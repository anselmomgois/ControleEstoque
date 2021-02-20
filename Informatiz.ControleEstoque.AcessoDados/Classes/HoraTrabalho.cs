using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class HoraTrabalho
    {

        public static List<Comum.Clases.HorarioTrabalho> RecuperarHoraTrabalho(string IdentificadorPessoa)
        {

            List<Comum.Clases.HorarioTrabalho> objHorasTrabalho = null;
            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);


            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.HoraTrabalhoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objHorasTrabalho = new List<Comum.Clases.HorarioTrabalho>();

                foreach (DataRow dr in dt.Rows)
                {
                    objHorasTrabalho.Add(new Comum.Clases.HorarioTrabalho
                    {
                        CodDiaSemana = (Comum.Enumeradores.Enumeradores.CodigoDiaSemana)(frmUtil.Util.AtribuirValorObj(dr["CODDIASEMANA"], typeof(int))),
                        DesHoraFim = frmUtil.Util.AtribuirValorObj(dr["DTHFIM"], typeof(string)) as string,
                        DesHoraInicio = frmUtil.Util.AtribuirValorObj(dr["DTHINICIO"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDHORATRABALHO"], typeof(string)) as string
                    });

                }
            }
            return objHorasTrabalho;
        }
        public static void InserirHoraTrabalho(Comum.Clases.HorarioTrabalho objHoraTrabalho, string IdentificadorPessoa, ref Sql ObjSql)
        {

            ObjSql.AdicionarParametro("IDHORATRABALHO", Guid.NewGuid(), true);
            ObjSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);
            ObjSql.AdicionarParametro("CODDIASEMANA", objHoraTrabalho.CodDiaSemana.GetHashCode());
            ObjSql.AdicionarParametro("DTHINICIO", frmUtil.Util.RetornaDbNull(objHoraTrabalho.DesHoraInicio));
            ObjSql.AdicionarParametro("DTHFIM", frmUtil.Util.RetornaDbNull(objHoraTrabalho.DesHoraFim));

            ObjSql.AdicionarTransacao(Properties.Resources.HoraTrabalhoInserir);
        }

        public static void DeletarHoraTrabalho(string IdentificadorPessoa, ref Sql ObjSql)
        {

            ObjSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa, true);

            ObjSql.AdicionarTransacao(Properties.Resources.HoraTrabalhoDeletar);

        }
    }
}
