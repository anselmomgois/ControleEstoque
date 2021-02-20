using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao
{
    public class PeticaoPesquisarProdutoPromocao : PeticaoGenerico
    {

        public string IdentificadorEmpresa { get; set; }
        public string Descricao { get; set; }
        public string DescricaoProduto { get; set; }
        public string IdentificadorFilial { get; set; }
    }
}