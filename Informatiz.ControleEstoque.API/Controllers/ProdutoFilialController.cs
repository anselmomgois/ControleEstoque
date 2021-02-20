using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/ProdutoFilial")]
    public class ProdutoFilialController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("SetProdutoFilial")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoFilial.SetProdutoFilial.RespostaSetProdutoFilial SetProdutoFilial(ContratoServico.ProdutoFilial.SetProdutoFilial.PeticaoSetProdutoFilial Peticao)
        {

            ContratoServico.ProdutoFilial.SetProdutoFilial.RespostaSetProdutoFilial objSaida = new ContratoServico.ProdutoFilial.SetProdutoFilial.RespostaSetProdutoFilial();

            try
            {

                if (string.IsNullOrEmpty(Peticao.ProdutoFilial.Identificador))
                {
                     LogicaNegocio.ProdutoFilial.InserirProdutoFilial(Peticao.ProdutoFilial, Peticao.IdentificadorFilial, Peticao.IdentificadorProdutoServico,
                                                                      Peticao.Usuario);
                }
                else
                {

                    LogicaNegocio.ProdutoFilial.AtualizarProdutoFilial(Peticao.ProdutoFilial, Peticao.Usuario);
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
