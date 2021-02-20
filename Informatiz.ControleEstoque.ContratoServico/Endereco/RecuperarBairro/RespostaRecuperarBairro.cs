using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.RecuperarBairro
{

   public class RespostaRecuperarBairro : RespostaGenerica
    {

        public List<Comum.Clases.Bairro> Bairros { get; set; }
    }
}
