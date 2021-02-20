using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class ProdutoFilial
    {

       public string Identificador { get; set; }
       public ProdutoComissao Comissao { get; set; }
        public SetorEmpresa SetorEmpresa { get; set; }
        public UnidadeMedida UnidadeMediaEstoque { get; set; }
        public UnidadeMedida UnidadeMedidaVenda { get; set; }
        public string DesPrateleira { get; set; }
        public Nullable<decimal> NumEstoqueMinimo { get; set; }
        public Nullable<decimal> NumMinimoVenda { get; set; }
        public Nullable<decimal> NumIPIPercentual { get; set; }
        public Nullable<decimal> NumEmbalagemPercentual { get; set; }
        public Nullable<decimal> NumFretePercentual { get; set; }
        public Nullable<decimal> NumOutrasDespesasPercentual { get; set; }
        public Nullable<decimal> NumValorVendaVarejo { get; set; }
        public Nullable<decimal> NumValorVendaAtacado { get; set; }
        public Nullable<int> NumQuantidadeVendaAtacado { get; set; }
        public Nullable<decimal> NumDescontoAtacadoPercentual { get; set; }
        public UnidadeMedida UnidadeMedidaVendaVarejo { get; set; }
        public UnidadeMedida UnidadeMedidaVendaAtacado { get; set; }
        public UnidadeMedida UnidadeMedidaQuantidadeVendaAtacado { get; set; }

    }
}
