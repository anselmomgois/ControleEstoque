using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoComissao
    {

        public static List<Comum.Clases.ProdutoComissao> RecuperarComissoes(string Descricao, string IdentificadorFilial, string Usuario)
        {

            List<Comum.Clases.ProdutoComissao> ObjComissoes = null;

            try
            {
                if (!string.IsNullOrEmpty(IdentificadorFilial))
                {
                    ObjComissoes = AcessoDados.Classes.ProdutoComissao.RecuperarComissoes(Descricao, IdentificadorFilial);
                }

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ObjComissoes;
        }

        public static void InserirProdutoComissao(Comum.Clases.ProdutoComissao objComissao, string IdentificadorFilial, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objComissao.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (objComissao.NumPercentual == 0 && objComissao.NumValor == 0)
                {
                    Erros.AppendLine("Favor informar o percentual da comissão ou o valor fixo");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoComissao.InserirProdutoComissao(objComissao, IdentificadorFilial);

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

        public static void AtualizarProdutoComissao(Comum.Clases.ProdutoComissao objComissao, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objComissao.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (objComissao.NumPercentual == 0 && objComissao.NumValor == 0)
                {
                    Erros.AppendLine("Favor informar o percentual da comissão ou o valor fixo");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoComissao.AtualizarProdutoComissao(objComissao);

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

        public static void DesativaProdutoComissao(string IdentificadorProdutoComissao, string Usuario)
        {

            try
            {

                AcessoDados.Classes.ProdutoComissao.DesativarProdutoComissao(IdentificadorProdutoComissao);

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

        public static Comum.Clases.ProdutoComissao RecuperarProdutoComissao(string IdentificadorProdutoComissao, string Usuario)
        {
            Comum.Clases.ProdutoComissao objProdutoComissao = null;

            try
            {

                objProdutoComissao = AcessoDados.Classes.ProdutoComissao.RecuperarProdutoComissao(IdentificadorProdutoComissao);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoComissao;
        }
    }
}
