using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Backup
    {

        public static List<Comum.Clases.Coluna> RecuperarColunas(string NomeTabela)
        {


            Sql objSql = new Sql();

            objSql.AdicionarParametro("NAME", NomeTabela);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ColunasRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            List<Comum.Clases.Coluna> objColunas = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                objColunas = new List<Comum.Clases.Coluna>();
                Int32 ColId;
                Boolean ChavePrimaria = false;
                Boolean Identity = false;

                foreach (DataRow dr in dt.Rows)
                {

                    ColId = (Int32)(frmUtil.Util.AtribuirValorObj(dr["COLUMN_ID"], typeof(Int32)));
                    Identity = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["IS_IDENTITY"], typeof(Boolean)));

                    if (!Identity)
                    {
                        if (ColId == 1)
                        {
                            ChavePrimaria = true;
                        }
                        else
                        {
                            ChavePrimaria = false;
                        }

                        objColunas.Add(new Comum.Clases.Coluna()
                        {
                            NomeColuna = frmUtil.Util.AtribuirValorObj(dr["COLUMN_NAME"], typeof(string)) as string,
                            Tipo = frmUtil.Util.AtribuirValorObj(dr["DATA_TYPE"], typeof(string)) as string,
                            PrimaryKey = ChavePrimaria
                        });
                    }
                }
            }

            return objColunas;
        }

        public static void Restaurar(Comum.Clases.Tabela objTabela, ref Sql objSql)
        {

            if (objTabela.Linhas != null && objTabela.Linhas.Count > 0)
            {

                StringBuilder campos = new StringBuilder();
                StringBuilder variaveis = new StringBuilder();

                foreach (Comum.Clases.Linha objLinha in objTabela.Linhas)
                {

                    if (objLinha.Colunas != null && objLinha.Colunas.Count > 0)
                    {

                        Boolean primeiravez = true;
                        campos = new StringBuilder();
                        variaveis = new StringBuilder();
                        foreach (Comum.Clases.Coluna objColuna in objLinha.Colunas.FindAll(l => !string.IsNullOrEmpty(l.Valor)))
                        {

                            if (!primeiravez)
                            {
                                campos.Append(",");
                                variaveis.Append(",");
                            }

                            campos.Append(objColuna.NomeColuna);
                            variaveis.Append("@" + objColuna.NomeColuna);

                            object valor = null;

                            switch (objColuna.Tipo)
                            {
                                case "CODIGO20":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "DESCRICAO100":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "DESCRICAO50":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "DESCRICAO200":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "varchar":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "OBJETO_ID":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "OBJETOID":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "OBSERVACAOLONGA":

                                    valor = Convert.ToString(objColuna.Valor);
                                    break;

                                case "int":

                                    valor = Convert.ToInt32(objColuna.Valor);
                                    break;

                                case "INTEIRO":

                                    valor = Convert.ToInt32(objColuna.Valor);
                                    break;

                                case "INTEIROSEQ":

                                    valor = Convert.ToInt32(objColuna.Valor);
                                    break;

                                case "BOLEANO":

                                    valor = Convert.ToBoolean(objColuna.Valor);
                                    break;

                                case "LOGICO":

                                    valor = Convert.ToBoolean(objColuna.Valor);
                                    break;

                                case "NUMERO_DECIMAL":

                                    valor = Convert.ToDecimal(objColuna.Valor);
                                    break;

                                case "DECIMAL1":

                                    valor = Convert.ToDecimal(objColuna.Valor);
                                    break;

                                case "DATAHORA":

                                    valor = Convert.ToDateTime(objColuna.Valor);
                                    break;
                            }

                            if (primeiravez)
                            {

                                if (objColuna.Tipo == "LOGICO" && string.IsNullOrEmpty(objColuna.Valor))
                                {
                                    objSql.AdicionarParametro(objColuna.NomeColuna, false, true);
                                }
                                else
                                {
                                    objSql.AdicionarParametro(objColuna.NomeColuna, valor, true);
                                }

                            }
                            else
                            {

                                if (objColuna.Tipo == "LOGICO" && string.IsNullOrEmpty(objColuna.Valor))
                                {
                                    objSql.AdicionarParametro(objColuna.NomeColuna, false);
                                }
                                else
                                {
                                    objSql.AdicionarParametro(objColuna.NomeColuna, valor);
                                }

                            }

                            primeiravez = false;

                        }

                        if (campos.Length > 0)
                        {
                            objSql.AdicionarTransacao(string.Format(Properties.Resources.TabelasRestaurar, objTabela.NomeTabela, campos.ToString(), variaveis.ToString()));
                        }

                    }

                }
            }
        }

        public static void LimparRegistroExistentes(ref Comum.Clases.Tabela objTabela)
        {

            if (objTabela.Linhas != null && objTabela.Linhas.Count > 0)
            {

                StringBuilder campos = new StringBuilder();
                StringBuilder variaveis = new StringBuilder();
                List<Comum.Clases.Linha> LinhasRemover = null;
                List<Comum.Clases.Coluna> ColunasValidacao = null;
                Comum.Clases.Coluna ColunaCorrente = null;

                foreach (Comum.Clases.Linha objLinha in objTabela.Linhas)
                {

                    if (objLinha.Colunas != null && objLinha.Colunas.Count > 0)
                    {

                        if (objTabela.ColunasValidacao != null && objTabela.ColunasValidacao.Count > 0)
                        {

                            ColunasValidacao = objTabela.ColunasValidacao;

                            foreach (Comum.Clases.Coluna col in ColunasValidacao)
                            {

                                ColunaCorrente = (from Comum.Clases.Coluna c in objLinha.Colunas where c.NomeColuna == col.NomeColuna select c).FirstOrDefault();

                                if (ColunaCorrente != null)
                                {
                                    col.Valor = ColunaCorrente.Valor;
                                }
                            }
                        }
                        else
                        {
                            ColunasValidacao = objLinha.Colunas;
                        }

                        if (ValidarRegistroExiste(ColunasValidacao, objTabela.ValidarComTodasColunas, objTabela.NomeTabela))
                        {

                            if (LinhasRemover == null) { LinhasRemover = new List<Comum.Clases.Linha>(); }


                            LinhasRemover.Add(objLinha);
                        }
                    }

                }

                if (LinhasRemover != null && LinhasRemover.Count > 0)
                {
                    foreach (Comum.Clases.Linha objLinhaRemover in LinhasRemover)
                    {
                        objTabela.Linhas.Remove(objLinhaRemover);
                    }
                }
            }
        }

        public static List<Comum.Clases.Linha> RecuperarLinhasTabela(Comum.Clases.Tabela objTabela)
        {


            Sql objSql = new Sql();

            string Orderby = string.Empty;

            if (objTabela.ColunasOrderBy != null && objTabela.ColunasOrderBy.Count > 0)
            {

                Orderby = " ORDER BY ";
                Boolean PrimeiraVez = true;
                foreach (Comum.Clases.Coluna col in objTabela.ColunasOrderBy)
                {

                    if (!PrimeiraVez)
                    {
                        Orderby += ", ";
                    }

                    Orderby += col.NomeColuna;

                }
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(string.Format(Properties.Resources.TabelasRecuperarDados, objTabela.NomeTabela,Orderby), Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            List<Comum.Clases.Linha> objLinhas = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                objLinhas = new List<Comum.Clases.Linha>();
                Comum.Clases.Linha objLinha = null;

                foreach (DataRow dr in dt.Rows)
                {

                    objLinha = new Comum.Clases.Linha();

                    objLinha.Colunas = (List<Comum.Clases.Coluna>)(frmUtil.Util.ClonarObjeto(objTabela.Colunas));

                    if (objLinha.Colunas != null && objLinha.Colunas.Count > 0)
                    {
                        foreach (Comum.Clases.Coluna col in objLinha.Colunas)
                        {

                            switch (col.Tipo)
                            {
                                case "CODIGO20":

                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "DESCRICAO100":

                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "DESCRICAO50":

                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "DESCRICAO200":

                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "varchar":
                                    
                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "OBJETO_ID":

                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "OBJETOID":

                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "OBSERVACAOLONGA":

                                    col.Valor = frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(string)) as string;
                                    break;

                                case "int":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        Int32 val = (Int32)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(Int32)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;

                                case "INTEIRO":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        Int32 val = (Int32)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(Int32)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;

                                case "INTEIROSEQ":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        Int32 val = (Int32)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(Int32)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;

                                case "BOLEANO":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        Boolean val = (Boolean)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(Boolean)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;

                                case "LOGICO":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        Boolean val = (Boolean)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(Boolean)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;

                                case "NUMERO_DECIMAL":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        decimal val = (decimal)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(decimal)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;

                                case "DECIMAL1":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        decimal val = (decimal)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(decimal)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;

                                case "DATAHORA":

                                    if (dr[col.NomeColuna] != DBNull.Value)
                                    {

                                        DateTime val = (DateTime)(frmUtil.Util.AtribuirValorObj(dr[col.NomeColuna], typeof(DateTime)));
                                        col.Valor = Convert.ToString(val);
                                    }
                                    break;
                            }

                        }

                        objLinhas.Add(objLinha);
                    }
                }
            }

            return objLinhas;
        }

        public static Boolean ValidarRegistroExiste(List<Comum.Clases.Coluna> objColunas, Boolean ValidarComTodasColunas, string NomeTabela)
        {

            Boolean Existe = false;
            StringBuilder objwhere = new StringBuilder();
            Sql objSql = new Sql();

            if (ValidarComTodasColunas)
            {
                Boolean primeiravez = true;

                foreach (Comum.Clases.Coluna objColuna in objColunas.FindAll(c => !string.IsNullOrEmpty(c.Valor)))
                {

                    if (!primeiravez)
                    {
                        objwhere.Append(" AND ");
                    }

                    objwhere.Append(objColuna.NomeColuna + " = @" + objColuna.NomeColuna);
                    objSql.AdicionarParametro(objColuna.NomeColuna, objColuna.Valor);

                    primeiravez = false;
                }
            }
            else
            {

                Comum.Clases.Coluna objColuna = (from Comum.Clases.Coluna c in objColunas where c.PrimaryKey select c).FirstOrDefault();

                if (objColuna != null)
                {
                    objwhere.Append(objColuna.NomeColuna + " = @" + objColuna.NomeColuna);
                    objSql.AdicionarParametro(objColuna.NomeColuna, objColuna.Valor);
                }
            }

            object valor = objSql.ExecutarScalarArquivo(string.Format(Properties.Resources.TabelasVerificarRegistroExiste, NomeTabela, objwhere.ToString()), Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (valor != DBNull.Value && valor != null)
            {
                Existe = true;
            }
            else
            {
                Existe = false;
            }
            return Existe;
        }
    }
}
