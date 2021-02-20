using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Compra.SetCompra
{
    public class PeticaoSetCompra : PeticaoGenerico
    {

        public Comum.Clases.Compra Compra { get; set; }
        public string IdentificadorEmpresa { get; set; }
    }
}
