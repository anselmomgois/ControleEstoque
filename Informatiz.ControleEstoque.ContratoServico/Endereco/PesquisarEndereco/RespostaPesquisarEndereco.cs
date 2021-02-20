using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Endereco.PesquisarEndereco
{

   public class RespostaPesquisarEndereco : RespostaGenerica
    {

        public List<Comum.Clases.Endereco> Enderecos { get; set; }
    }
}
