using System.Collections.Generic;

namespace Informatiz.ControleEstoque.Relatorios.DataSet
{

    public partial class dsVendas
    {

        public void PopularDataSet(object objDados)
        {

            Comum.Clases.Relatorios.FechamentoCaixa.FechamentoCaixa objFechamentoCaixa = null;

            if (objDados != null)
            {
                objFechamentoCaixa = (Comum.Clases.Relatorios.FechamentoCaixa.FechamentoCaixa)objDados;

                PARAMETROSRow drParametros = this.PARAMETROS.NewPARAMETROSRow();

                drParametros.FUNCIONARIOCAIXA = objFechamentoCaixa.NomeFuncionario;
                drParametros.NOMEEMPRESA = objFechamentoCaixa.Empresa;
                drParametros.NUMEROCAIXA = objFechamentoCaixa.NumeroCaixa;
                drParametros.ENDERECO = objFechamentoCaixa.Endereco;
                drParametros.SALDOINICIAL = objFechamentoCaixa.SaldoInicialCaixa;
                drParametros.SANGRIA = objFechamentoCaixa.ValorTotalSangria;
                drParametros.SUPRIMENTO = objFechamentoCaixa.ValorTotalSuprimento;
                

                this.PARAMETROS.Rows.Add(drParametros);

                if (objFechamentoCaixa.Vendas != null && objFechamentoCaixa.Vendas.Count > 0)
                {
                    VENDARow drVenda = null;

                    foreach (var v in objFechamentoCaixa.Vendas)
                    {

                        drVenda = this.VENDA.NewVENDARow();

                        drVenda.CODVENDA = v.CodigoVenda;
                        drVenda.IDVENDA = v.Identificador;

                        this.VENDA.Rows.Add(drVenda);

                        if (v.Pagamentos != null && v.Pagamentos.Count > 0)
                        {
                            PAGAMENTORow drPagamento = null;

                            foreach (var p in v.Pagamentos)
                            {
                                drPagamento = this.PAGAMENTO.NewPAGAMENTORow();
                                drPagamento.FORMAPAGAMENTO = p.FormaPagamento.Descricao;
                                drPagamento.VALOR = p.Valor;
                                drPagamento.IDVENDA = v.Identificador;
                                drPagamento.CODVENDA = v.CodigoVenda;

                                this.PAGAMENTO.Rows.Add(drPagamento);
                            }
                        }

                    }
                }


            }

        }
    }
}
