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
    public partial class GuardarProdutoNCM : TelaBase.BaseCE
    {
        public GuardarProdutoNCM(string IdentificadorNCM)
        {
            InitializeComponent();

            _IdentificadorNCM = IdentificadorNCM;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorNCM;
        private Comum.Clases.ProdutoNCM _objProdutoNCM;
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
            this.pnlBase.Controls.Add(lblNCM);
            this.pnlBase.Controls.Add(lblNome);
            this.pnlBase.Controls.Add(lblPercentualMVA);
            this.pnlBase.Controls.Add(txtCodigoNCM);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(txtPercentualMVA);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarProdutoMarca();
            PreencherControles();
        }

        private void RecuperarProdutoMarca()
        {

            if (!string.IsNullOrEmpty(_IdentificadorNCM))
            {
                _objProdutoNCM = LogicaNegocio.ProdutoNCM.RecuperarProdutoNCM(_IdentificadorNCM, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

        }

        private void PreencherControles()
        {

            if (_objProdutoNCM != null)
            {

                txtNome.Text = _objProdutoNCM.Descricao;
                txtCodigoNCM.Text = Convert.ToString(_objProdutoNCM.NCM);

                if (_objProdutoNCM.PercentualMVA != null)
                {
                    txtPercentualMVA.Text = Convert.ToString(_objProdutoNCM.PercentualMVA);
                }
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoNCM objProdutoNCM = new Comum.Clases.ProdutoNCM();

            objProdutoNCM.Descricao = txtNome.Text.Trim();
            objProdutoNCM.Identificador = _IdentificadorNCM;

            if (!string.IsNullOrEmpty(txtCodigoNCM.Text))
            {
                objProdutoNCM.NCM = Convert.ToInt32(txtCodigoNCM.Text);
            }

            if (!string.IsNullOrEmpty(txtPercentualMVA.Text))
            {
                objProdutoNCM.PercentualMVA = Convert.ToDecimal(txtPercentualMVA.Text);
            }

            if (string.IsNullOrEmpty(_IdentificadorNCM))
            {
                LogicaNegocio.ProdutoNCM.InserirProdutoNCM(objProdutoNCM, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.ProdutoNCM.AtualizarProdutoNCM(objProdutoNCM, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

            Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion

        #region"Eventos"
         

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

        private void txtCodigoNCM_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPercentualMVA_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentualMVA);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

    }
}
