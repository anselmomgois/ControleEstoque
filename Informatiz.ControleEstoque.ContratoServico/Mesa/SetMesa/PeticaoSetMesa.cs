using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Mesa.SetMesa
{
    public class PeticaoSetMesa : PeticaoGenerico
    {

        public string IdentificadorFilial { get; set; }
        public Comum.Clases.Mesa Mesa { get; set; }
    }
}