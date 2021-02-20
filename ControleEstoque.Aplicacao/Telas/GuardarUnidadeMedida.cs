using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarUnidadeMedida : TelaBase.BaseCE
    {
        public GuardarUnidadeMedida(string IdentificadorUnidadeMedida)
        {
            InitializeComponent();

            _IdentificadorUnidadeMedida = IdentificadorUnidadeMedida;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorUnidadeMedida = string.Empty;
        private Comum.Clases.UnidadeMedida _objUnidadeMedida = null;
        private List<Comum.Clases.UnidadeMedida> _objUnidadesMedida = null;
        private CurrencyTextBox CurrencyTextBox;

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

            if (operacao == SDK.Operacoes.operacao.RecuperarUnidadeMedida)
            {
                _objUnidadeMedida = ((ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.RespostaRecuperarUnidadeMedida)objSaida).UnidadeMedida;

                PreencherTela();
            }
            else if(operacao == SDK.Operacoes.operacao.RecuperarUnidadesMedida)
            {

                _objUnidadesMedida = ((ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida)objSaida).UnidadesMedida;

                if (!string.IsNullOrEmpty(_IdentificadorUnidadeMedida))
                {
                    _objUnidadesMedida.RemoveAll(un => un.Identificador == _IdentificadorUnidadeMedida);
                }

                CarregarComboUnidadeMedida();
                RecuperarUnidadeMedida();
            }
            else if(operacao == SDK.Operacoes.operacao.SetUnidadeMedida)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tableLayoutPanel1);
            CarregarTela();
            base.Inicializar();
        }

        private void RecuperarUnidadeMedida()
        {

            if (!string.IsNullOrEmpty(_IdentificadorUnidadeMedida))
            {               

                ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.PeticaoRecuperarUnidadeMedida Peticao = new ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.PeticaoRecuperarUnidadeMedida();

                Peticao.IdentificadorUnidadeMedida = _IdentificadorUnidadeMedida;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;


                Agente.Agente.InvocarServico<ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.RespostaRecuperarUnidadeMedida, ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.PeticaoRecuperarUnidadeMedida>(Peticao,
                        SDK.Operacoes.operacao.RecuperarUnidadeMedida,
                        new Comum.ParametrosTela.Generica() { PreencherObjeto = false, ExibirMensagemNenhumRegistro = false }, null, true);

            }

        }

        private void PreencherTela()
        {

            if (_objUnidadeMedida != null)
            {
                txtCodigo.Text = _objUnidadeMedida.Codigo;
                txtNome.Text = _objUnidadeMedida.Descricao;
                if (_objUnidadeMedida.UnidademedidaPai != null)
                {
                    txtUnidadePai.Text = Convert.ToString(_objUnidadeMedida.NumValorUnidadePai);
                    ddlUnidadePai = (ComboBox)(frmWindows.Util.SelecionarItemControle(ddlUnidadePai, _objUnidadeMedida.UnidademedidaPai.Identificador, "Identificador"));
                }
            }
        }
        private void RecuperarUnidadesMedida()
        {
            ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida Peticao = new ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida();

            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.RecuperarUnidadesFilhas = true;


            Agente.Agente.InvocarServico<ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida, ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida>(Peticao,
                    SDK.Operacoes.operacao.RecuperarUnidadesMedida,
                    new Comum.ParametrosTela.Generica() { PreencherObjeto = false, ExibirMensagemNenhumRegistro = false }, null, true);           

        }

        private void CarregarComboUnidadeMedida()
        {

            if (_objUnidadesMedida != null && _objUnidadesMedida.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_objUnidadesMedida, "Identificador", "Descricao");
                ddlUnidadePai = frmWindows.Util.PreencherCombobox(ddlUnidadePai, Items);

            }
            else
            {
                ddlUnidadePai.Enabled = false;
                txtUnidadePai.Text = string.Empty;
                txtUnidadePai.Enabled = false;
            }
        }

        private void CarregarTela()
        {

            RecuperarUnidadesMedida();           
           
        }

        private void ExecutarGravar()
        {

            Comum.Clases.UnidadeMedida objUnidadeMedida = new Comum.Clases.UnidadeMedida();

            objUnidadeMedida.Descricao = txtNome.Text.Trim();
            objUnidadeMedida.Codigo = txtCodigo.Text.Trim();
            objUnidadeMedida.Identificador = _IdentificadorUnidadeMedida;

            if (ddlUnidadePai.SelectedItem != null)
            {
                objUnidadeMedida.UnidademedidaPai = (Comum.Clases.UnidadeMedida)(frmWindows.Util.RecuperarItemSelecionado(ddlUnidadePai, _objUnidadesMedida, "Identificador"));

                if(!string.IsNullOrEmpty(txtUnidadePai.Text))
                {
                objUnidadeMedida.NumValorUnidadePai = Convert.ToDecimal(txtUnidadePai.Text);
                }
            }


            ContratoServico.UnidadeMedida.SetUnidadeMedida.PeticaoSetUnidadeMedida Peticao = new ContratoServico.UnidadeMedida.SetUnidadeMedida.PeticaoSetUnidadeMedida();

            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.UnidadeMedida = objUnidadeMedida;


            Agente.Agente.InvocarServico<ContratoServico.UnidadeMedida.SetUnidadeMedida.RespostaSetUnidadeMedida, ContratoServico.UnidadeMedida.SetUnidadeMedida.PeticaoSetUnidadeMedida>(Peticao,
                    SDK.Operacoes.operacao.SetUnidadeMedida,
                    new Comum.ParametrosTela.Generica() { PreencherObjeto = false, ExibirMensagemNenhumRegistro = false }, null, true);            

        }

        #endregion

        #region "Eventos"

        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {

                ExecutarGravar();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtUnidadePai_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtUnidadePai);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void ddlUnidadePai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlUnidadePai.SelectedItem != null)
                {
                    txtUnidadePai.Enabled = true;
                }
                else
                {
                    txtUnidadePai.Text = string.Empty;
                    txtUnidadePai.Enabled = false;
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
