using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.IntegracaoAPI.SetIntegracaoAPI
{
    public class PeticaoSetIntegracaoAPI : PeticaoGenerico
    {

       public string IdentificadorEmpesa { get; set; }
        public Comum.Clases.IntegracaoAPI IntegracaoAPI { get; set; }
    }
}