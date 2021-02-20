using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Estado
    {

       public static List<Comum.Clases.Estado> RecuperarEstado(string Usuario, string Identificador)

       {

           List<Comum.Clases.Estado> Estados = null;

           try
           {

               Estados = AcessoDados.Classes.Estado.RecuperarEstado(string.Empty, Identificador);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario});
               throw ex;
           }

           return Estados;
       }
    }
}
