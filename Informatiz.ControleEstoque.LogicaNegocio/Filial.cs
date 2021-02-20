using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Filial
    {

       public static List<Comum.Clases.Filiais> RecuperarFiliaisSimples(string identificadorEmpresa, string Usuario)
       {

           List<Comum.Clases.Filiais> Filiais = null;
           try
           {
               Filiais = AcessoDados.Classes.Filial.RecuperarFiliaisSimples(identificadorEmpresa);
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

           return Filiais;
       }

    }
}
