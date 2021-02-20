using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Sessao.AtualizarSessao
{

   public class RespostaAtualizarSessao : RespostaGenerica
    {
      public Boolean SessaoExpirada { get; set; }  
    }
}
