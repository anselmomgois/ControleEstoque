using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("AtualizarEmpresa")]
        [Classes.ValidateModel]
        public ContratoServico.Empresa.AtualizarEmpresa.RespostaAtualizarEmpresa AtualizarEmpresa(ContratoServico.Empresa.AtualizarEmpresa.PeticaoAtualizarEmpresa Peticao)
        {

            ContratoServico.Empresa.AtualizarEmpresa.RespostaAtualizarEmpresa objSaida = new ContratoServico.Empresa.AtualizarEmpresa.RespostaAtualizarEmpresa();

            try
            {


                LogicaNegocio.Empresa.AtualizarEmpresa(Peticao.Empresa, Peticao.Usuario);

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
