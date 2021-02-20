using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using frmEmail = AmgSistemas.Framework.Email;

namespace Informatiz.ControleEstoque.API.Controllers
{
    [RoutePrefix("api/Erro")]
    public class ErroController : ApiController
    {

        [AcceptVerbs("POST")]
        [Route("InserirErro")]
        [Classes.ValidateModel]
        public ContratoServico.Erro.InserirErro.RespostaInserirErro InserirErro(ContratoServico.Erro.InserirErro.PeticaoInserirErro Peticao)
        {

            ContratoServico.Erro.InserirErro.RespostaInserirErro objSaida = new ContratoServico.Erro.InserirErro.RespostaInserirErro();

            try
            {

                try
                {
                    List<string> lista = new List<string>();
                    string MesagemDetalhada = string.Empty;
                    if (Peticao.Erro.Execao != null)
                    {
                        if (Peticao.Erro.Execao.StackTrace != null)
                        {
                            MesagemDetalhada = Peticao.Erro.Execao.StackTrace.ToString();
                        }

                        RecuperarErro(ref MesagemDetalhada, Peticao.Erro.Execao);

                    }

                    lista.Add("");
                    frmEmail.Email.enviaMensagemEmail(lista, "", null, null,
                    "IMPORTANTE - ERRO", Peticao.Erro.DesErro + " - " + Peticao.Erro.Usuario + " - " + MesagemDetalhada, "smtp-mail.outlook.com", System.Net.Mail.MailPriority.Normal, 587, true, "");

                }
                catch (Exception ex)
                {
                    LogicaNegocio.Erro.InserirErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.ToString(), Usuario = Peticao.Erro.Usuario });
                }

                LogicaNegocio.Erro.InserirErro(Peticao.Erro);


                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                objSaida.CodigoErro = Convert.ToInt32(ex.Codigo);
                objSaida.DescricaoErro = ex.Descricao;

            }
            catch (Exception ex)
            {

                objSaida.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objSaida.DescricaoErro = "Aconteceu um erro inesperado.";

            }
            return objSaida;
        }

        private void RecuperarErro(ref string Mensagem, Exception ex)
        {

            if (ex.InnerException != null)
            {
                Mensagem += " " + ex.InnerException.Message;

                if (ex.InnerException.StackTrace != null)
                {
                    Mensagem += " " + ex.InnerException.StackTrace.ToString();

                }

                RecuperarErro(ref Mensagem, ex.InnerException);
            }

        }

    }
}
