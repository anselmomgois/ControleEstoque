using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe
{
    public class PeticaoBuscarFormaPagamentoDetalhe : PeticaoGenerico
    {

        [Required(ErrorMessage = "A Forma de Pagamento é obrigatório.")]
        public string IdentificadorFormaPagamento { get; set; }
    }
}
