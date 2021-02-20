using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoServico.DeletarProdutoServico
{
    public class PeticaoDeletarProdutoServico : PeticaoGenerico
    {

        public string Identificador { get; set; }
    }
}