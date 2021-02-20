using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Chave")]
    public class ChaveController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("ValidarChave")]
        [Classes.ValidateModel]
        public ContratoServico.ChaveAcesso.ValidarChave.RespuestaValidarChave ValidarChave(ContratoServico.ChaveAcesso.ValidarChave.PeticaoValidarChave Peticao)
        {

            ContratoServico.ChaveAcesso.ValidarChave.RespuestaValidarChave objSaida = new ContratoServico.ChaveAcesso.ValidarChave.RespuestaValidarChave();

            try
            {

                LogicaNegocio.ChaveAcesso.ValidarChave(Peticao.Chave, Peticao.CodigoEmpresa, Peticao.Usuario, Peticao.IdentificadorEmpresa);            


                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                if (ex.Codigo == Execao.Constantes.CodigoErro.ERRO_ADMINISTRADOR)
                {
                    objSaida.CodigoAcesso = Comum.Clases.Constantes.COD_ACESSO_LIMITADO;
                }

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
        [Route("RecuperarChaves")]
        [Classes.ValidateModel]
        public ContratoServico.ChaveAcesso.RecuperarChaves.RespuestaRecuperarChaves RecuperarChaves(ContratoServico.ChaveAcesso.RecuperarChaves.PeticaoRecuperarChaves Peticao)
        {

            ContratoServico.ChaveAcesso.RecuperarChaves.RespuestaRecuperarChaves objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Servico.Chave.RecuperarChaves(Peticao);


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
