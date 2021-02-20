using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes.Servico
{
    public class Versao
    {
        public static string RecuperarVersao()
        {

            string strVersao = null;

            Sql objSql = new Sql();

            object objVersao = (object)(objSql.ExecutarScalarArquivo(Properties.Resources.VersaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO));

            if (objVersao != null)
            {
                strVersao = objVersao as string;
            }
            return strVersao;
        }
    }
}
