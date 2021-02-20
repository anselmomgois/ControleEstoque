using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoMarca
    {


        public static List<Comum.Clases.ProdutoMarca> RecuperarMarca(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoMarca> objProdutoMarca = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESTIPOPRODUTO LIKE @DESTIPOPRODUTO ";
                objSql.AdicionarParametro("DESTIPOPRODUTO", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoMarcaPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoMarca = new List<Comum.Clases.ProdutoMarca>();

                foreach (DataRow dr in dt.Rows)
                {
                    objProdutoMarca.Add(new Comum.Clases.ProdutoMarca
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODUTOMARCA"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTOMARCA"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTOMARCA"], typeof(string)) as string
                    });
                }
            }

            return objProdutoMarca;
        }

        public static void InserirProdutoMarca(Comum.Clases.ProdutoMarca objMarca, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOMARCA", Guid.NewGuid());
            objSql.AdicionarParametro("DESPRODUTOMARCA", objMarca.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            
            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoMarcaInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarProdutoMarca(Comum.Clases.ProdutoMarca objMarca)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOMARCA", objMarca.Identificador);
            objSql.AdicionarParametro("DESPRODUTOMARCA", objMarca.Descricao.ToUpper());

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoMarcaAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarProdutoMarca(string IdentificadorProdutoMarca)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOMARCA", IdentificadorProdutoMarca);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoMarcaDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean ProdutoMarcaEstaSendoUsuada(string IdentificadorProdutoMarca)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODUTOMARCA", IdentificadorProdutoMarca);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.ProdutoMarcaEstaSendoUsuada, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.ProdutoMarca RecuperarProdutoMarca(string IdentificadorProdutoMarca)
        {

            if (string.IsNullOrEmpty(IdentificadorProdutoMarca))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoMarca objProdutoMarca = null;

            objSql.AdicionarParametro("IDPRODUTOMARCA", IdentificadorProdutoMarca);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoMarcaRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoMarca = new Comum.Clases.ProdutoMarca()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODUTOMARCA"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODUTOMARCA"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODUTOMARCA"], typeof(string)) as string
                };


            }

            return objProdutoMarca;
        }
    }
}
