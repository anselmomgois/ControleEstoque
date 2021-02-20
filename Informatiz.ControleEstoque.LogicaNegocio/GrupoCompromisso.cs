using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class GrupoCompromisso
    {

        public static ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.RespostaRecuperarGruposCompromisso RecuperarGruposCompromisso(ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.PeticaoRecuperarGruposCompromisso Peticao)
        {

            ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.RespostaRecuperarGruposCompromisso Resposta = new ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso.RespostaRecuperarGruposCompromisso();

            try
            {

                Resposta.GruposCompromisso = AcessoDados.Classes.GrupoCompromisso.PesquisarGrupoCompromisso(Peticao.Descricao, Peticao.IdentificadorEmpresa,
                                                                                                            Peticao.IdentificadorGrupoCompromisso, Peticao.Ordenar,
                                                                                                            Peticao.RecuperarSubGrupos, Peticao.RecuperarPerguntas);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                throw ex;
            }

            return Resposta;
        }

        public static void InserirGrupoCompromisso(Comum.Clases.GrupoCompromisso objGrupo, string IdentificadorEmpresa, string Usuario)
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

                objGrupo.Identificador = AcessoDados.Classes.GrupoCompromisso.InserirGrupoCompromisso(objGrupo, IdentificadorEmpresa, ref objSql);

                InserirSubGrupos(objGrupo, IdentificadorEmpresa, ref objSql);


                if (objGrupo.Perguntas != null && objGrupo.Perguntas.Count > 0)
                {

                    string IdentificadorPergunta = string.Empty;

                    foreach (Comum.Clases.Pergunta objPergunta in objGrupo.Perguntas)
                    {
                        IdentificadorPergunta = AcessoDados.Classes.Pergunta.InserirPergunta(objPergunta, objGrupo.Identificador, ref objSql);

                        if (objPergunta.Opcoes != null && objPergunta.Opcoes.Count > 0)
                        {

                            foreach (Comum.Clases.PerguntaOpcao objPOpcao in objPergunta.Opcoes)
                            {
                                AcessoDados.Classes.Pergunta.InserirPerguntaOpcao(objPOpcao, IdentificadorPergunta, ref objSql);
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

        public static void AtualizarGrupoCompromisso(Comum.Clases.GrupoCompromisso objGrupo, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objGrupo.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (objGrupo.Perguntas != null && objGrupo.Perguntas.Count > 0 &&
                    objGrupo.Perguntas.FindAll(p => p.Deletar && AcessoDados.Classes.Pergunta.PerguntaEstaSendoUsada(p.Identificador)).Count > 0)
                {
                    Erros.AppendLine("Existem perguntas que não podem ser deletadas, pois já estão sendo utilizadas.");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.GrupoCompromisso.AtualizarGrupoCompromisso(objGrupo, ref objSql);

                if (objGrupo.Deletar && objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
                {

                    foreach (Comum.Clases.GrupoCompromisso gp in objGrupo.SubGrupos)
                    {
                        gp.Deletar = true;
                    }

                }

                AtualizarSubGrupos(objGrupo, IdentificadorEmpresa, ref objSql);


                if (objGrupo.Perguntas != null && objGrupo.Perguntas.Count > 0)
                {

                    string IdentificadorPergunta = string.Empty;

                    foreach (Comum.Clases.Pergunta objPergunta in objGrupo.Perguntas)
                    {
                        IdentificadorPergunta = objPergunta.Identificador;

                        if (!string.IsNullOrEmpty(objPergunta.Identificador))
                        {
                            AcessoDados.Classes.Pergunta.DeletarPerguntaOpcao(objPergunta.Identificador, ref objSql);
                        }

                        if (objPergunta.Deletar)
                        {
                            AcessoDados.Classes.Pergunta.PerguntaDeletar(objPergunta.Identificador, ref objSql);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(objPergunta.Identificador))
                            {
                                AcessoDados.Classes.Pergunta.AtualizarPergunta(objPergunta, ref objSql);
                            }
                            else
                            {
                                IdentificadorPergunta = AcessoDados.Classes.Pergunta.InserirPergunta(objPergunta, objGrupo.Identificador, ref objSql);
                            }

                            if (objPergunta.Opcoes != null && objPergunta.Opcoes.Count > 0)
                            {

                                foreach (Comum.Clases.PerguntaOpcao objPOpcao in objPergunta.Opcoes)
                                {
                                    AcessoDados.Classes.Pergunta.InserirPerguntaOpcao(objPOpcao, IdentificadorPergunta, ref objSql);
                                }
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

        public static void DeletarGrupoCompromisso(string IdentificadorGrupoCompromisso, string Usuario)
        {

            try
            {

                Sql objSql = new Sql();
                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                Comum.Clases.GrupoCompromisso objGrupo = AcessoDados.Classes.GrupoCompromisso.RecuperarGrupoCompromisso(IdentificadorGrupoCompromisso);

                if (objGrupo != null && objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
                {
                    foreach (Comum.Clases.GrupoCompromisso sg in objGrupo.SubGrupos)
                    {
                        DeletarSubGrupos(sg, ref objSql);
                    }
                }

                if (objGrupo.Perguntas != null && objGrupo.Perguntas.Count > 0)
                {
                    foreach (Comum.Clases.Pergunta p in objGrupo.Perguntas)
                    {
                        AcessoDados.Classes.Pergunta.DeletarPerguntaOpcao(p.Identificador, ref objSql);

                        AcessoDados.Classes.Pergunta.PerguntaDeletar(p.Identificador, ref objSql);
                    }
                }

                AcessoDados.Classes.GrupoCompromisso.DeletarGrupoCompromissoSubGrupo(objGrupo.Identificador, ref objSql);
                AcessoDados.Classes.GrupoCompromisso.DeletarGrupoCompromisso(IdentificadorGrupoCompromisso, ref objSql);

                objSql.ExecutarTransacao();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        private static void DeletarSubGrupos(Comum.Clases.GrupoCompromisso objGrupo, ref Sql objSql)
        {

            if (objGrupo != null)
            {
                if (objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
                {
                    foreach (Comum.Clases.GrupoCompromisso sg in objGrupo.SubGrupos)
                    {
                        DeletarSubGrupos(sg, ref objSql);
                    }
                }

                if (objGrupo.Perguntas != null && objGrupo.Perguntas.Count > 0)
                {
                    foreach (Comum.Clases.Pergunta p in objGrupo.Perguntas)
                    {
                        AcessoDados.Classes.Pergunta.DeletarPerguntaOpcao(p.Identificador, ref objSql);
                        AcessoDados.Classes.Pergunta.PerguntaDeletar(p.Identificador, ref objSql);
                    }
                }

                AcessoDados.Classes.GrupoCompromisso.DeletarGrupoCompromissoSubGrupoComIdentificadorGrupo(objGrupo.Identificador, ref objSql);
                AcessoDados.Classes.GrupoCompromisso.DeletarGrupoCompromissoSubGrupo(objGrupo.Identificador, ref objSql);
                AcessoDados.Classes.GrupoCompromisso.DeletarGrupoCompromisso(objGrupo.Identificador, ref objSql);
            }
        }

        public static Comum.Clases.GrupoCompromisso RecuperarGrupoCompromisso(string IdentificadorGrupoCompromisso, string Usuario)
        {
            Comum.Clases.GrupoCompromisso objGrupoCompromisso = null;

            try
            {

                objGrupoCompromisso = AcessoDados.Classes.GrupoCompromisso.RecuperarGrupoCompromisso(IdentificadorGrupoCompromisso);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objGrupoCompromisso;
        }

        private static void AtualizarSubGrupos(Comum.Clases.GrupoCompromisso objGrupo, string IdentificadorEmpresa, ref Sql objSql)
        {

            if (objGrupo.Deletar || !string.IsNullOrEmpty(objGrupo.Identificador))
            {
                AcessoDados.Classes.GrupoCompromisso.DeletarGrupoCompromissoSubGrupo(objGrupo.Identificador, ref objSql);
            }

            if (objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
            {

                foreach (Comum.Clases.GrupoCompromisso sg in objGrupo.SubGrupos)
                {

                    if (sg.Deletar && sg.SubGrupos != null && sg.SubGrupos.Count > 0)
                    {

                        foreach (Comum.Clases.GrupoCompromisso gp in sg.SubGrupos)
                        {
                            gp.Deletar = true;
                        }

                    }


                    if (sg.Deletar)
                    {
                        AtualizarSubGrupos(sg, IdentificadorEmpresa, ref objSql);

                        if (sg.Perguntas != null && sg.Perguntas.Count > 0)
                        {
                            foreach (Comum.Clases.Pergunta objPergunta in sg.Perguntas)
                            {
                                AcessoDados.Classes.Pergunta.DeletarPerguntaOpcao(objPergunta.Identificador, ref objSql);
                                AcessoDados.Classes.Pergunta.PerguntaDeletar(objPergunta.Identificador, ref objSql);
                            }
                        }
                        AcessoDados.Classes.GrupoCompromisso.DeletarGrupoCompromissoComTransacao(sg.Identificador, ref objSql);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sg.Identificador))
                        {
                            sg.Identificador = AcessoDados.Classes.GrupoCompromisso.InserirGrupoCompromisso(sg, IdentificadorEmpresa, ref objSql);

                        }
                        else
                        {
                            AcessoDados.Classes.GrupoCompromisso.AtualizarGrupoCompromisso(sg, ref objSql);
                        }

                        AcessoDados.Classes.GrupoCompromisso.InserirGrupoCompromissoSubGrupo(objGrupo.Identificador, sg.Identificador, ref objSql);

                        AtualizarSubGrupos(sg, IdentificadorEmpresa, ref objSql);

                        if (sg.Perguntas != null && sg.Perguntas.Count > 0)
                        {

                            string IdentificadorPergunta = string.Empty;

                            foreach (Comum.Clases.Pergunta objPergunta in sg.Perguntas)
                            {
                                IdentificadorPergunta = objPergunta.Identificador;

                                if (!string.IsNullOrEmpty(objPergunta.Identificador))
                                {
                                    AcessoDados.Classes.Pergunta.DeletarPerguntaOpcao(objPergunta.Identificador, ref objSql);
                                }

                                if (objPergunta.Deletar)
                                {
                                    AcessoDados.Classes.Pergunta.PerguntaDeletar(objPergunta.Identificador, ref objSql);
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(objPergunta.Identificador))
                                    {
                                        AcessoDados.Classes.Pergunta.AtualizarPergunta(objPergunta, ref objSql);
                                    }
                                    else
                                    {
                                        IdentificadorPergunta = AcessoDados.Classes.Pergunta.InserirPergunta(objPergunta, sg.Identificador, ref objSql);
                                    }

                                    if (objPergunta.Opcoes != null && objPergunta.Opcoes.Count > 0)
                                    {

                                        foreach (Comum.Clases.PerguntaOpcao objPOpcao in objPergunta.Opcoes)
                                        {
                                            AcessoDados.Classes.Pergunta.InserirPerguntaOpcao(objPOpcao, IdentificadorPergunta, ref objSql);
                                        }
                                    }
                                }
                            }

                        }
                    }

                }
            }

        }

        private static void InserirSubGrupos(Comum.Clases.GrupoCompromisso objGrupo, string IdentificadorEmpresa, ref Sql objSql)
        {
            if (objGrupo.SubGrupos != null && objGrupo.SubGrupos.Count > 0)
            {

                foreach (Comum.Clases.GrupoCompromisso sg in objGrupo.SubGrupos)
                {

                    sg.Identificador = AcessoDados.Classes.GrupoCompromisso.InserirGrupoCompromisso(sg, IdentificadorEmpresa, ref objSql);
                    AcessoDados.Classes.GrupoCompromisso.InserirGrupoCompromissoSubGrupo(objGrupo.Identificador, sg.Identificador, ref objSql);

                    InserirSubGrupos(sg, IdentificadorEmpresa, ref objSql);
                }
            }
        }

        public static Boolean GrupoEstaSendoUsado(string IdentificadorGrupo, string Usuario)
        {

            try
            {

                return AcessoDados.Classes.GrupoCompromisso.GrupoCompromissoEstaSendoUsuado(IdentificadorGrupo);
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
