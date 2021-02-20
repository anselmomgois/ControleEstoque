using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Estado
    {

        public static List<Comum.Clases.Estado> RecuperarEstado(string Codigo, string Identificador)
        {

            Sql objSql = new Sql();
            string query = string.Empty;
            List<Comum.Clases.Estado> objEstados = null;

            if (!string.IsNullOrEmpty(Identificador))
            {
                query = " WHERE IDESTADO = @IDESTADO ";
                objSql.AdicionarParametro("IDESTADO", Identificador);
            }
            else if (!string.IsNullOrEmpty(Codigo))
            {
                query = " WHERE CODESTADO = @CODESTADO ";
                objSql.AdicionarParametro("CODESTADO", Codigo);
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.EstadoRecuperar + query, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
            
            if (dt != null && dt.Rows.Count > 0)
            {

                objEstados = new List<Comum.Clases.Estado>();

                foreach (DataRow dr in dt.Rows)
                {

                    objEstados.Add(new Comum.Clases.Estado
                    {
                        CodIbge = frmUtil.Util.AtribuirValorObj(dr["CODIBGE"], typeof(string)) as string,
                        Codigo = frmUtil.Util.AtribuirValorObj(dr["CODESTADO"], typeof(string)) as string,
                        ICMS = (decimal)frmUtil.Util.AtribuirValorObj(dr["NUMICMS"], typeof(decimal)),
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDESTADO"], typeof(string)) as string,
                        Nome = frmUtil.Util.AtribuirValorObj(dr["DESESTADO"], typeof(string)) as string
                    });


                }
            }

            return objEstados;
        }
    }
}
