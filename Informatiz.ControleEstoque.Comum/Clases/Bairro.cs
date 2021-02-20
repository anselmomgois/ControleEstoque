using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Bairro
    {

       public string Identificador { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeCodigo { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
