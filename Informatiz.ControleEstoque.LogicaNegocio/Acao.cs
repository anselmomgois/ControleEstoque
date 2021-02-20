using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Acao
    {

        public static ContratoServico.Acao.RecuperarAcoes.RespostaRecuperarAcoes RecuperarAcoes(ContratoServico.Acao.RecuperarAcoes.PeticaoRecuperarAcoes Peticao)
        {

            ContratoServico.Acao.RecuperarAcoes.RespostaRecuperarAcoes Resposta = new ContratoServico.Acao.RecuperarAcoes.RespostaRecuperarAcoes();
            List<Comum.Clases.Acao> Acoes = null;
            try
            {
                Acoes = AcessoDados.Classes.Acao.RecuperarAcoes();

                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);
                Resposta.Acoes = Acoes;
            }
            catch (Exception ex)
            {

                Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                Resposta.DescricaoErro = ex.Message;
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
            }

            return Resposta;
        }

    }
}
