using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/ProdutoServico")]
    public class ProdutoServicoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarProdutosServicos")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoServico.RecuperarProdutosServicos.RespostaRecuperarProdutosServicos RecuperarProdutosServicos(ContratoServico.ProdutoServico.RecuperarProdutosServicos.PeticaoRecuperarProdutosServicos Peticao)
        {

            ContratoServico.ProdutoServico.RecuperarProdutosServicos.RespostaRecuperarProdutosServicos objSaida = new ContratoServico.ProdutoServico.RecuperarProdutosServicos.RespostaRecuperarProdutosServicos();

            try
            {

                objSaida.ProdutosServicos = LogicaNegocio.ProdutoServico.RecuperarProdutosServicos(Peticao.Descricao, Peticao.Codigo, Peticao.CodigoBarras, Peticao.IdentificadorEmpresa, Peticao.Usuario, Peticao.CodigoTipoProduto, Peticao.IdentificadorFilial,
                                                                                                   Peticao.RecuperarUnidadeMedida, Peticao.RecuperarImagensProduto);

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
        [Route("DeletarProdutoServico")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoServico.DeletarProdutoServico.RespostaDeletarProdutoServico DeletarProdutoServico(ContratoServico.ProdutoServico.DeletarProdutoServico.PeticaoDeletarProdutoServico Peticao)
        {

            ContratoServico.ProdutoServico.DeletarProdutoServico.RespostaDeletarProdutoServico objSaida = new ContratoServico.ProdutoServico.DeletarProdutoServico.RespostaDeletarProdutoServico();

            try
            {

                LogicaNegocio.ProdutoServico.DeletarProdutoServico(Peticao.Identificador, Peticao.Usuario);

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
        [Route("SetProdutoServico")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoServico.SetProdutoServico.RespostaInserirProdutoServico SetProdutoServico(ContratoServico.ProdutoServico.SetProdutoServico.PeticaoSetProdutoServico Peticao)
        {

            ContratoServico.ProdutoServico.SetProdutoServico.RespostaInserirProdutoServico objSaida = new ContratoServico.ProdutoServico.SetProdutoServico.RespostaInserirProdutoServico();

            try
            {

                if (string.IsNullOrEmpty(Peticao.ProdutoServico.Identificador))
                {
                    LogicaNegocio.ProdutoServico.InserirProdutoServico(Peticao.ProdutoServico,
                                                                       Peticao.IdentificadorEmpresa, Peticao.Usuario);
                }
                else
                {

                    LogicaNegocio.ProdutoServico.AtualizarProdutoServico(Peticao.ProdutoServico, Peticao.IdentificadorEmpresa, Peticao.Usuario);
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
        [Route("RecuperarProdutos")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoServico.RecuperarProdutos.RespostaRecuperarProdutos RecuperarProdutos(ContratoServico.ProdutoServico.RecuperarProdutos.PeticaoRecuperarProdutos Peticao)
        {

            ContratoServico.ProdutoServico.RecuperarProdutos.RespostaRecuperarProdutos objSaida = new ContratoServico.ProdutoServico.RecuperarProdutos.RespostaRecuperarProdutos();

            try
            {

                objSaida.ProdutosDisponiveisVenda = AcessoDados.Classes.ProdutoServico.RecuperarProdutos(Peticao.IdentificadorEmpresa, 
                                                                                                         Peticao.IdentificadorFilial,
                                                                                                         Peticao.DataAtual,
                                                                                                         Peticao.Descricao,
                                                                                                         Peticao.Codigo,
                                                                                                         Peticao.RecuperarImagensProduto);

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
