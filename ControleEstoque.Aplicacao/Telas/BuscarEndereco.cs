using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscarEndereco : TelaBase.BaseCE
    {
        #region"Variaveis"

        private Comum.Clases.Cidade CidadeSelecionada;
        private Comum.Clases.Bairro BairroSelecionado;
        private Comum.Clases.Endereco EnderecoSelecionado;
        private List<Comum.Clases.Estado> Estados;
        private List<Comum.Clases.Permissao> _Permissoes;
        private Comum.Clases.Estado _EnderecoCompleto;

        #endregion

        #region"Propriedades"

        public Comum.Clases.Estado EnderecoCompleto
        {
            get
            {
                return _EnderecoCompleto;
            }
        }

        #endregion

        private enum TipoLimpar
        {

            CIDADE = 1,
            BAIRRO = 2,
            ENDERECO = 3,
            GERAL = 4,
            ESTADO = 5


        }

        public BuscarEndereco(List<Comum.Clases.Permissao> Permissoes)
        {
            try
            {
                InitializeComponent();

                _Permissoes = Permissoes;
              
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnLimpar = "btnLimpar";
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

                Estados = ((ContratoServico.Endereco.RecuperarEstado.RespostaRecuperarEstado)objSaida).Estados;

                if (Estados != null && Estados.Count > 0)
                {

                    List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Estados, "Identificador", "Nome");
                    cmbEstado = frmWindows.Util.PreencherCombobox(cmbEstado, Items);
                }

            }
            else if(operacao == SDK.Operacoes.operacao.RegistrarEndereco)
            {

                _EnderecoCompleto = ((ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco)objSaida).Estado;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.aceitar, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false,false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F3)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            PreencherEstados();
            ConfigurarVisibilidade();
            this.pnlBase.Controls.Add(tlpPrincipal);
            base.Inicializar();
        }

        private void ConfigurarVisibilidade()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(_Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CONFIGURACAOENDERECO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                btnInserirBairro.Visible = false;
                btnInserirCidade.Visible = false;
                btnInserirEndereco.Visible = false;
            }

        }

        private void PreencherEstados()
        {
            ContratoServico.Endereco.RecuperarEstado.PeticaoRecuperarEstado Peticao = new ContratoServico.Endereco.RecuperarEstado.PeticaoRecuperarEstado();

            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Endereco.RecuperarEstado.RespostaRecuperarEstado, ContratoServico.Endereco.RecuperarEstado.PeticaoRecuperarEstado>(Peticao,
                    SDK.Operacoes.operacao.RecuperarEstado,
                    new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);           

        }

        private void Limpar(TipoLimpar Tipo, Boolean LimparPai)
        {

            switch (Tipo)
            {

                case TipoLimpar.CIDADE:

                    if (LimparPai)
                    {
                        CidadeSelecionada = null;
                        txtCidade.Text = string.Empty;
                        btnBairro.Enabled = false;
                        btnLimparBairro.Enabled = false;
                        btnInserirBairro.Enabled = false;
                    }

                    BairroSelecionado = null;
                    EnderecoSelecionado = null;
                    txtEndereco.Text = string.Empty;
                    txtCep.Text = string.Empty;
                    txtBairro.Text = string.Empty;
                    btnEndereco.Enabled = false;
                    btnLimparEndereco.Enabled = false;
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);

                    break;

                case TipoLimpar.BAIRRO:

                    if (LimparPai)
                    {

                        BairroSelecionado = null;
                        txtBairro.Text = string.Empty;
                        btnEndereco.Enabled = false;
                        btnLimparEndereco.Enabled = false;
                        btnInserirEndereco.Enabled = false;

                    }

                    EnderecoSelecionado = null;
                    txtEndereco.Text = string.Empty;
                    txtCep.Text = string.Empty;
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);

                    break;
                case TipoLimpar.ENDERECO:

                    if (LimparPai)
                    {

                        EnderecoSelecionado = null;
                        txtEndereco.Text = string.Empty;
                        txtCep.Text = string.Empty;
                        this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                    }


                    break;

                case TipoLimpar.GERAL:

                    CidadeSelecionada = null;
                    BairroSelecionado = null;
                    EnderecoSelecionado = null;
                    txtEndereco.Text = string.Empty;
                    txtCidade.Text = string.Empty;
                    txtBairro.Text = string.Empty;
                    btnLimparEndereco.Enabled = false;
                    btnEndereco.Enabled = false;
                    btnLimparBairro.Enabled = false;
                    btnBairro.Enabled = false;
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                    btnInserirEndereco.Enabled = false;
                    btnInserirBairro.Enabled = false;
                    txtCep.Text = string.Empty;
                    btnInserirCidade.Enabled = false;
                    btnLimparCidade.Enabled = false;
                    btnCidade.Enabled = false;
                    cmbEstado.SelectedItem = null;

                    break;

                case TipoLimpar.ESTADO:

                    CidadeSelecionada = null;
                    BairroSelecionado = null;
                    EnderecoSelecionado = null;
                    txtEndereco.Text = string.Empty;
                    txtCidade.Text = string.Empty;
                    txtBairro.Text = string.Empty;
                    btnLimparEndereco.Enabled = false;
                    btnEndereco.Enabled = false;
                    btnLimparBairro.Enabled = false;
                    btnBairro.Enabled = false;
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                    btnInserirEndereco.Enabled = false;
                    btnInserirBairro.Enabled = false;
                    txtCep.Text = string.Empty;

                    break;
            }
        }
        #endregion

        #region"Eventos"

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (cmbEstado.SelectedIndex >= 0)
                {
                    btnCidade.Enabled = true;
                    btnLimparCidade.Enabled = true;
                    btnInserirCidade.Enabled = true;
                }
                else
                {
                    btnCidade.Enabled = false;
                    btnLimparCidade.Enabled = false;
                    btnInserirCidade.Enabled = false;

                }

                Limpar(TipoLimpar.ESTADO, false);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }


        }

        private void btnBairro_Click(object sender, EventArgs e)
        {
            try
            {

                if (CidadeSelecionada != null)
                {
                    Helper frmHelper = new Helper(Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO, CidadeSelecionada.Identificador);

                    frmHelper.ShowDialog();

                    if (frmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (frmHelper.DadoSelecinado != null)
                        {

                            BairroSelecionado = (Comum.Clases.Bairro)(frmHelper.DadoSelecinado);
                            txtBairro.Text = BairroSelecionado.Codigo + " - " + BairroSelecionado.Nome;
                            btnEndereco.Enabled = true;
                            btnLimparEndereco.Enabled = true;
                            btnInserirEndereco.Enabled = true;

                        }
                        else
                        {
                            btnEndereco.Enabled = false;
                            btnLimparEndereco.Enabled = false;
                            btnInserirEndereco.Enabled = false;
                        }

                        Limpar(TipoLimpar.BAIRRO, false);
                    }

                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnCidade_Click(object sender, EventArgs e)
        {

            try
            {


                Comum.Clases.Estado objEstado = (Comum.Clases.Estado)(frmWindows.Util.RecuperarItemSelecionado(cmbEstado, Estados, "Identificador"));

                Helper frmHelper = new Helper(Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE, objEstado.Identificador);
                frmHelper.ShowDialog();

                if (frmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmHelper.DadoSelecinado != null)
                    {

                        CidadeSelecionada = (Comum.Clases.Cidade)(frmHelper.DadoSelecinado);
                        txtCidade.Text = CidadeSelecionada.Codigo + " - " + CidadeSelecionada.Nome;
                        btnBairro.Enabled = true;
                        btnLimparBairro.Enabled = true;
                        btnInserirBairro.Enabled = true;

                    }
                    else
                    {
                        btnBairro.Enabled = false;
                        btnInserirBairro.Enabled = false;
                        btnLimparBairro.Enabled = false;
                        CidadeSelecionada = null;
                    }

                    Limpar(TipoLimpar.CIDADE, false);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnEndereco_Click(object sender, EventArgs e)
        {

            try
            {
                if (BairroSelecionado != null)
                {
                    Helper frmHelper = new Helper(Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO, BairroSelecionado.Identificador);
                    frmHelper.ShowDialog();

                    if (frmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (frmHelper.DadoSelecinado != null)
                        {

                            EnderecoSelecionado = (Comum.Clases.Endereco)(frmHelper.DadoSelecinado);
                            txtEndereco.Text = EnderecoSelecionado.Codigo + " - " + EnderecoSelecionado.DescricaoRua;
                            txtCep.Text = EnderecoSelecionado.DescricaoCep;
                            this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar,false);

                        }
                        else
                        {
                            this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                        }

                        Limpar(TipoLimpar.ENDERECO, false);
                    }

                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimparCidade_Click(object sender, EventArgs e)
        {
            try
            {
                Limpar(TipoLimpar.CIDADE, true);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimparBairro_Click(object sender, EventArgs e)
        {
            try
            {

                Limpar(TipoLimpar.BAIRRO, true);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimparEndereco_Click(object sender, EventArgs e)
        {
            try
            {

                Limpar(TipoLimpar.ENDERECO, true);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

                this.Close();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            try
            {

                Limpar(TipoLimpar.GERAL, true);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserirCidade_Click(object sender, EventArgs e)
        {
            try
            {

                Comum.Clases.Estado objEstado = (Comum.Clases.Estado)(frmWindows.Util.RecuperarItemSelecionado(cmbEstado, Estados, "Identificador"));

                GuardarItemHelper objFrmHelper = new GuardarItemHelper(Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE, objEstado.Identificador);

                objFrmHelper.ShowDialog();

                if (objFrmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (objFrmHelper.ItemSelecionado != null)
                    {

                        Comum.Clases.Cidade objCidadeSelecionada = (Comum.Clases.Cidade)(objFrmHelper.ItemSelecionado);

                        txtCidade.Text = objCidadeSelecionada.Codigo + " - " + objCidadeSelecionada.Nome;
                        CidadeSelecionada = objCidadeSelecionada;
                        btnBairro.Enabled = true;
                        btnLimparBairro.Enabled = true;
                        btnInserirBairro.Enabled = true;

                    }
                    else
                    {
                        btnBairro.Enabled = false;
                        btnInserirBairro.Enabled = false;
                        btnLimparBairro.Enabled = false;
                        CidadeSelecionada = null;
                    }
                    Limpar(TipoLimpar.CIDADE, false);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserirBairro_Click(object sender, EventArgs e)
        {
            try
            {

                if (CidadeSelecionada != null)
                {

                    GuardarItemHelper objFrmHelper = new GuardarItemHelper(Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO, CidadeSelecionada.Identificador);

                    objFrmHelper.ShowDialog();

                    if (objFrmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (objFrmHelper.ItemSelecionado != null)
                        {

                            Comum.Clases.Bairro objBairroSelecionado = (Comum.Clases.Bairro)(objFrmHelper.ItemSelecionado);

                            txtBairro.Text = objBairroSelecionado.Codigo + " - " + objBairroSelecionado.Nome;
                            BairroSelecionado = objBairroSelecionado;
                            btnEndereco.Enabled = true;
                            btnLimparEndereco.Enabled = true;
                            btnInserirEndereco.Enabled = true;

                        }
                        else
                        {
                            btnEndereco.Enabled = false;
                            btnLimparEndereco.Enabled = false;
                            btnInserirEndereco.Enabled = false;
                        }

                        Limpar(TipoLimpar.BAIRRO, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserirEndereco_Click(object sender, EventArgs e)
        {
            try
            {

                if (BairroSelecionado != null)
                {

                    GuardarItemHelper objFrmHelper = new GuardarItemHelper(Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO, BairroSelecionado.Identificador);

                    objFrmHelper.ShowDialog();

                    if (objFrmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (objFrmHelper.ItemSelecionado != null)
                        {

                            Comum.Clases.Endereco objEnderecoSelecionado = (Comum.Clases.Endereco)(objFrmHelper.ItemSelecionado);

                            txtEndereco.Text = objEnderecoSelecionado.Codigo + " - " + objEnderecoSelecionado.DescricaoRua;
                            txtCep.Text = objEnderecoSelecionado.DescricaoCep;
                            EnderecoSelecionado = objEnderecoSelecionado;
                            this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, false);

                        }
                        else
                        {
                            this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                        }

                        Limpar(TipoLimpar.ENDERECO, false);
                    }
                }
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

                if (EnderecoSelecionado != null && !string.IsNullOrEmpty(EnderecoSelecionado.DescricaoRua))
                {

                    Comum.Clases.Estado objEstado = (Comum.Clases.Estado)(frmWindows.Util.RecuperarItemSelecionado(cmbEstado, Estados, "Identificador"));
                                 
                    ContratoServico.Endereco.RegistrarEndereco.PeticaoRegistrarEndereco Peticao = new ContratoServico.Endereco.RegistrarEndereco.PeticaoRegistrarEndereco()
                    {
                        Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                        IdentificadorEstado = objEstado.Identificador,
                        IdentificadorCidade = CidadeSelecionada.Identificador,
                        IdentificadorBairro = BairroSelecionado.Identificador,
                        Rua = EnderecoSelecionado.DescricaoRua
                    };
                    Agente.Agente.InvocarServico<ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco, ContratoServico.Endereco.RegistrarEndereco.PeticaoRegistrarEndereco>(Peticao,
                            SDK.Operacoes.operacao.RegistrarEndereco, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
                }
                else
                {

                    Aplicacao.Classes.Util.ExibirMensagemErro("Favor selecionar o endereço completo.");
                    return;
                }


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        
        #endregion

        

    }
}
