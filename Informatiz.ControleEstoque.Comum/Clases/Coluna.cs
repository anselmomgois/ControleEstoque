using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Coluna
    {

        public string NomeColuna { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public Boolean PrimaryKey { get; set; }
    }
}
