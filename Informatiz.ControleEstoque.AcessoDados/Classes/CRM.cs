using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class CRM
    {

        public static List<Comum.Clases.CRM> RecuperarAgendamentos(string Descricao, string IdentificadorFuncionarioCadastro,
                                                                   List<string> IdentificadoresFuncionariosResponsaveis,
                                                                   string IdentificadorCliente,
                                                                   string IdentificadorEmpresa, Nullable<DateTime> DataInicio,
                                                                   Nullable<DateTime> DataFim, Nullable<Boolean> Ativo, Boolean ValidacoesToatis)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.CRM> objAgendamentos = null;
            string objQuery = string.Empty;

            objSql.AdicionarParametro("IDPESSOACADASTRO", RecuperarValor(IdentificadorFuncionarioCadastro));
            objSql.AdicionarParametro("IDPESSOACLIENTE", RecuperarValor(IdentificadorCliente));

            if (!string.IsNullOrEmpty(Descricao))
            {
                objSql.AdicionarParametro("DESCRM", "%" + Descricao.ToUpper() + "%");
            }
            else
            {
                objSql.AdicionarParametro("DESCRM", string.Empty);
            };

            objSql.AdicionarParametro("DTHPROXAGENDAMENTOINI", RecuperarValor(DataInicio));
            objSql.AdicionarParametro("DTHPROXAGENDAMENTOFIM", RecuperarValor(DataFim));
            objSql.AdicionarParametro("VALIDACOESTOTAIS", ValidacoesToatis);



            if (Ativo != null)
            {
                if (Ativo == true)
                {
                    objSql.AdicionarParametro("BOLATIVO", "1");
                }
                else
                {
                    objSql.AdicionarParametro("BOLATIVO", "0");
                }
            }
            else
            {
                objSql.AdicionarParametro("BOLATIVO", string.Empty);
            }

            if (IdentificadoresFuncionariosResponsaveis != null && IdentificadoresFuncionariosResponsaveis.Count > 0)
            {

                string IdentificaoresPessoas = string.Empty;

                foreach (string p in IdentificadoresFuncionariosResponsaveis)
                {

                    if (!string.IsNullOrEmpty(IdentificaoresPessoas))
                    {
                        IdentificaoresPessoas += ",";
                    }

                    IdentificaoresPessoas += p;

                }

                objSql.AdicionarParametro("IDPESSOA", IdentificaoresPessoas);

            }
            else
            {
                objSql.AdicionarParametro("IDPESSOA", string.Empty);
            }

            objSql.AdicionarParametro("IDEMPRESA", RecuperarValor(IdentificadorEmpresa));

            List<string> objNomesTabelas = new List<string>();

            objNomesTabelas.Add("CRM");
            objNomesTabelas.Add("PESSOACLIENTE");
            objNomesTabelas.Add("PESSOACADASTRO");
            objNomesTabelas.Add("GRUPOCOMPROMISSO");
            objNomesTabelas.Add("PERGUNTAS");
            objNomesTabelas.Add("PESSOACRM");

            List<DataTable> dts = objSql.ExecutarDataTablesArquivo("SP_RECUPERAR_AGENDAMENTO", Comum.Clases.Constantes.ARQUIVO_CONEXAO, CommandType.StoredProcedure, objNomesTabelas);

            DataTable dtCRM = dts[0];
            DataTable dtPessoaCliente = dts[1];
            DataTable dtPessoaCadastro = dts[2];
            DataTable dtGrupoCompromisso = dts[3];
            DataTable dtPerguntas = dts[4];
            DataTable dtPessoasCrm = dts[5];

            if (dtCRM != null && dtCRM.Rows.Count > 0)
            {

                objAgendamentos = new List<Comum.Clases.CRM>();

                Comum.Clases.CRM objAgendamento = null;
                string IdentificadorAgendamento = null;

                List<Comum.Clases.Pessoa> objListaClientes = null;
                List<Comum.Clases.Pessoa> objListaFuncionarios = null;
                List<Comum.Clases.GrupoCompromisso> objListaGrupoCompromisso = null;
                List<Comum.Clases.Pergunta> objListaPerguntas = null;
                Dictionary<string, List<Comum.Clases.Pessoa>> objListaPessasCrm = null;

                Task objTaskListaClientes = new Task(() => objListaClientes = Pessoa.PreencherPessoaSimples(dtPessoaCliente));
                Task objTaskListaFuncionarios = new Task(() => objListaFuncionarios = Pessoa.PreencherPessoaSimples(dtPessoaCadastro));
                Task objTaskListaGrupoCompromissos = new Task(() => objListaGrupoCompromisso = PreencherGrupoCompromisso(dtGrupoCompromisso));
                Task objTaskListaPerguntas = new Task(() => objListaPerguntas = PreencherPerguntas(dtPerguntas));
                Task objTaskListaPessoasCrm = new Task(() => objListaPessasCrm = PreencherPessoaAgendamento(dtPessoasCrm));

                objTaskListaClientes.Start();
                objTaskListaFuncionarios.Start();
                objTaskListaGrupoCompromissos.Start();
                objTaskListaPerguntas.Start();
                objTaskListaPessoasCrm.Start();

                Task.WaitAll(new Task[] { objTaskListaClientes, objTaskListaFuncionarios, objTaskListaGrupoCompromissos, objTaskListaPerguntas, objTaskListaPessoasCrm });

                foreach (DataRow dr in dtCRM.Rows)
                {

                    IdentificadorAgendamento = frmUtil.Util.AtribuirValorObj(dr["IDCRM"], typeof(string)) as string;
                    objAgendamento = (from Comum.Clases.CRM objAge in objAgendamentos where objAge.Identificador == IdentificadorAgendamento select objAge).FirstOrDefault();

                    if (objAgendamento == null)
                    {
                        objAgendamentos.Add(new Comum.Clases.CRM
                        {
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDCRM"], typeof(string)) as string,
                            Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODCRM"], typeof(Int32))),
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESCRM"], typeof(string)) as string,
                            Cliente = (objListaClientes != null ? (from Comum.Clases.Pessoa p in objListaClientes where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACLIENTE"], typeof(string)) as string select p).FirstOrDefault() : null),
                            FuncionarioCadastro = (objListaFuncionarios != null ? (from Comum.Clases.Pessoa p in objListaFuncionarios where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACADASTRO"], typeof(string)) as string select p).FirstOrDefault() : null),
                            Observacao = frmUtil.Util.AtribuirValorObj(dr["OBSCOMPROMISSO"], typeof(string)) as string,
                            Ativo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLATIVO"], typeof(Boolean))),
                            Atendimentos = new List<Comum.Clases.Agendamento>()

                        });

                        objAgendamento = (from Comum.Clases.CRM objAge in objAgendamentos where objAge.Identificador == IdentificadorAgendamento select objAge).FirstOrDefault();

                    }

                    KeyValuePair<string, List<Comum.Clases.Pessoa>> objPessoaAux = new KeyValuePair<string, List<Comum.Clases.Pessoa>>();

                    if (objAgendamento != null)
                    {

                        if (objListaPessasCrm != null)
                        {
                            objPessoaAux = (from KeyValuePair<string, List<Comum.Clases.Pessoa>> pcrm in objListaPessasCrm where pcrm.Key == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string select pcrm).FirstOrDefault();
                        }

                        objAgendamento.Atendimentos.Add(new Comum.Clases.Agendamento
                        {

                            FuncionariosResponsaveis = (!string.IsNullOrEmpty(objPessoaAux.Key) ? objPessoaAux.Value : null),
                            DataAtendimento = (DateTime)(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTO"], typeof(DateTime))),
                            DataAtendimentoFim = (DateTime)(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTOFIN"], typeof(DateTime))),
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESAGENDAMENTO"], typeof(string)) as string,
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string,
                            NivelAtendimento = (objListaGrupoCompromisso != null ? (from Comum.Clases.GrupoCompromisso p in objListaGrupoCompromisso where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string select p).FirstOrDefault() : null),
                            Perguntas = (objListaPerguntas != null ? (from Comum.Clases.Pergunta p in objListaPerguntas where p.IdentificadorPessoaCRM == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string select p).ToList() : null)

                        });
                    }

                }
            }

            return objAgendamentos;
        }


        public static Dictionary<string, List<Comum.Clases.Pessoa>> PreencherPessoaAgendamento(DataTable dt)
        {

            Dictionary<string, List<Comum.Clases.Pessoa>> objPessoaCrmPessoa = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                objPessoaCrmPessoa = new Dictionary<string, List<Comum.Clases.Pessoa>>();

                KeyValuePair<string, List<Comum.Clases.Pessoa>> objPessoa = new KeyValuePair<string, List<Comum.Clases.Pessoa>>();
                string IdentificadorPessoaCrm = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorPessoaCrm = frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string;
                    string IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string;

                    objPessoa = (from KeyValuePair<string, List<Comum.Clases.Pessoa>> pcrm in objPessoaCrmPessoa where pcrm.Key == IdentificadorPessoaCrm select pcrm).FirstOrDefault();

                    if (objPessoa.Key == null)
                    {
                        objPessoaCrmPessoa.Add(IdentificadorPessoaCrm, new List<Comum.Clases.Pessoa>());

                        objPessoa = (from KeyValuePair<string, List<Comum.Clases.Pessoa>> pcrm in objPessoaCrmPessoa where pcrm.Key == IdentificadorPessoaCrm select pcrm).FirstOrDefault();

                    }


                    objPessoa.Value.Add(new Comum.Clases.Pessoa
                    {
                        Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODPESSOA"], typeof(int))),
                        DesNome = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string,
                        Consultor = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLCONSULTOR"], typeof(Boolean))),
                        Identificador = IdentificadorPessoa,
                        Usuario = frmUtil.Util.AtribuirValorObj(dr["CODLOGIN"], typeof(string)) as string

                    });

                }

            }
            return objPessoaCrmPessoa;
        }

        public static List<Comum.Clases.Pergunta> PreencherPerguntas(DataTable dt)
        {
            List<Comum.Clases.Pergunta> objPerguntas = null;

            if (dt != null && dt.Rows.Count > 0)
            {
                objPerguntas = new List<Comum.Clases.Pergunta>();

                foreach (DataRow dr in dt.Rows)
                {
                    objPerguntas.Add(new Comum.Clases.Pergunta()
                    {
                        IdentificadorPessoaCRM = frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPERGUNTA"], typeof(string)) as string,
                        DesPergunta = frmUtil.Util.AtribuirValorObj(dr["DESPERGUNTA"], typeof(string)) as string,
                        Obrigatoria = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLOBRIGATORIA"], typeof(Boolean))),
                        TipoComponente = (Comum.Enumeradores.Enumeradores.TipoComponente)frmUtil.Util.AtribuirValorObj(dr["CODTIPOCOMPONENTE"], typeof(Int32)),
                        Numerico = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLNUMERICO"], typeof(Boolean))),
                        Resposta = frmUtil.Util.AtribuirValorObj(dr["DESVALOR"], typeof(string)) as string


                    });
                }
            }
            return objPerguntas;
        }

        public static string RecuperarValor(string valor)
        {
            if (!string.IsNullOrEmpty(valor)) { return valor; }

            return string.Empty;
        }

        public static Nullable<DateTime> RecuperarValor(Nullable<DateTime> valor)
        {
            if (valor != null) { return valor; }

            return DateTime.MinValue;
        }

        public static List<Comum.Clases.CRMSimples> RecuperarAgendamentosSimples(string Descricao, string IdentificadorFuncionarioCadastro,
                                                                          List<string> IdentificadoresFuncionariosResponsaveis,
                                                                          string IdentificadorCliente,
                                                                          string IdentificadorEmpresa, Nullable<DateTime> DataInicio,
                                                                          Nullable<DateTime> DataFim, Nullable<Boolean> Ativo, Boolean ValidacoesToatis,
                                                                          Boolean BuscarSomenteNaoConcluidos)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.CRMSimples> objAgendamentos = null;
            string objQuery = string.Empty;

            objSql.AdicionarParametro("IDPESSOACADASTRO", RecuperarValor(IdentificadorFuncionarioCadastro));
            objSql.AdicionarParametro("IDPESSOACLIENTE", RecuperarValor(IdentificadorCliente));

            if (!string.IsNullOrEmpty(Descricao))
            {
                objSql.AdicionarParametro("DESCRM", "%" + Descricao.ToUpper() + "%");
            }
            else
            {
                objSql.AdicionarParametro("DESCRM", string.Empty);
            };

            if (BuscarSomenteNaoConcluidos)
            {
                objSql.AdicionarParametro("BUSCARNAOCONCLUIDOS", "1");
            }
            else
            {
                objSql.AdicionarParametro("BUSCARNAOCONCLUIDOS", string.Empty);
            };

            
            if (DataInicio != null)
            {
                objSql.AdicionarParametro("DTHPROXAGENDAMENTOINI", DataInicio, false, SqlDbType.DateTime);
            }
            else
            {
                objSql.AdicionarParametro("DTHPROXAGENDAMENTOINI", DBNull.Value);
            }

            if (DataFim != null)
            {
                objSql.AdicionarParametro("DTHPROXAGENDAMENTOFIM", DataFim, false, SqlDbType.DateTime);
            }
            else
            {
                objSql.AdicionarParametro("DTHPROXAGENDAMENTOFIM", DBNull.Value);
            }
            objSql.AdicionarParametro("VALIDACOESTOTAIS", ValidacoesToatis);



            if (Ativo != null)
            {
                if (Ativo == true)
                {
                    objSql.AdicionarParametro("BOLATIVO", "1");
                }
                else
                {
                    objSql.AdicionarParametro("BOLATIVO", "0");
                }
            }
            else
            {
                objSql.AdicionarParametro("BOLATIVO", string.Empty);
            }

            
            if (IdentificadoresFuncionariosResponsaveis != null && IdentificadoresFuncionariosResponsaveis.Count > 0)
            {

                string IdentificaoresPessoas = string.Empty;

                foreach (string p in IdentificadoresFuncionariosResponsaveis)
                {

                    if (!string.IsNullOrEmpty(IdentificaoresPessoas))
                    {
                        IdentificaoresPessoas += ",";
                    }

                    IdentificaoresPessoas += p;

                }

                objSql.AdicionarParametro("IDPESSOA", IdentificaoresPessoas);

            }
            else
            {
                objSql.AdicionarParametro("IDPESSOA", string.Empty);
            }

            objSql.AdicionarParametro("IDEMPRESA", RecuperarValor(IdentificadorEmpresa));

            List<string> objNomesTabelas = new List<string>();

            objNomesTabelas.Add("CRM");
            objNomesTabelas.Add("PESSOACLIENTE");
            objNomesTabelas.Add("PESSOACADASTRO");
            objNomesTabelas.Add("GRUPOCOMPROMISSO");

            List<DataTable> dts = objSql.ExecutarDataTablesArquivo("SP_RECUPERAR_AGEND_SIMPLES", Comum.Clases.Constantes.ARQUIVO_CONEXAO, CommandType.StoredProcedure, objNomesTabelas);

            DataTable dtCRM = dts[0];
            DataTable dtPessoaCliente = dts[1];
            DataTable dtPessoaCadastro = dts[2];
            DataTable dtGrupoCompromisso = dts[3];

            if (dtCRM != null && dtCRM.Rows.Count > 0)
            {

                objAgendamentos = new List<Comum.Clases.CRMSimples>();

                Comum.Clases.CRMSimples objAgendamento = null;
                string IdentificadorAgendamento = null;
                List<string> objIdentificadoresGrupoCompromisso = (from DataRow dr in dtCRM.Rows where !string.IsNullOrEmpty(dr["IDGRUPOCOMPROMISSO"] as string) select dr["IDGRUPOCOMPROMISSO"] as string).ToList();

                List<Comum.Clases.Pessoa> objListaClientes = null;
                List<Comum.Clases.Pessoa> objListaFuncionarios = null;
                List<Comum.Clases.GrupoCompromisso> objListaGrupoCompromisso = null;

                Task objTaskListaClientes = new Task(() => objListaClientes = Pessoa.PreencherPessoaSimples(dtPessoaCliente));
                Task objTaskListaFuncionarios = new Task(() => objListaFuncionarios = Pessoa.PreencherPessoaSimples(dtPessoaCadastro));
                Task objTaskListaGrupoCompromissos = new Task(() => objListaGrupoCompromisso = PreencherGrupoCompromisso(dtGrupoCompromisso));

                objTaskListaClientes.Start();
                objTaskListaFuncionarios.Start();
                objTaskListaGrupoCompromissos.Start();

                Task.WaitAll(new Task[] { objTaskListaClientes, objTaskListaFuncionarios, objTaskListaGrupoCompromissos });


                foreach (DataRow dr in dtCRM.Rows)
                {

                    IdentificadorAgendamento = frmUtil.Util.AtribuirValorObj(dr["IDCRM"], typeof(string)) as string;
                    objAgendamento = (from Comum.Clases.CRMSimples objAge in objAgendamentos where objAge.Identificador == IdentificadorAgendamento select objAge).FirstOrDefault();

                    if (objAgendamento == null)
                    {
                        objAgendamentos.Add(new Comum.Clases.CRMSimples
                        {
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDCRM"], typeof(string)) as string,
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESCRM"], typeof(string)) as string,
                            CorStatus = frmUtil.Util.AtribuirValorObj(dr["CODCORRGB"], typeof(string)) as string,
                            Cliente = (objListaClientes != null ? (from Comum.Clases.Pessoa p in objListaClientes where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACLIENTE"], typeof(string)) as string select p.DesNome).FirstOrDefault() : string.Empty),
                            TelefoneCelular = (objListaClientes != null ? (from Comum.Clases.Pessoa p in objListaClientes where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACLIENTE"], typeof(string)) as string select p.DesTelefoneCelular).FirstOrDefault() : string.Empty),
                            TelefoneFixo = (objListaClientes != null ? (from Comum.Clases.Pessoa p in objListaClientes where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACLIENTE"], typeof(string)) as string select p.DesTelefoneFixo).FirstOrDefault() : string.Empty),
                            UsuarioCriacao = (objListaFuncionarios != null ? (from Comum.Clases.Pessoa p in objListaFuncionarios where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACADASTRO"], typeof(string)) as string select p.DesNome).FirstOrDefault() : string.Empty),
                            Ativo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLATIVO"], typeof(Boolean)))

                        });

                        objAgendamento = (from Comum.Clases.CRMSimples objAge in objAgendamentos where objAge.Identificador == IdentificadorAgendamento select objAge).FirstOrDefault();

                    }

                    if (objAgendamento != null)
                    {

                        objAgendamento.Itens += 1;
                        Comum.Clases.GrupoCompromisso objGrupoComp = (objListaGrupoCompromisso != null ? (from Comum.Clases.GrupoCompromisso p in objListaGrupoCompromisso where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string select p).FirstOrDefault() : null);
                        Boolean BolConcluido = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLCONCLUIDO"], typeof(Boolean)));

                        if (!BolConcluido)
                        {
                            if(objAgendamento.UsuariosResponsaveis == null) { objAgendamento.UsuariosResponsaveis = new List<string>(); }
                            objAgendamento.UsuariosResponsaveis.Add(frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string);
                            objAgendamento.DataProximoCompromisso = Convert.ToDateTime(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTO"], typeof(DateTime)));
                        }

                        if (objGrupoComp != null)
                        {
                            if (objAgendamento.Responsaveis != null)
                            {
                                objAgendamento.Responsaveis += "\r\n" + frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string + " - " + objGrupoComp.Descricao + " - " + Convert.ToString(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTO"], typeof(DateTime)));
                            }
                            else
                            {
                                objAgendamento.Responsaveis = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string + " - " + objGrupoComp.Descricao + " - " + Convert.ToString(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTO"], typeof(DateTime)));
                            }
                        }
                        else
                        {
                            if (objAgendamento.Responsaveis != null)
                            {
                                objAgendamento.Responsaveis += "\r\n" + frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string + " - " + Convert.ToString(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTO"], typeof(DateTime)));
                            }
                            else
                            {
                                objAgendamento.Responsaveis = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string + " - " + Convert.ToString(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTO"], typeof(DateTime)));
                            }
                        }

                    }

                }
            }

            return objAgendamentos;
        }

        private static List<Comum.Clases.GrupoCompromisso> PreencherGrupoCompromisso(DataTable dt)
        {

            List<Comum.Clases.GrupoCompromisso> objGrupoCompromisso = null;

            if (dt != null && dt.Rows.Count > 0)
            {
                objGrupoCompromisso = new List<Comum.Clases.GrupoCompromisso>();

                foreach (DataRow dr in dt.Rows)
                {
                    objGrupoCompromisso.Add(new Comum.Clases.GrupoCompromisso()
                    {
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODGRUPOCOMPROMISSO"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESGRUPOCOMPROMISSO"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string

                    });
                }
            }

            return objGrupoCompromisso;
        }


        public static List<Comum.Clases.Pessoa> RecuperarPessoasAgendamento(string IdentificadorPessoaAgendamento)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.Pessoa> objPessoas = null;
            List<string> IdentificadoresPessoas = null;
            objSql.AdicionarParametro("IDPESSOACRM", IdentificadorPessoaAgendamento);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PessoaCRMPessoaRecuperarIdentificadoresPessoas, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                IdentificadoresPessoas = (from DataRow dr in dt.Rows select frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string).ToList();

                if (IdentificadoresPessoas != null && IdentificadoresPessoas.Count > 0)
                {
                    Comum.Clases.Pessoa objPessoa = null;
                    objPessoas = new List<Comum.Clases.Pessoa>();

                    foreach (string IdentificadorPessoa in IdentificadoresPessoas)
                    {
                        objPessoa = Pessoa.RecuperarPessoa(IdentificadorPessoa);

                        if (objPessoa != null)
                        {
                            objPessoas.Add(objPessoa);
                        }
                    }
                }
            }
            return objPessoas;
        }

        public static string InserirAgendamento(Comum.Clases.CRM objAgendamento, string IdentificadorEmpresa, ref Sql objSql)
        {

            string IdentificadorAgendamento = Guid.NewGuid().ToString();

            objSql.AdicionarParametro("IDCRM", IdentificadorAgendamento);
            objSql.AdicionarParametro("IDPESSOACADASTRO", objAgendamento.FuncionarioCadastro.Identificador);
            objSql.AdicionarParametro("IDPESSOACLIENTE", objAgendamento.Cliente.Identificador);
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            if (!string.IsNullOrEmpty(objAgendamento.Observacao))
            {
                objSql.AdicionarParametro("OBSCOMPROMISSO", objAgendamento.Observacao);
            }
            else
            {
                objSql.AdicionarParametro("OBSCOMPROMISSO", DBNull.Value);
            }

            if (objAgendamento.StatusCrm != null && !string.IsNullOrEmpty(objAgendamento.StatusCrm.Identificador))
            {
                objSql.AdicionarParametro("IDSTATUSCRM", objAgendamento.StatusCrm.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDSTATUSCRM", DBNull.Value);
            }

            if (objAgendamento.TipoCrm != null && !string.IsNullOrEmpty(objAgendamento.TipoCrm.Identificador))
            {
                objSql.AdicionarParametro("IDTIPOCRM", objAgendamento.TipoCrm.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDTIPOCRM", DBNull.Value);
            }

            objSql.AdicionarParametro("DESCRM", objAgendamento.Descricao.ToUpper());
            objSql.AdicionarParametro("BOLATIVO", true);

            objSql.AdicionarTransacao(Properties.Resources.CRMInserir);

            return IdentificadorAgendamento;
        }

        public static string InserirPessoaAgendamento(Comum.Clases.Agendamento objAgendamento, string IdentificadorCRM, ref Sql objSql)
        {

            string Identificador = Guid.NewGuid().ToString();

            objSql.AdicionarParametro("IDPESSOACRM", Identificador);
            objSql.AdicionarParametro("IDCRM", IdentificadorCRM);
            objSql.AdicionarParametro("DTHPROXAGENDAMENTO", objAgendamento.DataAtendimento);
            objSql.AdicionarParametro("DESAGENDAMENTO", objAgendamento.Descricao);
            objSql.AdicionarParametro("DTHPROXAGENDAMENTOFIN", objAgendamento.DataAtendimentoFim);
            objSql.AdicionarParametro("BOLCONCLUIDO", objAgendamento.Concluido);

            if (objAgendamento.NivelAtendimento == null)
            {
                objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDGRUPOCOMPROMISSO", objAgendamento.NivelAtendimento.Identificador);
            }

            objSql.AdicionarTransacao(Properties.Resources.CRMPessoaInserir);

            return Identificador;
        }

        public static void InserirPessoasAgendamento(string IdentificadorPessoa, string IdentificadorPessoaCRM, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDPESSOACRMPESSOA", Guid.NewGuid().ToString());
            objSql.AdicionarParametro("IDPESSOACRM", IdentificadorPessoaCRM);
            objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);


            objSql.AdicionarTransacao(Properties.Resources.CRMPessoaPessoaInserir);

        }

        public static void DeletarPessoaAgendamento(string IdentificadorCRM, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDCRM", IdentificadorCRM);

            objSql.AdicionarTransacao(Properties.Resources.CRMPessoaDeletar);

        }

        public static void DeletarPessoasAgendamento(string IdentificadorCRM, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDCRM", IdentificadorCRM);

            objSql.AdicionarTransacao(Properties.Resources.PessoaCRMPessoaDeletar);

        }

        public static void AtualizarAgendamento(Comum.Clases.CRM objAgendamento, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDCRM", objAgendamento.Identificador);
            objSql.AdicionarParametro("IDPESSOACADASTRO", objAgendamento.FuncionarioCadastro.Identificador);
            objSql.AdicionarParametro("IDPESSOACLIENTE", objAgendamento.Cliente.Identificador);
            if (!string.IsNullOrEmpty(objAgendamento.Observacao))
            {
                objSql.AdicionarParametro("OBSCOMPROMISSO", objAgendamento.Observacao);
            }
            else
            {
                objSql.AdicionarParametro("OBSCOMPROMISSO", DBNull.Value);
            }

            objSql.AdicionarParametro("DESCRM", objAgendamento.Descricao.ToUpper());
            objSql.AdicionarParametro("BOLATIVO", objAgendamento.Ativo);

            if (objAgendamento.StatusCrm != null && !string.IsNullOrEmpty(objAgendamento.StatusCrm.Identificador))
            {
                objSql.AdicionarParametro("IDSTATUSCRM", objAgendamento.StatusCrm.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDSTATUSCRM", DBNull.Value);
            }

            if (objAgendamento.TipoCrm != null && !string.IsNullOrEmpty(objAgendamento.TipoCrm.Identificador))
            {
                objSql.AdicionarParametro("IDTIPOCRM", objAgendamento.TipoCrm.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDTIPOCRM", DBNull.Value);
            }

            objSql.AdicionarTransacao(Properties.Resources.CRMAtualizar);

        }

        public static void DesativarAgendamento(string IdentificadorAgendamento)
        {
            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDCRM", IdentificadorAgendamento);
            objSql.AdicionarParametro("BOLATIVO", false);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.CRMDesativar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static List<Comum.Clases.Proposta> PreencherProposta(DataTable dt, DataTable dtPessoaProposta)
        {

            List<Comum.Clases.Proposta> objPropostas = null;


            if (dt != null && dt.Rows.Count > 0)
            {

                objPropostas = new List<Comum.Clases.Proposta>();

                foreach (DataRow dr in dt.Rows)
                {
                    objPropostas.Add(new Comum.Clases.Proposta
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPROPOSTA"], typeof(string)) as string,
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPROPOSTA"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPROPOSTA"], typeof(string)) as string,
                        AtendeNecessidade = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLATENDENECESSIDADE"], typeof(Boolean))),
                        Ativa = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLATIVA"], typeof(Boolean))),
                        DataHoraInstalacao = (DateTime)(frmUtil.Util.AtribuirValorObj(dr["DTINSTALACAO"], typeof(DateTime))),
                        DesDuvida = frmUtil.Util.AtribuirValorObj(dr["DESDUVIDA"], typeof(string)) as string,
                        DesOpniao = frmUtil.Util.AtribuirValorObj(dr["DESOPNIAO"], typeof(string)) as string,
                        ValorContraPropostaManutencao = (Decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMCONTRAPROPOSTAMANUT"], typeof(Decimal))),
                        ValorContraPropostaVenda = (Decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMCONTRAPROPOSTAVENDA"], typeof(Decimal))),
                        ValorPropostaManutencao = (Decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMPROPOSTAMANUTENCAO"], typeof(Decimal))),
                        ValorPropostaVenda = (Decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMPROPOSTAVENDA"], typeof(Decimal))),
                        Cliente = Pessoa.PreencherPessoaSimplesV2(dtPessoaProposta)

                    });
                }
            }

            return objPropostas;
        }

        public static Dictionary<string, List<Comum.Clases.Pessoa>> PreencherPessoaCrm(DataTable dt)
        {
            Dictionary<string, List<Comum.Clases.Pessoa>> objPesoaCrm = null;

            if (dt != null && dt.Rows.Count > 0)
            {
                objPesoaCrm = new Dictionary<string, List<Comum.Clases.Pessoa>>();
                KeyValuePair<string, List<Comum.Clases.Pessoa>> objPessoa;

                foreach (DataRow dr in dt.Rows)
                {
                    objPessoa = (from KeyValuePair<string, List<Comum.Clases.Pessoa>> p in objPesoaCrm
                                 where p.Key == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string
                                 select p).FirstOrDefault();

                    if (string.IsNullOrEmpty(objPessoa.Key))
                    {
                        objPesoaCrm.Add(frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string,
                                        Pessoa.PreencherPessoaSimples(dt, frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string));
                    }


                }
            }
            return objPesoaCrm;
        }

        public static Comum.Clases.CRM RecuperarAgendamento(string IdentificadorAgendamento)
        {

            Sql objSql = new Sql();
            Comum.Clases.CRM objAgendamento = null;

            objSql.AdicionarParametro("IDCRM", IdentificadorAgendamento);

            List<string> objNomesTabelas = new List<string>();

            objNomesTabelas.Add("CRM");
            objNomesTabelas.Add("PROPOSTA");
            objNomesTabelas.Add("PESSOAPROPOSTA");
            objNomesTabelas.Add("PESSOACLIENTE");
            objNomesTabelas.Add("PESSOACADASTRO");
            objNomesTabelas.Add("GRUPOCOMPROMISSO");
            objNomesTabelas.Add("PERGUNTAS");
            objNomesTabelas.Add("PESSOACRM");

            List<DataTable> dts = objSql.ExecutarDataTablesArquivo("SP_RECUPERAR_AGENDAMENTO_DET", Comum.Clases.Constantes.ARQUIVO_CONEXAO, CommandType.StoredProcedure, objNomesTabelas);

            DataTable dtCRM = dts[0];
            DataTable dtProposta = dts[1];
            DataTable dtPessoaProposta = dts[2];
            DataTable dtPessoaCliente = dts[3];
            DataTable dtPessoaCadastro = dts[4];
            DataTable dtGrupoCompromisso = dts[5];
            DataTable dtPerguntas = dts[6];
            DataTable dtPessoasCrm = dts[7];

            if (dtCRM != null && dtCRM.Rows.Count > 0)
            {

                List<Comum.Clases.Pessoa> objListaClientes = null;
                List<Comum.Clases.Pessoa> objListaFuncionarios = null;
                List<Comum.Clases.GrupoCompromisso> objListaGrupoCompromisso = null;
                List<Comum.Clases.Pergunta> objListaPerguntas = null;
                List<Comum.Clases.Proposta> objListaPropostas = null;
                Dictionary<string, List<Comum.Clases.Pessoa>> objListaPessasCrm = null;

                Task objTaskListaClientes = new Task(() => objListaClientes = Pessoa.PreencherPessoaSimples(dtPessoaCliente));
                Task objTaskListaFuncionarios = new Task(() => objListaFuncionarios = Pessoa.PreencherPessoaSimples(dtPessoaCadastro));
                Task objTaskListaGrupoCompromissos = new Task(() => objListaGrupoCompromisso = PreencherGrupoCompromisso(dtGrupoCompromisso));
                Task objTaskListaPerguntas = new Task(() => objListaPerguntas = PreencherPerguntas(dtPerguntas));
                Task objTaskListaPessoasCrm = new Task(() => objListaPessasCrm = PreencherPessoaCrm(dtPessoasCrm));
                Task objTaskPropostas = new Task(() => objListaPropostas = PreencherProposta(dtProposta, dtPessoaCadastro));

                objTaskListaClientes.Start();
                objTaskListaFuncionarios.Start();
                objTaskListaGrupoCompromissos.Start();
                objTaskListaPerguntas.Start();
                objTaskListaPessoasCrm.Start();
                objTaskPropostas.Start();

                Task.WaitAll(new Task[] { objTaskListaClientes, objTaskListaFuncionarios, objTaskListaGrupoCompromissos, objTaskListaPerguntas, objTaskListaPessoasCrm, objTaskPropostas });

                objAgendamento = new Comum.Clases.CRM
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["IDCRM"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["CODCRM"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["DESCRM"], typeof(string)) as string,
                    Cliente = objListaClientes.FirstOrDefault(),
                    FuncionarioCadastro = objListaFuncionarios.FirstOrDefault(),
                    Observacao = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["OBSCOMPROMISSO"], typeof(string)) as string,
                    Ativo = (Boolean)(frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["BOLATIVO"], typeof(Boolean))),
                    Propostas = objListaPropostas,
                    StatusCrm = new Comum.Clases.StatusCrm()
                    {
                        Codigo = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["CODSTATUSCRM"], typeof(string)) as string,
                        Descricao = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["DESSTATUSCRM"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["IDSTATUSCRM"], typeof(string)) as string
                    },
                    TipoCrm = new Comum.Clases.TipoCrm()
                    {
                        Identificador = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["IDTIPOCRM"], typeof(string)) as string,
                        Descricao = frmUtil.Util.AtribuirValorObj(dtCRM.Rows[0]["DESTIPOCRM"], typeof(string)) as string
                    },
                    Atendimentos = new List<Comum.Clases.Agendamento>()

                };

                foreach (DataRow dr in dtCRM.Rows)
                {

                    if (objAgendamento != null)
                    {

                        objAgendamento.Atendimentos.Add(new Comum.Clases.Agendamento
                        {

                            FuncionariosResponsaveis = (from KeyValuePair<string, List<Comum.Clases.Pessoa>> p in objListaPessasCrm
                                                        where p.Key == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string
                                                        select p.Value).FirstOrDefault(),
                            DataAtendimento = (DateTime)(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTO"], typeof(DateTime))),
                            DataAtendimentoFim = (DateTime)(frmUtil.Util.AtribuirValorObj(dr["DTHPROXAGENDAMENTOFIN"], typeof(DateTime))),
                            Concluido = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLCONCLUIDO"], typeof(Boolean))),
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESAGENDAMENTO"], typeof(string)) as string,
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string,
                            NivelAtendimento = (objListaGrupoCompromisso != null ? (from Comum.Clases.GrupoCompromisso p in objListaGrupoCompromisso where p.Identificador == frmUtil.Util.AtribuirValorObj(dr["IDGRUPOCOMPROMISSO"], typeof(string)) as string select p).FirstOrDefault() : null),
                            Perguntas = (objListaPerguntas != null ? (from Comum.Clases.Pergunta p in objListaPerguntas where p.IdentificadorPessoaCRM == frmUtil.Util.AtribuirValorObj(dr["IDPESSOACRM"], typeof(string)) as string select p).ToList() : null)

                        });
                    }

                }
            }

            return objAgendamento;
        }
    }
}
