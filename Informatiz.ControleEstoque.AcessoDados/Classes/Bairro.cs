using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Bairro
    {

        #region "Consultas"

        public static List<Comum.Clases.Bairro> RecuperarBairro(string IdentificadorCidade, string Identificador, string Nome, string NomePesquisar,
                                                                Nullable<int> Codigo)
        {

            Sql objSql = new Sql();
            string objQuery = string.Empty;
            List<Comum.Clases.Bairro> objBairros = null;

            if (!string.IsNullOrEmpty(IdentificadorCidade))
            {

                objQuery = " WHERE IDCIDADE = @IDCIDADE ";
                objSql.AdicionarParametro("IDCIDADE", IdentificadorCidade);
            }
            else
            {
                objQuery = " WHERE IDBAIRRO = @IDBAIRRO ";
                objSql.AdicionarParametro("IDBAIRRO", Identificador);
            }


            if (!string.IsNullOrEmpty(Nome))
            {
                objQuery += " AND DESBAIRRO = @DESBAIRRO ";
                objSql.AdicionarParametro("DESBAIRRO", Nome.ToUpper());
            }
            else if (!string.IsNullOrEmpty(NomePesquisar))
            {
                objQuery += " AND DESBAIRRO LIKE @DESBAIRRO ";
                objSql.AdicionarParametro("DESBAIRRO", "%" + NomePesquisar.ToUpper() + "%");
            }

            if (Codigo != null)
            {
                objQuery += " AND CODBAIRRO = @CODBAIRRO ";
                objSql.AdicionarParametro("CODBAIRRO", Codigo);
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.BairroRecuperar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
            
            if (dt != null && dt.Rows.Count > 0)
            {

                objBairros = new List<Comum.Clases.Bairro>();

                foreach (DataRow dr in dt.Rows)
                {

                    objBairros.Add(new Comum.Clases.Bairro()
                    {
                        Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODBAIRRO"], typeof(int)),
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDBAIRRO"], typeof(string)) as string,
                        Nome = frmUtil.Util.AtribuirValorObj(dr["DESBAIRRO"], typeof(string)) as string

                    });

                }
            }

            return objBairros;
        }
        #endregion

        #region"Inserir"

        public static string InserirBairro(string IdentificadorCidade, string Nome, ref Sql objSql)
        {
            string IdentificadorBairro = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDBAIRRO", IdentificadorBairro, true);
            objSql.AdicionarParametro("IDCIDADE", IdentificadorCidade);
            objSql.AdicionarParametro("DESBAIRRO", Nome.ToUpper());

            objSql.AdicionarTransacao(Properties.Resources.BairroInserir);

            return IdentificadorBairro;

        }

        #endregion

        #region "Atualizar"

        public static void AtualizarBairro(string Nome, string IdentificadorBairro, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDBAIRRO", IdentificadorBairro, true);
            objSql.AdicionarParametro("DESBAIRRO", Nome.ToUpper());

            objSql.AdicionarTransacao(Properties.Resources.BairroAtualizar);

        }

        #endregion
    }
}
