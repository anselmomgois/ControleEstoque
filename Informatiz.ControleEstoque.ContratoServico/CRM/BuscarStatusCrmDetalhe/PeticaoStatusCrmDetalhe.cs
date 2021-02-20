using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.BuscarStatusCrmDetalhe
{
     public class PeticaoStatusCrmDetalhe : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador do status é obrigatório.")]
        public string IdentificadorStatusCrmAgrupador { get; set; }
    }
}
