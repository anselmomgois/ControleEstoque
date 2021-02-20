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
    public partial class GuardarProdutoCategoria : TelaBase.BaseCE
    {
        public GuardarProdutoCategoria(string IdentificadorCategoria)
        {
            InitializeComponent();

           _IdentificadorCategoria = IdentificadorCategoria;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorCategoria;
        private Comum.Clases.ProdutoCategoria _objProdutoCategoria;

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
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarProdutoCategoria();
            PreencherControles();
        }

        private void RecuperarProdutoCategoria()
        {

            if (!string.IsNullOrEmpty(_IdentificadorCategoria))
            {
                _objProdutoCategoria = LogicaNegocio.ProdutoCategoria.RecuperarProdutoCategoria(_IdentificadorCategoria, Parametros.Parametros.InformacaoUsuario.Login);
            }

        }

        private void PreencherControles()
        {

            if (_objProdutoCategoria != null)
            {

                txtNome.Text = _objProdutoCategoria.Descricao;
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoCategoria objProdutoCategoria = new Comum.Clases.ProdutoCategoria();

            objProdutoCategoria.Descricao = txtNome.Text.Trim();
            objProdutoCategoria.Identificador = _IdentificadorCategoria;

            if (string.IsNullOrEmpty(_IdentificadorCategoria))
            {
                LogicaNegocio.ProdutoCategoria.InserirProdutoCategoria(objProdutoCategoria, Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador, Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.ProdutoCategoria.AtualizarProdutoCategoria(objProdutoCategoria, Parametros.Parametros.InformacaoUsuario.Login);
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion    

    }
}
