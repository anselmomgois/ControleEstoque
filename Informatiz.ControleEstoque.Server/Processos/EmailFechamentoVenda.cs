using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Clases;
using Informatiz.ControleEstoque.Comum.ParametrosTela;
using Informatiz.ControleEstoque.SDK;
using Informatiz.ControleEstoque.Comum.Extencoes;
using System.IO;
using System.Configuration;
using frmEmail = AmgSistemas.Framework.Email;

namespace Informatiz.ControleEstoque.Server.Processos
{
    public class EmailFechamentoVenda : BaseProcessos
    {

        protected override void ExecutarProcesso(Processo Processo, Comum.Clases.ItemProcesso ItemProcesso)
        {

            RecuperarDadosRelatorio(Processo, ItemProcesso);

            base.ExecutarProcesso(Processo, ItemProcesso);

        }

        private void RecuperarDadosRelatorio(Processo Processo, Comum.Clases.ItemProcesso ItemProcesso)
        {
            ContratoServico.Relatorios.RecuperarFechamentoCaixa.PeticaoRecuperarFechamentoCaixa Peticao = new ContratoServico.Relatorios.RecuperarFechamentoCaixa.PeticaoRecuperarFechamentoCaixa();

            Peticao.IdentificadorResponsavelCaixa = ItemProcesso.Valor;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa, ContratoServico.Relatorios.RecuperarFechamentoCaixa.PeticaoRecuperarFechamentoCaixa>(Peticao,
                SDK.Operacoes.operacao.RecuperarFechamentoCaixa, new Comum.ParametrosTela.Generica()
                {
                    PreencherObjeto = true,
                    ExibirMensagemNenhumRegistro = false,
                    Processo = Processo,
                    ItemProcesso = ItemProcesso
                }, null, true);

        }

        protected override void RespostaAgente(object objSaida, Operacoes.operacao operacao, Generica Parametros)
        {
            try
            {

                if (operacao == SDK.Operacoes.operacao.RecuperarFechamentoCaixa)
                {

                    ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa objSaidaConvertido = (ContratoServico.Relatorios.RecuperarFechamentoCaixa.RespostaRecuperarFechamentoCaixa)objSaida;

                    if (objSaidaConvertido != null && objSaidaConvertido.DadosRelatorio != null)
                        objSaidaConvertido.DadosRelatorio.NomeEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome;

                    Stream objReport = Relatorios.Classes.Imprimir.ReportToStream(objSaidaConvertido, Comum.Enumeradores.TipoRelatorio.FechamentoCaixaEmail);

                    if(objReport != null)
                    {
                        List<string> lista = new List<string>();
                        lista.Add("");
                        frmEmail.Email.enviaMensagemEmail(lista, "", null,null, "Email Fechamento Caixa", "Fechamento Caixa", "smtp-mail.outlook.com",
                            System.Net.Mail.MailPriority.Normal, 587, true, "", objReport, new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain));
                    }

                }
            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
