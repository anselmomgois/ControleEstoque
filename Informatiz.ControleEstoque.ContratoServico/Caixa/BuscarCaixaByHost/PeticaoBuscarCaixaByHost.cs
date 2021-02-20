using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Caixa.BuscarCaixaByHost
{
    public class PeticaoBuscarCaixaByHost : PeticaoGenerico
    {
        public string HostName { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFilial { get; set; }
    }
}
