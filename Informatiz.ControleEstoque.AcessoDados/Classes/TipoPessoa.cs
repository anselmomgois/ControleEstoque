using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;


namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class TipoPessoa
    {

       public static void InserirTipoPessoa(string IdentificadorPessoa, string IdentificadorTipo, ref Sql objSql)
       {

           objSql.AdicionarParametro("IDTIPOPESSOAPESSOA",Guid.NewGuid(), true);
           objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);
           objSql.AdicionarParametro("IDTIPOPESSOA", IdentificadorTipo);

           objSql.AdicionarTransacao(Properties.Resources.TipoPessoaInserir);
       }
    }
}
