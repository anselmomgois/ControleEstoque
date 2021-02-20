using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarFuncionario")]
    public class GuardarFuncionarioController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarFuncionario.Carregar.RespostaGuardarFuncionarioCarregar Carregar(ContratoServico.Telas.GuardarFuncionario.Carregar.PeticaoGuardarFuncionarioCarregar Peticao)
        {

            ContratoServico.Telas.GuardarFuncionario.Carregar.RespostaGuardarFuncionarioCarregar objSaida = new ContratoServico.Telas.GuardarFuncionario.Carregar.RespostaGuardarFuncionarioCarregar();

            try
            {

                TipoEmpregadoController objTipoEmpregadoController = new TipoEmpregadoController();
                ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.RespostaPesquisarTipoEmpregado objSaidaTipoEmpregado = null;

                Task objTaskListaFiliais = new Task(() => objSaida.Filiais = LogicaNegocio.Filial.RecuperarFiliaisSimples(Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaTipoEmpregado = new Task(() => objSaidaTipoEmpregado =
                    objTipoEmpregadoController.PesquisarTipoEmpregado(new ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.PeticaoPesquisarTipoEmpregado()
                    {
                        IdentificadorEmpresa = Peticao.IdentificadorEmpresa
                    }));

                Task objTaskFuncionario = new Task(() => objSaida.Funcionario = LogicaNegocio.Pessoa.RecuperarPessoa(Peticao.IdentificadorFuncionario, Peticao.Usuario));

                objTaskListaFiliais.Start();
                objTaskListaTipoEmpregado.Start();
                objTaskFuncionario.Start();

                Task.WaitAll(new Task[] { objTaskListaFiliais, objTaskListaTipoEmpregado, objTaskFuncionario });

                if (objSaidaTipoEmpregado != null)
                {
                    objSaida.TiposEmpregado = objSaidaTipoEmpregado.TiposEmpregado;
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
