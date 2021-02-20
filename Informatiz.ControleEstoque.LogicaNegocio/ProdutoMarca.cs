using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoMarca
    {
        public static List<Comum.Clases.ProdutoMarca> RecuperarMarcas(string Descricao, string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.ProdutoMarca> Marcas = null;

            try
            {

                Marcas = AcessoDados.Classes.ProdutoMarca.RecuperarMarca(Descricao,IdentificadorEmpresa);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Marcas;
        }

        public static void InserirProdutoMarca(Comum.Clases.ProdutoMarca objMarca, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objMarca.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoMarca.InserirProdutoMarca(objMarca,IdentificadorEmpresa);

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

        public static void AtualizarProdutoMarca(Comum.Clases.ProdutoMarca objMarca, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objMarca.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.ProdutoMarca.AtualizarProdutoMarca(objMarca);

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

        public static void DeletarProdutoMarca(string IdentificadorProdutoMarca, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.ProdutoMarca.ProdutoMarcaEstaSendoUsuada(IdentificadorProdutoMarca))
                {

                    AcessoDados.Classes.ProdutoMarca.DeletarProdutoMarca(IdentificadorProdutoMarca);
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

        public static Comum.Clases.ProdutoMarca RecuperarProdutoMarca(string IdentificadorProdutoMarca, string Usuario)
        {
            Comum.Clases.ProdutoMarca objProdutoMarca = null;

            try
            {

                objProdutoMarca = AcessoDados.Classes.ProdutoMarca.RecuperarProdutoMarca(IdentificadorProdutoMarca);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objProdutoMarca;
        }
    }
}
