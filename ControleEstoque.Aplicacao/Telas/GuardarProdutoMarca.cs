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
    public partial class GuardarProdutoMarca : TelaBase.BaseCE
    {
        public GuardarProdutoMarca(string IdentificadorMarca)
        {
            InitializeComponent();

            _IdentificadorMarca = IdentificadorMarca;
        }

        #region"Variaveis"

        private string _IdentificadorMarca;
        private Comum.Clases.ProdutoMarca _objProdutoMarca;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click_1), Keys.F2, false, false, false);

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

            RecuperarProdutoMarca();
            PreencherControles();
        }

        private void RecuperarProdutoMarca()
        {

            if (!string.IsNullOrEmpty(_IdentificadorMarca))
            {
                _objProdutoMarca = LogicaNegocio.ProdutoMarca.RecuperarProdutoMarca(_IdentificadorMarca, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

        }

        private void PreencherControles()
        {

            if (_objProdutoMarca != null)
            {

                txtNome.Text = _objProdutoMarca.Descricao;
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoMarca objProdutoMarca = new Comum.Clases.ProdutoMarca();

            objProdutoMarca.Descricao = txtNome.Text.Trim();
            objProdutoMarca.Identificador = _IdentificadorMarca;

            if (string.IsNullOrEmpty(_IdentificadorMarca))
            {
                LogicaNegocio.ProdutoMarca.InserirProdutoMarca(objProdutoMarca, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.ProdutoMarca.AtualizarProdutoMarca(objProdutoMarca, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

            Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion

        #region"Eventos"


        private void GuardarProdutoMarca_Load(object sender, EventArgs e)
        {
            try
            {

                Aplicacao.Classes.Util.ConfigurarEstilo(this);
                Aplicacao.Classes.Util.ConfigurarFocoComponentes(this);

                CarregarTela();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
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
