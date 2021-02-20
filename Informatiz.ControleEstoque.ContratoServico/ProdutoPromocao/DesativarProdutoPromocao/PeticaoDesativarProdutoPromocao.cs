using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoPromocao.DesativarProdutoPromocao
{
    public class PeticaoDesativarProdutoPromocao : PeticaoGenerico
    {

        public string IdentificadorProdutoPromocao { get; set; }
    }
}