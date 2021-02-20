using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmCripto = AmgSistemas.Framework.Criptografia;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes.Servico
{
    public class ValidarChave
    {

        public static Boolean ValidarChaveSistema(Int32 CodigoEmpresa, string Chave)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("CODEMPRESA", CodigoEmpresa);
            objSql.AdicionarParametro("CHAVEATIVA", false);
            objSql.AdicionarParametro("CODLICENCA", Chave);

            object Valor = objSql.ExecutarScalarArquivo(Properties.Resources.ChaveValidar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (Valor != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static Boolean ValidarChaveExiste(string Chave)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("CODLICENCA", Chave);

            object Valor = objSql.ExecutarScalarArquivo(Properties.Resources.ChaveValidarExiste, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (Valor != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void GerarChave(string Chave, Boolean SessoesInfinita, Int32 QuantidadeSessoes, Int32 NumValidade,
                                      Boolean ValidadeInfinita, Int32 NumQuantidadeAcessos)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDLICENCA", Guid.NewGuid());
            objSql.AdicionarParametro("CODLICENCA", Chave);
            objSql.AdicionarParametro("SESSOESINFINITAS", SessoesInfinita);
            objSql.AdicionarParametro("NUMQUANTIDADESESSOES", QuantidadeSessoes);
            objSql.AdicionarParametro("NUMVALIDADE", NumValidade);
            objSql.AdicionarParametro("VALIDADEINFINITA", ValidadeInfinita);
            objSql.AdicionarParametro("CHAVEATIVA", true);
            objSql.AdicionarParametro("NUMQUANTIDADEACESSOS", NumQuantidadeAcessos);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.ChaveGerar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static string RecuperarIdentificadorChave(string Chave, Boolean Criptografar, Boolean ChaveAtiva)
        {

            string ChaveCriptografada = Chave;

            if (Criptografar)
            {
                ChaveCriptografada = frmCripto.Criptografar.EncryptString128Bit(Chave, Comum.Clases.Constantes.CHAVE_CRIPITOGRAFIA);
            }

            Sql objSql = new Sql();

            objSql.AdicionarParametro("CODLICENCA", ChaveCriptografada);
            objSql.AdicionarParametro("CHAVEATIVA", ChaveAtiva);

            object objIdentficador = objSql.ExecutarScalarArquivo(Properties.Resources.ChaveRecuperarIdentificador, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            string IdentificadorChave = string.Empty;

            if (objIdentficador != null)
            {
                IdentificadorChave = objIdentficador as string;
            }
            return IdentificadorChave;
        }

        public static Comum.Clases.Chave RecuperarChave(string Identificador)
        {

            Comum.Clases.Chave objChave = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDLICENCA", Identificador);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ChaveRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                objChave = new Comum.Clases.Chave()
                {
                    ChaveAcesso = frmCripto.Criptografar.DecryptString128Bit(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLICENCA"], typeof(string)) as string, Comum.Clases.Constantes.CHAVE_CRIPITOGRAFIA),
                    ChaveAcessoCriptografada = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLICENCA"], typeof(string)) as string,
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDLICENCA"], typeof(string)) as string,
                    QuantidadeAcessos = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMQUANTIDADEACESSOS"], typeof(Int32))),
                    QuantidadeSessoes = (Nullable<Int32>)(frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADESESSOES"], typeof(Int32), true)),
                    SessoesInfinitas = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["SESSOESINFINITAS"], typeof(Boolean))),
                    Validade = (Nullable<Int32>)(frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMVALIDADE"], typeof(Int32), true)),
                    ValidadeInfinita = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["VALIDADEINFINITA"], typeof(Boolean))),
                    DataAtivacao = (Nullable<DateTime>)(frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["DATAATIVACAO"], typeof(DateTime), true))
                };

            }

            return objChave;
        }

        public static List<Comum.Clases.Chave> RecuperarChaves()
        {

            List<Comum.Clases.Chave> objChaves = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("CHAVEATIVA", true);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.ChavesRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objChaves = new List<Comum.Clases.Chave>();

                foreach (DataRow dr in dt.Rows)
                {
                    objChaves.Add(new Comum.Clases.Chave()
                    {
                        ChaveAcesso = frmCripto.Criptografar.DecryptString128Bit(frmUtil.Util.AtribuirValorObj(dr["CODLICENCA"], typeof(string)) as string, Comum.Clases.Constantes.CHAVE_CRIPITOGRAFIA),
                        ChaveAcessoCriptografada = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLICENCA"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDLICENCA"], typeof(string)) as string,
                        QuantidadeAcessos = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMQUANTIDADEACESSOS"], typeof(Int32))),
                        QuantidadeSessoes = (Nullable<Int32>)(frmUtil.Util.AtribuirValorObj2(dr["NUMQUANTIDADESESSOES"], typeof(Int32), true)),
                        SessoesInfinitas = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["SESSOESINFINITAS"], typeof(Boolean))),
                        Validade = (Nullable<Int32>)(frmUtil.Util.AtribuirValorObj2(dr["NUMVALIDADE"], typeof(Int32), true)),
                        ValidadeInfinita = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["VALIDADEINFINITA"], typeof(Boolean)))
                    });
                }

            }

            return objChaves;
        }


        public static void EmpresaAtualizarChave(string IdentificadorChave, Int32 CodigoEmpresa, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDLICENCA", IdentificadorChave, true);
            objSql.AdicionarParametro("CODEMPRESA", CodigoEmpresa);

            objSql.AdicionarTransacao(Properties.Resources.EmpresaAtualizarChave);

        }

        public static void ChaveAtualizar(string IdentificadorChave, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDLICENCA", IdentificadorChave, true);
            objSql.AdicionarParametro("CHAVEATIVA", false);
            objSql.AdicionarParametro("DATAATIVACAO", DateTime.Now);

            objSql.AdicionarTransacao(Properties.Resources.ChaveAtualizar);
        }
    }
}
