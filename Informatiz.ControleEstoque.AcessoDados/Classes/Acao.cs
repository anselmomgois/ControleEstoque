using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Acao
    {

        public static List<Comum.Clases.Acao> RecuperarAcoes()
        {

            List<Comum.Clases.Acao> Acoes = null;

            Sql objSql = new Sql();

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.AcaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                Acoes = new List<Comum.Clases.Acao>();

                foreach (DataRow dr in dt.Rows)
                {

                    Acoes.Add(new Comum.Clases.Acao
                    {
                        TipoAcao = (Comum.Enumeradores.Enumeradores.TipoAcao)(frmUtil.Util.AtribuirValorObj(dr["CODACAO"], typeof(int))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESACAO"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDACAO"], typeof(string)) as string
                    });
                                                      
                }
            }

            
            return Acoes;
        }
    }
}
