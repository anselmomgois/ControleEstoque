using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.Execao;
using Informatiz.ControleEstoque.API.Entity;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/TipoEmpregado")]
    public class TipoEmpregadoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("SetTipoEmpregado")]
        [Classes.ValidateModel]
        public ContratoServico.TipoEmpregado.SetTipoEmpregado.RespostaSetTipoEmpregado SetTipoEmpregado(ContratoServico.TipoEmpregado.SetTipoEmpregado.PeticaoSetTipoEmpregado Peticao)
        {

            ContratoServico.TipoEmpregado.SetTipoEmpregado.RespostaSetTipoEmpregado objSaida = new ContratoServico.TipoEmpregado.SetTipoEmpregado.RespostaSetTipoEmpregado();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(Peticao.TipoEmpregado.Identificador))
                {
                    INFM_TIPOEMPREGADO objTipoEmpregado = (from INFM_TIPOEMPREGADO te in objBD.INFM_TIPOEMPREGADO where te.IDTIPOEMPREGADO == Peticao.TipoEmpregado.Identificador select te).FirstOrDefault();

                    if (objTipoEmpregado != null)
                    {
                        objTipoEmpregado.DESTIPOEMPREGADO = Peticao.TipoEmpregado.Descricao;
                        objTipoEmpregado.BOLSUPERVISOR = Peticao.TipoEmpregado.Supervisor;
                        objTipoEmpregado.BOLRESPFINANCEIRO = Peticao.TipoEmpregado.ResponsavelFinanceiro;
                        objTipoEmpregado.BOLENTREGADOR = Peticao.TipoEmpregado.Entregador;
                        objTipoEmpregado.BOLGERENTE = Peticao.TipoEmpregado.Gerente;
                        objTipoEmpregado.BOLENVIAREMAILFECHAMENTO = Peticao.TipoEmpregado.EnviarEmailFechamento;
                    }

                }
                else
                {
                    objBD.INFM_TIPOEMPREGADO.Add(new INFM_TIPOEMPREGADO()
                    {
                        IDEMPRESA = Peticao.IdentificadorEmpresa,
                        DESTIPOEMPREGADO = Peticao.TipoEmpregado.Descricao,
                        BOLSUPERVISOR = Peticao.TipoEmpregado.Supervisor,
                        BOLRESPFINANCEIRO  = Peticao.TipoEmpregado.ResponsavelFinanceiro,
                        BOLENTREGADOR = Peticao.TipoEmpregado.Entregador,
                        BOLGERENTE = Peticao.TipoEmpregado.Gerente,
                        IDTIPOEMPREGADO = Guid.NewGuid().ToString(),
                        BOLENVIAREMAILFECHAMENTO = Peticao.TipoEmpregado.EnviarEmailFechamento
                    });

                }

                objBD.SaveChanges();
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
        [Route("BuscarTipoEmpregado")]
        [Classes.ValidateModel]
        public ContratoServico.TipoEmpregado.BuscarTipoEmpregado.RespostaBuscarTipoEmpregado BuscarTipoEmpregado(ContratoServico.TipoEmpregado.BuscarTipoEmpregado.PeticaoBuscarTipoEmpregado Peticao)
        {

            ContratoServico.TipoEmpregado.BuscarTipoEmpregado.RespostaBuscarTipoEmpregado objSaida = new ContratoServico.TipoEmpregado.BuscarTipoEmpregado.RespostaBuscarTipoEmpregado();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                objSaida.TipoEmpregado = (from INFM_TIPOEMPREGADO te in objBD.INFM_TIPOEMPREGADO
                                          where te.IDTIPOEMPREGADO == Peticao.Identificador
                                          select new Comum.Clases.TipoEmpregado()
                                          {
                                              Identificador = te.IDTIPOEMPREGADO,
                                              Descricao = te.DESTIPOEMPREGADO,
                                              Supervisor = te.BOLSUPERVISOR.HasValue ? te.BOLSUPERVISOR.Value : false,
                                              ResponsavelFinanceiro = te.BOLRESPFINANCEIRO.HasValue ? te.BOLRESPFINANCEIRO.Value : false,
                                              Entregador = te.BOLENTREGADOR.HasValue ? te.BOLENTREGADOR.Value : false,
                                              Gerente = te.BOLGERENTE.HasValue ? te.BOLGERENTE.Value : false,
                                              EnviarEmailFechamento = te.BOLENVIAREMAILFECHAMENTO.HasValue ? te.BOLENVIAREMAILFECHAMENTO.Value : false
                                          }).FirstOrDefault();

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
        [Route("PesquisarTipoEmpregado")]
        [Classes.ValidateModel]
        public ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.RespostaPesquisarTipoEmpregado PesquisarTipoEmpregado(ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.PeticaoPesquisarTipoEmpregado Peticao)
        {

            ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.RespostaPesquisarTipoEmpregado objSaida = new ContratoServico.TipoEmpregado.PesquisarTipoEmpregado.RespostaPesquisarTipoEmpregado();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(Peticao.Descricao))
                {
                    objSaida.TiposEmpregado = (from INFM_TIPOEMPREGADO te in objBD.INFM_TIPOEMPREGADO
                                               where te.IDEMPRESA == Peticao.IdentificadorEmpresa &&
                                                     te.DESTIPOEMPREGADO == Peticao.Descricao
                                               select new Comum.Clases.TipoEmpregado()
                                               {
                                                   Identificador = te.IDTIPOEMPREGADO,
                                                   Descricao = te.DESTIPOEMPREGADO,
                                                   Supervisor = te.BOLSUPERVISOR.HasValue ? te.BOLSUPERVISOR.Value : false,
                                                   ResponsavelFinanceiro = te.BOLRESPFINANCEIRO.HasValue ? te.BOLRESPFINANCEIRO.Value : false,
                                                   Entregador = te.BOLENTREGADOR.HasValue ? te.BOLENTREGADOR.Value : false,
                                                   Gerente = te.BOLGERENTE.HasValue ? te.BOLGERENTE.Value : false,
                                                   EnviarEmailFechamento = te.BOLENVIAREMAILFECHAMENTO.HasValue ? te.BOLENVIAREMAILFECHAMENTO.Value : false
                                               }).ToList();
                }
                else
                {
                    objSaida.TiposEmpregado = (from INFM_TIPOEMPREGADO te in objBD.INFM_TIPOEMPREGADO
                                               where te.IDEMPRESA == Peticao.IdentificadorEmpresa
                                               select new Comum.Clases.TipoEmpregado()
                                               {
                                                   Identificador = te.IDTIPOEMPREGADO,
                                                   Descricao = te.DESTIPOEMPREGADO,
                                                   Supervisor = te.BOLSUPERVISOR.HasValue ? te.BOLSUPERVISOR.Value : false,
                                                   ResponsavelFinanceiro = te.BOLRESPFINANCEIRO.HasValue ? te.BOLRESPFINANCEIRO.Value : false,
                                                   Entregador = te.BOLENTREGADOR.HasValue ? te.BOLENTREGADOR.Value : false,
                                                   Gerente = te.BOLGERENTE.HasValue ? te.BOLGERENTE.Value : false,
                                                   EnviarEmailFechamento = te.BOLENVIAREMAILFECHAMENTO.HasValue ? te.BOLENVIAREMAILFECHAMENTO.Value : false
                                               }).ToList();
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

        [AcceptVerbs("POST")]
        [Route("ExcluirTipoEmpregado")]
        [Classes.ValidateModel]
        public ContratoServico.TipoEmpregado.ExcluirTipoEmpregado.RespostaExcluirTipoEmpregado ExcluirTipoEmpregado(ContratoServico.TipoEmpregado.ExcluirTipoEmpregado.PeticaoExcluirTipoEmpregado Peticao)
        {

            ContratoServico.TipoEmpregado.ExcluirTipoEmpregado.RespostaExcluirTipoEmpregado objSaida = new ContratoServico.TipoEmpregado.ExcluirTipoEmpregado.RespostaExcluirTipoEmpregado();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                Int32 QuantidadeRegistros = (from INFM_PESSOA p in objBD.INFM_PESSOA where p.IDTIPOEMPREGADO == Peticao.Identificador select p).Count();

                if(QuantidadeRegistros > 0)
                {
                    throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO, "O tipo do empregado já está sendo utilizado.");
                }

                INFM_TIPOEMPREGADO objTipoEmpregado = (from INFM_TIPOEMPREGADO icrm in objBD.INFM_TIPOEMPREGADO
                                                where icrm.IDTIPOEMPREGADO == Peticao.Identificador
                                                select icrm).FirstOrDefault();

                objBD.INFM_TIPOEMPREGADO.Remove(objTipoEmpregado);

                objBD.SaveChanges();
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
