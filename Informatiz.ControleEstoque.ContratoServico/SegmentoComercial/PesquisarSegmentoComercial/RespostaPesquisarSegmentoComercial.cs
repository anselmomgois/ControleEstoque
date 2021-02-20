using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.SegmentoComercial.PesquisarSegmentoComercial
{

   public class RespostaPesquisarSegmentoComercial : RespostaGenerica
    {
        public List<Comum.Clases.SegmentoComercial> SegmentoComercias { get; set; }
    }
}
