using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.SetCidades
{
     public class PeticaoSetCidades : PeticaoGenerico
    {

       public string IdentificadorEstado { get; set; }
       public Comum.Clases.Cidade Cidade { get; set; }
    }
}
