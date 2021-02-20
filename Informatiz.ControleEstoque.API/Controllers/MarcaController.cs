using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Marca")]
    public class MarcaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarMarcas")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoMarca.RecuperarMarcas.RespostaRecuperarMarcas RecuperarMarcas(ContratoServico.ProdutoMarca.RecuperarMarcas.PeticaoRecuperarMarcas Peticao)
        {

            ContratoServico.ProdutoMarca.RecuperarMarcas.RespostaRecuperarMarcas objSaida = new ContratoServico.ProdutoMarca.RecuperarMarcas.RespostaRecuperarMarcas();

            try
            {

                objSaida.Marcas = LogicaNegocio.ProdutoMarca.RecuperarMarcas(Peticao.Descricao, Peticao.IdentificadorEmpresa, Peticao.Usuario);

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
        [Route("DeletarProdutoMarca")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoMarca.DeletarProdutoMarca.RespostaDeletarProdutoMarca DeletarProdutoMarca(ContratoServico.ProdutoMarca.DeletarProdutoMarca.PeticaoDeletarProdutoMarca Peticao)
        {

            ContratoServico.ProdutoMarca.DeletarProdutoMarca.RespostaDeletarProdutoMarca objSaida = new ContratoServico.ProdutoMarca.DeletarProdutoMarca.RespostaDeletarProdutoMarca();

            try
            {

                LogicaNegocio.ProdutoMarca.DeletarProdutoMarca(Peticao.IdentificadorProdutoMarca, Peticao.Usuario);

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
