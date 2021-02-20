using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.SegmentoComercial.RecuperarSegmentoComercial
{

   public class RespostaRecuperarSegmentoComercial : RespostaGenerica
    {
        public Comum.Clases.SegmentoComercial SegmentoComercial { get; set; }
    }
}
