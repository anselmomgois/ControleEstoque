using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoPromocao.SetProdutoPromocao
{
    public class PeticaoSetProdutoPromocao : PeticaoGenerico
    {

        public Comum.Clases.ProdutoPromocao ProdutoPromocao{ get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFilial { get; set; }

    }
}