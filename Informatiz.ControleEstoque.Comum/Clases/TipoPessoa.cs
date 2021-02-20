using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class TipoPessoa
    {

       public string Identificador { get; set; }
       public Enumeradores.Enumeradores.TipoPessoaEnum Codigo { get; set; }
       public string Descricao { get; set; }

    }
}
