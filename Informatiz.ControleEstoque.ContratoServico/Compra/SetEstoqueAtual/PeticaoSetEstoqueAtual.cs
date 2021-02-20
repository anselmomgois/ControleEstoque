using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Compra.SetEstoqueAtual
{
    public class PeticaoSetEstoqueAtual : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador item de compra obrigatório")]
        public string IdentificadorItemCompra { get; set; }
        [Required(ErrorMessage = "O identificador produto filial obrigatório")]
        public string IdentificadorProdutoFilial { get; set; }
    }
}
