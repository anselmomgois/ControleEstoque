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
    [RoutePrefix("api/Parametro")]
    public class ParametroController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarParametros")]
        [Classes.ValidateModel]
        public ContratoServico.Parametro.RecuperarParametros.RespostaRecuperarParametros RecuperarParametros(ContratoServico.Parametro.RecuperarParametros.PeticaoRecuperarParametros objEntrada)
        {

            ContratoServico.Parametro.RecuperarParametros.RespostaRecuperarParametros objSaida = new ContratoServico.Parametro.RecuperarParametros.RespostaRecuperarParametros();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.IdentificadorFilial) && !string.IsNullOrEmpty(objEntrada.IdentificadorEmpresa))
                {
                    objSaida.Parametros = (from INFM_PARAMETROS p in objBD.INFM_PARAMETROS
                                           join INFM_PARAMETROVALOR pv in objBD.INFM_PARAMETROVALOR on p.IDPARAMETRO equals pv.IDPARAMETRO
                                           where (pv.IDFILIAL == objEntrada.IdentificadorFilial && pv.IDEMPRESA == objEntrada.IdentificadorEmpresa)
                                           select new Comum.Clases.Parametro()
                                           {
                                               Codigo = p.CODPARAMETRO,
                                               Descricao = p.DESPARAMETRO,
                                               Identificador = p.IDPARAMETRO,
                                               NivelFilial = p.BOLNIVELFILIAL,
                                               TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)(p.TIPOCOMPONENTE),
                                               DesValor = pv.DESVALORPARAMETRO,
                                           }).ToList();

                    List<Comum.Clases.Parametro> objParametros = (from INFM_PARAMETROS p in objBD.INFM_PARAMETROS
                                                                  join INFM_PARAMETROVALOR pv in objBD.INFM_PARAMETROVALOR on p.IDPARAMETRO equals pv.IDPARAMETRO
                                                                  where (pv.IDEMPRESA == objEntrada.IdentificadorEmpresa && (pv.IDFILIAL == null || string.IsNullOrEmpty(pv.IDFILIAL)))
                                                                  select new Comum.Clases.Parametro()
                                                                  {
                                                                      Codigo = p.CODPARAMETRO,
                                                                      Descricao = p.DESPARAMETRO,
                                                                      Identificador = p.IDPARAMETRO,
                                                                      NivelFilial = p.BOLNIVELFILIAL,
                                                                      TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)(p.TIPOCOMPONENTE),
                                                                      DesValor = pv.DESVALORPARAMETRO,
                                                                  }).ToList();

                    if(objParametros != null && objParametros.Count > 0)
                    {

                        if (objSaida.Parametros == null) objSaida.Parametros = new List<Comum.Clases.Parametro>();

                        objSaida.Parametros.AddRange(objParametros);
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
        [Route("SetParametros")]
        [Classes.ValidateModel]
        public ContratoServico.Parametro.SetParametros.RespostaSetParametros SetParametros(ContratoServico.Parametro.SetParametros.PeticaoSetParametros objEntrada)
        {

            ContratoServico.Parametro.SetParametros.RespostaSetParametros objSaida = new ContratoServico.Parametro.SetParametros.RespostaSetParametros();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (objEntrada.Parametros != null && objEntrada.Parametros.Count > 0 && (!string.IsNullOrEmpty(objEntrada.IdentificadorEmpresa)))
                {
                    INFM_PARAMETROVALOR objParametroValor = null;

                    foreach (Comum.Clases.Parametro pent in objEntrada.Parametros)
                    {

                        objParametroValor = (from INFM_PARAMETROS p in objBD.INFM_PARAMETROS
                                             join INFM_PARAMETROVALOR pv in objBD.INFM_PARAMETROVALOR on p.IDPARAMETRO equals pv.IDPARAMETRO
                                             where p.CODPARAMETRO == pent.Codigo && ((p.BOLNIVELFILIAL && pv.IDFILIAL == objEntrada.IdentificadorFilial && pv.IDEMPRESA == objEntrada.IdentificadorEmpresa) ||
                                                                                     (!p.BOLNIVELFILIAL && pv.IDEMPRESA == objEntrada.IdentificadorEmpresa))
                                             select pv).FirstOrDefault();

                        if (objParametroValor == null)
                        {

                            objBD.INFM_PARAMETROVALOR.Add(new INFM_PARAMETROVALOR()
                            {
                                DESVALORPARAMETRO = pent.DesValor,
                                IDFILIAL = pent.NivelFilial ? objEntrada.IdentificadorFilial : null,
                                IDEMPRESA = objEntrada.IdentificadorEmpresa,
                                IDPARAMETROVALOR = Guid.NewGuid().ToString(),
                                IDPARAMETRO = (from INFM_PARAMETROS p in objBD.INFM_PARAMETROS where p.CODPARAMETRO == pent.Codigo select p.IDPARAMETRO).FirstOrDefault()
                            });
                        }
                        else
                        {
                            objParametroValor.DESVALORPARAMETRO = pent.DesValor;
                        }



                    }

                    objBD.SaveChanges();
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
        [Route("RecuperarGrupoParametros")]
        [Classes.ValidateModel]
        public ContratoServico.Parametro.RecuperarGrupoParametros.RespostaRecuperarGrupoParametros RecuperarGrupoParametros(ContratoServico.Parametro.RecuperarGrupoParametros.PeticaoRecuperarGrupoParametros objEntrada)
        {

            ContratoServico.Parametro.RecuperarGrupoParametros.RespostaRecuperarGrupoParametros objSaida = new ContratoServico.Parametro.RecuperarGrupoParametros.RespostaRecuperarGrupoParametros();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                objSaida.GrupoParametros = (from INFM_GRUPOPARAMETRO gp in objBD.INFM_GRUPOPARAMETRO
                                            select new Comum.Clases.GrupoParametro()
                                            {
                                                Identificador = gp.IDGRUPOPARAMETRO,
                                                Codigo = gp.CODGRUPOPARAMETRO,
                                                Descricao = gp.DESGRUPOPARAMETRO,
                                                Parametros = (from INFM_PARAMETROS p in objBD.INFM_PARAMETROS
                                                              where gp.IDGRUPOPARAMETRO == p.IDGRUPOPARAMETRO
                                                              select new Comum.Clases.Parametro()
                                                              {
                                                                  Identificador = p.IDPARAMETRO,
                                                                  Codigo = p.CODPARAMETRO,
                                                                  Descricao = p.DESPARAMETRO,
                                                                  NivelFilial = p.BOLNIVELFILIAL,
                                                                  TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)(p.TIPOCOMPONENTE),
                                                                  DesValor = (from INFM_PARAMETROVALOR pv in objBD.INFM_PARAMETROVALOR
                                                                              where pv.IDPARAMETRO == p.IDPARAMETRO &&
                                                                              ((p.BOLNIVELFILIAL && pv.IDEMPRESA == objEntrada.IdentificadorEmpresa &&
                                                                                  pv.IDFILIAL == objEntrada.IdentificadorFilial) ||
                                                                              (!p.BOLNIVELFILIAL && pv.IDEMPRESA == objEntrada.IdentificadorEmpresa))
                                                                              select pv.DESVALORPARAMETRO).FirstOrDefault(),
                                                                  ValoresPossiveis = (from INFM_PARAMETROOPCAO pv in objBD.INFM_PARAMETROOPCAO
                                                                                      where pv.IDPARAMETRO == p.IDPARAMETRO
                                                                                      select new Comum.Clases.ValorPossivel()
                                                                                      {
                                                                                          Identificador = pv.IDPARAMETROOPCAO,
                                                                                          Codigo = pv.CODPARAMETROOPCAO,
                                                                                          DesValorPossivel = pv.DESPARAMETROOPCAO
                                                                                      }).ToList()
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

    }

}

