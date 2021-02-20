using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class ProdutoDerivacao
    {

       public static List<Comum.Clases.ProdutoDerivacao> RecuperarDerivacao(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoDerivacao> objProdutoDerivacao = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESPRODUTODERIVACAO LIKE @DESPRODUTODERIVACAO ";
                objSql.AdicionarParametro("DESPRODUTODERIVACAO", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoDerivacaoPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoDerivacao = new List<Comum.Clases.ProdutoDerivacao>();

                foreach (DataRow dr in dt.Rows)
                {
                    objProdutoDerivacao.Add(new Comum.Clases.ProdutoDerivacao
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTODERIVACAO"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTODERIVACAO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTODERIVACAO"], typeof(string)) as string
                    });
                }
            }

            return objProdutoDerivacao;
        }

       public static void InserirProdutoDerivacao(Comum.Clases.ProdutoDerivacao objDerivacao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTODERIVACAO", Guid.NewGuid());
            objSql.AdicionarParametro("DESPRODUTODERIVACAO", objDerivacao.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoDerivacaoInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

       public static void AtualizarProdutoDerivacao(Comum.Clases.ProdutoDerivacao objDerivacao)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTODERIVACAO", objDerivacao.Identificador);
            objSql.AdicionarParametro("DESPRODUTODERIVACAO", objDerivacao.Descricao.ToUpper());

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoDerivacaoAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

       public static void DeletarProdutoDerivacao(string IdentificadorProdutoDerivacao)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTODERIVACAO", IdentificadorProdutoDerivacao);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoDerivacaoDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean ProdutoDerivacaoEstaSendoUsuado(string IdentificadorProdutoDerivacao)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTODERIVACAO", IdentificadorProdutoDerivacao);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.ProdutoDerivacaoEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.ProdutoDerivacao RecuperarProdutoDerivacao(string IdentificadorProdutoDerivacao)
        {
            if (string.IsNullOrEmpty(IdentificadorProdutoDerivacao))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoDerivacao objProdutoDerivacao = null;

            objSql.AdicionarParametro("IDPRODUTODERIVACAO", IdentificadorProdutoDerivacao);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoDerivacaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoDerivacao = new Comum.Clases.ProdutoDerivacao()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTODERIVACAO"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTODERIVACAO"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTODERIVACAO"], typeof(string)) as string
                };


            }

            return objProdutoDerivacao;
        }
    }
}
