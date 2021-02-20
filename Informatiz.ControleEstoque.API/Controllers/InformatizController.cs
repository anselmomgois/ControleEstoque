using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Informatiz")]
    public class InformatizController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("AlterarImagemCentral")]
        [Classes.ValidateModel]
        public ContratoServico.Informatiz.AlterarImagemCentral.RespostaAlterarImagemCentral RecuperarAcoes(ContratoServico.Informatiz.AlterarImagemCentral.PeticaoAlterarImagemCentral Peticao)
        {

            ContratoServico.Informatiz.AlterarImagemCentral.RespostaAlterarImagemCentral objSaida = new ContratoServico.Informatiz.AlterarImagemCentral.RespostaAlterarImagemCentral();

            try
            {

                LogicaNegocio.Servico.Imagem.InserirImagemCentral(Peticao.ImagemCentral, Peticao.Usuario);

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
