using System;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios
{
    [Serializable]
    public class Ticket
    {
        public string Sequencia;
        public string CodigoProduto;
        public string DescricaoProduto;
        public Decimal Quantidade;
        public Decimal ValorUnitario;
        public Decimal SubTotal;
    }
}
