using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.InserirAgendamento
{
     public class PeticaoInserirAgendamento : PeticaoGenerico
    {

        [Required(ErrorMessage = "Os dados do crm são obrigatório.")]
        public Comum.Clases.CRM CRM { get; set; }

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
    }
}
