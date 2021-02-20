using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoProduto.DeletarGrupoProduto
{
     public class PeticaoDeletarGrupoProduto : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador do grupo é obrigatório.")]
        public string IdentificadorGrupoProduto { get; set; }

    }
}
