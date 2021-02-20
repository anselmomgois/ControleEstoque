using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Compra.RecuperarProdutoCompras
{

   public class RespostaRecuperarProdutoCompras : RespostaGenerica
    {
        public List<Comum.Clases.ProdutoCompra> Produtos { get; set; }
    }
}
