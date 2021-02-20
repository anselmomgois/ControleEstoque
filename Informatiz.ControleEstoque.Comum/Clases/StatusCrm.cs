using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class StatusCrm
    {

        public string Identificador { get; set; }
        [Required(ErrorMessage = "O código do status é obrigatório.")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "A descrição do status é obrigatória.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "A cor do status é obrigatória.")]
        public string CorRGB { get; set; }
    }
}
