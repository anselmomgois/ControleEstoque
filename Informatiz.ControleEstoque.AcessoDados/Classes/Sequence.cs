using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Sequence
    {

        public static Int64 RecuperarProximoNumeroCompra()
        {

           Int64 NumeroCompra = 0;

            Sql objSql = new Sql();

            NumeroCompra = (Int64)objSql.ExecutarScalarArquivo("SELECT NEXT VALUE FOR INFM_SEQ_NUMEROCOMPRA", Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           
            return NumeroCompra;
        }

    }
}
