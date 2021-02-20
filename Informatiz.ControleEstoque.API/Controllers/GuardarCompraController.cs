using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/GuardarCompra")]
    public class GuardarCompraController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("Carregar")]
        [Classes.ValidateModel]
        public ContratoServico.Telas.GuardarCompra.Carregar.RespostaGuardarCompraCarregar Carregar(ContratoServico.Telas.GuardarCompra.Carregar.PeticaoGuardarCompraCarregar Peticao)
        {

            ContratoServico.Telas.GuardarCompra.Carregar.RespostaGuardarCompraCarregar objSaida = new ContratoServico.Telas.GuardarCompra.Carregar.RespostaGuardarCompraCarregar();

            try
            {

                Int64 NumeroCompra = 0;

                Task objTaskListaFiliais = new Task(() => objSaida.Filiais = LogicaNegocio.Filial.RecuperarFiliaisSimples(Peticao.IdentificadorEmpresa, Peticao.Usuario));

                Task objTaskNumeroCompra = new Task(() => NumeroCompra = (string.IsNullOrEmpty(Peticao.IdentificadorCompra) ? AcessoDados.Classes.Sequence.RecuperarProximoNumeroCompra() : 0));

                Task objTaskUnidadeMedida = new Task(() => objSaida.UnidadesMedidas = LogicaNegocio.UnidadeMedida.RecuperarUnidadesMedida(string.Empty, Peticao.IdentificadorEmpresa, Peticao.Usuario, true));

                Task objTaskCompra = new Task(() => objSaida.Compra = RecuperarCompra(Peticao.IdentificadorCompra));

                objTaskListaFiliais.Start();
                objTaskNumeroCompra.Start();
                objTaskUnidadeMedida.Start();
                objTaskCompra.Start();

                Task.WaitAll(new Task[] { objTaskListaFiliais, objTaskNumeroCompra, objTaskUnidadeMedida, objTaskCompra });

                if (NumeroCompra > 0)
                {
                    objSaida.NumeroCompra = string.Format("{0}{1}", "IG", NumeroCompra.ToString().PadLeft(15, Convert.ToChar("0")));
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

        private Comum.Clases.Compra RecuperarCompra(string Identificador)
        {
            Comum.Clases.Compra objCompra = null;
            if (!string.IsNullOrEmpty(Identificador))
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                objCompra = (from INFM_COMPRA c in objBD.INFM_COMPRA
                             where c.IDCOMPRA == Identificador
                             select new Comum.Clases.Compra()
                             {
                                 CodigoCompra = c.CODCOMPRA,
                                 CodigoRastreio = c.CODRASTREIO,
                                 CodigoNotaFiscal = c.CODNOTAFISCAL,
                                 DataCompra = c.DTHCOMPRA,
                                 DataRecebimento = c.DTHRECEBIMENTO,
                                 Filial = new Comum.Clases.Filiais { Identificador = c.IDFILIAL },
                                 NumeroBaseCalculo = (c.NUMBASECALCULO != null ? (decimal)c.NUMBASECALCULO : 0),
                                 NumeroBaseSubstituicao = (c.NUMBASESUBSTITUICAO != null ? (decimal)c.NUMBASESUBSTITUICAO : 0),
                                 NumeroDesconto = (c.NUMDESCONTO != null ? (decimal)c.NUMDESCONTO : 0),
                                 NumeroIcmsSubstituicao = (c.NUMICMSSUBSTITUICAO != null ? (decimal)c.NUMICMSSUBSTITUICAO : 0),
                                 NumeroOutrasDespesas = (c.NUMOUTRASDESPESAS != null ? (decimal)c.NUMOUTRASDESPESAS : 0),
                                 NumeroSeguro = (c.NUMSEGURO != null ? (decimal)c.NUMSEGURO : 0),
                                 NumeroValorFrete = (c.NUMFRETE != null ? (decimal)c.NUMFRETE : 0),
                                 NumeroValorIcms = (c.NUMICMS != null ? (decimal)c.NUMICMS : 0),
                                 NumeroValorIPI = (c.NUMVALORTOTALIPI != null ? (decimal)c.NUMVALORTOTALIPI : 0),
                                 Especie = c.DESESPECIE,
                                 Marca = c.DESMARCA,
                                 NumeroVolumes = (c.NUMVOLUMES != null ? (Int32)c.NUMVOLUMES : 0),
                                 PesoBruto = (c.NUMPESOBRUTO != null ? (decimal)c.NUMPESOBRUTO : 0),
                                 PesoLiquido = (c.NUMPESOLIQUIDO != null ? (decimal)c.NUMPESOLIQUIDO : 0),
                                 QuantidadeVolumes = (c.NUMVOLUMES != null ? (Int32)c.NUMVOLUMES : 0),
                                 EstadoCompra = (!string.IsNullOrEmpty(c.CODESTADO) ? (c.CODESTADO == "CG" ?
                                                                                       Comum.Enumeradores.EstadoCompra.CompraGerada :
                                                                                       (c.CODESTADO == "OE" ?
                                                                                        Comum.Enumeradores.EstadoCompra.OrdemEmitida : Comum.Enumeradores.EstadoCompra.CompraFinalizada)) : Comum.Enumeradores.EstadoCompra.CompraGerada),
                                 Identificador = c.IDCOMPRA,
                                 ObservacaoCompra = c.OBSCOMPRA,
                                 Fornecedor = (from INFM_PESSOA p in objBD.INFM_PESSOA
                                               where p.IDPESSOA == c.IDFORNECEDOR
                                               select new Comum.Clases.Pessoa()
                                               {
                                                   Identificador = p.IDPESSOA,
                                                   DesNome = p.DESNOME,
                                                   Codigo = p.CODPESSOA
                                               }).FirstOrDefault(),
                                 Produtos = (from INFM_DATOSCOMPRAPROD dc in objBD.INFM_DATOSCOMPRAPROD
                                             join INFM_PRODUTOFILIAL pf in objBD.INFM_PRODUTOFILIAL on dc.IDPRODUTOFILIAL equals pf.IDPRODUTOFILIAL
                                             join INFM_PRODUTOSERVICO ps in objBD.INFM_PRODUTOSERVICO on pf.IDPRODUTOSERVICO equals ps.IDPRODUTOSERVICO
                                             join INFM_UNIDADEMEDIDA umc in objBD.INFM_UNIDADEMEDIDA on dc.IDUNIDADEMEDIDA equals umc.IDUNIDADEMEDIDA
                                             join INFM_UNIDADEMEDIDA umvc in objBD.INFM_UNIDADEMEDIDA on dc.IDUNIDADEMEDIDAVALORCOMPRA equals umvc.IDUNIDADEMEDIDA
                                             where dc.IDCOMPRA == c.IDCOMPRA
                                             select new Comum.Clases.ProdutoCompra()
                                             {
                                                 CodigoLote = dc.CODLOTE,
                                                 DataValidade = dc.DTHVALIDADE,
                                                 Estoque = dc.NUMESTOQUE == null ? 0 : (decimal)dc.NUMESTOQUE,
                                                 Identificador = dc.IDDATOSCOMPRAPROD,
                                                 IdentificadorProdutoFilial = pf.IDPRODUTOFILIAL,
                                                 NumeroBcIcms = (dc.NUMBCICMS != null ? (decimal)dc.NUMBCICMS : 0),
                                                 NumeroBcSt = (dc.NUMBCST != null ? (decimal)(dc.NUMBCST) : 0),
                                                 NumeroCfop = (dc.NUMCFOP != null ? (decimal)(dc.NUMCFOP) : 0),
                                                 NumeroCstIcms = (dc.NUMCSTICMS != null ? (decimal)(dc.NUMCSTICMS) : 0),
                                                 NumeroCstIpi = (dc.NUMCSTIPI != null ? (decimal)(dc.NUMCSTIPI) : 0),
                                                 NumeroIcms = (dc.NUMICMS != null ? (decimal)(dc.NUMICMS) : 0),
                                                 NumeroIcmsSt = (dc.NUMICMSST != null ? (decimal)(dc.NUMICMSST) : 0),
                                                 NumeroIpi = (dc.NUMIPI != null ? (decimal)(dc.NUMIPI) : 0),
                                                 NumeroPorcentagemBcIcms = (dc.NUMPERCENTBCICMS != null ? (decimal)(dc.NUMPERCENTBCICMS) : 0),
                                                 NumeroPorcentagemIcms = (dc.NUMPERCENTICMS != null ? (decimal)(dc.NUMPERCENTICMS) : 0),
                                                 NumeroPorcentagemIpi = (dc.NUMPERCENTIPI != null ? (decimal)(dc.NUMPERCENTIPI) : 0),
                                                 NumeroQuantidadeCompra = dc.NUMUNIDADECOMPRA == null ? 0 : (decimal)dc.NUMUNIDADECOMPRA,
                                                 UnidadeMedidaCompra = new Comum.Clases.UnidadeMedida()
                                                 {
                                                     Identificador = dc.IDUNIDADEMEDIDA,
                                                     Codigo = umc.CODUNIDADEMEDIDA,
                                                     Descricao = umc.DESUNIDADEMEDIDA
                                                 },
                                                 UnidadeMedidaValorProduto = new Comum.Clases.UnidadeMedida()
                                                 {
                                                     Identificador = dc.IDUNIDADEMEDIDAVALORCOMPRA,
                                                     Codigo = umvc.CODUNIDADEMEDIDA,
                                                     Descricao = umvc.DESUNIDADEMEDIDA
                                                 },
                                                 ValorCompra = dc.NUMVALORCOMPRA,
                                                 Produto = new Comum.Clases.ProdutoServico()
                                                 {
                                                     Identificador = ps.IDPRODUTOSERVICO,
                                                     Codigo = ps.CODPRODUTO,
                                                     CodigosBarras = (from INFM_CODIGOBARRASPRODSERV cb in objBD.INFM_CODIGOBARRASPRODSERV 
                                                                      where cb.IDPRODUTOSERVICO == ps.IDPRODUTOSERVICO
                                                                      select new Comum.Clases.ProdutoServicoCodigoBarras()
                                                                      {
                                                                          CodigoBarras = cb.DESCODBARRAS,
                                                                          Identficador = cb.IDCODIGOBARRASPRODSERV
                                                                      }).ToList(),
                                                     Descricao = ps.DESPRODUTO,
                                                     VendaPorNumeroSerie = (Boolean)(ps.BOLVENDANUMEROSERIE == null ? false : ps.BOLVENDANUMEROSERIE)
                                                 },
                                                 NumerosSerie = (from INFM_PRODUTONUMEROSERIE pns in objBD.INFM_PRODUTONUMEROSERIE
                                                                 where pns.IDDATOSCOMPRAPROD == dc.IDDATOSCOMPRAPROD
                                                                 select new Comum.Clases.ProdutoNumeroSerie()
                                                                 {
                                                                     Identificador = pns.IDPRODUTONUMEROSERIE,
                                                                     NumeroSerie = pns.DESNUMEROSERIE,
                                                                     Vendido = pns.BOLVENDIDO
                                                                 }).ToList()

                                             }).ToList()
                             }).FirstOrDefault();
            }


            return objCompra;
        }

        private static Comum.Enumeradores.EstadoCompra TraduzirEstado(string CodigoEstado)
        {

            return Comum.Extencoes.EnumExtension.RecuperarEnum<Comum.Enumeradores.EstadoCompra>(CodigoEstado);
        }
    }
}
