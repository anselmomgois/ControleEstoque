using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Publicidade
    {

        public static List<Comum.Clases.Publicidade> RecuperarPublicidades(string Descricao)
        {

            List<Comum.Clases.Publicidade> Publicidades = null;
            Sql objSql = new Sql();

            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESPUBLICIDADE LIKE @DESPUBLICIDADE ";
                objSql.AdicionarParametro("DESPUBLICIDADE", "%" + Descricao.ToUpper() + "%");
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PublicidadeRecuperar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
            

            if (dt != null && dt.Rows.Count > 0)
            {

                Publicidades = new List<Comum.Clases.Publicidade>();

                foreach (DataRow dr in dt.Rows)
                {
                    Publicidades.Add(new Comum.Clases.Publicidade
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPUBLICIDADE"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPUBLICIDADE"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPUBLICIDADE"], typeof(string)) as string
                    });
                }
            }

            return Publicidades;
        }

        public static void InserirPublicidade(Comum.Clases.Publicidade objPublicidade)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPUBLICIDADE", Guid.NewGuid());
            objSql.AdicionarParametro("DESPUBLICIDADE", objPublicidade.Descricao.ToUpper());
            
            objSql.ExecutarNonQueryArquivo(Properties.Resources.PublicidadeInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarPublicidade(Comum.Clases.Publicidade objPublicidade)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPUBLICIDADE", objPublicidade.Identificador);
            objSql.AdicionarParametro("DESPUBLICIDADE", objPublicidade.Descricao.ToUpper());

            objSql.ExecutarNonQueryArquivo(Properties.Resources.PublicidadeAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarPublicidade(string IdentificadorPublicidade)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPUBLICIDADE", IdentificadorPublicidade);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.PublicidadeDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean PublicidadeEstaSendoUsuada(string IdentificadorPublicidade)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPUBLICIDADE", IdentificadorPublicidade);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.PublicidadeEstaSendoUsada, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.Publicidade RecuperarPublicidade(string IdentificadorPublicidade)
        {

            if (string.IsNullOrEmpty(IdentificadorPublicidade))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.Publicidade objPublicidade = null;

            objSql.AdicionarParametro("IDPUBLICIDADE", IdentificadorPublicidade);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PublicidadeRecuperarComIdentificador, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objPublicidade = new Comum.Clases.Publicidade()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPUBLICIDADE"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPUBLICIDADE"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPUBLICIDADE"], typeof(string)) as string
                };


            }

            return objPublicidade;
        }
    }
}
