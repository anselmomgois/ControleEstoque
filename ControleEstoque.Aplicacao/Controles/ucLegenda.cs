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
    public partial class ucLegenda : UserControl
    {
        private string Descricao;
        private string cor;
        public ucLegenda(string Descricao, string cor)
        {
            InitializeComponent();
            lblDescricao.Text = Descricao;
            txtCorLegenda.Enabled = false;
            txtCorLegenda.BackColor = Classes.Util.ConverterStringEmCor(cor);
        }
    }
}
