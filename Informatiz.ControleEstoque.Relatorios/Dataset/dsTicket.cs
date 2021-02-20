namespace Informatiz.ControleEstoque.Relatorios.DataSet
{
    public partial class dsTicket
    {

        public void PopularDataSet(object objDados)
        {

            Comum.Clases.Relatorios.FechamentoVenda.FechamentoCaixa objFechamento = (Comum.Clases.Relatorios.FechamentoVenda.FechamentoCaixa)objDados;

            FiltroRow drFiltro = this.Filtro.NewFiltroRow();

            drFiltro.Comanda = objFechamento.comanda;
            drFiltro.Cnpj = objFechamento.cnpj;
            drFiltro.Data = objFechamento.Data.ToString("dd/MM/yyyy");
            drFiltro.Hora = objFechamento.Data.ToString("HH:mm:ss");
            drFiltro.FormaPagto = string.IsNullOrEmpty(objFechamento.FormaPagamento) ? string.Empty : objFechamento.FormaPagamento.ToUpper();
            drFiltro.Atendente = objFechamento.Atendente.ToUpper();
            drFiltro.NomeEmpresa = objFechamento.NomeEmpresa.ToUpper();
            drFiltro.TelefoneEmpresa = string.IsNullOrEmpty(objFechamento.TelefoneEmpresa) ? string.Empty : objFechamento.TelefoneEmpresa;
            drFiltro.EnderecoEmpresa = string.IsNullOrEmpty(objFechamento.EnderecoEmpresa) ? string.Empty : objFechamento.EnderecoEmpresa;

            this.Filtro.Rows.Add(drFiltro);

            if (objFechamento.objTickets != null)
            {
                TicketRow drItenVenda = null;

                foreach (Comum.Clases.Relatorios.Ticket objTicket in objFechamento.objTickets)
                {
                    drItenVenda = this.Ticket.NewTicketRow();

                    drItenVenda.Codigo = objTicket.CodigoProduto;
                    drItenVenda.Sequencia = objTicket.Sequencia;
                    drItenVenda.Descricao = objTicket.DescricaoProduto;
                    drItenVenda.Quantidade = objTicket.Quantidade;
                    drItenVenda.ValorUnitario = objTicket.ValorUnitario;
                    drItenVenda.SubTotal = objTicket.SubTotal;
                    this.Ticket.Rows.Add(drItenVenda);
                }
            }

        }
    }
}
