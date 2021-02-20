using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class GrupoPermissao
    {

        public static void GravarGrupoPermissao(Comum.Clases.GrupoPermissao objGrupoPermissao, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objGrupoPermissao.Nome, "Favor informar o nome", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objGrupoPermissao.Permissoes, "Favor informar ao menos uma permissão", typeof(List<Comum.Clases.Permissao>), true, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                string IdentificadorGrupo = AcessoDados.Classes.GrupoPermissao.InserirGrupoPermissao(objGrupoPermissao, ref objSql);

                if (objGrupoPermissao.Permissoes != null && objGrupoPermissao.Permissoes.Count > 0)
                {

                    foreach (Comum.Clases.Permissao objPermissao in objGrupoPermissao.Permissoes)
                    {

                        if (objPermissao.Acoes != null && objPermissao.Acoes.Count > 0)
                        {

                            foreach (Comum.Clases.Acao objAcao in objPermissao.Acoes)
                            {
                                AcessoDados.Classes.GrupoPermissao.InserirPermissao(IdentificadorGrupo, objPermissao.Identificador, objAcao.Identificador, ref objSql);
                            }
                        }
                    }
                }

                objSql.ExecutarTransacao();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static void AtualizarGrupoPermissao(Comum.Clases.GrupoPermissao objGrupoPermissao, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objGrupoPermissao.Nome, "Favor informar o nome", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objGrupoPermissao.Identificador, "Identificador não informado", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objGrupoPermissao.Permissoes, "Favor informar ao menos uma permissão", typeof(List<Comum.Clases.Permissao>), true, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.GrupoPermissao.AtualizarGrupoPermissao(objGrupoPermissao, ref objSql);

                AcessoDados.Classes.GrupoPermissao.DeletarPermissao(objGrupoPermissao.Identificador, ref objSql);

                if (objGrupoPermissao.Permissoes != null && objGrupoPermissao.Permissoes.Count > 0)
                {

                    foreach (Comum.Clases.Permissao objPermissao in objGrupoPermissao.Permissoes)
                    {

                        if (objPermissao.Acoes != null && objPermissao.Acoes.Count > 0)
                        {

                            foreach (Comum.Clases.Acao objAcao in objPermissao.Acoes)
                            {
                                AcessoDados.Classes.GrupoPermissao.InserirPermissao(objGrupoPermissao.Identificador, objPermissao.Identificador, objAcao.Identificador, ref objSql);
                            }
                        }
                    }
                }

                objSql.ExecutarTransacao();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static void DeletarGrupoPermissao(string IdentificadorGrupo, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(IdentificadorGrupo, "Identificador não informado", typeof(string), false, ref Erros);
                
                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.GrupoPermissao.DeletarPermissao(IdentificadorGrupo, ref objSql);

                AcessoDados.Classes.GrupoPermissao.DeletarGrupoPermissao(IdentificadorGrupo, ref objSql);


                objSql.ExecutarTransacao();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static List<Comum.Clases.GrupoPermissao> RecuperarGruposCompleto(string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.GrupoPermissao> GruposPermissoes = null;

            try
            {

                GruposPermissoes = AcessoDados.Classes.GrupoPermissao.RecuperarGruposCompleto(IdentificadorEmpresa);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return GruposPermissoes;
        }

        public static List<Comum.Clases.GrupoPermissao> RecuperarGrupos(string Nome, string IdentificadorEmpresa, string Usuario)
        {
            List<Comum.Clases.GrupoPermissao> GruposPermissoes = null;

            try
            {
                GruposPermissoes = AcessoDados.Classes.GrupoPermissao.RecuperarGrupos(Nome, IdentificadorEmpresa);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return GruposPermissoes;
        }

        public static Comum.Clases.GrupoPermissao RecuperarGrupoPermissao(string Identificador, string Usuario)
        {
            Comum.Clases.GrupoPermissao objGrupoPermissao = null;

            try
            {
                objGrupoPermissao = AcessoDados.Classes.GrupoPermissao.RecuperarGrupo(Identificador);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objGrupoPermissao;
        }
    }
}
