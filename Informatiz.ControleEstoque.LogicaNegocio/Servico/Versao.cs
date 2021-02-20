using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.LogicaNegocio.Servico
{
   public class Versao
    {

       public static ContratoServico.RecuperarVersao.Resposta RecuperarVersao(string Usuario)
       {

           ContratoServico.RecuperarVersao.Resposta objResposta = new ContratoServico.RecuperarVersao.Resposta();

           try
           {

               objResposta.CodigoVersao = AcessoDados.Classes.Servico.Versao.RecuperarVersao();

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return objResposta;
       }

    }
}
