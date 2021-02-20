using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/SegmentoComercial")]
    public class SegmentoComercialController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("PesquisarSegmentoComercial")]
        [Classes.ValidateModel]
        public ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.RespostaPesquisarSegmentoComercial PesquisarSegmentoComercial(ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.PeticaoPesquisarSegmentoComercial Peticao)
        {
            ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.RespostaPesquisarSegmentoComercial objSaida = new ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.RespostaPesquisarSegmentoComercial();

            try
            {

                objSaida.SegmentoComercias = LogicaNegocio.SegmentoComercial.PesquisarSegmentoComercial(Peticao.Usuario,Peticao.Identificador,Peticao.IdentificadorEmpresa,Peticao.Descricao);

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
        [Route("DeletarSegmentoComercial")]
        [Classes.ValidateModel]
        public ContratoServico.SegmentoComercial.DeletarSegmentoComercial.RespostaDeletarSegmentoComercial DeletarSegmentoComercial(ContratoServico.SegmentoComercial.DeletarSegmentoComercial.PeticaoDeletarSegmentoComercial Peticao)
        {
            ContratoServico.SegmentoComercial.DeletarSegmentoComercial.RespostaDeletarSegmentoComercial objSaida = new ContratoServico.SegmentoComercial.DeletarSegmentoComercial.RespostaDeletarSegmentoComercial();

            try
            {

                LogicaNegocio.SegmentoComercial.DeletarSegmentoComercial(Peticao.Identificador, Peticao.Usuario);

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
        [Route("RecuperarSegmentoComercial")]
        [Classes.ValidateModel]
        public ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.RespostaRecuperarSegmentoComercial RecuperarSegmentoComercial(ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.PeticaoRecuperarSegmentoComercial Peticao)
        {
            ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.RespostaRecuperarSegmentoComercial objSaida = new ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.RespostaRecuperarSegmentoComercial();

            try
            {

              objSaida.SegmentoComercial =   LogicaNegocio.SegmentoComercial.RecuperarSegmentoComercial(Peticao.Identificador, Peticao.Usuario);

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
        [Route("SetSegmentoComercial")]
        [Classes.ValidateModel]
        public ContratoServico.SegmentoComercial.SetSegmentoComercial.RespostaSetSegmentoComercial SetSegmentoComercial(ContratoServico.SegmentoComercial.SetSegmentoComercial.PeticaoRecuperarSetSegmentoComercial Peticao)
        {
            ContratoServico.SegmentoComercial.SetSegmentoComercial.RespostaSetSegmentoComercial objSaida = new ContratoServico.SegmentoComercial.SetSegmentoComercial.RespostaSetSegmentoComercial();

            try
            {

                if (string.IsNullOrEmpty(Peticao.SegmentoComercial.Identificador))
                {
                    LogicaNegocio.SegmentoComercial.InserirSegmentoComercial(Peticao.SegmentoComercial,Peticao.IdentificadorEmpresa, Peticao.Usuario);
                }
                else
                {
                    LogicaNegocio.SegmentoComercial.AtualizarSegmentoComercial(Peticao.SegmentoComercial, Peticao.Usuario);
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
