using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class FilialPessoa
    {

        public static void InseirPessoaFilial(string IdentificadorFilial, string IdentificadorPessoa, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDFILIALPESSOA", Guid.NewGuid(), true);
            objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
            objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);

            objSql.AdicionarTransacao(Properties.Resources.PessoaFilialInserir);

        }

        public static void DeletarPessoaFilial(string IdentificadorPessoa, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa,true);

            objSql.AdicionarTransacao(Properties.Resources.PessoaFilialDeletar);

        }

        public static List<Comum.Clases.Filiais> RecuperarFiliaisPessoa(string IdentificadorPessoa)
        {

            List<Comum.Clases.Filiais> objFiliais = null;
            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.FilialPessoaRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objFiliais = new List<Comum.Clases.Filiais>();

                foreach (DataRow dr in dt.Rows)
                {

                    objFiliais.Add(new Comum.Clases.Filiais
                    {
                        Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODFILIAL"], typeof(int))),
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDFILIAL"], typeof(string)) as string,
                        Nome = frmUtil.Util.AtribuirValorObj(dr["DESFILIAL"], typeof(string)) as string
                    });
                }
            }

            return objFiliais;
        }
    }
}
