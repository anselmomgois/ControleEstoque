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
    public partial class ValidarChave : TelaBase.BaseCE
    {

         public ValidarChave()
        {
            InitializeComponent();

        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.aceitar, new EventHandler(btnLogar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbChave);
            base.Inicializar();
        }
            

        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                string Chave = txtChave1.Text + "-" + txtChave2.Text + "-" + txtChave3.Text + "-" + txtChave4.Text + "-" + txtChave5.Text;
                LogicaNegocio.ChaveAcesso.AtivarChave(Chave.ToUpper(), ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Codigo, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador);

                Aplicacao.Classes.Util.ExibirMensagemSucesso("Chave Ativada com Sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
    }
}
