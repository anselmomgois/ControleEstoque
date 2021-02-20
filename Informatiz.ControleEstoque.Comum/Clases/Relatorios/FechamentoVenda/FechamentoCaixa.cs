using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios.FechamentoVenda
{
    public class FechamentoCaixa
    {

        public List<Comum.Clases.Relatorios.Ticket> objTickets { get; set; }
        public string comanda { get; set; }
        public string cnpj { get; set; }
        public DateTime Data { get; set; }
        public string FormaPagamento { get; set; }
        public string Atendente { get; set; }
        public string NomeEmpresa { get; set; }
        public string TelefoneEmpresa { get; set; }
        public string EnderecoEmpresa { get; set; }
    }
}
