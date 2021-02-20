using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.TipoEmpregado.BuscarTipoEmpregado
{

   public class RespostaBuscarTipoEmpregado : RespostaGenerica
    {
        public Comum.Clases.TipoEmpregado TipoEmpregado { get; set; }
    }
}
