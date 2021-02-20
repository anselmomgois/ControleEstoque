using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarTipoCrm.Carregar
{

   public class RespostaGuardarTipoCrmCarregar : RespostaGenerica
    {
        public Comum.Clases.TipoCrm TipoCrm { get; set; }
        public List<Comum.Clases.StatusCrmAgrupador> StatusAgrupador { get; set; }
    }
}
