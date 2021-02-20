using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios.FechamentoCaixaGeral
{
    public class DetalheVenda : PagamentoTotalPorVenda
    {
        public Nullable<Int32> Sequencia { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorItem { get; set; }
        public Nullable<decimal> ValorDesconto { get; set; }
        public Nullable<decimal> ValorAcrescimo { get; set; }
        public Nullable<decimal> Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
