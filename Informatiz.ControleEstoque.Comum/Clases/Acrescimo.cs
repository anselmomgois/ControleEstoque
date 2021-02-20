using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Acrescimo
    {
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public Int32 Codigo { get; set; }
        public decimal ValorItem { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Quantidade { get; set; }
    }
}
