using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Venda.ModificarPrecoProdutoVenda
{
    public class PeticaoModificarPrecoProdutoVenda : PeticaoGenerico
    {
        [Required(ErrorMessage = "O identificador da venda é obrigatório.")]
        public string IdentificadorVenda { get; set; }
        public List<Comum.Clases.ItemVenda> Items { get; set; }

    }
}
