using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Compra.RecuperarCompras
{

   public class RespostaRecuperarCompras : RespostaGenerica
    {
        public List<Comum.Clases.Compra> Compras { get; set; }
    }
}
