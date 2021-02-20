using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;
using AmgSistemas.Framework.AcessoDados;



namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class Sessao
    {

       public static List<Comum.Clases.Sessoes> RecuperarSessoes(string IdentificadorEmpresa)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

           DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.SessoesRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
           List<Comum.Clases.Sessoes> objSessoes = null;

           if (dt != null && dt.Rows.Count > 0)
           {
               objSessoes = new List<Comum.Clases.Sessoes>();

               foreach (DataRow dr in dt.Rows)
               {

                   objSessoes.Add(new Comum.Clases.Sessoes()
                   {
                       DataInicio = (DateTime)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHINICIO"], typeof(DateTime)),
                       DataUltimoUso = (DateTime)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHULTIMOUSO"], typeof(DateTime)),
                       Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDSESSAO"], typeof(string)) as string,
                       IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOA"], typeof(string)) as string
                   });
               }
           }
           return objSessoes;
       }

       public static string InserirSessao(string IdentificadorFilial, string IdentificadorUsuario, ref Sql objSql)
       {

           string IdentificadorSessao = Convert.ToString(Guid.NewGuid());

           objSql.AdicionarParametro("IDSESSAO", IdentificadorSessao, true);
           objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
           objSql.AdicionarParametro("IDPESSOA", IdentificadorUsuario);
           objSql.AdicionarParametro("DTHINICIO", DateTime.Now);
           objSql.AdicionarParametro("DTHFIM", DateTime.Now);
           objSql.AdicionarParametro("DTHULTIMOUSO", DateTime.Now);

           objSql.AdicionarTransacao(Properties.Resources.SessaoInserir);

           return IdentificadorSessao;
       }

       public static void DeletarSessao(string IdentificadorSessao, ref Sql objSql)
       {

           objSql.AdicionarParametro("IDSESSAO", IdentificadorSessao, true);

           objSql.AdicionarTransacao(Properties.Resources.SessaoDeletar);
       }

       public static void AtualizarSessao(string IdentificadorSessao)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDSESSAO", IdentificadorSessao);
           objSql.AdicionarParametro("DTHULTIMOUSO", DateTime.Now);

           objSql.ExecutarNonQueryArquivo(Properties.Resources.SessaoAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
       }

       public static Boolean SessaoExiste(string IdentificadorSessao)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDSESSAO", IdentificadorSessao);

           object resultado = objSql.ExecutarScalarArquivo(Properties.Resources.SessaoValidarExiste, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           if (resultado != null)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

    }
}
