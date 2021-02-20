using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ChaveAcesso
    {


        public static void AtivarChave(string Chave, Int32 CodigoEmpresa, string Usuario, string IdentificadorEmpresa)
        {
            try
            {

                ContratoServico.AtivarChave.Peticao objPeticao = new ContratoServico.AtivarChave.Peticao();
                Comunicacao.Proxy objProxy = new Comunicacao.Proxy();

                objPeticao.Chave = Chave;
                objPeticao.CodigoEmpresa = CodigoEmpresa;
                objPeticao.Usuario = Usuario;

                ContratoServico.AtivarChave.Respuesta objRespuesta = objProxy.AtivarChave(objPeticao);

                if (objRespuesta.CodigoErro != 0 || objRespuesta.ChaveAcesso == null)
                {

                    if (objRespuesta.CodigoErro == Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO))
                    {
                        throw new Exception(objRespuesta.DescricaoErro);
                    }
                    else
                    {
                        throw new Execao.ExecaoNegocio((Execao.Constantes.CodigoErro)(objRespuesta.CodigoErro), objRespuesta.DescricaoErro);
                    }

                }
                else
                {
                    if (objRespuesta.ChaveAcesso != null)
                    {
                        AcessoDados.Classes.Empresa.AtualizarInformacoesChave(IdentificadorEmpresa, Comum.Clases.Constantes.COD_ACESSO_TOTAL, objRespuesta.ChaveAcesso.ChaveAcessoCriptografada,
                                                                              objRespuesta.ChaveAcesso.QuantidadeSessoes,
                                                                              objRespuesta.ChaveAcesso.QuantidadeAcessos,
                                                                              objRespuesta.ChaveAcesso.SessoesInfinitas,
                                                                              objRespuesta.ChaveAcesso.ValidadeInfinita);
                    }
                    else
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Chave invalida");
                    }
                }

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Descricao, Usuario = Usuario });
                throw ex;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

        }

        public static void ValidarChave(string Chave, Int32 CodigoEmpresa, string Usuario, string IdentificadorEmpresa)
        {
            try
            {

                ContratoServico.ValidarChave.Respuesta objRespuesta = null;

                try
                {

                    LogicaNegocio.Servico.Chave objAcao = new LogicaNegocio.Servico.Chave();

                    objRespuesta = objAcao.ValidarChaveSistema(new ContratoServico.ValidarChave.Peticao() { Chave = Chave, CodigoEmpresa = CodigoEmpresa, Usuario = Usuario }); 

                }
                catch (Exception ex)
                {

                    Comum.Clases.Empresa objEmpresa = AcessoDados.Classes.Empresa.RecuperarEmpresaSimples(IdentificadorEmpresa);

                    if (objEmpresa != null)
                    {

                        if (objEmpresa.ValidadeIlimitada)
                        {
                            objRespuesta.ChaveOk = true;
                        }
                        else if (objEmpresa.QuantidadeAcessos != null && objEmpresa.QuantidadeAcessada != null)
                        {

                            if (objEmpresa.QuantidadeAcessos > objEmpresa.QuantidadeAcessada)
                            {
                                objRespuesta.ChaveOk = false;
                            }
                        }
                    }

                }

                if (!objRespuesta.ChaveOk)
                {
                    AcessoDados.Classes.Empresa.AtualizarCodigoAcesso(IdentificadorEmpresa, Comum.Clases.Constantes.COD_ACESSO_LIMITADO);
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_ADMINISTRADOR, "Seu sistema necessita de manutenção, favor contatar a administração.");
                }

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Descricao, Usuario = Usuario });
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
