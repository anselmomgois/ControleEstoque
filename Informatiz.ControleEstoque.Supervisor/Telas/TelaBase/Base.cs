using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Supervisor.Telas.TelaBase
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
        }

        public virtual void Inicializar()
        {

            if (!(DesignMode))
            {

                // adicionar evento de foco ao entrar e sair dos componentes
                Classes.Util.ConfigurarFocoComponentes(this);
                Classes.Util.ConfigurarEstilo(this);
            }
        }

        public virtual void ConfigurarFocoComponentes()
        {

            // adicionar evento de foco ao entrar e sair dos componentes
            Classes.Util.ConfigurarFocoComponentes(this);

        }
    }
}
