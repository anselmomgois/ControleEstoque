using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/ProdutoPromocao")]
    public class ProdutoPromocaoController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("SetProdutoPromocao")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoPromocao.SetProdutoPromocao.RespostaSetProdutoPromocao SetProdutoPromocao(ContratoServico.ProdutoPromocao.SetProdutoPromocao.PeticaoSetProdutoPromocao Peticao)
        {

            ContratoServico.ProdutoPromocao.SetProdutoPromocao.RespostaSetProdutoPromocao objSaida = new ContratoServico.ProdutoPromocao.SetProdutoPromocao.RespostaSetProdutoPromocao();

            try
            {

                if (string.IsNullOrEmpty(Peticao.ProdutoPromocao.Identificador))
                {
                    LogicaNegocio.ProdutoPromocao.InserirProdutoPromocao(Peticao.ProdutoPromocao,
                                                                         Peticao.IdentificadorEmpresa, 
                                                                         Peticao.IdentificadorFilial, 
                                                                         Peticao.Usuario);
                }
                else
                {
                    LogicaNegocio.ProdutoPromocao.AtualizarProdutoPromocao(Peticao.ProdutoPromocao, 
                                                                           Peticao.IdentificadorEmpresa,
                                                                           Peticao.IdentificadorFilial,
                                                                           Peticao.Usuario);
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
        [Route("PesquisarProdutoPromocao")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.RespostaPesquisarProdutoPromocao PesquisarProdutoPromocao(ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.PeticaoPesquisarProdutoPromocao Peticao)
        {

            ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.RespostaPesquisarProdutoPromocao objSaida = new ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.RespostaPesquisarProdutoPromocao();

            try
            {

                objSaida.Promocoes = LogicaNegocio.ProdutoPromocao.PesquisarProdutoPromocao(Peticao.Descricao, Peticao.DescricaoProduto,Peticao.IdentificadorEmpresa,
                                                                                            Peticao.IdentificadorFilial,Peticao.Usuario);
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
        [Route("DesativarProdutoPromocao")]
        [Classes.ValidateModel]
        public ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.RespostaDesativarProdutoPromocao DesativarProdutoPromocao(ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.PeticaoDesativarProdutoPromocao Peticao)
        {

            ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.RespostaDesativarProdutoPromocao objSaida = new ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.RespostaDesativarProdutoPromocao();

            try
            {
                LogicaNegocio.ProdutoPromocao.DesativarProdutoPromocao(Peticao.IdentificadorProdutoPromocao, Peticao.Usuario);

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
