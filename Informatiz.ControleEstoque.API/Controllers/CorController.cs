using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Cor")]
    public class CorController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("RecuperarCores")]
        [Classes.ValidateModel]
        public ContratoServico.Cor.RecuperarCores.RespostaRecuperarCores RecuperarCores(ContratoServico.Cor.RecuperarCores.PeticaoRecuperarCores Peticao)
        {

            ContratoServico.Cor.RecuperarCores.RespostaRecuperarCores objSaida = new ContratoServico.Cor.RecuperarCores.RespostaRecuperarCores();

            try
            {                

                objSaida.Cores = LogicaNegocio.Cor.RecuperarCores(Peticao.Descricao, Peticao.IdentificadorEmpesa, Peticao.Usuario);

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
        [Route("RecuperarCor")]
        [Classes.ValidateModel]
        public ContratoServico.Cor.RecuperarCor.RespostaRecuperarCor RecuperarCor(ContratoServico.Cor.RecuperarCor.PeticaoRecuperarCor Peticao)
        {

            ContratoServico.Cor.RecuperarCor.RespostaRecuperarCor objSaida = new ContratoServico.Cor.RecuperarCor.RespostaRecuperarCor();

            try
            {

                objSaida.Cor = LogicaNegocio.Cor.RecuperarCor(Peticao.Identificador, Peticao.Usuario);

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
        [Route("DeletarCor")]
        [Classes.ValidateModel]
        public ContratoServico.Cor.DeletarCor.RespostaDeletarCor DeletarCor(ContratoServico.Cor.DeletarCor.PeticaoDeletarCor Peticao)
        {

            ContratoServico.Cor.DeletarCor.RespostaDeletarCor objSaida = new ContratoServico.Cor.DeletarCor.RespostaDeletarCor();

            try
            {

                LogicaNegocio.Cor.DeletarCor(Peticao.Identificador, Peticao.Usuario);                              

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
        [Route("SetCor")]
        [Classes.ValidateModel]
        public ContratoServico.Cor.SetCor.RespostaSetCor SetCor(ContratoServico.Cor.SetCor.PeticaoSetCor Peticao)
        {

            ContratoServico.Cor.SetCor.RespostaSetCor objSaida = new ContratoServico.Cor.SetCor.RespostaSetCor();

            try
            {

                if (string.IsNullOrEmpty(Peticao.Cor.Identificador))
                {
                    LogicaNegocio.Cor.InserirCor(Peticao.Cor, Peticao.IdentificadorEmpresa, Peticao.Usuario);
                }
                else
                {
                    LogicaNegocio.Cor.AtualizarCor(Peticao.Cor, Peticao.Usuario);
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
