using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Filial")]
    public class FilialController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarFiliais")]
        [Classes.ValidateModel]
        public ContratoServico.Filial.RecuperarFiliais.RespostaRecuperarFiliais RecuperarFiliais(ContratoServico.Filial.RecuperarFiliais.PeticaoRecuperarFiliais Peticao)
        {

            ContratoServico.Filial.RecuperarFiliais.RespostaRecuperarFiliais objSaida = new ContratoServico.Filial.RecuperarFiliais.RespostaRecuperarFiliais();

            try
            {

                objSaida.Filiais = LogicaNegocio.Filial.RecuperarFiliaisSimples(Peticao.IdentificadorEmpresa,Peticao.Usuario);

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
