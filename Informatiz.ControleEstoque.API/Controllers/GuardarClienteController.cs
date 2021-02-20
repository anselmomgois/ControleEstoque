using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarCliente")]
    public class GuardarClienteController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarCliente.Carregar.RespostaGuardarClienteCarregar Carregar(ContratoServico.Telas.GuardarCliente.Carregar.PeticaoGuardarClienteCarregar Peticao)
        {

            ContratoServico.Telas.GuardarCliente.Carregar.RespostaGuardarClienteCarregar objSaida = new ContratoServico.Telas.GuardarCliente.Carregar.RespostaGuardarClienteCarregar();

            try
            {

                ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaidaFuncionarios = null;

                Task objTaskListaSituacoes = new Task(() => objSaida.SituacoesPessoa = LogicaNegocio.SituacaoPessoa.RecuperarSituacoesPessoa(Peticao.Usuario, string.Empty));

                Task objTaskCliente = new Task(() => objSaida.Cliente = LogicaNegocio.Pessoa.RecuperarPessoa(Peticao.IdentificadorCiente, Peticao.Usuario));

                Task objTaskListaSegmentos = new Task(() => objSaida.SegmentosComerciais = LogicaNegocio.SegmentoComercial.PesquisarSegmentoComercial(Peticao.Usuario,
                   string.Empty, Peticao.IdentificadorEmpresa, string.Empty));

                Task objTaskListaFuncionarios = new Task(() => objSaidaFuncionarios = LogicaNegocio.Pessoa.RecuperarPessoas(new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario,
                    TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO
                }));


                objTaskListaSituacoes.Start();
                objTaskListaSegmentos.Start();
                objTaskListaFuncionarios.Start();
                objTaskCliente.Start();

                Task.WaitAll(new Task[] { objTaskListaSituacoes, objTaskListaSegmentos, objTaskListaFuncionarios, objTaskCliente });

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
