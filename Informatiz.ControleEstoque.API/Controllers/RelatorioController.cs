using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Relatorio")]
    public class RelatorioController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarFechamentoCaixa")]
        [Classes.ValidateModel]
        public ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa RecuperarFechamentoCaixa(ContratoServico.Relatorios.RecuperarFechamentoCaixa.PeticaoRecuperarFechamentoCaixa objEntrada)
        {

            ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa objSaida = new ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                objSaida.DadosRelatorio = (from INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA
                                           join INFM_CAIXA c in objBD.INFM_CAIXA on rc.IDCAIXA equals c.IDCAIXA
                                           join INFM_PESSOA p in objBD.INFM_PESSOA on rc.IDPESSOARESPONSAVEL equals p.IDPESSOA
                                           where rc.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                           select new Comum.Clases.Relatorios.FechamentoCaixaGeral.DadosRelatorio()
                                           {
                                               FuncionarioCaixa = p.DESNOME,
                                               NumeroCaixa = c.CODCAIXA,
                                               SaldoInicialCaixa = rc.NUMVALORINICIAL
                                           }).FirstOrDefault();

                objSaida.PessoasEnviarEmail = (from INFM_PESSOA p in objBD.INFM_PESSOA
                                               join INFM_TIPOEMPREGADO te in objBD.INFM_TIPOEMPREGADO on p.IDTIPOEMPREGADO equals te.IDTIPOEMPREGADO
                                               join INFM_FILIALPESSOA fp in objBD.INFM_FILIALPESSOA on p.IDPESSOA equals fp.IDPESSOA
                                               join INFM_FILIAL f in objBD.INFM_FILIAL on fp.IDFILIAL equals f.IDFILIAL
                                               where te.BOLENVIAREMAILFECHAMENTO == true && te.IDEMPRESA == objEntrada.IdentificadorEmpresa &&
                                               f.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                               select new Comum.Clases.Pessoa()
                                               {
                                                   Identificador = p.IDPESSOA,
                                                   DesEmail = p.DESEMAIL,
                                                   DesNome = p.DESNOME,
                                                   Codigo = p.CODPESSOA
                                               }).ToList();

                if (objSaida.DadosRelatorio != null)
                {

                    objSaida.DetalhesVenda = (from INFM_VENDA v in objBD.INFM_VENDA
                                              join INFM_ITEMVENDA iv in objBD.INFM_ITEMVENDA on v.IDVENDA equals iv.IDVENDA
                                              join INFM_PRODUTOSERVICO ps in objBD.INFM_PRODUTOSERVICO on iv.IDPRODUTOSERVICO equals ps.IDPRODUTOSERVICO
                                              join INFM_VALORFECHAMENTO vf in objBD.INFM_VALORFECHAMENTO on v.IDRESPONSAVELCAIXA equals vf.IDRESPONSAVELCAIXA
                                              join INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO on vf.IDFORMAPAGAMENTO equals fp.IDFORMAPAGAMENTO
                                              where v.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                              select new Comum.Clases.Relatorios.FechamentoCaixaGeral.DetalheVenda()
                                              {
                                                  CodigoComanda = v.CODCOMANDA,
                                                  IdentificadorVenda = v.IDVENDA,
                                                  CodigoVenda = v.CODVENDA.ToString(),
                                                  DescricaoProduto = ps.DESPRODUTO,
                                                  Quantidade = iv.NUMQUANTIDADE,
                                                  Sequencia = iv.NUMSEQUENCIA,
                                                  ValorAcrescimo = iv.NUMVALORACRESCIMO,
                                                  ValorDesconto = iv.NUMVALORDESCONTO,
                                                  ValorItem = iv.NUMVALORITEM,
                                                  ValorTotal = iv.NUMVALORTOTAL,
                                                  CodigoSupervisor = (from INFM_PESSOA p in objBD.INFM_PESSOA
                                                                      where p.IDPESSOA == vf.IDPESSOASUPERVISOR
                                                                      select p.CODPESSOA + " - " + p.DESNOME).FirstOrDefault(),
                                                  ValorDiferenca = vf.NUMVALORDIFERENCA,
                                                  ValorRecebido = vf.NUMVALOR,
                                                  ValorTotalVendas = (from INFM_PAGAMENTO p in objBD.INFM_PAGAMENTO
                                                                      where p.IDVENDA == v.IDVENDA && p.IDFORMAPAGAMENTO == fp.IDFORMAPAGAMENTO
                                                                      select p.NUMVALOR).Sum(),
                                                  CodigoFormaPagamento = fp.CODFORMAPAGAMENTO,
                                                  DescricaoFormaPagamento = fp.DESFORMAPAGAMENTO,
                                                  IdentificadorFormaPagamento = fp.IDFORMAPAGAMENTO
                                              }).ToList();

                    if (objSaida.DetalhesVenda != null && objSaida.DetalhesVenda.Count > 0)
                    {
                        List<Comum.Clases.ClassesAuxiliares.ChaveCodigo> objMesas = (from Comum.Clases.Relatorios.FechamentoCaixaGeral.DetalheVenda dv in objSaida.DetalhesVenda
                                                                                     join INFM_MESAVENDA mv in objBD.INFM_MESAVENDA on dv.IdentificadorVenda equals mv.IDVENDA
                                                                                     join INFM_MESA m in objBD.INFM_MESA on mv.IDMESA equals m.IDMESA
                                                                                     select new Comum.Clases.ClassesAuxiliares.ChaveCodigo()
                                                                                     {
                                                                                         Chave = mv.IDVENDA,
                                                                                         Codigo = m.CODMESA
                                                                                     }).ToList();

                        if (objMesas != null && objMesas.Count > 0)
                        {
                            foreach (var m in objSaida.DetalhesVenda)
                            {

                                List<Comum.Clases.ClassesAuxiliares.ChaveCodigo> objMesasCorrentes = (from Comum.Clases.ClassesAuxiliares.ChaveCodigo cc in objMesas
                                                                                                      where cc.Chave == m.IdentificadorVenda
                                                                                                      select cc).ToList();

                                if (objMesasCorrentes != null && objMesasCorrentes.Count > 0)
                                {
                                    m.CodigoMesa = string.Join(",", objMesasCorrentes.Select(mc => mc.Codigo).ToArray());
                                }
                            }
                        }
                    }

                    if (objSaida.DetalhesVenda != null && objSaida.DetalhesVenda.Count > 0)
                    {
                        objSaida.PagamentosTotaisPorVenda = (from ptv in objSaida.DetalhesVenda
                                                             select new Comum.Clases.Relatorios.FechamentoCaixaGeral.PagamentoTotalPorVenda()
                                                             {
                                                                 CodigoComanda = ptv.CodigoComanda,
                                                                 IdentificadorVenda = ptv.IdentificadorVenda,
                                                                 CodigoVenda = ptv.CodigoVenda,
                                                                 CodigoMesa = ptv.CodigoMesa,
                                                                 CodigoSupervisor = ptv.CodigoSupervisor,
                                                                 ValorDiferenca = ptv.ValorDiferenca,
                                                                 ValorRecebido = ptv.ValorRecebido,
                                                                 ValorTotalVendas = ptv.ValorTotalVendas,
                                                                 CodigoFormaPagamento = ptv.CodigoFormaPagamento,
                                                                 DescricaoFormaPagamento = ptv.DescricaoFormaPagamento,
                                                                 IdentificadorFormaPagamento = ptv.IdentificadorFormaPagamento,
                                                                 IdentificadorAgrupamento = string.Format("{0}{1}", ptv.CodigoVenda, ptv.CodigoFormaPagamento)
                                                             }).ToList();
                    }

                    objSaida.PagamentosTotais = (from INFM_VENDA v in objBD.INFM_VENDA
                                                 join INFM_VALORFECHAMENTO vf in objBD.INFM_VALORFECHAMENTO on v.IDRESPONSAVELCAIXA equals vf.IDRESPONSAVELCAIXA
                                                 join INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO on vf.IDFORMAPAGAMENTO equals fp.IDFORMAPAGAMENTO
                                                 where v.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                                 select new Comum.Clases.Relatorios.FechamentoCaixaGeral.PagamentosTotais()
                                                 {
                                                     ValorDiferenca = vf.NUMVALORDIFERENCA,
                                                     ValorRecebido = vf.NUMVALOR,
                                                     ValorTotalVendas = (from INFM_PAGAMENTO p in objBD.INFM_PAGAMENTO
                                                                         where p.IDVENDA == v.IDVENDA && p.IDFORMAPAGAMENTO == fp.IDFORMAPAGAMENTO
                                                                         select p.NUMVALOR).Sum(),
                                                     CodigoFormaPagamento = fp.CODFORMAPAGAMENTO,
                                                     DescricaoFormaPagamento = fp.DESFORMAPAGAMENTO,
                                                     IdentificadorFormaPagamento = fp.IDFORMAPAGAMENTO
                                                 }).ToList();

                    objSaida.Sangrias = (from INFM_SANGRIA s in objBD.INFM_SANGRIA
                                         join INFM_PESSOA p in objBD.INFM_PESSOA on s.IDPESSOASUPERVISOR equals p.IDPESSOA
                                         where s.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                         select new Comum.Clases.Sangria()
                                         {
                                             Identificador = s.IDSANGRIA,
                                             Observacao = s.OBSSANGRIA,
                                             IdentificadorSupervisor = p.IDPESSOA,
                                             NomeSupervisor = p.DESNOME,
                                             Valor = s.NUMVALORSANGRIA
                                         }).ToList();

                    objSaida.Suprimentos = (from INFM_SUPRIMENTO s in objBD.INFM_SUPRIMENTO
                                            join INFM_PESSOA p in objBD.INFM_PESSOA on s.IDPESSOASUPERVISOR equals p.IDPESSOA
                                            where s.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                            select new Comum.Clases.Suprimento()
                                            {
                                                Identificador = s.IDSUPRIMENTO,
                                                Observacao = s.OBSSUPRIMENTO,
                                                IdentificadorSupervisor = p.IDPESSOA,
                                                NomeSupervisor = p.DESNOME,
                                                Valor = s.NUMVALORSUPRIMENTO
                                            }).ToList();

                }



                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
            }
            return objSaida;
        }

    }
}
