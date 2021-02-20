using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Mesa.BuscarMesas
{

   public class RespostaBuscarMesas : RespostaGenerica
    {
        public List<Comum.Clases.Mesa> Mesas { get; set; }
    }
}
