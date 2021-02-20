using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.TipoCrm.ExcluirTipoCrm
{
     public class PeticaoExcluirTipoCrm : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador é obrigatório.")]
        public string Identificador { get; set; }
        
    }
}
