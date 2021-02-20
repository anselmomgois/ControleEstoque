using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarFornecedor")]
    public class GuardarFornecedorController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarFornecedor.Carregar.RespostaGuardarFornecedorCarregar Carregar(ContratoServico.Telas.GuardarFornecedor.Carregar.PeticaoGuardarFornecedorCarregar Peticao)
        {

            ContratoServico.Telas.GuardarFornecedor.Carregar.RespostaGuardarFornecedorCarregar objSaida = new ContratoServico.Telas.GuardarFornecedor.Carregar.RespostaGuardarFornecedorCarregar();

            try
            {


                Task objTaskFornecedor = new Task(() => objSaida.Fornecedor = LogicaNegocio.Pessoa.RecuperarPessoa(Peticao.IdentificadorFornecedor, Peticao.Usuario));

                Task objTaskListaSegmentos = new Task(() => objSaida.SegmentosComerciais = LogicaNegocio.SegmentoComercial.PesquisarSegmentoComercial(Peticao.Usuario,
                   string.Empty, Peticao.IdentificadorEmpresa, string.Empty));


                objTaskListaSegmentos.Start();
                objTaskFornecedor.Start();

                Task.WaitAll(new Task[] { objTaskListaSegmentos, objTaskFornecedor });

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
