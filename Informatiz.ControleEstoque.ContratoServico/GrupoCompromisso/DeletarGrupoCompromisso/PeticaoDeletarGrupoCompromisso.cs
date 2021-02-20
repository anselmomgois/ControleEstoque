using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoCompromisso.DeletarGrupoCompromisso
{
     public class PeticaoDeletarGrupoCompromisso : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador do grupo de compromisso é obrigatório.")]
        public string IdentificadorGrupoCompromisso { get; set; }
      
    }
}
