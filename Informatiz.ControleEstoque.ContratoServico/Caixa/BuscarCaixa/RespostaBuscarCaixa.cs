using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Caixa.BuscarCaixa
{

   public class RespostaBuscarCaixa : RespostaGenerica
    {
        public List<Comum.Clases.Caixa> Caixas { get; set; }
    }
}
