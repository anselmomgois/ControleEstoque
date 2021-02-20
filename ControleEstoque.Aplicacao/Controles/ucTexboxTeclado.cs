using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    public partial class ucTexboxTeclado : UserControl
    {
        public ucTexboxTeclado(int X, int Y, FontFamily Fonte, bool Negrito, int TamanhoFonte, Form TelaBase, bool Touch, int comprimentoTecladoTouch, int AlturaTecladoTouch)
        {
            InitializeComponent();

            txtTexto.Name = Guid.NewGuid().ToString();
            btnTeclado.Name = Guid.NewGuid().ToString();
            _TamanhoFonte = TamanhoFonte;
            _diferencaTamanho = txtTexto.Height;
            _Negrito = Negrito;
            _Fonte = Fonte;
            txtTexto.Font = new Font(_Fonte, _TamanhoFonte, _Negrito ? FontStyle.Bold : txtTexto.Font.Style);
            tableLayoutPanel1.Height = txtTexto.Height - 10;
            btnTeclado.Height = txtTexto.Height - 10;
            _Y = Y + txtTexto.Height + 5;
            _X = X;
            _Touch = Touch;
            _TelaBase = TelaBase;

            if (!_Touch)
            {
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
                btnTeclado.Visible = false;
            }
            else
            {
                _diferencaTamanho = txtTexto.Height - _diferencaTamanho;
                tableLayoutPanel1.ColumnStyles[1].Width += _diferencaTamanho;
            }

            CriarTeclado(comprimentoTecladoTouch, AlturaTecladoTouch);

        }

        #region "Variaveis"

        private int _X;
        private int _Y;
        private ucTeclado _ucTeclado;
        private int _TamanhoFonte;
        private Form _TelaBase;
        private bool _Touch;
        private float _diferencaTamanho;
        FontFamily _Fonte;
        bool _Negrito;
        #endregion

        #region"Delegates"

        public delegate void GetValorDigitadoDelegate(string Item);
        public event GetValorDigitadoDelegate GetValorDigitado;

        public event EventHandler LimparValor;

        #endregion
        #region "Metodos"

        public void DesHabilitarControle()
        {
            txtTexto.Enabled = false;
            btnTeclado.Enabled = false;
        }

        public void HabilitarControle()
        {
            txtTexto.Enabled = true;
            btnTeclado.Enabled = true;
        }

        public string RecuperarValor()
        {
            return txtTexto.Text;
        }

        public void SetarFocus()
        {
            txtTexto.Focus();
        }

        public void SetarValor(string Valor)
        {
            txtTexto.Text = Valor;
        }

        private void ExibirTeclado()
        {
            try
            {
                if (_Touch)
                {
                    if (_TelaBase.Controls.Contains(_ucTeclado)) _TelaBase.Controls.Remove(_ucTeclado);

                    _ucTeclado.Visible = true;

                    _TelaBase.Controls.Add(_ucTeclado);
                    _ucTeclado.SendToBack();
                    _ucTeclado.BringToFront();
                }
            }

            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void OcultarTeclado()
        {
            try
            {
                if (_Touch)
                {
                    if (this.Controls.Contains(_ucTeclado)) this.Controls.Remove(_ucTeclado);

                    _ucTeclado.Visible = false;
                }
            }

            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        public void CriarTeclado(int x, int y)
        {
            if (_Touch)
            {
                _ucTeclado = new ucTeclado(ref txtTexto);

                _ucTeclado.Name = "_ucTeclado";
                _ucTeclado.Width = txtTexto.Width;
                _ucTeclado.Height = 300;
                _ucTeclado.Visible = false;
                _ucTeclado.Location = new Point(_X, _Y);
                _ucTeclado.OcultarTeclado += _ucTeclado_OcultarTeclado;
                _ucTeclado.ExecutarEnter += _ucTeclado_ExecutarEnter;
                _ucTeclado.ApagarUltimoCaractere += _ucTeclado_ApagarUltimoCaractere;
            }
        }

        #endregion
        #region "Eventos"

        private void _ucTeclado_ApagarUltimoCaractere(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTexto.Text))
            {
                txtTexto.Text = txtTexto.Text.Substring(0, txtTexto.Text.Length - 1);
            }
        }

        private void _ucTeclado_ExecutarEnter(object sender, EventArgs e)
        {
            try
            {

                GetValorDigitado(txtTexto.Text);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void _ucTeclado_OcultarTeclado(object sender, EventArgs e)
        {
            try
            {

                OcultarTeclado();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtTexto_Enter(object sender, EventArgs e)
        {
            try
            {

                ExibirTeclado();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_ucTeclado.Visible)
                {
                    ExibirTeclado();
                }
                else
                {

                    OcultarTeclado();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetValorDigitado(txtTexto.Text);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTexto.Text.Trim()))
                {
                    LimparValor(null, null);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion


    }
}
