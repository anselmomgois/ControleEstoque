using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
   public class Administradora
    {

       public static ContratoServico.Administradora.RecuperarAdministradoras.RespostaRecuperarAdministradoras RecuperarAdministradoras(ContratoServico.Administradora.RecuperarAdministradoras.PeticaoRecuperarAdministradoras  Peticao)
       {

           ContratoServico.Administradora.RecuperarAdministradoras.RespostaRecuperarAdministradoras Resposta = new ContratoServico.Administradora.RecuperarAdministradoras.RespostaRecuperarAdministradoras();

           try
           {

               Resposta.Administradoras = AcessoDados.Classes.Administradora.RecuperarAdministradoras(Peticao.Descricao, Peticao.IdentificadorEmpresa);

               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);


           }
           catch (Exception ex)
           {

               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
               Resposta.DescricaoErro = ex.Message;
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
            }

           return Resposta;
       }

       public static ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora InserirAdministradora(ContratoServico.Administradora.InserirAdministradora.PeticaoInserirAdministradora Peticao)
       {
           ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora Resposta = new ContratoServico.Administradora.InserirAdministradora.RespostaInserirAdministradora();
           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(Peticao.Administradora.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);
               
               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.Administradora.InserirAdministradora(Peticao.Administradora, Peticao.IdentificadorEmpresa);

               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);


           }
           catch (Execao.ExecaoNegocio ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
               Resposta.DescricaoErro = ex.Message;
           }
           catch (Exception ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
               Resposta.DescricaoErro = ex.Message;
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
           }

           return Resposta;
       }

       public static ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora AtualizarAdministradora(ContratoServico.Administradora.AtualizarAdministradora.PeticaoAtualizarAdministradora Peticao)
       {

           ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora Resposta = new ContratoServico.Administradora.AtualizarAdministradora.RespostaAtualizarAdministradora();

           try
           {

               System.Text.StringBuilder Erros = new System.Text.StringBuilder();

               frmUtil.Util.ValidarCampo(Peticao.Administradora.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

               if (Erros.Length > 0)
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
               }

               AcessoDados.Classes.Administradora.AtualizarAdministradora(Peticao.Administradora);

               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);

           }
           catch (Execao.ExecaoNegocio ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
               Resposta.DescricaoErro = ex.Message;
           }
           catch (Exception ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
               Resposta.DescricaoErro = ex.Message;
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
           }

           return Resposta;
       }

       public static ContratoServico.Administradora.DeletarAdministradora.RespostaDeletarAdministradora DeletarAdministradora(ContratoServico.Administradora.DeletarAdministradora.PeticaoDeletarAdministradora Peticao)
       {

           ContratoServico.Administradora.DeletarAdministradora.RespostaDeletarAdministradora  Resposta = new ContratoServico.Administradora.DeletarAdministradora.RespostaDeletarAdministradora();
           try
           {

               if (!AcessoDados.Classes.Administradora.AdministradoraEstaSendoUsuada(Peticao.IdentificadorAdministradora))
               {

                   AcessoDados.Classes.Administradora.DeletarAdministradora(Peticao.IdentificadorAdministradora);
               }
               else
               {
                   throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos que estão utilizando esta cor.");
               }

               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);

           }
           catch (Execao.ExecaoNegocio ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
               Resposta.DescricaoErro = ex.Message;
           }
           catch (Exception ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
               Resposta.DescricaoErro = ex.Message;
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
           }

           return Resposta;
       }

       public static ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora RecuperarAdministradora(ContratoServico.Administradora.RecuperarAdministradora.PeticaoRecuperarAdministradora Peticao)
       {
           ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora Resposta = new ContratoServico.Administradora.RecuperarAdministradora.RespostaRecuperarAdministradora();

           try
           {

               Resposta.Administradora = AcessoDados.Classes.Administradora.RecuperarAdministradora(Peticao.IdentificadorAdministradora);

               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);

           }
           catch (Execao.ExecaoNegocio ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_NEGOCIO);
               Resposta.DescricaoErro = ex.Message;
           }
           catch (Exception ex)
           {
               Resposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
               Resposta.DescricaoErro = ex.Message;
               Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
           }

           return Resposta;
       }


    }
}
