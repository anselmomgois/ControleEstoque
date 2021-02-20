using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarCRM")]
    public class GuardarCRMController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarCRM.Carregar.RespostaGuardarCRMCarregar Carregar(ContratoServico.Telas.GuardarCRM.Carregar.PeticaoGuardarCRMCarregar Peticao)
        {

            ContratoServico.Telas.GuardarCRM.Carregar.RespostaGuardarCRMCarregar objSaida = new ContratoServico.Telas.GuardarCRM.Carregar.RespostaGuardarCRMCarregar();

            try
            {

                StatusCrmController objStatusCRMController = new StatusCrmController();
                TipoCrmController objTipoCRMController = new TipoCrmController();

                ContratoServico.CRM.BuscarStatusCrm.RespostaBuscarStatusCrm objSaidaStatusCRM = null;
                ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaFuncionarios = null;
                ContratoServico.TipoCrm.PesquisarTipoCrm.RespostaPesquisarTipoCrm objSaidaTipoCrm = null;
                ContratoServico.CRM.RecuperarAgendamento.RespostaRecuperarAgendamento objSaidaCRM = null;

                Task objTaskListaFuncionarios = new Task(() => objSaidaFuncionarios = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario,
                    TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO
                }));

                Task objTaskListaStatusCrm = new Task(() => objSaidaStatusCRM =
                    objStatusCRMController.BuscarStatusCrm(new ContratoServico.CRM.BuscarStatusCrm.PeticaoBuscarStatusCrm() { IdentificadorEmpresa = Peticao.IdentificadorEmpresa }));


                Task objTaskTipoCrm = new Task(() => objSaidaTipoCrm = objTipoCRMController.PesquisarTipoCrm(new ContratoServico.TipoCrm.PesquisarTipoCrm.PeticaoPesquisarTipoCrm()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa
                }));

                Task objTaskCRM = new Task(() => objSaidaCRM = LogicaNegocio.CRM.RecuperarAgendamento(new ContratoServico.CRM.RecuperarAgendamento.PeticaoRecuperarAgendamento()
                {
                    IdentificadorCRM = Peticao.IdentificadorCRM,
                    Usuario = Peticao.Usuario
                }));

                objTaskListaFuncionarios.Start();
                objTaskListaStatusCrm.Start();
                objTaskTipoCrm.Start();
                objTaskCRM.Start();

                Task.WaitAll(new Task[] { objTaskListaFuncionarios, objTaskListaStatusCrm, objTaskTipoCrm, objTaskCRM });

                if (objSaidaStatusCRM != null)
                {
                    objSaida.StatusCRMAgrupador = objSaidaStatusCRM.StatusAgrupador;
                }

                if (objSaidaFuncionarios != null)
                {
                    objSaida.Funcionarios = objSaidaFuncionarios.Pessoas;
                }

                if(objSaidaTipoCrm != null)
                {
                    objSaida.TiposCrm = objSaidaTipoCrm.TiposCrm;
                }

                if(objSaidaCRM != null)
                {
                    objSaida.CRM = objSaidaCRM.CRM;
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
