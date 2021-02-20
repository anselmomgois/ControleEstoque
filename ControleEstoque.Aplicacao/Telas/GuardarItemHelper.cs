using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;


namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarItemHelper : TelaBase.BaseCE
    {
        public GuardarItemHelper(Comum.Enumeradores.Enumeradores.TipoHelper TipoHelper, string IdentificadorPai)
        {
            InitializeComponent();

            _TipoHelper = TipoHelper;
            _IdentificadorPai = IdentificadorPai;

        }

        #region "Enumeradores"

        private enum ComponentesTela
        {

            DESCRICAO = 0,
            DDD = 1,
            IBGE = 2,
            CEP = 3

        }

        #endregion
        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnInserir = "btnInserir";
        private const string btnCancelar = "btnGravar";
        #endregion
        #region "Variaveis"

        private Comum.Enumeradores.Enumeradores.TipoHelper _TipoHelper;
        private string _IdentificadorPai;
        private object Items;
        private string _IdentificadorCorrente;
        private object _ItemSelecionado;

        #endregion

        #region "Propriedades"

        public object ItemSelecionado
        {
            get
            {
                return _ItemSelecionado;
            }
        }

        #endregion

        #region"Metodos"

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarEstado)
            {

                Comum.Clases.Estado objEstado = ((ContratoServico.Endereco.RecuperarEstado.RespostaRecuperarEstado)objSaida).Estados.FirstOrDefault();

                if (objEstado != null)
                {
                    txtItemPai.Text = objEstado.Codigo + " - " + objEstado.Nome;

                    ContratoServico.Endereco.RecuperarCidades.PeticaoRecuperarCidades Peticao = new ContratoServico.Endereco.RecuperarCidades.PeticaoRecuperarCidades()
                    {
                        Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                        IdentificadorEstado = _IdentificadorPai
                    };
                    Agente.Agente.InvocarServico<ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades, ContratoServico.Endereco.RecuperarCidades.PeticaoRecuperarCidades>(Peticao,
                            SDK.Operacoes.operacao.RecuperarCidades, new Comum.ParametrosTela.Generica() { DiferenciadorChamada = "RECUPERAR_ESTADO" }, null, true);
                }

            }
            else if (operacao == SDK.Operacoes.operacao.RecuperarCidades)
            {

                if (Parametros.DiferenciadorChamada == "RECUPERAR_ESTADO")
                {
                    List<Comum.Clases.Cidade> objCidades = ((ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades)objSaida).Cidades;

                    Items = objCidades;

                    if (objCidades != null && objCidades.Count > 0)
                    {

                        dgvItems.Rows.Clear();

                        foreach (Comum.Clases.Cidade Cid in objCidades)
                        {

                            dgvItems.Rows.Add();
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colIdentificador.Index].Value = Cid.Identificador;
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colCodigo.Index].Value = Cid.Codigo;
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colDescricao.Index].Value = Cid.Nome;

                        }

                        foreach (DataGridViewRow dr in dgvItems.Rows)
                        {
                            dr.Selected = false;
                        }
                    }
                }
                else
                {
                    Comum.Clases.Cidade objCidade = ((ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades)objSaida).Cidades.FirstOrDefault();

                    if (objCidade != null)
                    {
                        txtItemPai.Text = objCidade.Codigo + " - " + objCidade.Nome;

                        ContratoServico.Endereco.RecuperarBairro.PeticaoRecuperarBairro Peticao = new ContratoServico.Endereco.RecuperarBairro.PeticaoRecuperarBairro()
                        {
                            Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                            IdentificadorCidade = objCidade.Identificador
                        };
                        Agente.Agente.InvocarServico<ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro, ContratoServico.Endereco.RecuperarBairro.PeticaoRecuperarBairro>(Peticao,
                                SDK.Operacoes.operacao.RecuperarBairro, new Comum.ParametrosTela.Generica() { DiferenciadorChamada = "RECUPERAR_CIDADE" }, null, true);

                    }
                }
            }
            else if (operacao == SDK.Operacoes.operacao.RecuperarBairro)
            {

                if (Parametros.DiferenciadorChamada == "RECUPERAR_CIDADE")
                {
                    List<Comum.Clases.Bairro> objBairros = ((ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro)objSaida).Bairros;

                    Items = objBairros;

                    if (objBairros != null && objBairros.Count > 0)
                    {

                        dgvItems.Rows.Clear();

                        foreach (Comum.Clases.Bairro bairro in objBairros)
                        {

                            dgvItems.Rows.Add();
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colIdentificador.Index].Value = bairro.Identificador;
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colCodigo.Index].Value = bairro.Codigo;
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colDescricao.Index].Value = bairro.Nome;

                        }

                        foreach (DataGridViewRow dr in dgvItems.Rows)
                        {
                            dr.Selected = false;
                        }
                    }
                }
                else
                {
                    Comum.Clases.Bairro objBairro = ((ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro)objSaida).Bairros.FirstOrDefault();

                    if (objBairro != null)
                    {
                        txtItemPai.Text = objBairro.Codigo + " - " + objBairro.Nome;

                        ContratoServico.Endereco.PesquisarEndereco.PeticaoPesquisarEndereco Peticao = new ContratoServico.Endereco.PesquisarEndereco.PeticaoPesquisarEndereco()
                        {
                            Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                            IdentificadorBairro = objBairro.Identificador
                        };
                        Agente.Agente.InvocarServico<ContratoServico.Endereco.PesquisarEndereco.RespostaPesquisarEndereco, ContratoServico.Endereco.PesquisarEndereco.PeticaoPesquisarEndereco>(Peticao,
                                SDK.Operacoes.operacao.PesquisarEndereco, new Comum.ParametrosTela.Generica() { DiferenciadorChamada = "RECUPERAR_BAIRRO" }, null, true);
                        
                    }
                }
            }
            else if (operacao == SDK.Operacoes.operacao.PesquisarEndereco)
            {
                if (Parametros.DiferenciadorChamada == "RECUPERAR_BAIRRO")
                {

                    List<Comum.Clases.Endereco> objEnderecos = ((ContratoServico.Endereco.PesquisarEndereco.RespostaPesquisarEndereco)objSaida).Enderecos;

                    Items = objEnderecos;

                    if (objEnderecos != null && objEnderecos.Count > 0)
                    {

                        dgvItems.Rows.Clear();

                        foreach (Comum.Clases.Endereco Endereco in objEnderecos)
                        {

                            dgvItems.Rows.Add();
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colIdentificador.Index].Value = Endereco.Identificador;
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colCodigo.Index].Value = Endereco.Codigo;
                            dgvItems.Rows[dgvItems.Rows.Count - 1].Cells[colDescricao.Index].Value = Endereco.DescricaoRua;

                        }

                        foreach (DataGridViewRow dr in dgvItems.Rows)
                        {
                            dr.Selected = false;
                        }
                    }

                }
            }
            else if(operacao == SDK.Operacoes.operacao.SetCidades)
            {
                LimparCampos();
                HabilitarDesabilitaCampos(false);

                Aplicacao.Classes.Util.ExibirMensagemSucesso("Registro Gravado com sucesso.");

                CarregarCidade();
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }
            else if(operacao == SDK.Operacoes.operacao.SetBairro)
            {
                LimparCampos();
                HabilitarDesabilitaCampos(false);

                Aplicacao.Classes.Util.ExibirMensagemSucesso("Registro Gravado com sucesso.");

                CarregarBairro();
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }
            else if(operacao == SDK.Operacoes.operacao.SetEndereco)
            {
                LimparCampos();
                HabilitarDesabilitaCampos(false);

                Aplicacao.Classes.Util.ExibirMensagemSucesso("Registro Gravado com sucesso.");

                CarregarEndereco();
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.aceitar, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(null, null, null, null, "Gravar (F4)", btnCancelar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F4, false, false, false);
            base.MontarMenu(GerarGrupo, false);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpPrincipal);
            this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE)
            {
                CarregarCidade();
            }
            else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO)
            {
                CarregarBairro();
            }
            else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO)
            {

                CarregarEndereco();
            }

            ConfiguraComponentes();
            base.Inicializar();
        }

        private void LimparCampos()
        {
            txtCep.Text = string.Empty;
            txtDDD.Text = string.Empty;
            txtItemFilho.Text = string.Empty;
            txtIbge.Text = string.Empty;
        }

        private void HabilitarDesabilitaCampos(Boolean Habilita)
        {

            txtCep.Enabled = Habilita;
            txtDDD.Enabled = Habilita;
            txtItemFilho.Enabled = Habilita;
            txtIbge.Enabled = Habilita;

        }

        private void ConfiguraComponentes()
        {

            if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE)
            {
                tlpControlesTexto.RowStyles[ComponentesTela.CEP.GetHashCode()].Height = 0;
            }
            else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO)
            {
                tlpControlesTexto.RowStyles[ComponentesTela.CEP.GetHashCode()].Height = 0;
                tlpControlesTexto.RowStyles[ComponentesTela.DDD.GetHashCode()].Height = 0;
                tlpControlesTexto.RowStyles[ComponentesTela.IBGE.GetHashCode()].Height = 0;
                tlpControles.RowStyles[2].Height = 50;

            }
            else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO)
            {
                tlpControlesTexto.RowStyles[ComponentesTela.DDD.GetHashCode()].Height = 0;
                tlpControlesTexto.RowStyles[ComponentesTela.IBGE.GetHashCode()].Height = 0;
                tlpControles.RowStyles[2].Height = 50;
                txtDDD.Visible = false;
                txtIbge.Visible = false;
            }
        }

        private void CarregarCidade()
        {

            ContratoServico.Endereco.RecuperarEstado.PeticaoRecuperarEstado Peticao = new ContratoServico.Endereco.RecuperarEstado.PeticaoRecuperarEstado()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEstado = _IdentificadorPai
            };
            Agente.Agente.InvocarServico<ContratoServico.Endereco.RecuperarEstado.RespostaRecuperarEstado, ContratoServico.Endereco.RecuperarEstado.PeticaoRecuperarEstado>(Peticao,
                    SDK.Operacoes.operacao.RecuperarEstado, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

            this.Text = "Cidade";
            lblItemPai.Text = "Estado";
        }

        private void CarregarBairro()
        {

            ContratoServico.Endereco.RecuperarCidades.PeticaoRecuperarCidades Peticao = new ContratoServico.Endereco.RecuperarCidades.PeticaoRecuperarCidades()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Identificador = _IdentificadorPai
            };
            Agente.Agente.InvocarServico<ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades, ContratoServico.Endereco.RecuperarCidades.PeticaoRecuperarCidades>(Peticao,
                    SDK.Operacoes.operacao.RecuperarCidades, new Comum.ParametrosTela.Generica(), null, true);

            this.Text = "Bairro";
            lblItemPai.Text = "Cidade";
        }

        private void CarregarEndereco()
        {

            ContratoServico.Endereco.RecuperarBairro.PeticaoRecuperarBairro Peticao = new ContratoServico.Endereco.RecuperarBairro.PeticaoRecuperarBairro()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Identificador = _IdentificadorPai
            };
            Agente.Agente.InvocarServico<ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro, ContratoServico.Endereco.RecuperarBairro.PeticaoRecuperarBairro>(Peticao,
                    SDK.Operacoes.operacao.RecuperarBairro, new Comum.ParametrosTela.Generica(), null, true);


            this.Text = "Endereço";
            lblItemPai.Text = "Bairro";

        }

        private void ExecutarGravar()
        {

            if (string.IsNullOrEmpty(txtItemFilho.Text))
            {

                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Descrição não informada.");

            }

            if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE)
            {


                Comum.Clases.Cidade CidadeCorrente = null;

                if (Items != null)
                {

                    CidadeCorrente = (from Comum.Clases.Cidade c in (List<Comum.Clases.Cidade>)(Items) where c.Identificador == _IdentificadorCorrente select c).FirstOrDefault();

                }

                if (CidadeCorrente == null) CidadeCorrente = new Comum.Clases.Cidade();

                CidadeCorrente.Nome = txtItemFilho.Text;
                CidadeCorrente.IBGE = txtIbge.Text;
                CidadeCorrente.DDD = txtDDD.Text;

                ContratoServico.Endereco.SetCidades.PeticaoSetCidades Peticao = new ContratoServico.Endereco.SetCidades.PeticaoSetCidades()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEstado = _IdentificadorPai,
                    Cidade = CidadeCorrente
                };
                Agente.Agente.InvocarServico<ContratoServico.Endereco.SetCidades.RespostaSetCidades, ContratoServico.Endereco.SetCidades.PeticaoSetCidades>(Peticao,
                        SDK.Operacoes.operacao.SetCidades, new Comum.ParametrosTela.Generica(), null, true);                
            }
            else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO)
            {

                Comum.Clases.Bairro BairroCorrente = null;

                if (Items != null)
                {

                    BairroCorrente = (from Comum.Clases.Bairro b in (List<Comum.Clases.Bairro>)(Items) where b.Identificador == _IdentificadorCorrente select b).FirstOrDefault();

                }

                if (BairroCorrente == null) BairroCorrente = new Comum.Clases.Bairro();

                BairroCorrente.Nome = txtItemFilho.Text;

                ContratoServico.Endereco.SetBairro.PeticaoSetBairro Peticao = new ContratoServico.Endereco.SetBairro.PeticaoSetBairro()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorCidade = _IdentificadorPai,
                    Bairro = BairroCorrente
                };
                Agente.Agente.InvocarServico<ContratoServico.Endereco.SetBairro.RespostaSetBairro, ContratoServico.Endereco.SetBairro.PeticaoSetBairro>(Peticao,
                        SDK.Operacoes.operacao.SetBairro, new Comum.ParametrosTela.Generica(), null, true);               

            }
            else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO)
            {

                Comum.Clases.Endereco EnderecoCorrente = null;

                if (Items != null)
                {

                    EnderecoCorrente = (from Comum.Clases.Endereco b in (List<Comum.Clases.Endereco>)(Items) where b.Identificador == _IdentificadorCorrente select b).FirstOrDefault();

                }

                if (EnderecoCorrente == null) EnderecoCorrente = new Comum.Clases.Endereco();

                EnderecoCorrente.DescricaoRua = txtItemFilho.Text;

                string cep = txtCep.Text.Replace(",", "");
                cep = cep.Replace("-", "");

                if (!string.IsNullOrEmpty(cep.Trim()))
                {
                    EnderecoCorrente.DescricaoCep = txtCep.Text;
                }

                ContratoServico.Endereco.SetEndereco.PeticaoSetEndereco Peticao = new ContratoServico.Endereco.SetEndereco.PeticaoSetEndereco()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorBairro = _IdentificadorPai,
                    Endereco = EnderecoCorrente
                };
                Agente.Agente.InvocarServico<ContratoServico.Endereco.SetEndereco.RespostaSetEndereco, ContratoServico.Endereco.SetEndereco.PeticaoSetEndereco>(Peticao,
                        SDK.Operacoes.operacao.SetEndereco, new Comum.ParametrosTela.Generica(), null, true);               
            }

        }

        #endregion

        #region "Eventos"

        private void txtDDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                frmUtil.Util.SomenteNumero(sender, e);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                frmUtil.Util.SomenteNumero(sender, e);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvItems_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvItems.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index)
                        {
                            //Define o cursor para Hand
                            Cursor.Current = Cursors.Hand;
                        }
                        else
                        {
                            //Define o cursor para default
                            Cursor.Current = Cursors.Default;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                _IdentificadorCorrente = string.Empty;
                LimparCampos();
                HabilitarDesabilitaCampos(true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }


        private void btnAceitar_Click(object sender, EventArgs e)
        {

            try
            {

                if (!string.IsNullOrEmpty(_IdentificadorCorrente) && Items != null)
                {

                    if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE)
                    {

                        Comum.Clases.Cidade CidadeCorrente = null;

                        CidadeCorrente = (from Comum.Clases.Cidade c in (List<Comum.Clases.Cidade>)(Items) where c.Identificador == _IdentificadorCorrente select c).FirstOrDefault();

                        _ItemSelecionado = CidadeCorrente;

                    }
                    else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO)
                    {

                        Comum.Clases.Bairro BairroCorrente = null;
                        BairroCorrente = (from Comum.Clases.Bairro b in (List<Comum.Clases.Bairro>)(Items) where b.Identificador == _IdentificadorCorrente select b).FirstOrDefault();
                        _ItemSelecionado = BairroCorrente;

                    }
                    else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO)
                    {
                        Comum.Clases.Endereco EnderecoCorrente = null;
                        EnderecoCorrente = (from Comum.Clases.Endereco en in (List<Comum.Clases.Endereco>)(Items) where en.Identificador == _IdentificadorCorrente select en).FirstOrDefault();
                        _ItemSelecionado = EnderecoCorrente;
                    }

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {

                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.ColumnIndex == colEditar.Index && e.RowIndex >= 0)
                {

                    _IdentificadorCorrente = dgvItems.Rows[e.RowIndex].Cells[colIdentificador.Index].Value as string;
                    HabilitarDesabilitaCampos(true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);

                    if (Items != null)
                    {
                        if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE)
                        {
                            Comum.Clases.Cidade CidadeCorrente = null;

                            CidadeCorrente = (from Comum.Clases.Cidade c in (List<Comum.Clases.Cidade>)(Items) where c.Identificador == _IdentificadorCorrente select c).FirstOrDefault();

                            if (CidadeCorrente != null)
                            {

                                txtItemFilho.Text = CidadeCorrente.Nome;
                                txtDDD.Text = CidadeCorrente.DDD;
                                txtIbge.Text = CidadeCorrente.IBGE;

                            }
                        }
                        else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO)
                        {
                            Comum.Clases.Bairro BairroCorrente = null;

                            BairroCorrente = (from Comum.Clases.Bairro b in (List<Comum.Clases.Bairro>)(Items) where b.Identificador == _IdentificadorCorrente select b).FirstOrDefault();

                            if (BairroCorrente != null)
                            {

                                txtItemFilho.Text = BairroCorrente.Nome;
                            }

                        }
                        else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO)
                        {
                            Comum.Clases.Endereco EnderecoCorrente = null;

                            EnderecoCorrente = (from Comum.Clases.Endereco b in (List<Comum.Clases.Endereco>)(Items) where b.Identificador == _IdentificadorCorrente select b).FirstOrDefault();

                            if (EnderecoCorrente != null)
                            {

                                txtItemFilho.Text = EnderecoCorrente.DescricaoRua;
                                txtCep.Text = EnderecoCorrente.DescricaoCep;
                            }

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.RowIndex >= 0)
                {
                    _IdentificadorCorrente = dgvItems.Rows[e.RowIndex].Cells[colIdentificador.Index].Value as string;
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, false);
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {
                ExecutarGravar();
            }
            catch (Execao.ExecaoNegocio ex)
            {

                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }

        }


        #endregion

        private void dgvItems_Leave(object sender, EventArgs e)
        {
            try
            {
                dgvItems.ClearSelection();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }


    }
}
