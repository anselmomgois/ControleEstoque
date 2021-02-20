using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoCFOP
    {

        public static List<Comum.Clases.ProdutoCFOP> RecuperarCFOP(string Descricao, string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.ProdutoCFOP> ObjCFOP = null;

            try
            {

                ObjCFOP = AcessoDados.Classes.ProdutoCFOP.RecuperarCFOPs(Descricao, IdentificadorEmpresa);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ObjCFOP;
        }

        public static void InserirProdutoCFOP(Comum.Clases.ProdutoCFOP objCFOP, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objCFOP.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoCFOP.InserirProdutoCFOP(objCFOP, IdentificadorEmpresa);

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

        public static void AtualizarProdutoCFOP(Comum.Clases.ProdutoCFOP objCFOP, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objCFOP.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);


                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoCFOP.AtualizarProdutoCFOP(objCFOP);

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

        public static void DeletarProdutoCFOP(string IdentificadorProdutoCFOP, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.ProdutoCFOP.ProdutoCFOPEstaSendoUsuado(IdentificadorProdutoCFOP))
                {

                    AcessoDados.Classes.ProdutoCFOP.DeletarProdutoCFOP(IdentificadorProdutoCFOP);
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos que estão utilizando este código");
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

        public static Comum.Clases.ProdutoCFOP RecuperarProdutoCFOP(string IdentificadorProdutoCFOP, string Usuario)
        {
            Comum.Clases.ProdutoCFOP objProdutoCFOP = null;

            try
            {

                objProdutoCFOP = AcessoDados.Classes.ProdutoCFOP.RecuperarProdutoCFOP(IdentificadorProdutoCFOP);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoCFOP;
        }
  
    }
}
