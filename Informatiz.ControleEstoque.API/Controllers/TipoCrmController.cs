using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Execao;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/TipoCrm")]
    public class TipoCrmController : ApiController
    {


        [AcceptVerbs("POST")]
        [Route("SetTipoCrm")]
        [Classes.ValidateModel]
        public ContratoServico.TipoCrm.SetTipoCrm.RespostaSetTipoCrm SetTipoCrm(ContratoServico.TipoCrm.SetTipoCrm.PeticaoSetTipoCrm objEntrada)
        {

            ContratoServico.TipoCrm.SetTipoCrm.RespostaSetTipoCrm objSaida = new ContratoServico.TipoCrm.SetTipoCrm.RespostaSetTipoCrm();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();
                INFM_TIPOCRM objTipoCrm = null;

                if (string.IsNullOrEmpty(objEntrada.TipoCrm.Identificador))
                {
                    objTipoCrm = new INFM_TIPOCRM();
                    objTipoCrm.IDEMPRESA = objEntrada.IdentificadorEmpresa;
                    objTipoCrm.IDTIPOCRM = Guid.NewGuid().ToString();
                    objTipoCrm.DESTIPOCRM = objEntrada.TipoCrm.Descricao;
                    objTipoCrm.CODTIPOCRM = objEntrada.TipoCrm.Codigo;
                    objTipoCrm.IDSTATUSCRM = objEntrada.TipoCrm.IdentificadorStatusPadrao;
                    objTipoCrm.IDSTATUSCRMAGRUP = objEntrada.TipoCrm.IdentificadorStatusCrmAgrup;

                    if (objEntrada.TipoCrm.TiposCrmConfig != null && objEntrada.TipoCrm.TiposCrmConfig.Count > 0)
                    {
                        foreach (Comum.Clases.TipoCrmConfig tc in objEntrada.TipoCrm.TiposCrmConfig)
                        {
                            string IdentificadorTipoCrm = Guid.NewGuid().ToString();

                            INFM_TIPOCRMCONFIG objTipoCrmConfig = new INFM_TIPOCRMCONFIG()
                            {
                                BOLEMPREGADOATUAL = tc.EmpregadoAtual,
                                IDTIPOCRM = objTipoCrm.IDTIPOCRM,
                                IDTIPOCRMCONFIG = IdentificadorTipoCrm,
                                IDTIPOEMPREGADO = (tc.TipoEmpregado != null ? tc.TipoEmpregado.Identificador : null),
                                NELNIVEL = tc.Nivel,
                                DESNIVELCONFIG = tc.DescricaoNivel,
                                NELQUANTDIASDATA = tc.QuantidadeDiasData,
                                NELQUANTFUNCIONARIOS = tc.QuantidadeEmpregados
                            };

                            if (tc.Pessoas != null && tc.Pessoas.Count > 0)
                            {
                                foreach (Comum.Clases.Pessoa p in tc.Pessoas)
                                {
                                    objTipoCrmConfig.INFM_TIPOCRMCONFIGPESSOA.Add(new INFM_TIPOCRMCONFIGPESSOA()
                                    {
                                        IDPESSOA = p.Identificador,
                                        IDTIPOCRMCONFIG = objTipoCrmConfig.IDTIPOCRMCONFIG,
                                        IDTIPOCRMCONFIGPESSOA = Guid.NewGuid().ToString()
                                    });
                                }
                            }
                            objTipoCrm.INFM_TIPOCRMCONFIG.Add(objTipoCrmConfig);


                        }
                    }

                    objBD.INFM_TIPOCRM.Add(objTipoCrm);
                }
                else
                {
                    objTipoCrm = (from INFM_TIPOCRM tc in objBD.INFM_TIPOCRM where tc.IDTIPOCRM == objEntrada.TipoCrm.Identificador select tc).FirstOrDefault();

                    objTipoCrm.DESTIPOCRM = objEntrada.TipoCrm.Descricao;
                    objTipoCrm.CODTIPOCRM = objEntrada.TipoCrm.Codigo;
                    objTipoCrm.IDSTATUSCRM = objEntrada.TipoCrm.IdentificadorStatusPadrao;
                    objTipoCrm.IDSTATUSCRMAGRUP = objEntrada.TipoCrm.IdentificadorStatusCrmAgrup;

                    List<INFM_TIPOCRMCONFIG> objTiposCrmConfig = (from INFM_TIPOCRMCONFIG tcc in objBD.INFM_TIPOCRMCONFIG where tcc.IDTIPOCRM == objEntrada.TipoCrm.Identificador select tcc).ToList();
                    List<INFM_TIPOCRMCONFIGPESSOA> objTiposCrmPessoa = null;

                    if (objTiposCrmConfig != null && objTiposCrmConfig.Count > 0)
                    {
                        foreach (INFM_TIPOCRMCONFIG tcrmc in objTiposCrmConfig)
                        {

                            objTiposCrmPessoa = (from INFM_TIPOCRMCONFIGPESSOA tcp in objBD.INFM_TIPOCRMCONFIGPESSOA
                                                 where tcp.IDTIPOCRMCONFIG == tcrmc.IDTIPOCRMCONFIG
                                                 select tcp).ToList();


                            if (objTiposCrmPessoa != null && objTiposCrmPessoa.Count > 0)
                            {
                                objBD.INFM_TIPOCRMCONFIGPESSOA.RemoveRange(objTiposCrmPessoa);
                            }

                            objBD.INFM_TIPOCRMCONFIG.RemoveRange(objTiposCrmConfig);
                        }
                    }

                    if (objEntrada.TipoCrm.TiposCrmConfig != null && objEntrada.TipoCrm.TiposCrmConfig.Count > 0)
                    {
                        foreach (Comum.Clases.TipoCrmConfig tc in objEntrada.TipoCrm.TiposCrmConfig)
                        {
                            string IdentificadorTipoCrm = Guid.NewGuid().ToString();

                            INFM_TIPOCRMCONFIG objTipoCrmConfig = new INFM_TIPOCRMCONFIG()
                            {
                                BOLEMPREGADOATUAL = tc.EmpregadoAtual,
                                IDTIPOCRM = objTipoCrm.IDTIPOCRM,
                                IDTIPOCRMCONFIG = IdentificadorTipoCrm,
                                IDTIPOEMPREGADO = (tc.TipoEmpregado != null ? tc.TipoEmpregado.Identificador : null),
                                NELNIVEL = tc.Nivel,
                                DESNIVELCONFIG = tc.DescricaoNivel,
                                NELQUANTDIASDATA = tc.QuantidadeDiasData,
                                NELQUANTFUNCIONARIOS = tc.QuantidadeEmpregados
                            };

                            if (tc.Pessoas != null && tc.Pessoas.Count > 0)
                            {
                                foreach (Comum.Clases.Pessoa p in tc.Pessoas)
                                {
                                    objTipoCrmConfig.INFM_TIPOCRMCONFIGPESSOA.Add(new INFM_TIPOCRMCONFIGPESSOA()
                                    {
                                        IDPESSOA = p.Identificador,
                                        IDTIPOCRMCONFIG = objTipoCrmConfig.IDTIPOCRMCONFIG,
                                        IDTIPOCRMCONFIGPESSOA = Guid.NewGuid().ToString()
                                    });
                                }
                            }
                            objTipoCrm.INFM_TIPOCRMCONFIG.Add(objTipoCrmConfig);
                        }
                    }

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

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("PesquisarTipoCrm")]
        [Classes.ValidateModel]
        public ContratoServico.TipoCrm.PesquisarTipoCrm.RespostaPesquisarTipoCrm PesquisarTipoCrm(ContratoServico.TipoCrm.PesquisarTipoCrm.PeticaoPesquisarTipoCrm objEntrada)
        {

            ContratoServico.TipoCrm.PesquisarTipoCrm.RespostaPesquisarTipoCrm objSaida = new ContratoServico.TipoCrm.PesquisarTipoCrm.RespostaPesquisarTipoCrm();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.Descricao))
                {
                    

                    objSaida.TiposCrm = (from INFM_TIPOCRM sc in objBD.INFM_TIPOCRM
                                         where sc.DESTIPOCRM == objEntrada.Descricao && sc.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                         select new Comum.Clases.TipoCrm()
                                         {
                                             Descricao = sc.DESTIPOCRM,
                                             Codigo = sc.CODTIPOCRM,
                                             Identificador = sc.IDTIPOCRM,
                                             DescricaoStatusCrmAgrup = (from INFM_STATUSCRMAGRUP sag in objBD.INFM_STATUSCRMAGRUP
                                                                            where sag.IDSTATUSCRMAGRUP == sc.IDSTATUSCRMAGRUP
                                                                            select sag.DESSTATUSCRMAGRUP).FirstOrDefault(),
                                             DescricaoStatusPadrao = (from INFM_STATUS_CRM scrm in objBD.INFM_STATUS_CRM 
                                                                          where scrm.IDSTATUSCRM == sc.IDSTATUSCRM
                                                                          select scrm.DESSTATUSCRM).FirstOrDefault(),
                                         }).ToList();

                }
                else
                {
                    objSaida.TiposCrm = (from INFM_TIPOCRM sc in objBD.INFM_TIPOCRM
                                         where sc.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                         select new Comum.Clases.TipoCrm()
                                         {
                                             Descricao = sc.DESTIPOCRM,
                                             Codigo = sc.CODTIPOCRM,
                                             Identificador = sc.IDTIPOCRM,
                                             DescricaoStatusCrmAgrup = (from INFM_STATUSCRMAGRUP sag in objBD.INFM_STATUSCRMAGRUP
                                                                        where sag.IDSTATUSCRMAGRUP == sc.IDSTATUSCRMAGRUP
                                                                        select sag.DESSTATUSCRMAGRUP).FirstOrDefault(),
                                             DescricaoStatusPadrao = (from INFM_STATUS_CRM scrm in objBD.INFM_STATUS_CRM
                                                                      where scrm.IDSTATUSCRM == sc.IDSTATUSCRM
                                                                      select scrm.DESSTATUSCRM).FirstOrDefault(),
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

        [AcceptVerbs("POST")]
        [Route("BuscarTipoCrm")]
        [Classes.ValidateModel]
        public ContratoServico.TipoCrm.BuscarTipoCrm.RespostaBuscarTipoCrm BuscarTipoCrm(ContratoServico.TipoCrm.BuscarTipoCrm.PeticaoBuscarTipoCrm objEntrada)
        {

            ContratoServico.TipoCrm.BuscarTipoCrm.RespostaBuscarTipoCrm objSaida = new ContratoServico.TipoCrm.BuscarTipoCrm.RespostaBuscarTipoCrm();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

               
                objSaida.TipoCrm = (from INFM_TIPOCRM sc in objBD.INFM_TIPOCRM
                                    where ((!string.IsNullOrEmpty(objEntrada.Identificador) && sc.IDTIPOCRM == objEntrada.Identificador) ||
                                          (!string.IsNullOrEmpty(objEntrada.Codigo) && sc.CODTIPOCRM == objEntrada.Codigo)) &&
                                          sc.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                    select new Comum.Clases.TipoCrm()
                                    {
                                        Descricao = sc.DESTIPOCRM,
                                        Codigo = sc.CODTIPOCRM,
                                        Identificador = sc.IDTIPOCRM,
                                        IdentificadorStatusCrmAgrup = sc.IDSTATUSCRMAGRUP,
                                        IdentificadorStatusPadrao = sc.IDSTATUSCRM,
                                        TiposCrmConfig = (from INFM_TIPOCRMCONFIG tcc in objBD.INFM_TIPOCRMCONFIG
                                                          where tcc.IDTIPOCRM == sc.IDTIPOCRM
                                                          select new Comum.Clases.TipoCrmConfig()
                                                          {
                                                              EmpregadoAtual = tcc.BOLEMPREGADOATUAL,
                                                              Identificador = tcc.IDTIPOCRMCONFIG,
                                                              Nivel = tcc.NELNIVEL,
                                                              DescricaoNivel = tcc.DESNIVELCONFIG,
                                                              QuantidadeDiasData = (Int32)(tcc.NELQUANTDIASDATA != null ? tcc.NELQUANTDIASDATA : 0),
                                                              QuantidadeEmpregados = tcc.NELQUANTFUNCIONARIOS,
                                                              TipoEmpregado = new Comum.Clases.TipoEmpregado() { Identificador = tcc.IDTIPOEMPREGADO },
                                                              Pessoas = (from INFM_TIPOCRMCONFIGPESSOA tcp in objBD.INFM_TIPOCRMCONFIGPESSOA
                                                                         join INFM_PESSOA p in objBD.INFM_PESSOA on tcp.IDPESSOA equals p.IDPESSOA
                                                                         where tcp.IDTIPOCRMCONFIG == tcc.IDTIPOCRMCONFIG
                                                                         select new Comum.Clases.Pessoa()
                                                                         {
                                                                             Identificador = tcp.IDPESSOA,
                                                                             DesNome = p.DESNOME
                                                                         }).ToList()
                                                          }).ToList()
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
        [Route("ExcluirTipoCrm")]
        [Classes.ValidateModel]
        public ContratoServico.TipoCrm.ExcluirTipoCrm.RespostaExcluirTipoCrm ExcluirTipoCrm(ContratoServico.TipoCrm.ExcluirTipoCrm.PeticaoExcluirTipoCrm objEntrada)
        {

            ContratoServico.TipoCrm.ExcluirTipoCrm.RespostaExcluirTipoCrm objSaida = new ContratoServico.TipoCrm.ExcluirTipoCrm.RespostaExcluirTipoCrm();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                Int32 objCrm = (from c in objBD.INFM_CRM where c.IDTIPOCRM == objEntrada.Identificador select c).Count();

                if (objCrm > 0)
                {

                    throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO, "O tipo do crm já está sendo utilizado.");
                }


                INFM_TIPOCRM objStatusCrm = (from INFM_TIPOCRM icrm in objBD.INFM_TIPOCRM
                                             where icrm.IDTIPOCRM == objEntrada.Identificador
                                             select icrm).FirstOrDefault();

                List<INFM_TIPOCRMCONFIG> objTiposCrmConfig = (from INFM_TIPOCRMCONFIG tcc in objBD.INFM_TIPOCRMCONFIG where tcc.IDTIPOCRM == objEntrada.Identificador select tcc).ToList();
                List<INFM_TIPOCRMCONFIGPESSOA> objTiposCrmPessoa = null;

                if (objTiposCrmConfig != null && objTiposCrmConfig.Count > 0)
                {

                    foreach (INFM_TIPOCRMCONFIG tcrmc in objTiposCrmConfig)
                    {

                        objTiposCrmPessoa = (from INFM_TIPOCRMCONFIGPESSOA tcp in objBD.INFM_TIPOCRMCONFIGPESSOA
                                             where tcp.IDTIPOCRMCONFIG == tcrmc.IDTIPOCRMCONFIG
                                             select tcp).ToList();


                        if (objTiposCrmPessoa != null && objTiposCrmPessoa.Count > 0)
                        {
                            objBD.INFM_TIPOCRMCONFIGPESSOA.RemoveRange(objTiposCrmPessoa);
                        }

                        objBD.INFM_TIPOCRMCONFIG.RemoveRange(objTiposCrmConfig);
                    }

                }

                objBD.INFM_TIPOCRM.Remove(objStatusCrm);


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
    }
}
