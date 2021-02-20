using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Proposta")]
    public class PropostaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarProposta")]
        [Classes.ValidateModel]
        public ContratoServico.Proposta.RecuperarProposta.RespostaRecuperarProposta RecuperarProposta(ContratoServico.Proposta.RecuperarProposta.PeticaoRecuperarProposta Peticao)
        {

            ContratoServico.Proposta.RecuperarProposta.RespostaRecuperarProposta objSaida = new ContratoServico.Proposta.RecuperarProposta.RespostaRecuperarProposta();

            try
            {

               objSaida.Proposta = LogicaNegocio.Proposta.RecuperarProposta(Peticao.IdentificadorProposta, Peticao.Usuario);


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
        [Route("SetProposta")]
        [Classes.ValidateModel]
        public ContratoServico.Proposta.SetProposta.RespostaSetProposta SetProposta(ContratoServico.Proposta.SetProposta.PeticaoSetProposta Peticao)
        {

            ContratoServico.Proposta.SetProposta.RespostaSetProposta objSaida = new ContratoServico.Proposta.SetProposta.RespostaSetProposta();

            try
            {

                if (string.IsNullOrEmpty(Peticao.Proposta.Identificador))
                {
                    LogicaNegocio.Proposta.InserirProposta(Peticao.Proposta, Peticao.IdentificadorEmpresa,Peticao.Usuario);
                }
                else
                {
                    LogicaNegocio.Proposta.AtualizarProposta(Peticao.Proposta, Peticao.Usuario);
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
