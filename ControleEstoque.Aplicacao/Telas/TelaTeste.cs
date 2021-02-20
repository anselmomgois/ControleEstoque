using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class TelaTeste : Form
    {
        private Controles.ucTexboxTeclado _ucTextBox1 = null;
        private Controles.ucTexboxTeclado _ucTextBox2 = null;

        public TelaTeste()
        {
            InitializeComponent();

            _ucTextBox1 = new Controles.ucTexboxTeclado(pnlTexto1.Location.X, pnlTexto1.Location.Y, new FontFamily("Arial"), true, 25, this, true, 0, 0);
            _ucTextBox2 = new Controles.ucTexboxTeclado(pnlTexto2.Location.X, pnlTexto2.Location.Y, new FontFamily("Arial"), true, 25, this, false, 0, 0);
            _ucTextBox1.Dock = DockStyle.Fill;
            pnlTexto1.Controls.Add(_ucTextBox1);
            pnlTexto2.Controls.Add(_ucTextBox2);
        }

        private void _ucTextBox1_OcultarTeclado(Controles.ucTeclado objTeclado)
        {
            try
            {
                if (this.Controls.Contains(objTeclado)) this.Controls.Remove(objTeclado);
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

        private void _ucTextBox1_ExibirTeclado(Controles.ucTeclado objTeclado)
        {

            try
            {
                if (this.Controls.Contains(objTeclado)) this.Controls.Remove(objTeclado);

                this.Controls.Add(objTeclado);
                objTeclado.SendToBack();
                objTeclado.BringToFront();
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

        private void _ucTextBox1_GetLocationEvent(ref int X, ref int Y)
        {
            // Y = Screen.PrimaryScreen.WorkingArea.Height;
            //X = 7000 * 1000;

            //int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;

            Point parentPoint = this.Location;

            X = (parentPoint.X + pnlTexto1.Location.X) - 150;
            Y = (parentPoint.Y + pnlTexto1.Location.Y) - pnlTexto1.Height;
            //int parentHeight = this.Height;
            //int parentWidth = this.Width;

            //int childHeight = pnlTexto1.Height;
            //int childWidth = pnlTexto1.Width;

            //if ((parentPoint.Y + parentHeight + childHeight) > screenHeight)
            //{
            //    // If we would move off the screen, position near the top.
            //    Y = parentPoint.Y + 50; // move down 50
            //    X = parentPoint.X;
            //}
            //else
            //{
            //    // Position on the edge.
            //    Y = parentPoint.Y + parentHeight;
            //    X = parentPoint.X;
            //}
        }

    }
}

