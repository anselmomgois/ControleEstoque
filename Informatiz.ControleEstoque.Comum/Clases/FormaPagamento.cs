using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class FormaPagamento
    {
        public string Identificador { get; set; }
        [Required(ErrorMessage = "O código da forma de pagamento é obrigatório.")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "A descrição da forma de pagamento é obrigatório.")]
        public string Descricao { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal ValorAcrescimo { get; set; }
        public decimal PercentualAcrescimo { get; set; }
        public Nullable<Comum.Enumeradores.TipoPagamento> TipoPagamento { get; set; }

    }
}
