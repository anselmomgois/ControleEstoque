using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarProdutoFilial")]
    public class GuardarProdutoFilialController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarProdutoFilial.Carregar.RespostaGuardarProdutoFilialCarregar Carregar(ContratoServico.Telas.GuardarProdutoFilial.Carregar.PeticaoGuardarProdutoFilialCarregar Peticao)
        {

            ContratoServico.Telas.GuardarProdutoFilial.Carregar.RespostaGuardarProdutoFilialCarregar objSaida = new ContratoServico.Telas.GuardarProdutoFilial.Carregar.RespostaGuardarProdutoFilialCarregar();


            ContratoServico.Setor.BuscarSetores.RespostaBuscarSetores objSaidaSetor = null;
            SetorController objSetorController = new SetorController();

            try
            {
                              

                Task objTaskComissoes = new Task(() => objSaida.Comissoes = LogicaNegocio.ProdutoComissao.RecuperarComissoes(string.Empty, Peticao.IdentificadorFilial, Peticao.Usuario));

                Task objTaskProdutoFilial = new Task(() => objSaida.ProdutoFilial = LogicaNegocio.ProdutoFilial.RecuperarProdutoFilial(Peticao.IdentificadorFilial, Peticao.IdentificadorProdutoServico, Peticao.Usuario));

                Task objTaskProdutoServico = new Task(() => objSaida.ProdutoServico = LogicaNegocio.ProdutoServico.RecuperarProdutoServico(Peticao.IdentificadorProdutoServico, Peticao.Usuario));

                Task objTaskUnidadesMedida = new Task(() => objSaida.UnidadesMedida = LogicaNegocio.UnidadeMedida.RecuperarUnidadesMedida(null, Peticao.IdentificadorEmpresa, Peticao.Usuario, true));

                Task objTaskSetor = new Task(() => objSaidaSetor = objSetorController.BuscarSetores(new ContratoServico.Setor.BuscarSetores.PeticaoBuscarSetores()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    IdentificadorFilial = Peticao.IdentificadorFilial,
                    Usuario = Peticao.Usuario
                }));


                objTaskProdutoServico.Start();
                objTaskProdutoFilial.Start();
                objTaskComissoes.Start();
                objTaskUnidadesMedida.Start();
                objTaskSetor.Start();

                Task.WaitAll(new Task[] { objTaskComissoes, objTaskProdutoFilial, objTaskProdutoServico, objTaskUnidadesMedida, objTaskSetor });

                if(objSaidaSetor != null)
                {
                    objSaida.SetoresEmpresa = objSaidaSetor.Setores;
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
