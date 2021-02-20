using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   
    public class ProdutoDisponivelVenda
    {

        public int CantidadAgrupada { get; set; }
        public string SequenciaAgrupada { get; set; }
        // 1 - Acrescimo, 2 - Desconto, 3 - ValorUnitario
        public int TipoPorcentagem;
        public Int32 Sequencia { get; set; }
        public ProdutoServico Produto { get; set; }//ok
        public List<ProdutoNumeroSerie> NumerosSerie { get; set; }//ok fazer depois
                                                                  
        public SetorEmpresa SetorEmpresa { get; set; } //ok LISTO

        public UnidadeMedida UnidadeMediaEstoque { get; set; }//ok
        public UnidadeMedida UnidadeMedidaVenda { get; set; }//ok
        public UnidadeMedida UnidadeMedidaVendaVarejo { get; set; }//ok
        public UnidadeMedida UnidadeMedidaVendaAtacado { get; set; }//ok
        public UnidadeMedida UnidadeMedidaQuantidadeVendaAtacado { get; set; }//ok

        // produto filial
        public Nullable<decimal> NumMinimoVenda { get; set; }
        public Nullable<decimal> NumOutrasDespesasPercentual { get; set; }
        public Nullable<decimal> NumValorVendaVarejo { get; set; }
        public Nullable<decimal> NumValorVendaAtacado { get; set; }
        public Nullable<int> NumQuantidadeVendaAtacado { get; set; }
        public Nullable<decimal> NumDescontoAtacadoPercentual { get; set; }

        public Nullable<decimal> PercentualDescontoPromocao { get; set; }//ok
        public Nullable<decimal> ValorDescontoPromocao { get; set; }//ok
                
        // passar data e hora da tela para o serviço e calcular valor/percentual da promoção

        public decimal NumQuantidadeVendido { get; set; }
        public decimal NumValorProdutoCalculado { get; set; }
        public decimal NumValorDescontoCalculado { get; set; }
        public decimal NumValorAcrescimoCalculado { get; set; }
        public decimal NumValorAcrescimoProdutoCalculado { get; set; }
        public decimal NumValorPercentualModificado { get; set; }
        public Boolean CalculoTotalEfetuado { get; set; }
        public List<Comum.Clases.Acrescimo> Acrescimos { get; set; }
        public List<Comum.Clases.ProdutoObservacao> Observacoes { get; set; }
    }
}
