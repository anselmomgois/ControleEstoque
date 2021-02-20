using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoDerivacao : TelaBase.BaseCE
    {
        public GuardarProdutoDerivacao(string IdentificadorDerivacao)
        {
            InitializeComponent();

             _IdentificadorDerivacao = IdentificadorDerivacao;
        }

        #region"Variaveis"

        private string _IdentificadorDerivacao;
        private Comum.Clases.ProdutoDerivacao _objProdutoDerivacao;

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
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(lblNome);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarProdutoDerivacao();
            PreencherControles();
        }

        private void RecuperarProdutoDerivacao()
        {

            if (!string.IsNullOrEmpty(_IdentificadorDerivacao))
            {
                _objProdutoDerivacao = LogicaNegocio.ProdutoDerivacao.RecuperarProdutoDerivacao(_IdentificadorDerivacao, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

        }

        private void PreencherControles()
        {

            if (_objProdutoDerivacao != null)
            {

                txtNome.Text = _objProdutoDerivacao.Descricao;
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoDerivacao objProdutoDerivacao = new Comum.Clases.ProdutoDerivacao();

            objProdutoDerivacao.Descricao = txtNome.Text.Trim();
            objProdutoDerivacao.Identificador = _IdentificadorDerivacao;

            if (string.IsNullOrEmpty(_IdentificadorDerivacao))
            {
                LogicaNegocio.ProdutoDerivacao.InserirProdutoDerivacao(objProdutoDerivacao, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.ProdutoDerivacao.AtualizarProdutoDerivacao(objProdutoDerivacao, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
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

        #endregion

    }
}
