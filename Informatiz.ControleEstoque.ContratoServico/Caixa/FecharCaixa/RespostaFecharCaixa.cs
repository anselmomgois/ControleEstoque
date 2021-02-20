using System.Collections.Generic;

namespace Informatiz.ControleEstoque.ContratoServico.Caixa.FecharCaixa
{

   public class RespostaFecharCaixa : RespostaGenerica
    {
        public List<Comum.Clases.FechamentoCaixa> PagamentosEfetuados { get; set; }
    }
}
