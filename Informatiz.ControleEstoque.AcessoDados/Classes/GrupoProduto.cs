using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class GrupoProduto
    {

        public static List<Comum.Clases.GrupoProduto> PesquisarGrupoProduto(string Descricao, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.GrupoProduto> objGruposProdutos = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESGRUPOPRODUTO LIKE @DESGRUPOPRODUTO ";
                objSql.AdicionarParametro("DESGRUPOPRODUTO", "%" + Descricao.ToUpper() + "%");
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoProdutoPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objGruposProdutos = new List<Comum.Clases.GrupoProduto>();

                foreach (DataRow dr in dt.Rows)
                {
                    objGruposProdutos.Add(new Comum.Clases.GrupoProduto
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOPRODUTO"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODGRUPOPRODUTO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESGRUPOPRODUTO"], typeof(string)) as string
                    });
                }
            }

            return objGruposProdutos;
        }

        public static string InserirGrupoProduto(Comum.Clases.GrupoProduto objGrupo, string IdentificadorEmpresa, ref Sql objSql)
        {

            string IdentificadorGrupo = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDGRUPOPRODUTO", IdentificadorGrupo);
            objSql.AdicionarParametro("DESGRUPOPRODUTO", objGrupo.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            objSql.AdicionarTransacao(Properties.Resources.GrupoProdutoInserir);

            return IdentificadorGrupo;
        }

        public static void AtualizarGrupoProduto(Comum.Clases.GrupoProduto objGrupo, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOPRODUTO", objGrupo.Identificador);
            objSql.AdicionarParametro("DESGRUPOPRODUTO", objGrupo.Descricao.ToUpper());

            objSql.AdicionarTransacao(Properties.Resources.GrupoProdutoAtualizar);
            
        }

        public static void DeletarGrupoProduto(string IdentificadorGrupoProduto)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDGRUPOPRODUTO", IdentificadorGrupoProduto);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.GrupoProdutoDeletar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarGrupoProdutoComTransacao(string IdentificadorGrupoProduto, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOPRODUTO", IdentificadorGrupoProduto);

            objSql.AdicionarTransacao(Properties.Resources.GrupoProdutoDeletar);

        }

        public static List<string> RecuperarIdentificadoresRelacionamento(string IdentificadorGrupo)
        {

            Sql objSql = new Sql();
            List<string> objIdentificadores = null;

            objSql.AdicionarParametro("IDGRUPOPRODUTOPAI", IdentificadorGrupo);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoProdutoSubGrupoRecuperarIdentificadores, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                objIdentificadores = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    objIdentificadores.Add(frmUtil.Util.AtribuirValorObj(dr["IDGRUPOPRODUTOSUBGRUPO"], typeof(string)) as string);
                }
            }
            
            return objIdentificadores;
        }

        public static void DeletarGrupoProdutoSubGrupoComIdentificadorRegistro(List<string> IdentificadoresRelacionamento, ref Sql objSql)
        {

            if(IdentificadoresRelacionamento != null && IdentificadoresRelacionamento.Count > 0)
            {
            string Query = Util.MontarClausulaIn(IdentificadoresRelacionamento,"IDGRUPOPRODUTOSUBGRUPO", ref objSql,false,"WHERE");
            objSql.AdicionarTransacao(Properties.Resources.GrupoProdutoSubGrupoDeletarRelacionamento + Query);
            }
        }

        public static void DeletarGrupoProdutoSubGrupo(string IdentificadorGrupoProduto, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOPRODUTOPAI", IdentificadorGrupoProduto);

            objSql.AdicionarTransacao(Properties.Resources.GrupoProdutoSubGrupoDeletar);
        }

        public static void InserirGrupoProdutoSubGrupo(string IdentificadorGrupoProdutoPai, string IdentificadorGrupoProduto, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOPRODUTOSUBGRUPO", Guid.NewGuid());
            objSql.AdicionarParametro("IDGRUPOPRODUTOPAI", IdentificadorGrupoProdutoPai);
            objSql.AdicionarParametro("IDGRUPOPRODUTO", IdentificadorGrupoProduto);

            objSql.AdicionarTransacao(Properties.Resources.GrupoProdutoSubGrupoInserir);
        }

        public static Boolean GrupoProdutoEstaSendoUsuado(string IdentificadorGrupoProduto)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDGRUPOPRODUTO", IdentificadorGrupoProduto);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoProdutoEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {

                List<string> IdentificadoresSubGrupos = RecuperarIdentificadorSubGrupo(IdentificadorGrupoProduto);

                if (IdentificadoresSubGrupos != null && IdentificadoresSubGrupos.Count > 0)
                {

                    foreach(string item in IdentificadoresSubGrupos)
                    {

                        if (GrupoProdutoEstaSendoUsuado(item))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static List<string> RecuperarIdentificadorSubGrupo(string IdentificadorGrupo)
        {

            List<string> IdentificadoresSubGrupo = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDGRUPOPRODUTOPAI", IdentificadorGrupo);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoProdutoRecuperarSubGrupos, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                IdentificadoresSubGrupo = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    IdentificadoresSubGrupo.Add(frmUtil.Util.AtribuirValorObj(dr["IDGRUPOPRODUTO"], typeof(string)) as string);
                }
            }

            return IdentificadoresSubGrupo;
        }

        public static Comum.Clases.GrupoProduto RecuperarGrupoProduto(string IdentificadorGrupoProduto)
        {
            if (string.IsNullOrEmpty(IdentificadorGrupoProduto))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.GrupoProduto objGrupoProduto = null;

            objSql.AdicionarParametro("IDGRUPOPRODUTO", IdentificadorGrupoProduto);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoProdutoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                string IdentificadorSubGrupo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOPRODUTOFILHO"], typeof(string)) as string;

                objGrupoProduto = new Comum.Clases.GrupoProduto()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOPRODUTO"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODGRUPOPRODUTO"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESGRUPOPRODUTO"], typeof(string)) as string
                };

                if (!string.IsNullOrEmpty(IdentificadorSubGrupo))
                {
                    objGrupoProduto.SubGrupos = new List<Comum.Clases.GrupoProduto>();
                    Comum.Clases.GrupoProduto objSubGrupo = null;

                    foreach (DataRow dr in dt.Rows)
                    {

                        IdentificadorSubGrupo = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOPRODUTOFILHO"], typeof(string)) as string;
                        objSubGrupo = RecuperarGrupoProduto(IdentificadorSubGrupo);

                        if (objSubGrupo != null)
                        {
                            objGrupoProduto.SubGrupos.Add(objSubGrupo);
                        }
                    }
                }

            }

            return objGrupoProduto;
        }
    }
}
