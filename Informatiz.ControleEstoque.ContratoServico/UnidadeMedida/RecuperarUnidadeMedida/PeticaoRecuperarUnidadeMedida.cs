using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.UnidadeMedida.RecuperarUnidadeMedida
{
     public class PeticaoRecuperarUnidadeMedida : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da unidade de medida é obrigatório.")]
        public string IdentificadorUnidadeMedida { get; set; }
        
    }
}
