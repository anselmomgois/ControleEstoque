using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class ProdutoCompra
    {

        public static Comum.Clases.ProdutoCompra RecuperarProdutoCompra(string IdentificadorProdutoCompra)
        {

            Comum.Clases.ProdutoCompra objProdutoCompra = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorProdutoCompra);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ProdutoCompraRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);


            return objProdutoCompra;
        }
    }
}
