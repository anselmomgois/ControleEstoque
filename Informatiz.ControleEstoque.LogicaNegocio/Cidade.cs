using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Cidade
    {

        public static List<Comum.Clases.Cidade> RecuperarCidades(Nullable<int> Codigo, string Nome, string Usuario,
                                                                 string IdentificadorEstado, string Identificador)
        {

            List<Comum.Clases.Cidade> Cidades = null;
            try
            {
                Cidades = AcessoDados.Classes.Cidade.RecuperarCidades(Identificador, IdentificadorEstado, string.Empty, Nome, Codigo);
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Cidades;
        }

        public static Comum.Clases.Cidade SetCidades(Comum.Clases.Cidade Cidade, string IdentificadorEstado, string Usuario)
        {

            Comum.Clases.Cidade objCidade = null;

            try
            {

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);
                List<Comum.Clases.Cidade> objCidades = AcessoDados.Classes.Cidade.RecuperarCidades(string.Empty, IdentificadorEstado, Cidade.Nome, string.Empty, null); ;


                if (string.IsNullOrEmpty(Cidade.Identificador))
                {


                    if (objCidades != null && objCidades.Count > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A cidade informada já existe na base de dados.");
                    }

                    Cidade.Identificador = AcessoDados.Classes.Cidade.InserirCidade(Cidade.Nome, IdentificadorEstado, Cidade.DDD, Cidade.IBGE, ref objSql);

                }
                else
                {

                    if (objCidades != null && objCidades.FindAll(b => b.Identificador != Cidade.Identificador).Count > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A cidade informada  já existe na base de dados.");
                    }

                    AcessoDados.Classes.Cidade.AtualizarCidade(Cidade.Nome, Cidade.Identificador, Cidade.DDD, Cidade.IBGE, ref objSql);

                }

                objSql.ExecutarTransacao();

                objCidade = AcessoDados.Classes.Cidade.RecuperarCidades(Cidade.Identificador, IdentificadorEstado, string.Empty, string.Empty, null).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objCidade;
        }

    }
}
