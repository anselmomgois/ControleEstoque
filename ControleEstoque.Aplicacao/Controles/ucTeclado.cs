using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    public partial class ucTeclado : UserControl
    {
        private TextBox _objTextBox;

        public event EventHandler OcultarTeclado;
        public event EventHandler ExecutarEnter;
        public event EventHandler ApagarUltimoCaractere;

        public ucTeclado(ref TextBox objTextbox)
        {
            InitializeComponent();

            _objTextBox = objTextbox;

            btn0.Click += btnNumeros_Click;
            btn1.Click += btnNumeros_Click;
            btn2.Click += btnNumeros_Click;
            btn3.Click += btnNumeros_Click;
            btn4.Click += btnNumeros_Click;
            btn5.Click += btnNumeros_Click;
            btn6.Click += btnNumeros_Click;
            btn7.Click += btnNumeros_Click;
            btn8.Click += btnNumeros_Click;
            btn9.Click += btnNumeros_Click;
        }

        private void btnNumeros_Click(object sender, EventArgs e)
        {
            try
            {

                _objTextBox.Text += ((Button)sender).Text;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                ApagarUltimoCaractere(null,null);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {

                ExecutarEnter(null, null);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
