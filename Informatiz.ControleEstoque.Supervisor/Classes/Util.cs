using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Informatiz.ControleEstoque.Supervisor.Classes
{
   public class Util
    {

        #region "Metodos"

        public static Boolean ValidarPermissao(List<Comum.Clases.Permissao> objPermissoes, string CodigoPermissao, Nullable<Comum.Enumeradores.Enumeradores.TipoAcao> TipoAcao)
        {

            if (objPermissoes != null && objPermissoes.Count > 0)
            {

                Comum.Clases.Permissao objPermissao = (from Comum.Clases.Permissao objP in objPermissoes where objP.Codigo == CodigoPermissao select objP).FirstOrDefault();

                if (TipoAcao != null && objPermissao != null && objPermissao.Acoes != null && objPermissao.Acoes.Count > 0 &&
                  (from Comum.Clases.Acao objA in objPermissao.Acoes where objA.TipoAcao == TipoAcao select objA).Count() > 0)
                {

                    return true;
                }
                else if (objPermissao != null && TipoAcao == null)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ExibirMensagemErro(string Mensagem)
        {
            MessageBox.Show(Mensagem, "CE - CONTROLE DE ESTOQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ExibirMensagemSucesso(string Mensagem)
        {
            MessageBox.Show(Mensagem, "CE - CONTROLE DE ESTOQUE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ExibirMensagemInformacao(string Mensagem)
        {
            MessageBox.Show(Mensagem, "CE - CONTROLE DE ESTOQUE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void LogarErro(Comum.Clases.Erro objErro)
        {

            //LogicaNegocio.Erro.InserirErro(objErro);

            ExibirMensagemErro(objErro.DesErro);

        }


        public static void ConfigurarFocoComponentes(Control controle)
        {


            if ((controle is DataGridView))
            {
                DataGridView grid = controle as DataGridView;

                if (grid != null)
                {
                    grid.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
                    grid.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                }


            }
            else if ((controle is MaskedTextBox) || (controle is ComboBox) || (controle is TextBox) || (controle is RichTextBox) || (controle is NumericUpDown) || (controle is TreeView))
            {
                controle.Enter += ConfigurarEnterComponente;
                controle.Leave += ConfigurarLeaveComponente;

            }

            // chamada recursiva para configurar os controles filhos do item atual 

            foreach (Control controleFilho in controle.Controls)
            {
                ConfigurarFocoComponentes(controleFilho);

            }

        }


        public static void ConfigurarEstilo(Control controle)
        {


            if (controle is Button)
            {
                Button objBotao = (Button)(controle);

                controle.BackColor = Color.FromName("GradientActiveCaption");
                controle.ForeColor = Color.Navy;
                objBotao.FlatStyle = FlatStyle.Popup;

            }
            else if (controle is TextBox)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is MaskedTextBox)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is DateTimePicker)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is ComboBox)
            {
                controle.ForeColor = Color.Blue;
            }
            else if (controle is DataGridView)
            {
                DataGridView objDataGrid = (DataGridView)(controle);

                controle.ForeColor = Color.Blue;
                objDataGrid.BackgroundColor = Color.FromName("GradientActiveCaption");
            }

            // chamada recursiva para configurar os controles filhos do item atual 

            foreach (Control controleFilho in controle.Controls)
            {
                ConfigurarEstilo(controleFilho);

            }

        }
        /// <summary>
        /// Configura o evento enter de um determinado componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        /// <history>
        /// [octavio.piramo] 20/01/2009 Criado
        /// </history>

        public static void ConfigurarEnterComponente(object sender, EventArgs e)
        {

            if (sender is Control)
            {
                if (ValidarComponente(sender))
                {
                    Control controle = (Control)sender;
                    controle.BackColor = System.Drawing.Color.Blue;
                    controle.ForeColor = System.Drawing.Color.White;
                }

            }

        }



        /// <summary>
        /// Confifura o evento leave de um determinado componente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        /// <history>
        /// [octavio.piramo] 20/01/2009 Criado
        /// </history>

        public static void ConfigurarLeaveComponente(object sender, EventArgs e)
        {

            if (sender is Control)
            {
                if (ValidarComponente(sender))
                {
                    Control controle = (Control)sender;
                    controle.BackColor = System.Drawing.Color.White;
                    controle.ForeColor = System.Drawing.Color.Blue;
                }

            }

        }


        /// <summary>
        /// Valida se o componente está habilitado, visível e não leitura
        /// </summary>
        /// <param name="sender"></param>
        /// <remarks></remarks>
        /// <history>
        /// [octavio.piramo] 20/01/2009 Criado
        /// </history>
        public static bool ValidarComponente(object sender)
        {

            Control controle = (Control)sender;

            // validar controle

            if (controle is MaskedTextBox)
            {
                if (!(controle as MaskedTextBox).ReadOnly)
                {
                    return true;
                }


            }
            else if (controle is TextBox)
            {
                if (!(controle as TextBox).ReadOnly)
                {
                    return true;
                }


            }
            else if (controle is RichTextBox)
            {
                if (!(controle as RichTextBox).ReadOnly)
                {
                    return true;
                }

            }

            return false;

        }

        #endregion
    }
}
