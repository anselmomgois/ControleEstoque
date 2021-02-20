using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.SDK
{
    public class Util
    {
        public static Boolean IsNumeric(string valor)
        {
            int n;

            var isNumeric = int.TryParse(valor, out n);

            return isNumeric;
        }
    }
}
