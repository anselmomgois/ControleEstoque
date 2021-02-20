using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoServico
    {

        public static List<Comum.Clases.ProdutoServico> RecuperarProdutosServicos(string Descricao, Nullable<Int32> Codigo, string CodigoBarras,
                                                                                  string IdentificadorEmpresa, string CodigoTipoProduto,
                                                                                  string IdentificadorFilial, Boolean RecuperarUnidadesMedida,
                                                                                  Boolean RecuperarImagensProduto)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoServico> objProdutosServicos = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND PS.DESPRODUTO LIKE @DESPRODUTO ";
                objSql.AdicionarParametro("DESPRODUTO", "%" + Descricao.ToUpper() + "%");
            }

            if (Codigo != null)
            {
                objQuery = " AND PS.CODPRODUTO = @CODPRODUTO ";
                objSql.AdicionarParametro("CODPRODUTO", Codigo);
            }

            if (!string.IsNullOrEmpty(CodigoBarras))
            {
                objQuery = " AND CB.DESCODBARRAS = @DESCODBARRAS ";
                objSql.AdicionarParametro("DESCODBARRAS", CodigoBarras);
            }

            if (!string.IsNullOrEmpty(CodigoTipoProduto))
            {
                objQuery = " AND TP.CODTIPOPRODUTO = @CODTIPOPRODUTO ";
                objSql.AdicionarParametro("CODTIPOPRODUTO", CodigoTipoProduto);
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            string QueryPrincipal = Properties.Resources.ProdutoServicoPesquisar + objQuery;
            string CamposAdicionais = string.Empty;

            if (RecuperarImagensProduto)
            {
                CamposAdicionais = " ,PS.BITIMGPRODUTO ";
            }

            if (string.IsNullOrEmpty(IdentificadorFilial) && !RecuperarUnidadesMedida)
            {
                QueryPrincipal = string.Format(QueryPrincipal, CamposAdicionais, string.Empty);
            }
            else
            {
                if (!string.IsNullOrEmpty(IdentificadorFilial) && RecuperarUnidadesMedida)
                {
                    CamposAdicionais += " ,PF.IDPRODUTOFILIAL ,UM.IDUNIDADEMEDIDA ";

                    QueryPrincipal = string.Format(QueryPrincipal, CamposAdicionais, " INNER JOIN INFM_PRODUTOFILIAL PF ON PF.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO INNER JOIN INFM_UNIDADEMEDPRODUTO UM ON UM.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO ");
                    QueryPrincipal += " AND PF.IDFILIAL = @IDFILIAL ";
                    objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
                }
                else if (!string.IsNullOrEmpty(IdentificadorFilial))
                {
                    CamposAdicionais += " ,PF.IDPRODUTOFILIAL ";

                    QueryPrincipal = string.Format(QueryPrincipal, CamposAdicionais, " INNER JOIN INFM_PRODUTOFILIAL PF ON PF.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO ");
                    QueryPrincipal += " AND PF.IDFILIAL = @IDFILIAL ";
                    objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
                }
                else
                {
                    CamposAdicionais += " ,UM.IDUNIDADEMEDIDA ";
                    QueryPrincipal = string.Format(QueryPrincipal, CamposAdicionais, " INNER JOIN INFM_UNIDADEMEDPRODUTO UM ON UM.IDPRODUTOSERVICO = PS.IDPRODUTOSERVICO ");

                }


            }

            DataTable dt = objSql.ExecutarDataTableArquivo(QueryPrincipal, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutosServicos = new List<Comum.Clases.ProdutoServico>();
                Comum.Clases.ProdutoServico objProdutoServico = null;
                string IdentificadorCodigoBarras = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    objProdutoServico = (from Comum.Clases.ProdutoServico ps in objProdutosServicos
                                         where ps.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string
                                         select ps).FirstOrDefault();

                    if (objProdutoServico == null)
                    {
                        objProdutosServicos.Add(new Comum.Clases.ProdutoServico
                        {
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string,
                            Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTO"], typeof(Int32))),
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTO"], typeof(string)) as string,
                            Acrescimo = (Boolean)frmUtil.Util.AtribuirValorObj(dr["BOLACRESCIMO"], typeof(Boolean)),
                            ProdutoInterno = (Boolean)frmUtil.Util.AtribuirValorObj(dr["BOLINTERNO"], typeof(Boolean)),
                            VendaAGranel = (Boolean)frmUtil.Util.AtribuirValorObj(dr["BOLVENDAAGRANEL"], typeof(Boolean)),
                            VendaPorNumeroSerie = (Boolean)frmUtil.Util.AtribuirValorObj(dr["BOLVENDANUMEROSERIE"], typeof(Boolean)),
                            ImgProduto = (RecuperarImagensProduto ? (byte[])(frmUtil.Util.AtribuirValorObj(dr["BITIMGPRODUTO"], typeof(byte[]))) : null),
                            IdentificadorProdutoFilial = (string.IsNullOrEmpty(IdentificadorFilial) ? string.Empty : frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOFILIAL"], typeof(string)) as string),
                            UnidadesMedida = (RecuperarUnidadesMedida ? (new List<Comum.Clases.UnidadeMedida>() { new Comum.Clases.UnidadeMedida() { Identificador = frmUtil.Util.AtribuirValorObj(dr["IDUNIDADEMEDIDA"], typeof(string)) as string } }) : null)
                        });

                        objProdutoServico = objProdutosServicos.LastOrDefault();
                    }

                    IdentificadorCodigoBarras = frmUtil.Util.AtribuirValorObj(dr["IDCODIGOBARRASPRODSERV"], typeof(string)) as string;

                    if (!string.IsNullOrEmpty(IdentificadorCodigoBarras))
                    {
                        if (objProdutoServico.CodigosBarras == null) { objProdutoServico.CodigosBarras = new List<Comum.Clases.ProdutoServicoCodigoBarras>(); }

                        objProdutoServico.CodigosBarras.Add(new Comum.Clases.ProdutoServicoCodigoBarras()
                        {
                            CodigoBarras = frmUtil.Util.AtribuirValorObj(dr["DESCODBARRAS"], typeof(string)) as string,
                            Identficador = frmUtil.Util.AtribuirValorObj(dr["IDCODIGOBARRASPRODSERV"], typeof(string)) as string
                        });
                    }
                }
            }

            return objProdutosServicos;
        }

        public static string InserirProdutoServico(Comum.Clases.ProdutoServico objProdutoServico, string IdentificadorEmpresa, ref Sql objSql)
        {

            string IdentificadorProdutoServico = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);
            objSql.AdicionarParametro("DESPRODUTO", objProdutoServico.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            if (!string.IsNullOrEmpty(objProdutoServico.Observacao))
            {
                objSql.AdicionarParametro("OBSPRODUTO", objProdutoServico.Observacao);
            }
            else
            {
                objSql.AdicionarParametro("OBSPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.TipoProdutoServico != null && !string.IsNullOrEmpty(objProdutoServico.TipoProdutoServico.Identificador))
            {
                objSql.AdicionarParametro("IDTIPOPRODUTO", objProdutoServico.TipoProdutoServico.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDTIPOPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.GrupoProduto != null && !string.IsNullOrEmpty(objProdutoServico.GrupoProduto.Identificador))
            {
                objSql.AdicionarParametro("IDGRUPOPRODUTO", objProdutoServico.GrupoProduto.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDGRUPOPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.Cor != null && !string.IsNullOrEmpty(objProdutoServico.Cor.Identificador))
            {
                objSql.AdicionarParametro("IDCOR", objProdutoServico.Cor.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDCOR", DBNull.Value);
            }

            if (objProdutoServico.ProdutoDerivacao != null && !string.IsNullOrEmpty(objProdutoServico.ProdutoDerivacao.Identificador))
            {
                objSql.AdicionarParametro("IDPRODUTODERIVACAO", objProdutoServico.ProdutoDerivacao.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTODERIVACAO", DBNull.Value);
            }

            if (objProdutoServico.ProdutoCategoria != null && !string.IsNullOrEmpty(objProdutoServico.ProdutoCategoria.Identificador))
            {
                objSql.AdicionarParametro("IDPRODCATEGORIA", objProdutoServico.ProdutoCategoria.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODCATEGORIA", DBNull.Value);
            }

            if (objProdutoServico.ProdutoMarca != null && !string.IsNullOrEmpty(objProdutoServico.ProdutoMarca.Identificador))
            {
                objSql.AdicionarParametro("IDPRODUTOMARCA", objProdutoServico.ProdutoMarca.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOMARCA", DBNull.Value);
            }

            if (objProdutoServico.Peso != null)
            {
                objSql.AdicionarParametro("NUMPESOPRODUTO", objProdutoServico.Peso);
            }
            else
            {
                objSql.AdicionarParametro("NUMPESOPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.ProdutoNCM != null)
            {
                objSql.AdicionarParametro("IDPRODUTONCM", objProdutoServico.ProdutoNCM.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTONCM", DBNull.Value);
            }

            if (objProdutoServico.ProdutoCST != null)
            {
                objSql.AdicionarParametro("IDPRODUTOCST", objProdutoServico.ProdutoCST.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOCST", DBNull.Value);
            }

            if (objProdutoServico.ProdutoCFOP != null)
            {
                objSql.AdicionarParametro("IDPRODUTOCFOP", objProdutoServico.ProdutoCFOP.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOCFOP", DBNull.Value);
            }

            objSql.AdicionarParametro("BOLVENDAAGRANEL", objProdutoServico.VendaAGranel);
            objSql.AdicionarParametro("BOLINTERNO", objProdutoServico.ProdutoInterno);
            objSql.AdicionarParametro("BOLACRESCIMO", objProdutoServico.Acrescimo);
            objSql.AdicionarParametro("BOLVENDANUMEROSERIE", objProdutoServico.VendaPorNumeroSerie);

            string objQueryCampo = string.Empty;
            string objQueryValor = string.Empty;

            if (objProdutoServico.ImgProduto != null)
            {
                objQueryCampo = " ,BITIMGPRODUTO ";
                objQueryValor = " ,@BITIMGPRODUTO ";
                objSql.AdicionarParametro("BITIMGPRODUTO", objProdutoServico.ImgProduto);
            }

            objSql.AdicionarTransacao(string.Format(Properties.Resources.ProdutoServicoInserir, objQueryCampo, objQueryValor));

            return IdentificadorProdutoServico;
        }

        public static void InserirCodigoBarras(string CodigoBarras, string IdentificadorEmpresa,
                                               string IdentificadorProdutoServico, ref Sql objSql)
        {
            objSql.AdicionarParametro("IDCODIGOBARRASPRODSERV", Guid.NewGuid().ToString(), true);
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("DESCODBARRAS", CodigoBarras);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoInserirCodigoBarras);
        }

        public static void InserirAcrescimo(string IdentificadorProdutoServico, string IdentificadorAcrescimo, ref Sql objSql)
        {
            objSql.AdicionarParametro("IDACRESCIMOPRODUTO", Guid.NewGuid().ToString(), true);
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);
            objSql.AdicionarParametro("IDACRESCIMO", IdentificadorAcrescimo);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoInserirAcrescimo);
        }

        public static void InserirObservacoesProduto(string IdentificadorProdutoServico, string IdentificadorObservacao, ref Sql objSql)
        {
            objSql.AdicionarParametro("IDOBSERVACAOPRODUTO", Guid.NewGuid().ToString(), true);
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);
            objSql.AdicionarParametro("IDOBSERVACAO", IdentificadorObservacao);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoInserirObservacao);
        }

        public static void DeletarAcrescimo(string IdentificadorProdutoServico, ref Sql objSql)
        {
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoDeletarAcrescimo);
        }

        public static void DeletarObservacao(string IdentificadorProdutoServico, ref Sql objSql)
        {
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoDeletarObservacao);
        }

        public static void DeletarCodigoBarras(string IdentificadorProdutoServico, ref Sql objSql)
        {
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico, true);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoDeletarCodigoBarras);
        }

        public static void AtualizarProdutoServico(Comum.Clases.ProdutoServico objProdutoServico, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPRODUTOSERVICO", objProdutoServico.Identificador);
            objSql.AdicionarParametro("DESPRODUTO", objProdutoServico.Descricao.ToUpper());


            if (!string.IsNullOrEmpty(objProdutoServico.Observacao))
            {
                objSql.AdicionarParametro("OBSPRODUTO", objProdutoServico.Observacao);
            }
            else
            {
                objSql.AdicionarParametro("OBSPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.TipoProdutoServico != null && !string.IsNullOrEmpty(objProdutoServico.TipoProdutoServico.Identificador))
            {
                objSql.AdicionarParametro("IDTIPOPRODUTO", objProdutoServico.TipoProdutoServico.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDTIPOPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.GrupoProduto != null && !string.IsNullOrEmpty(objProdutoServico.GrupoProduto.Identificador))
            {
                objSql.AdicionarParametro("IDGRUPOPRODUTO", objProdutoServico.GrupoProduto.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDGRUPOPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.Cor != null && !string.IsNullOrEmpty(objProdutoServico.Cor.Identificador))
            {
                objSql.AdicionarParametro("IDCOR", objProdutoServico.Cor.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDCOR", DBNull.Value);
            }

            if (objProdutoServico.ProdutoDerivacao != null && !string.IsNullOrEmpty(objProdutoServico.ProdutoDerivacao.Identificador))
            {
                objSql.AdicionarParametro("IDPRODUTODERIVACAO", objProdutoServico.ProdutoDerivacao.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTODERIVACAO", DBNull.Value);
            }

            if (objProdutoServico.ProdutoCategoria != null && !string.IsNullOrEmpty(objProdutoServico.ProdutoCategoria.Identificador))
            {
                objSql.AdicionarParametro("IDPRODCATEGORIA", objProdutoServico.ProdutoCategoria.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODCATEGORIA", DBNull.Value);
            }

            if (objProdutoServico.ProdutoMarca != null && !string.IsNullOrEmpty(objProdutoServico.ProdutoMarca.Identificador))
            {
                objSql.AdicionarParametro("IDPRODUTOMARCA", objProdutoServico.ProdutoMarca.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOMARCA", DBNull.Value);
            }

            if (objProdutoServico.Peso != null)
            {
                objSql.AdicionarParametro("NUMPESOPRODUTO", objProdutoServico.Peso);
            }
            else
            {
                objSql.AdicionarParametro("NUMPESOPRODUTO", DBNull.Value);
            }

            if (objProdutoServico.ProdutoNCM != null)
            {
                objSql.AdicionarParametro("IDPRODUTONCM", objProdutoServico.ProdutoNCM.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTONCM", DBNull.Value);
            }

            if (objProdutoServico.ProdutoCST != null)
            {
                objSql.AdicionarParametro("IDPRODUTOCST", objProdutoServico.ProdutoCST.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOCST", DBNull.Value);
            }

            if (objProdutoServico.ProdutoCFOP != null)
            {
                objSql.AdicionarParametro("IDPRODUTOCFOP", objProdutoServico.ProdutoCFOP.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOCFOP", DBNull.Value);
            }

            objSql.AdicionarParametro("BOLVENDAAGRANEL", objProdutoServico.VendaAGranel);
            objSql.AdicionarParametro("BOLINTERNO", objProdutoServico.ProdutoInterno);
            objSql.AdicionarParametro("BOLACRESCIMO", objProdutoServico.Acrescimo);
            objSql.AdicionarParametro("BOLVENDANUMEROSERIE", objProdutoServico.VendaPorNumeroSerie);

            string Query = string.Empty;

            if (objProdutoServico.ImgProduto != null)
            {
                Query = " ,BITIMGPRODUTO = @BITIMGPRODUTO ";
                objSql.AdicionarParametro("BITIMGPRODUTO", objProdutoServico.ImgProduto);
            }

            objSql.AdicionarTransacao(string.Format(Properties.Resources.ProdutoServicoAtualizar, Query));
        }

        public static void DeletarProdutoServico(string IdentificadorProdutoServico, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoDeletar);
        }

        public static Boolean ProdutoServicoEstaSendoUsuado(string IdentificadorProdutoServico)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.ProdutoServicoEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.ProdutoServico RecuperarProdutoServico(string IdentificadorProdutoServico)
        {
            Sql objSql = new Sql();
            Comum.Clases.ProdutoServico objProdutoServico = null;

            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoServicoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                string IdentificadorCodigoBarras = string.Empty;
                string IdentificadorAcrescimo = string.Empty;
                string IdentificadorObservacao = string.Empty;

                objProdutoServico = new Comum.Clases.ProdutoServico()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOSERVICO"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTO"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTO"], typeof(string)) as string,
                    Cor = Cor.RecuperarCor(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDCOR"], typeof(string)) as string),
                    ProdutoNCM = ProdutoNCM.RecuperarProdutoNCM(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTONCM"], typeof(string)) as string),
                    GrupoProduto = GrupoProduto.RecuperarGrupoProduto(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOPRODUTO"], typeof(string)) as string),
                    ImgProduto = (byte[])(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BITIMGPRODUTO"], typeof(byte[]))),
                    Observacao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["OBSPRODUTO"], typeof(string)) as string,
                    Peso = (Decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPESOPRODUTO"], typeof(Decimal))),
                    ProdutoCategoria = ProdutoCategoria.RecuperarProdutoCategoria(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODCATEGORIA"], typeof(string)) as string),
                    ProdutoDerivacao = ProdutoDerivacao.RecuperarProdutoDerivacao(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTODERIVACAO"], typeof(string)) as string),
                    ProdutoMarca = ProdutoMarca.RecuperarProdutoMarca(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOMARCA"], typeof(string)) as string),
                    ProdutoCST = ProdutoCST.RecuperarProdutoCST(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCST"], typeof(string)) as string),
                    ProdutoCFOP = ProdutoCFOP.RecuperarProdutoCFOP(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCFOP"], typeof(string)) as string),
                    UnidadesMedida = UnidadesMedida.RecuperarUnidadesMedidaProduto(IdentificadorProdutoServico),
                    TipoProdutoServico = TipoProdutoServico.RecuperarTipoProdutoServico(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDTIPOPRODUTO"], typeof(string)) as string),
                    Acrescimo = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLACRESCIMO"], typeof(Boolean))),
                    ProdutoInterno = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLINTERNO"], typeof(Boolean))),
                    VendaAGranel = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLVENDAAGRANEL"], typeof(Boolean))),
                    VendaPorNumeroSerie = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLVENDANUMEROSERIE"], typeof(Boolean)))

                };

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorCodigoBarras = frmUtil.Util.AtribuirValorObj(dr["IDCODIGOBARRASPRODSERV"], typeof(string)) as string;
                    IdentificadorAcrescimo = frmUtil.Util.AtribuirValorObj(dr["IDACRESCIMO"], typeof(string)) as string;
                    IdentificadorObservacao = frmUtil.Util.AtribuirValorObj(dr["IDOBSERVACAO"], typeof(string)) as string;

                    if (!string.IsNullOrEmpty(IdentificadorCodigoBarras) && ((objProdutoServico.CodigosBarras == null || objProdutoServico.CodigosBarras.Count == 0) ||
                        (objProdutoServico.CodigosBarras != null && !objProdutoServico.CodigosBarras.Exists(cb => cb.Identficador.Equals(IdentificadorCodigoBarras)))))
                    {

                        if (objProdutoServico.CodigosBarras == null) { objProdutoServico.CodigosBarras = new List<Comum.Clases.ProdutoServicoCodigoBarras>(); }

                        objProdutoServico.CodigosBarras.Add(new Comum.Clases.ProdutoServicoCodigoBarras()
                        {
                            CodigoBarras = frmUtil.Util.AtribuirValorObj(dr["DESCODBARRAS"], typeof(string)) as string,
                            Identficador = IdentificadorCodigoBarras
                        });
                    }

                    if (!string.IsNullOrEmpty(IdentificadorAcrescimo) && ((objProdutoServico.Acrescimos == null || objProdutoServico.Acrescimos.Count == 0) ||
                        (objProdutoServico.Acrescimos != null && !objProdutoServico.Acrescimos.Exists(cb => cb.Identificador.Equals(IdentificadorAcrescimo)))))
                    {

                        if (objProdutoServico.Acrescimos == null) { objProdutoServico.Acrescimos = new List<Comum.Clases.Acrescimo>(); }

                        objProdutoServico.Acrescimos.Add(new Comum.Clases.Acrescimo()
                        {
                            Identificador = IdentificadorAcrescimo
                        });
                    }

                    if (!string.IsNullOrEmpty(IdentificadorObservacao) && ((objProdutoServico.ObservacoesProduto == null || objProdutoServico.ObservacoesProduto.Count == 0) ||
                        (objProdutoServico.ObservacoesProduto != null && !objProdutoServico.ObservacoesProduto.Exists(cb => cb.Identificador.Equals(IdentificadorObservacao)))))
                    {

                        if (objProdutoServico.ObservacoesProduto == null) { objProdutoServico.ObservacoesProduto = new List<Comum.Clases.ProdutoObservacao>(); }

                        objProdutoServico.ObservacoesProduto.Add(new Comum.Clases.ProdutoObservacao()
                        {
                            Identificador = IdentificadorObservacao
                        });
                    }


                }

            }

            return objProdutoServico;
        }

        public static Comum.Clases.ProdutoServico RecuperarProdutoServicoPorFilial(string IdentificadorProdutoFilial)
        {
            Sql objSql = new Sql();
            Comum.Clases.ProdutoServico objProdutoServico = null;

            objSql.AdicionarParametro("IDPRODUTOFILIAL", IdentificadorProdutoFilial);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoServicoRecuperarPorFilial, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoServico = new Comum.Clases.ProdutoServico()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOSERVICO"], typeof(string)) as string,
                    IdentificadorProdutoFilial = IdentificadorProdutoFilial,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTO"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTO"], typeof(string)) as string,
                    Cor = Cor.RecuperarCor(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDCOR"], typeof(string)) as string),
                    ProdutoNCM = ProdutoNCM.RecuperarProdutoNCM(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTONCM"], typeof(string)) as string),
                    GrupoProduto = GrupoProduto.RecuperarGrupoProduto(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOPRODUTO"], typeof(string)) as string),
                    ImgProduto = (byte[])(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BITIMGPRODUTO"], typeof(byte[]))),
                    Observacao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["OBSPRODUTO"], typeof(string)) as string,
                    Peso = (Decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPESOPRODUTO"], typeof(Decimal))),
                    ProdutoCategoria = ProdutoCategoria.RecuperarProdutoCategoria(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODCATEGORIA"], typeof(string)) as string),
                    ProdutoDerivacao = ProdutoDerivacao.RecuperarProdutoDerivacao(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTODERIVACAO"], typeof(string)) as string),
                    ProdutoMarca = ProdutoMarca.RecuperarProdutoMarca(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOMARCA"], typeof(string)) as string),
                    ProdutoCST = ProdutoCST.RecuperarProdutoCST(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCST"], typeof(string)) as string),
                    ProdutoCFOP = ProdutoCFOP.RecuperarProdutoCFOP(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCFOP"], typeof(string)) as string),
                    UnidadesMedida = UnidadesMedida.RecuperarUnidadesMedidaProduto(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOSERVICO"], typeof(string)) as string),
                    TipoProdutoServico = TipoProdutoServico.RecuperarTipoProdutoServico(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDTIPOPRODUTO"], typeof(string)) as string)

                };


            }

            return objProdutoServico;
        }

        public static Comum.Clases.ProdutoServico RecuperarProdutoServicoPorEstoque(string IdentificadorProdutoEstoque)
        {
            Sql objSql = new Sql();
            Comum.Clases.ProdutoServico objProdutoServico = null;

            objSql.AdicionarParametro("IDDATOSCOMPRAPROD", IdentificadorProdutoEstoque);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoServicoRecuperarPorEstoque, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoServico = new Comum.Clases.ProdutoServico()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOSERVICO"], typeof(string)) as string,
                    IdentificadorProdutoFilial = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOFILIAL"], typeof(string)) as string,
                    IdentificadorProdutoCompra = IdentificadorProdutoEstoque,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTO"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTO"], typeof(string)) as string,
                    Cor = Cor.RecuperarCor(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDCOR"], typeof(string)) as string),
                    ProdutoNCM = ProdutoNCM.RecuperarProdutoNCM(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTONCM"], typeof(string)) as string),
                    GrupoProduto = GrupoProduto.RecuperarGrupoProduto(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOPRODUTO"], typeof(string)) as string),
                    ImgProduto = (byte[])(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BITIMGPRODUTO"], typeof(byte[]))),
                    Observacao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["OBSPRODUTO"], typeof(string)) as string,
                    Peso = (Decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPESOPRODUTO"], typeof(Decimal))),
                    ProdutoCategoria = ProdutoCategoria.RecuperarProdutoCategoria(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODCATEGORIA"], typeof(string)) as string),
                    ProdutoDerivacao = ProdutoDerivacao.RecuperarProdutoDerivacao(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTODERIVACAO"], typeof(string)) as string),
                    ProdutoMarca = ProdutoMarca.RecuperarProdutoMarca(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOMARCA"], typeof(string)) as string),
                    ProdutoCST = ProdutoCST.RecuperarProdutoCST(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCST"], typeof(string)) as string),
                    ProdutoCFOP = ProdutoCFOP.RecuperarProdutoCFOP(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCFOP"], typeof(string)) as string),
                    UnidadesMedida = UnidadesMedida.RecuperarUnidadesMedidaProduto(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOSERVICO"], typeof(string)) as string),
                    TipoProdutoServico = TipoProdutoServico.RecuperarTipoProdutoServico(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDTIPOPRODUTO"], typeof(string)) as string)

                };


            }

            return objProdutoServico;
        }

        public static void DeletarUnidadesMedidaProdut(string IdentificadorProdutoServico, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico, true);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoDeletarUnidadesMedida);

        }

        public static void InserirUnidadesMedidaProduto(string IdentificadorProdutoServico, string IdentificadorUnidadeMedida,
                                                        ref Sql objSql)
        {

            objSql.AdicionarParametro("IDUNIDADEMEDPRODUTO", Guid.NewGuid(), true);
            objSql.AdicionarParametro("IDUNIDADEMEDIDA", IdentificadorUnidadeMedida);
            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoServicoInserirUnidadesMedida);
        }

        public static Dictionary<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> RecuperarCodigosBarrasProdutos(List<string> IdentificadoresProdutos)
        {

            Dictionary<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> objCodigosBarrasProdutos = null;

            Sql objSql = new Sql();
            string query = Util.MontarClausulaIn(IdentificadoresProdutos, "IDPRODUTOSERVICO", ref objSql, false, "WHERE");

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoServicoRecucperarCodigoBarras + query, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                objCodigosBarrasProdutos = new Dictionary<string, List<Comum.Clases.ProdutoServicoCodigoBarras>>();
                KeyValuePair<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> objCodigoBarra;
                foreach (DataRow dr in dt.Rows)
                {
                    objCodigoBarra = (from KeyValuePair<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> cb in objCodigosBarrasProdutos
                                      where cb.Key == frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string
                                      select cb).FirstOrDefault();

                    if (string.IsNullOrEmpty(objCodigoBarra.Key))
                    {
                        objCodigosBarrasProdutos.Add(frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string, new List<Comum.Clases.ProdutoServicoCodigoBarras>());

                        objCodigoBarra = objCodigosBarrasProdutos.LastOrDefault();
                    }

                    objCodigoBarra.Value.Add(new Comum.Clases.ProdutoServicoCodigoBarras()
                    {
                        CodigoBarras = frmUtil.Util.AtribuirValorObj(dr["DESCODBARRAS"], typeof(string)) as string,
                        Identficador = frmUtil.Util.AtribuirValorObj(dr["IDCODIGOBARRASPRODSERV"], typeof(string)) as string
                    });
                }
            }

            return objCodigosBarrasProdutos;
        }

        public static Comum.Clases.ProdutosGeral RecuperarProdutosGeral(string IdentificadorFilial, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            Comum.Clases.ProdutosGeral objProdutosGeral = null;

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutosGeralRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                List<string> IdentficadoresProdutos = (from DataRow row in dt.Rows
                                                       select frmUtil.Util.AtribuirValorObj(row["IDPRODUTOSERVICO"], typeof(string)) as string).ToList();
                Dictionary<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> CodigosBarras = null;

                if (IdentficadoresProdutos != null)
                {
                    IdentficadoresProdutos = IdentficadoresProdutos.Distinct().ToList();
                    CodigosBarras = RecuperarCodigosBarrasProdutos(IdentficadoresProdutos);

                }
                Int32 Tipo;
                objProdutosGeral = new Comum.Clases.ProdutosGeral();

                foreach (DataRow dr in dt.Rows)
                {

                    Tipo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["TIPO"], typeof(Int32)));

                    switch (Tipo)
                    {

                        case 1:

                            if (objProdutosGeral.ProdutosFilial == null) objProdutosGeral.ProdutosFilial = new List<Comum.Clases.ProdutoServico>();

                            objProdutosGeral.ProdutosFilial.Add(new Comum.Clases.ProdutoServico()
                            {
                                Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTO"], typeof(string)) as string,
                                Estoque = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMESTOQUE"], typeof(decimal))),
                                Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string,
                                IdentificadorProdutoFilial = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOFILIAL"], typeof(string)) as string,
                                CodigosBarras = (CodigosBarras != null && CodigosBarras.Count > 0 ? (from KeyValuePair<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> cb in CodigosBarras
                                                                                                     where cb.Key == frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string
                                                                                                     select cb.Value).FirstOrDefault() : null)
                            });

                            break;
                        case 2:

                            if (objProdutosGeral.ProdutosEmpresa == null) objProdutosGeral.ProdutosEmpresa = new List<Comum.Clases.ProdutoServico>();

                            objProdutosGeral.ProdutosEmpresa.Add(new Comum.Clases.ProdutoServico()
                            {
                                Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTO"], typeof(string)) as string,
                                Estoque = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMESTOQUE"], typeof(decimal))),
                                Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string,
                                CodigosBarras = (CodigosBarras != null && CodigosBarras.Count > 0 ? (from KeyValuePair<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> cb in CodigosBarras
                                                                                                     where cb.Key == frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string
                                                                                                     select cb.Value).FirstOrDefault() : null)
                            });

                            break;
                        case 3:

                            if (objProdutosGeral.ProdutoFilialEstoque == null) objProdutosGeral.ProdutoFilialEstoque = new List<Comum.Clases.ProdutoServico>();

                            objProdutosGeral.ProdutoFilialEstoque.Add(new Comum.Clases.ProdutoServico()
                            {
                                Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTO"], typeof(string)) as string,
                                Estoque = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMESTOQUE"], typeof(decimal))),
                                Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string,
                                IdentificadorProdutoFilial = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOFILIAL"], typeof(string)) as string,
                                IdentificadorProdutoCompra = frmUtil.Util.AtribuirValorObj(dr["IDDATOSCOMPRAPROD"], typeof(string)) as string,
                                CodigosBarras = (CodigosBarras != null && CodigosBarras.Count > 0 ? (from KeyValuePair<string, List<Comum.Clases.ProdutoServicoCodigoBarras>> cb in CodigosBarras
                                                                                                     where cb.Key == frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string
                                                                                                     select cb.Value).FirstOrDefault() : null)
                            });

                            break;
                    }

                }
            }

            return objProdutosGeral;
        }

        public static List<Comum.Clases.ProdutoDisponivelVenda> RecuperarProdutos(string identificadorEmpresa,
                                                                                  string identificadorFilial,
                                                                                  DateTime dataAtual,
                                                                                  string descricaoProduto,
                                                                                  Int32 codigoProduto,
                                                                                  bool recuperarImagens)
        {
            Sql objSql = new Sql();
            string objQuery = string.Empty;

            objSql.AdicionarParametro("IDEMPRESA", identificadorEmpresa);
            objSql.AdicionarParametro("IDFILIAL", identificadorFilial);
            objSql.AdicionarParametro("DTATUAL", dataAtual);

            if (descricaoProduto != null)
            {
                objSql.AdicionarParametro("DESPRODUTO", descricaoProduto);
            }
            else
            {
                objSql.AdicionarParametro("DESPRODUTO", DBNull.Value);
            }

            objSql.AdicionarParametro("CODPRODUTO", codigoProduto);

            if (recuperarImagens)
            {
                objSql.AdicionarParametro("BOLIMAGEM", 1);
            }
            else
            {
                objSql.AdicionarParametro("BOLIMAGEM", 0);
            }

            List<string> objNomesTabelas = new List<string>();

            List<DataTable> dts = objSql.ExecutarDataTablesArquivo("SP_RECUPERAR_PRODUTOS", Comum.Clases.Constantes.ARQUIVO_CONEXAO, CommandType.StoredProcedure, objNomesTabelas);

            if (dts != null && dts.Count > 0)
            {
                List<Comum.Clases.ProdutoDisponivelVenda> produtoDisponivelVendas = new List<Comum.Clases.ProdutoDisponivelVenda>();

                DataTable dtProdutos = dts[0];
                DataTable dtProdutosAcrescimos = dts[1];
                DataTable dtObservacoes = dts[2];
                DataTable dtCodigosBarra = dts[3];
                DataTable dtUnidadesMedidas = dts[4];
                DataTable dtProdutosFiliais = dts[5];
                DataTable dtProdutosPromocoes = dts[6];
                DataTable dtImagens = null;
                if (dts.Count > 7) dtImagens = dts[7];

                Comum.Clases.ProdutoDisponivelVenda produtoVenda = null;

                if (dtProdutos != null && dtProdutos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtProdutos.Rows)
                    {

                        produtoVenda = new Comum.Clases.ProdutoDisponivelVenda();
                        produtoVenda.Produto = RecuperarProduto(row, dtImagens);

                        string identificadorSector = (string)frmUtil.Util.AtribuirValorObj(row["IDSETOREMPRESA"], typeof(string));

                        if (!string.IsNullOrEmpty(identificadorSector))
                        {
                            produtoVenda.SetorEmpresa = new Comum.Clases.SetorEmpresa();
                            produtoVenda.SetorEmpresa.IdentificadorSetorEmpresa = (string)frmUtil.Util.AtribuirValorObj(row["IDSETOREMPRESA"], typeof(string));
                            produtoVenda.SetorEmpresa.DescricaoSetorEmpresa = (string)frmUtil.Util.AtribuirValorObj(row["DESSETOR"], typeof(string));
                            produtoVenda.SetorEmpresa.DescricaoImpressora = (string)frmUtil.Util.AtribuirValorObj(row["DESIMPRESSORA"], typeof(string));                            
                        }

                        if (dtProdutosPromocoes != null && dtProdutosPromocoes.Rows.Count > 0)
                        {
                            foreach (DataRow rowPP in dtProdutosPromocoes.Rows)
                            {

                                if (produtoVenda.Produto.Identificador == (string)frmUtil.Util.AtribuirValorObj(rowPP["IDPRODUTOSERVICO"], typeof(string)))
                                {
                                    string codigoDiaSemana = (string)frmUtil.Util.AtribuirValorObj(rowPP["CODDIASEMANA"], typeof(string));

                                    if (!string.IsNullOrEmpty(codigoDiaSemana))
                                    {

                                        int codigo = Convert.ToInt32(codigoDiaSemana);

                                        DayOfWeek today = DateTime.Now.DayOfWeek;
                                        if ((int)today == codigo)
                                        {
                                            DateTime dataInicio = (DateTime)frmUtil.Util.AtribuirValorObj(rowPP["DTHINICIO"], typeof(DateTime));
                                            DateTime dataFim = (DateTime)frmUtil.Util.AtribuirValorObj(rowPP["DTHFIM"], typeof(DateTime));

                                            DateTime atual = DateTime.Now;

                                            if (TimeSpan.Compare(dataInicio.TimeOfDay, atual.TimeOfDay) == -1 && TimeSpan.Compare(atual.TimeOfDay, dataFim.TimeOfDay) == -1)
                                            {
                                                produtoVenda.PercentualDescontoPromocao = (decimal)frmUtil.Util.AtribuirValorObj(rowPP["NUMPROMOCAOPER"], typeof(decimal));
                                                produtoVenda.ValorDescontoPromocao = (decimal)frmUtil.Util.AtribuirValorObj(rowPP["NUMPROMOCAOVALOR"], typeof(decimal));
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        DateTime dataInicio = (DateTime)frmUtil.Util.AtribuirValorObj(rowPP["DTHINICIO"], typeof(DateTime));
                                        DateTime dataFim = (DateTime)frmUtil.Util.AtribuirValorObj(rowPP["DTHFIM"], typeof(DateTime));

                                        DateTime atual = DateTime.Now.Date;

                                        if (dataInicio.Date <= atual && dataFim.Date >= atual)
                                        {
                                            produtoVenda.PercentualDescontoPromocao = (decimal)frmUtil.Util.AtribuirValorObj(rowPP["NUMPROMOCAOPER"], typeof(decimal));
                                            produtoVenda.ValorDescontoPromocao = (decimal)frmUtil.Util.AtribuirValorObj(rowPP["NUMPROMOCAOVALOR"], typeof(decimal));
                                            break;
                                        }
                                    }
                                }

                            }
                        }

                        if (dtProdutosAcrescimos != null && dtProdutosAcrescimos.Rows.Count > 0)
                        {
                            foreach (DataRow rowPA in dtProdutosAcrescimos.Rows)
                            {
                                string identificadorProduto = (string)frmUtil.Util.AtribuirValorObj(rowPA["IDPRODUTOSERVICO"], typeof(string));

                                if (produtoVenda.Produto.Identificador == identificadorProduto)
                                {
                                    if (produtoVenda.Produto.Acrescimos == null)
                                    {
                                        produtoVenda.Produto.Acrescimos = new List<Comum.Clases.Acrescimo>();
                                    }

                                    produtoVenda.Produto.Acrescimos.Add(RecuperarAcrescimo(rowPA));
                                }

                            }
                        }

                        if (dtObservacoes != null && dtObservacoes.Rows.Count > 0)
                        {
                            foreach (DataRow rowOBS in dtObservacoes.Rows)
                            {
                                string identificadorProduto = (string)frmUtil.Util.AtribuirValorObj(rowOBS["IDPRODUTOSERVICO"], typeof(string));

                                if (produtoVenda.Produto.Identificador == identificadorProduto)
                                {
                                    if (produtoVenda.Produto.ObservacoesProduto == null)
                                    {
                                        produtoVenda.Produto.ObservacoesProduto = new List<Comum.Clases.ProdutoObservacao>();
                                    }

                                    produtoVenda.Produto.ObservacoesProduto.Add(RecuperarObservacao(rowOBS));

                                }
                            }
                        }

                        if (dtCodigosBarra != null && dtCodigosBarra.Rows.Count > 0)
                        {
                            foreach (DataRow rowCB in dtCodigosBarra.Rows)
                            {
                                string identificadorProduto = (string)frmUtil.Util.AtribuirValorObj(rowCB["IDPRODUTOSERVICO"], typeof(string));

                                if (produtoVenda.Produto.Identificador == identificadorProduto)
                                {
                                    if (produtoVenda.Produto.CodigosBarras == null)
                                    {
                                        produtoVenda.Produto.CodigosBarras = new List<Comum.Clases.ProdutoServicoCodigoBarras>();
                                    }

                                    produtoVenda.Produto.CodigosBarras.Add(RecuperarCodigosBarra(rowCB));
                                }

                            }
                        }

                        if (dtProdutosFiliais != null && dtProdutosFiliais.Rows.Count > 0)
                        {

                            DataRow rowPF = (from r in dtProdutosFiliais.AsEnumerable()
                                             where r.Field<string>("IDPRODUTOSERVICO") == produtoVenda.Produto.Identificador
                                             select r).FirstOrDefault();

                            if (rowPF != null)
                            {

                                produtoVenda.NumDescontoAtacadoPercentual = (decimal)frmUtil.Util.AtribuirValorObj(rowPF["NUMPERCENTDESCONTATAC"], typeof(decimal));
                                produtoVenda.NumMinimoVenda = (decimal)frmUtil.Util.AtribuirValorObj(rowPF["NUMMINIMOVENDA"], typeof(decimal));
                                produtoVenda.NumOutrasDespesasPercentual = (decimal)frmUtil.Util.AtribuirValorObj(rowPF["NUMOUTDESPPER"], typeof(decimal));
                                produtoVenda.NumQuantidadeVendaAtacado = (int)frmUtil.Util.AtribuirValorObj(rowPF["NUMQUANTVENDAATACADO"], typeof(int));
                                produtoVenda.NumValorVendaAtacado = (decimal)frmUtil.Util.AtribuirValorObj(rowPF["NUMVALORVENDAATACADO"], typeof(decimal));
                                produtoVenda.NumValorVendaVarejo = (decimal)frmUtil.Util.AtribuirValorObj(rowPF["NUMVALORVENDAVAREJO"], typeof(decimal));

                                produtoVenda.UnidadeMediaEstoque = RecuperarUnidadeMedida("IDUNIDADEMEDIDAESTOQUE", rowPF, dtUnidadesMedidas);
                                produtoVenda.UnidadeMedidaQuantidadeVendaAtacado = RecuperarUnidadeMedida("IDUNIDADEMEDIDAMINESTOQUE", rowPF, dtUnidadesMedidas);
                                produtoVenda.UnidadeMedidaVenda = RecuperarUnidadeMedida("IDUNIDADEMEDIDAVENDA", rowPF, dtUnidadesMedidas);
                                produtoVenda.UnidadeMedidaVendaAtacado = RecuperarUnidadeMedida("IDUMVENDAATACADO", rowPF, dtUnidadesMedidas);
                                produtoVenda.UnidadeMedidaVendaVarejo = RecuperarUnidadeMedida("IDUMVALORVENDAVAREJO", rowPF, dtUnidadesMedidas);
                            }

                        }

                        produtoDisponivelVendas.Add(produtoVenda);
                    }
                }

                return produtoDisponivelVendas;
            }

            return null;
        }

        private static Comum.Clases.UnidadeMedida RecuperarUnidadeMedida(string identificador, DataRow row, DataTable dtUnidadesMedidas)
        {
            Comum.Clases.UnidadeMedida unidadeMedida = null;

            if (dtUnidadesMedidas != null && dtUnidadesMedidas.Rows.Count > 0)
            {
                string unidadeMedidaVenda = (string)frmUtil.Util.AtribuirValorObj(row[identificador], typeof(string));

                if (!string.IsNullOrEmpty(unidadeMedidaVenda))
                {
                    DataRow linha = (from myRow in dtUnidadesMedidas.AsEnumerable()
                                     where myRow.Field<string>("IDUNIDADEMEDIDA") == unidadeMedidaVenda
                                     select myRow).FirstOrDefault();
                    if (linha != null)
                    {
                        unidadeMedida = new Comum.Clases.UnidadeMedida();
                        unidadeMedida.Identificador = (string)frmUtil.Util.AtribuirValorObj(linha["IDUNIDADEMEDIDA"], typeof(string));
                        unidadeMedida.Codigo = (string)frmUtil.Util.AtribuirValorObj(linha["CODUNIDADEMEDIDA"], typeof(string));
                        unidadeMedida.Descricao = (string)frmUtil.Util.AtribuirValorObj(linha["DESUNIDADEMEDIDA"], typeof(string));
                        unidadeMedida.NumValorUnidadePai = (decimal)frmUtil.Util.AtribuirValorObj(linha["NUMUNIDADEPAI"], typeof(decimal));
                    }
                }

            }

            return unidadeMedida;
        }

        private static Comum.Clases.Acrescimo RecuperarAcrescimo(DataRow row)
        {
            Comum.Clases.Acrescimo acrescimo = new Comum.Clases.Acrescimo();
            acrescimo.Identificador = (string)frmUtil.Util.AtribuirValorObj(row["IDACRESCIMO"], typeof(string));
            acrescimo.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESPRODUTO"], typeof(string));
            return acrescimo;
        }

        private static Comum.Clases.ProdutoServico RecuperarProduto(DataRow row, DataTable dtImagens)
        {
            Comum.Clases.ProdutoServico produto = new Comum.Clases.ProdutoServico();

            produto.Identificador = (string)frmUtil.Util.AtribuirValorObj(row["IDPRODUTOSERVICO"], typeof(string));
            produto.Codigo = (Int32)frmUtil.Util.AtribuirValorObj(row["CODPRODUTO"], typeof(Int32));
            produto.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESPRODUTO"], typeof(string));
            produto.VendaAGranel = (bool)frmUtil.Util.AtribuirValorObj(row["BOLVENDAAGRANEL"], typeof(bool));
            produto.ProdutoInterno = (bool)frmUtil.Util.AtribuirValorObj(row["BOLINTERNO"], typeof(bool));
            produto.Acrescimo = (bool)frmUtil.Util.AtribuirValorObj(row["BOLACRESCIMO"], typeof(bool));
            produto.VendaPorNumeroSerie = (bool)frmUtil.Util.AtribuirValorObj(row["BOLVENDANUMEROSERIE"], typeof(bool));
            produto.Observacao = (string)frmUtil.Util.AtribuirValorObj(row["OBSPRODUTO"], typeof(string));

            if (dtImagens != null && dtImagens.Rows.Count > 0)
            {

                DataRow rowImg = (from r in dtImagens.AsEnumerable()
                                  where r.Field<string>("IDPRODUTOSERVICO") == produto.Identificador
                                  select r).FirstOrDefault();
                if (rowImg != null)
                {
                    produto.ImgProduto = (byte[])frmUtil.Util.AtribuirValorObj(rowImg["BITIMGPRODUTO"], typeof(byte[]));
                }

            }

            // Marca
            string identificadorMarca = (string)frmUtil.Util.AtribuirValorObj(row["IDPRODUTOMARCA"], typeof(string));
            if (!string.IsNullOrEmpty(identificadorMarca))
            {
                produto.ProdutoMarca = new Comum.Clases.ProdutoMarca();
                produto.ProdutoMarca.Identificador = identificadorMarca;
                produto.ProdutoMarca.Codigo = (int)frmUtil.Util.AtribuirValorObj(row["CODPRODUTOMARCA"], typeof(int));
                produto.ProdutoMarca.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESPRODUTOMARCA"], typeof(string));
            }

            // Catergoria
            string identificadorCategoria = (string)frmUtil.Util.AtribuirValorObj(row["IDPRODCATEGORIA"], typeof(string));
            if (!string.IsNullOrEmpty(identificadorCategoria))
            {
                produto.ProdutoCategoria = new Comum.Clases.ProdutoCategoria();
                produto.ProdutoCategoria.Identificador = identificadorCategoria;
                produto.ProdutoCategoria.Codigo = (int)frmUtil.Util.AtribuirValorObj(row["CODPRODCATEGORIA"], typeof(int)); ;
                produto.ProdutoCategoria.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESPRODCATEGORIA"], typeof(string));
            }

            // Unidade de medida
            produto.UnidadesMedida = new List<Comum.Clases.UnidadeMedida>();
            Comum.Clases.UnidadeMedida unidadeMedida = new Comum.Clases.UnidadeMedida();
            unidadeMedida.Identificador = (string)frmUtil.Util.AtribuirValorObj(row["IDUNIDADEMEDIDA"], typeof(string));
            unidadeMedida.Codigo = (string)frmUtil.Util.AtribuirValorObj(row["CODUNIDADEMEDIDA"], typeof(string));
            unidadeMedida.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESUNIDADEMEDIDA"], typeof(string));
            unidadeMedida.NumValorUnidadePai = (decimal)frmUtil.Util.AtribuirValorObj(row["NUMUNIDADEPAI"], typeof(decimal)); ;
            produto.UnidadesMedida.Add(unidadeMedida);

            // Tipo de produto
            produto.TipoProdutoServico = new Comum.Clases.TipoProdutoServico();
            produto.TipoProdutoServico.Identificador = (string)frmUtil.Util.AtribuirValorObj(row["IDTIPOPRODUTO"], typeof(string));
            produto.TipoProdutoServico.Codigo = (string)frmUtil.Util.AtribuirValorObj(row["CODTIPOPRODUTO"], typeof(string));
            produto.TipoProdutoServico.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESTIPOPRODUTO"], typeof(string));

            // Grupo do produto
            produto.GrupoProduto = new Comum.Clases.GrupoProduto();
            produto.GrupoProduto.Identificador = (string)frmUtil.Util.AtribuirValorObj(row["IDGRUPOPRODUTO"], typeof(string));
            produto.GrupoProduto.Codigo = (Int32)frmUtil.Util.AtribuirValorObj(row["CODGRUPOPRODUTO"], typeof(Int32));
            produto.GrupoProduto.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESGRUPOPRODUTO"], typeof(string));

            return produto;

        }

        private static Comum.Clases.ProdutoObservacao RecuperarObservacao(DataRow row)
        {
            Comum.Clases.ProdutoObservacao observacao = new Comum.Clases.ProdutoObservacao();

            observacao.Identificador = (string)frmUtil.Util.AtribuirValorObj(row["IDOBSERVACAO"], typeof(string));
            observacao.Descricao = (string)frmUtil.Util.AtribuirValorObj(row["DESOBSERVACAO"], typeof(string));
            return observacao;
        }

        private static Comum.Clases.ProdutoServicoCodigoBarras RecuperarCodigosBarra(DataRow row)
        {
            Comum.Clases.ProdutoServicoCodigoBarras codigoBarra = new Comum.Clases.ProdutoServicoCodigoBarras();

            codigoBarra.Identficador = (string)frmUtil.Util.AtribuirValorObj(row["IDCODIGOBARRASPRODSERV"], typeof(string));
            codigoBarra.CodigoBarras = (string)frmUtil.Util.AtribuirValorObj(row["DESCODBARRAS"], typeof(string));
            return codigoBarra;
        }
    }
}
