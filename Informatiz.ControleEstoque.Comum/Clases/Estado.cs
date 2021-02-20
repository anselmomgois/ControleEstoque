using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Estado
    {

       public string Identificador { get; set; }
       public string Codigo { get; set; }
       public string Nome { get; set; }
       public decimal ICMS { get; set; }
       public string CodIbge { get; set; }
       public List<Cidade> Cidades { get; set; }
    }
}
