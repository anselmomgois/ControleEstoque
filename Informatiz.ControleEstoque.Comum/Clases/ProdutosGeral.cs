using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class ProdutosGeral
    {

      public  List<Comum.Clases.ProdutoServico> ProdutosEmpresa { get; set; }
      public  List<Comum.Clases.ProdutoServico> ProdutosFilial { get; set; }
      public  List<Comum.Clases.ProdutoServico> ProdutoFilialEstoque { get; set; }
    }
}
