namespace Informatiz.ControleEstoque.ContratoServico.Caixa.SetCaixa
{
    public class PeticaoSetCaixa : PeticaoGenerico
    {
        public Comum.Clases.Caixa Caixa { get; set; }
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFilial { get; set; }
    }
}
