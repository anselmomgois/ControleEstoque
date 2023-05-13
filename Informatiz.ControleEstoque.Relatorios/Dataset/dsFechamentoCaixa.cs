using System.Linq;

namespace Informatiz.ControleEstoque.Relatorios.DataSet
{
    public partial class dsFechamentoCaixa
    {

        public void PopularDataSet(object objDados)
        {

            ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa objFechamentoCaixa = null;

            if (objDados != null)
            {
                objFechamentoCaixa = (ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa)objDados;

                PARAMETROSRow drParametros = this.PARAMETROS.NewPARAMETROSRow();

                drParametros.FUNCIONARIOCAIXA = objFechamentoCaixa.DadosRelatorio.FuncionarioCaixa;
                drParametros.NOMEEMPRESA = objFechamentoCaixa.DadosRelatorio.NomeEmpresa;
                drParametros.NUMEROCAIXA = objFechamentoCaixa.DadosRelatorio.NumeroCaixa;
                drParametros.SALDOINICIAL = objFechamentoCaixa.DadosRelatorio.SaldoInicialCaixa;


                this.PARAMETROS.Rows.Add(drParametros);


                if (objFechamentoCaixa.PagamentosTotais != null && objFechamentoCaixa.PagamentosTotais.Count > 0)
                {
                    foreach (var v in objFechamentoCaixa.PagamentosTotais)
                    {

                        PAGAMENTORow drPagamento = null;

                        drPagamento = this.PAGAMENTO.NewPAGAMENTORow();
                        drPagamento.DIFERENCA = v.ValorDiferenca != null ? (decimal)v.ValorDiferenca : 0;
                        drPagamento.FORMAPAGAMENTO = v.DescricaoFormaPagamento;
                        drPagamento.VALORRECEBIDO = v.ValorRecebido != null ? (decimal)v.ValorRecebido : 0;
                        drPagamento.VALORTOTALVENDAS = v.ValorTotalVendas != null ? (decimal)v.ValorTotalVendas : 0;

                        this.PAGAMENTO.Rows.Add(drPagamento);

                    }
                }

                if (objFechamentoCaixa.PagamentosTotaisPorVenda != null && objFechamentoCaixa.PagamentosTotaisPorVenda.Count > 0)
                {


                    //(from Comum.Clases.FechamentoCaixa p in _PagamentosEfetuados
                    // group p by p.IdentificadorFormaPagamento into Soma
                    // select new Comum.Clases.FechamentoCaixa()
                    // {
                    //     ValorFechamento = Soma.Sum(su => su.ValorFechamento),
                    //     ValorDiferenca = Soma.Sum(su => su.ValorFechamento),
                    //     IdentificadorFormaPagamento = Soma.First().IdentificadorFormaPagamento,
                    //     DescricaoFormaPagamento = Soma.First().DescricaoFormaPagamento
                    // }).ToList();

                    foreach (var v in (from pv in objFechamentoCaixa.PagamentosTotaisPorVenda
                                       group pv by pv.IdentificadorAgrupamento into soma
                                       select new Comum.Clases.Relatorios.FechamentoCaixaGeral.PagamentoTotalPorVenda()
                                       {
                                           CodigoSupervisor = soma.First().CodigoSupervisor,
                                           CodigoComanda = soma.First().CodigoComanda,
                                           CodigoFormaPagamento = soma.First().CodigoFormaPagamento,
                                           CodigoMesa = soma.First().CodigoMesa,
                                           CodigoVenda = soma.First().CodigoVenda,
                                           DescricaoFormaPagamento = soma.First().DescricaoFormaPagamento,
                                           IdentificadorAgrupamento = soma.First().IdentificadorAgrupamento,
                                           IdentificadorFormaPagamento = soma.First().IdentificadorFormaPagamento,
                                           IdentificadorVenda = soma.First().IdentificadorVenda,
                                           ValorDiferenca = soma.Sum(su => su.ValorDiferenca),
                                           ValorRecebido = soma.Sum(su => su.ValorRecebido),
                                           ValorTotalVendas = soma.Sum(su => su.ValorTotalVendas)
                                       }))
                    {

                        PAGAMENTOTOTAISVENDARow drPagamento = null;

                        drPagamento = this.PAGAMENTOTOTAISVENDA.NewPAGAMENTOTOTAISVENDARow();
                        drPagamento.DIFERENCA = v.ValorDiferenca != null ? (decimal)v.ValorDiferenca : 0;
                        drPagamento.FORMAPAGAMENTO = v.DescricaoFormaPagamento;
                        drPagamento.VALORRECEBIDO = v.ValorRecebido != null ? (decimal)v.ValorRecebido : 0;
                        drPagamento.VALORTOTALVENDA = v.ValorTotalVendas != null ? (decimal)v.ValorTotalVendas : 0;
                        drPagamento.CODIGOCOMANDA = v.CodigoComanda;
                        drPagamento.CODIGOMESA = v.CodigoMesa;
                        drPagamento.CODIGOVENDA = v.CodigoVenda;
                        drPagamento.SUPERVISOR = v.CodigoSupervisor;
                        drPagamento.IDAGRUPAMENTO = string.Format("{0}{1}", v.CodigoFormaPagamento, string.IsNullOrEmpty(v.CodigoVenda) ? "1" : v.CodigoVenda);

                        this.PAGAMENTOTOTAISVENDA.Rows.Add(drPagamento);

                    }
                }

                if (objFechamentoCaixa.DetalhesVenda != null && objFechamentoCaixa.DetalhesVenda.Count > 0)
                {


                    foreach (var v in objFechamentoCaixa.DetalhesVenda)
                    {

                        VENDADETALHERow drDetalhe = null;

                        drDetalhe = this.VENDADETALHE.NewVENDADETALHERow();
                        drDetalhe.DIFERENCA = v.ValorDiferenca != null ? (decimal)v.ValorDiferenca : 0;
                        drDetalhe.FORMAPAGAMENTO = v.DescricaoFormaPagamento;
                        drDetalhe.VALORRECEBIDO = v.ValorRecebido != null ? (decimal)v.ValorRecebido : 0;
                        drDetalhe.VALORTOTALVENDA = v.ValorTotalVendas != null ? (decimal)v.ValorTotalVendas : 0;
                        drDetalhe.CODIGOCOMANDA = v.CodigoComanda;
                        drDetalhe.CODIGOMESA = v.CodigoMesa;
                        drDetalhe.CODIGOVENDA = v.CodigoVenda;
                        drDetalhe.SUPERVISOR = v.CodigoSupervisor;
                        drDetalhe.PRODUTO = v.DescricaoProduto;
                        drDetalhe.QUANTIDADE = v.Quantidade != null ? (decimal)v.Quantidade : 0;
                        drDetalhe.SEQUENCIA = v.Sequencia != null ? (int)v.Sequencia : 0;
                        drDetalhe.VALORACRESCIMO = v.ValorAcrescimo != null ? (decimal)v.ValorAcrescimo : 0;
                        drDetalhe.VALORDESCONTO = v.ValorDesconto != null ? (decimal)v.ValorDesconto : 0;
                        drDetalhe.VALORITEM = v.ValorItem;
                        drDetalhe.VALORTOTAL = v.ValorTotal;
                        drDetalhe.IDAGRUPAMENTO = string.Format("{0}{1}", v.CodigoFormaPagamento, v.CodigoVenda);
                        this.VENDADETALHE.Rows.Add(drDetalhe);

                    }
                }

                if (objFechamentoCaixa.Sangrias != null && objFechamentoCaixa.Sangrias.Count > 0)
                {
                    foreach (var v in objFechamentoCaixa.Sangrias)
                    {

                        SANGRIARow drSangria = null;

                        drSangria = this.SANGRIA.NewSANGRIARow();
                        drSangria.NOMESUPERVISOR = v.NomeSupervisor;
                        drSangria.VALOR = v.Valor;
                        drSangria.OBSERVACAOSANGRIA = v.Observacao;

                        this.SANGRIA.Rows.Add(drSangria);

                    }
                }

                if (objFechamentoCaixa.Suprimentos != null && objFechamentoCaixa.Suprimentos.Count > 0)
                {
                    foreach (var v in objFechamentoCaixa.Suprimentos)
                    {

                        SUPRIMENTORow drSuprimento = null;

                        drSuprimento = this.SUPRIMENTO.NewSUPRIMENTORow();
                        drSuprimento.NOMESUPERVISOR = v.NomeSupervisor;
                        drSuprimento.VALOR = v.Valor;
                        drSuprimento.OBSERVACAOSUPRIMENTO = v.Observacao;

                        this.SUPRIMENTO.Rows.Add(drSuprimento);

                    }
                }


            }

        }
    }
}
