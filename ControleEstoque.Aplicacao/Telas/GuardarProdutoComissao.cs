using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoComissao : TelaBase.BaseCE
    {
        public GuardarProdutoComissao(string IdentificadorComissao)
        {
            InitializeComponent();

           _IdentificadorComissao = IdentificadorComissao;

        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorComissao;
        private Comum.Clases.ProdutoComissao _objProdutoComissao;
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
            this.pnlBase.Controls.Add(lblNome);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(lblHabilitada);
            this.pnlBase.Controls.Add(lblPercentual);
            this.pnlBase.Controls.Add(lblValor);
            this.pnlBase.Controls.Add(txtPercentual);
            this.pnlBase.Controls.Add(txtValor);
            this.pnlBase.Controls.Add(chkHabilitada);
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

            if (!string.IsNullOrEmpty(_IdentificadorComissao))
            {
                _objProdutoComissao = LogicaNegocio.ProdutoComissao.RecuperarProdutoComissao(_IdentificadorComissao, Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                chkHabilitada.Checked = true;
                chkHabilitada.Enabled = false;
            }
        }

        private void PreencherControles()
        {

            if (_objProdutoComissao != null)
            {

                txtNome.Text = _objProdutoComissao.Descricao;
                txtPercentual.Text = (_objProdutoComissao.NumPercentual != null ? Convert.ToString(_objProdutoComissao.NumPercentual) : null);
                txtValor.Text = (_objProdutoComissao.NumValor != null ? Convert.ToString(_objProdutoComissao.NumValor) : null);
                chkHabilitada.Checked = _objProdutoComissao.Habilitada;

            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoComissao objProdutoComissao = new Comum.Clases.ProdutoComissao();

            objProdutoComissao.Descricao = txtNome.Text.Trim();
            objProdutoComissao.Identificador = _IdentificadorComissao;
            if(!string.IsNullOrEmpty(txtPercentual.Text))
            {
            objProdutoComissao.NumPercentual = Convert.ToDecimal(txtPercentual.Text);
            }
            
            if (!string.IsNullOrEmpty(txtValor.Text))
            {
                objProdutoComissao.NumValor = Convert.ToDecimal(txtValor.Text);
            }

            objProdutoComissao.Habilitada = chkHabilitada.Checked;

            if (string.IsNullOrEmpty(_IdentificadorComissao))
            {
                LogicaNegocio.ProdutoComissao.InserirProdutoComissao(objProdutoComissao, Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.First().Identificador, Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.ProdutoComissao.AtualizarProdutoComissao(objProdutoComissao, Parametros.Parametros.InformacaoUsuario.Login);
            }

            Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion

        #region "Eventos"

        private void txtPercentual_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentual);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValor);

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
