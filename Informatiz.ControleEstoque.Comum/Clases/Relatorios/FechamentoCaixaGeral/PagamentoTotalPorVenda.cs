using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios.FechamentoCaixaGeral
{
   public  class PagamentoTotalPorVenda : PagamentosTotais
    {
        public string CodigoVenda { get; set; }
        public string CodigoComanda { get; set; }
        public string CodigoMesa { get; set; }
        public string IdentificadorVenda { get; set; }
        public string CodigoSupervisor { get; set; }
        public string IdentificadorAgrupamento { get; set; }
    }
}
