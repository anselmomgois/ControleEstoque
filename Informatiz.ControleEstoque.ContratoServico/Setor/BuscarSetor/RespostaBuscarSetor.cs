using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Setor.BuscarSetor
{

   public class RespostaBuscarSetor : RespostaGenerica
    {
        
        public Comum.Clases.SetorEmpresa Setor { get; set; }
    }
}
