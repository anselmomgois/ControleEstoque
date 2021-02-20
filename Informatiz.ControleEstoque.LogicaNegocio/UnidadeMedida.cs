using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class UnidadeMedida
    {

        public static List<Comum.Clases.UnidadeMedida> RecuperarUnidadesMedida(string Descricao, string IdentificadorEmpresa, string Usuario, Boolean RecuperarUnidadesFilhas)
        {

            List<Comum.Clases.UnidadeMedida> UnidadesMedida = null;

            try
            {

                UnidadesMedida = AcessoDados.Classes.UnidadesMedida.RecuperarUnidadesMedida(Descricao, IdentificadorEmpresa,RecuperarUnidadesFilhas);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return UnidadesMedida;
        }

        public static Comum.Clases.UnidadeMedida RecuperarUnidadeMedida(string IdentificadorUnidadeMedida, string Usuario)
        {
            Comum.Clases.UnidadeMedida objUnidadeMedida = null;

            try
            {

                objUnidadeMedida = AcessoDados.Classes.UnidadesMedida.RecuperarUnidadeMedida(IdentificadorUnidadeMedida);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objUnidadeMedida;
        }

        public static void InserirUnidadeMedida(Comum.Clases.UnidadeMedida objUnidadeMedida, string IdentificadorEmpresa, string Usuario)
        {

            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objUnidadeMedida.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objUnidadeMedida.Codigo, "Favor selecionar a cor", typeof(string), false, ref Erros);

                if (objUnidadeMedida.UnidademedidaPai != null)
                {
                    frmUtil.Util.ValidarCampo(objUnidadeMedida.NumValorUnidadePai, "Favor informar o valor da unidade pai", typeof(Nullable<Decimal>), false, ref Erros);
                }

                if (objUnidadeMedida.NumValorUnidadePai != null)
                {
                    frmUtil.Util.ValidarCampo(objUnidadeMedida.UnidademedidaPai, "Favor selecionar a unidade pai", typeof(Comum.Clases.UnidadeMedida), false, ref Erros);
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.UnidadesMedida.InserirUnidadeMedida(objUnidadeMedida, IdentificadorEmpresa);

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

        public static void AtualizarUnidadeMedida(Comum.Clases.UnidadeMedida objUnidadeMedida, string Usuario)
        {

            try
            {
                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(objUnidadeMedida.Descricao, "Favor informar a descrição", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objUnidadeMedida.Codigo, "Favor informar o código", typeof(string), false, ref Erros);

                if (objUnidadeMedida.UnidademedidaPai != null)
                {
                    frmUtil.Util.ValidarCampo(objUnidadeMedida.NumValorUnidadePai, "Favor informar o valor da unidade pai", typeof(Nullable<Decimal>), false, ref Erros);
                }

                if (objUnidadeMedida.NumValorUnidadePai != null)
                {
                    frmUtil.Util.ValidarCampo(objUnidadeMedida.UnidademedidaPai, "Favor selecionar a unidade pai", typeof(Comum.Clases.UnidadeMedida), false, ref Erros);
                }

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.UnidadesMedida.AtualizarUnidadeMedida(objUnidadeMedida);

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

        public static void DeletarUnidadeMedida(string IdentificadorUnidadeMedida, string Usuario)
        {

            try
            {

                AcessoDados.Classes.UnidadesMedida.DeletarUnidadeMedida(IdentificadorUnidadeMedida);
                
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("FK"))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não é possivel deletar a unidade de medida, poi ela está sendo usada.");
                }
                else
                {
                    throw ex;
                }
            }
        }

        public static List<Comum.Clases.UnidadeMedida> RecuperarUnidadesMedidaProduto(string IdentificadorProduto, string Usuario)
        {

            List<Comum.Clases.UnidadeMedida> UnidadesMedida = null;

            try
            {

                UnidadesMedida = AcessoDados.Classes.UnidadesMedida.RecuperarUnidadesMedidaProduto(IdentificadorProduto);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return UnidadesMedida;
        }
    }
}
