using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class CRM
    {

        public string Identificador { get; set; }
        [Required(ErrorMessage = "O funcionário é obrigatório.")]
        public Pessoa FuncionarioCadastro { get; set; }
        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public Pessoa Cliente { get; set; }
        public Int32 Codigo { get; set; }
        [Required(ErrorMessage = "A observação é obrigatória.")]
        public string Observacao { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusCrm StatusCrm { get; set; }
        [Required(ErrorMessage = "O agendamento é obrigatório.")]
        public List<Agendamento> Atendimentos { get; set; }
        public List<Proposta> Propostas { get; set; }
        public Boolean Ativo { get; set; }
        public Comum.Clases.TipoCrm TipoCrm { get; set; }
        public string Consultor { get; set; }

    }
}
