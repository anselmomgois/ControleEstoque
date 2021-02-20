using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class ProdutoNCM
    {

        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public Int32 Codigo { get; set; }
        public Int32 NCM { get; set; }
        public Nullable<decimal> PercentualMVA { get; set; }

    }
}
