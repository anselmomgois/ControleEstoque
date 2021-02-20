using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoCategoria.DeletarProdutoCategoria
{
    public class PeticaoDeletarProdutoCategoria : PeticaoGenerico
    {

       public string IdentificadorProdutoCategoria { get; set; }
    }
}