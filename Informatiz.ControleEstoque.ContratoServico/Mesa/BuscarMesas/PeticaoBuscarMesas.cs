using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Mesa.BuscarMesas
{
    public class PeticaoBuscarMesas : PeticaoGenerico
    {

        public string IdentificadorFilial { get; set; }
        public string Codigo { get; set; }
        public Int32 QuantidadeLugares { get; set; }
    }
}