using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Filial.RecuperarFiliais
{

   public class RespostaRecuperarFiliais : RespostaGenerica
    {
        public List<Comum.Clases.Filiais> Filiais { get; set; }
    }
}
