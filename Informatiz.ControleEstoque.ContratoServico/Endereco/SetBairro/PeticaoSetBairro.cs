using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.SetBairro
{
     public class PeticaoSetBairro : PeticaoGenerico
    {

       public string IdentificadorCidade { get; set; }
       public Comum.Clases.Bairro Bairro { get; set; }
    }
}
