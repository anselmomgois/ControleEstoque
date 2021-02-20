using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GrupoPermissao")]
    public class GrupoPermissaoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarGrupos")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoPermissao.RecuperarGrupos.RespostaRecuperarGrupos RecuperarGrupos(ContratoServico.GrupoPermissao.RecuperarGrupos.PeticaoRecuperarGrupos Peticao)
        {

            ContratoServico.GrupoPermissao.RecuperarGrupos.RespostaRecuperarGrupos objSaida = new ContratoServico.GrupoPermissao.RecuperarGrupos.RespostaRecuperarGrupos();

            try
            {
                objSaida.GruposPermissoes = LogicaNegocio.GrupoPermissao.RecuperarGrupos(Peticao.Nome, Peticao.IdentificadorEmpresa, Peticao.Usuario);

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
        [Route("DeletarGrupoPermissao")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoPermissao.DeletarGrupoPermissao.RespostaDeletarGrupoPermissao DeletarGrupoPermissao(ContratoServico.GrupoPermissao.DeletarGrupoPermissao.PeticaoDeletarGrupoPermissao Peticao)
        {

            ContratoServico.GrupoPermissao.DeletarGrupoPermissao.RespostaDeletarGrupoPermissao objSaida = new ContratoServico.GrupoPermissao.DeletarGrupoPermissao.RespostaDeletarGrupoPermissao();

            try
            {
                LogicaNegocio.GrupoPermissao.DeletarGrupoPermissao(Peticao.Identificador, Peticao.Usuario);

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
