using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Proposta
    {

       public string Identificador { get; set; }
       public string IdentificadorAuxiliar { get; set; }
       public Int32 Codigo { get; set; }
       public string Descricao { get; set; }
       public Pessoa PessoaResponsavel { get; set; }
       public string IdentificadorCRM { get; set; }
       public Pessoa Cliente { get; set; }
       public decimal ValorPropostaVenda { get; set; }
       public decimal ValorPropostaManutencao { get; set; }
       public decimal ValorContraPropostaVenda { get; set; }
       public decimal ValorContraPropostaManutencao { get; set; }
       public string DesOpniao { get; set; }
       public string DesDuvida { get; set; }
       public Boolean AtendeNecessidade { get; set; }
       public Nullable<DateTime> DataHoraInstalacao { get; set; }
       public Boolean Ativa { get; set; }

    }
}
