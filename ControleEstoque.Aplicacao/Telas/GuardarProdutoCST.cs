using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoCST : TelaBase.BaseCE
    {
        public GuardarProdutoCST(string IdentificadorCST)
        {
            InitializeComponent();

            _IdentificadorCST = IdentificadorCST;

        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"


        private string _IdentificadorCST;
        private Comum.Clases.ProdutoCST _objProdutoCST;
        private CurrencyTextBox CurrencyTextBox;

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
            this.pnlBase.Controls.Add(lblCodigo);
            this.pnlBase.Controls.Add(lblNome);
            this.pnlBase.Controls.Add(lblObservacao);
            this.pnlBase.Controls.Add(lblTemCST);
            this.pnlBase.Controls.Add(txtCodigoCST);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(txtObservacao);
            this.pnlBase.Controls.Add(chkTemCST);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarProdutoComissao();
            PreencherControles();
        }

        private void RecuperarProdutoComissao()
        {

            if (!string.IsNullOrEmpty(_IdentificadorCST))
            {
                _objProdutoCST = LogicaNegocio.ProdutoCST.RecuperarProdutoCST(_IdentificadorCST, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

        }

        private void PreencherControles()
        {

            if (_objProdutoCST != null)
            {

                txtNome.Text = _objProdutoCST.Descricao;
                txtCodigoCST.Text = Convert.ToString(_objProdutoCST.CST);
                chkTemCST.Checked = _objProdutoCST.TemCST;
                txtObservacao.Text = _objProdutoCST.DesMensagemNotaFiscal;
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoCST objProdutoCST = new Comum.Clases.ProdutoCST();

            objProdutoCST.Descricao = txtNome.Text.Trim();
            objProdutoCST.Identificador = _IdentificadorCST;

            if (!string.IsNullOrEmpty(txtCodigoCST.Text))
            {
                objProdutoCST.CST = Convert.ToInt32(txtCodigoCST.Text);
            }

            objProdutoCST.TemCST = chkTemCST.Checked;
            objProdutoCST.DesMensagemNotaFiscal = txtObservacao.Text.Trim();

            if (string.IsNullOrEmpty(_IdentificadorCST))
            {
                LogicaNegocio.ProdutoCST.InserirProdutoCST(objProdutoCST, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.ProdutoCST.AtualizarProdutoCST(objProdutoCST, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

            Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion

        #region "Eventos"

        private void txtPercentual_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion

    }
}
