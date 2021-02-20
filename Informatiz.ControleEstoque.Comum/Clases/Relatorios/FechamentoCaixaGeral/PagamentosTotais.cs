using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios.FechamentoCaixaGeral
{
    public class PagamentosTotais
    {
        public Nullable<decimal> ValorRecebido { get; set; }
        public Nullable<decimal> ValorTotalVendas { get; set; }
        public string IdentificadorFormaPagamento { get; set; }
        public string CodigoFormaPagamento { get; set; }
        public string DescricaoFormaPagamento { get; set; }
        public Nullable<decimal> ValorDiferenca { get; set; }

    }
}
