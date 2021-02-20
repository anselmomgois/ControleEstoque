using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Parcelamento
    {

       public string Identificador { get; set; }
       public DateTime DataVencimentoAtual { get; set; }
       public DateTime DataVencimentoOriginal { get; set; }
       public decimal ValorOriginal { get; set; }
       public Int32 NumeroParcela { get; set; }
       public List<Transacao> Transacoes { get; set; }

    }
}
