using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Execao;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Observacao")]
    public class ObservacaoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("BuscarObservacao")]
        [Classes.ValidateModel]
        public ContratoServico.Observacao.BuscarObservacao.RespostaBuscarObservacao BuscarObservacao(ContratoServico.Observacao.BuscarObservacao.PeticaoBuscarObservacao objEntrada)
        {

            ContratoServico.Observacao.BuscarObservacao.RespostaBuscarObservacao objSaida = new ContratoServico.Observacao.BuscarObservacao.RespostaBuscarObservacao();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.Descricao))
                {


                    objSaida.Observacoes = (from INFM_OBSERVACAO sc in objBD.INFM_OBSERVACAO
                                            where sc.DESOBSERVACAO == objEntrada.Descricao && sc.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                            select new Comum.Clases.ProdutoObservacao()
                                            {
                                                Descricao = sc.DESOBSERVACAO,
                                                Identificador = sc.IDOBSERVACAO
                                            }).ToList();

                }
                else
                {
                    objSaida.Observacoes = (from INFM_OBSERVACAO sc in objBD.INFM_OBSERVACAO
                                            where sc.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                            select new Comum.Clases.ProdutoObservacao()
                                            {
                                                Descricao = sc.DESOBSERVACAO,
                                                Identificador = sc.IDOBSERVACAO
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
        [Route("RecuperarObservacao")]
        [Classes.ValidateModel]
        public ContratoServico.Observacao.RecuperarObservacao.RespostaRecuperarObservacao RecuperarObservacao(ContratoServico.Observacao.RecuperarObservacao.PeticaoRecuperarObservacao objEntrada)
        {

            ContratoServico.Observacao.RecuperarObservacao.RespostaRecuperarObservacao objSaida = new ContratoServico.Observacao.RecuperarObservacao.RespostaRecuperarObservacao();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.Identificador))
                {


                    objSaida.Observacao = (from INFM_OBSERVACAO sc in objBD.INFM_OBSERVACAO
                                           where sc.IDOBSERVACAO == objEntrada.Identificador
                                           select new Comum.Clases.ProdutoObservacao()
                                           {
                                               Descricao = sc.DESOBSERVACAO,
                                               Identificador = sc.IDOBSERVACAO
                                           }).FirstOrDefault();

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
        [Route("SetObservacao")]
        [Classes.ValidateModel]
        public ContratoServico.Observacao.SetObservacao.RespostaSetObservacao SetObservacao(ContratoServico.Observacao.SetObservacao.PeticaoSetObservacao objEntrada)
        {

            ContratoServico.Observacao.SetObservacao.RespostaSetObservacao objSaida = new ContratoServico.Observacao.SetObservacao.RespostaSetObservacao();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();


                if (string.IsNullOrEmpty(objEntrada.Observacao.Identificador))
                {
                    objBD.INFM_OBSERVACAO.Add(new INFM_OBSERVACAO()
                    {
                        IDEMPRESA = objEntrada.IdentificadorEmpresa,
                        DESOBSERVACAO = objEntrada.Observacao.Descricao,
                        IDOBSERVACAO = Guid.NewGuid().ToString()
                    });

                }
                else
                {
                    INFM_OBSERVACAO objObservacao = (from INFM_OBSERVACAO tc in objBD.INFM_OBSERVACAO where tc.IDOBSERVACAO == objEntrada.Observacao.Identificador select tc).FirstOrDefault();

                    objObservacao.DESOBSERVACAO = objEntrada.Observacao.Descricao;

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
        [Route("DeletarObservacao")]
        [Classes.ValidateModel]
        public ContratoServico.Observacao.DeletarObservacao.RespostaDeletarObservacao DeletarObservacao(ContratoServico.Observacao.DeletarObservacao.PeticaoDeletarObservacao objEntrada)
        {

            ContratoServico.Observacao.DeletarObservacao.RespostaDeletarObservacao objSaida = new ContratoServico.Observacao.DeletarObservacao.RespostaDeletarObservacao();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                Int32 Existe = (from c in objBD.INFM_OBSERVACAOPRODUTO where c.IDOBSERVACAO == objEntrada.Identificador select c).Count();

                if (Existe > 0)
                {

                    throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO, "A observação já está sendo utilizada.");
                }


                INFM_OBSERVACAO objObservacao = (from INFM_OBSERVACAO icrm in objBD.INFM_OBSERVACAO
                                                 where icrm.IDOBSERVACAO == objEntrada.Identificador
                                                 select icrm).FirstOrDefault();


                objBD.INFM_OBSERVACAO.Remove(objObservacao);


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
