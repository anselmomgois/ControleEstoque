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
    [RoutePrefix("api/GuardarProdutoServico")]
    public class GuardarProdutoServicoController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarProdutoServico.Carregar.RespostaGuardarProdutoServicoCarregar Carregar(ContratoServico.Telas.GuardarProdutoServico.Carregar.PeticaoGuardarProdutoServicoCarregar Peticao)
        {

            ContratoServico.Telas.GuardarProdutoServico.Carregar.RespostaGuardarProdutoServicoCarregar objSaida = new ContratoServico.Telas.GuardarProdutoServico.Carregar.RespostaGuardarProdutoServicoCarregar();

            try
            {

                IGERENCEEntities objBD = new IGERENCEEntities();

                ContratoServico.Observacao.BuscarObservacao.RespostaBuscarObservacao objRespostaObservacao = null;
                ObservacaoController objObsController = new ObservacaoController();

                Task objTaskListaMarcas = new Task(() => objSaida.Marcas = LogicaNegocio.ProdutoMarca.RecuperarMarcas(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaCores = new Task(() => objSaida.Cores = LogicaNegocio.Cor.RecuperarCores(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaNCMS = new Task(() => objSaida.ProdutosNCMs = LogicaNegocio.ProdutoNCM.PesquisarProdutoNCM(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaCSTS = new Task(() => objSaida.ProdutosCSTs = LogicaNegocio.ProdutoCST.RecuperarCSTs(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaCFOP = new Task(() => objSaida.ProdutosCFOPs = LogicaNegocio.ProdutoCFOP.RecuperarCFOP(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaGrupos = new Task(() => objSaida.GruposProduto = LogicaNegocio.GrupoProduto.RecuperarGrupo(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaUnidadesMedida = new Task(() => objSaida.UnidadesMedida = LogicaNegocio.UnidadeMedida.RecuperarUnidadesMedida(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario, false));

                Task objTaskListaCategorias = new Task(() => objSaida.Categorias = LogicaNegocio.ProdutoCategoria.RecuperarCategorias(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskListaDerivacoes = new Task(() => objSaida.Derivacoes = LogicaNegocio.ProdutoDerivacao.RecuperarDerivacao(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskProtudoServico = new Task(() => objSaida.ProdutoServico = LogicaNegocio.ProdutoServico.RecuperarProdutoServico(Peticao.IdentificadorProdutoServico, Peticao.Usuario));

                Task objTaskTipoProtudo = new Task(() => objSaida.TipoProduto = LogicaNegocio.TipoProdutoServico.RecuperarTipoProdutoServicoComCodigo(Peticao.Usuario, Comum.Clases.Constantes.COD_TIPO_PRODUTO_SERVICO_PROD));

                Task objTaskTipoServico = new Task(() => objSaida.TipoServico = LogicaNegocio.TipoProdutoServico.RecuperarTipoProdutoServicoComCodigo(Peticao.Usuario, Comum.Clases.Constantes.COD_TIPO_PRODUTO_SERVICO_SERV));

                Task objTaskObservacao = new Task(() => objRespostaObservacao = objObsController.BuscarObservacao(new ContratoServico.Observacao.BuscarObservacao.PeticaoBuscarObservacao()
                {IdentificadorEmpresa = Peticao.IdentificadorEmpresa,
                Usuario = Peticao.Usuario}));

                Task objTaskAcrescimos = new Task(() => objSaida.Acrescimos =
                (from INFM_PRODUTOSERVICO ps in objBD.INFM_PRODUTOSERVICO
                 where ps.BOLACRESCIMO == true && ps.IDEMPRESA == Peticao.IdentificadorEmpresa
                 select new Comum.Clases.Acrescimo() { Identificador = ps.IDPRODUTOSERVICO, Descricao = ps.DESPRODUTO }).ToList());


                objTaskObservacao.Start();
                objTaskListaMarcas.Start();
                objTaskListaCores.Start();
                objTaskListaNCMS.Start();
                objTaskListaCSTS.Start();
                objTaskListaCFOP.Start();
                objTaskListaGrupos.Start();
                objTaskListaUnidadesMedida.Start();
                objTaskListaCategorias.Start();
                objTaskListaDerivacoes.Start();
                objTaskProtudoServico.Start();
                objTaskTipoProtudo.Start();
                objTaskTipoServico.Start();
                objTaskAcrescimos.Start();

                Task.WaitAll(new Task[] { objTaskListaMarcas,objTaskListaCores,objTaskListaNCMS,objTaskListaCSTS,objTaskListaCFOP,
                    objTaskListaGrupos,objTaskListaUnidadesMedida,objTaskListaCategorias,objTaskListaDerivacoes,objTaskProtudoServico,objTaskTipoProtudo,objTaskTipoServico,
                    objTaskAcrescimos,objTaskObservacao });

                if(objRespostaObservacao != null)
                {
                    objSaida.Observacoes = objRespostaObservacao.Observacoes;
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
