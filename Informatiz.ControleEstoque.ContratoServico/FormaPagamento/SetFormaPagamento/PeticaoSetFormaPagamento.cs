using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.FormaPagamento.SetFormaPagamento
{
    public class PeticaoSetFormaPagamento : PeticaoGenerico
    {

        [Required(ErrorMessage = "A Forma de Pagamento é obrigatório.")]
        public Comum.Clases.FormaPagamento FormaPagamento { get; set; }

        public string IdentificadorEmpresa { get; set; }
    }
}
