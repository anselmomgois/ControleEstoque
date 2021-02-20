using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class TipoProdutoServico
    {

        public static Comum.Clases.TipoProdutoServico RecuperarTipoProdutoServico(string IdentificadorProdutoServico)
        {

            if (string.IsNullOrEmpty(IdentificadorProdutoServico))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.TipoProdutoServico objProdutoServico = null;

            objSql.AdicionarParametro("IDTIPOPRODUTO", IdentificadorProdutoServico);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.TipoProdutoServicoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoServico = new Comum.Clases.TipoProdutoServico()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDTIPOPRODUTO"], typeof(string)) as string,
                    Codigo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODTIPOPRODUTO"], typeof(string)) as string,
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTIPOPRODUTO"], typeof(string)) as string
                };


            }

            return objProdutoServico;
        }

        public static Comum.Clases.TipoProdutoServico RecuperarTipoProdutoServicoComCodigo(string CodigoProdutoServico)
        {

            if (string.IsNullOrEmpty(CodigoProdutoServico))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.TipoProdutoServico objProdutoServico = null;

            objSql.AdicionarParametro("CODTIPOPRODUTO", CodigoProdutoServico);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.TipoProdutoServicoRecuperarComCodigo, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProdutoServico = new Comum.Clases.TipoProdutoServico()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDTIPOPRODUTO"], typeof(string)) as string,
                    Codigo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODTIPOPRODUTO"], typeof(string)) as string,
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTIPOPRODUTO"], typeof(string)) as string
                };


            }

            return objProdutoServico;
        }

    }
}
