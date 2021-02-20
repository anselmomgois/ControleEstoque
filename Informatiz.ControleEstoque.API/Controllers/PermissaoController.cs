using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Permissao")]
    public class PermissaoController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.Permissoes.Carregar.RespostaPermissoesCarregar Carregar(ContratoServico.Telas.Permissoes.Carregar.PeticaoPermissoesCarregar Peticao)
        {

            ContratoServico.Telas.Permissoes.Carregar.RespostaPermissoesCarregar objSaida = new ContratoServico.Telas.Permissoes.Carregar.RespostaPermissoesCarregar();

            try
            {

                ContratoServico.Acao.RecuperarAcoes.RespostaRecuperarAcoes RespostaAcoes = null;

                Task objTaskGruposPermissoes = new Task(() => objSaida.GruposPermissoes = LogicaNegocio.GrupoPermissao.RecuperarGruposCompleto(Peticao.IdentificadorEmpresa, Peticao.Usuario));
                Task objTaskPermissoes = new Task(() => objSaida.Permissoes = LogicaNegocio.Permissao.RecuperarPermissoes(Peticao.Usuario));
                Task objTaskGrupo = new Task(() => objSaida.GrupoPermissao = (!string.IsNullOrEmpty(Peticao.IdentificadorGrupo) ? LogicaNegocio.GrupoPermissao.RecuperarGrupoPermissao(Peticao.IdentificadorGrupo, Peticao.Usuario) : null));
                Task objTaskAcoes = new Task(() => RespostaAcoes = LogicaNegocio.Acao.RecuperarAcoes(new ContratoServico.Acao.RecuperarAcoes.PeticaoRecuperarAcoes() { Usuario = Peticao.Usuario }));
                Task objTaskPermissoesFuncionario = new Task(() => objSaida.PermissoesFuncionario = (!string.IsNullOrEmpty(Peticao.IdentificadorFuncionario) ? LogicaNegocio.Permissao.RecuperarPermissoesUsuario(Peticao.IdentificadorFuncionario, Peticao.Usuario) : null));

                objTaskGruposPermissoes.Start();
                objTaskPermissoes.Start();
                objTaskGrupo.Start();
                objTaskAcoes.Start();
                objTaskPermissoesFuncionario.Start();

                Task.WaitAll(new Task[] { objTaskGruposPermissoes, objTaskPermissoes, objTaskGrupo, objTaskAcoes, objTaskPermissoesFuncionario });

                if (RespostaAcoes != null)
                {
                    objSaida.Acoes = RespostaAcoes.Acoes;
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


        [AcceptVerbs("POST")]
        [Route("GravarPermissoesUsuario")]
        [Classes.ValidateModel]
        public ContratoServico.Permissao.GravarPermissoesUsuario.RespostaGravarPermissoesUsuario GravarPermissoesUsuario(ContratoServico.Permissao.GravarPermissoesUsuario.PeticaoGravarPermissoesUsuario Peticao)
        {

            ContratoServico.Permissao.GravarPermissoesUsuario.RespostaGravarPermissoesUsuario objSaida = new ContratoServico.Permissao.GravarPermissoesUsuario.RespostaGravarPermissoesUsuario();

            try
            {
                LogicaNegocio.Permissao.GravarPermissoesUsuario(Peticao.IdentificadorFuncionario, Peticao.Permissoes, Peticao.Usuario);

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
        [Route("GravarGrupoPermissao")]
        [Classes.ValidateModel]
        public ContratoServico.Permissao.GravarGrupoPermissao.RespostaGravarGrupoPermissao GravarGrupoPermissao(ContratoServico.Permissao.GravarGrupoPermissao.PeticaoGravarGrupoPermissao Peticao)
        {

            ContratoServico.Permissao.GravarGrupoPermissao.RespostaGravarGrupoPermissao objSaida = new ContratoServico.Permissao.GravarGrupoPermissao.RespostaGravarGrupoPermissao();

            try
            {
                if (string.IsNullOrEmpty(Peticao.IdentificadorGrupo))
                {
                    LogicaNegocio.GrupoPermissao.GravarGrupoPermissao(Peticao.GrupoPermissao, Peticao.Usuario);
                }
                else
                {
                    LogicaNegocio.GrupoPermissao.AtualizarGrupoPermissao(Peticao.GrupoPermissao, Peticao.Usuario);
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
