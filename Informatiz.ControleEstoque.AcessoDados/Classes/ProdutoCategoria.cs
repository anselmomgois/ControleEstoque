using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoCategoria
    {

        public static List<Comum.Clases.ProdutoCategoria> RecuperarCategorias(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.ProdutoCategoria> objTiposProdutos = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESTIPOPRODUTO LIKE @DESTIPOPRODUTO ";
                objSql.AdicionarParametro("DESTIPOPRODUTO", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoCategoriaPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objTiposProdutos = new List<Comum.Clases.ProdutoCategoria>();

                foreach (DataRow dr in dt.Rows)
                {
                    objTiposProdutos.Add(new Comum.Clases.ProdutoCategoria
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPRODCATEGORIA"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODCATEGORIA"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODCATEGORIA"], typeof(string)) as string
                    });
                }
            }

            return objTiposProdutos;
        }

        public static void InserirProdutoCategoria(Comum.Clases.ProdutoCategoria objCategoria, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODCATEGORIA", Guid.NewGuid());
            objSql.AdicionarParametro("DESPRODCATEGORIA", objCategoria.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCategoriaInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarProdutoCategoria(Comum.Clases.ProdutoCategoria objCategoria)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODCATEGORIA", objCategoria.Identificador);
            objSql.AdicionarParametro("DESPRODCATEGORIA", objCategoria.Descricao.ToUpper());

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCategoriaAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarProdutoCategoria(string IdentificadorProdutoCategoria)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODCATEGORIA", IdentificadorProdutoCategoria);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ProdutoCategoriaDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean ProdutoCategoriaEstaSendoUsuado(string IdentificadorProdutoCategoria)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPRODCATEGORIA", IdentificadorProdutoCategoria);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.ProdutoCategoriaEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.ProdutoCategoria RecuperarProdutoCategoria(string IdentificadorProdutoCategoria)
        {

            if (string.IsNullOrEmpty(IdentificadorProdutoCategoria))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.ProdutoCategoria objProdutoCategoria = null;

            objSql.AdicionarParametro("IDPRODCATEGORIA", IdentificadorProdutoCategoria);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoCategoriaRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoCategoria = new Comum.Clases.ProdutoCategoria()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPRODCATEGORIA"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPRODCATEGORIA"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPRODCATEGORIA"], typeof(string)) as string
                };


            }

            return objProdutoCategoria;
        }
    }
}
