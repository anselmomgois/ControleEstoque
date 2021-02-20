using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Execao;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Processo")]
    public class ProcessoController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("RecuperarProcessos")]
        [Classes.ValidateModel]
        public ContratoServico.Processo.RecuperarProcessos.RespostaRecuperarProcessos RecuperarProcessos(ContratoServico.Processo.RecuperarProcessos.PeticaoRecuperarProcessos objEntrada)
        {

            ContratoServico.Processo.RecuperarProcessos.RespostaRecuperarProcessos objSaida = new ContratoServico.Processo.RecuperarProcessos.RespostaRecuperarProcessos();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.IdentificadorEmpresa))
                {

                    string TipoProcessoEmailFechamento = Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA.RecuperarValor();

                    if (objEntrada.Ativo == null)
                    {

                        objSaida.Processos = (from INFM_PROCESSO p in objBD.INFM_PROCESSO
                                              where p.IDEMPRESA == objEntrada.IdentificadorEmpresa
                                              select new Comum.Clases.Processo()

                                              {
                                                  Identificador = p.IDPROCESSO,
                                                  Ativo = p.BOLATIVO,
                                                  Descricao = p.DESPROCESSO,
                                                  IntervaloExecucao = p.NELINTERVALO,
                                                  QuantidadeTentativas = p.NELTENTATIVAS,
                                                  Tipo = (p.CODTIPOPROCESSO == TipoProcessoEmailFechamento ?
                                                          Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA : Comum.Enumeradores.TipoProcesso.API)
                                              }).ToList();
                    }
                    else
                    {

                        if (objEntrada.RecuperarItemProcesso)
                        {
                            objSaida.Processos = (from INFM_PROCESSO p in objBD.INFM_PROCESSO
                                                  where p.IDEMPRESA == objEntrada.IdentificadorEmpresa && p.BOLATIVO == objEntrada.Ativo
                                                  select new Comum.Clases.Processo()

                                                  {
                                                      Identificador = p.IDPROCESSO,
                                                      Ativo = p.BOLATIVO,
                                                      Descricao = p.DESPROCESSO,
                                                      IntervaloExecucao = p.NELINTERVALO,
                                                      QuantidadeTentativas = p.NELTENTATIVAS,
                                                      Tipo = (p.CODTIPOPROCESSO == TipoProcessoEmailFechamento ?
                                                              Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA : Comum.Enumeradores.TipoProcesso.API),
                                                      Items = (from INFM_ITEMPROCESSO ip in objBD.INFM_ITEMPROCESSO
                                                               where ip.IDPROCESSO == p.IDPROCESSO && !ip.BOLCONCLUIDO
                                                               select new Comum.Clases.ItemProcesso()
                                                               {
                                                                   DataExecucaoProgramada = ip.DTHPROGRAMADO,
                                                                   FimExecucao = ip.DTHEXECUCAO,
                                                                   Identificador = ip.IDITEMPROCESSO,
                                                                   Valor = ip.DESVALOR,
                                                                   Tipo = p.CODTIPOPROCESSO == TipoProcessoEmailFechamento ? Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA : Comum.Enumeradores.TipoProcesso.API
                                                               }).ToList()
                                                  }).ToList();
                        }
                        else
                        {
                            objSaida.Processos = (from INFM_PROCESSO p in objBD.INFM_PROCESSO
                                                  where p.IDEMPRESA == objEntrada.IdentificadorEmpresa && p.BOLATIVO == objEntrada.Ativo
                                                  select new Comum.Clases.Processo()

                                                  {
                                                      Identificador = p.IDPROCESSO,
                                                      Ativo = p.BOLATIVO,
                                                      Descricao = p.DESPROCESSO,
                                                      IntervaloExecucao = p.NELINTERVALO,
                                                      QuantidadeTentativas = p.NELTENTATIVAS,
                                                      Tipo = (p.CODTIPOPROCESSO == TipoProcessoEmailFechamento ?
                                                              Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA : Comum.Enumeradores.TipoProcesso.API)
                                                  }).ToList();
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

        [AcceptVerbs("POST")]
        [Route("SetProcesso")]
        [Classes.ValidateModel]
        public ContratoServico.Processo.SetProcesso.RespostaSetProcesso SetProcesso(ContratoServico.Processo.SetProcesso.PeticaoSetProcesso objEntrada)
        {

            ContratoServico.Processo.SetProcesso.RespostaSetProcesso objSaida = new ContratoServico.Processo.SetProcesso.RespostaSetProcesso();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                string CodigoTipoProcesso = objEntrada.Processo.Tipo.RecuperarValor();

                if (objEntrada.Processo.Ativo)
                {
                    Int32 Existe = 0;

                    if (string.IsNullOrEmpty(objEntrada.Processo.Identificador))
                    {
                        Existe = (from INFM_PROCESSO m in objBD.INFM_PROCESSO
                                  where m.IDEMPRESA == objEntrada.IdentificadorEmpresa &&
                                        m.CODTIPOPROCESSO == CodigoTipoProcesso
                                  select m).Count();
                    }
                    else
                    {
                        Existe = (from INFM_PROCESSO m in objBD.INFM_PROCESSO
                                  where m.IDEMPRESA == objEntrada.IdentificadorEmpresa &&
                                        m.CODTIPOPROCESSO == CodigoTipoProcesso &&
                                        m.IDPROCESSO != objEntrada.Processo.Identificador
                                  select m).Count();
                    }

                    if (Existe > 0)
                    {
                        throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO, "Processo já existe.");
                    }
                }

                if (string.IsNullOrEmpty(objEntrada.Processo.Identificador))
                {
                    objBD.INFM_PROCESSO.Add(new INFM_PROCESSO()
                    {
                        BOLATIVO = true,
                        CODTIPOPROCESSO = CodigoTipoProcesso,
                        DESPROCESSO = objEntrada.Processo.Descricao,
                        IDEMPRESA = objEntrada.IdentificadorEmpresa,
                        IDPROCESSO = Guid.NewGuid().ToString(),
                        NELINTERVALO = objEntrada.Processo.IntervaloExecucao,
                        NELTENTATIVAS = objEntrada.Processo.QuantidadeTentativas
                    });

                }
                else
                {
                    INFM_PROCESSO objProcesso = (from INFM_PROCESSO tc in objBD.INFM_PROCESSO where tc.IDPROCESSO == objEntrada.Processo.Identificador select tc).FirstOrDefault();

                    objProcesso.DESPROCESSO = objEntrada.Processo.Descricao;
                    objProcesso.BOLATIVO = objEntrada.Processo.Ativo;
                    objProcesso.NELINTERVALO = objEntrada.Processo.IntervaloExecucao;
                    objProcesso.NELTENTATIVAS = objEntrada.Processo.QuantidadeTentativas;
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
        [Route("RecuperarProcesso")]
        [Classes.ValidateModel]
        public ContratoServico.Processo.RecuperarProcesso.RespostaRecuperarProcesso RecuperarProcesso(ContratoServico.Processo.RecuperarProcesso.PeticaoRecuperarProcesso objEntrada)
        {

            ContratoServico.Processo.RecuperarProcesso.RespostaRecuperarProcesso objSaida = new ContratoServico.Processo.RecuperarProcesso.RespostaRecuperarProcesso();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.IdentificadorProcesso))
                {

                    string TipoProcessoEmailFechamento = Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA.RecuperarValor();

                    objSaida.Processo = (from INFM_PROCESSO p in objBD.INFM_PROCESSO
                                         where p.IDPROCESSO == objEntrada.IdentificadorProcesso
                                         select new Comum.Clases.Processo()

                                         {
                                             Identificador = p.IDPROCESSO,
                                             Ativo = p.BOLATIVO,
                                             Descricao = p.DESPROCESSO,
                                             IntervaloExecucao = p.NELINTERVALO,
                                             QuantidadeTentativas = p.NELTENTATIVAS,
                                             Tipo = (p.CODTIPOPROCESSO == TipoProcessoEmailFechamento ?
                                                     Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA : Comum.Enumeradores.TipoProcesso.API)
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
        [Route("RecuperarItemsProcesso")]
        [Classes.ValidateModel]
        public ContratoServico.Processo.RecuperarItemsProcesso.RespostaRecuperarItemsProcesso RecuperarItemsProcesso(ContratoServico.Processo.RecuperarItemsProcesso.PeticaoRecuperarItemsProcesso objEntrada)
        {

            ContratoServico.Processo.RecuperarItemsProcesso.RespostaRecuperarItemsProcesso objSaida = new ContratoServico.Processo.RecuperarItemsProcesso.RespostaRecuperarItemsProcesso();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                if (!string.IsNullOrEmpty(objEntrada.IdentificadorProcesso))
                {

                    string TipoProcessoEmailFechamento = Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA.RecuperarValor();

                    objSaida.ItemsProcesso = (from INFM_ITEMPROCESSO ip in objBD.INFM_ITEMPROCESSO
                                              join INFM_PROCESSO p in objBD.INFM_PROCESSO on ip.IDPROCESSO equals p.IDPROCESSO
                                              where ip.IDPROCESSO == objEntrada.IdentificadorProcesso
                                              select new Comum.Clases.ItemProcesso()
                                              {
                                                  DataExecucaoProgramada = ip.DTHPROGRAMADO != null ? Convert.ToDateTime(ip.DTHEXECUCAO) : DateTime.Now,
                                                  FimExecucao = ip.DTHEXECUCAO,
                                                  Identificador = ip.IDITEMPROCESSO,
                                                  Valor = ip.DESVALOR,
                                                  Tipo = p.CODTIPOPROCESSO == TipoProcessoEmailFechamento ? Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA : Comum.Enumeradores.TipoProcesso.API
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
        [Route("RegistrarItemProcesso")]
        [Classes.ValidateModel]
        public ContratoServico.Processo.RegistrarItemProcesso.RespostaRegistrarItemProcesso RegistrarItemProcesso(ContratoServico.Processo.RegistrarItemProcesso.PeticaoRegistrarItemProcesso objEntrada)
        {

            ContratoServico.Processo.RegistrarItemProcesso.RespostaRegistrarItemProcesso objSaida = new ContratoServico.Processo.RegistrarItemProcesso.RespostaRegistrarItemProcesso();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();
                string IdentificadorItemProcesso = string.Empty;

                GerarItemProcesso(objEntrada, ref IdentificadorItemProcesso, ref objBD);

                objBD.SaveChanges();
                objSaida.ItemProcesso = objEntrada.ItemProcesso;
                objSaida.ItemProcesso.Identificador = IdentificadorItemProcesso;

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

        public static void GerarItemProcesso(ContratoServico.Processo.RegistrarItemProcesso.PeticaoRegistrarItemProcesso objEntrada,
                                              ref string IdentificadorItemProcesso,
                                              ref IGERENCEEntities objBD)
        {
            IdentificadorItemProcesso = Guid.NewGuid().ToString();

            string CodigoTipoProcesso = objEntrada.ItemProcesso.Tipo.RecuperarValor();

            INFM_PROCESSO objProcesso = (from p in objBD.INFM_PROCESSO where p.IDEMPRESA == objEntrada.IdentificadorEmpresa && p.CODTIPOPROCESSO == CodigoTipoProcesso select p).FirstOrDefault();

            if (objProcesso != null)
            {
                objBD.INFM_ITEMPROCESSO.Add(new INFM_ITEMPROCESSO()
                {
                    BOLCONCLUIDO = false,
                    DESVALOR = objEntrada.ItemProcesso.Valor,
                    DTHCRIACAO = DateTime.Now,
                    IDPROCESSO = objProcesso.IDPROCESSO,
                    IDITEMPROCESSO = IdentificadorItemProcesso,
                    DTHPROGRAMADO = objEntrada.ItemProcesso.DataExecucaoProgramada,
                    NELTENTATIVAS = 0
                });

            }

        }
    }
}
