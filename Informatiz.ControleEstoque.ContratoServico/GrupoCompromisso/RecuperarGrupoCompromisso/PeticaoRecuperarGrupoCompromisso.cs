using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso
{
     public class PeticaoRecuperarGrupoCompromisso : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador do grupo é obrigatório.")]
        public string IdentificadorGrupoCompromisso { get; set; }
       
    }
}
