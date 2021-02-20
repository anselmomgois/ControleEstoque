using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Caixa.BuscarCaixa
{
    public class PeticaoBuscarCaixa : PeticaoGenerico
    {
        public int? Codigo { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFilial { get; set; }
    }
}
