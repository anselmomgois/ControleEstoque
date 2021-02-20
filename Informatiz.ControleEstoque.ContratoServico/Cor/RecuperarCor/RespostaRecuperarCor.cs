using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Cor.RecuperarCor
{

   public class RespostaRecuperarCor : RespostaGenerica
    {
        public Comum.Clases.Cor Cor { get; set; }
    }
}
