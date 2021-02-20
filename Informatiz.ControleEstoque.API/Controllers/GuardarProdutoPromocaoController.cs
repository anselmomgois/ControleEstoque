using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarProdutoPromocao")]
    public class GuardarProdutoPromocaoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarProdutoPromocao.Carregar.RespostaGuardarProdutoPromocaoCarregar Carregar(ContratoServico.Telas.GuardarProdutoPromocao.Carregar.PeticaoGuardarProdutoPromocaoCarregar Peticao)
        {

            ContratoServico.Telas.GuardarProdutoPromocao.Carregar.RespostaGuardarProdutoPromocaoCarregar objSaida = new ContratoServico.Telas.GuardarProdutoPromocao.Carregar.RespostaGuardarProdutoPromocaoCarregar();

            try
            {

                Task objTaskProdutos = new Task(() => objSaida.ProdutosGeral = LogicaNegocio.ProdutoServico.RecuperarProdutoGeral(Peticao.IdentificadorEmpresa,
                                                                                                                                  Peticao.IdentificadorFilial,Peticao.Usuario));

                Task objTaskProdutoPromocao = new Task(() => objSaida.ProdutoPromocao = (!string.IsNullOrEmpty(Peticao.IdentificadorProdutoPromocao) ? LogicaNegocio.ProdutoPromocao.RecuperarProdutoPromocao(Peticao.IdentificadorProdutoPromocao,Peticao.Usuario) : null));


                objTaskProdutos.Start();
                objTaskProdutoPromocao.Start();

                Task.WaitAll(new Task[] { objTaskProdutos, objTaskProdutoPromocao });

              
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
