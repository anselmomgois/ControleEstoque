using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarAgendamento")]
    public class GuardarAgendamentoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarAgendamento.Carregar.RespostaGuardarAgendamentoCarregar Carregar(ContratoServico.Telas.GuardarAgendamento.Carregar.PeticaoGuardarAgendamentoCarregar Peticao)
        {

            ContratoServico.Telas.GuardarAgendamento.Carregar.RespostaGuardarAgendamentoCarregar objSaida = new ContratoServico.Telas.GuardarAgendamento.Carregar.RespostaGuardarAgendamentoCarregar();

            try
            {

                StatusCrmController objStatusCRMController = new StatusCrmController();
                TipoCrmController objTipoCRMController = new TipoCrmController();

                ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaFuncionarios = null;
                ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.RespostaRecuperarGruposCompromisso objSaidaGrupoCompromisso = null;

                Task objTaskListaFuncionarios = new Task(() => objSaidaFuncionarios = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario,
                    TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO
                }));

              
                Task objTaskGrupoCompromisso = new Task(() => objSaidaGrupoCompromisso = LogicaNegocio.GrupoCompromisso.RecuperarGruposCompromisso(new ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.PeticaoRecuperarGruposCompromisso()
                {
                 IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                 Ordenar = true,
                 RecuperarPerguntas = true,
                 RecuperarSubGrupos = true,
                 Usuario = Peticao.Usuario
                }));

                objTaskListaFuncionarios.Start();
                objTaskGrupoCompromisso.Start();

                Task.WaitAll(new Task[] { objTaskListaFuncionarios, objTaskGrupoCompromisso });

                if (objSaidaGrupoCompromisso != null)
                {
                    objSaida.GruposCompromisso = objSaidaGrupoCompromisso.GruposCompromisso;
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
