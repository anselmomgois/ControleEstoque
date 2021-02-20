using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.API.Entity;
namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarMesa")]
    public class GuardarMesaController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarMesa.Carregar.RespostaGuardarMesaCarregar Carregar(ContratoServico.Telas.GuardarMesa.Carregar.PeticaoGuardarMesaCarregar Peticao)
        {

            ContratoServico.Telas.GuardarMesa.Carregar.RespostaGuardarMesaCarregar objSaida = new ContratoServico.Telas.GuardarMesa.Carregar.RespostaGuardarMesaCarregar();

            try
            {

                MesaController objController = new MesaController();
                ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas objRespostaBuscarMesas = null;
                ContratoServico.Mesa.RecuperarMesa.RespostaRecuperarMesa objRespostaRecuperarMesas = null;

                Task objTaskBuscarMesas = new Task(() => objRespostaBuscarMesas = objController.BuscarMesas(new ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas()
                {
                    IdentificadorFilial = Peticao.IdentificadorFilial,
                    Usuario = Peticao.Usuario
                }));

                Task objTaskRecuperarMesas = new Task(() => objRespostaRecuperarMesas = objController.RecuperarMesa(new ContratoServico.Mesa.RecuperarMesa.PeticaoRecuperarMesa
                {
                    Identificador = Peticao.IdentificadorMesa,
                    Usuario = Peticao.Usuario
                }));


                objTaskBuscarMesas.Start();
                objTaskRecuperarMesas.Start();

                Task.WaitAll(new Task[] { objTaskBuscarMesas, objTaskRecuperarMesas });


                if (objRespostaRecuperarMesas != null)
                {
                    objSaida.Mesa = objRespostaRecuperarMesas.Mesa;
                }

                if (objRespostaBuscarMesas != null && objRespostaBuscarMesas.Mesas != null && objRespostaBuscarMesas.Mesas.Count > 0)
                {
                    if (objSaida.Mesa != null) objRespostaBuscarMesas.Mesas.RemoveAll(om => om.Identificador == objSaida.Mesa.Identificador);
                    if (objRespostaBuscarMesas.Mesas.Count > 0) objSaida.Mesas = (from ma in objRespostaBuscarMesas.Mesas
                                                                                  select new Comum.Clases.MesaProxima()
                                                                                  {
                                                                                      Identificador = ma.Identificador,
                                                                                      Codigo = ma.Codigo
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



    }
}
