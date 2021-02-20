using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class GrupoPermissao
    {

       public string Identificador { get; set; }
       public string Nome { get; set; }
       public string IdentificadorEmpresa { get; set; }
       public List<Comum.Clases.Permissao> Permissoes { get; set; }

    }
}
