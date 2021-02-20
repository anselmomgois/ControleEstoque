using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Informatiz.AlterarImagemCentral
{
     public class PeticaoAlterarImagemCentral : PeticaoGenerico
    {

        [Required(ErrorMessage = "A imagem é obrigatória.")]
        public Comum.Clases.Imagem ImagemCentral { get; set; }

    }
}
