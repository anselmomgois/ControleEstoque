using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class ItemVenda
    {
        public string Identificador { get; set; }
        public string IdentificadorSetor { get; set; }
        public Comum.Clases.Pessoa FuncionarioVenda { get; set; }
        public Comum.Clases.Pessoa SupervisorCancelamento { get; set; }
        public Comum.Clases.ProdutoServico Produto { get; set; }
        public List<Comum.Clases.ProdutoNumeroSerie> NumeroSerie { get; set; }
        public List<Comum.Clases.Acrescimo> Acrescimos { get; set; }
        public List<Comum.Clases.ProdutoObservacao> Observacoes { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Acrescimo { get; set; }
        public Int32 Sequencia { get; set; }
        public Boolean Cancelado { get; set; }
        public decimal ValorItem { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
