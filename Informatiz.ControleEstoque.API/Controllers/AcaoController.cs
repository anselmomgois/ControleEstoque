using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Acao")]
    public class AcaoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarAcoes")]
        [Classes.ValidateModel]
        public ContratoServico.Acao.RecuperarAcoes.RespostaRecuperarAcoes RecuperarAcoes(ContratoServico.Acao.RecuperarAcoes.PeticaoRecuperarAcoes Peticao)
        {

            ContratoServico.Acao.RecuperarAcoes.RespostaRecuperarAcoes objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Acao.RecuperarAcoes(Peticao);

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
