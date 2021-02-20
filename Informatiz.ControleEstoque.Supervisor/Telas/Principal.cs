using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Supervisor
{
    public partial class Principal : Telas.TelaBase.BaseCE
    {
        public Principal()
        {
            InitializeComponent();

            this.Inicializar();
        }

        private void tsmChavesDisponiveis_Click(object sender, EventArgs e)
        {
            Chaves frmRecuperar = new Chaves();

            frmRecuperar.ShowDialog();
        }

        private void tsmGerarChave_Click(object sender, EventArgs e)
        {
            GerarChave frmGErar = new GerarChave();

            frmGErar.ShowDialog();
        }

        private void tsmSair_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
