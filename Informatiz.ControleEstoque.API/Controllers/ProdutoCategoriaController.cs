using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/ProdutoCategoria")]
    public class ProdutoCategoriaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarCategorias")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoCategoria.RecuperarCategorias.RespostaRecuperarCategorias RecuperarCategorias(ContratoServico.ProdutoCategoria.RecuperarCategorias.PeticaoRecuperarCategorias Peticao)
        {

            ContratoServico.ProdutoCategoria.RecuperarCategorias.RespostaRecuperarCategorias objSaida = new ContratoServico.ProdutoCategoria.RecuperarCategorias.RespostaRecuperarCategorias();

            try
            {

                objSaida.Categorias = LogicaNegocio.ProdutoCategoria.RecuperarCategorias(Peticao.Descricao,
                                                                                            Peticao.IdentificadorEmpresa,
                                                                                            Peticao.Usuario);

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
        [Route("DeletarProdutoCategoria")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.RespostaDeletarProdutoCategoria DeletarProdutoCategoria(ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.PeticaoDeletarProdutoCategoria Peticao)
        {

            ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.RespostaDeletarProdutoCategoria objSaida = new ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.RespostaDeletarProdutoCategoria();

            try
            {

                LogicaNegocio.ProdutoCategoria.DeletarProdutoCategoria(Peticao.IdentificadorProdutoCategoria, Peticao.Usuario);

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
