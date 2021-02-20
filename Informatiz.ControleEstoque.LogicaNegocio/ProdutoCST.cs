using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoCST
    {
        public static List<Comum.Clases.ProdutoCST> RecuperarCSTs(string Descricao, string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.ProdutoCST> ObjCSTs = null;

            try
            {

                ObjCSTs = AcessoDados.Classes.ProdutoCST.RecuperarCST(Descricao, IdentificadorEmpresa);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return ObjCSTs;
        }

        public static void InserirProdutoCST(Comum.Clases.ProdutoCST objCST, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objCST.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoCST.InserirProdutoCST(objCST, IdentificadorEmpresa);

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

        public static void AtualizarProdutoCST(Comum.Clases.ProdutoCST objCST, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objCST.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoCST.AtualizarProdutoCST(objCST);

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

        public static void DeletarProdutoComissao(string IdentificadorProdutoCST, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.ProdutoCST.ProdutoCSTEstaSendoUsuado(IdentificadorProdutoCST))
                {

                    AcessoDados.Classes.ProdutoCST.DeletarProdutoCST(IdentificadorProdutoCST);
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

        public static Comum.Clases.ProdutoCST RecuperarProdutoCST(string IdentificadorProdutoCST, string Usuario)
        {
            Comum.Clases.ProdutoCST objProdutoCST = null;

            try
            {

                objProdutoCST = AcessoDados.Classes.ProdutoCST.RecuperarProdutoCST(IdentificadorProdutoCST);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoCST;
        }
    }
}
