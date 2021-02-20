using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.FecharVenda
{

    public class RespostaFecharVenda : RespostaGenerica
    {
        public decimal SaldoCaixa { get; set; }
        public List<Comum.Clases.Pagamento> Pagamentos { get; set; }
        public decimal Troco { get; set; }
    }
}
