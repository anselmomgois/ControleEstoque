using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.APIExterna.Modelo2
{
    public class RootObject
    {
        public string id { get; set; }
        public string usuario { get; set; }
        public string did { get; set; }
        public string data { get; set; }
        public string hora { get; set; }
        public string telefone { get; set; }
        public object nome { get; set; }
    }
}
