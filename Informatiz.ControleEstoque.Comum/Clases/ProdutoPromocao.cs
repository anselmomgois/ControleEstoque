using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class ProdutoPromocao
    {

        public string Identificador { get; set; }
        public Int32 Codigo { get; set; }
        public string Descricao { get; set; }
        public Nullable<decimal> PercentualDesconto { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Boolean Habilitada { get; set; }
        public DateTime DataInicio { get; set; }
        public Nullable<DateTime> DataFim { get; set; }
        public List<Comum.Clases.ProdutoServico> PrudutosEmpresa { get; set; }
        public List<Comum.Clases.ProdutoServico> ProdutosPorFilial { get; set; }
        public List<Comum.Clases.ProdutoServico> ProdutosCompra { get; set; }
        public List<Comum.Clases.ProdutoServico> Produtos { get; set; }
        public decimal Estoque { get; set; }
        public string CodigoTipoPromocao { get; set; }
        public Boolean PorHorario { get; set; }
        public List<Comum.Enumeradores.Enumeradores.DiasSemana> DiasSemana { get; set; }
    }
}
