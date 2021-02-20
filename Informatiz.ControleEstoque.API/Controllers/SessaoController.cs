using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Sessao")]
    public class SessaoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("AtualizarSessao")]
        [Classes.ValidateModel]
        public ContratoServico.Sessao.AtualizarSessao.RespostaAtualizarSessao AtualizarSessao(ContratoServico.Sessao.AtualizarSessao.PeticaoAtualizarSessao Peticao)
        {

            ContratoServico.Sessao.AtualizarSessao.RespostaAtualizarSessao objSaida = new ContratoServico.Sessao.AtualizarSessao.RespostaAtualizarSessao();

            try
            {

              objSaida.SessaoExpirada =   LogicaNegocio.Usuario.AtualizarSessao(Peticao.IdentificadorSessao, Peticao.Usuario);

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
