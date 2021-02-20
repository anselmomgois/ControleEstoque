using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.FecharVenda
{
     public class PeticaoFecharVenda : PeticaoGenerico
    {
        [Required(ErrorMessage = "O identificador da venda é obrigatório")]
        public string IdentificadorVenda { get; set; }
        [Required(ErrorMessage = "O identificador resposável caixa é obrigatório")]
        public string IdentificadorResponsavelCaixa { get; set; }
        [Required(ErrorMessage = "Não foi informado nenhum pagamento.")]
        public List<Comum.Clases.Pagamento> Pagamentos { get; set; }
        public List<Comum.Clases.FormaPagamento> FormasPagamento { get; set; }
        public string IdentificadorCliente { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorVendedor { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public Boolean PagamentoParcial { get; set; }
        public decimal ValorAcrescimo { get; set; }
        public decimal ValorDesconto { get; set; }
    }
}
