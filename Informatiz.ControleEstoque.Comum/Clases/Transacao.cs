using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public  class Transacao
    {

      public string Identificador { get; set; }
      public decimal ValorAcrescimo { get; set; }
      public decimal ValorDesconto { get; set; }
      public decimal ValorTransacao { get; set; }
      public DateTime DataTransacao { get; set; }

    }
}
