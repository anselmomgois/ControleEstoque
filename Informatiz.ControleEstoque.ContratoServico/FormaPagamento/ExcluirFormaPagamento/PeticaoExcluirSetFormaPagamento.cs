using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.FormaPagamento.ExcluirSetFormaPagamento
{
     public class PeticaoExcluirSetFormaPagamento : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da Forma de Pagamento é obrigatório.")]
        public string IdentificadorFormaPagamento { get; set; }
    }
}
