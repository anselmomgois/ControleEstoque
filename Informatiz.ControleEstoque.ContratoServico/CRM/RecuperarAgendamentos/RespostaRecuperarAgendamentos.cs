using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.RecuperarAgendamentos
{

   public class RespostaRecuperarAgendamentos : RespostaGenerica
    {

        public List<Comum.Clases.CRM> Agendamentos { get; set; }
    }
}
