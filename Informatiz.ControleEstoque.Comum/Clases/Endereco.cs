using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Endereco
    {

       public string Identificador { get; set; }
       public string DescricaoCep { get; set; }
       public string DescricaoRua { get; set; }
       public int Codigo { get; set; }
       public string NomeCodigo { get; set; }
       public string DesReferencia { get; set; }
       public Nullable<int> Numero { get; set; }
       public string Complemento { get; set; }
    }
}
