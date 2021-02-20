using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.FormaPagamento.BuscarFormaPagamento
{

   public class RespostaBuscarFormaPagamento : RespostaGenerica
    {
        public List<Comum.Clases.FormaPagamento> FormaPagamento { get; set; }
    }
}
