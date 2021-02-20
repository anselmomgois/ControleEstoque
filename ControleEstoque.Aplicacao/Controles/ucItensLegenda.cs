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
    public partial class ucItensLegenda : UserControl
    {
        private List<Comum.Clases.StatusCrm> _objStatus;

        public ucItensLegenda(List<Comum.Clases.StatusCrm> objStatus)
        {
            InitializeComponent();

            _objStatus = objStatus;
        }

        private void ucItensLegenda_Load(object sender, EventArgs e)
        {
            if (_objStatus != null && _objStatus.Count > 0)
            {
                Int32 index = 0;
               
                foreach (Comum.Clases.StatusCrm s in _objStatus)
                {
                    flpLegenda.Controls.Add(new ucLegenda(s.Descricao, s.CorRGB)
                    {
                        Dock = DockStyle.Fill,
                        Name = "objLegenda" + index,
                        Height = 20
                    });

                    index += 1;
                   

                }
            }
        }
    }
}
