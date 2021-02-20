using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Chave
    {

        public string ChaveAcesso { get; set; }
        public string ChaveAcessoCriptografada { get; set; }
        public string Identificador { get; set; }
        public Boolean SessoesInfinitas { get; set; }
        public Nullable<Int32> QuantidadeSessoes { get; set; }
        public Nullable<Int32> Validade { get; set; }
        public Boolean ValidadeInfinita { get; set; }
        public Int32 QuantidadeAcessos { get; set; }
        public Nullable<DateTime> DataAtivacao { get; set; }

    }
}
