using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class GrupoCompromisso
    {

        public static List<Comum.Clases.GrupoCompromisso> PesquisarGrupoCompromisso(string Descricao, string IdentificadorEmpresa, string IdentificadorGrupoCompromisso,
                                                                                    Boolean Ordenar, Boolean RecuperarSubGrupos, Boolean RecuperarPerguntas)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.GrupoCompromisso> objGruposCompromissos = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objSql.AdicionarParametro("DESGRUPOCOMPROMISSO", "%" + Descricao.ToUpper() + "%");
            }
            else
            {
                objSql.AdicionarParametro("DESGRUPOCOMPROMISSO", DBNull.Value);
            }

            if(!string.IsNullOrEmpty(IdentificadorGrupoCompromisso))
            {
                objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);
            }
            else
            {
                objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", DBNull.Value);
            }
            
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("ORDENAR", Ordenar);
            objSql.AdicionarParametro("RECUPERARSUBGRUPO", RecuperarSubGrupos);
            objSql.AdicionarParametro("RECUPERARPERGUNTAS", RecuperarPerguntas);

            List<string> objNomesTabelas = new List<string>();

            objNomesTabelas.Add("GRUPOCOMPROMISSO");

            if (RecuperarPerguntas)
            {
                objNomesTabelas.Add("PERGUNTAS");
                objNomesTabelas.Add("PERGUNTASOPCOES");
            }
     

            List<DataTable> dts = objSql.ExecutarDataTablesArquivo("SP_PESQUISAR_GRUPO_COMPROMISSO", Comum.Clases.Constantes.ARQUIVO_CONEXAO, CommandType.StoredProcedure, objNomesTabelas);
            
            DataTable dt = dts[0];
            DataTable dtPerguntas = null;
            DataTable dtPerguntasOpcoes = null;

            if(RecuperarPerguntas)
            {
                dtPerguntas = dts[1];
                dtPerguntasOpcoes = dts[2];
            }

            if (dt != null && dt.Rows.Count > 0)
            {

                objGruposCompromissos = new List<Comum.Clases.GrupoCompromisso>();

                foreach (DataRow dr in (from DataRow draux in  dt.Rows
                                        where string.IsNullOrEmpty(frmUtil.Util.AtribuirValorObj(draux["IDGRUPOCOMPROMISSO_PAI"], typeof(string)) as string) select draux))
                {
                    objGruposCompromissos.Add(new Comum.Clases.GrupoCompromisso
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODGRUPOCOMPROMISSO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESGRUPOCOMPROMISSO"], typeof(string)) as string,
                        Perguntas = (RecuperarPerguntas ?  PreencherPerguntas(dtPerguntas, dtPerguntasOpcoes, frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string): null),
                        SubGrupos = PreencherSubGrupos(dt, frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string)
                    });
                }
            }

            return objGruposCompromissos;
        }

        public static List<Comum.Clases.Pergunta> PreencherPerguntas(DataTable dt, DataTable dtPerguntaOpcao,string IdentificadorGrupoCompromisso)
        {

            List<Comum.Clases.Pergunta> objPerguntas = null;
            if (dt != null && dt.Rows.Count > 0)
            {

                objPerguntas = new List<Comum.Clases.Pergunta>();

                foreach (DataRow dr in (from DataRow drAux in dt.Rows where frmUtil.Util.AtribuirValorObj(drAux["IDGRUPOCOMPROMISSO"], typeof(string)) as string == IdentificadorGrupoCompromisso select drAux))
                {
                    objPerguntas.Add(new Comum.Clases.Pergunta
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTA"], typeof(string)) as string,
                        DesPergunta = frmUtil.Util.AtribuirValorObj(dr["DESPERGUNTA"], typeof(string)) as string,
                        Numerico = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLNUMERICO"], typeof(Boolean))),
                        Obrigatoria = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLOBRIGATORIA"], typeof(Boolean))),
                        Opcoes = PreencherPerguntaOpcoes(dtPerguntaOpcao, frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTA"], typeof(string)) as string),
                        TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)(frmUtil.Util.AtribuirValorObj(Convert.ToInt32(dr["CODTIPOCOMPONENTE"]), typeof(Int32)))
                    });
                }
            }

            return objPerguntas;
        }

        public static List<Comum.Clases.PerguntaOpcao> PreencherPerguntaOpcoes(DataTable dt,string IdentifiadorPergunta)
        {

            List<Comum.Clases.PerguntaOpcao> objPerguntaOpcoes = null;

           if (dt != null && dt.Rows.Count > 0)
            {

                objPerguntaOpcoes = new List<Comum.Clases.PerguntaOpcao>();

                foreach (DataRow dr in (from DataRow drAux in  dt.Rows where frmUtil.Util.AtribuirValorObj(drAux["IDPERGUNTA"], typeof(string)) as string == IdentifiadorPergunta select drAux))
                {
                    objPerguntaOpcoes.Add(new Comum.Clases.PerguntaOpcao
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTAOPCAO"], typeof(string)) as string,
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPERGUNTAOPCAO"], typeof(string)) as string
                    });
                }
            }

            return objPerguntaOpcoes;
        }

        private static List<Comum.Clases.GrupoCompromisso> PreencherSubGrupos(DataTable dt, string IdentificadorGrupoPai)
        {
            List<Comum.Clases.GrupoCompromisso> objSubGrupos = null;

            if (dt != null && dt.Rows.Count > 0)
            {
                objSubGrupos = new List<Comum.Clases.GrupoCompromisso>();

                foreach(DataRow dr in (from DataRow draux in dt.Rows
                                       where frmUtil.Util.AtribuirValorObj(draux["IDGRUPOCOMPROMISSO_PAI"], typeof(string)) as string == IdentificadorGrupoPai
                                       select draux))
                {
                    objSubGrupos.Add(new Comum.Clases.GrupoCompromisso
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODGRUPOCOMPROMISSO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESGRUPOCOMPROMISSO"], typeof(string)) as string,
                        SubGrupos = PreencherSubGrupos(dt, frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string)
                    });
                }

            }

            return objSubGrupos;
        }

        public static string InserirGrupoCompromisso(Comum.Clases.GrupoCompromisso objGrupo, string IdentificadorEmpresa, ref Sql objSql)
        {

            string IdentificadorGrupo = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupo);
            objSql.AdicionarParametro("DESGRUPOCOMPROMISSO", objGrupo.Descricao.ToUpper());
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoInserir);

            return IdentificadorGrupo;
        }

        public static void AtualizarGrupoCompromisso(Comum.Clases.GrupoCompromisso objGrupo, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", objGrupo.Identificador);
            objSql.AdicionarParametro("DESGRUPOCOMPROMISSO", objGrupo.Descricao.ToUpper());

            objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoAtualizar);

        }

        public static void DeletarGrupoCompromisso(string IdentificadorGrupoCompromisso, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);

            objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoDeletar);
        }

        public static void DeletarGrupoCompromissoComTransacao(string IdentificadorGrupoCompromisso, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);

            objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoDeletar);

        }

        public static List<string> RecuperarIdentificadoresRelacionamento(string IdentificadorGrupo)
        {

            Sql objSql = new Sql();
            List<string> objIdentificadores = null;

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSOPAI", IdentificadorGrupo);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoCompromissoSubGrupoRecuperarIdentificadores, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                objIdentificadores = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    objIdentificadores.Add(frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSOSUBGRUPO"], typeof(string)) as string);
                }
            }

            return objIdentificadores;
        }

        public static void DeletarGrupoCompromissoSubGrupoComIdentificadorRegistro(List<string> IdentificadoresRelacionamento, ref Sql objSql)
        {

            if (IdentificadoresRelacionamento != null && IdentificadoresRelacionamento.Count > 0)
            {
                string Query = Util.MontarClausulaIn(IdentificadoresRelacionamento, "IDGRUPOCOMPROMISSOSUBGRUPO", ref objSql, false, "WHERE");
                objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoSubGrupoDeletarRelacionamento + Query);
            }
        }

        public static void DeletarGrupoCompromissoSubGrupo(string IdentificadorGrupoCompromisso, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSOPAI", IdentificadorGrupoCompromisso);

            objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoSubGrupoDeletar);
        }

        public static void DeletarGrupoCompromissoSubGrupoComIdentificadorGrupo(string IdentificadorGrupoCompromisso, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);

            objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoDeletarGrupoSubGrupoComIdentificador);
        }

        public static void InserirGrupoCompromissoSubGrupo(string IdentificadorGrupoCompromissoPai, string IdentificadorGrupoCompromisso, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSOSUBGRUPO", Guid.NewGuid());
            objSql.AdicionarParametro("IDGRUPOCOMPROMISSOPAI", IdentificadorGrupoCompromissoPai);
            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);

            objSql.AdicionarTransacao(Properties.Resources.GrupoCompromissoSubGrupoInserir);
        }

        public static Boolean GrupoCompromissoEstaSendoUsuado(string IdentificadorGrupoCompromisso)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoCompromissoEstaSendoUsado, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {

                List<string> IdentificadoresSubGrupos = RecuperarIdentificadorSubGrupo(IdentificadorGrupoCompromisso);

                if (IdentificadoresSubGrupos != null && IdentificadoresSubGrupos.Count > 0)
                {

                    foreach (string item in IdentificadoresSubGrupos)
                    {

                        if (GrupoCompromissoEstaSendoUsuado(item))
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

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSOPAI", IdentificadorGrupo);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoCompromissoRecuperarSubGrupo, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                IdentificadoresSubGrupo = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    IdentificadoresSubGrupo.Add(frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string);
                }
            }

            return IdentificadoresSubGrupo;
        }

        public static Comum.Clases.GrupoCompromisso RecuperarGrupoCompromisso(string IdentificadorGrupoCompromisso)
        {
            if (string.IsNullOrEmpty(IdentificadorGrupoCompromisso))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.GrupoCompromisso objGrupoCompromisso = null;

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoCompromissoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                string IdentificadorSubGrupo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOCOMPROMISSOFILHO"], typeof(string)) as string;

                objGrupoCompromisso = new Comum.Clases.GrupoCompromisso()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOCOMPROMISSO"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODGRUPOCOMPROMISSO"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESGRUPOCOMPROMISSO"], typeof(string)) as string,
                    Perguntas = Pergunta.RecuperarPerguntas(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDGRUPOCOMPROMISSO"], typeof(string)) as string)
                };

                if (!string.IsNullOrEmpty(IdentificadorSubGrupo))
                {
                    objGrupoCompromisso.SubGrupos = new List<Comum.Clases.GrupoCompromisso>();
                    Comum.Clases.GrupoCompromisso objSubGrupo = null;

                    foreach (DataRow dr in dt.Rows)
                    {

                        IdentificadorSubGrupo = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSOFILHO"], typeof(string)) as string;
                        objSubGrupo = RecuperarGrupoCompromisso(IdentificadorSubGrupo);

                        if (objSubGrupo != null)
                        {
                            objGrupoCompromisso.SubGrupos.Add(objSubGrupo);
                        }
                    }

                    
                }

            }

            return objGrupoCompromisso;
        }

        public static List<Comum.Clases.GrupoCompromisso> RecuperarGruposCompromisso(List<string> IdentificadoresGruposCompromisso)
        {
            if (IdentificadoresGruposCompromisso == null || IdentificadoresGruposCompromisso.Count == 0)
            {
                return null;
            }

            Sql objSql = new Sql();
            List<Comum.Clases.GrupoCompromisso> objGruposCompromisso = null;
            Comum.Clases.GrupoCompromisso objGrupoCompromisso = null;

            string objQuery = string.Empty;

            ParametroColecao objParametros = null;

            objQuery += frmUtil.Util.MontarClausulaIn(IdentificadoresGruposCompromisso, "IDGRUPOCOMPROMISSO", ref objParametros, "WHERE", "GC");

            if (objParametros != null && objParametros.Count > 0)
            {
                foreach (AmgSistemas.Framework.AcessoDados.Parametro objParametro in objParametros)
                {
                    objSql.AdicionarParametro(objParametro.Campo, objParametro.Valor);
                }
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.GrupoCompromissoRecuperarGrupos + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                objGruposCompromisso = new List<Comum.Clases.GrupoCompromisso>();

                foreach (DataRow dr in dt.Rows)
                {
                    string IdentificadorSubGrupo = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSOFILHO"], typeof(string)) as string;

                    objGrupoCompromisso = new Comum.Clases.GrupoCompromisso()
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODGRUPOCOMPROMISSO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESGRUPOCOMPROMISSO"], typeof(string)) as string,
                        Perguntas = Pergunta.RecuperarPerguntas(frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string)
                    };

                    List<string> objIdentificadoresSubGrupos = (from DataRow drs1 in dt.Rows 
                                                                where drs1["IDGRUPOCOMPROMISSO"] == frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string &&
                                                                !string.IsNullOrEmpty(frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSOFILHO"], typeof(string)) as string)
                                                                select drs1["IDGRUPOCOMPROMISSOFILHO"] as string).ToList();

                    if (objIdentificadoresSubGrupos != null && objIdentificadoresSubGrupos.Count > 0)
                    {

                        objGrupoCompromisso.SubGrupos = RecuperarGruposCompromisso(objIdentificadoresSubGrupos);
                        
                        if (objGrupoCompromisso.SubGrupos != null && objGrupoCompromisso.SubGrupos.Count > 0)
                        {

                            List<Comum.Clases.GrupoCompromisso> objGrupos = (List<Comum.Clases.GrupoCompromisso>)(frmUtil.Util.ClonarObjeto(objGrupoCompromisso.SubGrupos));

                            objGrupoCompromisso.SubGrupos.Clear();

                            objGrupoCompromisso.SubGrupos.AddRange(objGrupos.OrderBy(g => g.Descricao));

                        }

                    }

                    objGruposCompromisso.Add(objGrupoCompromisso);
                }

            }

            return objGruposCompromisso;
        }

    }
}
