using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.BuscarStatusCrm
{

   public class RespostaBuscarStatusCrm : RespostaGenerica
    {
        public List<Comum.Clases.StatusCrmAgrupador> StatusAgrupador { get; set; }
    }
}
