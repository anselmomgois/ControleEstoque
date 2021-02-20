using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GrupoProduto")]
    public class GrupoProdutoController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("RecuperarGruposProduto")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoProduto.RecuperarGruposProduto.RespostaRecuperarGruposCompromisso RecuperarGruposProduto(ContratoServico.GrupoProduto.RecuperarGruposProduto.PeticaoRecuperarGruposProduto Peticao)
        {

            ContratoServico.GrupoProduto.RecuperarGruposProduto.RespostaRecuperarGruposCompromisso objSaida = new ContratoServico.GrupoProduto.RecuperarGruposProduto.RespostaRecuperarGruposCompromisso();

            try
            {

                objSaida.GruposProdutos = LogicaNegocio.GrupoProduto.RecuperarGrupo(Peticao.Descricao, Peticao.IdentificadorEmpresa,Peticao.Usuario); 

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
        [Route("DeletarGrupoProduto")]
        [Classes.ValidateModel]
        public ContratoServico.GrupoProduto.DeletarGrupoProduto.RespostaDeletarGrupoProduto DeletarGrupoProduto(ContratoServico.GrupoProduto.DeletarGrupoProduto.PeticaoDeletarGrupoProduto Peticao)
        {

            ContratoServico.GrupoProduto.DeletarGrupoProduto.RespostaDeletarGrupoProduto objSaida = new ContratoServico.GrupoProduto.DeletarGrupoProduto.RespostaDeletarGrupoProduto();

            try
            {

                LogicaNegocio.GrupoProduto.DeletarGrupoProduto(Peticao.IdentificadorGrupoProduto, Peticao.Usuario);

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
