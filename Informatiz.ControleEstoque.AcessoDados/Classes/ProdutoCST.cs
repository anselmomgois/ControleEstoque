using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoCST
    {

        public static List<Comum.Clases.ProdutoCST> RecuperarCST(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoCST> objProdutoCST = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESPRODUTOCST LIKE @DESPRODUTOCST ";
                objSql.AdicionarParametro("DESPRODUTOCST", "%" + Descricao.ToUpper() + "%");
            }
            
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoCSTPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoCST = new List<Comum.Clases.ProdutoCST>();

                foreach (DataRow dr in dt.Rows)
                {
                    objProdutoCST.Add(new Comum.Clases.ProdutoCST
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOCST"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTOCST"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTOCST"], typeof(string)) as string,
                        CST = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODCST"], typeof(Int32))),
                        TemCST = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLTEMST"], typeof(Boolean)))
                    });
                }
            }

            return objProdutoCST;
        }

        public static void InserirProdutoCST(Comum.Clases.ProdutoCST objCST, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCST", Guid.NewGuid());
            objSql.AdicionarParametro("DESPRODUTOCST", objCST.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("CODCST", objCST.CST);
            objSql.AdicionarParametro("BOLTEMST", objCST.TemCST);
            if(string.IsNullOrEmpty(objCST.DesMensagemNotaFiscal))
            {
            objSql.AdicionarParametro("OBSMSGNOTAFISCAL", DBNull.Value);
            }
            else
            {
            objSql.AdicionarParametro("OBSMSGNOTAFISCAL", objCST.DesMensagemNotaFiscal);
            }

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCSTInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarProdutoCST(Comum.Clases.ProdutoCST objCST)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCST", objCST.Identificador);
            objSql.AdicionarParametro("DESPRODUTOCST", objCST.Descricao.ToUpper());
            objSql.AdicionarParametro("CODCST", objCST.CST);
            objSql.AdicionarParametro("BOLTEMST", objCST.TemCST);
            if (string.IsNullOrEmpty(objCST.DesMensagemNotaFiscal))
            {
                objSql.AdicionarParametro("OBSMSGNOTAFISCAL", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("OBSMSGNOTAFISCAL", objCST.DesMensagemNotaFiscal);
            }

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCSTAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarProdutoCST(string IdentificadorProdutoCST)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCST", IdentificadorProdutoCST);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCSTDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean ProdutoCSTEstaSendoUsuado(string IdentificadorProdutoCST)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOCST", IdentificadorProdutoCST);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.ProdutoCSTEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.ProdutoCST RecuperarProdutoCST(string IdentificadorProdutoCST)
        {
            if (string.IsNullOrEmpty(IdentificadorProdutoCST))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoCST objProdutoCST = null;

            objSql.AdicionarParametro("IDPRODUTOCST", IdentificadorProdutoCST);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoCSTRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoCST = new Comum.Clases.ProdutoCST()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCST"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTOCST"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTOCST"], typeof(string)) as string,
                    CST = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODCST"], typeof(Int32))),
                    TemCST = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLTEMST"], typeof(Boolean))),
                    DesMensagemNotaFiscal = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["OBSMSGNOTAFISCAL"], typeof(string)) as string
                };


            }

            return objProdutoCST;
        }
    }
}
