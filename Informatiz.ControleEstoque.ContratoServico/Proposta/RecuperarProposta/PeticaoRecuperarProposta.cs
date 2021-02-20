using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Proposta.RecuperarProposta
{
    public class PeticaoRecuperarProposta : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da proposta é obrigatório.")]
        public string IdentificadorProposta { get; set; }
    }
}
