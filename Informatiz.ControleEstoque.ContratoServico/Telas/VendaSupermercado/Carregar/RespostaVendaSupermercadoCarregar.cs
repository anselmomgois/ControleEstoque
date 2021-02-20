using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.VendaSupermercado.Carregar
{

    public class RespostaVendaSupermercadoCarregar : RespostaGenerica
    {
        public List<Comum.Clases.ProdutoMarca> Marcas { get; set; }
        public List<Comum.Clases.Cor> Cores { get; set; }
        public List<Comum.Clases.ProdutoNCM> ProdutosNCMs { get; set; }
        public List<Comum.Clases.ProdutoCST> ProdutosCSTs { get; set; }
        public List<Comum.Clases.ProdutoCFOP> ProdutosCFOPs { get; set; }
        public List<Comum.Clases.GrupoProduto> GruposProduto { get; set; }
        public List<Comum.Clases.UnidadeMedida> UnidadesMedida { get; set; }
        public List<Comum.Clases.ProdutoCategoria> Categorias { get; set; }
        public List<Comum.Clases.ProdutoDerivacao> Derivacoes { get; set; }
        public Comum.Clases.ProdutoServico ProdutoServico { get; set; }
        public Comum.Clases.TipoProdutoServico TipoProduto { get; set; }
        public Comum.Clases.TipoProdutoServico TipoServico { get; set; }

    }
}
