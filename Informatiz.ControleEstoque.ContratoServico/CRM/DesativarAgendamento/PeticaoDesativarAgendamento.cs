using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.DesativarAgendamento
{
     public class PeticaoDesativarAgendamento : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador do CRM é obrigatório.")]
        public string IdentificadorCRM { get; set; }
    }
}
