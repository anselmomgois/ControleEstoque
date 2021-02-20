using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Empresa
    {

        public static List<Comum.Clases.Empresa> RecuperarEmpresasFuncionario(string IdentificadorPessoa)
        {

            List<Comum.Clases.Empresa> objEmpresas = null;

            Sql objFrm = new Sql();

            objFrm.AdicionarParametro("IDPESSOA", IdentificadorPessoa, true);

            DataTable dt = null;

            dt = objFrm.ExecutarDataTableArquivo(Properties.Resources.EmpresasRecuperarEmpresasFuncionario, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                Comum.Clases.Empresa objEmpresa = null;
                objEmpresas = new List<Comum.Clases.Empresa>();
                string IdentificadorEmpresa;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorEmpresa = frmUtil.Util.AtribuirValorObj(dr["IDEMPRESA"], typeof(string)) as string;

                    objEmpresa = (from emp in objEmpresas where emp.Identificador == IdentificadorEmpresa select emp).FirstOrDefault();

                    if (objEmpresa == null)
                    {

                        objEmpresas.Add(new Comum.Clases.Empresa
                        {
                            Identificador = IdentificadorEmpresa,
                            Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODEMPRESA"], typeof(int)),
                            Nome = frmUtil.Util.AtribuirValorObj(dr["DESEMPRESA"], typeof(string)) as string,
                            CodAcesso = frmUtil.Util.AtribuirValorObj(dr["CODACESSO"], typeof(string)) as string,
                            Cnpj = frmUtil.Util.AtribuirValorObj(dr["DESCNPJ"], typeof(string)) as string,
                            InscricaoEstadual = frmUtil.Util.AtribuirValorObj(dr["DESINSCRICAOESTADUAL"], typeof(string)) as string,
                            ChaveAcesso = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLICENCA"], typeof(string)) as string,
                            QuantidadeAcessada = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADEACESSADA"], typeof(int), true),
                            QuantidadeAcessos = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADEACESSO"], typeof(int), true),
                            QuantidadeSessoes = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADESESSOES"], typeof(int), true),
                            SessoesIlimitadas = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["SESSOSILIMITADAS"], typeof(Boolean)),
                            ValidadeIlimitada = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["VALIDADEILIMITADA"], typeof(Boolean)),
                            EmpresaMestre = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLEMPRESAMESTE"], typeof(Boolean)),
                            Filiais = new List<Comum.Clases.Filiais>()
                        });

                        objEmpresa = (from emp in objEmpresas where emp.Identificador == IdentificadorEmpresa select emp).FirstOrDefault();

                    }

                    Comum.Clases.Filiais objFilial = new Comum.Clases.Filiais();

                    string IdentificadorEndereco = frmUtil.Util.AtribuirValorObj(dr["IDENDERECO"], typeof(string)) as string;

                    objFilial.Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODFILIAL"], typeof(int));
                    objFilial.Identificador = frmUtil.Util.AtribuirValorObj(dr["IDFILIAL"], typeof(string)) as string;
                    objFilial.Nome = frmUtil.Util.AtribuirValorObj(dr["DESFILIAL"], typeof(string)) as string;
                    objFilial.TelefoneFax = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFAX"], typeof(string)) as string;
                    objFilial.TelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFIXO"], typeof(string)) as string;
                    objFilial.TelefoneMovel = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONECEL"], typeof(string)) as string;
                    objFilial.Email = frmUtil.Util.AtribuirValorObj(dr["DESEMAIL"], typeof(string)) as string;

                    if (!string.IsNullOrEmpty(IdentificadorEndereco))
                    {

                        objFilial.Endereco = Endereco.RecuperarEndereco(string.Empty, string.Empty,
                                                                        string.Empty, string.Empty,
                                                                        string.Empty, string.Empty, IdentificadorEndereco);

                        Int32 Numero = (int)frmUtil.Util.AtribuirValorObj(dr["NUMENDERECO"], typeof(int));

                        if (objFilial.Endereco != null && objFilial.Endereco.Cidades != null && objFilial.Endereco.Cidades.Count > 0
                           && objFilial.Endereco.Cidades.First().Bairros != null && objFilial.Endereco.Cidades.First().Bairros.Count > 0
                           && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos != null && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.Count > 0)
                        {
                            objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Numero = Numero;
                        }
                    }

                    objEmpresa.Filiais.Add(objFilial);

                }
            }
            return objEmpresas;
        }

        public static Comum.Clases.Empresa RecuperarEmpresaSimples(string IdentificadorEmpresa)
        {
            Comum.Clases.Empresa objEmpresa = null;


            Sql objFrm = new Sql();

            objFrm.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objFrm.ExecutarDataTableArquivo(Properties.Resources.EmpresaRecuperarSimples, Comum.Clases.Constantes.ARQUIVO_CONEXAO);


            if (dt != null && dt.Rows.Count > 0)
            {

                objEmpresa = new Comum.Clases.Empresa
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDEMPRESA"], typeof(string)) as string,
                    Codigo = (int)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODEMPRESA"], typeof(int)),
                    Nome = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESEMPRESA"], typeof(string)) as string,
                    CodAcesso = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODACESSO"], typeof(string)) as string,
                    QuantidadeAcessada = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADEACESSADA"], typeof(int), true),
                    QuantidadeAcessos = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADEACESSO"], typeof(int), true),
                    QuantidadeSessoes = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADESESSOES"], typeof(int), true),
                    SessoesIlimitadas = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["SESSOSILIMITADAS"], typeof(Boolean)),
                    ValidadeIlimitada = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["VALIDADEILIMITADA"], typeof(Boolean)),
                    Cnpj = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCNPJ"], typeof(string)) as string,
                    InscricaoEstadual = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESINSCRICAOESTADUAL"], typeof(string)) as string,
                    ChaveAcesso = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLICENCA"], typeof(string)) as string
                };

            }

            return objEmpresa;
        }

        public static Comum.Clases.Empresa RecuperarEmpresa(string IdentificadorEmpresa, Nullable<Boolean> EmpresaMestre)
        {

            if (string.IsNullOrEmpty(IdentificadorEmpresa))
            {
                return null;
            }

            Comum.Clases.Empresa objEmpresa = null;

            Sql objFrm = new Sql();



            string strSql = string.Empty;

            if (EmpresaMestre != null)
            {

                strSql = " WHERE E.BOLEMPRESAMESTE = @BOLEMPRESAMESTE ";
                objFrm.AdicionarParametro("BOLEMPRESAMESTE", EmpresaMestre, true);

            }
            else
            {
                strSql = " WHERE E.IDEMPRESA = @IDEMPRESA ";
                objFrm.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa, true);
            }

            DataTable dt = objFrm.ExecutarDataTableArquivo(string.Format(Properties.Resources.EmpresaRecuperar, strSql), Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                objEmpresa = new Comum.Clases.Empresa
                {
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDEMPRESA"], typeof(string)) as string,
                    Codigo = (int)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODEMPRESA"], typeof(int)),
                    Nome = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESEMPRESA"], typeof(string)) as string,
                    CodAcesso = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODACESSO"], typeof(string)) as string,
                    EmpresaMestre = (Boolean)(frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["BOLEMPRESAMESTE"], typeof(Boolean), false)),
                    QuantidadeAcessada = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADEACESSADA"], typeof(int), true),
                    QuantidadeAcessos = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADEACESSO"], typeof(int), true),
                    QuantidadeSessoes = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["NUMQUANTIDADESESSOES"], typeof(int), true),
                    SessoesIlimitadas = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["SESSOSILIMITADAS"], typeof(Boolean)),
                    ValidadeIlimitada = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["VALIDADEILIMITADA"], typeof(Boolean)),
                    Cnpj = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCNPJ"], typeof(string)) as string,
                    InscricaoEstadual = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESINSCRICAOESTADUAL"], typeof(string)) as string,
                    ChaveAcesso = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLICENCA"], typeof(string)) as string,
                    Email = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESEMAIL"], typeof(string)) as string,
                    Senha = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESSENHA"], typeof(string)) as string,
                    Smtp = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESSMTP"], typeof(string)) as string,
                    Porta = (Nullable<Int32>)frmUtil.Util.AtribuirValorObj2(dt.Rows[0]["CODPORTA"], typeof(int), true),
                    Ssl = (Boolean)frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLSSL"], typeof(Boolean)),
                    Filiais = new List<Comum.Clases.Filiais>()
                };

                foreach (DataRow dr in dt.Rows)
                {


                    Comum.Clases.Filiais objFilial = new Comum.Clases.Filiais();

                    string IdentificadorEndereco = frmUtil.Util.AtribuirValorObj(dr["IDENDERECO"], typeof(string)) as string;
                    string IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string;

                    objFilial.Codigo = (Int32)frmUtil.Util.AtribuirValorObj(dr["CODFILIAL"], typeof(Int32));
                    objFilial.Identificador = frmUtil.Util.AtribuirValorObj(dr["IDFILIAL"], typeof(string)) as string;
                    objFilial.Nome = frmUtil.Util.AtribuirValorObj(dr["DESFILIAL"], typeof(string)) as string;
                    objFilial.TelefoneFax = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFAX"], typeof(string)) as string;
                    objFilial.TelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFIXO"], typeof(string)) as string;
                    objFilial.TelefoneMovel = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONECEL"], typeof(string)) as string;
                    objFilial.Email = frmUtil.Util.AtribuirValorObj(dr["DESEMAIL"], typeof(string)) as string;
                    objFilial.Matriz = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLMATRIZ"], typeof(Boolean)));
                    objFilial.NumContribuicaoSocialPer = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMCONTSOCPER"], typeof(decimal)));
                    objFilial.NumOutrasDespesas = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMOUTDESPPER"], typeof(decimal)));
                    objFilial.NumPercentualConfins = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMCONFINSPER"], typeof(decimal)));
                    objFilial.NumPercentualPis = (decimal)(frmUtil.Util.AtribuirValorObj(dr["NUMPISPER"], typeof(decimal)));
                    objFilial.Observacao = frmUtil.Util.AtribuirValorObj(dr["OBSFILIAL"], typeof(string)) as string;
                    objFilial.DataAbertura = (Nullable<DateTime>)(frmUtil.Util.AtribuirValorObj(dr["DTHABERTURA"], typeof(Nullable<DateTime>)));
                    objFilial.CodigoTabelaMercadoria = (Int32)frmUtil.Util.AtribuirValorObj(dr["CODTABMERCADORIA"], typeof(Int32));
                    objFilial.Ativa = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLATIVA"], typeof(Boolean)));

                    if (!string.IsNullOrEmpty(IdentificadorPessoa))
                    {
                        objFilial.Gerente = Pessoa.RecuperarPessoa(IdentificadorPessoa);
                    }

                    if (!string.IsNullOrEmpty(IdentificadorEndereco))
                    {

                        objFilial.Endereco = Endereco.RecuperarEndereco(string.Empty, string.Empty,
                                                                        string.Empty, string.Empty,
                                                                        string.Empty, string.Empty, IdentificadorEndereco);

                        Int32 Numero = (int)frmUtil.Util.AtribuirValorObj(dr["NUMENDERECO"], typeof(int));

                        if (objFilial.Endereco != null && objFilial.Endereco.Cidades != null && objFilial.Endereco.Cidades.Count > 0
                           && objFilial.Endereco.Cidades.First().Bairros != null && objFilial.Endereco.Cidades.First().Bairros.Count > 0
                           && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos != null && objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.Count > 0)
                        {
                            objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Numero = Numero;
                            objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().Complemento = frmUtil.Util.AtribuirValorObj(dr["DESCOMPENDERECO"], typeof(string)) as string;
                            objFilial.Endereco.Cidades.First().Bairros.First().Enderecos.First().DesReferencia = frmUtil.Util.AtribuirValorObj(dr["DESPONTREFENDERECO"], typeof(string)) as string;
                        }
                    }

                    objEmpresa.Filiais.Add(objFilial);

                }
            }
            return objEmpresa;
        }

        public static void AtualizarEmpresa(Comum.Clases.Empresa objEmpresa, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDEMPRESA", objEmpresa.Identificador, true);
            objSql.AdicionarParametro("DESEMPRESA", objEmpresa.Nome.ToUpper());
            objSql.AdicionarParametro("DESCNPJ", objEmpresa.Cnpj);
            objSql.AdicionarParametro("DESINSCRICAOESTADUAL", objEmpresa.InscricaoEstadual);
            objSql.AdicionarParametro("DESEMAIL", objEmpresa.Email);
            objSql.AdicionarParametro("DESSENHA", objEmpresa.Senha);
            objSql.AdicionarParametro("DESSMTP", objEmpresa.Smtp);
            objSql.AdicionarParametro("BOLSSL", objEmpresa.Ssl);
            objSql.AdicionarParametro("CODPORTA", objEmpresa.Porta);
            objSql.AdicionarTransacao(Properties.Resources.EmpresaAtualizar);
        }

        public static void AtualizarInformacoesChave(string IdentificadorEmpresa, string CodigoAcesso, string ChaveAcesso,
                                                     Nullable<Int32> NumQuantidadeSessoes, Nullable<Int32> NumQuantidadeAcessos,
                                                     Boolean SessoesIlimitadas, Boolean ValidadeIlimitada)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("CODACESSO", CodigoAcesso);
            objSql.AdicionarParametro("CODLICENCA", ChaveAcesso);

            if (NumQuantidadeSessoes == null)
            {
                objSql.AdicionarParametro("NUMQUANTIDADESESSOES", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMQUANTIDADESESSOES", NumQuantidadeSessoes);
            }

            if (NumQuantidadeAcessos == null)
            {
                objSql.AdicionarParametro("NUMQUANTIDADEACESSO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("NUMQUANTIDADEACESSO", NumQuantidadeAcessos);
            }
            objSql.AdicionarParametro("NUMQUANTIDADEACESSADA", 0);
            objSql.AdicionarParametro("SESSOSILIMITADAS", SessoesIlimitadas);
            objSql.AdicionarParametro("VALIDADEILIMITADA", ValidadeIlimitada);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.EmpresaAtualizarInformacoesChave, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static void AtualizarCodigoAcesso(string IdentificadorEmpresa, string CodigoAcesso)
        {

            Sql objSql = new Sql();
            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("CODACESSO", CodigoAcesso);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.EmpresaAtualizarCodigoAcesso, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static void AtualizarQuantidadeAcessos(string IdentificadorEmpresa, Int32 QuantidadeAcessos, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa, true);
            objSql.AdicionarParametro("NUMQUANTIDADEACESSADA", QuantidadeAcessos);

            objSql.AdicionarTransacao(Properties.Resources.EmpresaAtualizarQuantidadeAcessada);

        }

        public static string InserirEmpresa(string NomeEmpresa, Int32 CodigoEmpresa, string IdentificadorPublicidade, string IdentificadorConsultor,
                                            string DescricaoIndiciacao, ref Sql objSql)
        {

            string IdentificadorEmpesa = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpesa, true);
            objSql.AdicionarParametro("CODEMPRESA", CodigoEmpresa);
            objSql.AdicionarParametro("DESEMPRESA", NomeEmpresa);
            objSql.AdicionarParametro("CODACESSO", 1);
            objSql.AdicionarParametro("BOLEMPRESAMESTE", false);

            if (string.IsNullOrEmpty(IdentificadorPublicidade))
            {
                objSql.AdicionarParametro("IDPUBLICIDADE", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDPUBLICIDADE", frmUtil.Util.RetornaDbNull(IdentificadorPublicidade, true));
            }

            if (string.IsNullOrEmpty(IdentificadorConsultor))
            {
                objSql.AdicionarParametro("IDPESSOA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOA", frmUtil.Util.RetornaDbNull(IdentificadorConsultor, true));
            }

            objSql.AdicionarParametro("DESAMIGO", frmUtil.Util.RetornaDbNull(DescricaoIndiciacao, true));
            objSql.AdicionarTransacao(Properties.Resources.EmpresaInserir);

            return IdentificadorEmpesa;
        }

        public static Int32 RetornarProximoCodigoEmpresa()
        {

            Sql objSql = new Sql();

            return ((Int32)(objSql.ExecutarScalarArquivo(Properties.Resources.EmpresaRecuperarProximoCodigo, Comum.Clases.Constantes.ARQUIVO_CONEXAO)));
        }
    }
}
