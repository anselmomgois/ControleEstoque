using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoCategoria.RecuperarCategorias
{
    public class PeticaoRecuperarCategorias : PeticaoGenerico
    {

       public string Descricao { get; set; }
        public string IdentificadorEmpresa { get; set; }
    }
}