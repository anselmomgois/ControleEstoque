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
    public partial class ucNotificacoesUsuario : UserControl
    {
        private List<Comum.Clases.CRMSimples> _objCrmsSimples;

        public ucNotificacoesUsuario(List<Comum.Clases.CRMSimples> objCrmsSimples)
        {
            InitializeComponent();
           _objCrmsSimples = objCrmsSimples;
        }

        private void ucNotificacoesUsuario_Load(object sender, EventArgs e)
        {
            if (_objCrmsSimples != null && _objCrmsSimples.Count > 0)
            {
                Int32 index = 0;

                foreach (Comum.Clases.CRMSimples s in _objCrmsSimples)
                {
                    if (s.UsuariosResponsaveis != null && s.UsuariosResponsaveis.Exists(u => u == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador))
                    {
                        flpLegenda.Controls.Add(new ucNotificacaoUsuario(s)
                        {
                            Dock = DockStyle.Fill,
                            Name = "objNotificacao" + index,
                            Height = 20
                        });

                        index += 1;
                    }

                }
            }
        }
    }
}
