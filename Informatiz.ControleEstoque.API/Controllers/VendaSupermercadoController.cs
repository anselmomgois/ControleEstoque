using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarVendaSupermercado")]
    public class VendaSupermercadoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarVendaSupermercado.Carregar.RespostaGuardarVendaSupermercadoCarregar Carregar(ContratoServico.Telas.GuardarVendaSupermercado.Carregar.PeticaoGuardarVendaSupermercadoCarregar Peticao)
        {

            ContratoServico.Telas.GuardarVendaSupermercado.Carregar.RespostaGuardarVendaSupermercadoCarregar objSaida = new ContratoServico.Telas.GuardarVendaSupermercado.Carregar.RespostaGuardarVendaSupermercadoCarregar();

            try
            {

                ContratoServico.ProdutoServico.RecuperarProdutos.RespostaRecuperarProdutos objSaidaProdutosServicos = null;
                ContratoServico.Venda.RecuperarVendaEmCurso.RespostaRecuperarVendaEmCurso objSaidaVendaEmCurso = null;

                ProdutoServicoController objProdutoController = new ProdutoServicoController();
                VendaController objVendaController = new VendaController();

                Task objTaskListaProdutos = new Task(() => objSaidaProdutosServicos = objProdutoController.RecuperarProdutos(new ContratoServico.ProdutoServico.RecuperarProdutos.PeticaoRecuperarProdutos()
                {
                    Usuario = Peticao.Usuario,
                    DataAtual = Peticao.DataAtual,
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    IdentificadorFilial = Peticao.IdentificadorFilial,
                    RecuperarImagensProduto = Peticao.RecuperarImagensProduto
                }));

                Task objTaskVenda = new Task(() => objSaidaVendaEmCurso = objVendaController.RecuperarVendaEmCurso(new ContratoServico.Venda.RecuperarVendaEmCurso.PeticaoRecuperarVendaEmCurso()
                {
                    Usuario = Peticao.Usuario,
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    IdentificadorResponsavelCaixa = Peticao.IdentificadorResponsavelCaixa
                }));


                objTaskListaProdutos.Start();
                objTaskVenda.Start();

                Task.WaitAll(new Task[] { objTaskListaProdutos, objTaskVenda });

                if (objSaidaProdutosServicos != null)
                {
                    objSaida.ProdutosDisponiveisVenda = objSaidaProdutosServicos.ProdutosDisponiveisVenda;
                }

                if (objSaidaVendaEmCurso != null)
                {
                    objSaida.Venda = objSaidaVendaEmCurso.Venda;
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
