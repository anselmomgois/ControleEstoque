using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Informatiz.ControleEstoque.Comum;
using Informatiz.ControleEstoque.Execao;
using AmgSistemas.Framework.AcessoDados;
using AmgSistemas.Framework.Criptografia;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Permissao
    {

        #region"Consultas"

        public static List<Comum.Clases.Permissao> RecuperarPermissaoUsuario(string IdentificadorUsuario)
        {

            List<Comum.Clases.Permissao> objPermissoes = null;

            Sql objFrm = new Sql();

            objFrm.AdicionarParametro("IDPESSOA", IdentificadorUsuario, true);

            DataTable dt = objFrm.ExecutarDataTableArquivo(Properties.Resources.PermissaoRecuperarComIdUsuario, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                string IdentificadorPermissao = string.Empty;
                objPermissoes = new List<Comum.Clases.Permissao>();
                Comum.Clases.Permissao objPermissao = null;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorPermissao = frmUtil.Util.AtribuirValorObj(dr["IDPERMISSAO"], typeof(string)) as string;

                    objPermissao = (from Comum.Clases.Permissao p in objPermissoes where p.Identificador == IdentificadorPermissao select p).FirstOrDefault();

                    if (objPermissao == null)
                    {

                        objPermissoes.Add(new Comum.Clases.Permissao
                        {
                            Identificador = IdentificadorPermissao,
                            Codigo = frmUtil.Util.AtribuirValorObj(dr["CODPERMISSAO"], typeof(string)) as string,
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPERMISSAO"], typeof(string)) as string,
                            IdentificadorGrupoPermissao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOPERMISSAO"], typeof(string)) as string,
                            Acoes = new List<Comum.Clases.Acao>()
                        });

                        objPermissao = (from Comum.Clases.Permissao p in objPermissoes where p.Identificador == IdentificadorPermissao select p).FirstOrDefault();

                    }

                    objPermissao.Acoes.Add(new Comum.Clases.Acao
                    {
                        TipoAcao = (Comum.Enumeradores.Enumeradores.TipoAcao)(frmUtil.Util.AtribuirValorObj(dr["CODACAO"], typeof(int))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESACAO"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDACAO"], typeof(string)) as string
                    });

                }

            }

            return objPermissoes;
        }


        public static List<Comum.Clases.Permissao> RecuperarPermissoes(Boolean ExecutarComArquivo)
        {

            List<Comum.Clases.Permissao> Permissoes = null;

            Sql objSql = new Sql();

            DataTable dt = null;

            if (ExecutarComArquivo)
            {
                dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PermissaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
            }
            else
            {
                dt = objSql.ExecutarDataTable(Properties.Resources.PermissaoRecuperar, Comum.Clases.Constantes.STRING_CONEXAO);
            }

            if (dt != null && dt.Rows.Count > 0)
            {

                Permissoes = new List<Comum.Clases.Permissao>();

                Comum.Clases.Permissao objPermissao = null;
                string IdentificadorPermissao = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorPermissao = frmUtil.Util.AtribuirValorObj(dr["IDPERMISSAO"], typeof(string)) as string;

                    objPermissao = (from Comum.Clases.Permissao p in Permissoes where p.Identificador == IdentificadorPermissao select p).FirstOrDefault();

                    if (objPermissao == null)
                    {

                        Permissoes.Add(new Comum.Clases.Permissao
                        {
                            Identificador = IdentificadorPermissao,
                            Codigo = frmUtil.Util.AtribuirValorObj(dr["CODPERMISSAO"], typeof(string)) as string,
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPERMISSAO"], typeof(string)) as string,
                            Obrigatoria = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLOBRIGATORIA"], typeof(Boolean))),
                            Acoes = new List<Comum.Clases.Acao>()
                        });

                        objPermissao = (from Comum.Clases.Permissao p in Permissoes where p.Identificador == IdentificadorPermissao select p).FirstOrDefault();
                    }

                    objPermissao.Acoes.Add(new Comum.Clases.Acao
                    {
                        TipoAcao = (Comum.Enumeradores.Enumeradores.TipoAcao)(frmUtil.Util.AtribuirValorObj(dr["CODACAO"], typeof(int))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESACAO"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDACAO"], typeof(string)) as string
                    });

                }
            }


            return Permissoes;
        }

        #endregion

        #region"Deletar"

        public static void DeletarPermissoesPessoa(string IdentificadorUsuario, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPESSOA", IdentificadorUsuario, true);

            objSql.AdicionarTransacao(Properties.Resources.PermissaoUsuarioDeletar);
        }

        #endregion


        #region"Inserir"

        public static void InserirPermissoesPessoa(string IdentificadorUsuario, string IdentificadorPermissao, string IdentificadorAcao,
                                                   string IdentificadorGrupoPermissao, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDUSUPERMISSAOACAO", Guid.NewGuid(), true);
            objSql.AdicionarParametro("IDPERMISSAO", IdentificadorPermissao);
            objSql.AdicionarParametro("IDACAO", IdentificadorAcao);
            objSql.AdicionarParametro("IDPESSOA", IdentificadorUsuario);

            if (string.IsNullOrEmpty(IdentificadorGrupoPermissao))
            {
                objSql.AdicionarParametro("IDGRUPOPERMISSAO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDGRUPOPERMISSAO", frmUtil.Util.RetornaDbNull(IdentificadorGrupoPermissao));
            }


            objSql.AdicionarTransacao(Properties.Resources.PermissaoUsuarioInserir);
        }

        #endregion


    }
}
