using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.StatusCrm
{
     public class PeticaoStatusCrm : PeticaoGenerico
    {

        [Required(ErrorMessage = "O status é obrigatório.")]
        public Comum.Clases.StatusCrmAgrupador Status { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
    }
}
