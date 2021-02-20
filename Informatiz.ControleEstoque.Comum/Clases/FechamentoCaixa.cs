using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class FechamentoCaixa
    {
        public string Identificador { get; set; }
        public decimal ValorFechamento { get; set; }
        public decimal ValorDiferenca { get; set; }
        public decimal ValorRecebido { get; set; }
        public decimal ValorTotalSangria { get; set; }
        public decimal ValorTotalSuprimento { get; set; }
        public decimal SaldoInicialCaixa { get; set; }
           
        public string DescricaoFormaPagamento { get; set; }
        public string IdentificadorFormaPagamento { get; set; }
    }
}
