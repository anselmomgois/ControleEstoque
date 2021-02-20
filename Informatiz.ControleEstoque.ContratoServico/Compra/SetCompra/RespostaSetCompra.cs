using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Compra.SetCompra
{

   public class RespostaSetCompra : RespostaGenerica
    {
        public string IdentificadorCompra { get; set; }
    }
}
