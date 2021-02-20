using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Proposta.SetProposta
{
    public class PeticaoSetProposta : PeticaoGenerico
    {

        [Required(ErrorMessage = "A proposta é obrigatória.")]
        public Comum.Clases.Proposta Proposta { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
    }
}
