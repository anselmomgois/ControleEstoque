using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Parametros
{
    public class ParametrosAplicacao
    {
        public string CodigoTipoCrmDefault { get; set; }
        public string DescricaoClienteDefault { get; set; }
        public Int32 IntervaloExecucaoAPI { get; set; }
        public Int32 IntervaloCompromissoCrm { get; set; }
        public string NivelAtendimentoPadrao { get; set; }
        public Int32 ValorRealizarSangria { get; set; }
        public string FormaPagamentoPadrao { get; set; }
        public Boolean RecuperarImagemProduto { get; set; }
        public Boolean ImprimirTicketVenda { get; set; }
        public Boolean ImprimirTicketSetor { get; set; }
        public Boolean CodigoBarrasPorValor { get; set; }
        public Boolean ExibirRelatorioFechamento { get; set; }
        public string TipoCodigoBarras { get; set; }
        public Boolean TrabalhaPorComanda { get; set; }
        public Boolean GerarComandaAutomatico { get; set; }
    }
}
