using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using frmCripto =  AmgSistemas.Framework.Criptografia;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio.Servico
{
    public class Chave
    {

        public ContratoServico.ValidarChave.Respuesta ValidarChaveSistema(ContratoServico.ValidarChave.Peticao Peticao)
        {

            ContratoServico.ValidarChave.Respuesta objResposta = new ContratoServico.ValidarChave.Respuesta();

            try
            {

                frmUtil.Util.ValidarCampo(Peticao.Chave, "Chave não informada.", typeof(string), false);
                
                Boolean ok = AcessoDados.Classes.Servico.ValidarChave.ValidarChaveSistema(Peticao.CodigoEmpresa, Peticao.Chave);

                if (ok)
                {
                    string IdentificadorChave = AcessoDados.Classes.Servico.ValidarChave.RecuperarIdentificadorChave(Peticao.Chave,false,false);
                    Comum.Clases.Chave objChave = AcessoDados.Classes.Servico.ValidarChave.RecuperarChave(IdentificadorChave);

                    if (objChave != null)
                    {

                        if (objChave.ValidadeInfinita)
                        {
                            objResposta.ChaveOk = true;
                        }
                        else
                        {

                            if (objChave.DataAtivacao != null && objChave.Validade != null)
                            {
                                DateTime DataLimite = Convert.ToDateTime(objChave.DataAtivacao).AddDays(Convert.ToInt32(objChave.Validade));

                                if (DateTime.Now > DataLimite)
                                {
                                    objResposta.ChaveOk = false;
                                }
                                else
                                {
                                    objResposta.ChaveOk = true;
                                }
                            }
                            
                        }
                    }
                    else
                    {
                        objResposta.ChaveOk = false;
                    }
                }
                else
                {
                    objResposta.ChaveOk = ok;
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                objResposta.CodigoErro = Convert.ToInt32(ex.Codigo);
                objResposta.DescricaoErro = ex.Descricao;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                objResposta.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objResposta.DescricaoErro = ex.ToString();

            }

            return objResposta;
        }

        public static ContratoServico.GerarChave.Respuesta GerarChave(ContratoServico.GerarChave.Peticao Peticao)
        {

            ContratoServico.GerarChave.Respuesta objResposta = new ContratoServico.GerarChave.Respuesta();

            try
            {

                if (!Peticao.SessoesInfinita && Peticao.QuantidadeSessoes == 0)
                {

                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar a quantidade de sessões.");
                }

                if (!Peticao.ValidadeInfinita && Peticao.NumValidade == 0)
                {

                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar a quantidade de dias que a chave é valida.");
                }

                string Chave = frmCripto.SNGenerator.RandomSNKGenerator.GetSerialKeyAlphaNumaric(frmCripto.SNGenerator.SNKeyLength.SN20, 20);
                string ChaveCriptografada = frmCripto.Criptografar.EncryptString128Bit(Chave, Comum.Clases.Constantes.CHAVE_CRIPITOGRAFIA);

                if (AcessoDados.Classes.Servico.ValidarChave.ValidarChaveExiste(Chave))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Chave gerada já existe.");
                }

                AcessoDados.Classes.Servico.ValidarChave.GerarChave(ChaveCriptografada, Peticao.SessoesInfinita, Peticao.QuantidadeSessoes,
                                                                    Peticao.NumValidade, Peticao.ValidadeInfinita,Peticao.NumQuantidadeAcessos);

                objResposta.ChaveGerada = Chave;

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objResposta.CodigoErro = Convert.ToInt32(ex.Codigo);
                objResposta.DescricaoErro = ex.Descricao;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                objResposta.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objResposta.DescricaoErro = ex.ToString();

            }

            return objResposta;
        }

        public ContratoServico.AtivarChave.Respuesta AtivarChave(ContratoServico.AtivarChave.Peticao Peticao)
        {
            ContratoServico.AtivarChave.Respuesta objResposta = new ContratoServico.AtivarChave.Respuesta();

            try
            {

                if (string.IsNullOrEmpty(Peticao.Chave))
                {

                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar a chave.");
                }

                if (Peticao.CodigoEmpresa == 0)
                {

                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar o código da empresa.");
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacao(Comum.Clases.Constantes.STRING_CONEXAO);

                string IdentificadorChave = AcessoDados.Classes.Servico.ValidarChave.RecuperarIdentificadorChave(Peticao.Chave,true,true);

                if (!string.IsNullOrEmpty(IdentificadorChave))
                {
                    Comum.Clases.Chave objChave = AcessoDados.Classes.Servico.ValidarChave.RecuperarChave(IdentificadorChave);
                    AcessoDados.Classes.Servico.ValidarChave.EmpresaAtualizarChave(IdentificadorChave, Peticao.CodigoEmpresa, ref objSql);
                    AcessoDados.Classes.Servico.ValidarChave.ChaveAtualizar(IdentificadorChave, ref objSql);

                    objSql.ExecutarTransacao();

                    objResposta.ChaveAcesso = objChave;
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Chave Invalida");
                }

                                              
            }
            catch (Execao.ExecaoNegocio ex)
            {
                objResposta.CodigoErro = Convert.ToInt32(ex.Codigo);
                objResposta.DescricaoErro = ex.Descricao;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                objResposta.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objResposta.DescricaoErro = ex.ToString();

            }

            return objResposta;
        }

        public static ContratoServico.ChaveAcesso.RecuperarChaves.RespuestaRecuperarChaves RecuperarChaves(ContratoServico.ChaveAcesso.RecuperarChaves.PeticaoRecuperarChaves Peticao)
        {
            ContratoServico.ChaveAcesso.RecuperarChaves.RespuestaRecuperarChaves objResposta = new ContratoServico.ChaveAcesso.RecuperarChaves.RespuestaRecuperarChaves();

            try
            {

                objResposta.Chaves = AcessoDados.Classes.Servico.ValidarChave.RecuperarChaves();
                
            }
            catch (Execao.ExecaoNegocio ex)
            {
                objResposta.CodigoErro = Convert.ToInt32(ex.Codigo);
                objResposta.DescricaoErro = ex.Descricao;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                objResposta.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objResposta.DescricaoErro = ex.ToString();

            }

            return objResposta;
        }
    }
}
