using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Compra.RecuperarProdutoCompras
{
     public class PeticaoRecuperarProdutoCompras : PeticaoGenerico
    {

        public string IdentificadorProdutoServico { get; set; }
        public string IdentificadorFilial { get; set; }
    }
}
