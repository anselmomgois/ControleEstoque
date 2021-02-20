using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Pagamento
    {

        public string Identificador { get; set; }
        public FormaPagamento FormaPagamento { get; set; }       
        public decimal Valor { get; set; }
        public decimal ValorTroco { get; set; }
        public List<string> IdentificadoresProdutosPagos { get; set; }
    }
}
