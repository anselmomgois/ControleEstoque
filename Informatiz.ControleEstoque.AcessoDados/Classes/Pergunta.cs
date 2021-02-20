using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Pergunta
    {

        public static string InserirPergunta(Comum.Clases.Pergunta objPergunta, string IdentificadorGrupo, ref Sql objSql)
        {

            string IdentificadorPergunta = Guid.NewGuid().ToString();

            objSql.AdicionarParametro("IDPERGUNTA", IdentificadorPergunta);
            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupo);
            objSql.AdicionarParametro("DESPERGUNTA", objPergunta.DesPergunta.ToUpper());
            objSql.AdicionarParametro("BOLOBRIGATORIA", objPergunta.Obrigatoria);
            objSql.AdicionarParametro("CODTIPOCOMPONENTE", objPergunta.TipoComponente.GetHashCode().ToString());
            objSql.AdicionarParametro("BOLNUMERICO", objPergunta.Obrigatoria);

            objSql.AdicionarTransacao(Properties.Resources.PerguntaInserir);

            return IdentificadorPergunta;
        }

        public static void InserirResposta(Comum.Clases.Pergunta objPergunta, string IdentificadorPessoaCrm, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDRESPOSTAPERGUNTA", Guid.NewGuid().ToString());
            objSql.AdicionarParametro("IDPERGUNTA", objPergunta.Identificador);
            objSql.AdicionarParametro("IDPESSOACRM", IdentificadorPessoaCrm);
            objSql.AdicionarParametro("DESVALOR", objPergunta.Resposta);

            objSql.AdicionarTransacao(Properties.Resources.PerguntaInserirResposta);
        }

        public static void DeletarResposta(string IdentificadorCrm, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDCRM", IdentificadorCrm);
            
            objSql.AdicionarTransacao(Properties.Resources.PerguntaDeletarResposta);
        }

        public static void InserirPerguntaOpcao(Comum.Clases.PerguntaOpcao objPerguntaOpcao, string IdentificadorPergunta, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPERGUNTAOPCAO", Guid.NewGuid());
            objSql.AdicionarParametro("IDPERGUNTA", IdentificadorPergunta);
            objSql.AdicionarParametro("DESPERGUNTAOPCAO", objPerguntaOpcao.Descricao.ToUpper());

            objSql.AdicionarTransacao(Properties.Resources.PerguntaOpcaoInserir);
        }

        public static void DeletarPerguntaOpcao(string IdentificadorPergunta, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPERGUNTA", IdentificadorPergunta);
           
            objSql.AdicionarTransacao(Properties.Resources.PerguntaOpcaoDeletar);
        }

        public static void AtualizarPergunta(Comum.Clases.Pergunta objPergunta, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPERGUNTA", objPergunta.Identificador);
            objSql.AdicionarParametro("DESPERGUNTA", objPergunta.DesPergunta.ToUpper());
            objSql.AdicionarParametro("BOLOBRIGATORIA", objPergunta.Obrigatoria);
            objSql.AdicionarParametro("CODTIPOCOMPONENTE", objPergunta.TipoComponente.GetHashCode().ToString());
            objSql.AdicionarParametro("BOLNUMERICO", objPergunta.Obrigatoria);

            objSql.AdicionarTransacao(Properties.Resources.PerguntaAtualizar);
        }

        public static void PerguntaDeletar(string Identificador, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPERGUNTA", Identificador);


            objSql.AdicionarTransacao(Properties.Resources.PerguntaDeletar);
        }

        public static Boolean PerguntaExiste(string Pergunta)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("DESPERGUNTA", Pergunta);

            object objResult = objSql.ExecutarScalarArquivo(Properties.Resources.PerguntaExiste, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (objResult == DBNull.Value || objResult == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public static Boolean PerguntaEstaSendoUsada(string Identificador)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPERGUNTA", Identificador);

            object objResult = objSql.ExecutarScalarArquivo(Properties.Resources.PerguntaEstaSendoUsada, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (objResult == DBNull.Value || objResult == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static List<Comum.Clases.Pergunta> RecuperarPerguntas(string IdentificadorGrupoCompromisso)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.Pergunta> objPerguntas = null;

            objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", IdentificadorGrupoCompromisso);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PerguntaRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objPerguntas = new List<Comum.Clases.Pergunta>();

                foreach (DataRow dr in dt.Rows)
                {
                    objPerguntas.Add(new Comum.Clases.Pergunta
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTA"], typeof(string)) as string,
                        DesPergunta = frmUtil.Util.AtribuirValorObj(dr["DESPERGUNTA"], typeof(string)) as string,
                        Numerico = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLNUMERICO"], typeof(Boolean))),
                        Obrigatoria = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLOBRIGATORIA"], typeof(Boolean))),
                        Opcoes = RecuperarPerguntaOpcoes(frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTA"], typeof(string)) as string),
                        TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)(frmUtil.Util.AtribuirValorObj(Convert.ToInt32(dr["CODTIPOCOMPONENTE"]), typeof(Int32)))
                    });
                }
            }

            return objPerguntas;
        }

        public static List<Comum.Clases.Pergunta> RecuperarPerguntasComResposta(string IdentificadorPessoaAgendamento)
        {

            if (string.IsNullOrEmpty(IdentificadorPessoaAgendamento))
            {
                return null;
            }

            Sql objSql = new Sql();
            List<Comum.Clases.Pergunta> objPerguntas = null;

            objSql.AdicionarParametro("IDPESSOACRM", IdentificadorPessoaAgendamento);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PerguntaReguperarRespostas, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objPerguntas = new List<Comum.Clases.Pergunta>();

                foreach (DataRow dr in dt.Rows)
                {
                    objPerguntas.Add(new Comum.Clases.Pergunta
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTA"], typeof(string)) as string,
                        DesPergunta = frmUtil.Util.AtribuirValorObj(dr["DESPERGUNTA"], typeof(string)) as string,
                        Numerico = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLNUMERICO"], typeof(Boolean))),
                        Obrigatoria = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLOBRIGATORIA"], typeof(Boolean))),
                        Opcoes = RecuperarPerguntaOpcoes(frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTA"], typeof(string)) as string),
                        Resposta = frmUtil.Util.AtribuirValorObj(dr["DESVALOR"], typeof(string)) as string,
                        TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)(frmUtil.Util.AtribuirValorObj(Convert.ToInt32(dr["CODTIPOCOMPONENTE"]), typeof(Int32)))
                    });
                }
            }

            return objPerguntas;
        }

        public static List<Comum.Clases.PerguntaOpcao> RecuperarPerguntaOpcoes(string IdentifiadorPergunta)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.PerguntaOpcao> objPerguntaOpcoes = null;

            objSql.AdicionarParametro("IDPERGUNTA", IdentifiadorPergunta);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PerguntaOpcaoRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objPerguntaOpcoes = new List<Comum.Clases.PerguntaOpcao>();

                foreach (DataRow dr in dt.Rows)
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
    }
}
