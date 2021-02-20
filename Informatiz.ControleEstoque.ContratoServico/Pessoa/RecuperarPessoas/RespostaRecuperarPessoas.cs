using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Pessoa.RecuperarPessoas
{

   public class RespostaRecuperarPessoas : RespostaGenerica
    {
        public List<Comum.Clases.Pessoa> Pessoas { get; set; }
    }
}
