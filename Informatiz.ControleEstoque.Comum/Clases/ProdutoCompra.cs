using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{

    public class ProdutoCompra
    {

        public string Identificador { get; set; }
        public DateTime DataCompra { get; set; }
        public string CodigoCompra { get; set; }
        public string IdentificadorProdutoFilial { get; set; }
        public Comum.Clases.ProdutoServico Produto { get; set; }
        public List<ProdutoNumeroSerie> NumerosSerie { get; set; }
        public Comum.Clases.UnidadeMedida UnidadeMedidaCompra { get; set; }
        public Comum.Clases.UnidadeMedida UnidadeMedidaValorProduto { get; set; }
        public Decimal NumeroQuantidadeCompra { get; set; }
        public Decimal NumeroEstoqueConvertido { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal Estoque { get; set; }
        public Nullable<DateTime> DataValidade { get; set; }
        public string CodigoLote { get; set; }
        public decimal NumeroCstIcms { get; set; }
        public decimal NumeroPorcentagemIcms { get; set; }
        public decimal NumeroPorcentagemBcIcms { get; set; }
        public decimal NumeroCstIpi { get; set; }
        public decimal NumeroIpi { get; set; }
        public decimal NumeroPorcentagemIpi { get; set; }
        public decimal NumeroCfop { get; set; }
        public decimal NumeroIcms { get; set; }
        public decimal NumeroBcIcms { get; set; }
        public decimal NumeroBcSt { get; set; }
        public decimal NumeroIcmsSt { get; set; }
        public Boolean EstoqueAtual { get; set; }
    }
}
