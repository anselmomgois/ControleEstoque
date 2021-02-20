using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class SituacaoPessoa
    {

        public static List<Comum.Clases.SituacaoPessoa> RecuperarSituacaoPessoa(string Identificador)
        {

            Sql objSql = new Sql();
            string objQuery = string.Empty;
            List<Comum.Clases.SituacaoPessoa> objColSituacao = null;

            if (!string.IsNullOrEmpty(objQuery))
            {

                objQuery = " WHERE IDSITUACAOPESSOA = @IDSITUACAOPESSOA ";
                objSql.AdicionarParametro("IDSITUACAOPESSOA", Identificador);

            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.SituacaoPessoaRecuperar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objColSituacao = new List<Comum.Clases.SituacaoPessoa>();

                foreach (DataRow dr in dt.Rows)
                {

                    objColSituacao.Add(new Comum.Clases.SituacaoPessoa
                    {
                        Codigo = frmUtil.Util.AtribuirValorObj(dr["CODSITUACAO"], typeof(string)) as string,
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESSITUACAO"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDSITUACAOPESSOA"], typeof(string)) as string
                    });

                }
            }
            return objColSituacao;
        }

    }
}
