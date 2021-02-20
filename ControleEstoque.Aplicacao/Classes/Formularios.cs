using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Aplicacao.Classes
{
   public class Formularios
    {

        public static List<System.Windows.Forms.Form> FormulariosAbertos { get; set; }
        

        public static void AdicionarFormulario(System.Windows.Forms.Form objFormulario)
        {
            if(FormulariosAbertos == null) { FormulariosAbertos = new List<System.Windows.Forms.Form>(); }

            FormulariosAbertos.Add(objFormulario);

        }

        public static void RemoverFormulario(System.Windows.Forms.Form objFormulario)
        {
            FormulariosAbertos.RemoveAll(f => f.Name == objFormulario.Name);
        }
    }
}
