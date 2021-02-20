using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.SetEndereco
{
     public class PeticaoSetEndereco : PeticaoGenerico
    {

       public string IdentificadorBairro { get; set; }
       public Comum.Clases.Endereco Endereco { get; set; }
    }
}
