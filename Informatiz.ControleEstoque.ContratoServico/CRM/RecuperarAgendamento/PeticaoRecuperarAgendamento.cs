using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.RecuperarAgendamento
{
     public class PeticaoRecuperarAgendamento : PeticaoGenerico
    {

        [Required(ErrorMessage = "O Identificador do CRM é obrigatório.")]
        public string IdentificadorCRM { get; set; }
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public string Usuario { get; set; }
    }
}
