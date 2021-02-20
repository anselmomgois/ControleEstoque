using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Execao;
using Informatiz.ControleEstoque.Comum.Extencoes;
using Informatiz.ControleEstoque.Comum.Enumeradores;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/IntegracaoAPI")]
    public class IntegracaoAPIController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("BuscaIntegracoesAPI")]
        [Classes.ValidateModel]
        public ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.RespostaBuscaIntegracoesAPI BuscaIntegracoesAPI(ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.PeticaoBuscaIntegracoesAPI objEntrada)
        {

            ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.RespostaBuscaIntegracoesAPI objSaida = new ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.RespostaBuscaIntegracoesAPI();

            try
            {

                string Short = TipoIntegracao.SHORT.RecuperarValor();
                string Sms = TipoIntegracao.SMS.RecuperarValor();
                string Shor2 = TipoIntegracao.SHORT2.RecuperarValor();

                IGERENCEEntities objBD = new IGERENCEEntities();
                
                objSaida.IntegracoesAPI = (from INFM_INTEGRACAOAPI ia in objBD.INFM_INTEGRACAOAPI
                                           where ia.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                           select new Comum.Clases.IntegracaoAPI()
                                           {
                                               Identificador = ia.IDINTEGRACAOAPI,
                                               IdentificadorTipoCRM = ia.IDTIPOCRM,
                                               CodigoTipoCrm = (from INFM_TIPOCRM tc in objBD.INFM_TIPOCRM where tc.IDTIPOCRM == ia.IDTIPOCRM select tc.CODTIPOCRM).FirstOrDefault(),
                                               TipoIntegracao =  (!string.IsNullOrEmpty(ia.CODINTEGRACAOAPI) ? (ia.CODINTEGRACAOAPI == Short ? TipoIntegracao.SHORT :
                                                                                                                ia.CODINTEGRACAOAPI == Sms? TipoIntegracao.SMS :
                                                                                                                ia.CODINTEGRACAOAPI == Shor2 ? TipoIntegracao.SHORT2 :
                                                                                                                TipoIntegracao.ZERO800): TipoIntegracao.SHORT),
                                               Url = ia.DESURLINTEGRACAOAPI
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
        [Route("DeletarIntegracaoAPI")]
        [Classes.ValidateModel]
        public ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.RespostaDeletarIntegracaoAPI DeletarIntegracaoAPI(ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.PeticaoDeletarIntegracaoAPI objEntrada)
        {

            ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.RespostaDeletarIntegracaoAPI objSaida = new ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.RespostaDeletarIntegracaoAPI();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                INFM_INTEGRACAOAPI objIntegracao = (from INFM_INTEGRACAOAPI ia in objBD.INFM_INTEGRACAOAPI
                                                    where ia.IDINTEGRACAOAPI == objEntrada.Identificador
                                                    select ia).FirstOrDefault();


                if (objIntegracao != null)
                {
                    objBD.INFM_INTEGRACAOAPI.Remove(objIntegracao);
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
        [Route("RecuperarIntegracaoAPI")]
        [Classes.ValidateModel]
        public ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI.RespostaRecuperarIntegracaoAPI RecuperarIntegracaoAPI(ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI.PeticaoRecuperarIntegracaoAPI objEntrada)
        {

            ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI.RespostaRecuperarIntegracaoAPI objSaida = new ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI.RespostaRecuperarIntegracaoAPI();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                string Short = TipoIntegracao.SHORT.RecuperarValor();
                string Sms = TipoIntegracao.SMS.RecuperarValor();
                string Shor2 = TipoIntegracao.SHORT2.RecuperarValor();

                objSaida.IntegracaoAPI = (from INFM_INTEGRACAOAPI sc in objBD.INFM_INTEGRACAOAPI
                                          where sc.IDINTEGRACAOAPI == objEntrada.Identificador
                                          select new Comum.Clases.IntegracaoAPI()
                                          {
                                              Url = sc.DESURLINTEGRACAOAPI,
                                              Identificador = sc.IDINTEGRACAOAPI,
                                              IdentificadorTipoCRM= sc.IDTIPOCRM,
                                              TipoIntegracao = (!string.IsNullOrEmpty(sc.CODINTEGRACAOAPI) ? (sc.CODINTEGRACAOAPI == Short ? TipoIntegracao.SHORT :
                                                                                                                sc.CODINTEGRACAOAPI == Sms ? TipoIntegracao.SMS :
                                                                                                                sc.CODINTEGRACAOAPI == Shor2 ? TipoIntegracao.SHORT2 :
                                                                                                                TipoIntegracao.ZERO800) : TipoIntegracao.SHORT),
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
        [Route("SetIntegracaoAPI")]
        [Classes.ValidateModel]
        public ContratoServico.IntegracaoAPI.SetIntegracaoAPI.RespostaSetIntegracaoAPI SetIntegracaoAPI(ContratoServico.IntegracaoAPI.SetIntegracaoAPI.PeticaoSetIntegracaoAPI objEntrada)
        {

            ContratoServico.IntegracaoAPI.SetIntegracaoAPI.RespostaSetIntegracaoAPI objSaida = new ContratoServico.IntegracaoAPI.SetIntegracaoAPI.RespostaSetIntegracaoAPI();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();
                INFM_INTEGRACAOAPI objIntegracao = null;

                if (string.IsNullOrEmpty(objEntrada.IntegracaoAPI.Identificador))
                {
                    objIntegracao = new INFM_INTEGRACAOAPI();
                    objIntegracao.IDEMPRESA = objEntrada.IdentificadorEmpesa;
                    objIntegracao.IDINTEGRACAOAPI = Guid.NewGuid().ToString();
                    objIntegracao.DESURLINTEGRACAOAPI = objEntrada.IntegracaoAPI.Url;
                    objIntegracao.CODINTEGRACAOAPI = objEntrada.IntegracaoAPI.TipoIntegracao.RecuperarValor();
                    objIntegracao.IDTIPOCRM = objEntrada.IntegracaoAPI.IdentificadorTipoCRM;

                    objBD.INFM_INTEGRACAOAPI.Add(objIntegracao);
                }
                else
                {
                    objIntegracao = (from INFM_INTEGRACAOAPI tc in objBD.INFM_INTEGRACAOAPI where tc.IDINTEGRACAOAPI == objEntrada.IntegracaoAPI.Identificador select tc).FirstOrDefault();

                    objIntegracao.DESURLINTEGRACAOAPI = objEntrada.IntegracaoAPI.Url;
                    objIntegracao.CODINTEGRACAOAPI = objEntrada.IntegracaoAPI.TipoIntegracao.RecuperarValor();
                    objIntegracao.IDTIPOCRM = objEntrada.IntegracaoAPI.IdentificadorTipoCRM;

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
    }
}
