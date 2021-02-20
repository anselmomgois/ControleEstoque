using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarEmpresa")]
    public class GuardarEmpresaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarEmpresa.Carregar.RespostaGuardarEmpresaCarregar Carregar(ContratoServico.Telas.GuardarEmpresa.Carregar.PeticaoGuardarEmpresaCarregar Peticao)
        {

            ContratoServico.Telas.GuardarEmpresa.Carregar.RespostaGuardarEmpresaCarregar objSaida = new ContratoServico.Telas.GuardarEmpresa.Carregar.RespostaGuardarEmpresaCarregar();

            try
            {


                objSaida.Empresa = LogicaNegocio.Empresa.RecuperarEmpresa(Peticao.IdentificadorEmpresa,null, Peticao.Usuario);
                                
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
