using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio.Servico
{
    public class Imagem
    {

        public static void InserirImagemCentral(Comum.Clases.Imagem objImagem, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                if (objImagem.ImgImagemCentral == null)
                {
                    Erros.AppendLine("Favor informar uma imagem");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.Servico.Imagem.DeletarImagemCentral(ref objSql);

                AcessoDados.Classes.Servico.Imagem.InserirImagemCentral(objImagem, ref objSql);

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

        public static ContratoServico.RecuperarImagem.Resposta RecuperarImagem(string Usuario)
        {

            ContratoServico.RecuperarImagem.Resposta objResposta = new ContratoServico.RecuperarImagem.Resposta();

            try
            {

                objResposta.objImagem = AcessoDados.Classes.Servico.Imagem.RecuperarImagem();

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objResposta;
        }
    }
}
