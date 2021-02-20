using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class UnidadeMedida
    {
        public string Identificador { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public UnidadeMedida UnidademedidaPai { get; set; }
        public Nullable<Decimal> NumValorUnidadePai { get; set; }
    }
}
