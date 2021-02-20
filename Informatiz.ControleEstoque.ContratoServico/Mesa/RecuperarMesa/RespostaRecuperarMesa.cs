using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Mesa.RecuperarMesa
{

   public class RespostaRecuperarMesa : RespostaGenerica
    {
        public Comum.Clases.Mesa Mesa { get; set; }
    }
}
