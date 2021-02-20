using System;
using System.Collections.Generic;


namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Compra
    {

        public Comum.Clases.Pessoa Fornecedor { get; set; }
        public DateTime DataCompra { get; set; }      
        public List<ProdutoCompra> Produtos { get; set; }
        public Enumeradores.EstadoCompra EstadoCompra { get; set; }
        public Nullable<DateTime> DataRecebimento { get; set; }
        public string CodigoRastreio { get; set; }
        public string CodigoNotaFiscal { get; set; }
        public string CodigoCompra { get; set; }
        public string Identificador { get; set; }
        public string ObservacaoCompra { get; set; }
        public Comum.Clases.Filiais Filial { get; set; }
        public decimal NumeroBaseCalculo { get; set; }
        public decimal NumeroValorIcms { get; set; }
        public decimal NumeroBaseSubstituicao { get; set; }
        public decimal NumeroIcmsSubstituicao { get; set; }
        public decimal NumeroValorFrete { get; set; }
        public decimal NumeroSeguro { get; set; }
        public decimal NumeroOutrasDespesas { get; set; }
        public decimal NumeroValorIPI { get; set; }
        public decimal NumeroDesconto { get; set; }
        public Int32 QuantidadeVolumes { get; set; }
        public string Especie { get; set; }
        public Int32 NumeroVolumes { get; set; }
        public string Marca { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }

    }
}
