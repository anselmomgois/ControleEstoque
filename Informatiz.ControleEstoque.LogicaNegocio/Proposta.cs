using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Proposta
    {

       public static List<Comum.Clases.Proposta> RecuperarPropostas(string Descricao,  string IdentificadorEmpresa,
                                                                    string IdentificadorCliente, string IdentificadorFuncionario, Boolean Gerente, Nullable<Int32> Codigo, string Usuario)
       {

           List<Comum.Clases.Proposta> Propostas = null;

           try
           {

               Propostas = AcessoDados.Classes.Proposta.PesquisarProposta(Descricao, IdentificadorEmpresa, IdentificadorCliente, 
                                                                          IdentificadorFuncionario, Gerente, Codigo, string.Empty);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return Propostas;
       }

       public static void InserirProposta(Comum.Clases.Proposta objProposta, string IdentificadorEmpresa, string Usuario)
       {

           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objProposta.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.Proposta.InserirProposta(objProposta, IdentificadorEmpresa);

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

       public static void AtualizarProposta(Comum.Clases.Proposta objProposta, string Usuario)
       {

           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(objProposta.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.Proposta.AtualizarrProposta(objProposta);

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

       public static void DesativarProposta(string IdentificadorProposta, string Usuario)
       {

           try
           {

               AcessoDados.Classes.Proposta.DesativarProposta(IdentificadorProposta);

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

       public static Comum.Clases.Proposta RecuperarProposta(string IdentificadorProposta, string Usuario)
       {
           Comum.Clases.Proposta objProposta = null;

           try
           {

               objProposta = AcessoDados.Classes.Proposta.RecuperarProposta(IdentificadorProposta);

           }
           catch (Exception ex)
           {
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
               throw ex;
           }

           return objProposta;
       }
    }
}
