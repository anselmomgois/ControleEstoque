using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarProdutoPromocao.Carregar
{

   public class RespostaGuardarProdutoPromocaoCarregar : RespostaGenerica
    {
        public Comum.Clases.ProdutosGeral ProdutosGeral { get; set; }
        public Comum.Clases.ProdutoPromocao ProdutoPromocao { get; set; }
    }
}
