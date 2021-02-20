using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/UnidadeMedida")]
    public class UnidadeMedidaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarUnidadesMedida")]
        [Classes.ValidateModel]
        public ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida RecuperarUnidadesMedida(ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida Peticao)
        {

            ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida objSaida = new ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida();

            try
            {

                objSaida.UnidadesMedida = LogicaNegocio.UnidadeMedida.RecuperarUnidadesMedida(Peticao.Descricao, Peticao.IdentificadorEmpresa, Peticao.Usuario, Peticao.RecuperarUnidadesFilhas);

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
        [Route("RecuperarUnidadeMedida")]
        [Classes.ValidateModel]
        public ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.RespostaRecuperarUnidadeMedida RecuperarUnidadeMedida(ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.PeticaoRecuperarUnidadeMedida Peticao)
        {

            ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.RespostaRecuperarUnidadeMedida objSaida = new ContratoServico.UnidadeMedida.RecuperarUnidadeMedida.RespostaRecuperarUnidadeMedida();

            try
            {

                objSaida.UnidadeMedida = LogicaNegocio.UnidadeMedida.RecuperarUnidadeMedida(Peticao.IdentificadorUnidadeMedida,Peticao.Usuario);

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
        [Route("SetUnidadeMedida")]
        [Classes.ValidateModel]
        public ContratoServico.UnidadeMedida.SetUnidadeMedida.RespostaSetUnidadeMedida SetUnidadeMedida(ContratoServico.UnidadeMedida.SetUnidadeMedida.PeticaoSetUnidadeMedida Peticao)
        {

            ContratoServico.UnidadeMedida.SetUnidadeMedida.RespostaSetUnidadeMedida objSaida = new ContratoServico.UnidadeMedida.SetUnidadeMedida.RespostaSetUnidadeMedida();

            try
            {

                if (string.IsNullOrEmpty(Peticao.UnidadeMedida.Identificador))
                {
                    LogicaNegocio.UnidadeMedida.InserirUnidadeMedida(Peticao.UnidadeMedida,Peticao.IdentificadorEmpresa,Peticao.Usuario);
                }
                else
                {
                    LogicaNegocio.UnidadeMedida.AtualizarUnidadeMedida(Peticao.UnidadeMedida, Peticao.Usuario);
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
        [Route("DeletarUnidadeMedida")]
        [Classes.ValidateModel]
        public ContratoServico.UnidadeMedida.DeletarUnidadeMedida.RespostaDeletarUnidadeMedida DeletarUnidadeMedida(ContratoServico.UnidadeMedida.DeletarUnidadeMedida.PeticaoDeletarUnidadeMedida Peticao)
        {

            ContratoServico.UnidadeMedida.DeletarUnidadeMedida.RespostaDeletarUnidadeMedida objSaida = new ContratoServico.UnidadeMedida.DeletarUnidadeMedida.RespostaDeletarUnidadeMedida();

            try
            {

                LogicaNegocio.UnidadeMedida.DeletarUnidadeMedida(Peticao.IdentificadorUnidadeMedida, Peticao.Usuario);
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
