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
    public partial class GuardarPublicidade : TelaBase.BaseCE
    {
        public GuardarPublicidade(string IdentificadorPublicidade)
        {
            InitializeComponent();

            _IdentificadorPublicidade = IdentificadorPublicidade;

        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorPublicidade;
        private Comum.Clases.Publicidade _objPublicidade;

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

            RecuperarProdutoMarca();
            PreencherControles();
        }

        private void RecuperarProdutoMarca()
        {

            if (!string.IsNullOrEmpty(_IdentificadorPublicidade))
            {
                _objPublicidade = LogicaNegocio.Publicidade.RecuperarPublicidade(_IdentificadorPublicidade, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }

        }

        private void PreencherControles()
        {

            if (_objPublicidade != null)
            {

                txtNome.Text = _objPublicidade.Descricao;
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.Publicidade objPublicidade = new Comum.Clases.Publicidade();

            objPublicidade.Descricao = txtNome.Text.Trim();
            objPublicidade.Identificador = _IdentificadorPublicidade;

            if (string.IsNullOrEmpty(_IdentificadorPublicidade))
            {
                LogicaNegocio.Publicidade.InserirPublicidade(objPublicidade, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            }
            else
            {
                LogicaNegocio.Publicidade.AtualizarPubliciade(objPublicidade, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
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
