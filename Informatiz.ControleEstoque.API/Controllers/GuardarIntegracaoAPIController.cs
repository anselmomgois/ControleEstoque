using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarIntegracaoAPI")]
    public class GuardarIntegracaoAPIController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.RespostaGuardarIntegracaoAPICarregar Carregar(ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.PeticaoGuardarIntegracaoAPICarregar Peticao)
        {

            ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.RespostaGuardarIntegracaoAPICarregar objSaida = new ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.RespostaGuardarIntegracaoAPICarregar();

            try
            {

                TipoCrmController objTipoCrmController = new TipoCrmController();
                ContratoServico.TipoCrm.PesquisarTipoCrm.RespostaPesquisarTipoCrm objRespostaTipoCrm = null;

                IntegracaoAPIController objIntegracaoController = new IntegracaoAPIController();
                ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI.RespostaRecuperarIntegracaoAPI objRespostaIntegracaoApi = null;

                Task objTaskTipoCrm = new Task(() => objRespostaTipoCrm = objTipoCrmController.PesquisarTipoCrm(new ContratoServico.TipoCrm.PesquisarTipoCrm.PeticaoPesquisarTipoCrm()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario
                }));

                Task objTaskIntegracaoAPI = new Task(() => objRespostaIntegracaoApi = !string.IsNullOrEmpty(Peticao.IdentificadorAPI) ? objIntegracaoController.RecuperarIntegracaoAPI(new ContratoServico.IntegracaoAPI.RecuperarIntegracaoAPI.PeticaoRecuperarIntegracaoAPI()
                {
                    Identificador = Peticao.IdentificadorAPI,
                    Usuario = Peticao.Usuario
                }) : null);


                objTaskIntegracaoAPI.Start();
                objTaskTipoCrm.Start();


                Task.WaitAll(new Task[] { objTaskTipoCrm, objTaskIntegracaoAPI });

                if (objRespostaTipoCrm != null) objSaida.TiposCrm = objRespostaTipoCrm.TiposCrm;
                if (objRespostaIntegracaoApi != null) objSaida.IntegracaoAPI = objRespostaIntegracaoApi.IntegracaoAPI;

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
