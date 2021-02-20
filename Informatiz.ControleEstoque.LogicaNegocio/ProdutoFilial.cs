using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoFilial
    {

        public static Comum.Clases.ProdutoFilial RecuperarProdutoFilial(string IdentificadorFilial,
                                                                        string IdentificadorProdutoServico,
                                                                        string Usuario)
        {
            Comum.Clases.ProdutoFilial objProdutoFilial = null;

            try
            {

                objProdutoFilial = AcessoDados.Classes.ProdutoFilial.RecuperarProdutoFilial(IdentificadorFilial, IdentificadorProdutoServico);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoFilial;
        }

        public static void InserirProdutoFilial(Comum.Clases.ProdutoFilial objProdutoFilial,
                                                 string IdentificadorFilial,
                                                 string IdentificadorProdutoServico,
                                                 string Usuario)
        {
            try
            {

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                AcessoDados.Classes.ProdutoFilial.InserirProdutoFilial(objProdutoFilial, IdentificadorFilial,
                                                                       IdentificadorProdutoServico, ref objSql);

                objSql.ExecutarTransacao();

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

        }

        public static void AtualizarProdutoFilial(Comum.Clases.ProdutoFilial objProdutoFilial,
                                                  string Usuario)
        {
            try
            {


                AcessoDados.Classes.ProdutoFilial.AtualizarProdutoFilial(objProdutoFilial);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

        }

    }
}
