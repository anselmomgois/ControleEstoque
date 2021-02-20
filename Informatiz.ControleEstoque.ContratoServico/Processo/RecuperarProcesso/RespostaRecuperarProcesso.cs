using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Processo.RecuperarProcesso
{

   public class RespostaRecuperarProcesso : RespostaGenerica
    {
        public Comum.Clases.Processo Processo { get; set; }
    }
}
