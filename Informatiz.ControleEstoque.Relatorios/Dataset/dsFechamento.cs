using System.Collections.Generic;

namespace Informatiz.ControleEstoque.Relatorios.DataSet
{


    partial class dsFechamento
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
                drParametros.SUPERVISOR = objFechamentoCaixa.NomeSupervisor;


                this.PARAMETROS.Rows.Add(drParametros);

                if (objFechamentoCaixa.Fechamentos != null && objFechamentoCaixa.Fechamentos.Count > 0)
                {
                    foreach (var v in objFechamentoCaixa.Fechamentos)
                    {

                        PAGAMENTORow drPagamento = null;

                        drPagamento = this.PAGAMENTO.NewPAGAMENTORow();
                        drPagamento.FORMAPAGAMENTO = v.DescricaoFormaPagamento;
                        drPagamento.VALORRECEBIDO = v.ValorRecebido;
                        drPagamento.VALORINFORMADO = v.ValorFechamento;
                        drPagamento.DIFERENCA = v.ValorDiferenca;

                        this.PAGAMENTO.Rows.Add(drPagamento);

                    }
                }


            }

        }

    }
}
