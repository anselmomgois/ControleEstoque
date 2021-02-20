using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.Execao;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/FormaPagamento")]
    public class FormaPagamentoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("SetFormaPagamento")]
        [Classes.ValidateModel]
        public ContratoServico.FormaPagamento.SetFormaPagamento.RespostaSetFormaPagamento SetFormaPagamento(ContratoServico.FormaPagamento.SetFormaPagamento.PeticaoSetFormaPagamento objEntrada)
        {

            ContratoServico.FormaPagamento.SetFormaPagamento.RespostaSetFormaPagamento objSaida = new ContratoServico.FormaPagamento.SetFormaPagamento.RespostaSetFormaPagamento();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                INFM_FORMAPAGAMENTO objFormaPagamento = null;

                if (string.IsNullOrEmpty(objEntrada.FormaPagamento.Identificador))
                {

                    objFormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                         where fp.CODFORMAPAGAMENTO == objEntrada.FormaPagamento.Codigo &&
                                               fp.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                         select fp).FirstOrDefault();

                    if (objFormaPagamento != null)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Já existe uma forma de pagamento registrada com o código: " + objFormaPagamento.CODFORMAPAGAMENTO);
                    }
                    else
                    {
                        objFormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                             where fp.BOLCREDITO == true &&
                                                   fp.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                             select fp).FirstOrDefault();

                        if (objFormaPagamento != null)
                        {
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A forma de pagamento: " + objFormaPagamento.DESFORMAPAGAMENTO + " já está marcada como crédito!");
                        }
                    }

                    objFormaPagamento = new INFM_FORMAPAGAMENTO()
                    {
                        BOLCARTAO = false,
                        BOLCREDITO = false,
                        CODTIPOPAGAMENTO = objEntrada.FormaPagamento.TipoPagamento != null ? objEntrada.FormaPagamento.TipoPagamento.RecuperarValor() : null,
                        IDEMPRESA = objEntrada.IdentificadorEmpresa,
                        CODFORMAPAGAMENTO = objEntrada.FormaPagamento.Codigo,
                        DESFORMAPAGAMENTO = objEntrada.FormaPagamento.Descricao,
                        IDFORMAPAGAMENTO = Guid.NewGuid().ToString(),
                        NUMPERCENTACRESCIMO = objEntrada.FormaPagamento.PercentualAcrescimo,
                        NUMPERCENTDESCONTO = objEntrada.FormaPagamento.PercentualDesconto,
                        NUMVALORACRESCIMO = objEntrada.FormaPagamento.ValorDesconto,
                        NUMVALORDESCONTO = objEntrada.FormaPagamento.ValorAcrescimo
                    };

                    objBD.INFM_FORMAPAGAMENTO.Add(objFormaPagamento);

                }
                else
                {

                    objFormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                         where fp.CODFORMAPAGAMENTO == objEntrada.FormaPagamento.Codigo &&
                                               fp.IDEMPRESA == objEntrada.IdentificadorEmpresa &&
                                               fp.IDFORMAPAGAMENTO != objEntrada.FormaPagamento.Identificador
                                         select fp).FirstOrDefault();

                    if (objFormaPagamento != null)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Já existe uma forma de pagamento registrada com o código '" + objFormaPagamento.CODFORMAPAGAMENTO + "'");
                    }
                    else
                    {
                        objFormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                             where fp.BOLCREDITO == true &&
                                                   fp.IDEMPRESA == objEntrada.IdentificadorEmpresa &&
                                                   fp.IDFORMAPAGAMENTO != objEntrada.FormaPagamento.Identificador
                                             select fp).FirstOrDefault();

                        if (objFormaPagamento != null)
                        {
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A forma de pagamento '" + objFormaPagamento.DESFORMAPAGAMENTO + "' já está marcada como crédito!");
                        }
                    }

                    objFormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                         where fp.IDFORMAPAGAMENTO == objEntrada.FormaPagamento.Identificador
                                         select fp).FirstOrDefault();

                    objFormaPagamento.BOLCARTAO = false;
                    objFormaPagamento.BOLCREDITO = false;
                    objFormaPagamento.CODTIPOPAGAMENTO = objEntrada.FormaPagamento.TipoPagamento != null ? objEntrada.FormaPagamento.TipoPagamento.RecuperarValor() : null;
                    objFormaPagamento.CODFORMAPAGAMENTO = objEntrada.FormaPagamento.Codigo;
                    objFormaPagamento.DESFORMAPAGAMENTO = objEntrada.FormaPagamento.Descricao;
                    objFormaPagamento.NUMPERCENTACRESCIMO = objEntrada.FormaPagamento.PercentualAcrescimo;
                    objFormaPagamento.NUMPERCENTDESCONTO = objEntrada.FormaPagamento.PercentualDesconto;
                    objFormaPagamento.NUMVALORACRESCIMO = objEntrada.FormaPagamento.ValorDesconto;
                    objFormaPagamento.NUMVALORDESCONTO = objEntrada.FormaPagamento.ValorAcrescimo;

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
        [Route("BuscarFormaPagamentoDetalhe")]
        [Classes.ValidateModel]
        public ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.RespostaBuscarFormaPagamentoDetalhe BuscarFormaPagamentoDetalhe(ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.PeticaoBuscarFormaPagamentoDetalhe objEntrada)
        {

            ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.RespostaBuscarFormaPagamentoDetalhe objSaida = new ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.RespostaBuscarFormaPagamentoDetalhe();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                string TipoPagamentoCartao = Comum.Enumeradores.TipoPagamento.Cartao.RecuperarValor();
                string TipoPagamentoEfectivo = Comum.Enumeradores.TipoPagamento.Efetivo.RecuperarValor();
                string TipoPagamentoPrePago = Comum.Enumeradores.TipoPagamento.PrePago.RecuperarValor();


                objSaida.FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                           where fp.IDFORMAPAGAMENTO == objEntrada.IdentificadorFormaPagamento
                                           select new Comum.Clases.FormaPagamento()
                                           {
                                               Codigo = fp.CODFORMAPAGAMENTO,
                                               Descricao = fp.DESFORMAPAGAMENTO,
                                               Identificador = fp.IDFORMAPAGAMENTO,
                                               PercentualAcrescimo = fp.NUMPERCENTACRESCIMO.HasValue ? fp.NUMPERCENTACRESCIMO.Value : 0,
                                               ValorAcrescimo = fp.NUMVALORACRESCIMO.HasValue ? fp.NUMVALORACRESCIMO.Value : 0,
                                               PercentualDesconto = fp.NUMPERCENTDESCONTO.HasValue ? fp.NUMPERCENTDESCONTO.Value : 0,
                                               ValorDesconto = fp.NUMVALORDESCONTO.HasValue ? fp.NUMVALORDESCONTO.Value : 0,
                                               TipoPagamento = (!string.IsNullOrEmpty(fp.CODTIPOPAGAMENTO) ? (fp.CODTIPOPAGAMENTO == TipoPagamentoCartao ?
                                                                Comum.Enumeradores.TipoPagamento.Cartao : (fp.CODTIPOPAGAMENTO == TipoPagamentoEfectivo ?
                                                                Comum.Enumeradores.TipoPagamento.Efetivo : Comum.Enumeradores.TipoPagamento.PrePago)) : Comum.Enumeradores.TipoPagamento.Nulo)
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
        [Route("BuscarFormaPagamento")]
        [Classes.ValidateModel]
        public ContratoServico.FormaPagamento.BuscarFormaPagamento.RespostaBuscarFormaPagamento BuscarFormaPagamento(ContratoServico.FormaPagamento.BuscarFormaPagamento.PeticaoBuscarFormaPagamento objEntrada)
        {

            ContratoServico.FormaPagamento.BuscarFormaPagamento.RespostaBuscarFormaPagamento objSaida = new ContratoServico.FormaPagamento.BuscarFormaPagamento.RespostaBuscarFormaPagamento();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                string TipoPagamentoCartao = Comum.Enumeradores.TipoPagamento.Cartao.RecuperarValor();
                string TipoPagamentoEfectivo = Comum.Enumeradores.TipoPagamento.Efetivo.RecuperarValor();
                string TipoPagamentoPrePago = Comum.Enumeradores.TipoPagamento.PrePago.RecuperarValor();

                if (!string.IsNullOrEmpty(objEntrada.Codigo) || !string.IsNullOrEmpty(objEntrada.Descricao))
                {                

                    if (!string.IsNullOrEmpty(objEntrada.Codigo))
                    {
                        objSaida.FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                                   where fp.CODFORMAPAGAMENTO == objEntrada.Codigo && fp.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                                   select new Comum.Clases.FormaPagamento()
                                                   {
                                                       Identificador = fp.IDFORMAPAGAMENTO,
                                                       Codigo = fp.CODFORMAPAGAMENTO,
                                                       Descricao = fp.DESFORMAPAGAMENTO,
                                                       PercentualAcrescimo = fp.NUMPERCENTACRESCIMO.HasValue ? fp.NUMPERCENTACRESCIMO.Value : 0,
                                                       PercentualDesconto = fp.NUMPERCENTDESCONTO.HasValue ? fp.NUMPERCENTDESCONTO.Value : 0,
                                                       ValorAcrescimo = fp.NUMVALORACRESCIMO.HasValue ? fp.NUMVALORACRESCIMO.Value : 0,
                                                       ValorDesconto = fp.NUMVALORDESCONTO.HasValue ? fp.NUMVALORDESCONTO.Value : 0,
                                                       TipoPagamento = (!string.IsNullOrEmpty(fp.CODTIPOPAGAMENTO) ? (fp.CODTIPOPAGAMENTO == TipoPagamentoCartao ?
                                                                Comum.Enumeradores.TipoPagamento.Cartao : (fp.CODTIPOPAGAMENTO == TipoPagamentoEfectivo ?
                                                                Comum.Enumeradores.TipoPagamento.Efetivo : Comum.Enumeradores.TipoPagamento.PrePago)) : Comum.Enumeradores.TipoPagamento.Nulo)

                                                   }).ToList();
                    }
                    else if (!string.IsNullOrEmpty(objEntrada.Descricao))
                    {
                        objSaida.FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                                   where fp.DESFORMAPAGAMENTO == objEntrada.Descricao && fp.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                                   select new Comum.Clases.FormaPagamento()
                                                   {
                                                       Identificador = fp.IDFORMAPAGAMENTO,
                                                       Codigo = fp.CODFORMAPAGAMENTO,
                                                       Descricao = fp.DESFORMAPAGAMENTO,
                                                       PercentualAcrescimo = fp.NUMPERCENTACRESCIMO.HasValue ? fp.NUMPERCENTACRESCIMO.Value : 0,
                                                       PercentualDesconto = fp.NUMPERCENTDESCONTO.HasValue ? fp.NUMPERCENTDESCONTO.Value : 0,
                                                       ValorAcrescimo = fp.NUMVALORACRESCIMO.HasValue ? fp.NUMVALORACRESCIMO.Value : 0,
                                                       ValorDesconto = fp.NUMVALORDESCONTO.HasValue ? fp.NUMVALORDESCONTO.Value : 0,
                                                       TipoPagamento = (!string.IsNullOrEmpty(fp.CODTIPOPAGAMENTO) ? (fp.CODTIPOPAGAMENTO == TipoPagamentoCartao ?
                                                                Comum.Enumeradores.TipoPagamento.Cartao : (fp.CODTIPOPAGAMENTO == TipoPagamentoEfectivo ?
                                                                Comum.Enumeradores.TipoPagamento.Efetivo : Comum.Enumeradores.TipoPagamento.PrePago)) : Comum.Enumeradores.TipoPagamento.Nulo)

                                                   }).ToList();
                    }
                }
                else
                {
                    objSaida.FormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                               where fp.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                               select new Comum.Clases.FormaPagamento()
                                               {
                                                   Identificador = fp.IDFORMAPAGAMENTO,
                                                   Codigo = fp.CODFORMAPAGAMENTO,
                                                   Descricao = fp.DESFORMAPAGAMENTO,
                                                   PercentualAcrescimo = fp.NUMPERCENTACRESCIMO.HasValue ? fp.NUMPERCENTACRESCIMO.Value : 0,
                                                   PercentualDesconto = fp.NUMPERCENTDESCONTO.HasValue ? fp.NUMPERCENTDESCONTO.Value : 0,
                                                   ValorAcrescimo = fp.NUMVALORACRESCIMO.HasValue ? fp.NUMVALORACRESCIMO.Value : 0,
                                                   ValorDesconto = fp.NUMVALORDESCONTO.HasValue ? fp.NUMVALORDESCONTO.Value : 0,
                                                   TipoPagamento = (!string.IsNullOrEmpty(fp.CODTIPOPAGAMENTO) ? (fp.CODTIPOPAGAMENTO == TipoPagamentoCartao ?
                                                                Comum.Enumeradores.TipoPagamento.Cartao : (fp.CODTIPOPAGAMENTO == TipoPagamentoEfectivo ?
                                                                Comum.Enumeradores.TipoPagamento.Efetivo : Comum.Enumeradores.TipoPagamento.PrePago)) : Comum.Enumeradores.TipoPagamento.Nulo)

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
        [Route("ExcluirSetFormaPagamento")]
        [Classes.ValidateModel]
        public ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.RespostaExcluirSetFormaPagamento ExcluirSetFormaPagamento(ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.PeticaoExcluirSetFormaPagamento objEntrada)
        {

            ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.RespostaExcluirSetFormaPagamento objSaida = new ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.RespostaExcluirSetFormaPagamento();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                Int32 objFP = (from c in objBD.INFM_DOCUMENTO where c.IDFORMAPAGAMENTO == objEntrada.IdentificadorFormaPagamento select c).Count();

                if (objFP > 0)
                {
                    throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO, "A forma de pagamento já está sendo utilizada.");
                }
                else
                {
                    objFP = (from c in objBD.INFM_PAGAMENTO where c.IDFORMAPAGAMENTO == objEntrada.IdentificadorFormaPagamento select c).Count();

                    if (objFP > 0)
                    {
                        throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO, "A forma de pagamento já está sendo utilizada.");
                    }
                }

                INFM_FORMAPAGAMENTO objFormaPagamento = (from INFM_FORMAPAGAMENTO fp in objBD.INFM_FORMAPAGAMENTO
                                                         where fp.IDFORMAPAGAMENTO == objEntrada.IdentificadorFormaPagamento
                                                         select fp).FirstOrDefault();

                objBD.INFM_FORMAPAGAMENTO.Remove(objFormaPagamento);

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
