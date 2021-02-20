using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarTipoCrmConfig")]
    public class GuardarTipoCrmConfigController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.RespostaGuardarTipoCrmConfigCarregar Carregar(ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.PeticaoGuardarTipoCrmConfigCarregar Peticao)
        {

            ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.RespostaGuardarTipoCrmConfigCarregar objSaida = new ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.RespostaGuardarTipoCrmConfigCarregar();

            try
            {
                ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.RespostaPesquisarTipoEmpregado objSaidaTipoEmpregado = null;
                TipoEmpregadoController objTipoEmpregadoController = new TipoEmpregadoController();
                ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaFuncionarios = null;

                Task objTaskFuncionarios = new Task(() => objSaidaFuncionarios = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                {
                    TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO,
                    Usuario = Peticao.Usuario,
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa
                }));


                Task objTaskTipoFuncionarios = new Task(() => objSaidaTipoEmpregado = objTipoEmpregadoController.PesquisarTipoEmpregado(new ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.PeticaoPesquisarTipoEmpregado()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario
                }));

                objTaskFuncionarios.Start();
                objTaskTipoFuncionarios.Start();

                Task.WaitAll(new Task[] { objTaskTipoFuncionarios, objTaskFuncionarios });

                if (objSaidaTipoEmpregado != null)
                {
                    objSaida.TiposEmpregado = objSaidaTipoEmpregado.TiposEmpregado;
                }

                if (objSaidaFuncionarios != null)
                {
                    objSaida.Funcionarios = objSaidaFuncionarios.Pessoas;
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
