using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Informatiz.ControleEstoque.Execao;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Util
    {

       public static void ValidarCampo(object campo, string msgErro, System.Type type, bool BolColecao)
       {

           if (object.ReferenceEquals(type, typeof(string)))
           {
               if (string.IsNullOrEmpty(campo as string))
               {
                   throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
               }


           }
           else if (object.ReferenceEquals(type, typeof(Nullable<bool>)))
           {
               if (campo == null)
               {
                   throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
               }


           }
           else if (object.ReferenceEquals(type, typeof(DateTime)))
           {
               if (campo.Equals(System.DateTime.MinValue))
               {
                   throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
               }


           }
           else if (object.ReferenceEquals(type, typeof(Nullable<decimal>)))
           {
               if (campo == null)
               {
                   throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
               }


           }
           else if (object.ReferenceEquals(type, typeof(Nullable<int>)))
           {
               if (campo == null)
               {
                   throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
               }

           }
           else if (object.ReferenceEquals(type, typeof(int)))
           {
               if (Convert.ToInt32(campo) == 0)
               {
                   throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
               }


           }
           else
           {

               if (BolColecao)
               {
                   if (campo == null)
                   {
                       throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
                   }


               }
               else
               {
                   if (campo == null)
                   {
                       throw new ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, msgErro);
                   }

               }
           }
       }

    }
}
