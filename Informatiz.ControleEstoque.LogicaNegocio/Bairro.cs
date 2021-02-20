using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Bairro
    {

        public static List<Comum.Clases.Bairro> RecuperarBairro(Nullable<int> Codigo, string Nome, string Usuario,
                                                                string IdentificadorCidade, string Identificador)
        {

            List<Comum.Clases.Bairro> Bairros = null;
            try
            {
                Bairros = AcessoDados.Classes.Bairro.RecuperarBairro(IdentificadorCidade, Identificador, string.Empty, Nome, Codigo);
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Bairros;
        }

        public static Comum.Clases.Bairro SetBairro(Comum.Clases.Bairro Bairro, string IdentificadorCidade, string Usuario)
        {

            Comum.Clases.Bairro objBairro = null;

            try
            {

                Sql objSql = new Sql();
                List<Comum.Clases.Bairro> objBairros = null;

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                objBairros = AcessoDados.Classes.Bairro.RecuperarBairro(IdentificadorCidade, string.Empty, Bairro.Nome, string.Empty, null);

                if (string.IsNullOrEmpty(Bairro.Identificador))
                {


                    if (objBairros != null && objBairros.Count > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O bairro informado já existe na base de dados.");
                    }

                    Bairro.Identificador = AcessoDados.Classes.Bairro.InserirBairro(IdentificadorCidade, Bairro.Nome, ref objSql);

                }
                else
                {

                    if (objBairros != null && objBairros.FindAll(b => b.Identificador != Bairro.Identificador).Count > 0)
                    {

                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O bairro informado já existe na base de dados.");
                    }

                    AcessoDados.Classes.Bairro.AtualizarBairro(Bairro.Nome, Bairro.Identificador, ref objSql);

                }

                objSql.ExecutarTransacao();

                objBairro = AcessoDados.Classes.Bairro.RecuperarBairro(IdentificadorCidade, Bairro.Identificador, string.Empty, string.Empty, null).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objBairro;
        }

    }
}
