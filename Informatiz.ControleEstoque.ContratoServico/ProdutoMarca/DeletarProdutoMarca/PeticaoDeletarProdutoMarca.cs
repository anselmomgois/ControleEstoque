using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoMarca.DeletarProdutoMarca
{
    public class PeticaoDeletarProdutoMarca : PeticaoGenerico
    {

       public string IdentificadorProdutoMarca { get; set; }
    }
}