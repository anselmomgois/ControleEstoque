using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Relatorios.RecuperarFechamentoCaixa
{

   public class RespostaRecuperarFechamentoCaixa : RespostaGenerica
    {
        public Comum.Clases.Relatorios.FechamentoCaixaGeral.DadosRelatorio DadosRelatorio { get; set; }
        public List<Comum.Clases.Sangria> Sangrias { get; set; }
        public List<Comum.Clases.Suprimento> Suprimentos { get; set; }
        public List<Comum.Clases.Relatorios.FechamentoCaixaGeral.PagamentosTotais> PagamentosTotais { get; set; }
        public List<Comum.Clases.Relatorios.FechamentoCaixaGeral.PagamentoTotalPorVenda> PagamentosTotaisPorVenda { get; set; }
        public List<Comum.Clases.Relatorios.FechamentoCaixaGeral.DetalheVenda> DetalhesVenda { get; set; }
        public List<Comum.Clases.Pessoa> PessoasEnviarEmail { get; set; }
    }
}
