using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Backup
    {

        public static List<Comum.Clases.Coluna> RecuperarColunas(string NomeTabela, string Usuario)
        {

            List<Comum.Clases.Coluna> Colunas = null;
            try
            {
                Colunas = AcessoDados.Classes.Backup.RecuperarColunas(NomeTabela);
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Colunas;
        }

        public static Comum.Clases.TabelaColecao GerarBackup(Comum.Clases.TabelaColecao Tabelas, string Usuario)
        {
                       
            try
            {

                if (Tabelas != null && Tabelas.Count > 0)
                {

                    foreach (Comum.Clases.Tabela t in Tabelas)
                    {
                        t.Linhas = AcessoDados.Classes.Backup.RecuperarLinhasTabela(t);
                    }
                }
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Tabelas;
        }


        public static void RestaurarBackup(Comum.Clases.TabelaColecao Tabelas, string Usuario)
        {

            try
            {

                StringBuilder Erros = new StringBuilder();

                if (Tabelas != null && Tabelas.Count > 0)
                {

                    Sql objSql = null;

                    foreach (Comum.Clases.Tabela t in Tabelas)
                    {

                        try
                        {
                            objSql = new Sql();
                            Comum.Clases.Tabela objTabela = t;

                            AcessoDados.Classes.Backup.LimparRegistroExistentes(ref objTabela);

                            objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);


                            AcessoDados.Classes.Backup.Restaurar(objTabela, ref objSql);

                            objSql.ExecutarTransacao();
                        }
                        catch (Exception ex)
                        {
                            Erros.AppendLine(ex.ToString());
                        }
                    }

                    if (Erros.Length > 0)
                    {
                        throw new Exception(Erros.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
             
        }

    }
}
