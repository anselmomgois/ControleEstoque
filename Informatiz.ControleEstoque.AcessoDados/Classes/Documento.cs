using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class Documento
    {

       public static List<Comum.Clases.Documento> RecuperarDocumentos(string IdentificadorCliente, string CodigoTransacao, 
                                                                       Nullable<DateTime> DataInicio, Nullable<DateTime> DataFim, 
                                                                       string IdentificadorTipodocumento,
                                                                       string CodigoDocumento, string IdentificadorFilial, string IdentificadorEmpresa)
       {

           Sql objSql = new Sql();
           List<Comum.Clases.Documento> objDocumentos= null;
           string objQuery = string.Empty;
           
           if (!string.IsNullOrEmpty(IdentificadorCliente))
           {
               objQuery = " AND IDPESSOA = @IDPESSOA ";
               objSql.AdicionarParametro("IDPESSOA", IdentificadorCliente);
           }

           objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

           //DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.DocumentoPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           //if (dt != null && dt.Rows.Count > 0)
           //{

           //    objProdutoMarca = new List<Comum.Clases.ProdutoMarca>();

           //    foreach (DataRow dr in dt.Rows)
           //    {
           //        objProdutoMarca.Add(new Comum.Clases.ProdutoMarca
           //        {
           //            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOMARCA"], typeof(string)) as string,
           //            Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTOMARCA"], typeof(Int32))),
           //            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTOMARCA"], typeof(string)) as string
           //        });
           //    }
           //}

           return objDocumentos;
       }
    }
}
