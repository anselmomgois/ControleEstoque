using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.RegistrarSangria
{
     public class PeticaoRegistrarSangria : PeticaoGenerico
    {

        [Required(ErrorMessage = "Sangria obrigatória")]
        public Comum.Clases.Sangria Sangria { get; set; }
        
    }
}
