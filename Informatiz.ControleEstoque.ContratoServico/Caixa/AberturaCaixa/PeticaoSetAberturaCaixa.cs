using System;

namespace Informatiz.ControleEstoque.ContratoServico.Caixa.SetAberturaCaixa
{
    public class PeticaoSetAberturaCaixa : PeticaoGenerico
    {
        public string IdentificadorResponsavelCaixa { get; set; }
        public string IdentificadorCaixa { get; set; }
        public string IdentificadorResponsavel { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorSaldo { get; set; }
        public DateTime InicioOperacao { get; set; }
        public DateTime FimOperacao { get; set; }
        public Boolean Fechado { get; set; }
    }
}
