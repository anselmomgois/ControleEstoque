using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Cor
    {

        public static List<Comum.Clases.Cor> RecuperarCores(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.Cor> objCores = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESCOR LIKE @DESCOR ";
                objSql.AdicionarParametro("DESCOR", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.CoresRecuperar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objCores = new List<Comum.Clases.Cor>();

                foreach (DataRow dr in dt.Rows)
                {
                    objCores.Add(new Comum.Clases.Cor
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDCOR"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODCOR"], typeof(Int32))),
                        CodigoRGB = frmUtil.Util.AtribuirValorObj(dr["CODCORRGB"], typeof(string)) as string,
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESCOR"], typeof(string)) as string
                    });
                }
            }

            return objCores;
        }

        public static Comum.Clases.Cor RecuperarCor(string IdentificadorCor)
        {
            if (string.IsNullOrEmpty(IdentificadorCor))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.Cor objCor = null;

            objSql.AdicionarParametro("IDCOR", IdentificadorCor);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.CorRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objCor = new Comum.Clases.Cor()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDCOR"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODCOR"], typeof(Int32))),
                    CodigoRGB = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODCORRGB"], typeof(string)) as string,
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCOR"], typeof(string)) as string
                };
                 
                
            }

            return objCor;
        }

        public static void InserirCor(Comum.Clases.Cor objCor, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDCOR", Guid.NewGuid());
            objSql.AdicionarParametro("CODCORRGB", objCor.CodigoRGB);
            objSql.AdicionarParametro("DESCOR", objCor.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.CorInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean CorEstaSendoUsuada(string IdentificadorCor)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDCOR", IdentificadorCor);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.CorVerificarEstaSendoUsuada, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static void DeletarCor(string IdentificadorCor)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDCOR", IdentificadorCor);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.CorDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarCor(Comum.Clases.Cor objCor)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDCOR", objCor.Identificador);
            objSql.AdicionarParametro("CODCORRGB", objCor.CodigoRGB);
            objSql.AdicionarParametro("DESCOR", objCor.Descricao.ToUpper());

            objSql.ExecutarNonQueryArquivo(Properties.Resources.CorAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }
    }
}
