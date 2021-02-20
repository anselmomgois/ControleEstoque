using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico
{
   public class PeticaoGenerico
    {

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public string Usuario { get; set; }

    }
}
