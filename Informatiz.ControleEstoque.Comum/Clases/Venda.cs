using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Venda
    {
        public string CodigoVenda { get; set; }
        public string Identificador { get; set; }
        public string IdentificadorFilial { get; set; }
        public Comum.Clases.Pessoa Cliente { get; set; }
        public Comum.Clases.Pessoa FuncionarioCaixa { get; set; }
        public Comum.Clases.Geral Atendente { get; set; }
        public Comum.Clases.Pessoa FuncionarioEntregador { get; set; }
        public Comum.Clases.Pessoa SupervisorCancelamento { get; set; }
        public Comum.Clases.Endereco EnderecoEntrega { get; set; }
        public string IdentificadorResponsavelCaixa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorServico { get; set; }
        public decimal ValorEntrega { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorAcrescimo { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorTroco { get; set; }
        public string CodigoComanda { get; set; }
        public Int32 QuantidadePessoas { get; set; }
        public string Observacao { get; set; }
        public Comum.Enumeradores.EstadoVenda Estado { get; set; }
        public List<Comum.Clases.Mesa> Mesas { get; set; }
        public List<Comum.Clases.ItemVenda> Items { get; set; }
        public Comum.Clases.ItemVenda ItemRegistrar { get; set; }
        public List<Pagamento> Pagamentos { get; set; }

    }
}
