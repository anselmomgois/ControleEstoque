using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Atributos;

namespace Informatiz.ControleEstoque.Comum.Enumeradores
{
    public enum TipoRelatorio
    {
        [ValorEnum("Report\\Venda.rpt")]
        VendasCaixa,
        [ValorEnum("Report\\Ticket.rpt")]
        FechamentoVenda,
        [ValorEnum("Report\\Fechamento.rpt")]
        FechamentoCaixa,
        [ValorEnum("Report\\FechamentoCaixa.rpt")]
        FechamentoCaixaEmail,
        [ValorEnum("Report\\TicketSetor.rpt")]
        PedidoSetor
    }
}
