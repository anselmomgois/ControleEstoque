using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Erro
    {

        public string Usuario { get; set; }
        public string DesErro { get; set; }
        public Exception Execao { get; set; }

    }
}
