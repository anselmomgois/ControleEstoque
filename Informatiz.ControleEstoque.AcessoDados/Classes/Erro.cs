using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class Erro
    {

        public static void InerirErro(Comum.Clases.Erro objErro)
        {

            Sql objFrm = new Sql();

            objFrm.AdicionarParametro("IDLOGERROR", Guid.NewGuid());
            objFrm.AdicionarParametro("DESERROR", objErro.DesErro);
            objFrm.AdicionarParametro("DESPESSOA", string.IsNullOrEmpty(objErro.Usuario) ? DBNull.Value.ToString() : objErro.Usuario);
            objFrm.AdicionarParametro("DTHERROR", DateTime.Now);

            objFrm.ExecutarNonQueryArquivo(Properties.Resources.ErroInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }
    }
}
