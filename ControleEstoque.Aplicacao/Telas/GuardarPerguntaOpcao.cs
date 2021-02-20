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
    public partial class GuardarPerguntaOpcao : TelaBase.BaseCE
    {
        public GuardarPerguntaOpcao(Comum.Clases.PerguntaOpcao objOpcao)
        {
            InitializeComponent();

           _objOpcao = objOpcao;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private Comum.Clases.PerguntaOpcao _objOpcao;

        #endregion

        #region"Propriedades"

        public Comum.Clases.PerguntaOpcao objOpcaoTrans
        {
            get
            {
                return _objOpcao;
            }
        }

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
            this.pnlBase.Controls.Add(lblPergunta);
            this.pnlBase.Controls.Add(txtPergunta);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

                       
            CarregarControlesTela();


        }

        private void CarregarControlesTela()
        {

            if (_objOpcao != null)
            {

                txtPergunta.Text = _objOpcao.Descricao;
            }

        }

        #endregion

        #region"Eventos"

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtPergunta.Text))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório informar a descrição da opção");
                }

                if (_objOpcao == null) _objOpcao = new Comum.Clases.PerguntaOpcao();


                _objOpcao.Descricao = txtPergunta.Text;
  
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Execao.ExecaoNegocio ex)
            {

                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

       

    }
}
