using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/BuscarCRM")]
    public class BuscaCRMController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.BuscarCRM.Carregar.RespostaBuscarCRMCarregar Carregar(ContratoServico.Telas.BuscarCRM.Carregar.PeticaoBuscarCRMCarregar Peticao)
        {

            ContratoServico.Telas.BuscarCRM.Carregar.RespostaBuscarCRMCarregar objSaida = new ContratoServico.Telas.BuscarCRM.Carregar.RespostaBuscarCRMCarregar();

            try
            {

                StatusCrmController objStatusCRMController = new StatusCrmController();
                TipoCrmController objTipoCRMController = new TipoCrmController();

                ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaFuncionarios = null;
                ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaClientes = null;
                ContratoServico.CRM.BuscarStatusCrm.RespostaBuscarStatusCrm objSaidaStatusCrm = null;

                Task objTaskListaFuncionarios = new Task(() => objSaidaFuncionarios = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario,
                    TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO
                }));

                Task objTaskListaClientes = new Task(() => objSaidaClientes = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario,
                    TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE
                }));

                StatusCrmController objControllerStatus = new StatusCrmController();

                Task objTaskStatusCRM = new Task(() => objSaidaStatusCrm = objControllerStatus.BuscarStatusCrm(new ContratoServico.CRM.BuscarStatusCrm.PeticaoBuscarStatusCrm()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario
                }));

                objTaskListaFuncionarios.Start();
                objTaskStatusCRM.Start();
                objTaskListaClientes.Start();

                Task.WaitAll(new Task[] { objTaskListaFuncionarios, objTaskListaClientes, objTaskStatusCRM });

                if (objSaidaStatusCrm != null)
                {
                    objSaida.StatusAgrupador = objSaidaStatusCrm.StatusAgrupador;
                }

                if (objSaidaFuncionarios != null)
                {
                    objSaida.Funcionarios = objSaidaFuncionarios.Pessoas;
                }

                if (objSaidaClientes != null)
                {
                    objSaida.Clientes = objSaidaClientes.Pessoas;
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
