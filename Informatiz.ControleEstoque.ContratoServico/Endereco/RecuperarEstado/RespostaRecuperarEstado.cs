using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.RecuperarEstado
{

   public class RespostaRecuperarEstado : RespostaGenerica
    {
       
        public List<Comum.Clases.Estado> Estados { get; set; }
    }
}
