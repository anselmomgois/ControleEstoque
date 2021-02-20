using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.TipoCrm.BuscarTipoCrm
{

   public class RespostaBuscarTipoCrm : RespostaGenerica
    {
        public Comum.Clases.TipoCrm TipoCrm { get; set; }
    }
}
