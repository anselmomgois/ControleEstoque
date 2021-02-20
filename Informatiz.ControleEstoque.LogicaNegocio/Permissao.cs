using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Informatiz.ControleEstoque.Comum;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;


namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Permissao
    {
        public static List<Comum.Clases.Permissao> RecuperarPermissoes(string Usuario)
        {

            List<Comum.Clases.Permissao> Permissoes = null;
            try
            {
                Permissoes = AcessoDados.Classes.Permissao.RecuperarPermissoes(true);
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Permissoes;
        }

        public static List<Comum.Clases.Permissao> RecuperarPermissoesUsuario(string IdentificadorUsuario, string Usuario)
        {

            List<Comum.Clases.Permissao> Permissoes = null;
            try
            {
                Permissoes = AcessoDados.Classes.Permissao.RecuperarPermissaoUsuario(IdentificadorUsuario);
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Permissoes;
        }

        public static void GravarPermissoesUsuario(string IdentificadorUsuario, List<Comum.Clases.Permissao> objPermissoes, string Usuario)
        {
            try
            {
                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(IdentificadorUsuario, "Identificador do Usuario não informado.", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objPermissoes, "Permissões não informadas.", typeof(List<Comum.Clases.Permissao>), true, ref Erros);
                
                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.Permissao.DeletarPermissoesPessoa(IdentificadorUsuario, ref objSql);

                if (objPermissoes != null && objPermissoes.Count > 0)
                {

                    foreach (Comum.Clases.Permissao objPermissao in objPermissoes)
                    {

                        if (objPermissao.Acoes != null && objPermissao.Acoes.Count > 0)
                        {

                            foreach (Comum.Clases.Acao objAcao in objPermissao.Acoes)
                            {
                                AcessoDados.Classes.Permissao.InserirPermissoesPessoa(IdentificadorUsuario, objPermissao.Identificador, objAcao.Identificador,
                                                                                      objPermissao.IdentificadorGrupoPermissao, ref objSql);
                            }
                        }

                    }
                }

                objSql.ExecutarTransacao();

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }
    }
}
