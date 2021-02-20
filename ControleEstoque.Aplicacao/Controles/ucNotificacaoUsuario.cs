using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Aplicacao.Telas;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    public partial class ucNotificacaoUsuario : UserControl
    {
        private Comum.Clases.CRMSimples _objCrm;

        public ucNotificacaoUsuario(Comum.Clases.CRMSimples objCrm)
        {
            InitializeComponent();

            _objCrm = objCrm;

            if (_objCrm != null)
            { 
                imgcor.BackColor = Classes.Util.ConverterStringEmCor(objCrm.CorStatus);
                lblDescricaoMostrar.Text = _objCrm.Descricao;
                lblClienteMostrar.Text = _objCrm.Cliente;
                lblFixoMostrar.Text = _objCrm.TelefoneFixo;
                lblCelularMostrar.Text = _objCrm.TelefoneCelular;
            }

        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCRM frmCores = new GuardarCRM(false,
                                        _objCrm.Identificador);

                frmCores.ShowDialog();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
