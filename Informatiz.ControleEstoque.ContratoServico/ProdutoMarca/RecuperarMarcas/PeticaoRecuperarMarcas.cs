using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.ProdutoMarca.RecuperarMarcas
{
    public class PeticaoRecuperarMarcas : PeticaoGenerico
    {

       public string Descricao { get; set; }
        public string IdentificadorEmpresa { get; set; }
    }
}