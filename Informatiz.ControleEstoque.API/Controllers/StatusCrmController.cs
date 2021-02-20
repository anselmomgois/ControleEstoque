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
    [RoutePrefix("api/StatusCrm")]
    public class StatusCrmController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("SetStatusCrm")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.StatusCrm.RespostaStatusCrm SetStatusCrm(ContratoServico.CRM.StatusCrm.PeticaoStatusCrm objEntrada)
        {

            ContratoServico.CRM.StatusCrm.RespostaStatusCrm objSaida = new ContratoServico.CRM.StatusCrm.RespostaStatusCrm();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                INFM_STATUSCRMAGRUP objStatusCrmAgrup = null;

                if (string.IsNullOrEmpty(objEntrada.Status.Identificador))
                {
                    objStatusCrmAgrup = new INFM_STATUSCRMAGRUP()
                    {
                        DESSTATUSCRMAGRUP = objEntrada.Status.Descricao,
                        IDEMPRESA = objEntrada.IdentificadorEmpresa,
                        IDSTATUSCRMAGRUP = Guid.NewGuid().ToString()
                    };

                    objBD.INFM_STATUSCRMAGRUP.Add(objStatusCrmAgrup);

                }
                else
                {

                    objStatusCrmAgrup = (from INFM_STATUSCRMAGRUP scrm in objBD.INFM_STATUSCRMAGRUP
                                         where scrm.IDSTATUSCRMAGRUP == objEntrada.Status.Identificador
                                         select scrm).FirstOrDefault();

                    objStatusCrmAgrup.DESSTATUSCRMAGRUP = objEntrada.Status.Descricao;

                }

                if (objEntrada.Status.StatusCrms != null && objEntrada.Status.StatusCrms.Count > 0)
                {

                    List<INFM_STATUS_CRM> objStatusCrm = (from INFM_STATUS_CRM scrm in objBD.INFM_STATUS_CRM
                                                          where scrm.IDSTATUSCRMAGRUP == objStatusCrmAgrup.IDSTATUSCRMAGRUP
                                                          select scrm).ToList();

                    if (objStatusCrm != null && objStatusCrm.Count > 0)
                    {
                        List<INFM_STATUS_CRM> objStatusAdd = (from Comum.Clases.StatusCrm scrmadd in objEntrada.Status.StatusCrms
                                                              where !objStatusCrm.Exists(sc => sc.IDSTATUSCRM == scrmadd.Identificador)
                                                              select new INFM_STATUS_CRM()
                                                              {
                                                                  IDEMPRESA = objEntrada.IdentificadorEmpresa,
                                                                  IDSTATUSCRM = Guid.NewGuid().ToString(),
                                                                  CODCORRGB = scrmadd.CorRGB,
                                                                  CODSTATUSCRM = scrmadd.Codigo,
                                                                  DESSTATUSCRM = scrmadd.Descricao,
                                                                  IDSTATUSCRMAGRUP = objStatusCrmAgrup.IDSTATUSCRMAGRUP
                                                              }).ToList();

                        List<INFM_STATUS_CRM> objStatusModificar = (from Comum.Clases.StatusCrm scrmmod in objEntrada.Status.StatusCrms
                                                                    join INFM_STATUS_CRM scm in objStatusCrm on scrmmod.Identificador equals scm.IDSTATUSCRM
                                                                    select new INFM_STATUS_CRM()
                                                                    {
                                                                        IDEMPRESA = objEntrada.IdentificadorEmpresa,
                                                                        IDSTATUSCRM = scm.IDSTATUSCRM,
                                                                        CODCORRGB = scrmmod.CorRGB,
                                                                        CODSTATUSCRM = scrmmod.Codigo,
                                                                        DESSTATUSCRM = scrmmod.Descricao,
                                                                        IDSTATUSCRMAGRUP = objStatusCrmAgrup.IDSTATUSCRMAGRUP
                                                                    }).ToList();

                        List<INFM_STATUS_CRM> objStatusDeletar = (from INFM_STATUS_CRM scdel in objStatusCrm
                                                                  where !objEntrada.Status.StatusCrms.Exists(sd => sd.Identificador == scdel.IDSTATUSCRM)
                                                                  select scdel).ToList();

                        if (objStatusAdd != null && objStatusAdd.Count > 0)
                        {
                            objBD.INFM_STATUS_CRM.AddRange(objStatusAdd);
                        }

                        if (objStatusDeletar != null && objStatusDeletar.Count > 0)
                        {

                            objBD.INFM_STATUS_CRM.RemoveRange(objStatusDeletar);
                        }

                        if (objStatusModificar != null && objStatusModificar.Count > 0)
                        {
                            foreach (INFM_STATUS_CRM sc in objStatusModificar)
                            {
                                INFM_STATUS_CRM objMod = (from INFM_STATUS_CRM scrm in objStatusCrm
                                                          where scrm.IDSTATUSCRM == sc.IDSTATUSCRM
                                                          select scrm).FirstOrDefault();

                                if (objMod != null)
                                {
                                    objMod.CODCORRGB = sc.CODCORRGB;
                                    objMod.CODSTATUSCRM = sc.CODSTATUSCRM;
                                    objMod.DESSTATUSCRM = sc.DESSTATUSCRM;
                                }
                            }
                        }
                    }
                    else
                    {
                        List<INFM_STATUS_CRM> objStatusAdd = (from Comum.Clases.StatusCrm scrmadd in objEntrada.Status.StatusCrms
                                                              select new INFM_STATUS_CRM()
                                                              {
                                                                  IDEMPRESA = objEntrada.IdentificadorEmpresa,
                                                                  IDSTATUSCRM = Guid.NewGuid().ToString(),
                                                                  CODCORRGB = scrmadd.CorRGB,
                                                                  CODSTATUSCRM = scrmadd.Codigo,
                                                                  DESSTATUSCRM = scrmadd.Descricao,
                                                                  IDSTATUSCRMAGRUP = objStatusCrmAgrup.IDSTATUSCRMAGRUP
                                                              }).ToList();

                        if (objStatusAdd != null && objStatusAdd.Count > 0)
                        {
                            objBD.INFM_STATUS_CRM.AddRange(objStatusAdd);
                        }
                    }
                }
                else
                {
                    List<INFM_STATUS_CRM> objStatusCrmDeletar = (from INFM_STATUS_CRM scrm in objBD.INFM_STATUS_CRM
                                                                 where scrm.IDSTATUSCRMAGRUP == objStatusCrmAgrup.IDSTATUSCRMAGRUP
                                                                 select scrm).ToList();


                    if (objStatusCrmDeletar != null && objStatusCrmDeletar.Count > 0)
                    {

                        objBD.INFM_STATUS_CRM.RemoveRange(objStatusCrmDeletar);
                    }
                }

                objBD.SaveChanges();
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                    objSaida.DescricaoErro = "Não é possivel deletar o status do crm, pois ele já está sendo utilizado.";

                }
                else
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                    objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
                }
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
        [Route("ExcluirSetStatusCrm")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.ExcluirSetStatusCrm.RespostaExcluirSetStatusCrm ExcluirSetStatusCrm(ContratoServico.CRM.ExcluirSetStatusCrm.PeticaoExcluirSetStatusCrm objEntrada)
        {

            ContratoServico.CRM.ExcluirSetStatusCrm.RespostaExcluirSetStatusCrm objSaida = new ContratoServico.CRM.ExcluirSetStatusCrm.RespostaExcluirSetStatusCrm();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();


                List<INFM_STATUS_CRM> objStatusCrmDeletar = (from INFM_STATUS_CRM scrm in objBD.INFM_STATUS_CRM
                                                             where scrm.IDSTATUSCRMAGRUP == objEntrada.IdentificadorStatusCrmAgrup
                                                             select scrm).ToList();


                if (objStatusCrmDeletar != null && objStatusCrmDeletar.Count > 0)
                {

                    objBD.INFM_STATUS_CRM.RemoveRange(objStatusCrmDeletar);
                }


                INFM_STATUSCRMAGRUP objStatusCrm = (from INFM_STATUSCRMAGRUP icrm in objBD.INFM_STATUSCRMAGRUP
                                                    where icrm.IDSTATUSCRMAGRUP == objEntrada.IdentificadorStatusCrmAgrup
                                                    select icrm).FirstOrDefault();

                objBD.INFM_STATUSCRMAGRUP.Remove(objStatusCrm);


                objBD.SaveChanges();
                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                    objSaida.DescricaoErro = "Não é possivel deletar o status do crm, pois ele já está sendo utilizado.";

                }
                else
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                    objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
                }
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
        [Route("BuscarStatusCrm")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.BuscarStatusCrm.RespostaBuscarStatusCrm BuscarStatusCrm(ContratoServico.CRM.BuscarStatusCrm.PeticaoBuscarStatusCrm objEntrada)
        {

            ContratoServico.CRM.BuscarStatusCrm.RespostaBuscarStatusCrm objSaida = new ContratoServico.CRM.BuscarStatusCrm.RespostaBuscarStatusCrm();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                objSaida.StatusAgrupador = (from INFM_STATUSCRMAGRUP sca in objBD.INFM_STATUSCRMAGRUP
                                            where sca.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                            select new Comum.Clases.StatusCrmAgrupador()
                                            {
                                                Descricao = sca.DESSTATUSCRMAGRUP,
                                                Identificador = sca.IDSTATUSCRMAGRUP,
                                                StatusCrms = (from INFM_STATUS_CRM sc in sca.INFM_STATUS_CRM
                                                              select new Comum.Clases.StatusCrm()
                                                              {
                                                                  Codigo = sc.CODSTATUSCRM,
                                                                  CorRGB = sc.CODCORRGB,
                                                                  Descricao = sc.DESSTATUSCRM,
                                                                  Identificador = sc.IDSTATUSCRM
                                                              }).ToList()
                                            }).ToList();



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
        [Route("BuscarStatusCrmSimples")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.BuscarStatusCrmSimples.RespostaBuscarStatusCrmSimples BuscarStatusCrmSimples(ContratoServico.CRM.BuscarStatusCrmSimples.PeticaoBuscarStatusCrmSimples objEntrada)
        {

            ContratoServico.CRM.BuscarStatusCrmSimples.RespostaBuscarStatusCrmSimples objSaida = new ContratoServico.CRM.BuscarStatusCrmSimples.RespostaBuscarStatusCrmSimples();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                objSaida.StatusAgrupador = (from INFM_STATUSCRMAGRUP sca in objBD.INFM_STATUSCRMAGRUP
                                            where sca.IDEMPRESA == objEntrada.IdentificadorEmpresa &&
                                            (string.IsNullOrEmpty(objEntrada.Descricao) || sca.DESSTATUSCRMAGRUP.ToUpper().Contains(objEntrada.Descricao.ToUpper()))
                                            select new Comum.Clases.StatusCrmAgrupador()
                                            {
                                                Descricao = sca.DESSTATUSCRMAGRUP,
                                                Identificador = sca.IDSTATUSCRMAGRUP,
                                                StatusCrms = (from INFM_STATUS_CRM sc in sca.INFM_STATUS_CRM
                                                              select new Comum.Clases.StatusCrm()
                                                              {
                                                                  Codigo = sc.CODSTATUSCRM,
                                                                  CorRGB = sc.CODCORRGB,
                                                                  Descricao = sc.DESSTATUSCRM,
                                                                  Identificador = sc.IDSTATUSCRM
                                                              }).ToList()
                                            }).ToList();



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
        [Route("BuscarStatusCrmDetalhe")]
        [Classes.ValidateModel]
        public ContratoServico.CRM.BuscarStatusCrmDetalhe.RespostaStatusCrmDetalhe BuscarStatusCrmDetalhe(ContratoServico.CRM.BuscarStatusCrmDetalhe.PeticaoStatusCrmDetalhe objEntrada)
        {

            ContratoServico.CRM.BuscarStatusCrmDetalhe.RespostaStatusCrmDetalhe objSaida = new ContratoServico.CRM.BuscarStatusCrmDetalhe.RespostaStatusCrmDetalhe();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();


                objSaida.StatusAgrupador = (from INFM_STATUSCRMAGRUP sca in objBD.INFM_STATUSCRMAGRUP
                                            where sca.IDSTATUSCRMAGRUP == objEntrada.IdentificadorStatusCrmAgrupador
                                            select new Comum.Clases.StatusCrmAgrupador()
                                            {
                                                Descricao = sca.DESSTATUSCRMAGRUP,
                                                Identificador = sca.IDSTATUSCRMAGRUP,
                                                StatusCrms = (from INFM_STATUS_CRM sc in sca.INFM_STATUS_CRM
                                                              select new Comum.Clases.StatusCrm()
                                                              {
                                                                  Codigo = sc.CODSTATUSCRM,
                                                                  CorRGB = sc.CODCORRGB,
                                                                  Descricao = sc.DESSTATUSCRM,
                                                                  Identificador = sc.IDSTATUSCRM
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

    }
}
