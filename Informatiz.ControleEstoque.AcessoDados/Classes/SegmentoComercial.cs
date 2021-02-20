using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class SegmentoComercial
    {

        public static List<Comum.Clases.SegmentoComercial> RecuperarSegmentoComercial(string IdentificadorSegmento,string IdentificadorEmpresa,
                                                                                      string Descricao)
        {

            Sql objSql = new Sql();
            string objQuery = string.Empty;
            List<Comum.Clases.SegmentoComercial> Segmentos = null;

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            if (!string.IsNullOrEmpty(objQuery))
            {

                objQuery = " AND IDSEGMENTOCOMERCIAL = @IDSEGMENTOCOMERCIAL ";
                objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", IdentificadorSegmento);

            }

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESSEGMENTOCOMERCIAL LIKE @DESSEGMENTOCOMERCIAL ";
                objSql.AdicionarParametro("DESSEGMENTOCOMERCIAL", "%" + Descricao.ToUpper() + "%");
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.SegmentoComercialRecuperar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                Segmentos = new List<Comum.Clases.SegmentoComercial>();

                foreach (DataRow dr in dt.Rows)
                {

                    Segmentos.Add(new Comum.Clases.SegmentoComercial
                    {
                        Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODSEGMENTOCOMERCIAL"], typeof(int))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESSEGMENTOCOMERCIAL"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDSEGMENTOCOMERCIAL"], typeof(string)) as string
                    });

                }
            }
            return Segmentos;
        }

        public static void InserirSegmentoComercial(Comum.Clases.SegmentoComercial objSegmentoComercial, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", Guid.NewGuid());
            objSql.AdicionarParametro("DESSEGMENTOCOMERCIAL", objSegmentoComercial.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.SegmentoComercialInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void AtualizarSegmentoComercial(Comum.Clases.SegmentoComercial objSegmentoComercial)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", objSegmentoComercial.Identificador);
            objSql.AdicionarParametro("DESSEGMENTOCOMERCIAL", objSegmentoComercial.Descricao.ToUpper());

            objSql.ExecutarNonQueryArquivo(Properties.Resources.SegmentoComercialAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarSegmentoComercial(string IdentificadorSegmentoComercial)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", IdentificadorSegmentoComercial);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.SegmentoComercialDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static Boolean SegmentoComercialEstaSendoUsuado(string IdentificadorSegmentoComercial)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", IdentificadorSegmentoComercial);

            return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.SegmentoComercialEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
        }

        public static Comum.Clases.SegmentoComercial RecuperarSegmentoComercialItem(string IdentificadorSegmentoComercial)
        {

            if (string.IsNullOrEmpty(IdentificadorSegmentoComercial))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.SegmentoComercial objSegmentoComercial = null;

            objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", IdentificadorSegmentoComercial);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.SegmentoComercialRecuperarItem, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objSegmentoComercial = new Comum.Clases.SegmentoComercial()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDSEGMENTOCOMERCIAL"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODSEGMENTOCOMERCIAL"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESSEGMENTOCOMERCIAL"], typeof(string)) as string
                };


            }

            return objSegmentoComercial;
        }


    }
}
