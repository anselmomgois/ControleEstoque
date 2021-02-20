using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoServico.SetProdutoServico
{
    public class PeticaoSetProdutoServico : PeticaoGenerico
    {

        public Comum.Clases.ProdutoServico ProdutoServico { get; set; }
        public string IdentificadorEmpresa { get; set; }
    }
}