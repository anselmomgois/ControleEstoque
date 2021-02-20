using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Logar")]
        [Classes.ValidateModel]
        public ContratoServico.Usuario.Logar.RespostaLogar Logar(ContratoServico.Usuario.Logar.PeticaoLogar Peticao)
        {

            ContratoServico.Usuario.Logar.RespostaLogar objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Usuario.Logar(Peticao);

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
        [Route("DeletarSessao")]
        [Classes.ValidateModel]
        public ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao DeletarSessao(ContratoServico.Usuario.DeletarSessao.PeticaoDeletarSessao Peticao)
        {

            ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Usuario.DeletarSessao(Peticao);

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
        [Route("AtivarSessao")]
        [Classes.ValidateModel]
        public ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao AtivarSessao(ContratoServico.Usuario.AtivarSessao.PeticaoAtivarSessao Peticao)
        {

            ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao objSaida = null;

            try
            {

                objSaida = LogicaNegocio.Usuario.AtivarSessao(Peticao);

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
        [Route("ValidarTipoEmpregado")]
        [Classes.ValidateModel]
        public ContratoServico.Usuario.ValidarTipoEmpregado.RespostaValidarTipoEmpregado ValidarTipoEmpregado(ContratoServico.Usuario.ValidarTipoEmpregado.PeticaoValidarTipoEmpregado Peticao)
        {

            ContratoServico.Usuario.ValidarTipoEmpregado.RespostaValidarTipoEmpregado objSaida = new ContratoServico.Usuario.ValidarTipoEmpregado.RespostaValidarTipoEmpregado();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (Peticao.validarPermissao)

                {
                    Auxiliar objTipoEmpregado;
                    objTipoEmpregado = (from INFM_PESSOA ps in objBD.INFM_PESSOA
                                        join INFM_TIPOEMPREGADO tp in objBD.INFM_TIPOEMPREGADO on ps.IDTIPOEMPREGADO equals tp.IDTIPOEMPREGADO
                                        where ps.CODLOGIN.ToUpper() == Peticao.nomeUsuario.ToUpper() && ps.DESSENHA == Peticao.senhaUsuario
                                        select new Auxiliar()
                                        {
                                            Identificador = ps.IDPESSOA,
                                            Nome = ps.DESNOME,
                                            TipoEmpregado = tp
                                        }).FirstOrDefault();

                    if (objTipoEmpregado != null)
                    {

                        objSaida.TiposEmpregado = new List<Comum.Enumeradores.Enumeradores.TipoEmpregado>();

                        foreach (Comum.Enumeradores.Enumeradores.TipoEmpregado item in Peticao.TiposEmpregado)
                        {
                            if (item == Comum.Enumeradores.Enumeradores.TipoEmpregado.SUPERVISOR)
                            {
                                if (objTipoEmpregado.TipoEmpregado.BOLSUPERVISOR.HasValue && objTipoEmpregado.TipoEmpregado.BOLSUPERVISOR.Value)
                                {
                                    objSaida.TiposEmpregado.Add(item);
                                }
                            }
                            else if (item == Comum.Enumeradores.Enumeradores.TipoEmpregado.RESPFINANCEIRO)
                            {
                                if (objTipoEmpregado.TipoEmpregado.BOLRESPFINANCEIRO.HasValue && objTipoEmpregado.TipoEmpregado.BOLRESPFINANCEIRO.Value)
                                {
                                    objSaida.TiposEmpregado.Add(item);
                                }
                            }
                            else if (item == Comum.Enumeradores.Enumeradores.TipoEmpregado.ENTREGADOR)
                            {
                                if (objTipoEmpregado.TipoEmpregado.BOLENTREGADOR.HasValue && objTipoEmpregado.TipoEmpregado.BOLENTREGADOR.Value)
                                {
                                    objSaida.TiposEmpregado.Add(item);
                                }
                            }
                            else if (item == Comum.Enumeradores.Enumeradores.TipoEmpregado.GERENTE)
                            {
                                if (objTipoEmpregado.TipoEmpregado.BOLGERENTE.HasValue && objTipoEmpregado.TipoEmpregado.BOLGERENTE.Value)
                                {
                                    objSaida.TiposEmpregado.Add(item);
                                }
                            }
                        }

                        objSaida.IdentificadorUsuario = objTipoEmpregado.Identificador;
                        objSaida.NomeUsuario = objTipoEmpregado.Nome;
                        objSaida.AcessoPermitido = (objSaida.TiposEmpregado != null && objSaida.TiposEmpregado.Count > 0);

                    }

                }
                else
                {
                    // se parametro estiver True, o usuario informado deverá ser o mesmo que já estava logado
                    if (Peticao.usuarioLogado)
                    {

                        INFM_PESSOA objPessoa = null;
                        objPessoa = (from INFM_PESSOA ps in objBD.INFM_PESSOA
                                     where ps.CODLOGIN.ToUpper() == Peticao.nomeUsuario.ToUpper() &&
                                           ps.DESSENHA == Peticao.senhaUsuario
                                     select ps).FirstOrDefault();

                        if(objPessoa != null)
                        {
                            objSaida.IdentificadorUsuario =  objPessoa.IDPESSOA;
                            objSaida.NomeUsuario = objPessoa.DESNOME;
                            objSaida.AcessoPermitido = true;
                        }
                        

                    }

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

    public class Auxiliar
    {

        public string Identificador { get; set; }
        public string Nome { get; set; }
        public INFM_TIPOEMPREGADO TipoEmpregado { get; set; }
    }

}
