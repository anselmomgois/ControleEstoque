using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class SegmentoComercial
    {

       public static List<Comum.Clases.SegmentoComercial> PesquisarSegmentoComercial(string Usuario, string Identificador, string IdentificadorEmpresa, string Descricao)
       {

           List<Comum.Clases.SegmentoComercial> Segmentos = null;

           try
           {

               Segmentos = AcessoDados.Classes.SegmentoComercial.RecuperarSegmentoComercial(Identificador,IdentificadorEmpresa,Descricao);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return Segmentos;
       }

       public static void InserirSegmentoComercial(Comum.Clases.SegmentoComercial objSegmento, string IdentificadorEmpresa, string Usuario)
       {

           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objSegmento.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.SegmentoComercial.InserirSegmentoComercial(objSegmento, IdentificadorEmpresa);

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

       public static void AtualizarSegmentoComercial(Comum.Clases.SegmentoComercial objSegmento, string Usuario)
       {

           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objSegmento.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.SegmentoComercial.AtualizarSegmentoComercial(objSegmento);

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

       public static void DeletarSegmentoComercial(string IdentificadorSegmentoComercial, string Usuario)
       {

           try
           {

               if (!AcessoDados.Classes.SegmentoComercial.SegmentoComercialEstaSendoUsuado(IdentificadorSegmentoComercial))
               {

                   AcessoDados.Classes.SegmentoComercial.DeletarSegmentoComercial(IdentificadorSegmentoComercial);
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

       public static Comum.Clases.SegmentoComercial RecuperarSegmentoComercial(string IdentificadorSegmentoComercial, string Usuario)
       {
           Comum.Clases.SegmentoComercial objSegmentoComercial = null;

           try
           {

               objSegmentoComercial = AcessoDados.Classes.SegmentoComercial.RecuperarSegmentoComercialItem(IdentificadorSegmentoComercial);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return objSegmentoComercial;
       }

    }
}
