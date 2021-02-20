using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI
{

   public class RespostaRecuperarIntegracaoAPI : RespostaGenerica
    {
        public Comum.Clases.IntegracaoAPI IntegracaoAPI { get; set; }
    }
}
