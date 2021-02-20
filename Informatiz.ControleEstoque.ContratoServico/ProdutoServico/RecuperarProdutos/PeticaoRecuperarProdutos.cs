using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoServico.RecuperarProdutos
{
    public class PeticaoRecuperarProdutos : PeticaoGenerico
    {
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFilial { get; set; }       
        public string Descricao { get; set; }
        public Int32 Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public bool RecuperarImagensProduto { get; set; }
        public DateTime DataAtual { get; set; }
    }
}