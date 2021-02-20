using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarIntegracaoAPI.Carregar
{

   public class RespostaGuardarIntegracaoAPICarregar : RespostaGenerica
    {
        public List<Comum.Clases.TipoCrm> TiposCrm { get; set; }
        public Comum.Clases.IntegracaoAPI IntegracaoAPI { get; set; }
    }
}
