using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.RecuperarCidades
{

   public class RespostaRecuperarCidades : RespostaGenerica
    {

        public List<Comum.Clases.Cidade> Cidades { get; set; }
    }
}
