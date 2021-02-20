using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.UnidadeMedida.RecuperarUnidadeMedida
{

   public class RespostaRecuperarUnidadeMedida : RespostaGenerica
    {
        public Comum.Clases.UnidadeMedida UnidadeMedida { get; set; }
    }
}
