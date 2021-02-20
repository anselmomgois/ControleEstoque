using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.TipoCrm.SetTipoCrm
{
     public class PeticaoSetTipoCrm : PeticaoGenerico
    {

        public Comum.Clases.TipoCrm TipoCrm { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        
    }
}
