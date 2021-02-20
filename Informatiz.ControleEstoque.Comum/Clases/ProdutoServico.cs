using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   
    public class ProdutoServico
    {

        public string Identificador { get; set; }
        public GrupoProduto GrupoProduto { get; set; }
        public Cor Cor { get; set; }
        public ProdutoDerivacao ProdutoDerivacao { get; set; }
        public ProdutoCategoria ProdutoCategoria { get; set; }
        public ProdutoMarca ProdutoMarca { get; set; }
        public ProdutoNCM ProdutoNCM { get; set; }
        public ProdutoCST ProdutoCST { get; set; }
        public ProdutoCFOP ProdutoCFOP { get; set; }
        public List<UnidadeMedida> UnidadesMedida { get; set; }
        public TipoProdutoServico TipoProdutoServico { get; set; }
        public Int32 Codigo { get; set; }
        public string Descricao { get; set; }
        public List<ProdutoServicoCodigoBarras> CodigosBarras { get; set; }
        public string Observacao { get; set; }
        public Nullable<Decimal> Peso { get; set; }
        public Byte[] ImgProduto { get; set; }
        public string IdentificadorProdutoCompra { get; set; }
        public string IdentificadorProdutoFilial { get; set; }
        public decimal Estoque { get; set; }
        public Boolean VendaAGranel { get; set; }
        public Boolean ProdutoInterno { get; set; }
        public Boolean Acrescimo { get; set; }
        public Boolean VendaPorNumeroSerie { get; set; }
        public List<ProdutoObservacao> ObservacoesProduto { get; set; }
        public List<Acrescimo> Acrescimos { get; set; }
    }
}
