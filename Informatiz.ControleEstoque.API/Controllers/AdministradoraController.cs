using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Administradora")]
    public class AdministradoraController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarAdministradoras")]
        [Classes.ValidateModel]
        public ContratoServico.Administradora.RecuperarAdministradoras.RespostaRecuperarAdministradoras RecuperarAdministradoras(ContratoServico.Administradora.RecuperarAdministradoras.PeticaoRecuperarAdministradoras Peticao)
        {

            ContratoServico.Administradora.RecuperarAdministradoras.RespostaRecuperarAdministradoras objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Administradora.RecuperarAdministradoras(Peticao);

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
        [Route("InserirAdministradora")]
        [Classes.ValidateModel]
        public ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora InserirAdministradora(ContratoServico.Administradora.InserirAdministradora.PeticaoInserirAdministradora Peticao)
        {

            ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Administradora.InserirAdministradora(Peticao);

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
        [Route("AtualizarAdministradora")]
        [Classes.ValidateModel]
        public ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora AtualizarAdministradora(ContratoServico.Administradora.AtualizarAdministradora.PeticaoAtualizarAdministradora Peticao)
        {

            ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Administradora.AtualizarAdministradora(Peticao);

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
        [Route("DeletarAdministradora")]
        [Classes.ValidateModel]
        public ContratoServico.Administradora.DeletarAdministradora.RespostaDeletarAdministradora DeletarAdministradora(ContratoServico.Administradora.DeletarAdministradora.PeticaoDeletarAdministradora Peticao)
        {

            ContratoServico.Administradora.DeletarAdministradora.RespostaDeletarAdministradora objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Administradora.DeletarAdministradora(Peticao);

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
        [Route("RecuperarAdministradora")]
        [Classes.ValidateModel]
        public ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora RecuperarAdministradora(ContratoServico.Administradora.RecuperarAdministradora.PeticaoRecuperarAdministradora Peticao)
        {

            ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Administradora.RecuperarAdministradora(Peticao);

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
