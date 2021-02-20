using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.BuscarStatusCrmDetalhe
{

   public class RespostaStatusCrmDetalhe :RespostaGenerica
    {
        public Comum.Clases.StatusCrmAgrupador StatusAgrupador { get; set; }
    }
}
