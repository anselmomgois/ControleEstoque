using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class GrupoPermissao
    {

        public static string InserirGrupoPermissao(Comum.Clases.GrupoPermissao objGrupoPermissao, ref Sql objsql)
        {

            string IdentificadorGrupo = Convert.ToString(Guid.NewGuid());

            objsql.AdicionarParametro("IDGRUPOPERMISSAO", IdentificadorGrupo, true);
            objsql.AdicionarParametro("DESGRUPO", objGrupoPermissao.Nome.ToUpper());
            objsql.AdicionarParametro("IDEMPRESA", objGrupoPermissao.IdentificadorEmpresa);

            objsql.AdicionarTransacao(Properties.Resources.GrupoPermissaoInserir);

            return IdentificadorGrupo;
        }

        public static void AtualizarGrupoPermissao(Comum.Clases.GrupoPermissao objGrupoPermissao, ref Sql objsql)
        {

            objsql.AdicionarParametro("IDGRUPOPERMISSAO", objGrupoPermissao.Identificador, true);
            objsql.AdicionarParametro("DESGRUPO", objGrupoPermissao.Nome.ToUpper());

            objsql.AdicionarTransacao(Properties.Resources.GrupoPermissaoAtualizar);

        }

        public static void DeletarGrupoPermissao(string IdentificadorGrupo, ref Sql objsql)
        {

            objsql.AdicionarParametro("IDGRUPOPERMISSAO", IdentificadorGrupo, true);
            
            objsql.AdicionarTransacao(Properties.Resources.GrupoPermissaoDeletar);

        }

        public static void InserirPermissao(string IdentificadorGrupo, string IdentificadorPermissao, string IdentificadorAcao, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOPERMISSAOACAO", Convert.ToString(Guid.NewGuid()), true);
            objSql.AdicionarParametro("IDPERMISSAO", IdentificadorPermissao);
            objSql.AdicionarParametro("IDACAO", IdentificadorAcao);
            objSql.AdicionarParametro("IDGRUPOPERMISSAO", IdentificadorGrupo);

            objSql.AdicionarTransacao(Properties.Resources.GrupoPermissaoAcaoInserir);

        }

        public static void DeletarPermissao(string IdentificadorGrupo, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOPERMISSAO", IdentificadorGrupo, true);


            objSql.AdicionarTransacao(Properties.Resources.GrupoPermissaoAcaoDeletar);

        }

        public static List<Comum.Clases.GrupoPermissao> RecuperarGrupos(string Nome, string IdentificadorEmprsa)
        {

            List<Comum.Clases.GrupoPermissao> objGrupos = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("DESGRUPO", "%" + Nome.ToUpper() + "%");
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmprsa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoPermissaoPesquisar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objGrupos = new List<Comum.Clases.GrupoPermissao>();

                foreach (DataRow dr in dt.Rows)
                {

                    objGrupos.Add(new Comum.Clases.GrupoPermissao
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOPERMISSAO"], typeof(string)) as string,
                        Nome = frmUtil.Util.AtribuirValorObj(dr["DESGRUPO"], typeof(string)) as string
                    });
                }
            }

            return objGrupos;
        }

        public static Comum.Clases.GrupoPermissao RecuperarGrupo(string Identificador)
        {

            Comum.Clases.GrupoPermissao objGrupoPermissao = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDGRUPOPERMISSAO", Identificador);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoPermissaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objGrupoPermissao = new Comum.Clases.GrupoPermissao();

                objGrupoPermissao.Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOPERMISSAO"], typeof(string)) as string;
                objGrupoPermissao.Nome = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESGRUPO"], typeof(string)) as string;

                objGrupoPermissao.Permissoes = new List<Comum.Clases.Permissao>();

                Comum.Clases.Permissao objPermissao = null;
                string IdentificadorPermissao = string.Empty;
                string IdentificadorAcao = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorPermissao = frmUtil.Util.AtribuirValorObj(dr["IDPERMISSAO"], typeof(string)) as string;
                    IdentificadorAcao = frmUtil.Util.AtribuirValorObj(dr["IDACAO"], typeof(string)) as string;

                    objPermissao = (from Comum.Clases.Permissao objP in objGrupoPermissao.Permissoes where objP.Identificador == IdentificadorPermissao select objP).FirstOrDefault();

                    if (objPermissao == null)
                    {

                        objGrupoPermissao.Permissoes.Add(new Comum.Clases.Permissao
                        {
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPERMISSAO"], typeof(string)) as string,
                            Codigo = frmUtil.Util.AtribuirValorObj(dr["CODPERMISSAO"], typeof(string)) as string,
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPERMISSAO"], typeof(string)) as string,
                            Obrigatoria = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLOBRIGATORIA"], typeof(Boolean))),
                            Acoes = new List<Comum.Clases.Acao>()
                        });

                        objPermissao = (from Comum.Clases.Permissao objP in objGrupoPermissao.Permissoes where objP.Identificador == IdentificadorPermissao select objP).FirstOrDefault();

                    }

                    objPermissao.Acoes.Add(new Comum.Clases.Acao
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDACAO"], typeof(string)) as string,
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESACAO"], typeof(string)) as string,
                        TipoAcao = (Comum.Enumeradores.Enumeradores.TipoAcao)(frmUtil.Util.AtribuirValorObj(dr["CODACAO"], typeof(int)))
                    });


                }
            }


            return objGrupoPermissao;
        }

        public static List<Comum.Clases.GrupoPermissao> RecuperarGruposCompleto(string IdentificadorEmpresa)
        {

            List<Comum.Clases.GrupoPermissao> objGruposPermissao = null;

            Comum.Clases.GrupoPermissao objGrupoPermissao = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoPermissaoRecuperarComIdEmpresa, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objGruposPermissao = new List<Comum.Clases.GrupoPermissao>();

                Comum.Clases.Permissao objPermissao = null;
                string IdentificadorPermissao = string.Empty;
                string IdentificadorAcao = string.Empty;
                string IdentificadorGrupoPermissao = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorPermissao = frmUtil.Util.AtribuirValorObj(dr["IDPERMISSAO"], typeof(string)) as string;
                    IdentificadorAcao = frmUtil.Util.AtribuirValorObj(dr["IDACAO"], typeof(string)) as string;
                    IdentificadorGrupoPermissao = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOPERMISSAO"], typeof(string)) as string;

                    objGrupoPermissao = (from Comum.Clases.GrupoPermissao objGrupo in objGruposPermissao where objGrupo.Identificador == IdentificadorGrupoPermissao select objGrupo).FirstOrDefault();

                    if (objGrupoPermissao == null)
                    {
                        objGruposPermissao.Add(new Comum.Clases.GrupoPermissao()
                        {
                            Identificador = IdentificadorGrupoPermissao,
                            Nome = frmUtil.Util.AtribuirValorObj(dr["DESGRUPO"], typeof(string)) as string,
                            Permissoes = new List<Comum.Clases.Permissao>()
                        });

                        objGrupoPermissao = (from Comum.Clases.GrupoPermissao objGrupo in objGruposPermissao where objGrupo.Identificador == IdentificadorGrupoPermissao select objGrupo).FirstOrDefault();
                    }

                    objPermissao = (from Comum.Clases.Permissao objP in objGrupoPermissao.Permissoes where objP.Identificador == IdentificadorPermissao select objP).FirstOrDefault();

                    if (objPermissao == null)
                    {

                        objGrupoPermissao.Permissoes.Add(new Comum.Clases.Permissao
                        {
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPERMISSAO"], typeof(string)) as string,
                            Codigo = frmUtil.Util.AtribuirValorObj(dr["CODPERMISSAO"], typeof(string)) as string,
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPERMISSAO"], typeof(string)) as string,
                            Obrigatoria = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLOBRIGATORIA"], typeof(Boolean))),
                            Acoes = new List<Comum.Clases.Acao>()
                        });

                        objPermissao = (from Comum.Clases.Permissao objP in objGrupoPermissao.Permissoes where objP.Identificador == IdentificadorPermissao select objP).FirstOrDefault();

                    }

                    objPermissao.Acoes.Add(new Comum.Clases.Acao
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDACAO"], typeof(string)) as string,
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESACAO"], typeof(string)) as string,
                        TipoAcao = (Comum.Enumeradores.Enumeradores.TipoAcao)(frmUtil.Util.AtribuirValorObj(dr["CODACAO"], typeof(int)))
                    });


                }
            }
            
            return objGruposPermissao;
        }
    }
}
