using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Pessoa")]
    public class PessoaController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("RecuperarPessoas")]
        [Classes.ValidateModel]
        public ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas RecuperarPessoas(ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao)
        {

            ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas objSaida = null;

            try
            {
                objSaida = LogicaNegocio.Pessoa.RecuperarPessoas(Peticao);

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
        [Route("InserirPessoa")]
        [Classes.ValidateModel]
        public ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa InserirPessoa(ContratoServico.Pessoa.InserirPessoa.PeticaoInserirPessoa Peticao)
        {

            ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa objSaida = new ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa();

            try
            {

                if ((from tp in Peticao.Pessoa.TiposPessoa where tp.Codigo == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO select tp).Count() > 0)
                {
                    IGERENCEEntities objBD = new IGERENCEEntities();

                    var existe = (from p in objBD.INFM_PESSOA where p.IDEMPRESA == Peticao.Pessoa.Empresa.Identificador && p.DESSENHATOUCH == Peticao.Pessoa.DesSenhaTouch select p).Count() > 0;

                    if (existe)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Senha touch informada fora do padrão");
                    }
                }

                string IdentificadorPessoa = string.Empty;

                IdentificadorPessoa = LogicaNegocio.Pessoa.InserirPessoa(Peticao.Pessoa, Peticao.Usuario);

                objSaida.Pessoa = AcessoDados.Classes.Pessoa.RecuperarPessoasSimples(new List<string> { IdentificadorPessoa }).FirstOrDefault();

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
        [Route("AtualizarPessoa")]
        [Classes.ValidateModel]
        public ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa AtualizarPessoa(ContratoServico.Pessoa.AtualizarPessoa.PeticaoAtualizarPessoa Peticao)
        {

            ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa objSaida = new ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa();

            try
            {

                if ((from tp in Peticao.Pessoa.TiposPessoa where tp.Codigo == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO select tp).Count() > 0)
                {
                    IGERENCEEntities objBD = new IGERENCEEntities();

                    var existe = (from p in objBD.INFM_PESSOA
                                  where p.IDEMPRESA == Peticao.Pessoa.Empresa.Identificador &&
                                  p.DESSENHATOUCH == Peticao.Pessoa.DesSenhaTouch &&
                                  p.IDPESSOA != Peticao.Pessoa.Identificador
                                  select p).Count() > 0;

                    if (existe)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Senha touch informada fora do padrão");
                    }
                }

                LogicaNegocio.Pessoa.AtualizarPessoa(Peticao.Pessoa, Peticao.Usuario);

                objSaida.Pessoa = Peticao.Pessoa;

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
        [Route("DesativarPessoa")]
        [Classes.ValidateModel]
        public ContratoServico.Pessoa.DesativarPessoa.RespostaDesativarPessoa DesativarPessoa(ContratoServico.Pessoa.DesativarPessoa.PeticaoDesativarPessoa Peticao)
        {

            ContratoServico.Pessoa.DesativarPessoa.RespostaDesativarPessoa objSaida = new ContratoServico.Pessoa.DesativarPessoa.RespostaDesativarPessoa();

            try
            {
                LogicaNegocio.Pessoa.DesativarPessoa(Peticao.Identificador, Peticao.TipoPessoa, Peticao.Usuario);

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
        [Route("TrocarSenhaPessoa")]
        [Classes.ValidateModel]
        public ContratoServico.Pessoa.TrocarSenhaPessoa.RespostaTrocarSenhaPessoa TrocarSenhaPessoa(ContratoServico.Pessoa.TrocarSenhaPessoa.PeticaoTrocarSenhaPessoa Peticao)
        {

            ContratoServico.Pessoa.TrocarSenhaPessoa.RespostaTrocarSenhaPessoa objSaida = new ContratoServico.Pessoa.TrocarSenhaPessoa.RespostaTrocarSenhaPessoa();

            try
            {
                LogicaNegocio.Pessoa.TrocarSenhaPessoa(Peticao.Identificador, Peticao.Senha, Peticao.SolicitarTrocarSenha, Peticao.Usuario);

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
