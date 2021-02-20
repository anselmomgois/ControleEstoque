using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.CancelarItems
{
     public class PeticaoCancelarItems : PeticaoGenerico
    {
        [Required(ErrorMessage = "O identificador da venda é obrigatório")]
        public string IdentificadorVenda { get; set; }
        [Required(ErrorMessage = "O identificador do supervisor é obrigatório")]
        public string IdentificadorSupervisorCancelamento { get; set; }
        [Required(ErrorMessage = "O identificador da filial é obrigatório")]
        public string IdentificadorFilial { get; set; }
        public List<Comum.Clases.ItemVenda> Items { get; set; }

    }
}
