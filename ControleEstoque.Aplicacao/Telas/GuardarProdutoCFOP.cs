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
    public partial class GuardarProdutoCFOP : TelaBase.BaseCE
    {
        public GuardarProdutoCFOP(string IdentificadorCFOP)
        {
            InitializeComponent();

            _IdentificadorCFOP = IdentificadorCFOP;
        }

        #region"Variaveis"

        private string _IdentificadorCFOP;
        private Comum.Clases.ProdutoCFOP _objProdutoCFOP;

        #endregion

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
            this.pnlBase.Controls.Add(lblNome);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(lblCodigo);
            this.pnlBase.Controls.Add(txtCodigoCST);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarProdutoCFOP();
            PreencherControles();
        }

        private void RecuperarProdutoCFOP()
        {

            if (!string.IsNullOrEmpty(_IdentificadorCFOP))
            {
                _objProdutoCFOP = LogicaNegocio.ProdutoCFOP.RecuperarProdutoCFOP(_IdentificadorCFOP, Parametros.Parametros.InformacaoUsuario.Login);
            }

        }

        private void PreencherControles()
        {

            if (_objProdutoCFOP != null)
            {

                txtNome.Text = _objProdutoCFOP.Descricao;
                txtCodigoCST.Text = Convert.ToString(_objProdutoCFOP.CFOP);
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoCFOP objProdutoCFOP = new Comum.Clases.ProdutoCFOP();

            objProdutoCFOP.Descricao = txtNome.Text.Trim();
            objProdutoCFOP.Identificador = _IdentificadorCFOP;

            if (!string.IsNullOrEmpty(txtCodigoCST.Text))
            {
                objProdutoCFOP.CFOP = Convert.ToInt32(txtCodigoCST.Text);
            }

            if (string.IsNullOrEmpty(_IdentificadorCFOP))
            {
                LogicaNegocio.ProdutoCFOP.InserirProdutoCFOP(objProdutoCFOP, Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador, Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.ProdutoCFOP.AtualizarProdutoCFOP(objProdutoCFOP, Parametros.Parametros.InformacaoUsuario.Login);
            }

            Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion

        #region"Eventos"

        private void txtCodigoCST_KeyPress(object sender, KeyPressEventArgs e)
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

    }
}
