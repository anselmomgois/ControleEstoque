using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Aplicacao.Classes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarStatusCrm : Telas.TelaBase.BaseCE
    {

        #region"Variaveis"

        private string _CorARGB;
        private Comum.Clases.StatusCrm _objStatusCrm;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Propriedades"

        public Comum.Clases.StatusCrm StatusRetorno
        {
            get
            {
                return _objStatusCrm;
            }
        }

        #endregion

        public GuardarStatusCrm(Comum.Clases.StatusCrm objStatusCrm)
        {
            InitializeComponent();

            _objStatusCrm = objStatusCrm;
        }

        #region "Metodos"

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
            this.pnlBase.Controls.Add(lblCodigo);
            this.pnlBase.Controls.Add(txtCodigo);
            this.pnlBase.Controls.Add(lblCor);
            this.pnlBase.Controls.Add(pnlCor);
            this.pnlBase.Controls.Add(btnCidade);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarCor();
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            DesabilitarControles(this, Habilitado, NomeControles);

        }

        private void DesabilitarControles(Control objcontrole, Boolean Habilitado, List<string> NomeControles)
        {
            if (NomeControles != null && NomeControles.Count > 0)
            {
                if (NomeControles.Exists(c => c == objcontrole.Name))
                {
                    objcontrole.Enabled = Habilitado;
                }
            }
            else
            {
                objcontrole.Enabled = Habilitado;
            }

            if (objcontrole.Controls != null && objcontrole.Controls.Count > 0)
            {
                foreach (Control c in objcontrole.Controls)
                {
                    DesabilitarControles(c, Habilitado, NomeControles);
                }
            }
        }

        private void RecuperarCor()
        {

            PreencherControles();
        }

        private Color ConverterStringEmCor(string Cor)
        {

            if (!string.IsNullOrEmpty(Cor))
            {
                string[] objStrCor = _objStatusCrm.CorRGB.Split(Convert.ToChar("|"));

                Int32 A = Convert.ToInt32(objStrCor[0]);
                Int32 R = Convert.ToInt32(objStrCor[1]);
                Int32 G = Convert.ToInt32(objStrCor[2]);
                Int32 B = Convert.ToInt32(objStrCor[3]);

                return Color.FromArgb(A, R, G, B);
            }

            return new Color();
        }

        private void PreencherControles()
        {

            if (_objStatusCrm != null)
            {

                txtNome.Text = _objStatusCrm.Descricao;
                txtCodigo.Text = _objStatusCrm.Codigo;

                _CorARGB = _objStatusCrm.CorRGB;

                pnlCor.BackColor = ConverterStringEmCor(_objStatusCrm.CorRGB);
                ExecutarPreencherGrid(false);


            }
        }

        private void ExecutarGravar()
        {
            if (_objStatusCrm == null) { _objStatusCrm = new Comum.Clases.StatusCrm(); }

            if (string.IsNullOrEmpty(_objStatusCrm.Identificador)) { _objStatusCrm.Identificador = Guid.NewGuid().ToString(); }
            _objStatusCrm.Descricao = txtNome.Text.Trim();
            _objStatusCrm.CorRGB = _CorARGB;
            _objStatusCrm.Codigo = txtCodigo.Text.Trim();

            Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        #endregion

        #region "Eventos"

        private void btnCidade_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_CorARGB))
                {

                    frmColor.Color = ConverterStringEmCor(_CorARGB);
                }


                if (frmColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pnlCor.BackColor = frmColor.Color;
                    _CorARGB = frmColor.Color.A + "|" + frmColor.Color.R + "|" + frmColor.Color.G + "|" + frmColor.Color.B;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

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
