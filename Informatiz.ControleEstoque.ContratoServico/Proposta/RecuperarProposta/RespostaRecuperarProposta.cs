using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Proposta.RecuperarProposta
{

   public class RespostaRecuperarProposta : RespostaGenerica
    {
        public Comum.Clases.Proposta Proposta { get; set; }
    }
}
