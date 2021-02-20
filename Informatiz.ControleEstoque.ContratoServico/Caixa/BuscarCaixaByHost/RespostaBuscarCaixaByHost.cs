using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Caixa.BuscarCaixaByHost
{

   public class RespostaBuscarCaixaByHost : RespostaGenerica
    {
        public Comum.Clases.Caixa Caixa { get; set; }
    }
}
