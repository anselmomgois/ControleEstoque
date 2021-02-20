using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GrupoCompromisso")]
    public class GrupoCompromissoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarGruposCompromisso")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.RespostaRecuperarGruposCompromisso RecuperarGruposCompromisso(ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.PeticaoRecuperarGruposCompromisso Peticao)
        {

            ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.RespostaRecuperarGruposCompromisso objSaida = null;

            try
            {

                objSaida = LogicaNegocio.GrupoCompromisso.RecuperarGruposCompromisso(Peticao);

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
        [Route("DeletarGrupoCompromisso")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoCompromisso.DeletarGrupoCompromisso.RespostaDeletarGrupoCompromisso DeletarGrupoCompromisso(ContratoServico.GrupoCompromisso.DeletarGrupoCompromisso.PeticaoDeletarGrupoCompromisso Peticao)
        {

            ContratoServico.GrupoCompromisso.DeletarGrupoCompromisso.RespostaDeletarGrupoCompromisso objSaida = new ContratoServico.GrupoCompromisso.DeletarGrupoCompromisso.RespostaDeletarGrupoCompromisso();

            try
            {

                LogicaNegocio.GrupoCompromisso.DeletarGrupoCompromisso(Peticao.IdentificadorGrupoCompromisso, Peticao.Usuario);

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                    objSaida.DescricaoErro = "Não é possivel deletar o nivel de atendimento, pois ele já está sendo utilizado.";
                    
                }
                else
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                    objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
                }
            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        [AcceptVerbs("POST")]
        [Route("RecuperarGrupoCompromisso")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.RespostaRecuperarGrupoCompromisso RecuperarGrupoCompromisso(ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.PeticaoRecuperarGrupoCompromisso Peticao)
        {

            ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.RespostaRecuperarGrupoCompromisso objSaida = new ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso.RespostaRecuperarGrupoCompromisso();

            try
            {

                objSaida.GrupoCompromisso = LogicaNegocio.GrupoCompromisso.RecuperarGrupoCompromisso(Peticao.IdentificadorGrupoCompromisso, Peticao.Usuario);

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
        [Route("SetGrupoCompromisso")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoCompromisso.SetGrupoCompromisso.RespostaSetGrupoCompromisso SetGrupoCompromisso(ContratoServico.GrupoCompromisso.SetGrupoCompromisso.PeticaoSetGrupoCompromisso Peticao)
        {

            ContratoServico.GrupoCompromisso.SetGrupoCompromisso.RespostaSetGrupoCompromisso objSaida = new ContratoServico.GrupoCompromisso.SetGrupoCompromisso.RespostaSetGrupoCompromisso();

            try
            {

                if (string.IsNullOrEmpty(Peticao.GrupoCompromisso.Identificador))
                {
                    LogicaNegocio.GrupoCompromisso.InserirGrupoCompromisso(Peticao.GrupoCompromisso, Peticao.IdentificadorEmpresa,
                                                                           Peticao.Usuario);
                }
                else
                {
                    LogicaNegocio.GrupoCompromisso.AtualizarGrupoCompromisso(Peticao.GrupoCompromisso,Peticao.IdentificadorEmpresa,
                                                                             Peticao.Usuario);
                }

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                    objSaida.DescricaoErro = "Não é possivel deletar o sub grupo, pois ele já está sendo utilizado.";

                }
                else
                {
                    objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                    objSaida.DescricaoErro = "Aconteceu um erro inesperado.";
                }
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
