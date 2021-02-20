using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoCompromisso.SetGrupoCompromisso
{
     public class PeticaoSetGrupoCompromisso : PeticaoGenerico
    {

        [Required(ErrorMessage = "O grupo é obrigatório.")]
        public Comum.Clases.GrupoCompromisso GrupoCompromisso { get; set; }

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
      
    }
}
