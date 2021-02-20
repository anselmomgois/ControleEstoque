using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Informatiz.ControleEstoque;
using AmgSistemas.Framework.Email;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Erro
    {

       public static void InserirErro(Comum.Clases.Erro objErro)
       {

           try
           {
 
               AcessoDados.Classes.Erro.InerirErro(objErro);

           }
           catch (Exception ex)
           { 
           
           }
       }

    }
}
