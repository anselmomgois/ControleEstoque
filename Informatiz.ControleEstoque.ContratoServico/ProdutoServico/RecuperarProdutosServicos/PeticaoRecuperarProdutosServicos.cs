using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoServico.RecuperarProdutosServicos
{
    public class PeticaoRecuperarProdutosServicos : PeticaoGenerico
    {

        public string Descricao { get; set; }
        public Nullable<Int32> Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string CodigoTipoProduto { get; set; }
        public string IdentificadorFilial { get; set; }
        public Boolean RecuperarUnidadeMedida { get; set; }
        public Boolean RecuperarImagensProduto { get; set; }
    }
}