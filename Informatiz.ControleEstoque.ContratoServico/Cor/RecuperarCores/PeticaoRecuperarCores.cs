using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Cor.RecuperarCores
{
    public class PeticaoRecuperarCores : PeticaoGenerico
    {

       public string Descricao { get; set; }
       public string IdentificadorEmpesa { get; set; }
    }
}