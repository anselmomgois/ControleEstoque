using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.UnidadeMedida.SetUnidadeMedida
{
     public class PeticaoSetUnidadeMedida : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "A unidade de Medida é obrigatório.")]
        public Comum.Clases.UnidadeMedida UnidadeMedida { get; set; }
        
    }
}
