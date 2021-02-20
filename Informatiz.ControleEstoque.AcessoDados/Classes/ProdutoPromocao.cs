using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoPromocao
    {

        public static List<Comum.Clases.ProdutoPromocao> PesquisarProdutoPromocao(string DescricaoPromocao, string DescricaoProduto,
                                                                             string IdentificadorEmpresa,
                                                                             string IdentificadorFilial)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoPromocao> objProdutoPromocao = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(DescricaoPromocao))
            {
                objQuery = " AND PM.DESPRODUTOPROMOCAO LIKE @DESPRODUTOPROMOCAO ";
                objSql.AdicionarParametro("DESPRODUTOPROMOCAO", "%" + DescricaoPromocao.ToUpper() + "%");
            }

            if (!string.IsNullOrEmpty(DescricaoProduto))
            {
                objQuery = " AND PS.DESPRODUTO LIKE @DESPRODUTO ";
                objSql.AdicionarParametro("DESPRODUTO", "%" + DescricaoProduto.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);

            DataTable dt = objSql.ExecutarDataTableArquivo(string.Format(Properties.Resources.ProdutoPromocaoPesquisar, objQuery), Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoPromocao = new List<Comum.Clases.ProdutoPromocao>();

                foreach (DataRow dr in dt.Rows)
                {
                    objProdutoPromocao.Add(new Comum.Clases.ProdutoPromocao
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOPROMOCAO"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTOPROMOCAO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTOPROMOCAO"], typeof(string)) as string,
                        DataFim = (DateTime)(frmUtil.Util.AtribuirValorObj(dr["DTHFIM"], typeof(DateTime))),
                        DataInicio = (DateTime)(frmUtil.Util.AtribuirValorObj(dr["DTHINICIO"], typeof(DateTime))),
                        Habilitada = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLHABILITADA"], typeof(Boolean))),
                        PercentualDesconto = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMPROMOCAOPER"], typeof(decimal))),
                        Valor = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMPROMOCAOVALOR"], typeof(decimal))),
                        Estoque = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMESTOQUE"], typeof(decimal))),
                        Produtos = AcessoDados.Classes.ProdutoPromocao.RecuperarProdutosPromocao(frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOPROMOCAO"], typeof(string)) as string)
                });
                }
            }

            return objProdutoPromocao;
        }

        public static string InserirProdutoPromocao(Comum.Clases.ProdutoPromocao objProdutoPromocao,
                                                    string identificadorEmpresa,
                                                    string identificadorFilial,
                                                    ref Sql objSql)
        {

            string IdentificadorPromocao = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorPromocao, true);
            objSql.AdicionarParametro("DESPRODUTOPROMOCAO", objProdutoPromocao.Descricao.ToUpper());
            objSql.AdicionarParametro("CODTIPOPROMOCAO", objProdutoPromocao.CodigoTipoPromocao);

            if (objProdutoPromocao.PercentualDesconto == null)
            {
                objSql.AdicionarParametro("NUMPROMOCAOPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMPROMOCAOPER", objProdutoPromocao.PercentualDesconto);
            }

            if (objProdutoPromocao.Valor == null)
            {
                objSql.AdicionarParametro("NUMPROMOCAOVALOR", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMPROMOCAOVALOR", objProdutoPromocao.Valor);
            }

            objSql.AdicionarParametro("BOLHABILITADA", objProdutoPromocao.Habilitada);
            objSql.AdicionarParametro("DTHINICIO", objProdutoPromocao.DataInicio);

            if (objProdutoPromocao.DataFim == null)
            {
                objSql.AdicionarParametro("DTHFIM", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("DTHFIM", objProdutoPromocao.DataFim);
            }

            if (!string.IsNullOrEmpty(identificadorEmpresa))
            {
                objSql.AdicionarParametro("IDEMPRESA", identificadorEmpresa);
            }
            else
            {
                objSql.AdicionarParametro("IDEMPRESA", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(identificadorFilial))
            {
                objSql.AdicionarParametro("IDFILIAL", identificadorFilial);
            }
            else
            {
                objSql.AdicionarParametro("IDFILIAL", DBNull.Value);
            }
            objSql.AdicionarParametro("BOL_POR_HORARIO", objProdutoPromocao.PorHorario);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoPromocaoInserir);

            InserirDiaSemanaPromocao(objProdutoPromocao, IdentificadorPromocao, ref objSql);

            return IdentificadorPromocao;
        }

        public static void InserirItensProdutoPromocao(string IdentificadorProdutoPromocao,
                                                       string IdentificadorProdutoServico,
                                                       string IdentificadorProdutoFilial,
                                                       string IdentificadorDadosCompra,
                                                       ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPRODUTOPROMOCAOPRODF", Guid.NewGuid(), true);
            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorProdutoPromocao);

            if (!string.IsNullOrEmpty(IdentificadorProdutoFilial))
            {
                objSql.AdicionarParametro("IDPRODUTOFILIAL", IdentificadorProdutoFilial);
            }
            else
            {
                objSql.AdicionarParametro("IDPRODUTOFILIAL", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(IdentificadorDadosCompra))
            {
                objSql.AdicionarParametro("IDDATOSCOMPRAPROD", IdentificadorDadosCompra);
            }
            else
            {
                objSql.AdicionarParametro("IDDATOSCOMPRAPROD", DBNull.Value);
            }

            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProdutoServico);



            objSql.AdicionarTransacao(Properties.Resources.ProdutoPromocaoInserirItens);
        }

        public static List<Comum.Clases.ProdutoServico> RecuperarProdutosPromocao(string IdentificadorProdutoPromocao)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoServico> objProdutosPromocao = null;

            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorProdutoPromocao);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoPromocaoRecuperarProdutos, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutosPromocao = new List<Comum.Clases.ProdutoServico>();

                foreach (DataRow dr in dt.Rows)
                {

                    objProdutosPromocao.Add(new Comum.Clases.ProdutoServico
                    {
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTO"], typeof(string)) as string,
                        Estoque = (Int32)(frmUtil.Util.AtribuirValorObj(dr["NUMESTOQUE"], typeof(Int32))),
                    });

                }
            }

            return objProdutosPromocao;
        }

        public static void DeletarItensProdutoPromocao(string IdentificadorProdutoPromocao, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorProdutoPromocao, true);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoPromocaoDeletarItens);
        }

        public static void DesativarProdutoPromocao(string IdentificadorProdutoPromocao)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorProdutoPromocao, true);
            objSql.AdicionarParametro("BOLHABILITADA", false);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoPromocaoDesativar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static void AtualizarProdutoPromocao(Comum.Clases.ProdutoPromocao objProdutoPromocao,
                                                    string identificadorEmpresa,
                                                    string identificadorFilial,
                                                    ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", objProdutoPromocao.Identificador, true);
            objSql.AdicionarParametro("DESPRODUTOPROMOCAO", objProdutoPromocao.Descricao.ToUpper());
            objSql.AdicionarParametro("CODTIPOPROMOCAO", objProdutoPromocao.CodigoTipoPromocao);

            if (objProdutoPromocao.PercentualDesconto == null)
            {
                objSql.AdicionarParametro("NUMPROMOCAOPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMPROMOCAOPER", objProdutoPromocao.PercentualDesconto);
            }

            if (objProdutoPromocao.Valor == null)
            {
                objSql.AdicionarParametro("NUMPROMOCAOVALOR", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMPROMOCAOVALOR", objProdutoPromocao.Valor);
            }

            objSql.AdicionarParametro("BOLHABILITADA", objProdutoPromocao.Habilitada);
            objSql.AdicionarParametro("DTHINICIO", objProdutoPromocao.DataInicio);

            if (objProdutoPromocao.DataFim == null)
            {
                objSql.AdicionarParametro("DTHFIM", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("DTHFIM", objProdutoPromocao.DataFim);
            }

            if (string.IsNullOrEmpty(identificadorEmpresa))
            {
                objSql.AdicionarParametro("IDEMPRESA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDEMPRESA", identificadorEmpresa);
            }
            if (string.IsNullOrEmpty(identificadorFilial))
            {
                objSql.AdicionarParametro("IDFILIAL", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDFILIAL", identificadorFilial);
            }

            objSql.AdicionarParametro("BOL_POR_HORARIO", objProdutoPromocao.PorHorario);

            objSql.AdicionarTransacao(Properties.Resources.ProdutoPromocaoAtualizar);

            DeletarDiasSemanaPromocao(objProdutoPromocao.Identificador, ref objSql);
            InserirDiaSemanaPromocao(objProdutoPromocao, objProdutoPromocao.Identificador, ref objSql);
                                 
        }

        private static void DeletarDiasSemanaPromocao(string identificadorProdutoPromocao,
                                                      ref Sql objSql)
        {
            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", identificadorProdutoPromocao);
            objSql.AdicionarTransacao(Properties.Resources.ProdutoPromocaoDiasSemanaDeletar);
        }

        private static void InserirDiaSemanaPromocao(Comum.Clases.ProdutoPromocao objProdutoPromocao,
                                                     string IdentificadorProdutoPromocao,
                                                     ref Sql objSql)
        {
            if (objProdutoPromocao.PorHorario && objProdutoPromocao.DiasSemana != null && objProdutoPromocao.DiasSemana.Count > 0)
            {
                foreach (Comum.Enumeradores.Enumeradores.DiasSemana ds in objProdutoPromocao.DiasSemana)
                {

                    string IdentificadorDiasSemana = Guid.NewGuid().ToString();

                    objSql.AdicionarParametro("IDDIASEMANAPROMOCAO", IdentificadorDiasSemana, true);
                    objSql.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorProdutoPromocao);
                    objSql.AdicionarParametro("CODDIASEMANA", ds);
                    objSql.AdicionarTransacao(Properties.Resources.ProdutoPromocaoDiasSemanaInserir);
                }
            }
        }

        public static Comum.Clases.ProdutoPromocao RecuperarProdutoPromocao(string IdentificadorProdutoPromocao)
        {

            Sql objSql = new Sql();
            Comum.Clases.ProdutoPromocao objProdutoPromocao = null;

            objSql.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorProdutoPromocao);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoPromocaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                List<Comum.Clases.ProdutoServico> objProdutosServico = null;
                List<Comum.Clases.ProdutoServico> objProdutoPorFilial = null;
                List<Comum.Clases.ProdutoServico> objProdutoPorEstoque = null;

                string IdentificadorProdutoServico = string.Empty;
                string IdentificadorProdutoFilial = string.Empty;
                string IdentificadorProdutoEstoque = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorProdutoServico = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOSERVICO"], typeof(string)) as string;
                    IdentificadorProdutoFilial = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOFILIAL"], typeof(string)) as string;
                    IdentificadorProdutoEstoque = frmUtil.Util.AtribuirValorObj(dr["IDDATOSCOMPRAPROD"], typeof(string)) as string;

                    if (!string.IsNullOrEmpty(IdentificadorProdutoEstoque))
                    {

                        if (objProdutoPorEstoque == null) objProdutoPorEstoque = new List<Comum.Clases.ProdutoServico>();

                        objProdutoPorEstoque.Add(ProdutoServico.RecuperarProdutoServicoPorEstoque(IdentificadorProdutoEstoque));

                    }
                    else if (!string.IsNullOrEmpty(IdentificadorProdutoFilial))
                    {

                        if (objProdutoPorFilial == null) objProdutoPorFilial = new List<Comum.Clases.ProdutoServico>();

                        objProdutoPorFilial.Add(ProdutoServico.RecuperarProdutoServicoPorFilial(IdentificadorProdutoFilial));

                    }
                    else if (!string.IsNullOrEmpty(IdentificadorProdutoServico))

                    {

                        if (objProdutosServico == null) objProdutosServico = new List<Comum.Clases.ProdutoServico>();

                        objProdutosServico.Add(ProdutoServico.RecuperarProdutoServico(IdentificadorProdutoServico));
                    }
                }


                objProdutoPromocao = new Comum.Clases.ProdutoPromocao()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOPROMOCAO"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTOPROMOCAO"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTOPROMOCAO"], typeof(string)) as string,
                    CodigoTipoPromocao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODTIPOPROMOCAO"], typeof(string)) as string,
                    DataFim = (DateTime)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHFIM"], typeof(DateTime))),
                    DataInicio = (DateTime)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHINICIO"], typeof(DateTime))),
                    Habilitada = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLHABILITADA"], typeof(Boolean))),
                    PorHorario = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOL_POR_HORARIO"], typeof(Boolean))),
                    PercentualDesconto = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPROMOCAOPER"], typeof(decimal))),
                    Valor = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPROMOCAOVALOR"], typeof(decimal))),
                    PrudutosEmpresa = objProdutosServico,
                    ProdutosPorFilial = objProdutoPorFilial,
                    ProdutosCompra = objProdutoPorEstoque
                };

                if (objProdutoPromocao.PorHorario)
                {

                    Sql objSqlDiasSemana = new Sql();

                    //DiasSemana = new List<Comum.Enumeradores.Enumeradores.DiasSemana>();

                    objSqlDiasSemana.AdicionarParametro("IDPRODUTOPROMOCAO", IdentificadorProdutoPromocao);

                    DataTable dtDiasSemana = objSqlDiasSemana.ExecutarDataTableArquivo(Properties.Resources.ProdutoPromocaoRecuperarDiasSemana, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
                    if (dtDiasSemana != null && dtDiasSemana.Rows.Count > 0)
                    {
                        objProdutoPromocao.DiasSemana = new List<Comum.Enumeradores.Enumeradores.DiasSemana>();
                        foreach (DataRow dr in dtDiasSemana.Rows)
                        {
                            int cod = (int)(frmUtil.Util.AtribuirValorObj(dr["CODDIASEMANA"], typeof(int)));

                            if (cod == 0)
                            {
                                objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Domingo);
                            }
                            else if (cod == 1)
                            {
                                objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Segunda);
                            }
                            else if (cod == 2)
                            {
                                objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Terça);
                            }
                            else if (cod == 3)
                            {
                                objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Quarta);
                            }
                            else if (cod == 4)
                            {
                                objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Quinta);
                            }
                            else if (cod == 5)
                            {
                                objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Sexta);
                            }
                            else if (cod == 6)
                            {
                                objProdutoPromocao.DiasSemana.Add(Comum.Enumeradores.Enumeradores.DiasSemana.Sábado);
                            }

                        }
                    }
                }

            }
            return objProdutoPromocao;
        }
    }
}
