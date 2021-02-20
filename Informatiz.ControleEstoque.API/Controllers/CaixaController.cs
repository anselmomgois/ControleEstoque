using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.Execao;
using Informatiz.ControleEstoque.API.Entity;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Caixa")]
    public class CaixaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("SetCaixa")]
        [Classes.ValidateModel]
        public ContratoServico.Caixa.SetCaixa.RespostaSetCaixa SetCaixao(ContratoServico.Caixa.SetCaixa.PeticaoSetCaixa objEntrada)
        {

            ContratoServico.Caixa.SetCaixa.RespostaSetCaixa objSaida = new ContratoServico.Caixa.SetCaixa.RespostaSetCaixa();

            INFM_CAIXA objCaixa = null;

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();
                objCaixa = (from INFM_CAIXA cx in objBD.INFM_CAIXA
                            where cx.IDCAIXA == objEntrada.Caixa.Identificador
                            select cx).FirstOrDefault();

                if (objCaixa != null)
                {
                    objCaixa.CODCAIXA = objEntrada.Caixa.Codigo;
                    objCaixa.BOLABERTO = objEntrada.Caixa.EstaAberto;
                    objCaixa.DESHOST = objEntrada.Caixa.HostName;
                }
                else
                {
                    objCaixa = new INFM_CAIXA()
                    {
                        BOLABERTO = objEntrada.Caixa.EstaAberto,
                        IDEMPRESA = objEntrada.IdentificadorEmpresa,
                        CODCAIXA = objEntrada.Caixa.Codigo,
                        DESHOST = objEntrada.Caixa.HostName,
                        IDFILIAL = objEntrada.IdentificadorFilial,
                        IDCAIXA = Guid.NewGuid().ToString()
                    };
                    objBD.INFM_CAIXA.Add(objCaixa);
                }

                objBD.SaveChanges();
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("AK_INFM_CAIXA1"))
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                    objSaida.DescricaoErro = "Já existe um caixa registrada com o código: '" + objCaixa.CODCAIXA.ToString() + "'";
                }
                else if (ex.ToString().Contains("AK_INFM_CAIXA2"))
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                    objSaida.DescricaoErro = "Já existe um caixa registrado para o Host: '" + objCaixa.DESHOST + "'";
                }
                else
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                    objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
                }
            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("BuscarCaixaDetalhe")]
        [Classes.ValidateModel]
        public ContratoServico.Caixa.BuscarCaixaDetalhe.RespostaBuscarCaixaDetalhe BuscarCaixaDetalhe(ContratoServico.Caixa.BuscarCaixaDetalhe.PeticaoBuscarCaixaDetalhe objEntrada)
        {

            ContratoServico.Caixa.BuscarCaixaDetalhe.RespostaBuscarCaixaDetalhe objSaida = new ContratoServico.Caixa.BuscarCaixaDetalhe.RespostaBuscarCaixaDetalhe();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();


                objSaida.Caixa = (from INFM_CAIXA cx in objBD.INFM_CAIXA
                                  where cx.IDCAIXA == objEntrada.IdentificadorCaixa
                                  select new Comum.Clases.Caixa()
                                  {
                                      Codigo = cx.CODCAIXA,
                                      Identificador = cx.IDCAIXA,
                                      EstaAberto = cx.BOLABERTO,
                                      HostName = cx.DESHOST,
                                  }).FirstOrDefault();


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

        [AcceptVerbs("POST")]
        [Route("BuscarCaixa")]
        [Classes.ValidateModel]
        public ContratoServico.Caixa.BuscarCaixa.RespostaBuscarCaixa BuscarCaixa(ContratoServico.Caixa.BuscarCaixa.PeticaoBuscarCaixa objEntrada)
        {

            ContratoServico.Caixa.BuscarCaixa.RespostaBuscarCaixa objSaida = new ContratoServico.Caixa.BuscarCaixa.RespostaBuscarCaixa();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (objEntrada.Codigo.HasValue && objEntrada.Codigo > 0)
                {
                    objSaida.Caixas = (from INFM_CAIXA cx in objBD.INFM_CAIXA
                                       where cx.CODCAIXA == objEntrada.Codigo &&
                                       (!string.IsNullOrEmpty(objEntrada.IdentificadorFilial) && cx.IDFILIAL == objEntrada.IdentificadorFilial && cx.IDEMPRESA == objEntrada.IdentificadorEmpresa)
                                       select new Comum.Clases.Caixa()
                                       {
                                           Identificador = cx.IDCAIXA,
                                           Codigo = cx.CODCAIXA,
                                           EstaAberto = cx.BOLABERTO,
                                           HostName = cx.DESHOST
                                       }).ToList();

                }
                else
                {
                    {
                        objSaida.Caixas = (from INFM_CAIXA cx in objBD.INFM_CAIXA
                                           where (!string.IsNullOrEmpty(objEntrada.IdentificadorFilial) && cx.IDFILIAL == objEntrada.IdentificadorFilial && cx.IDEMPRESA == objEntrada.IdentificadorEmpresa)
                                           select new Comum.Clases.Caixa()
                                           {
                                               Identificador = cx.IDCAIXA,
                                               Codigo = cx.CODCAIXA,
                                               EstaAberto = cx.BOLABERTO,
                                               HostName = cx.DESHOST
                                           }).ToList();

                    }
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

        [AcceptVerbs("POST")]
        [Route("BuscarCaixaByHost")]
        [Classes.ValidateModel]
        public ContratoServico.Caixa.BuscarCaixaByHost.RespostaBuscarCaixaByHost BuscarCaixaByHost(ContratoServico.Caixa.BuscarCaixaByHost.PeticaoBuscarCaixaByHost objEntrada)
        {

            ContratoServico.Caixa.BuscarCaixaByHost.RespostaBuscarCaixaByHost objSaida = new ContratoServico.Caixa.BuscarCaixaByHost.RespostaBuscarCaixaByHost();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.HostName))
                {
                    objSaida.Caixa = (from INFM_CAIXA cx in objBD.INFM_CAIXA
                                      where cx.DESHOST == objEntrada.HostName &&
                                      cx.IDFILIAL == objEntrada.IdentificadorFilial && cx.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                      select new Comum.Clases.Caixa()
                                      {
                                          Identificador = cx.IDCAIXA,
                                          Codigo = cx.CODCAIXA,
                                          EstaAberto = cx.BOLABERTO,
                                          HostName = cx.DESHOST,
                                          OperacaoCaixa = (from INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA
                                                           join INFM_PESSOA f in objBD.INFM_PESSOA on rc.IDPESSOARESPONSAVEL equals f.IDPESSOA
                                                           where rc.IDCAIXA == cx.IDCAIXA && rc.DTHFIMOPERACAO == null
                                                           select new Comum.Clases.OperacaoCaixa()
                                                           {
                                                               Identificador = rc.IDRESPONSAVELCAIXA,
                                                               DataInicioOperacao = rc.DTHINICIOOPERACAO,
                                                               DataFimOperacao = rc.DTHFIMOPERACAO,
                                                               FuncionarioCaixa = new Comum.Clases.Pessoa()
                                                               {
                                                                   Identificador = rc.IDPESSOARESPONSAVEL,
                                                                   DesNome = f.DESNOME
                                                               },
                                                               Saldo = rc.NUMSALDO,
                                                               ValorAbertura = rc.NUMVALORINICIAL
                                                           }).FirstOrDefault()
                                      }).FirstOrDefault();

                    if (objSaida.Caixa != null && objSaida.Caixa.EstaAberto && objSaida.Caixa.OperacaoCaixa == null)
                    {
                        objSaida.Caixa.EstaAberto = false;
                    }

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

        [AcceptVerbs("POST")]
        [Route("ExcluirSetCaixa")]
        [Classes.ValidateModel]
        public ContratoServico.Caixa.ExcluirSetCaixa.RespostaExcluirSetCaixa ExcluirSetCaixa(ContratoServico.Caixa.ExcluirSetCaixa.PeticaoExcluirSetCaixa objEntrada)
        {

            ContratoServico.Caixa.ExcluirSetCaixa.RespostaExcluirSetCaixa objSaida = new ContratoServico.Caixa.ExcluirSetCaixa.RespostaExcluirSetCaixa();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                INFM_CAIXA objCaixa = (from INFM_CAIXA fp in objBD.INFM_CAIXA
                                       where fp.IDCAIXA == objEntrada.IdentificadorCaixa
                                       select fp).FirstOrDefault();

                objBD.INFM_CAIXA.Remove(objCaixa);

                objBD.SaveChanges();
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

        [AcceptVerbs("POST")]
        [Route("SetAberturaCaixa")]
        [Classes.ValidateModel]
        public ContratoServico.Caixa.SetAberturaCaixa.RespostaSetAberturaCaixa SetAberturaCaixa(ContratoServico.Caixa.SetAberturaCaixa.PeticaoSetAberturaCaixa objEntrada)
        {

            ContratoServico.Caixa.SetAberturaCaixa.RespostaSetAberturaCaixa objSaida = new ContratoServico.Caixa.SetAberturaCaixa.RespostaSetAberturaCaixa();

            INFM_RESPONSAVELCAIXA objResponsavelCaixa = null;
            INFM_CAIXA objCaixa = null;

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();
                string IdentificadorResponsavelCaixa = string.Empty;

                if (objEntrada.Fechado)
                {
                    objResponsavelCaixa = (from INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA
                                           where rc.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                           select rc).FirstOrDefault();

                    if (objResponsavelCaixa != null)
                    {
                        objResponsavelCaixa.DTHFIMOPERACAO = objEntrada.FimOperacao;
                    }

                }
                else
                {
                    IdentificadorResponsavelCaixa = Guid.NewGuid().ToString();

                    objResponsavelCaixa = new INFM_RESPONSAVELCAIXA()
                    {
                        IDRESPONSAVELCAIXA = IdentificadorResponsavelCaixa,
                        IDCAIXA = objEntrada.IdentificadorCaixa,
                        IDPESSOARESPONSAVEL = objEntrada.IdentificadorResponsavel,
                        NUMVALORINICIAL = objEntrada.ValorInicial,
                        NUMSALDO = objEntrada.ValorSaldo,
                        DTHINICIOOPERACAO = objEntrada.InicioOperacao
                    };
                    objBD.INFM_RESPONSAVELCAIXA.Add(objResponsavelCaixa);
                }

                objCaixa = (from INFM_CAIXA cx in objBD.INFM_CAIXA
                            where cx.IDCAIXA == objEntrada.IdentificadorCaixa
                            select cx).FirstOrDefault();
                if (objCaixa != null)
                {
                    objCaixa.BOLABERTO = !objEntrada.Fechado;                    
                }

                objBD.SaveChanges();
                objSaida.IdentificadorResponsavelCaixa = IdentificadorResponsavelCaixa;
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

        [AcceptVerbs("POST")]
        [Route("FecharCaixa")]
        [Classes.ValidateModel]
        public ContratoServico.Caixa.FecharCaixa.RespostaFecharCaixa FecharCaixa(ContratoServico.Caixa.FecharCaixa.PeticaoFecharCaixa objEntrada)
        {

            ContratoServico.Caixa.FecharCaixa.RespostaFecharCaixa objSaida = new ContratoServico.Caixa.FecharCaixa.RespostaFecharCaixa();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

               if(!string.IsNullOrEmpty(objEntrada.IdentificadorResponsavelCaixa) && !string.IsNullOrEmpty(objEntrada.IdentificadorCaixa) &&
                    objEntrada.PagamentosEfetuados != null && objEntrada.PagamentosEfetuados.Count > 0)
                {
                    foreach(var pe in objEntrada.PagamentosEfetuados)
                    {

                        objBD.INFM_VALORFECHAMENTO.Add(new INFM_VALORFECHAMENTO()
                        {
                            IDFORMAPAGAMENTO = pe.IdentificadorFormaPagamento,
                            IDPESSOASUPERVISOR = objEntrada.IdentificadorSupervisor,
                            IDRESPONSAVELCAIXA = objEntrada.IdentificadorResponsavelCaixa,
                            IDVALORFECHAMENTO = Guid.NewGuid().ToString(),
                            NUMVALOR = pe.ValorFechamento,
                            NUMVALORDIFERENCA = pe.ValorFechamento
                        });
                    }

                    INFM_RESPONSAVELCAIXA objResponsavelCaixa = (from INFM_RESPONSAVELCAIXA rc in objBD.INFM_RESPONSAVELCAIXA
                                                                 where rc.IDRESPONSAVELCAIXA == objEntrada.IdentificadorResponsavelCaixa
                                                                 select rc).FirstOrDefault();

                    if(objResponsavelCaixa != null)
                    {
                        objResponsavelCaixa.DTHFIMOPERACAO = DateTime.Now;

                        INFM_CAIXA objCaixa = (from INFM_CAIXA c in objBD.INFM_CAIXA
                                               where c.IDCAIXA == objEntrada.IdentificadorCaixa && c.IDFILIAL == objEntrada.IdentificadorFilial
                                               select c).FirstOrDefault();

                        if(objCaixa != null)
                        {
                            objCaixa.BOLABERTO = false;

                            string IdentificadorItemProcesso = string.Empty;

                            ProcessoController.GerarItemProcesso(new ContratoServico.Processo.RegistrarItemProcesso.PeticaoRegistrarItemProcesso()
                            {
                                IdentificadorEmpresa = objEntrada.IdentificadorEmpresa,
                                Usuario = objEntrada.Usuario,
                                ItemProcesso = new Comum.Clases.ItemProcesso()
                                {
                                    DataExecucaoProgramada = DateTime.Now,
                                    Tipo = Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA,
                                    Valor = objEntrada.IdentificadorResponsavelCaixa
                                }
                            }, ref IdentificadorItemProcesso, ref objBD);
                        }
                    }
                    
                }
            

                objBD.SaveChanges();
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);
                objSaida.PagamentosEfetuados = objEntrada.PagamentosEfetuados;

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
