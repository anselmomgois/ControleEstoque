using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class ProdutoComissao
    {

       public static List<Comum.Clases.ProdutoComissao> RecuperarComissoes(string Descricao, string IdentificadorFilial)
       {

           Sql objSql = new Sql();
           List<Comum.Clases.ProdutoComissao> objProdutoComissao = null;
           string objQuery = string.Empty;

           if (!string.IsNullOrEmpty(Descricao))
           {
               objQuery = " AND DESPRODUTOCOMISSAO LIKE @DESPRODUTOCOMISSAO ";
               objSql.AdicionarParametro("DESPRODUTOCOMISSAO", "%" + Descricao.ToUpper() + "%");
           }

           objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);

           DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoComissaoPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           if (dt != null && dt.Rows.Count > 0)
           {

               objProdutoComissao = new List<Comum.Clases.ProdutoComissao>();

               foreach (DataRow dr in dt.Rows)
               {
                   objProdutoComissao.Add(new Comum.Clases.ProdutoComissao
                   {
                       Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOCOMISSAO"], typeof(string)) as string,
                       Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTOCOMISSAO"], typeof(Int32))),
                       Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTOCOMISSAO"], typeof(string)) as string,
                       NumPercentual = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMCOMISSAOPER"], typeof(decimal))),
                       NumValor = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMCOMISSAOVALOR"], typeof(decimal))),
                       Habilitada = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLHABILITADA"], typeof(Boolean)))

                   });
               }
           }

           return objProdutoComissao;
       }

       public static void InserirProdutoComissao(Comum.Clases.ProdutoComissao objComissao, string IdentificadorFilial)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDPRODUTOCOMISSAO", Guid.NewGuid());
           objSql.AdicionarParametro("DESPRODUTOCOMISSAO", objComissao.Descricao.ToUpper());

           if (objComissao.NumPercentual == null)
           {
               objSql.AdicionarParametro("NUMCOMISSAOPER", DBNull.Value);
           }
           else
           {
               objSql.AdicionarParametro("NUMCOMISSAOPER", objComissao.NumPercentual);
           }
           
           if (objComissao.NumValor == null)
           {
               objSql.AdicionarParametro("NUMCOMISSAOVALOR", DBNull.Value);
           }
           else
           {
               objSql.AdicionarParametro("NUMCOMISSAOVALOR", objComissao.NumValor);
           }

           objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
           objSql.AdicionarParametro("BOLHABILITADA", true);
           
           objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoComissaoInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
       }

       public static void AtualizarProdutoComissao(Comum.Clases.ProdutoComissao objComissao)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDPRODUTOCOMISSAO", objComissao.Identificador);
           objSql.AdicionarParametro("DESPRODUTOCOMISSAO", objComissao.Descricao.ToUpper());
           if (objComissao.NumPercentual == null)
           {
               objSql.AdicionarParametro("NUMCOMISSAOPER", DBNull.Value);
           }
           else
           {
               objSql.AdicionarParametro("NUMCOMISSAOPER", objComissao.NumPercentual);
           }

           if (objComissao.NumValor == null)
           {
               objSql.AdicionarParametro("NUMCOMISSAOVALOR", DBNull.Value);
           }
           else
           {
               objSql.AdicionarParametro("NUMCOMISSAOVALOR", objComissao.NumValor);
           }
           objSql.AdicionarParametro("BOLHABILITADA", objComissao.Habilitada);

           objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoComissaoAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
       }

       public static void DesativarProdutoComissao(string IdentificadorProdutoComissao)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDPRODUTOCOMISSAO", IdentificadorProdutoComissao);
           objSql.AdicionarParametro("BOLHABILITADA", false);

           objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoComissaoDesativar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
       }

       public static Comum.Clases.ProdutoComissao RecuperarProdutoComissao(string IdentificadorProdutoComissao)
       {
           if (string.IsNullOrEmpty(IdentificadorProdutoComissao))
           {
               return null;
           }

           Sql objSql = new Sql();
           Comum.Clases.ProdutoComissao objProdutoComissao = null;

           objSql.AdicionarParametro("IDPRODUTOCOMISSAO", IdentificadorProdutoComissao);

           DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoComissaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           if (dt != null && dt.Rows.Count > 0)
           {

               objProdutoComissao = new Comum.Clases.ProdutoComissao()
               {
                   Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOCOMISSAO"], typeof(string)) as string,
                   Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTOCOMISSAO"], typeof(Int32))),
                   Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTOCOMISSAO"], typeof(string)) as string,
                   NumPercentual = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMCOMISSAOPER"], typeof(decimal))),
                   NumValor = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMCOMISSAOVALOR"], typeof(decimal))),
                   Habilitada = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLHABILITADA"], typeof(Boolean)))
               };


           }

           return objProdutoComissao;
       }
    }
}
