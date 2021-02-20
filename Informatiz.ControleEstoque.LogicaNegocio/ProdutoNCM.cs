using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoNCM
    {

        public static List<Comum.Clases.ProdutoNCM> PesquisarProdutoNCM(string Descricao, string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.ProdutoNCM> ProdutosNCM = null;

            try
            {

                ProdutosNCM = AcessoDados.Classes.ProdutoNCM.PesquisarProdutoNCM(Descricao, IdentificadorEmpresa);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ProdutosNCM;
        }

        public static void InserirProdutoNCM(Comum.Clases.ProdutoNCM objProdutoNCM, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objProdutoNCM.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoNCM.InserirProdutoNCM(objProdutoNCM, IdentificadorEmpresa);

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

        public static void AtualizarProdutoNCM(Comum.Clases.ProdutoNCM objProdutoNCM, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objProdutoNCM.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoNCM.AtualizarProdutoNCM(objProdutoNCM);

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

        public static void DeletarProdutoNCM(string IdentificadorProdutoNCM, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.ProdutoNCM.ProdutoNCMEstaSendoUsuada(IdentificadorProdutoNCM))
                {

                    AcessoDados.Classes.ProdutoNCM.DeletarProdutoNCM(IdentificadorProdutoNCM);
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos que estão utilizando esta cor.");
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

        public static Comum.Clases.ProdutoNCM RecuperarProdutoNCM(string IdentificadorProdutoNCM, string Usuario)
        {
            Comum.Clases.ProdutoNCM objProdutoNCM = null;

            try
            {

                objProdutoNCM = AcessoDados.Classes.ProdutoNCM.RecuperarProdutoNCM(IdentificadorProdutoNCM);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoNCM;
        }

    }
}
