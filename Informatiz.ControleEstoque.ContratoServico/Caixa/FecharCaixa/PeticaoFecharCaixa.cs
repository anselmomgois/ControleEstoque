using System.Collections.Generic;

namespace Informatiz.ControleEstoque.ContratoServico.Caixa.FecharCaixa
{
     public class PeticaoFecharCaixa : PeticaoGenerico
    {
        public string IdentificadorCaixa { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorResponsavelCaixa { get; set; }
        public string IdentificadorSupervisor { get; set; }
        public string IdentificadorFilial { get; set; }
        public List<Comum.Clases.FechamentoCaixa> PagamentosEfetuados { get; set; }
    }
}
