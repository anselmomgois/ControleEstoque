using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoCFOP
    {

        public static List<Comum.Clases.ProdutoCFOP> RecuperarCFOPs(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoCFOP> objProdutoCFOPs = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESPRODUTOCFOP LIKE @DESPRODUTOCFOP ";
                objSql.AdicionarParametro("DESPRODUTOCFOP", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoCFOPPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoCFOPs = new List<Comum.Clases.ProdutoCFOP>();

                foreach (DataRow dr in dt.Rows)
                {
                    objProdutoCFOPs.Add(new Comum.Clases.ProdutoCFOP
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOCFOP"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTOCFOP"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTOCFOP"], typeof(string)) as string,
                        CFOP = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODCFOP"], typeof(Int32)))

                    });
                }
            }

            return objProdutoCFOPs;
        }

        public static void InserirProdutoCFOP(Comum.Clases.ProdutoCFOP objCFOP, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCFOP", Guid.NewGuid());
            objSql.AdicionarParametro("DESPRODUTOCFOP", objCFOP.Descricao.ToUpper());
            objSql.AdicionarParametro("CODCFOP", objCFOP.CFOP);
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            
            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCFOPInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarProdutoCFOP(Comum.Clases.ProdutoCFOP objCFOP)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCFOP", objCFOP.Identificador);
            objSql.AdicionarParametro("DESPRODUTOCFOP", objCFOP.Descricao.ToUpper());
            objSql.AdicionarParametro("CODCFOP", objCFOP.CFOP);
            
            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCFOPAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarProdutoCFOP(string IdentificadorProdutoCFOP)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCFOP", IdentificadorProdutoCFOP);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCFOPDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean ProdutoCFOPEstaSendoUsuado(string IdentificadorProdutoCFOP)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCFOP", IdentificadorProdutoCFOP);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.ProdutoCFOPEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.ProdutoCFOP RecuperarProdutoCFOP(string IdentificadorProdutoCFOP)
        {
            if (string.IsNullOrEmpty(IdentificadorProdutoCFOP))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoCFOP objProdutoCFOP = null;

            objSql.AdicionarParametro("IDPRODUTOCFOP", IdentificadorProdutoCFOP);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoCFOPRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoCFOP = new Comum.Clases.ProdutoCFOP()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCFOP"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTOCFOP"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTOCFOP"], typeof(string)) as string,
                    CFOP = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODCFOP"], typeof(Int32)))
                };


            }

            return objProdutoCFOP;
        }
    }
}
