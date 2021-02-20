using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoNCM
    {

        public static List<Comum.Clases.ProdutoNCM> PesquisarProdutoNCM(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoNCM> objProdutoNCM = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESPRODUTONCM LIKE @DESPRODUTONCM ";
                objSql.AdicionarParametro("DESPRODUTONCM", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoNCMPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoNCM = new List<Comum.Clases.ProdutoNCM>();

                foreach (DataRow dr in dt.Rows)
                {
                    objProdutoNCM.Add(new Comum.Clases.ProdutoNCM
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTONCM"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTONCM"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTONCM"], typeof(string)) as string,
                        NCM = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODNCM"], typeof(Int32))),
                        PercentualMVA = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMMVAPER"], typeof(decimal)))
                    });
                }
            }

            return objProdutoNCM;
        }

        public static void InserirProdutoNCM(Comum.Clases.ProdutoNCM objProdutoNCM, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTONCM", Guid.NewGuid());
            objSql.AdicionarParametro("DESPRODUTONCM", objProdutoNCM.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("CODNCM", objProdutoNCM.NCM);

            if (objProdutoNCM.PercentualMVA == null)
            {
                objSql.AdicionarParametro("NUMMVAPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMMVAPER", objProdutoNCM.PercentualMVA);
            }
            

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoNCMInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarProdutoNCM(Comum.Clases.ProdutoNCM objProdutoNCM)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTONCM", objProdutoNCM.Identificador);
            objSql.AdicionarParametro("DESPRODUTONCM", objProdutoNCM.Descricao.ToUpper());
            objSql.AdicionarParametro("CODNCM", objProdutoNCM.NCM);

            if (objProdutoNCM.PercentualMVA == null)
            {
                objSql.AdicionarParametro("NUMMVAPER", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMMVAPER", objProdutoNCM.PercentualMVA);
            }


            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoNCMAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarProdutoNCM(string IdentificadorProdutoNCM)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTONCM", IdentificadorProdutoNCM);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoNCMDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean ProdutoNCMEstaSendoUsuada(string IdentificadorProdutoNCM)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTONCM", IdentificadorProdutoNCM);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.ProdutoNCMEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.ProdutoNCM RecuperarProdutoNCM(string IdentificadorProdutoNCM)
        {

            if (string.IsNullOrEmpty(IdentificadorProdutoNCM))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoNCM objProdutoNCM = null;

            objSql.AdicionarParametro("IDPRODUTONCM", IdentificadorProdutoNCM);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoNCMRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoNCM = new Comum.Clases.ProdutoNCM()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTONCM"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTONCM"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTONCM"], typeof(string)) as string,
                    NCM = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODNCM"], typeof(Int32))),
                    PercentualMVA = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMMVAPER"], typeof(decimal)))
                };


            }

            return objProdutoNCM;
        }

    }
}
