using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Informatiz.ControleEstoque.Comum;
using System.Configuration;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Usuario
    {

        public static ContratoServico.Usuario.Logar.RespostaLogar Logar(ContratoServico.Usuario.Logar.PeticaoLogar Peticao)
        {

            ContratoServico.Usuario.Logar.RespostaLogar Resposta = new ContratoServico.Usuario.Logar.RespostaLogar();

            try
            {

                Resposta.Usuario = AcessoDados.Classes.Usuario.Logar(Peticao.Usuario, Peticao.Senha);

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

        public static ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao DeletarSessao(ContratoServico.Usuario.DeletarSessao.PeticaoDeletarSessao Peticao)
        {

            ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao Resposta = new ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao();

            try
            {
                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.Sessao.DeletarSessao(Peticao.IdentificadorSessao, ref objSql);

                objSql.ExecutarTransacao();

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

        public static ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao AtivarSessao(ContratoServico.Usuario.AtivarSessao.PeticaoAtivarSessao Peticao)
        {

            ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao Resposta = new ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao();

            try
            {

                List<Comum.Clases.Sessoes> objSessoes = AcessoDados.Classes.Sessao.RecuperarSessoes(Peticao.IdentificadorEmpresa);

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                if (objSessoes != null && objSessoes.Count > 0)
                {

                    Int32 TempoSessao = 0;
                    int resultado;

                    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["TempoSessao"]) &&
                        int.TryParse(ConfigurationManager.AppSettings["TempoSessao"], out resultado))
                    {
                        TempoSessao = Convert.ToInt32(ConfigurationManager.AppSettings["TempoSessao"]);

                    }

                    foreach (Comum.Clases.Sessoes objs in objSessoes.FindAll(s=> s.IdentificadorPessoa != Peticao.IdentificadorPessoa))
                    {
                        TimeSpan Dif = DateTime.Now - objs.DataUltimoUso;

                        if (Dif.TotalMinutes > TempoSessao)
                        {
                            AcessoDados.Classes.Sessao.DeletarSessao(objs.Identificador, ref objSql);
                            objSessoes.Remove(objs);
                        }
                    }

                    Comum.Clases.Sessoes objSessao = (from Comum.Clases.Sessoes s in objSessoes where s.IdentificadorPessoa == Peticao.IdentificadorPessoa select s).FirstOrDefault();

                    if (objSessao != null)
                    {
                        AcessoDados.Classes.Sessao.DeletarSessao(objSessao.Identificador, ref objSql);
                        objSessoes.Remove(objSessao);
                    }

                    if (!Peticao.SessoesIlimitadas && Peticao.QuantidadeSessoes < objSessoes.Count && TempoSessao > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Quantidade máxima de sessões atingidas");
                    }

                    Resposta.IdentificadorSessao = AcessoDados.Classes.Sessao.InserirSessao(Peticao.IdentificadorFilial, Peticao.IdentificadorPessoa, ref objSql);

                }
                else
                {
                    Resposta.IdentificadorSessao = AcessoDados.Classes.Sessao.InserirSessao(Peticao.IdentificadorFilial, Peticao.IdentificadorPessoa, ref objSql);
                }

                objSql.ExecutarTransacao();

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

        public static Boolean AtualizarSessao(string IdentificadorSessao, string Usuario)
        {
            Boolean SessaoExpirada = false;
            try
            {

                if (!string.IsNullOrEmpty(IdentificadorSessao))
                {
                    if (AcessoDados.Classes.Sessao.SessaoExiste(IdentificadorSessao))
                    {
                        AcessoDados.Classes.Sessao.AtualizarSessao(IdentificadorSessao);
                    }
                    else
                    {
                        SessaoExpirada = true;                       
                    }
                }

               // Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);

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

            return SessaoExpirada;
        }
    }
}
