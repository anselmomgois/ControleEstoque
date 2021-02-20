using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class UnidadesMedida
    {

        public static List<Comum.Clases.UnidadeMedida> RecuperarUnidadesMedida(string Descricao, string IdentificadorEmpresa, Boolean RecuperarUnidadesFilhas)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.UnidadeMedida> objUnidades = null;
            string objQuery = string.Empty;

            if(!RecuperarUnidadesFilhas)
            {
                objQuery = " AND IDUNIDADEMEDIDAPAI IS NULL ";
            }

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESUNIDADEMEDIDA LIKE @DESUNIDADEMEDIDA ";
                objSql.AdicionarParametro("DESUNIDADEMEDIDA", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.UnidadeMedidaPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objUnidades = new List<Comum.Clases.UnidadeMedida>();
                string IdentificadorUnidadePai = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    IdentificadorUnidadePai = frmUtil.Util.AtribuirValorObj(dr["IDUNIDADEMEDIDAPAI"], typeof(string)) as string;

                    objUnidades.Add(new Comum.Clases.UnidadeMedida
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDUNIDADEMEDIDA"], typeof(string)) as string,
                        Codigo = frmUtil.Util.AtribuirValorObj(dr["CODUNIDADEMEDIDA"], typeof(string)) as string,
                        UnidademedidaPai = (!string.IsNullOrEmpty(IdentificadorUnidadePai) ? RecuperarUnidadeMedida(IdentificadorUnidadePai) : null),
                        NumValorUnidadePai = (Decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMUNIDADEPAI"], typeof(Decimal))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESUNIDADEMEDIDA"], typeof(string)) as string
                    });
                }
            }

            return objUnidades;
        }

        public static Comum.Clases.UnidadeMedida RecuperarUnidadeMedida(string IdentificadorUnidadeMedida)
        {

            if (string.IsNullOrEmpty(IdentificadorUnidadeMedida))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.UnidadeMedida objUnidadeMedida = null;

            objSql.AdicionarParametro("IDUNIDADEMEDIDA", IdentificadorUnidadeMedida);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.UnidadeMedidaRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                string IdentificadorUnidadePai = string.Empty;

                IdentificadorUnidadePai = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUNIDADEMEDIDAPAI"], typeof(string)) as string;

                objUnidadeMedida = new Comum.Clases.UnidadeMedida()
                   {
                       Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDUNIDADEMEDIDA"], typeof(string)) as string,
                       Codigo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODUNIDADEMEDIDA"], typeof(string)) as string,
                       UnidademedidaPai = (!string.IsNullOrEmpty(IdentificadorUnidadePai) ? RecuperarUnidadeMedida(IdentificadorUnidadePai) : null),
                       NumValorUnidadePai = (Decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMUNIDADEPAI"], typeof(Decimal))),
                       Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESUNIDADEMEDIDA"], typeof(string)) as string
                   };


            }

            return objUnidadeMedida;
        }

        public static void InserirUnidadeMedida(Comum.Clases.UnidadeMedida objUnidadeMedida, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDUNIDADEMEDIDA", Guid.NewGuid(), true);
            objSql.AdicionarParametro("CODUNIDADEMEDIDA", objUnidadeMedida.Codigo);
            objSql.AdicionarParametro("DESUNIDADEMEDIDA", objUnidadeMedida.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            if (objUnidadeMedida.NumValorUnidadePai != null)
            {
                objSql.AdicionarParametro("NUMUNIDADEPAI", objUnidadeMedida.NumValorUnidadePai);
            }
            else
            {
                objSql.AdicionarParametro("NUMUNIDADEPAI", DBNull.Value);
            }

            if (objUnidadeMedida.UnidademedidaPai != null)
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAPAI", objUnidadeMedida.UnidademedidaPai.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAPAI", DBNull.Value);
            }

            objSql.ExecutarNonQueryArquivo(Properties.Resources.UnidadeMedidaInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static void AtualizarUnidadeMedida(Comum.Clases.UnidadeMedida objUnidadeMedida)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDUNIDADEMEDIDA", objUnidadeMedida.Identificador, true);
            objSql.AdicionarParametro("CODUNIDADEMEDIDA", objUnidadeMedida.Codigo);
            objSql.AdicionarParametro("DESUNIDADEMEDIDA", objUnidadeMedida.Descricao.ToUpper());

            if (objUnidadeMedida.NumValorUnidadePai != null)
            {
                objSql.AdicionarParametro("NUMUNIDADEPAI", objUnidadeMedida.NumValorUnidadePai);
            }
            else
            {
                objSql.AdicionarParametro("NUMUNIDADEPAI", DBNull.Value);
            }

            if (objUnidadeMedida.UnidademedidaPai != null)
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAPAI", objUnidadeMedida.UnidademedidaPai.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDUNIDADEMEDIDAPAI", DBNull.Value);
            }

            objSql.ExecutarNonQueryArquivo(Properties.Resources.UnidadeMedidaAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static void DeletarUnidadeMedida(string IdentificadorUnidadeMedida)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDUNIDADEMEDIDA", IdentificadorUnidadeMedida);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.UnidadeMedidaDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean UnidadeMedidaEstaSendoUsuada(string IdentificadorUnidadeMedida)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDUNIDADEMEDIDA", IdentificadorUnidadeMedida);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.UnidadeMedidaVerificarEstaSendoUsada, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            return (Boolean)((dt != null && dt.Rows.Count > 0) ? true : false);
        }

        public static List<Comum.Clases.UnidadeMedida> RecuperarUnidadesMedidaProduto(string IdentificadorProduto)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.UnidadeMedida> objUnidades = null;

            objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProduto);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.UnidadeMedidaRecuperarUnidadesProduto, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objUnidades = new List<Comum.Clases.UnidadeMedida>();
                string IdentificadorUnidadePai = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    IdentificadorUnidadePai = frmUtil.Util.AtribuirValorObj(dr["IDUNIDADEMEDIDAPAI"], typeof(string)) as string;

                    objUnidades.Add(new Comum.Clases.UnidadeMedida
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDUNIDADEMEDIDA"], typeof(string)) as string,
                        Codigo = frmUtil.Util.AtribuirValorObj(dr["CODUNIDADEMEDIDA"], typeof(string)) as string,
                        UnidademedidaPai = (!string.IsNullOrEmpty(IdentificadorUnidadePai) ? RecuperarUnidadeMedida(IdentificadorUnidadePai) : null),
                        NumValorUnidadePai = (Decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMUNIDADEPAI"], typeof(Decimal))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESUNIDADEMEDIDA"], typeof(string)) as string
                    });
                }
            }

            return objUnidades;
        }

    }
}
