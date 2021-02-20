using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class ProdutoCategoria
    {

       public static List<Comum.Clases.ProdutoCategoria> RecuperarCategorias(string Descricao, string IdentificadorEmpresa, string Usuario)
       {

           List<Comum.Clases.ProdutoCategoria> TiposProdutos = null;

           try
           {

               TiposProdutos = AcessoDados.Classes.ProdutoCategoria.RecuperarCategorias(Descricao, IdentificadorEmpresa);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return TiposProdutos;
       }

       public static void InserirProdutoCategoria(Comum.Clases.ProdutoCategoria objCategoria, string IdentificadorEmpresa, string Usuario)
       {

           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objCategoria.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);
 
               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.ProdutoCategoria.InserirProdutoCategoria(objCategoria, IdentificadorEmpresa);

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

       public static void AtualizarProdutoCategoria(Comum.Clases.ProdutoCategoria objCategoria, string Usuario)
       {

           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objCategoria.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.ProdutoCategoria.AtualizarProdutoCategoria(objCategoria);

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

       public static void DeletarProdutoCategoria(string IdentificadorProdutoCategoria, string Usuario)
       {

           try
           {

               if (!AcessoDados.Classes.ProdutoCategoria.ProdutoCategoriaEstaSendoUsuado(IdentificadorProdutoCategoria))
               {

                   AcessoDados.Classes.ProdutoCategoria.DeletarProdutoCategoria(IdentificadorProdutoCategoria);
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

       public static Comum.Clases.ProdutoCategoria RecuperarProdutoCategoria(string IdentificadorProdutoCategoria, string Usuario)
       {
           Comum.Clases.ProdutoCategoria objProdutoCategoria = null;

           try
           {

               objProdutoCategoria = AcessoDados.Classes.ProdutoCategoria.RecuperarProdutoCategoria(IdentificadorProdutoCategoria);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return objProdutoCategoria;
       }
   }
}
