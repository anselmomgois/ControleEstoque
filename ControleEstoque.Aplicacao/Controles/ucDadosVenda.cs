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
    public partial class ucDadosVenda : UserControl
    {

        private Controles.ucTexboxTeclado _ucTextBoxComanda = null;
        private Controles.ucTexboxTeclado _ucTextBoxMesa = null;
        private bool _touch;
        private Form _TelaPai;
        private int _X;
        private int _Y;

        public delegate void GetValorDigitadoDelegate(string Item);
        public event GetValorDigitadoDelegate GetValorDigitado;

        public event EventHandler LimparTela;

        public ucDadosVenda(bool Touch, Form TelaPai, int X, int Y)
        {
            InitializeComponent();

            _TelaPai = TelaPai;
            _touch = Touch;
            _X = X;
            _Y = Y;

            _ucTextBoxComanda = new Controles.ucTexboxTeclado(_X + pnlComanda.Location.X, _Y + pnlComanda.Location.Y, new FontFamily("Arial"), true, 25, _TelaPai, _touch, 0, 0);
            _ucTextBoxMesa = new Controles.ucTexboxTeclado(_X + pnlMesa.Location.X + 150, _Y + pnlMesa.Location.Y, new FontFamily("Arial"), true, 25, _TelaPai, _touch, 0, 0);
            _ucTextBoxComanda.Dock = DockStyle.Fill;
            _ucTextBoxMesa.Dock = DockStyle.Fill;

            _ucTextBoxComanda.GetValorDigitado += _ucTextBoxComanda_GetValorDigitado;
            _ucTextBoxMesa.GetValorDigitado += _ucTextBoxMesa_GetValorDigitado;

            _ucTextBoxComanda.LimparValor += _ucTextBoxComanda_LimparValor;
            _ucTextBoxMesa.LimparValor += _ucTextBoxMesa_LimparValor;
            txtAtendente.Height = pnlMesa.Height;
            pnlComanda.Controls.Add(_ucTextBoxComanda);
            pnlMesa.Controls.Add(_ucTextBoxMesa);

            Classes.Util.ConfigurarEstilo(this);
            Classes.Util.ConfigurarFocoComponentes(this);

            if (Parametros.Parametros.ParametrosAplicacao.TrabalhaPorComanda)
            {
                _ucTextBoxMesa.DesHabilitarControle();
            }
            else
            {
                _ucTextBoxComanda.Visible = false;
                tableLayoutPanel10.ColumnStyles[0].Width = 0;
                _ucTextBoxComanda.DesHabilitarControle();

            }

        }

        #region "Metodos"
        public string RecuperarValorComanda()
        {
            return _ucTextBoxComanda != null ? _ucTextBoxComanda.RecuperarValor() : string.Empty;
        }

        public string RecuperarValorMesa()
        {
            return _ucTextBoxMesa != null ? _ucTextBoxMesa.RecuperarValor() : string.Empty;
        }

        public void SetarValorComanda(string Valor)
        {
            _ucTextBoxComanda.SetarValor(Valor);
        }

        public void SetarValorMesa(string Valor)
        {
            _ucTextBoxMesa.SetarValor(Valor);
        }

        public void SetarValorAtendente(string Valor)
        {
            txtAtendente.Text = Valor;
        }
        public void SetarFocus()
        {
            if (Parametros.Parametros.ParametrosAplicacao.TrabalhaPorComanda)
            {
                _ucTextBoxComanda.Focus();
            }
            else
            {
                _ucTextBoxMesa.Focus();
            }
        }
        #endregion
        #region "Eventos"

        private void _ucTextBoxMesa_GetValorDigitado(string Item)
        {
            try
            {
                GetValorDigitado(Item);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void _ucTextBoxComanda_GetValorDigitado(string Item)
        {
            try
            {
                GetValorDigitado(Item);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void _ucTextBoxMesa_LimparValor(object sender, EventArgs e)
        {
            LimparTela(null, null);
        }

        private void _ucTextBoxComanda_LimparValor(object sender, EventArgs e)
        {
            LimparTela(null, null);
        }

        #endregion

    }
}
