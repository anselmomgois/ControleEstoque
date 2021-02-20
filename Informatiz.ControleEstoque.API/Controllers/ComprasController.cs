using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Informatiz.ControleEstoque.API.Entity;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Compra")]
    public class ComprasController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("RecuperarCompras")]
        [Classes.ValidateModel]
        public ContratoServico.Compra.RecuperarCompras.RespostaRecuperarCompras RecuperarCompras(ContratoServico.Compra.RecuperarCompras.PeticaoRecuperarCompras Peticao)
        {

            ContratoServico.Compra.RecuperarCompras.RespostaRecuperarCompras objSaida = new ContratoServico.Compra.RecuperarCompras.RespostaRecuperarCompras();

            try
            {
                if (Peticao.IdentificadorFiliais != null && Peticao.IdentificadorFiliais.Count > 0)
                {

                    IGERENCEEntities objBD = new IGERENCEEntities();
                    string EstadoCompra = (Peticao.EstadoCompra != null ? Peticao.EstadoCompra.RecuperarValor() : null);

                    objSaida.Compras = (from INFM_COMPRA c in objBD.INFM_COMPRA
                                        where Peticao.IdentificadorFiliais.Contains(c.IDFILIAL)
                                              && (Peticao.DataInicio == null || (c.DTHCOMPRA >= Peticao.DataInicio))
                                              && (Peticao.DataFim == null || (c.DTHCOMPRA <= Peticao.DataFim))
                                              && (Peticao.EstadoCompra == null || EstadoCompra == c.CODESTADO)
                                              && (string.IsNullOrEmpty(Peticao.Codigo) || Peticao.Codigo == c.CODCOMPRA)
                                        select new Comum.Clases.Compra
                                        {
                                            CodigoCompra = c.CODCOMPRA,
                                            DataCompra = c.DTHCOMPRA,
                                            Identificador = c.IDCOMPRA,
                                            Fornecedor = (from INFM_PESSOA p in objBD.INFM_PESSOA
                                                          where p.IDPESSOA == c.IDFORNECEDOR
                                                          select new Comum.Clases.Pessoa()
                                                          {
                                                              Identificador = p.IDPESSOA,
                                                              DesNome = p.DESNOME
                                                          }).FirstOrDefault(),
                                            DataRecebimento = (c.DTHRECEBIMENTO != null ? c.DTHRECEBIMENTO : null),
                                            CodigoRastreio = c.CODRASTREIO
                                        }).ToList();

                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar ao menos uma filial");
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
        [Route("RecuperarProdutoCompras")]
        [Classes.ValidateModel]
        public ContratoServico.Compra.RecuperarProdutoCompras.RespostaRecuperarProdutoCompras RecuperarProdutoCompras(ContratoServico.Compra.RecuperarProdutoCompras.PeticaoRecuperarProdutoCompras Peticao)
        {

            ContratoServico.Compra.RecuperarProdutoCompras.RespostaRecuperarProdutoCompras objSaida = new ContratoServico.Compra.RecuperarProdutoCompras.RespostaRecuperarProdutoCompras();

            try
            {
                if (!string.IsNullOrEmpty(Peticao.IdentificadorFilial))
                {

                    IGERENCEEntities objBD = new IGERENCEEntities();
                    string EstadoCompra = Comum.Enumeradores.EstadoCompra.CompraFinalizada.RecuperarValor();

                    objSaida.Produtos = (from INFM_COMPRA c in objBD.INFM_COMPRA
                                         join INFM_DATOSCOMPRAPROD dc in objBD.INFM_DATOSCOMPRAPROD on c.IDCOMPRA equals dc.IDCOMPRA
                                         join INFM_PRODUTOFILIAL pf in objBD.INFM_PRODUTOFILIAL on dc.IDPRODUTOFILIAL equals pf.IDPRODUTOFILIAL
                                         where c.IDFILIAL == Peticao.IdentificadorFilial
                                               && pf.IDPRODUTOSERVICO == Peticao.IdentificadorProdutoServico
                                               && EstadoCompra == c.CODESTADO && dc.NUMESTOQUE > 0
                                         select new Comum.Clases.ProdutoCompra
                                         {
                                             CodigoLote = dc.CODLOTE,
                                             CodigoCompra = c.CODCOMPRA,
                                             DataCompra = c.DTHCOMPRA,
                                             DataValidade = dc.DTHVALIDADE,
                                             Estoque = dc.NUMESTOQUE == null ? 0 : (decimal)dc.NUMESTOQUE,
                                             EstoqueAtual = dc.BOLESTOQUEATUAL == null ? false : (Boolean)dc.BOLESTOQUEATUAL,
                                             Identificador = dc.IDDATOSCOMPRAPROD,
                                             IdentificadorProdutoFilial = dc.IDPRODUTOFILIAL
                                         }).ToList();

                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar a filial");
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
        [Route("SetCompra")]
        [Classes.ValidateModel]
        public ContratoServico.Compra.SetCompra.RespostaSetCompra SetCompra(ContratoServico.Compra.SetCompra.PeticaoSetCompra Peticao)
        {

            ContratoServico.Compra.SetCompra.RespostaSetCompra objSaida = new ContratoServico.Compra.SetCompra.RespostaSetCompra();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                if (Peticao.Compra.Filial != null && !string.IsNullOrEmpty(Peticao.Compra.Filial.Identificador))
                {

                    INFM_COMPRA objCompra = null;

                    if (string.IsNullOrEmpty(Peticao.Compra.Identificador))
                    {
                        Peticao.Compra.Identificador = Guid.NewGuid().ToString();
                        objCompra = new INFM_COMPRA()
                        {
                            CODCOMPRA = Peticao.Compra.CodigoCompra,
                            IDCOMPRA = Peticao.Compra.Identificador,
                            IDEMPRESA = Peticao.IdentificadorEmpresa,
                            IDFILIAL = Peticao.Compra.Filial.Identificador,
                            IDFORNECEDOR = Peticao.Compra.Fornecedor.Identificador,
                            OBSCOMPRA = Peticao.Compra.ObservacaoCompra,
                            CODESTADO = Peticao.Compra.EstadoCompra.RecuperarValor(),
                            CODNOTAFISCAL = Peticao.Compra.CodigoNotaFiscal,
                            CODRASTREIO = Peticao.Compra.CodigoRastreio,
                            DTHCOMPRA = Peticao.Compra.DataCompra,
                            DTHRECEBIMENTO = Peticao.Compra.DataRecebimento,
                            DESESPECIE = Peticao.Compra.Especie,
                            DESMARCA = Peticao.Compra.Marca,
                            NUMBASECALCULO = Peticao.Compra.NumeroBaseCalculo,
                            NUMBASESUBSTITUICAO = Peticao.Compra.NumeroBaseSubstituicao,
                            NUMDESCONTO = Peticao.Compra.NumeroDesconto,
                            NUMFRETE = Peticao.Compra.NumeroValorFrete,
                            NUMICMS = Peticao.Compra.NumeroValorIcms,
                            NUMICMSSUBSTITUICAO = Peticao.Compra.NumeroIcmsSubstituicao,
                            NUMOUTRASDESPESAS = Peticao.Compra.NumeroOutrasDespesas,
                            NUMPESOBRUTO = Peticao.Compra.PesoBruto,
                            NUMPESOLIQUIDO = Peticao.Compra.PesoLiquido,
                            NUMSEGURO = Peticao.Compra.NumeroSeguro,
                            NUMVALORTOTALIPI = Peticao.Compra.NumeroValorIPI,
                            NUMVOLUMES = Peticao.Compra.NumeroVolumes,
                            QTDVOLUMES = Peticao.Compra.QuantidadeVolumes
                        };

                        objBD.INFM_COMPRA.Add(objCompra);
                    }
                    else
                    {
                        objCompra = (from INFM_COMPRA c in objBD.INFM_COMPRA where c.IDCOMPRA == Peticao.Compra.Identificador select c).FirstOrDefault();

                        objCompra.IDFILIAL = Peticao.Compra.Filial.Identificador;
                        objCompra.IDFORNECEDOR = Peticao.Compra.Fornecedor.Identificador;
                        objCompra.OBSCOMPRA = Peticao.Compra.ObservacaoCompra;
                        objCompra.CODESTADO = Peticao.Compra.EstadoCompra.RecuperarValor();
                        objCompra.CODNOTAFISCAL = Peticao.Compra.CodigoNotaFiscal;
                        objCompra.CODRASTREIO = Peticao.Compra.CodigoRastreio;
                        objCompra.DTHCOMPRA = Peticao.Compra.DataCompra;
                        objCompra.DTHRECEBIMENTO = Peticao.Compra.DataRecebimento;
                        objCompra.DESESPECIE = Peticao.Compra.Especie;
                        objCompra.DESMARCA = Peticao.Compra.Marca;
                        objCompra.NUMBASECALCULO = Peticao.Compra.NumeroBaseCalculo;
                        objCompra.NUMBASESUBSTITUICAO = Peticao.Compra.NumeroBaseSubstituicao;
                        objCompra.NUMDESCONTO = Peticao.Compra.NumeroDesconto;
                        objCompra.NUMFRETE = Peticao.Compra.NumeroValorFrete;
                        objCompra.NUMICMS = Peticao.Compra.NumeroValorIcms;
                        objCompra.NUMICMSSUBSTITUICAO = Peticao.Compra.NumeroIcmsSubstituicao;
                        objCompra.NUMOUTRASDESPESAS = Peticao.Compra.NumeroOutrasDespesas;
                        objCompra.NUMPESOBRUTO = Peticao.Compra.PesoBruto;
                        objCompra.NUMPESOLIQUIDO = Peticao.Compra.PesoLiquido;
                        objCompra.NUMSEGURO = Peticao.Compra.NumeroSeguro;
                        objCompra.NUMVALORTOTALIPI = Peticao.Compra.NumeroValorIPI;
                        objCompra.NUMVOLUMES = Peticao.Compra.NumeroVolumes;
                        objCompra.QTDVOLUMES = Peticao.Compra.QuantidadeVolumes;

                        objBD.INFM_PRODUTONUMEROSERIE.RemoveRange(from INFM_PRODUTONUMEROSERIE pns in objBD.INFM_PRODUTONUMEROSERIE
                                                                  join INFM_DATOSCOMPRAPROD pc in objBD.INFM_DATOSCOMPRAPROD on pns.IDDATOSCOMPRAPROD equals pc.IDDATOSCOMPRAPROD
                                                                  where pc.IDCOMPRA == Peticao.Compra.Identificador
                                                                  select pns);

                        objBD.INFM_DATOSCOMPRAPROD.RemoveRange(from INFM_DATOSCOMPRAPROD pc in objBD.INFM_DATOSCOMPRAPROD where pc.IDCOMPRA == Peticao.Compra.Identificador select pc);


                    }

                    if (Peticao.Compra.Produtos != null && Peticao.Compra.Produtos.Count > 0)
                    {
                        INFM_DATOSCOMPRAPROD objProduto = null;
                        INFM_PRODUTONUMEROSERIE objProdutoNumeroSerie = null;

                        foreach (Comum.Clases.ProdutoCompra pc in Peticao.Compra.Produtos)
                        {
                            string IdentificadorProduto = Guid.NewGuid().ToString();
                            objProduto = new INFM_DATOSCOMPRAPROD()
                            {
                                CODLOTE = pc.CodigoLote,
                                DTHVALIDADE = pc.DataValidade,
                                IDCOMPRA = objCompra.IDCOMPRA,
                                IDDATOSCOMPRAPROD = IdentificadorProduto,
                                IDPRODUTOFILIAL = pc.IdentificadorProdutoFilial,
                                IDUNIDADEMEDIDA = (pc.UnidadeMedidaCompra != null ? pc.UnidadeMedidaCompra.Identificador : null),
                                IDUNIDADEMEDIDAVALORCOMPRA = (pc.UnidadeMedidaValorProduto != null ? pc.UnidadeMedidaValorProduto.Identificador : null),
                                NUMESTOQUE = pc.NumeroEstoqueConvertido,
                                NUMUNIDADECOMPRA = pc.NumeroQuantidadeCompra,
                                NUMVALORCOMPRA = pc.ValorCompra,
                                NUMBCICMS = pc.NumeroBcIcms,
                                NUMBCST = pc.NumeroBcSt,
                                NUMCFOP = pc.NumeroCfop,
                                NUMCSTICMS = pc.NumeroCstIcms,
                                NUMCSTIPI = pc.NumeroCstIpi,
                                NUMICMS = pc.NumeroIcms,
                                NUMICMSST = pc.NumeroIcmsSt,
                                NUMIPI = pc.NumeroIpi,
                                NUMPERCENTBCICMS = pc.NumeroPorcentagemBcIcms,
                                NUMPERCENTICMS = pc.NumeroPorcentagemIcms,
                                NUMPERCENTIPI = pc.NumeroPorcentagemIpi
                            };

                            objBD.INFM_DATOSCOMPRAPROD.Add(objProduto);

                            if (pc.NumerosSerie != null && pc.NumerosSerie.Count > 0)
                            {
                                foreach (Comum.Clases.ProdutoNumeroSerie pns in pc.NumerosSerie)
                                {
                                    objProdutoNumeroSerie = new INFM_PRODUTONUMEROSERIE()
                                    {
                                        BOLVENDIDO = false,
                                        DESNUMEROSERIE = pns.NumeroSerie,
                                        IDEMPRESA = Peticao.IdentificadorEmpresa,
                                        IDDATOSCOMPRAPROD = IdentificadorProduto,
                                        IDPRODUTONUMEROSERIE = Guid.NewGuid().ToString()
                                    };

                                    objBD.INFM_PRODUTONUMEROSERIE.Add(objProdutoNumeroSerie);
                                }
                            }

                            if (Peticao.Compra.EstadoCompra == Comum.Enumeradores.EstadoCompra.CompraFinalizada)
                            {
                                INFM_PRODUTOFILIAL objProdutoFilial = null;

                                objProdutoFilial = (from INFM_PRODUTOFILIAL pf in objBD.INFM_PRODUTOFILIAL
                                                    where pf.IDPRODUTOFILIAL == pc.IdentificadorProdutoFilial
                                                    select pf).FirstOrDefault();

                                if (objProdutoFilial != null)
                                {
                                    foreach (INFM_DATOSCOMPRAPROD dc in (from INFM_DATOSCOMPRAPROD dcaux in objBD.INFM_DATOSCOMPRAPROD
                                                                         where dcaux.IDCOMPRA == Peticao.Compra.Identificador
                                                                         select dcaux))
                                    {

                                        if (objBD.INFM_DATOSCOMPRAPROD.Where(dtc => dtc.IDPRODUTOFILIAL == pc.IdentificadorProdutoFilial && dtc.BOLESTOQUEATUAL == true).Count() == 0)
                                        {
                                            dc.BOLESTOQUEATUAL = true;
                                        }
                                    }

                                    if (objProdutoFilial.IDUNIDADEMEDIDAESTOQUE == null)
                                    {
                                        INFM_UNIDADEMEDPRODUTO objUnidadeMediaProduto = (from INFM_PRODUTOSERVICO ps in objBD.INFM_PRODUTOSERVICO
                                                                                         join INFM_UNIDADEMEDPRODUTO ump in objBD.INFM_UNIDADEMEDPRODUTO on ps.IDPRODUTOSERVICO equals ump.IDPRODUTOSERVICO
                                                                                         where ps.IDPRODUTOSERVICO == objProdutoFilial.IDPRODUTOSERVICO
                                                                                         select ump).FirstOrDefault();

                                        if (objUnidadeMediaProduto != null)
                                        {
                                            objProdutoFilial.IDUNIDADEMEDIDAESTOQUE = objUnidadeMediaProduto.IDUNIDADEMEDIDA;
                                        }
                                    }

                                    if (objProdutoFilial.NUMESTOQUE == null)
                                    {
                                        objProdutoFilial.NUMESTOQUE = pc.NumeroEstoqueConvertido;
                                    }
                                    else
                                    {
                                        objProdutoFilial.NUMESTOQUE += pc.NumeroEstoqueConvertido;
                                    }
                                }

                            }


                        }
                    }

                    objSaida.IdentificadorCompra = Peticao.Compra.Identificador;

                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar ao menos uma filial");
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
        [Route("SetEstoqueAtual")]
        [Classes.ValidateModel]
        public ContratoServico.Compra.SetEstoqueAtual.RespostaSetEstoqueAtual SetEstoqueAtual(ContratoServico.Compra.SetEstoqueAtual.PeticaoSetEstoqueAtual Peticao)
        {

            ContratoServico.Compra.SetEstoqueAtual.RespostaSetEstoqueAtual objSaida = new ContratoServico.Compra.SetEstoqueAtual.RespostaSetEstoqueAtual();

            try
            {
                IGERENCEEntities objBD = new IGERENCEEntities();

                List<INFM_DATOSCOMPRAPROD> objProdutos = (from INFM_DATOSCOMPRAPROD pf in objBD.INFM_DATOSCOMPRAPROD
                                                          where pf.IDPRODUTOFILIAL == Peticao.IdentificadorProdutoFilial
                                                          select pf).ToList();

                if (objProdutos != null && objProdutos.Count > 0)
                {
                    objProdutos.ForEach(pf => pf.BOLESTOQUEATUAL = false);


                    INFM_DATOSCOMPRAPROD objProdutoAlterar = (from INFM_DATOSCOMPRAPROD dc in objProdutos
                                                              where dc.IDDATOSCOMPRAPROD == Peticao.IdentificadorItemCompra
                                                              select dc).FirstOrDefault();

                    if (objProdutoAlterar != null)
                    {
                        objProdutoAlterar.BOLESTOQUEATUAL = true;
                    }

                    objBD.SaveChanges();
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
