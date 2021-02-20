using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoFilial.SetProdutoFilial
{
    public class PeticaoSetProdutoFilial : PeticaoGenerico
    {

        public Comum.Clases.ProdutoFilial ProdutoFilial { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFilial { get; set; }
        public string IdentificadorProdutoServico { get; set; }

    }
}