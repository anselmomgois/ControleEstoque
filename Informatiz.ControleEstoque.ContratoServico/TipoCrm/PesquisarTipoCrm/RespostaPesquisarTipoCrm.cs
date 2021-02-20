using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.TipoCrm.PesquisarTipoCrm
{

   public class RespostaPesquisarTipoCrm : RespostaGenerica
    {
        public List<Comum.Clases.TipoCrm> TiposCrm { get; set; }
        
    }
}
