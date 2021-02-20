using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Documento
    {

        public static List<Comum.Clases.Documento> RecuperarDocumentos(string IdentificadorCliente, string CodigoTransacao, 
                                                                       Nullable<DateTime> DataInicio, Nullable<DateTime> DataFim, string IdentificadorTipodocumento,
                                                                       string CodigoDocumento, string IdentificadorEmpresa, string Usuario)
        {

            List<Comum.Clases.Documento> Documentos = null;

            try
            {

                
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Documentos;
        }

        public static void InserirDocumento(Comum.Clases.Documento objDocumento, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objDocumento.Pessoa, "Favor informar a pessoa", typeof(Comum.Clases.Pessoa), false, ref Erros);
                frmUtil.Util.ValidarCampo(objDocumento.FormaPagamento, "Favor informar a forma de pagamento", typeof(Comum.Clases.FormaPagamento), false, ref Erros);
                frmUtil.Util.ValidarCampo(objDocumento.Codigo, "Favor informar o código do documento", typeof(string), false, ref Erros);

                if (objDocumento.ValorOriginal <= 0)
                {
                    Erros.AppendLine("Favor informar um valor");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                //AcessoDados.Classes.ProdutoMarca.InserirProdutoMarca(objMarca, IdentificadorEmpresa);

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

        public static void AtualizarDocumento(Comum.Clases.Documento objDocumento, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objDocumento.Pessoa, "Favor informar a pessoa", typeof(Comum.Clases.Pessoa), false, ref Erros);
                frmUtil.Util.ValidarCampo(objDocumento.FormaPagamento, "Favor informar a forma de pagamento", typeof(Comum.Clases.FormaPagamento), false, ref Erros);
                frmUtil.Util.ValidarCampo(objDocumento.Codigo, "Favor informar o código do documento", typeof(string), false, ref Erros);

                if (objDocumento.ValorOriginal <= 0)
                {
                    Erros.AppendLine("Favor informar um valor");
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                //AcessoDados.Classes.ProdutoMarca.AtualizarProdutoMarca(objMarca);

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

        public static void DeletarDocumento(string IdentificadorDocumento, string Usuario)
        {

            try
            {

                //if (!AcessoDados.Classes.ProdutoMarca.ProdutoMarcaEstaSendoUsuada(IdentificadorProdutoMarca))
                //{

                //    AcessoDados.Classes.ProdutoMarca.DeletarProdutoMarca(IdentificadorProdutoMarca);
                //}
                //else
                //{
                //    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos que estão utilizando esta cor.");
                //}
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

        public static Comum.Clases.Documento RecuperarDocumento(string IdentificadorDocumento, string Usuario)
        {
            Comum.Clases.Documento objDocumento = null;

            try
            {

                //objProdutoMarca = AcessoDados.Classes.ProdutoMarca.RecuperarProdutoMarca(IdentificadorProdutoMarca);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objDocumento;
        }

    }
}
