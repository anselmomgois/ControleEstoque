using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Proposta
    {

        public static List<Comum.Clases.Proposta> PesquisarProposta(string Descricao, string IdentificadorEmpresa,
                                                                    string IdentificadorCliente, string IdentificadorFuncionario, Boolean Gerente, Nullable<Int32> Codigo,
                                                                    string IdentificadorAgendamento)
        {

            Sql objSql = new Sql();
            List<Comum.Clases.Proposta> objPropostas = null;
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(Descricao))
            {
                objQuery = " AND DESPROPOSTA LIKE @DESPROPOSTA ";
                objSql.AdicionarParametro("DESPROPOSTA", "%" + Descricao.ToUpper() + "%");
            }

            if (!Gerente)
            {
                objQuery = " AND IDPESSOA = @IDPESSOA ";
                objSql.AdicionarParametro("IDPESSOA", IdentificadorFuncionario);
            }

            if (!string.IsNullOrEmpty(IdentificadorCliente))
            {
                objQuery = " AND IDPESSOACLIENTE = @IDPESSOACLIENTE ";
                objSql.AdicionarParametro("IDPESSOACLIENTE", IdentificadorCliente);
            }

            if (Codigo != null)
            {
                objQuery = " AND CODPROPOSTA = @CODPROPOSTA ";
                objSql.AdicionarParametro("CODPROPOSTA", Codigo);
            }

            if (!string.IsNullOrEmpty(IdentificadorAgendamento))
            {
                objQuery = " AND IDCRM = @IDCRM ";
                objSql.AdicionarParametro("IDCRM", IdentificadorAgendamento);
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PropostaPesquisar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

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
                        Cliente = Pessoa.RecuperarPessoa(frmUtil.Util.AtribuirValorObj(dr["IDPESSOACLIENTE"], typeof(string)) as string)

                    });
                }
            }

            return objPropostas;
        }

        public static void InserirProposta(Comum.Clases.Proposta objProposta, string IdentificadorEmpresa)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPROPOSTA", Guid.NewGuid());
            objSql.AdicionarParametro("DESPROPOSTA", frmUtil.Util.RetornaDbNull(objProposta.Descricao.ToUpper(), true));
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("NUMPROPOSTAVENDA", frmUtil.Util.RetornaDbNull(objProposta.ValorPropostaVenda));
            objSql.AdicionarParametro("NUMPROPOSTAMANUTENCAO", frmUtil.Util.RetornaDbNull(objProposta.ValorPropostaManutencao));
            objSql.AdicionarParametro("NUMCONTRAPROPOSTAVENDA", frmUtil.Util.RetornaDbNull(objProposta.ValorContraPropostaVenda));
            objSql.AdicionarParametro("NUMCONTRAPROPOSTAMANUT", frmUtil.Util.RetornaDbNull(objProposta.ValorContraPropostaManutencao));
            objSql.AdicionarParametro("DESOPNIAO", frmUtil.Util.RetornaDbNull(objProposta.DesOpniao, true));
            objSql.AdicionarParametro("DESDUVIDA", frmUtil.Util.RetornaDbNull(objProposta.DesDuvida, true));
            objSql.AdicionarParametro("BOLATENDENECESSIDADE", frmUtil.Util.RetornaDbNull(objProposta.AtendeNecessidade));
            objSql.AdicionarParametro("DTINSTALACAO", frmUtil.Util.RetornaDbNull(objProposta.DataHoraInstalacao));
            objSql.AdicionarParametro("BOLATIVA", true);

            if (string.IsNullOrEmpty(objProposta.IdentificadorCRM))
            {
                objSql.AdicionarParametro("IDCRM", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDCRM", frmUtil.Util.RetornaDbNull(objProposta.IdentificadorCRM));
            }

            if (objProposta.PessoaResponsavel != null)
            {
                objSql.AdicionarParametro("IDPESSOA", objProposta.PessoaResponsavel.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOA", DBNull.Value);
            }

            if (objProposta.Cliente != null)
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", frmUtil.Util.RetornaDbNull(objProposta.Cliente.Identificador));
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", DBNull.Value);
            }


            objSql.ExecutarNonQueryArquivo(Properties.Resources.PropostaInserir, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void InserirPropostaComTransacao(Comum.Clases.Proposta objProposta, string IdentificadorEmpresa, ref Sql objSql)
        {


            objSql.AdicionarParametro("IDPROPOSTA", Guid.NewGuid());
            objSql.AdicionarParametro("DESPROPOSTA", frmUtil.Util.RetornaDbNull(objProposta.Descricao.ToUpper(), true));
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("NUMPROPOSTAVENDA", frmUtil.Util.RetornaDbNull(objProposta.ValorPropostaVenda));
            objSql.AdicionarParametro("NUMPROPOSTAMANUTENCAO", frmUtil.Util.RetornaDbNull(objProposta.ValorPropostaManutencao));
            objSql.AdicionarParametro("NUMCONTRAPROPOSTAVENDA", frmUtil.Util.RetornaDbNull(objProposta.ValorContraPropostaVenda));
            objSql.AdicionarParametro("NUMCONTRAPROPOSTAMANUT", frmUtil.Util.RetornaDbNull(objProposta.ValorContraPropostaManutencao));
            objSql.AdicionarParametro("DESOPNIAO", frmUtil.Util.RetornaDbNull(objProposta.DesOpniao, true));
            objSql.AdicionarParametro("DESDUVIDA", frmUtil.Util.RetornaDbNull(objProposta.DesDuvida, true));
            objSql.AdicionarParametro("BOLATENDENECESSIDADE", frmUtil.Util.RetornaDbNull(objProposta.AtendeNecessidade));
            objSql.AdicionarParametro("DTINSTALACAO", frmUtil.Util.RetornaDbNull(objProposta.DataHoraInstalacao));
            objSql.AdicionarParametro("BOLATIVA", true);

            if (string.IsNullOrEmpty(objProposta.IdentificadorCRM))
            {
                objSql.AdicionarParametro("IDCRM", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDCRM", frmUtil.Util.RetornaDbNull(objProposta.IdentificadorCRM));
            }

            if (objProposta.PessoaResponsavel != null)
            {
                objSql.AdicionarParametro("IDPESSOA", objProposta.PessoaResponsavel.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOA", DBNull.Value);
            }

            if (objProposta.Cliente != null)
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", frmUtil.Util.RetornaDbNull(objProposta.Cliente.Identificador));
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", DBNull.Value);
            }


            objSql.AdicionarTransacao(Properties.Resources.PropostaInserir);
        }

        public static void AtualizarrProposta(Comum.Clases.Proposta objProposta)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPROPOSTA", objProposta.Identificador);
            objSql.AdicionarParametro("DESPROPOSTA", frmUtil.Util.RetornaDbNull(objProposta.Descricao.ToUpper(), true));
            objSql.AdicionarParametro("NUMPROPOSTAVENDA", frmUtil.Util.RetornaDbNull(objProposta.ValorPropostaVenda));
            objSql.AdicionarParametro("NUMPROPOSTAMANUTENCAO", frmUtil.Util.RetornaDbNull(objProposta.ValorPropostaManutencao));
            objSql.AdicionarParametro("NUMCONTRAPROPOSTAVENDA", frmUtil.Util.RetornaDbNull(objProposta.ValorContraPropostaVenda));
            objSql.AdicionarParametro("NUMCONTRAPROPOSTAMANUT", frmUtil.Util.RetornaDbNull(objProposta.ValorContraPropostaManutencao));
            objSql.AdicionarParametro("DESOPNIAO", frmUtil.Util.RetornaDbNull(objProposta.DesOpniao, true));
            objSql.AdicionarParametro("DESDUVIDA", frmUtil.Util.RetornaDbNull(objProposta.DesDuvida, true));
            objSql.AdicionarParametro("BOLATENDENECESSIDADE", frmUtil.Util.RetornaDbNull(objProposta.AtendeNecessidade));
            objSql.AdicionarParametro("DTINSTALACAO", frmUtil.Util.RetornaDbNull(objProposta.DataHoraInstalacao));
            objSql.AdicionarParametro("BOLATIVA", objProposta.Ativa);

            if (string.IsNullOrEmpty(objProposta.IdentificadorCRM))
            {
                objSql.AdicionarParametro("IDCRM", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDCRM", frmUtil.Util.RetornaDbNull(objProposta.IdentificadorCRM));
            }

            if (objProposta.PessoaResponsavel != null)
            {
                objSql.AdicionarParametro("IDPESSOA", objProposta.PessoaResponsavel.Identificador);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOA", DBNull.Value);
            }

            if (objProposta.Cliente != null)
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", frmUtil.Util.RetornaDbNull(objProposta.Cliente.Identificador));
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOACLIENTE", DBNull.Value);
            }


            objSql.ExecutarNonQueryArquivo(Properties.Resources.PropostaAtualizar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DesativarProposta(string IdentificadorProposta)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPROPOSTA", IdentificadorProposta);
            objSql.AdicionarParametro("BOLATIVA", false);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.PropostaDesativar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
        }

        public static void DeletarPropostasCRM(string IdentificadorCRM, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDCRM", IdentificadorCRM);
            
            objSql.AdicionarTransacao(Properties.Resources.PropostaDeletarComIdCrm);
        }

        public static Comum.Clases.Proposta RecuperarProposta(string IdentificadorProposta)
        {

            if (string.IsNullOrEmpty(IdentificadorProposta))
            {
                return null;
            }

            Sql objSql = new Sql();
            Comum.Clases.Proposta objProposta = null;

            objSql.AdicionarParametro("IDPROPOSTA", IdentificadorProposta);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PropostaRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objProposta = new Comum.Clases.Proposta()
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPROPOSTA"], typeof(string)) as string,
                    Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPROPOSTA"], typeof(Int32))),
                    Descricao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPROPOSTA"], typeof(string)) as string,
                    IdentificadorCRM = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDCRM"], typeof(string)) as string,
                    ValorContraPropostaManutencao = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMCONTRAPROPOSTAMANUT"], typeof(decimal))),
                    ValorContraPropostaVenda = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMCONTRAPROPOSTAVENDA"], typeof(decimal))),
                    ValorPropostaManutencao = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPROPOSTAMANUTENCAO"], typeof(decimal))),
                    ValorPropostaVenda = (decimal)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMPROPOSTAVENDA"], typeof(decimal))),
                    DesDuvida = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESDUVIDA"], typeof(string)) as string,
                    DesOpniao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESOPNIAO"], typeof(string)) as string,
                    AtendeNecessidade = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLATENDENECESSIDADE"], typeof(Boolean))),
                    Ativa = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLATIVA"], typeof(Boolean))),
                    DataHoraInstalacao = (DateTime)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTINSTALACAO"], typeof(DateTime))),
                    Cliente = Pessoa.RecuperarPessoa(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOACLIENTE"], typeof(string)) as string),
                    PessoaResponsavel = Pessoa.RecuperarPessoa(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOA"], typeof(string)) as string)

                };


            }

            return objProposta;
        }

    }
}
