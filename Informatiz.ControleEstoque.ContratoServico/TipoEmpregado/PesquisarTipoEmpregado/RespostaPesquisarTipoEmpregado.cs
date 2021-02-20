using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.TipoEmpregado.PesquisarTipoEmpregado
{

   public class RespostaPesquisarTipoEmpregado : RespostaGenerica
    {
        public List<Comum.Clases.TipoEmpregado> TiposEmpregado { get; set; }
    }
}
