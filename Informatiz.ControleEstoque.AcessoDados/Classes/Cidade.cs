using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Cidade
    {

        #region"Consultas"

        public static List<Comum.Clases.Cidade> RecuperarCidades(string Identificador, string IdentificadorEstado, string Nome, string NomePesquisar, 
                                                                 Nullable<int> Codigo)
        {

            List<Comum.Clases.Cidade> Cidades = null;
            Sql objSql = new Sql();
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Identificador))
            {
                objQuery = " WHERE C.IDCIDADE = @IDCIDADE ";
                objSql.AdicionarParametro("IDCIDADE", Identificador);
            }
            else
            {
                objQuery = " WHERE E.IDESTADO = @IDESTADO ";
                objSql.AdicionarParametro("IDESTADO", IdentificadorEstado);
            }


            if (!string.IsNullOrEmpty(Nome))
            {
                objQuery += " AND C.DESCIDADE = @DESCIDADE ";
                objSql.AdicionarParametro("DESCIDADE", Nome.ToUpper());
            }
            else if (!string.IsNullOrEmpty(NomePesquisar))
            {
                objQuery += " AND C.DESCIDADE LIKE @DESCIDADE ";
                objSql.AdicionarParametro("DESCIDADE", "%" + NomePesquisar.ToUpper() + "%");
            }

            if (Codigo != null)
            {
                objQuery += " AND C.CODCIDADE = @CODCIDADE ";
                objSql.AdicionarParametro("CODCIDADE", Codigo);
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.CidadeRecuperar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
          

            if (dt != null && dt.Rows.Count > 0)
            {

                Cidades = new List<Comum.Clases.Cidade>();

                foreach (DataRow dr in dt.Rows)
                {

                    Cidades.Add(new Comum.Clases.Cidade()
                    {
                        Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODCIDADE"], typeof(int)),
                        DDD = frmUtil.Util.AtribuirValorObj(dr["CODDDD"], typeof(string)) as string,
                        IBGE = frmUtil.Util.AtribuirValorObj(dr["CODIBGE"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDCIDADE"], typeof(string)) as string,
                        Nome = frmUtil.Util.AtribuirValorObj(dr["DESCIDADE"], typeof(string)) as string

                    });

                }
            }

            return Cidades;
        }

        #endregion

        #region"Inserir"

        public static string InserirCidade(string Nome, string IdentificadorEstado, string CodDDD, string CodIbge, ref Sql objSql)
        {

            string IdentificadorCidade = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDCIDADE", IdentificadorCidade, true);
            objSql.AdicionarParametro("IDESTADO", IdentificadorEstado);
            objSql.AdicionarParametro("DESCIDADE", Nome.ToUpper());
            objSql.AdicionarParametro("CODDDD", (string.IsNullOrEmpty(CodDDD) ? DBNull.Value.ToString() : CodDDD));
            objSql.AdicionarParametro("CODIBGE", (string.IsNullOrEmpty(CodIbge) ? DBNull.Value.ToString() : CodIbge));

            objSql.AdicionarTransacao(Properties.Resources.CidadeInserir);

            return IdentificadorCidade;
        }
        #endregion

        #region "Atualizar"

        public static void AtualizarCidade(string Nome, string IdentificadorCidade, string CodDDD, string CodIbge, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDCIDADE", IdentificadorCidade, true);
            objSql.AdicionarParametro("DESCIDADE", Nome.ToUpper());
            objSql.AdicionarParametro("CODDDD", (string.IsNullOrEmpty(CodDDD) ? DBNull.Value.ToString() : CodDDD));
            objSql.AdicionarParametro("CODIBGE",(string.IsNullOrEmpty(CodIbge) ? DBNull.Value.ToString() : CodIbge));

            objSql.AdicionarTransacao(Properties.Resources.CidadeAtualizar);

        }

        #endregion
    }
}
