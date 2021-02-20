using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Cor
    {

       public static List<Comum.Clases.Cor> RecuperarCores(string Descricao, string IdentificadorEmpesa, string Usuario)
       {

           List<Comum.Clases.Cor> Cores = null;

           try
           {

               Cores = AcessoDados.Classes.Cor.RecuperarCores(Descricao,IdentificadorEmpesa);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return Cores;
       }

       public static void InserirCor(Comum.Clases.Cor objCor, string IdentificadorEmpresa, string Usuario)
       {
                     
           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objCor.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);
               frmUtil.Util.ValidarCampo(objCor.CodigoRGB, "Favor selecionar a cor", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.Cor.InserirCor(objCor,IdentificadorEmpresa);

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

       public static void AtualizarCor(Comum.Clases.Cor objCor, string Usuario)
       {

           try
           {
               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objCor.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);
               frmUtil.Util.ValidarCampo(objCor.CodigoRGB, "Favor selecionar a cor", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.Cor.AtualizarCor(objCor);

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

       public static void DeletarCor(string IdentificadorCor, string Usuario)
       {

           try
           {

               if (!AcessoDados.Classes.Cor.CorEstaSendoUsuada(IdentificadorCor))
               {

                   AcessoDados.Classes.Cor.DeletarCor(IdentificadorCor);
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

       public static Comum.Clases.Cor RecuperarCor(string IdentificadorCor,string Usuario)
       {
           Comum.Clases.Cor objCor = null;

           try
           {

               objCor = AcessoDados.Classes.Cor.RecuperarCor(IdentificadorCor);
               
           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return objCor;
       }
    }
}
