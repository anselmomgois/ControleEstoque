using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarTipoCrm")]
    public class GuardarTipoCrmController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarTipoCrm.Carregar.RespostaGuardarTipoCrmCarregar Carregar(ContratoServico.Telas.GuardarTipoCrm.Carregar.PeticaoGuardarTipoCrmCarregar Peticao)
        {

            ContratoServico.Telas.GuardarTipoCrm.Carregar.RespostaGuardarTipoCrmCarregar objSaida = new ContratoServico.Telas.GuardarTipoCrm.Carregar.RespostaGuardarTipoCrmCarregar();

            try
            {
                ContratoServico.CRM.BuscarStatusCrm.RespostaBuscarStatusCrm objSaidaStatusCrm = null;
                StatusCrmController objStatusCrmController = new StatusCrmController();

                ContratoServico.TipoCrm.BuscarTipoCrm.RespostaBuscarTipoCrm objSaidaTipoCrm = null;
                TipoCrmController objTipoCrmController = new TipoCrmController();

                Task objTaskStatusCrm = new Task(() => objSaidaStatusCrm = objStatusCrmController.BuscarStatusCrm(new ContratoServico.CRM.BuscarStatusCrm.PeticaoBuscarStatusCrm()
                {
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario
                }));


                Task objTaskTipoCrm = new Task(() => objSaidaTipoCrm = (string.IsNullOrEmpty(Peticao.IdentificadorTipoCrm) ? null : objTipoCrmController.BuscarTipoCrm(new ContratoServico.TipoCrm.BuscarTipoCrm.PeticaoBuscarTipoCrm()
                {
                    Identificador = Peticao.IdentificadorTipoCrm,
                    IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                    Usuario = Peticao.Usuario
                })));

                objTaskStatusCrm.Start();
                objTaskTipoCrm.Start();

                Task.WaitAll(new Task[] { objTaskStatusCrm, objTaskTipoCrm });

                if (objSaidaStatusCrm != null)
                {
                    objSaida.StatusAgrupador = objSaidaStatusCrm.StatusAgrupador;
                }

                if (objSaidaTipoCrm != null)
                {
                    objSaida.TipoCrm = objSaidaTipoCrm.TipoCrm;
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
