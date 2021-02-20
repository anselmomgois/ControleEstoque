using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoDerivacao
    {

        public static List<Comum.Clases.ProdutoDerivacao> RecuperarDerivacao(string Descricao, string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.ProdutoDerivacao> ObjDerivacao = null;

            try
            {

                ObjDerivacao = AcessoDados.Classes.ProdutoDerivacao.RecuperarDerivacao(Descricao, IdentificadorEmpresa);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ObjDerivacao;
        }

        public static void InserirProdutoDerivacao(Comum.Clases.ProdutoDerivacao objDerivacao, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objDerivacao.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoDerivacao.InserirProdutoDerivacao(objDerivacao, IdentificadorEmpresa);

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

        public static void AtualizarProdutoDerivacao(Comum.Clases.ProdutoDerivacao objDerivacao, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objDerivacao.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoDerivacao.AtualizarProdutoDerivacao(objDerivacao);

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

        public static void DeletarProdutoDerivacao(string IdentificadorProdutoDerivacao, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.ProdutoDerivacao.ProdutoDerivacaoEstaSendoUsuado(IdentificadorProdutoDerivacao))
                {

                    AcessoDados.Classes.ProdutoDerivacao.DeletarProdutoDerivacao(IdentificadorProdutoDerivacao);
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos que estão utilizando está derivação");
                }
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

        public static Comum.Clases.ProdutoDerivacao RecuperarProdutoDerivacao(string IdentificadorProdutoDerivacao, string Usuario)
        {
            Comum.Clases.ProdutoDerivacao objProdutoDerivacao = null;

            try
            {

                objProdutoDerivacao = AcessoDados.Classes.ProdutoDerivacao.RecuperarProdutoDerivacao(IdentificadorProdutoDerivacao);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoDerivacao;
        }
    }
}
