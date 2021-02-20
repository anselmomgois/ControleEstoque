using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Setor.BuscarSetores
{

   public class RespostaBuscarSetores : RespostaGenerica
    {
        
        public List<Comum.Clases.SetorEmpresa> Setores { get; set; }
    }
}
