using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using AmgSistemas.Framework.ConsultaCep;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.Componentes;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarCliente : TelaBase.BaseCE
    {
        #region"Variaveis"

        private string _IdentificadorPessoa;
        private List<Comum.Clases.Pessoa> Pessoas;
        private List<Comum.Clases.SegmentoComercial> SegmentosComerciais;
        private List<Comum.Clases.SituacaoPessoa> SituacoesPessoa;
        private CurrencyTextBox CurrencyTextBox;
        private Comum.Clases.Pessoa objPessoa = null;
        private Boolean _Visualizar;

        #endregion

        public GuardarCliente(string IdentificadorPessoa, Boolean Visualizar)
        {
            InitializeComponent();
            _IdentificadorPessoa = IdentificadorPessoa;
            _Visualizar = Visualizar;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            txtTelefoneCelular.Mask = "(00) 00000-0000";
            CarregarTela();
            this.pnlBase.Controls.Add(gbpCliente);
            base.Inicializar();
        }

        private void CarregarDados()
        {

            ContratoServico.Telas.GuardarCliente.Carregar.PeticaoGuardarClienteCarregar Peticao = new ContratoServico.Telas.GuardarCliente.Carregar.PeticaoGuardarClienteCarregar()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorCiente = _IdentificadorPessoa,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarCliente.Carregar.RespostaGuardarClienteCarregar, ContratoServico.Telas.GuardarCliente.Carregar.PeticaoGuardarClienteCarregar>(Peticao,
                  SDK.Operacoes.operacao.CarregarGuardarCliente, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                base.RespostaAgente(objSaida, operacao, Parametros);

                if (operacao == SDK.Operacoes.operacao.CarregarGuardarCliente)
                {
                    ContratoServico.Telas.GuardarCliente.Carregar.RespostaGuardarClienteCarregar objRespostaConvertido = (ContratoServico.Telas.GuardarCliente.Carregar.RespostaGuardarClienteCarregar)objSaida;

                    Pessoas = objRespostaConvertido.Funcionarios;
                    SituacoesPessoa = objRespostaConvertido.SituacoesPessoa;
                    SegmentosComerciais = objRespostaConvertido.SegmentosComerciais;
                    objPessoa = objRespostaConvertido.Cliente;

                    PreencherComboVendedores();
                    PreencherComboSituacao();
                    PreencherComboSegmentoComercial();
                    CarregarCliente();
                }
                else if (operacao == SDK.Operacoes.operacao.AtualizarPessoa)
                {

                    ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa objRespostaConvertido = (ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa)objSaida;

                    base.objNotificacao.ExibirMensagem("Cliente atualizado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                    DadoRetornar = objRespostaConvertido.Pessoa;


                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else if (operacao == SDK.Operacoes.operacao.InserirPessoa)
                {
                    ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa objRespostaConvertido = (ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa)objSaida;

                    base.objNotificacao.ExibirMensagem("Cliente cadastrado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                    DadoRetornar = objRespostaConvertido.Pessoa;


                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void PreencherComboSituacao()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(SituacoesPessoa, "Identificador", "Descricao");
            cmbSituacao = frmWindows.Util.PreencherCombobox(cmbSituacao, Items);

        }

        private void PreencherComboVendedores()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Pessoas, "Identificador", "DesNome");
            cmbVendedor = frmWindows.Util.PreencherCombobox(cmbVendedor, Items);

        }

        private void BloquearCampos()
        {

            if (_Visualizar)
            {
                txtNome.Enabled = false;
                txtNomeFantasia.Enabled = false;
                ucEndereco.BloquearControle();
                dtpNascimento.Enabled = false;
                txtCPF.Enabled = false;
                txtRG.Enabled = false;
                txtTabelaMercadoria.Enabled = false;
                txtNomeMae.Enabled = false;
                txtNomePai.Enabled = false;
                txtTelefoneCelular.Enabled = false;
                txtTelefoneFixo.Enabled = false;
                txtEmail.Enabled = false;
                txtFax.Enabled = false;
                txtCnpj.Enabled = false;
                txtInscricao.Enabled = false;
                txtContato.Enabled = false;
                txtLimite.Enabled = false;
                cmbSegmento.Enabled = false;
                cmbSituacao.Enabled = false;
                cmbVendedor.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }
        }

        private void PreencherComboSegmentoComercial()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(SegmentosComerciais, "Identificador", "Descricao");
            cmbSegmento = frmWindows.Util.PreencherCombobox(cmbSegmento, Items);

        }

        private void CarregarGridEmpresa()
        {
            dgvEmpresa.Rows.Add();
        }

        private void CarregarCliente()
        {

            if (objPessoa != null)
            {

                txtCodigo.Text = Convert.ToString(objPessoa.Codigo);
                txtNome.Text = objPessoa.DesNome;
                txtNomeFantasia.Text = objPessoa.DesNomeFantasia;
                ucEndereco.CarregarControle(objPessoa.EnderecoCompleto);
                dtpNascimento.Text = (objPessoa.DataNascimento != null ? Convert.ToString(objPessoa.DataNascimento) : string.Empty);
                txtCPF.Text = objPessoa.cpf;
                txtRG.Text = objPessoa.RG;
                txtCnpj.Text = objPessoa.cnpj;
                txtInscricao.Text = objPessoa.InscricaoEstadual;
                txtContato.Text = objPessoa.DesContato;
                txtTabelaMercadoria.Text = (objPessoa.TabelaVendas != null ? Convert.ToString(objPessoa.TabelaVendas) : string.Empty);
                txtLimite.Text = (objPessoa.NumLimite != null ? Convert.ToString(objPessoa.NumLimite) : string.Empty);
                txtEmail.Text = objPessoa.DesEmail;
                txtNomeMae.Text = objPessoa.DesNomeMae;
                txtNomePai.Text = objPessoa.DesNomePai;
                txtTelefoneFixo.Text = objPessoa.DesTelefoneFixo;

                if (!string.IsNullOrEmpty(objPessoa.DesTelefoneCelular))
                {
                    //55 31 98872 5044
                    string telefonePuro = objPessoa.DesTelefoneCelular.Trim().Replace("+", "").Replace("-", "").Replace("(", "").Replace(")", "");

                    if (telefonePuro.Length > 12)
                    {
                        // possui codigo do pais
                        if (telefonePuro.Substring(0, 2) == "55")
                        {
                            txtTelefoneCelular.Mask = "(00) 00000-0000";
                            txtTelefoneCelular.Text = objPessoa.DesTelefoneCelular.Substring(2, objPessoa.DesTelefoneCelular.Length - 2).Trim();
                        }
                        else
                        {
                            txtTelefoneCelular.Mask = "00 (000) 000-0000";
                            txtTelefoneCelular.Text = objPessoa.DesTelefoneCelular;
                        }
                    }
                    else
                    {
                        txtTelefoneCelular.Mask = "(00) 00000-0000";
                        txtTelefoneCelular.Text = objPessoa.DesTelefoneCelular;
                    }
                }


                txtFax.Text = objPessoa.DesTelefoneFax;

                if (objPessoa.SegmentoComercial != null)
                {
                    cmbSegmento = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbSegmento, objPessoa.SegmentoComercial.Identificador, "Identificador"));
                }

                if (objPessoa.PessoaResponsavel != null)
                {
                    cmbVendedor = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbVendedor, objPessoa.PessoaResponsavel.Identificador, "Identificador"));
                }

                if (objPessoa.SituacaoPessoa != null)
                {
                    cmbSituacao = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbSituacao, objPessoa.SituacaoPessoa.Identificador, "Identificador"));
                }

                dgvEmpresa.Rows[0].Cells[colCargo.Index].Value = objPessoa.DesCargo;
                dgvEmpresa.Rows[0].Cells[colEmpresa.Index].Value = objPessoa.DesEmpresaAnterior;

                if (_Visualizar)
                {
                    dgvEmpresa.Rows[0].Cells[colEditar.Index].Value = Properties.Resources.search_16;
                }

                if (objPessoa.NumSalario != null)
                {
                    dgvEmpresa.Rows[0].Cells[colSalario.Index].Value = Convert.ToString(objPessoa.NumSalario);
                }

            }
        }

        private void CarregarTela()
        {


            CarregarDados();
            CarregarGridEmpresa();
            BloquearCampos();

            ucEndereco.InformarParametrosObrigatorios(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes);

        }

        private void ExecutarGravar()
        {
            if (objPessoa == null)
            {
                objPessoa = new Comum.Clases.Pessoa();
            }
            objPessoa.TiposPessoa = new List<Comum.Clases.TipoPessoa>();
            objPessoa.TiposPessoa.Add(new Comum.Clases.TipoPessoa { Codigo = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE, Identificador = "2" });

            objPessoa.DesNome = txtNome.Text.Trim();
            objPessoa.DesNomeFantasia = txtNomeFantasia.Text.Trim();
            objPessoa.Identificador = _IdentificadorPessoa;
            objPessoa.EnderecoCompleto = ucEndereco.RecuperarEndereco();

            if (objPessoa.EnderecoCompleto != null)
            {
                objPessoa.Endereco = objPessoa.EnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First();
            }
            else
            {
                objPessoa.Endereco = null;
            }

            if (dtpNascimento.Checked)
            {
                objPessoa.DataNascimento = dtpNascimento.Value;
            }
            else
            {
                objPessoa.DataNascimento = null;
            }

            string cpf = txtCPF.Text.Replace(",", "");
            cpf = cpf.Replace("-", "");

            if (!string.IsNullOrEmpty(cpf.Trim()))
            {
                objPessoa.cpf = txtCPF.Text.Trim();
            }
            else
            {
                objPessoa.cpf = string.Empty;
            }

            objPessoa.RG = txtRG.Text.Trim();

            if (!string.IsNullOrEmpty(txtCnpj.Text.Replace(",", "").Replace("/", "").Replace("-", "").Trim()))
            {
                objPessoa.cnpj = txtCnpj.Text;
            }
            else
            {
                objPessoa.cnpj = string.Empty;
            }

            objPessoa.InscricaoEstadual = txtInscricao.Text;

            objPessoa.FuncionarioAtivo = false;
            objPessoa.FornecedorAtivo = false;

            string telefone = txtTelefoneFixo.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                objPessoa.DesTelefoneFixo = txtTelefoneFixo.Text;
            }
            else
            {
                objPessoa.DesTelefoneFixo = string.Empty;
            }

            telefone = txtTelefoneCelular.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");


            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                objPessoa.DesTelefoneCelular = txtTelefoneCelular.Text;
            }
            else
            {
                objPessoa.DesTelefoneCelular = string.Empty;
            }


            telefone = txtFax.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                objPessoa.DesTelefoneFax = txtFax.Text;
            }
            else
            {
                objPessoa.DesTelefoneFax = string.Empty;
            }

            objPessoa.DesContato = txtContato.Text;
            if (!string.IsNullOrEmpty(txtTabelaMercadoria.Text))
            {
                objPessoa.NumeroTabelaMercadoria = Convert.ToInt32(txtTabelaMercadoria.Text);
            }
            else
            {
                objPessoa.NumeroTabelaMercadoria = null;
            }

            if (!string.IsNullOrEmpty(txtLimite.Text))
            {
                objPessoa.NumLimite = Convert.ToDecimal(txtLimite.Text);
            }
            else
            {
                objPessoa.NumLimite = null;
            }

            objPessoa.DesEmail = txtEmail.Text;
            objPessoa.DesNomeMae = txtNomeMae.Text;
            objPessoa.DesNomePai = txtNomePai.Text;
            objPessoa.Empresa = new Comum.Clases.Empresa { Identificador = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador };

            objPessoa.Empresa = new Comum.Clases.Empresa() { Identificador = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador };
            // string ValorSelecionado = frmUtil.Util.RecuperarValorComponente(cmbVendedor);

            if (cmbVendedor.SelectedItem != null)
            {
                objPessoa.PessoaResponsavel = (Comum.Clases.Pessoa)(frmWindows.Util.RecuperarItemSelecionado(cmbVendedor, Pessoas, "Identificador"));
            }
            else
            {
                objPessoa.PessoaResponsavel = null;
            }

            //ValorSelecionado = frmUtil.Util.RecuperarValorComponente(cmbSegmento);

            if (cmbSegmento.SelectedItem != null)
            {
                objPessoa.SegmentoComercial = (Comum.Clases.SegmentoComercial)(frmWindows.Util.RecuperarItemSelecionado(cmbSegmento, SegmentosComerciais, "Identificador"));
            }
            else
            {
                objPessoa.SegmentoComercial = null;
            }

            //ValorSelecionado = frmUtil.Util.RecuperarValorComponente(cmbSituacao);

            if (cmbSituacao.SelectedItem != null)
            {
                objPessoa.SituacaoPessoa = (Comum.Clases.SituacaoPessoa)(frmWindows.Util.RecuperarItemSelecionado(cmbSituacao, SituacoesPessoa, "Identificador"));
            }
            else
            {
                objPessoa.SituacaoPessoa = null;
            }


            if (!string.IsNullOrEmpty(_IdentificadorPessoa))
            {
                ContratoServico.Pessoa.AtualizarPessoa.PeticaoAtualizarPessoa Peticao = new ContratoServico.Pessoa.AtualizarPessoa.PeticaoAtualizarPessoa();

                Peticao.Pessoa = objPessoa;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa, ContratoServico.Pessoa.AtualizarPessoa.PeticaoAtualizarPessoa>(Peticao, SDK.Operacoes.operacao.AtualizarPessoa,
                    new Comum.ParametrosTela.Generica
                    {
                        ExibirMensagemNenhumRegistro = false,
                        PreencherObjeto = true
                    }, null, true);
            }
            else
            {

                ContratoServico.Pessoa.InserirPessoa.PeticaoInserirPessoa Peticao = new ContratoServico.Pessoa.InserirPessoa.PeticaoInserirPessoa();

                Peticao.Pessoa = objPessoa;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa, ContratoServico.Pessoa.InserirPessoa.PeticaoInserirPessoa>(Peticao, SDK.Operacoes.operacao.InserirPessoa,
                    new Comum.ParametrosTela.Generica
                    {
                        ExibirMensagemNenhumRegistro = false,
                        PreencherObjeto = true
                    }, null, true);

            }


        }

        #endregion

        #region"Eventos"    

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
                return;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void txtLimite_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtLimite);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtTabelaMercadoria_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvEmpresa.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index)
                        {

                            DadosEmpresa objFrmDadosEmpresa = new DadosEmpresa(objPessoa, _Visualizar);

                            if (objFrmDadosEmpresa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {

                                if (objPessoa == null) objPessoa = new Comum.Clases.Pessoa();

                                if (objFrmDadosEmpresa.Pessoa != null)
                                {
                                    objPessoa.NumSalario = objFrmDadosEmpresa.Pessoa.NumSalario;
                                    objPessoa.DesCargo = objFrmDadosEmpresa.Pessoa.DesCargo;
                                    objPessoa.DesTelefoneEmpresaAnterior = objFrmDadosEmpresa.Pessoa.DesTelefoneEmpresaAnterior;
                                    objPessoa.ObservacaoRefPessoa = objFrmDadosEmpresa.Pessoa.ObservacaoRefPessoa;
                                    objPessoa.DesEmpresaAnterior = objFrmDadosEmpresa.Pessoa.DesEmpresaAnterior;

                                }

                                dgvEmpresa.Rows[e.RowIndex].Cells[colCargo.Index].Value = objPessoa.DesCargo;
                                dgvEmpresa.Rows[e.RowIndex].Cells[colEmpresa.Index].Value = objPessoa.DesEmpresaAnterior;
                                dgvEmpresa.Rows[e.RowIndex].Cells[colSalario.Index].Value = objPessoa.NumSalario;

                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvEmpresa_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvEmpresa.RowCount > 0)
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion
    }
}
