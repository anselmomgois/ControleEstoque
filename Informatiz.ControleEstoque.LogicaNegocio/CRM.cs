using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class CRM
    {

        public static ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos RecuperarAgendamentos(ContratoServico.CRM.RecuperarAgendamentos.PeticaoRecuperarAgendamentos Peticao)
        {

            ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos Resposta = new ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos();

            try
            {

                Resposta.Agendamentos = AcessoDados.Classes.CRM.RecuperarAgendamentos(Peticao.Descricao, Peticao.IdentificadorFuncionarioCadastro,
                                                                             Peticao.IdentificadoresFuncionariosResponsaveis,
                                                                             Peticao.IdentificadorCliente, Peticao.IdentificadorEmpresa,
                                                                             Peticao.DataInicio, Peticao.DataFim, Peticao.Ativo, Peticao.ValidacoesExpecificas);

                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                Resposta.DescricaoErro = ex.Message;
            }
            catch (Exception ex)
            {
                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                Resposta.DescricaoErro = ex.Message;
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
            }

            return Resposta;
        }

        public static ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples RecuperarAgendamentosSimples(ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples Peticao)
        {

            ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples Resposta = new ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples();

            try
            {

                Resposta.Agendamentos = AcessoDados.Classes.CRM.RecuperarAgendamentosSimples(Peticao.Descricao, Peticao.IdentificadorFuncionarioCadastro,
                                                                             Peticao.IdentificadoresFuncionariosResponsaveis,
                                                                             Peticao.IdentificadorCliente, Peticao.IdentificadorEmpresa,
                                                                             Peticao.DataInicio, Peticao.DataFim, Peticao.Ativo, Peticao.ValidacoesExpecificas, Peticao.BuscarSomenteNaoConcluidos);

                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
                Resposta.DescricaoErro = ex.Message;
            }
            catch (Exception ex)
            {
                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                Resposta.DescricaoErro = ex.Message;
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
            }

            return Resposta;
        }
        public static void InserirAgendamento(ContratoServico.CRM.InserirAgendamento.PeticaoInserirAgendamento Peticao)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(Peticao.CRM.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Peticao.CRM.Propostas != null && Peticao.CRM.Propostas.Count > 0 &&
                   (from Comum.Clases.Proposta objProp in Peticao.CRM.Propostas where string.IsNullOrEmpty(objProp.Descricao) select objProp).Count() > 0)
                {
                    Erros.AppendLine("Existem propostas sem descrição");
                }

                if (Peticao.CRM.Atendimentos != null && Peticao.CRM.Atendimentos.Count > 0)
                {
                    if (Peticao.CRM.Atendimentos.Exists(a => a.FuncionariosResponsaveis == null || a.FuncionariosResponsaveis.Count == 0))
                        Erros.AppendLine("Existem atendimentos sem funcionários alocados.");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                string IdentificadorAgendamento = AcessoDados.Classes.CRM.InserirAgendamento(Peticao.CRM, Peticao.IdentificadorEmpresa, ref objSql);

                if (Peticao.CRM.Atendimentos != null && Peticao.CRM.Atendimentos.Count > 0)
                {
                    string IdentificadorPessoaAgendamento = string.Empty;

                    foreach (Comum.Clases.Agendamento objCrm in Peticao.CRM.Atendimentos)
                    {
                        IdentificadorPessoaAgendamento = AcessoDados.Classes.CRM.InserirPessoaAgendamento(objCrm, IdentificadorAgendamento, ref objSql);

                        if (objCrm.FuncionariosResponsaveis != null && objCrm.FuncionariosResponsaveis.Count > 0)
                        {

                            foreach (Comum.Clases.Pessoa funcionario in objCrm.FuncionariosResponsaveis)
                            {
                                AcessoDados.Classes.CRM.InserirPessoasAgendamento(funcionario.Identificador, IdentificadorPessoaAgendamento, ref objSql);
                            }
                        }

                        if (objCrm.Perguntas != null && objCrm.Perguntas.Count > 0)
                        {

                            foreach (Comum.Clases.Pergunta objPergunta in objCrm.Perguntas)
                            {
                                AcessoDados.Classes.Pergunta.InserirResposta(objPergunta, IdentificadorPessoaAgendamento, ref objSql);
                            }
                        }
                    }
                }

                if (Peticao.CRM.Propostas != null && Peticao.CRM.Propostas.Count > 0)
                {

                    foreach (Comum.Clases.Proposta objProp in Peticao.CRM.Propostas)
                    {
                        objProp.IdentificadorCRM = IdentificadorAgendamento;
                        objProp.PessoaResponsavel = Peticao.CRM.FuncionarioCadastro;
                        AcessoDados.Classes.Proposta.InserirPropostaComTransacao(objProp, Peticao.IdentificadorEmpresa, ref objSql);
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
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                throw ex;
            }
        }

        public static void AtualizarAgendamento(ContratoServico.CRM.AtualizarAgendamento.PeticaoAtualizarAgendamento Peticao)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(Peticao.CRM.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);


                if (Peticao.CRM.Propostas != null && Peticao.CRM.Propostas.Count > 0 &&
                    (from Comum.Clases.Proposta objProp in Peticao.CRM.Propostas where string.IsNullOrEmpty(objProp.Descricao) select objProp).Count() > 0)
                {
                    Erros.AppendLine("Existem propostas sem descrição");
                }

                if (Peticao.CRM.Atendimentos != null && Peticao.CRM.Atendimentos.Count > 0)
                {
                    if(Peticao.CRM.Atendimentos.Exists(a => a.FuncionariosResponsaveis == null || a.FuncionariosResponsaveis.Count == 0))
                    Erros.AppendLine("Existem atendimentos sem funcionários alocados.");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.CRM.AtualizarAgendamento(Peticao.CRM, ref objSql);

                AcessoDados.Classes.Pergunta.DeletarResposta(Peticao.CRM.Identificador, ref objSql);
                AcessoDados.Classes.CRM.DeletarPessoasAgendamento(Peticao.CRM.Identificador, ref objSql);
                AcessoDados.Classes.CRM.DeletarPessoaAgendamento(Peticao.CRM.Identificador, ref objSql);

                if (Peticao.CRM.Atendimentos != null && Peticao.CRM.Atendimentos.Count > 0)
                {
                    string IdentificadorPessoaAgendamento = string.Empty;

                    foreach (Comum.Clases.Agendamento objCrm in Peticao.CRM.Atendimentos)
                    {

                        IdentificadorPessoaAgendamento = AcessoDados.Classes.CRM.InserirPessoaAgendamento(objCrm, Peticao.CRM.Identificador, ref objSql);

                        if (objCrm.FuncionariosResponsaveis != null && objCrm.FuncionariosResponsaveis.Count > 0)
                        {

                            foreach (Comum.Clases.Pessoa funcionario in objCrm.FuncionariosResponsaveis)
                            {
                                AcessoDados.Classes.CRM.InserirPessoasAgendamento(funcionario.Identificador, IdentificadorPessoaAgendamento, ref objSql);
                            }
                        }

                        if (objCrm.Perguntas != null && objCrm.Perguntas.Count > 0)
                        {

                            foreach (Comum.Clases.Pergunta objPergunta in objCrm.Perguntas)
                            {
                                AcessoDados.Classes.Pergunta.InserirResposta(objPergunta, IdentificadorPessoaAgendamento, ref objSql);
                            }
                        }
                    }
                }

                AcessoDados.Classes.Proposta.DeletarPropostasCRM(Peticao.CRM.Identificador, ref objSql);

                if (Peticao.CRM.Propostas != null && Peticao.CRM.Propostas.Count > 0)
                {

                    foreach (Comum.Clases.Proposta objProp in Peticao.CRM.Propostas)
                    {
                        objProp.IdentificadorCRM = Peticao.CRM.Identificador;
                        objProp.PessoaResponsavel = Peticao.CRM.FuncionarioCadastro;
                        AcessoDados.Classes.Proposta.InserirPropostaComTransacao(objProp, Peticao.IdentificadorEmpresa, ref objSql);
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
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.IdentificadorEmpresa });
                throw ex;
            }
        }

        public static void DesativarAgendamento(string IdentificadorCRM, string Usuario)
        {

            try
            {

                AcessoDados.Classes.CRM.DesativarAgendamento(IdentificadorCRM);

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

        public static ContratoServico.CRM.RecuperarAgendamento.RespostaRecuperarAgendamento RecuperarAgendamento(ContratoServico.CRM.RecuperarAgendamento.PeticaoRecuperarAgendamento Peticao)
        {

            ContratoServico.CRM.RecuperarAgendamento.RespostaRecuperarAgendamento Resposta = new ContratoServico.CRM.RecuperarAgendamento.RespostaRecuperarAgendamento();

            try
            {

                Resposta.CRM = AcessoDados.Classes.CRM.RecuperarAgendamento(Peticao.IdentificadorCRM);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                throw ex;
            }

            return Resposta;
        }

    }
}
