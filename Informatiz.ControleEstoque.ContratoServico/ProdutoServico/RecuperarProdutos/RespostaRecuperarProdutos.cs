using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoServico.RecuperarProdutos
{

   public class RespostaRecuperarProdutos : RespostaGenerica
    {
        public List<Comum.Clases.ProdutoDisponivelVenda> ProdutosDisponiveisVenda { get; set; }
    }
}
