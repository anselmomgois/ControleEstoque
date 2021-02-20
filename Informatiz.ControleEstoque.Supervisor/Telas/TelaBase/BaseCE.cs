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
    public partial class BaseCE : TelaBase.Base
    {
        public BaseCE()
        {
            InitializeComponent();
        }

        #region"Propriedades"

        public Parametros.Parametros objParametros { get; set; }

        #endregion

        #region"Metodos"

        public virtual void Inicializar()
        {
            try
            {

                base.Inicializar();


            }
            catch (Exception ex)
            {

            }

        }

        #endregion
    }
}
