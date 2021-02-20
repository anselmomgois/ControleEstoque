using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Publicidade
    {

        public static List<Comum.Clases.Publicidade> RecuperarPublicidades(string Descricao, string Usuario)
        {

            List<Comum.Clases.Publicidade> Publicidades = null;

            try
            {

                Publicidades = AcessoDados.Classes.Publicidade.RecuperarPublicidades(Descricao);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Publicidades;
        }

        public static void InserirPublicidade(Comum.Clases.Publicidade objPublicidade, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objPublicidade.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.Publicidade.InserirPublicidade(objPublicidade);

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

        public static void AtualizarPubliciade(Comum.Clases.Publicidade objPublicidade, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objPublicidade.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.Publicidade.AtualizarPublicidade(objPublicidade);

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

        public static void DeletarPublicidade(string IdentificadorPublicidade, string Usuario)
        {

            try
            {

                if (!AcessoDados.Classes.Publicidade.PublicidadeEstaSendoUsuada(IdentificadorPublicidade))
                {

                    AcessoDados.Classes.Publicidade.DeletarPublicidade(IdentificadorPublicidade);
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Publicidade está sendo usada.");
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

        public static Comum.Clases.Publicidade RecuperarPublicidade(string IdentificadorPublicidade, string Usuario)
        {
            Comum.Clases.Publicidade objPublicidade = null;

            try
            {

                objPublicidade = AcessoDados.Classes.Publicidade.RecuperarPublicidade(IdentificadorPublicidade);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objPublicidade;
        }
    }
}
