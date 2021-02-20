using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
   public class Administradora
    {

       public static List<Comum.Clases.Administradora> RecuperarAdministradoras(string Descricao, string IdentificadorEmpresa)
       {

           Sql objSql = new Sql();
           List<Comum.Clases.Administradora> objAdministradoras = null;
           string objQuery = string.Empty;

           if (!string.IsNullOrEmpty(Descricao))
           {
               objQuery = " AND DESADMINISTRADORA LIKE @DESADMINISTRADORA ";
               objSql.AdicionarParametro("DESTIPOPRODUTO", "%" + Descricao.ToUpper() + "%");
           }

           objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

           DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.AdministradoraPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           if (dt != null && dt.Rows.Count > 0)
           {

               objAdministradoras = new List<Comum.Clases.Administradora>();

               foreach (DataRow dr in dt.Rows)
               {
                   objAdministradoras.Add(new Comum.Clases.Administradora
                   {
                       Identificador = frmUtil.Util.AtribuirValorObj(dr["IDADMINISTRADORA"], typeof(string)) as string,
                       Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODADMINISTRADORA"], typeof(Int32))),
                       Descricao = frmUtil.Util.AtribuirValorObj(dr["DESADMINISTRADORA"], typeof(string)) as string,
                       DescricaoTela = frmUtil.Util.AtribuirValorObj(dr["DESTELADMINISTRADORA"], typeof(string)) as string,
                       Observacao = frmUtil.Util.AtribuirValorObj(dr["OBSREFADMINISTRADORA"], typeof(string)) as string,
                       PercentualDesconto = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMDESCONTPERCENT"], typeof(decimal))),
                       PercentualTarifa = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMTARIFAPERCENT"], typeof(decimal))),
                       PercentualTarifaAntecipada = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMTARIFAANTPERCENT"], typeof(decimal))),
                       ValorDesconto = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMDESCONTVALOR"], typeof(decimal))),
                       ValorTarifa = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMTARIFAVALOR"], typeof(decimal))),
                       ValorTarifaAntecipada = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMTARIFAANTVALOR"], typeof(decimal))),
                       ImgAdministradora = (byte[])(frmUtil.Util.AtribuirValorObj(dr["BITIMGADMINISTRADORA"], typeof(byte[])))
                   });
               }
           }

           return objAdministradoras;
       }

       public static void InserirAdministradora(Comum.Clases.Administradora objAdministradora, string IdentificadorEmpresa)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDADMINISTRADORA", Guid.NewGuid());
           objSql.AdicionarParametro("DESADMINISTRADORA", objAdministradora.Descricao.ToUpper());
           objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
           objSql.AdicionarParametro("DESTELADMINISTRADORA", frmUtil.Util.RetornaDbNull(objAdministradora.DescricaoTela,true));
           objSql.AdicionarParametro("OBSREFADMINISTRADORA", frmUtil.Util.RetornaDbNull(objAdministradora.Observacao, true));
           objSql.AdicionarParametro("NUMTARIFAPERCENT", frmUtil.Util.RetornaDbNull(objAdministradora.PercentualTarifa));
           objSql.AdicionarParametro("NUMTARIFAVALOR", frmUtil.Util.RetornaDbNull(objAdministradora.ValorTarifa));
           objSql.AdicionarParametro("NUMTARIFAANTPERCENT", frmUtil.Util.RetornaDbNull(objAdministradora.PercentualTarifaAntecipada));
           objSql.AdicionarParametro("NUMTARIFAANTVALOR", frmUtil.Util.RetornaDbNull(objAdministradora.ValorTarifaAntecipada));
           objSql.AdicionarParametro("NUMDESCONTPERCENT", frmUtil.Util.RetornaDbNull(objAdministradora.PercentualDesconto));
           objSql.AdicionarParametro("NUMDESCONTVALOR", frmUtil.Util.RetornaDbNull(objAdministradora.ValorDesconto));
           objSql.AdicionarParametro("BITIMGADMINISTRADORA", frmUtil.Util.RetornaDbNull(objAdministradora.ImgAdministradora));
           
           objSql.ExecutarNonQueryArquivo(Properties.Resources.AdministradoraInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
       }

       public static void AtualizarAdministradora(Comum.Clases.Administradora objAdministradora)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDADMINISTRADORA", objAdministradora.Identificador);
           objSql.AdicionarParametro("DESADMINISTRADORA", objAdministradora.Descricao.ToUpper());
           objSql.AdicionarParametro("DESTELADMINISTRADORA", frmUtil.Util.RetornaDbNull(objAdministradora.DescricaoTela,true));
           objSql.AdicionarParametro("OBSREFADMINISTRADORA", frmUtil.Util.RetornaDbNull(objAdministradora.Observacao, true));
           objSql.AdicionarParametro("NUMTARIFAPERCENT", frmUtil.Util.RetornaDbNull(objAdministradora.PercentualTarifa));
           objSql.AdicionarParametro("NUMTARIFAVALOR", frmUtil.Util.RetornaDbNull(objAdministradora.ValorTarifa));
           objSql.AdicionarParametro("NUMTARIFAANTPERCENT", frmUtil.Util.RetornaDbNull(objAdministradora.PercentualTarifaAntecipada));
           objSql.AdicionarParametro("NUMTARIFAANTVALOR", frmUtil.Util.RetornaDbNull(objAdministradora.ValorTarifaAntecipada));
           objSql.AdicionarParametro("NUMDESCONTPERCENT", frmUtil.Util.RetornaDbNull(objAdministradora.PercentualDesconto));
           objSql.AdicionarParametro("NUMDESCONTVALOR", frmUtil.Util.RetornaDbNull(objAdministradora.ValorDesconto));
           objSql.AdicionarParametro("BITIMGADMINISTRADORA", frmUtil.Util.RetornaDbNull(objAdministradora.ImgAdministradora));

           objSql.ExecutarNonQueryArquivo(Properties.Resources.AdministradoraAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
       }

       public static void DeletarAdministradora(string IdentificadorAdministradora)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDADMINISTRADORA", IdentificadorAdministradora);

           objSql.ExecutarNonQueryArquivo(Properties.Resources.AdministradoraDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
       }

       public static Boolean AdministradoraEstaSendoUsuada(string IdentificadorAdministradora)
       {

           Sql objSql = new Sql();

           objSql.AdicionarParametro("IDADMINISTRADORA", IdentificadorAdministradora);

           return (Boolean)((objSql.ExecutarScalarArquivo(Properties.Resources.AdministradoraVerificarEstaSendoUsada, Comum.Clases.Constantes.ARQUIVO_CONEXAO) == DBNull.Value ? true : false));
       }

       public static Comum.Clases.Administradora RecuperarAdministradora(string IdentificadorAdministradora)
       {

           if (string.IsNullOrEmpty(IdentificadorAdministradora))
           {
               return null;
           }

           Sql objSql = new Sql();
           Comum.Clases.Administradora objAdministradora = null;

           objSql.AdicionarParametro("IDADMINISTRADORA", IdentificadorAdministradora);

           DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.AdministradoraRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

           if (dt != null && dt.Rows.Count > 0)
           {

               objAdministradora = new Comum.Clases.Administradora()
               {
                   Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDADMINISTRADORA"], typeof(string)) as string,
                   Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODADMINISTRADORA"], typeof(Int32))),
                   Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESADMINISTRADORA"], typeof(string)) as string,
                   DescricaoTela = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTELADMINISTRADORA"], typeof(string)) as string,
                   Observacao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["OBSREFADMINISTRADORA"], typeof(string)) as string,
                   PercentualDesconto = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMDESCONTPERCENT"], typeof(decimal))),
                   PercentualTarifa = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMTARIFAPERCENT"], typeof(decimal))),
                   PercentualTarifaAntecipada = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMTARIFAANTPERCENT"], typeof(decimal))),
                   ValorDesconto = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMDESCONTVALOR"], typeof(decimal))),
                   ValorTarifa = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMTARIFAVALOR"], typeof(decimal))),
                   ValorTarifaAntecipada = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMTARIFAANTVALOR"], typeof(decimal))),
                   ImgAdministradora = (byte[])(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BITIMGADMINISTRADORA"], typeof(byte[])))
               };


           }

           return objAdministradora;
       }
    }
}
