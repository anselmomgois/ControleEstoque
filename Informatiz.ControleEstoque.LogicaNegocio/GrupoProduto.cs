using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class GrupoProduto
    {

        public static List<Comum.Clases.GrupoProduto> RecuperarGrupo(string Descricao, string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.GrupoProduto> Grupos = null;

            try
            {

                Grupos = AcessoDados.Classes.GrupoProduto.PesquisarGrupoProduto(Descricao, IdentificadorEmpresa);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Grupos;
        }

        public static void InserirGrupoProduto(Comum.Clases.GrupoProduto objGrupo, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objGrupo.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                objGrupo.Identificador = AcessoDados.Classes.GrupoProduto.InserirGrupoProduto(objGrupo, IdentificadorEmpresa, ref objSql);

                InserirSubGrupos(objGrupo, IdentificadorEmpresa, ref objSql);

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

        public static void AtualizarGrupoProduto(Comum.Clases.GrupoProduto objGrupo, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objGrupo.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.GrupoProduto.AtualizarGrupoProduto(objGrupo, ref objSql);

                if (objGrupo.Deletar && objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
                {

                    foreach (Comum.Clases.GrupoProduto gp in objGrupo.SubGrupos)
                    {
                        gp.Deletar = true;
                    }

                }

                AtualizarSubGrupos(objGrupo, IdentificadorEmpresa, ref objSql);

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

        public static void DeletarGrupoProduto(string IdentificadorGrupoProduto, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.GrupoProduto.GrupoProdutoEstaSendoUsuado(IdentificadorGrupoProduto))
                {


                    AcessoDados.Classes.GrupoProduto.DeletarGrupoProduto(IdentificadorGrupoProduto);
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos que estão utilizando este grupo.");
                }
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

        public static Comum.Clases.GrupoProduto RecuperarGrupoProduto(string IdentificadorGrupoProduto, string Usuario)
        {
            Comum.Clases.GrupoProduto objGrupoProduto = null;

            try
            {

                objGrupoProduto = AcessoDados.Classes.GrupoProduto.RecuperarGrupoProduto(IdentificadorGrupoProduto);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objGrupoProduto;
        }

        private static void AtualizarSubGrupos(Comum.Clases.GrupoProduto objGrupo, string IdentificadorEmpresa, ref Sql objSql)
        {

            AcessoDados.Classes.GrupoProduto.DeletarGrupoProdutoSubGrupo(objGrupo.Identificador, ref objSql);

            if (objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
            {

                foreach (Comum.Clases.GrupoProduto sg in objGrupo.SubGrupos)
                {

                    if (sg.Deletar && sg.SubGrupos != null && sg.SubGrupos.Count > 0)
                    {

                        foreach (Comum.Clases.GrupoProduto gp in sg.SubGrupos)
                        {
                            gp.Deletar = true;
                        }

                    }

                    AtualizarSubGrupos(sg, IdentificadorEmpresa, ref objSql);

                    if (sg.Deletar)
                    {
                        AcessoDados.Classes.GrupoProduto.DeletarGrupoProdutoComTransacao(sg.Identificador, ref objSql);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sg.Identificador))
                        {
                            sg.Identificador = AcessoDados.Classes.GrupoProduto.InserirGrupoProduto(sg, IdentificadorEmpresa, ref objSql);
                        }
                        else
                        {
                            AcessoDados.Classes.GrupoProduto.AtualizarGrupoProduto(sg, ref objSql);
                        }

                        AcessoDados.Classes.GrupoProduto.InserirGrupoProdutoSubGrupo(objGrupo.Identificador, sg.Identificador, ref objSql);
                       
                    }
                                                     
                }
            }

          }

        private static void InserirSubGrupos(Comum.Clases.GrupoProduto objGrupo, string IdentificadorEmpresa, ref Sql objSql)
        {
            if (objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
            {

                foreach (Comum.Clases.GrupoProduto sg in objGrupo.SubGrupos)
                {

                    sg.Identificador = AcessoDados.Classes.GrupoProduto.InserirGrupoProduto(sg, IdentificadorEmpresa, ref objSql);
                    AcessoDados.Classes.GrupoProduto.InserirGrupoProdutoSubGrupo(objGrupo.Identificador, sg.Identificador, ref objSql);

                    InserirSubGrupos(sg,IdentificadorEmpresa, ref objSql);
                }
            }
        }

        public static Boolean GrupoEstaSendoUsado(string IdentificadorGrupo, string Usuario)
        { 
        
            try
            {

                return AcessoDados.Classes.GrupoProduto.GrupoProdutoEstaSendoUsuado(IdentificadorGrupo);
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
    }
}
