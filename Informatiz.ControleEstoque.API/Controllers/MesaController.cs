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
    [RoutePrefix("api/Mesa")]
    public class MesaController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("SetMesa")]
        [Classes.ValidateModel]
        public ContratoServico.Mesa.SetMesa.RespostaSetMesa SetMesa(ContratoServico.Mesa.SetMesa.PeticaoSetMesa objEntrada)
        {

            ContratoServico.Mesa.SetMesa.RespostaSetMesa objSaida = new ContratoServico.Mesa.SetMesa.RespostaSetMesa();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                string IdentificadorMesa = string.Empty;

                Int32 Existe = (from INFM_MESA m in objBD.INFM_MESA
                                  where m.IDFILIAL == objEntrada.IdentificadorFilial &&
                                        m.CODMESA == objEntrada.Mesa.Codigo &&
                                        (string.IsNullOrEmpty(objEntrada.Mesa.Identificador) || m.IDMESA != objEntrada.Mesa.Identificador)
                                  select m).Count();

                if (Existe > 0)
                {
                    throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO, "Codigo da mesa já existe.");
                }

                if (string.IsNullOrEmpty(objEntrada.Mesa.Identificador))
                {
                    IdentificadorMesa = Guid.NewGuid().ToString();

                    objBD.INFM_MESA.Add(new INFM_MESA()
                    {
                        CODESTADO = Comum.Enumeradores.EstadoMesa.Livre.RecuperarValor(),
                        CODMESA = objEntrada.Mesa.Codigo,
                        IDMESA = IdentificadorMesa,
                        IDFILIAL = objEntrada.IdentificadorFilial,
                        NELQUANTIDADELUGAR = objEntrada.Mesa.QuantidadeLugar,
                        BOLATIVA = true
                    });

                }
                else
                {
                    IdentificadorMesa = objEntrada.Mesa.Identificador;

                    INFM_MESA objMesa = (from INFM_MESA tc in objBD.INFM_MESA where tc.IDMESA == objEntrada.Mesa.Identificador select tc).FirstOrDefault();

                    objMesa.CODMESA = objEntrada.Mesa.Codigo;
                    objMesa.NELQUANTIDADELUGAR = objEntrada.Mesa.QuantidadeLugar;
                    objMesa.BOLATIVA = objEntrada.Mesa.Ativa;

                    List<INFM_MESAAGRUPAR> objMesasAgrupar = (from ma in objBD.INFM_MESAAGRUPAR where ma.IDMESAPRINCIPAL == objMesa.IDMESA select ma).ToList();
                    if (objMesasAgrupar != null) objBD.INFM_MESAAGRUPAR.RemoveRange(objMesasAgrupar);
                }

                if (objEntrada.Mesa.MesasProximas != null && objEntrada.Mesa.MesasProximas.Count > 0)
                {

                    foreach (var m in objEntrada.Mesa.MesasProximas)
                    {
                        objBD.INFM_MESAAGRUPAR.Add(new INFM_MESAAGRUPAR()
                        {
                            IDMESAAGRUPAR = Guid.NewGuid().ToString(),
                            IDMESAAUXILIAR = m.Identificador,
                            IDMESAPRINCIPAL = IdentificadorMesa
                        });
                    }
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
        [Route("BuscarMesas")]
        [Classes.ValidateModel]
        public ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas BuscarMesas(ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas objEntrada)
        {

            ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas objSaida = new ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                string strCodigoMesaOcupada = Comum.Enumeradores.EstadoMesa.Ocupada.RecuperarValor();
                string strCodigoMesaLivre = Comum.Enumeradores.EstadoMesa.Livre.RecuperarValor();
                string strCodigoMesaAguardandoLimpeza = Comum.Enumeradores.EstadoMesa.AguardandoLimpeza.RecuperarValor();
                string strCodigoMesaReservada = Comum.Enumeradores.EstadoMesa.Reservada.RecuperarValor();

                if (!string.IsNullOrEmpty(objEntrada.Codigo) || objEntrada.QuantidadeLugares > 0)
                {


                    objSaida.Mesas = (from INFM_MESA sc in objBD.INFM_MESA
                                      where sc.IDFILIAL == objEntrada.IdentificadorFilial &&
                                      sc.CODMESA == (!string.IsNullOrEmpty(objEntrada.Codigo) ? objEntrada.Codigo : sc.CODMESA) &&
                                      sc.NELQUANTIDADELUGAR == (objEntrada.QuantidadeLugares > 0 ? objEntrada.QuantidadeLugares : sc.NELQUANTIDADELUGAR)
                                      select new Comum.Clases.Mesa()
                                      {
                                          Ativa = sc.BOLATIVA,
                                          Identificador = sc.IDMESA,
                                          Codigo = sc.CODMESA,
                                          QuantidadeLugar = sc.NELQUANTIDADELUGAR,
                                          Estado = (sc.CODESTADO == strCodigoMesaLivre ? Comum.Enumeradores.EstadoMesa.Livre :
                                                   (sc.CODESTADO == strCodigoMesaAguardandoLimpeza ? Comum.Enumeradores.EstadoMesa.AguardandoLimpeza :
                                                   (sc.CODESTADO == strCodigoMesaOcupada ? Comum.Enumeradores.EstadoMesa.Ocupada : Comum.Enumeradores.EstadoMesa.Reservada)))
                                      }).ToList();

                }
                else
                {


                    objSaida.Mesas = (from INFM_MESA sc in objBD.INFM_MESA
                                      where sc.IDFILIAL == objEntrada.IdentificadorFilial
                                      select new Comum.Clases.Mesa()
                                      {
                                          Ativa = sc.BOLATIVA,
                                          Identificador = sc.IDMESA,
                                          Codigo = sc.CODMESA,
                                          QuantidadeLugar = sc.NELQUANTIDADELUGAR,
                                          Estado = (sc.CODESTADO == strCodigoMesaLivre ? Comum.Enumeradores.EstadoMesa.Livre :
                                                   (sc.CODESTADO == strCodigoMesaAguardandoLimpeza ? Comum.Enumeradores.EstadoMesa.AguardandoLimpeza :
                                                   (sc.CODESTADO == strCodigoMesaOcupada ? Comum.Enumeradores.EstadoMesa.Ocupada : Comum.Enumeradores.EstadoMesa.Reservada)))
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
        [Route("RecuperarMesa")]
        [Classes.ValidateModel]
        public ContratoServico.Mesa.RecuperarMesa.RespostaRecuperarMesa RecuperarMesa(ContratoServico.Mesa.RecuperarMesa.PeticaoRecuperarMesa objEntrada)
        {

            ContratoServico.Mesa.RecuperarMesa.RespostaRecuperarMesa objSaida = new ContratoServico.Mesa.RecuperarMesa.RespostaRecuperarMesa();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();
                string strCodigoMesaOcupada = Comum.Enumeradores.EstadoMesa.Ocupada.RecuperarValor();
                string strCodigoMesaLivre = Comum.Enumeradores.EstadoMesa.Livre.RecuperarValor();
                string strCodigoMesaAguardandoLimpeza = Comum.Enumeradores.EstadoMesa.AguardandoLimpeza.RecuperarValor();
                string strCodigoMesaReservada = Comum.Enumeradores.EstadoMesa.Reservada.RecuperarValor();

                if (!string.IsNullOrEmpty(objEntrada.Identificador))
                {


                    objSaida.Mesa = (from INFM_MESA sc in objBD.INFM_MESA
                                     where sc.IDMESA == objEntrada.Identificador
                                     select new Comum.Clases.Mesa()
                                     {
                                         Ativa = sc.BOLATIVA,
                                         Identificador = sc.IDMESA,
                                         Codigo = sc.CODMESA,
                                         QuantidadeLugar = sc.NELQUANTIDADELUGAR,
                                         Estado = (sc.CODESTADO == strCodigoMesaLivre ? Comum.Enumeradores.EstadoMesa.Livre :
                                                  (sc.CODESTADO == strCodigoMesaAguardandoLimpeza ? Comum.Enumeradores.EstadoMesa.AguardandoLimpeza :
                                                  (sc.CODESTADO == strCodigoMesaOcupada ? Comum.Enumeradores.EstadoMesa.Ocupada : Comum.Enumeradores.EstadoMesa.Reservada))),
                                         MesasProximas = (from mp in objBD.INFM_MESAAGRUPAR
                                                          where mp.IDMESAPRINCIPAL == sc.IDMESA
                                                          select new Comum.Clases.MesaProxima() { Identificador = mp.IDMESAAUXILIAR }).ToList()
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
    }
}
