using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoServico.RecuperarProdutosServicos
{

   public class RespostaRecuperarProdutosServicos : RespostaGenerica
    {
        public List<Comum.Clases.ProdutoServico> ProdutosServicos { get; set; }
    }
}
