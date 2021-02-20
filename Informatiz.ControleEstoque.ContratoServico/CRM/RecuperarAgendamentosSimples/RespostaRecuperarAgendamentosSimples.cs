using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.RecuperarAgendamentosSimples
{

    public class RespostaRecuperarAgendamentosSimples : RespostaGenerica
    {

        public List<Comum.Clases.CRMSimples> Agendamentos { get; set; }
    }
}
