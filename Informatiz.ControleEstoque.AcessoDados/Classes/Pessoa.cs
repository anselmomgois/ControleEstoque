using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Pessoa
    {

        public static void AlterarSenhaUsuario(string Identificador, string Senha, Boolean SolicitarTrocarSenha)
        {

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPESSOA", Identificador);
            objSql.AdicionarParametro("DESSENHA", Senha);
            objSql.AdicionarParametro("BOLALTERARSENHA", SolicitarTrocarSenha);

            objSql.ExecutarNonQueryArquivo(Properties.Resources.PessoaAlterarSenha, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static void DesativarPessoa(string Identificador, Comum.Enumeradores.Enumeradores.TipoPessoaEnum TipoPessoa)
        {

            Sql objSql = new Sql();
            string objQuery = string.Empty;

            objSql.AdicionarParametro("IDPESSOA", Identificador);
            objSql.AdicionarParametro("ATIVO", false);

            if (TipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO)
            {
                objQuery = " BOLFUNICIONARIOATIVO = @ATIVO ";
            }
            else if (TipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR)
            {
                objQuery = " BOLFORNECEDORATIVO = @ATIVO ";
            }

            objSql.ExecutarNonQueryArquivo(string.Format(Properties.Resources.PessoaDesativar, objQuery), Comum.Clases.Constantes.ARQUIVO_CONEXAO);

        }

        public static List<Comum.Clases.Pessoa> RecuperarPessoas(int Codigo, string Descricao, string cpf, string cnpj, string Usuario,
                                                                 Comum.Enumeradores.Enumeradores.TipoPessoaEnum TipoPessoa, string IdentificadorEmpresa,
                                                                 Nullable<Boolean> FuncionarioAtivo)
        {

            List<Comum.Clases.Pessoa> objPessoas = null;
            Sql objFrm = new Sql();
            string objSql = string.Empty;


            objFrm.AdicionarParametro("CODTIPOPESSOA", TipoPessoa, true);
            objFrm.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);



            if (Codigo > 0)
            {

                objSql = " AND P.CODPESSOA = @CODPESSOA ";
                objFrm.AdicionarParametro("CODPESSOA", Codigo);

            }

            if (!string.IsNullOrEmpty(Descricao))
            {

                objSql = " AND P.DESNOME LIKE  @DESNOME ";
                objFrm.AdicionarParametro("DESNOME", "%" + Descricao.ToUpper() + "%");

            }

            if (!string.IsNullOrEmpty(cpf))
            {

                objSql = " AND P.DESCPF = @DESCPF ";
                objFrm.AdicionarParametro("DESCPF", cpf);

            }

            if (!string.IsNullOrEmpty(cnpj))
            {

                objSql = " AND P.DESCNPJ = @DESCNPJ ";
                objFrm.AdicionarParametro("DESCNPJ", cnpj);

            }

            if (!string.IsNullOrEmpty(Usuario))
            {

                objSql = " AND UPPER(P.CODLOGIN) LIKE @CODLOGIN ";
                objFrm.AdicionarParametro("CODLOGIN", "%" + Usuario.ToUpper() + "%");

            }

            if(FuncionarioAtivo != null)
            {
                objSql = " AND P.BOLFUNICIONARIOATIVO = @BOLFUNICIONARIOATIVO ";
                objFrm.AdicionarParametro("BOLFUNICIONARIOATIVO", FuncionarioAtivo);
            }


            DataTable dt = objFrm.ExecutarDataTableArquivo(string.Format(Properties.Resources.PessoaPesquisar, objSql), Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {

                Comum.Clases.Pessoa objPessoa = null;
                string IdentificadorPessoa = null;
                objPessoas = new List<Comum.Clases.Pessoa>();
                string IdentificadorTipoPessoa = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {

                    IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string;

                    objPessoa = (from p in objPessoas where p.Identificador == IdentificadorPessoa select p).FirstOrDefault();

                    if (objPessoa == null)
                    {

                        objPessoas.Add(new Comum.Clases.Pessoa
                        {
                            Identificador = IdentificadorPessoa,
                            cnpj = frmUtil.Util.AtribuirValorObj(dr["DESCNPJ"], typeof(string)) as string,
                            Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODPESSOA"], typeof(int)),
                            cpf = frmUtil.Util.AtribuirValorObj(dr["DESCPF"], typeof(string)) as string,
                            DesNome = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string,
                            Usuario = frmUtil.Util.AtribuirValorObj(dr["CODLOGIN"], typeof(string)) as string,
                            FuncionarioAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLFUNICIONARIOATIVO"], typeof(Boolean))),
                            FornecedorAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLFORNECEDORATIVO"], typeof(Boolean))),
                            SituacaoPessoa = new Comum.Clases.SituacaoPessoa()
                            {
                                Codigo = frmUtil.Util.AtribuirValorObj(dr["CODSITUACAO"], typeof(string)) as string,
                                Descricao = frmUtil.Util.AtribuirValorObj(dr["DESSITUACAO"], typeof(string)) as string
                            },
                            TipoEmpregado = new Comum.Clases.TipoEmpregado()
                            {
                                Identificador = frmUtil.Util.AtribuirValorObj(dr["IDTIPOEMPREGADO"], typeof(string)) as string,
                                Descricao = frmUtil.Util.AtribuirValorObj(dr["DESTIPOEMPREGADO"], typeof(string)) as string
                            },
                            TiposPessoa = new List<Comum.Clases.TipoPessoa>()
                        });

                        objPessoa = (from p in objPessoas where p.Identificador == IdentificadorPessoa select p).FirstOrDefault();

                    }

                    IdentificadorTipoPessoa = frmUtil.Util.AtribuirValorObj(dr["IDTIPOPESSOA"], typeof(string)) as string;

                    if (objPessoa.TiposPessoa.FindAll(tp => tp.Identificador == IdentificadorTipoPessoa).Count == 0)
                    {
                        objPessoa.TiposPessoa.Add(new Comum.Clases.TipoPessoa
                        {
                            Codigo = (Comum.Enumeradores.Enumeradores.TipoPessoaEnum)frmUtil.Util.AtribuirValorObj(dr["CODPESSOA"], typeof(int)),
                            Descricao = frmUtil.Util.AtribuirValorObj(dr["DESTIPOPESSOA"], typeof(string)) as string,
                            Identificador = IdentificadorTipoPessoa
                        });
                    }

                }

            }

            return objPessoas;
        }

        public static string InserirPessoa(Comum.Clases.Pessoa objPessoa, ref Sql objSql)
        {

            string IdentificadorPessoa = Convert.ToString(Guid.NewGuid());
            string sqlCampos = string.Empty;
            string sqlParametros = string.Empty;

            objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa, true);

            if (objPessoa.Endereco == null)
            {
                objSql.AdicionarParametro("IDENDERECO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDENDERECO", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.Identificador));
            }

            if (objPessoa.SituacaoPessoa == null)
            {
                objSql.AdicionarParametro("IDSITUACAOPESSOA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDSITUACAOPESSOA", frmUtil.Util.RetornaDbNull(objPessoa.SituacaoPessoa.Identificador));
            }

            if (objPessoa.PessoaResponsavel == null)
            {
                objSql.AdicionarParametro("IDPESSOARESPONSAVEL", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOARESPONSAVEL", frmUtil.Util.RetornaDbNull(objPessoa.PessoaResponsavel.Identificador));
            }

            if (objPessoa.SegmentoComercial == null)
            {
                objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", frmUtil.Util.RetornaDbNull(objPessoa.SegmentoComercial.Identificador));
            }

            if (objPessoa.EnderecoEmpresa == null)
            {
                objSql.AdicionarParametro("IDENDERECOEMPRESA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDENDERECOEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.Identificador));
            }

            if (objPessoa.Empresa == null)
            {
                objSql.AdicionarParametro("IDEMPRESA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.Empresa.Identificador));
            }

            if (objPessoa.TipoEmpregado == null)
            {
                objSql.AdicionarParametro("IDTIPOEMPREGADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDTIPOEMPREGADO", frmUtil.Util.RetornaDbNull(objPessoa.TipoEmpregado.Identificador));
            }

            objSql.AdicionarParametro("DESNOME", objPessoa.DesNome.ToUpper());
            objSql.AdicionarParametro("DESNOMEFANTASIA", frmUtil.Util.RetornaDbNull(objPessoa.DesNomeFantasia, true));
            objSql.AdicionarParametro("DESRG", frmUtil.Util.RetornaDbNull(objPessoa.RG, true));
            objSql.AdicionarParametro("DTHNASCIMENTO", frmUtil.Util.RetornaDbNull(objPessoa.DataNascimento));
            objSql.AdicionarParametro("DESCPF", frmUtil.Util.RetornaDbNull(objPessoa.cpf));
            objSql.AdicionarParametro("DESCNPJ", frmUtil.Util.RetornaDbNull(objPessoa.cnpj));
            objSql.AdicionarParametro("DTHCADASTRO", DateTime.Now);
            objSql.AdicionarParametro("DESINSCRICAOESTADUAL", frmUtil.Util.RetornaDbNull(objPessoa.InscricaoEstadual, true));
            objSql.AdicionarParametro("DESTELEFONEFIXO", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneFixo));
            objSql.AdicionarParametro("DESTELEFONEFAX", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneFax));
            objSql.AdicionarParametro("DESTELEFONECELULAR", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneCelular));
            objSql.AdicionarParametro("DESHABILITACAO", frmUtil.Util.RetornaDbNull(objPessoa.DesCarteiraHabilitacao, true));
            objSql.AdicionarParametro("NUMCOMISSAO", frmUtil.Util.RetornaDbNull(objPessoa.NumComissao));
            objSql.AdicionarParametro("NUMSALARIO", (decimal)(objPessoa.NumSalario != null ? objPessoa.NumSalario: 0));
            objSql.AdicionarParametro("DTHADMISSAO", frmUtil.Util.RetornaDbNull(objPessoa.DataAdmissao));
            objSql.AdicionarParametro("DESCONTATO", frmUtil.Util.RetornaDbNull(objPessoa.DesContato, true));
            objSql.AdicionarParametro("OBSPESSOA", frmUtil.Util.RetornaDbNull(objPessoa.Observacao, true));
            objSql.AdicionarParametro("NUMLIMITE", frmUtil.Util.RetornaDbNull(objPessoa.NumLimite));
            objSql.AdicionarParametro("DESEMAIL", frmUtil.Util.RetornaDbNull(objPessoa.DesEmail));
            objSql.AdicionarParametro("DESNOMEPAI", frmUtil.Util.RetornaDbNull(objPessoa.DesNomePai, true));
            objSql.AdicionarParametro("DESNOMEMAE", frmUtil.Util.RetornaDbNull(objPessoa.DesNomeMae, true));
            objSql.AdicionarParametro("DESEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.DesEmpresaAnterior, true));
            objSql.AdicionarParametro("DESFONEEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneEmpresaAnterior));
            objSql.AdicionarParametro("DESCARGO", frmUtil.Util.RetornaDbNull(objPessoa.DesCargo, true));
            objSql.AdicionarParametro("OBSREFPESSOAL", frmUtil.Util.RetornaDbNull(objPessoa.ObservacaoRefPessoa, true));
            objSql.AdicionarParametro("DTHALMOCOINICIO", frmUtil.Util.RetornaDbNull(objPessoa.DesHoraAlmocoInicio));
            objSql.AdicionarParametro("DTHALMOCOFIM", frmUtil.Util.RetornaDbNull(objPessoa.DesHoraAlmocoFim));
            objSql.AdicionarParametro("CODLOGIN", frmUtil.Util.RetornaDbNull(objPessoa.Usuario));
            objSql.AdicionarParametro("DESSENHA", frmUtil.Util.RetornaDbNull(objPessoa.DesSenha));
            objSql.AdicionarParametro("CODTABMERCADORIA", frmUtil.Util.RetornaDbNull(objPessoa.NumeroTabelaMercadoria));
            objSql.AdicionarParametro("BOLALTERARSENHA", true);
            objSql.AdicionarParametro("BOLCONSULTOR", objPessoa.Consultor);
            objSql.AdicionarParametro("BOLFUNICIONARIOATIVO", true);
            objSql.AdicionarParametro("BOLFORNECEDORATIVO", frmUtil.Util.RetornaDbNull(objPessoa.FornecedorAtivo));
            objSql.AdicionarParametro("CODTABELAMERCADORIA", frmUtil.Util.RetornaDbNull(objPessoa.NumeroTabelaMercadoria));
            objSql.AdicionarParametro("DESSENHATOUCH", frmUtil.Util.RetornaDbNull(objPessoa.DesSenhaTouch));

            if (objPessoa.Endereco == null)
            {
                objSql.AdicionarParametro("NUMENDERECO", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDER", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESPONTOREFERENCIA", Convert.ToString(DBNull.Value));
            }
            else
            {
                objSql.AdicionarParametro("NUMENDERECO", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.Numero));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDER", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.Complemento, true));
                objSql.AdicionarParametro("DESPONTOREFERENCIA", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.DesReferencia, true));
            }

            if (objPessoa.EnderecoEmpresa == null)
            {
                objSql.AdicionarParametro("NUMENDERECOEMP", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDEREMP", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESPONTOREFERENCIAEMP", Convert.ToString(DBNull.Value));
            }
            else
            {
                objSql.AdicionarParametro("NUMENDERECOEMP", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.Numero));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDEREMP", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.Complemento, true));
                objSql.AdicionarParametro("DESPONTOREFERENCIAEMP", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.DesReferencia, true));
            }

            objSql.AdicionarTransacao(Properties.Resources.PessoaInserir);


            return IdentificadorPessoa;
        }

        public static void AtualizarPessoa(Comum.Clases.Pessoa objPessoa, ref Sql objSql)
        {

            string sqlCampos = string.Empty;
            string sqlParametros = string.Empty;

            objSql.AdicionarParametro("IDPESSOA", objPessoa.Identificador, true);

            if (objPessoa.Endereco == null)
            {
                objSql.AdicionarParametro("IDENDERECO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDENDERECO", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.Identificador));
            }

            if (objPessoa.SituacaoPessoa == null)
            {
                objSql.AdicionarParametro("IDSITUACAOPESSOA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDSITUACAOPESSOA", frmUtil.Util.RetornaDbNull(objPessoa.SituacaoPessoa.Identificador));
            }

            if (objPessoa.PessoaResponsavel == null)
            {
                objSql.AdicionarParametro("IDPESSOARESPONSAVEL", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDPESSOARESPONSAVEL", frmUtil.Util.RetornaDbNull(objPessoa.PessoaResponsavel.Identificador));
            }

            if (objPessoa.SegmentoComercial == null)
            {
                objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDSEGMENTOCOMERCIAL", frmUtil.Util.RetornaDbNull(objPessoa.SegmentoComercial.Identificador));
            }

            if (objPessoa.EnderecoEmpresa == null)
            {
                objSql.AdicionarParametro("IDENDERECOEMPRESA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDENDERECOEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.Identificador));
            }

            if (objPessoa.Empresa == null)
            {
                objSql.AdicionarParametro("IDEMPRESA", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.Empresa.Identificador));
            }

            if (objPessoa.TipoEmpregado == null)
            {
                objSql.AdicionarParametro("IDTIPOEMPREGADO", DBNull.Value);
            }
            else
            {
                objSql.AdicionarParametro("IDTIPOEMPREGADO", frmUtil.Util.RetornaDbNull(objPessoa.TipoEmpregado.Identificador));
            }

            objSql.AdicionarParametro("DESNOME", objPessoa.DesNome.ToUpper());
            objSql.AdicionarParametro("DESNOMEFANTASIA", frmUtil.Util.RetornaDbNull(objPessoa.DesNomeFantasia, true));
            objSql.AdicionarParametro("DESRG", frmUtil.Util.RetornaDbNull(objPessoa.RG, true));
            objSql.AdicionarParametro("DTHNASCIMENTO", frmUtil.Util.RetornaDbNull(objPessoa.DataNascimento));
            objSql.AdicionarParametro("DESCPF", frmUtil.Util.RetornaDbNull(objPessoa.cpf));
            objSql.AdicionarParametro("DESCNPJ", frmUtil.Util.RetornaDbNull(objPessoa.cnpj));
            objSql.AdicionarParametro("DTHCADASTRO", DateTime.Now);
            objSql.AdicionarParametro("BOLCONSULTOR", objPessoa.Consultor);
            objSql.AdicionarParametro("DESINSCRICAOESTADUAL", frmUtil.Util.RetornaDbNull(objPessoa.InscricaoEstadual, true));
            objSql.AdicionarParametro("DESTELEFONEFIXO", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneFixo));
            objSql.AdicionarParametro("DESTELEFONEFAX", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneFax));
            objSql.AdicionarParametro("DESTELEFONECELULAR", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneCelular));
            objSql.AdicionarParametro("DESHABILITACAO", frmUtil.Util.RetornaDbNull(objPessoa.DesCarteiraHabilitacao, true));
            objSql.AdicionarParametro("NUMCOMISSAO", frmUtil.Util.RetornaDbNull(objPessoa.NumComissao));
            objSql.AdicionarParametro("NUMSALARIO", frmUtil.Util.RetornaDbNull(objPessoa.NumSalario));
            objSql.AdicionarParametro("DTHADMISSAO", frmUtil.Util.RetornaDbNull(objPessoa.DataAdmissao));
            objSql.AdicionarParametro("DESCONTATO", frmUtil.Util.RetornaDbNull(objPessoa.DesContato, true));
            objSql.AdicionarParametro("OBSPESSOA", frmUtil.Util.RetornaDbNull(objPessoa.Observacao, true));
            objSql.AdicionarParametro("NUMLIMITE", frmUtil.Util.RetornaDbNull(objPessoa.NumLimite));
            objSql.AdicionarParametro("DESEMAIL", frmUtil.Util.RetornaDbNull(objPessoa.DesEmail));
            objSql.AdicionarParametro("DESNOMEPAI", frmUtil.Util.RetornaDbNull(objPessoa.DesNomePai, true));
            objSql.AdicionarParametro("DESNOMEMAE", frmUtil.Util.RetornaDbNull(objPessoa.DesNomeMae, true));
            objSql.AdicionarParametro("DESEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.DesEmpresaAnterior, true));
            objSql.AdicionarParametro("DESFONEEMPRESA", frmUtil.Util.RetornaDbNull(objPessoa.DesTelefoneEmpresaAnterior));
            objSql.AdicionarParametro("DESCARGO", frmUtil.Util.RetornaDbNull(objPessoa.DesCargo, true));
            objSql.AdicionarParametro("OBSREFPESSOAL", frmUtil.Util.RetornaDbNull(objPessoa.ObservacaoRefPessoa, true));
            objSql.AdicionarParametro("DTHALMOCOINICIO", frmUtil.Util.RetornaDbNull(objPessoa.DesHoraAlmocoInicio));
            objSql.AdicionarParametro("DTHALMOCOFIM", frmUtil.Util.RetornaDbNull(objPessoa.DesHoraAlmocoFim));
            objSql.AdicionarParametro("CODTABMERCADORIA", frmUtil.Util.RetornaDbNull(objPessoa.NumeroTabelaMercadoria));
            objSql.AdicionarParametro("BOLFUNICIONARIOATIVO", frmUtil.Util.RetornaDbNull(objPessoa.FuncionarioAtivo));
            objSql.AdicionarParametro("BOLFORNECEDORATIVO", frmUtil.Util.RetornaDbNull(objPessoa.FornecedorAtivo));
            objSql.AdicionarParametro("CODTABELAMERCADORIA", frmUtil.Util.RetornaDbNull(objPessoa.NumeroTabelaMercadoria));
            objSql.AdicionarParametro("CODLOGIN", frmUtil.Util.RetornaDbNull(objPessoa.Usuario));
            objSql.AdicionarParametro("DESSENHATOUCH", frmUtil.Util.RetornaDbNull(objPessoa.DesSenhaTouch));

            if (objPessoa.Endereco == null)
            {
                objSql.AdicionarParametro("NUMENDERECO", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDER", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESPONTOREFERENCIA", Convert.ToString(DBNull.Value));
            }
            else
            {
                objSql.AdicionarParametro("NUMENDERECO", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.Numero));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDER", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.Complemento, true));
                objSql.AdicionarParametro("DESPONTOREFERENCIA", frmUtil.Util.RetornaDbNull(objPessoa.Endereco.DesReferencia, true));
            }

            if (objPessoa.EnderecoEmpresa == null)
            {
                objSql.AdicionarParametro("NUMENDERECOEMP", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDEREMP", Convert.ToString(DBNull.Value));
                objSql.AdicionarParametro("DESPONTOREFERENCIAEMP", Convert.ToString(DBNull.Value));
            }
            else
            {
                objSql.AdicionarParametro("NUMENDERECOEMP", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.Numero));
                objSql.AdicionarParametro("DESCOMPLEMENTOENDEREMP", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.Complemento, true));
                objSql.AdicionarParametro("DESPONTOREFERENCIAEMP", frmUtil.Util.RetornaDbNull(objPessoa.EnderecoEmpresa.DesReferencia, true));
            }

            objSql.AdicionarTransacao(Properties.Resources.PessoaAtualizar);

        }

        public static Comum.Clases.Pessoa RecuperarPessoa(string IdentificadorPessoa)
        {

            if (string.IsNullOrEmpty(IdentificadorPessoa))
            {
                return null;
            }
            Comum.Clases.Pessoa objPessoa = null;

            Sql objSql = new Sql();

            objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PessoaRecuperar, Comum.Clases.Constantes.ARQUIVO_CONEXAO);


            if (dt != null && dt.Rows.Count > 0)
            {

                string IdentificadorPessoaResponsavel = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOARESPONSAVEL"], typeof(string)) as string;
                string IdentificadorEndereco = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDENDERECO"], typeof(string)) as string;
                string IdentificadorEnderecoEmpresa = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDENDERECOEMPRESA"], typeof(string)) as string;
                string IdentificadorTipoEmpregado = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDTIPOEMPREGADO"], typeof(string)) as string;
                objPessoa = new Comum.Clases.Pessoa();
                objPessoa.cnpj = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCNPJ"], typeof(string)) as string;
                objPessoa.Codigo = (int)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPESSOA"], typeof(int)));
                objPessoa.cpf = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCPF"], typeof(string)) as string;
                objPessoa.RG = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESRG"], typeof(string)) as string;
                objPessoa.DataAdmissao = (Nullable<DateTime>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHADMISSAO"], typeof(Nullable<DateTime>)));
                objPessoa.DataNascimento = (Nullable<DateTime>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHNASCIMENTO"], typeof(Nullable<DateTime>)));
                objPessoa.DesCargo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCARGO"], typeof(string)) as string;
                objPessoa.DesCarteiraHabilitacao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESHABILITACAO"], typeof(string)) as string;
                objPessoa.DesContato = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCONTATO"], typeof(string)) as string;
                objPessoa.DesEmail = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESEMAIL"], typeof(string)) as string;
                objPessoa.DesEmpresaAnterior = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESEMPRESA"], typeof(string)) as string;
                objPessoa.DesHoraAlmocoFim = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHALMOCOFIM"], typeof(string)) as string;
                objPessoa.DesHoraAlmocoInicio = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DTHALMOCOINICIO"], typeof(string)) as string;
                objPessoa.DesNome = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESNOME"], typeof(string)) as string;
                objPessoa.DesNomeFantasia = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESNOMEFANTASIA"], typeof(string)) as string;
                objPessoa.DesNomeMae = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESNOMEMAE"], typeof(string)) as string;
                objPessoa.DesNomePai = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESNOMEPAI"], typeof(string)) as string;
                objPessoa.DesTelefoneCelular = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTELEFONECELULAR"], typeof(string)) as string;
                objPessoa.DesTelefoneEmpresaAnterior = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESFONEEMPRESA"], typeof(string)) as string;
                objPessoa.DesTelefoneFax = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTELEFONEFAX"], typeof(string)) as string;
                objPessoa.DesTelefoneFixo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTELEFONEFIXO"], typeof(string)) as string;
                objPessoa.DesSenhaTouch = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESSENHATOUCH"], typeof(string)) as string;

                if (!string.IsNullOrEmpty(IdentificadorTipoEmpregado))
                {
                    objPessoa.TipoEmpregado = new Comum.Clases.TipoEmpregado();
                    objPessoa.TipoEmpregado.Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDTIPOEMPREGADO"], typeof(string)) as string;
                }

                objPessoa.Empresa = null;
                objPessoa.EnderecoCompletoEmpresa = (!string.IsNullOrEmpty(IdentificadorEnderecoEmpresa) ? Endereco.RecuperarEndereco(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, IdentificadorEnderecoEmpresa) : null); ;
                objPessoa.EnderecoCompleto = (!string.IsNullOrEmpty(IdentificadorEndereco) ? Endereco.RecuperarEndereco(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, IdentificadorEndereco) : null);

                if (objPessoa.EnderecoCompleto != null)
                {

                    objPessoa.EnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().Complemento = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCOMPLEMENTOENDER"], typeof(string)) as string;
                    objPessoa.EnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().DesReferencia = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPONTOREFERENCIA"], typeof(string)) as string;
                    objPessoa.EnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().Numero = (Nullable<int>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMENDERECO"], typeof(int)));
                }

                if (objPessoa.EnderecoCompletoEmpresa != null)
                {

                    objPessoa.EnderecoCompletoEmpresa.Cidades.First().Bairros.First().Enderecos.First().Complemento = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESCOMPLEMENTOENDEREMP"], typeof(string)) as string;
                    objPessoa.EnderecoCompletoEmpresa.Cidades.First().Bairros.First().Enderecos.First().DesReferencia = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESPONTOREFERENCIAEMP"], typeof(string)) as string;
                    objPessoa.EnderecoCompletoEmpresa.Cidades.First().Bairros.First().Enderecos.First().Numero = (Nullable<int>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMENDERECOEMP"], typeof(int)));
                }

                objPessoa.FornecedorAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLFORNECEDORATIVO"], typeof(Boolean)));
                objPessoa.Consultor = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLCONSULTOR"], typeof(Boolean)));
                objPessoa.FuncionarioAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLFUNICIONARIOATIVO"], typeof(Boolean)));
                objPessoa.Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOA"], typeof(string)) as string;
                objPessoa.Filiais = FilialPessoa.RecuperarFiliaisPessoa(objPessoa.Identificador);
                objPessoa.HorarioTrabalho = HoraTrabalho.RecuperarHoraTrabalho(objPessoa.Identificador);
                objPessoa.InscricaoEstadual = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESINSCRICAOESTADUAL"], typeof(string)) as string;
                objPessoa.NumComissao = (Nullable<Decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMCOMISSAO"], typeof(Decimal)));
                objPessoa.NumLimite = (Nullable<Decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMLIMITE"], typeof(Decimal)));
                objPessoa.NumSalario = (Nullable<Decimal>)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["NUMSALARIO"], typeof(Decimal)));
                objPessoa.Observacao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["OBSPESSOA"], typeof(string)) as string;
                objPessoa.ObservacaoRefPessoa = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["OBSREFPESSOAL"], typeof(string)) as string;
                objPessoa.PessoaResponsavel = (!string.IsNullOrEmpty(IdentificadorPessoaResponsavel) ? RecuperarPessoa(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOARESPONSAVEL"], typeof(string)) as string) : null);

                string IdentificadorSegmento = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDSEGMENTOCOMERCIAL"], typeof(string)) as string;

                if (!string.IsNullOrEmpty(IdentificadorSegmento))
                {
                    objPessoa.SegmentoComercial = SegmentoComercial.RecuperarSegmentoComercialItem(IdentificadorSegmento);
                }

                string IdentificadorSituacao = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDSITUACAOPESSOA"], typeof(string)) as string;

                if (!string.IsNullOrEmpty(IdentificadorSituacao))
                {
                    objPessoa.SituacaoPessoa = SituacaoPessoa.RecuperarSituacaoPessoa(IdentificadorSituacao).FirstOrDefault();
                }

                objPessoa.TiposPessoa = null;
                objPessoa.Usuario = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLOGIN"], typeof(string)) as string;


            }
            return objPessoa;

        }

        public static List<Comum.Clases.Pessoa> RecuperarPessoas(List<string> IdentificadoresPessoa)
        {

            if (IdentificadoresPessoa == null)
            {
                return null;
            }

            List<Comum.Clases.Pessoa> objPessoas = null;

            Sql objSql = new Sql();
            string objQuery = string.Empty;

            ParametroColecao objParametros = null;

            objQuery += frmUtil.Util.MontarClausulaIn(IdentificadoresPessoa, "IDPESSOA", ref objParametros, "WHERE", "P");

            if (objParametros != null && objParametros.Count > 0)
            {
                foreach (AmgSistemas.Framework.AcessoDados.Parametro objParametro in objParametros)
                {
                    objSql.AdicionarParametro(objParametro.Campo, objParametro.Valor);
                }
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PessoaRecuperarPessoas + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);


            if (dt != null && dt.Rows.Count > 0)
            {

                objPessoas = new List<Comum.Clases.Pessoa>();

                foreach (DataRow dr in dt.Rows)
                {
                    string IdentificadorPessoaResponsavel = frmUtil.Util.AtribuirValorObj(dr["IDPESSOARESPONSAVEL"], typeof(string)) as string;
                    string IdentificadorEndereco = frmUtil.Util.AtribuirValorObj(dr["IDENDERECO"], typeof(string)) as string;
                    string IdentificadorEnderecoEmpresa = frmUtil.Util.AtribuirValorObj(dr["IDENDERECOEMPRESA"], typeof(string)) as string;
                    Comum.Clases.Estado objEnderecoCompleto = (!string.IsNullOrEmpty(IdentificadorEndereco) ? Endereco.RecuperarEndereco(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, IdentificadorEndereco) : null);
                    Comum.Clases.Estado objEnderecoCompletoEmpresa = (!string.IsNullOrEmpty(IdentificadorEnderecoEmpresa) ? Endereco.RecuperarEndereco(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, IdentificadorEnderecoEmpresa) : null);
                    string IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string;
                    string IdentificadorSegmento = frmUtil.Util.AtribuirValorObj(dr["IDSEGMENTOCOMERCIAL"], typeof(string)) as string;
                    string IdentificadorSituacao = frmUtil.Util.AtribuirValorObj(dr["IDSITUACAOPESSOA"], typeof(string)) as string;

                    if (objEnderecoCompleto != null)
                    {

                        objEnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().Complemento = frmUtil.Util.AtribuirValorObj(dr["DESCOMPLEMENTOENDER"], typeof(string)) as string;
                        objEnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().DesReferencia = frmUtil.Util.AtribuirValorObj(dr["DESPONTOREFERENCIA"], typeof(string)) as string;
                        objEnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().Numero = (Nullable<int>)(frmUtil.Util.AtribuirValorObj(dr["NUMENDERECO"], typeof(int)));
                    }

                    if (objEnderecoCompletoEmpresa != null)
                    {

                        objEnderecoCompletoEmpresa.Cidades.First().Bairros.First().Enderecos.First().Complemento = frmUtil.Util.AtribuirValorObj(dr["DESCOMPLEMENTOENDEREMP"], typeof(string)) as string;
                        objEnderecoCompletoEmpresa.Cidades.First().Bairros.First().Enderecos.First().DesReferencia = frmUtil.Util.AtribuirValorObj(dr["DESPONTOREFERENCIAEMP"], typeof(string)) as string;
                        objEnderecoCompletoEmpresa.Cidades.First().Bairros.First().Enderecos.First().Numero = (Nullable<int>)(frmUtil.Util.AtribuirValorObj(dr["NUMENDERECOEMP"], typeof(int)));
                    }

                    objPessoas.Add(new Comum.Clases.Pessoa
                    {
                        cnpj = frmUtil.Util.AtribuirValorObj(dr["DESCNPJ"], typeof(string)) as string,
                        Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODPESSOA"], typeof(int))),
                        cpf = frmUtil.Util.AtribuirValorObj(dr["DESCPF"], typeof(string)) as string,
                        RG = frmUtil.Util.AtribuirValorObj(dr["DESRG"], typeof(string)) as string,
                        DataAdmissao = (Nullable<DateTime>)(frmUtil.Util.AtribuirValorObj(dr["DTHADMISSAO"], typeof(Nullable<DateTime>))),
                        DataNascimento = (Nullable<DateTime>)(frmUtil.Util.AtribuirValorObj(dr["DTHNASCIMENTO"], typeof(Nullable<DateTime>))),
                        DesCargo = frmUtil.Util.AtribuirValorObj(dr["DESCARGO"], typeof(string)) as string,
                        DesCarteiraHabilitacao = frmUtil.Util.AtribuirValorObj(dr["DESHABILITACAO"], typeof(string)) as string,
                        DesContato = frmUtil.Util.AtribuirValorObj(dr["DESCONTATO"], typeof(string)) as string,
                        DesEmail = frmUtil.Util.AtribuirValorObj(dr["DESEMAIL"], typeof(string)) as string,
                        DesEmpresaAnterior = frmUtil.Util.AtribuirValorObj(dr["DESEMPRESA"], typeof(string)) as string,
                        DesHoraAlmocoFim = frmUtil.Util.AtribuirValorObj(dr["DTHALMOCOFIM"], typeof(string)) as string,
                        DesHoraAlmocoInicio = frmUtil.Util.AtribuirValorObj(dr["DTHALMOCOINICIO"], typeof(string)) as string,
                        DesNome = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string,
                        DesNomeFantasia = frmUtil.Util.AtribuirValorObj(dr["DESNOMEFANTASIA"], typeof(string)) as string,
                        DesNomeMae = frmUtil.Util.AtribuirValorObj(dr["DESNOMEMAE"], typeof(string)) as string,
                        DesNomePai = frmUtil.Util.AtribuirValorObj(dr["DESNOMEPAI"], typeof(string)) as string,
                        DesTelefoneCelular = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONECELULAR"], typeof(string)) as string,
                        DesTelefoneEmpresaAnterior = frmUtil.Util.AtribuirValorObj(dr["DESFONEEMPRESA"], typeof(string)) as string,
                        DesTelefoneFax = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFAX"], typeof(string)) as string,
                        DesTelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFIXO"], typeof(string)) as string,
                        Empresa = null,
                        EnderecoCompletoEmpresa = objEnderecoCompletoEmpresa,
                        EnderecoCompleto = objEnderecoCompleto,
                        FornecedorAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLFORNECEDORATIVO"], typeof(Boolean))),
                        Consultor = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLCONSULTOR"], typeof(Boolean))),
                        FuncionarioAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLFUNICIONARIOATIVO"], typeof(Boolean))),
                        Identificador = IdentificadorPessoa,
                        Filiais = FilialPessoa.RecuperarFiliaisPessoa(IdentificadorPessoa),
                        HorarioTrabalho = HoraTrabalho.RecuperarHoraTrabalho(IdentificadorPessoa),
                        InscricaoEstadual = frmUtil.Util.AtribuirValorObj(dr["DESINSCRICAOESTADUAL"], typeof(string)) as string,
                        NumComissao = (Nullable<Decimal>)(frmUtil.Util.AtribuirValorObj(dr["NUMCOMISSAO"], typeof(Decimal))),
                        NumLimite = (Nullable<Decimal>)(frmUtil.Util.AtribuirValorObj(dr["NUMLIMITE"], typeof(Decimal))),
                        NumSalario = (Nullable<Decimal>)(frmUtil.Util.AtribuirValorObj(dr["NUMSALARIO"], typeof(Decimal))),
                        Observacao = frmUtil.Util.AtribuirValorObj(dr["OBSPESSOA"], typeof(string)) as string,
                        ObservacaoRefPessoa = frmUtil.Util.AtribuirValorObj(dr["OBSREFPESSOAL"], typeof(string)) as string,
                        PessoaResponsavel = (!string.IsNullOrEmpty(IdentificadorPessoaResponsavel) ? RecuperarPessoa(frmUtil.Util.AtribuirValorObj(dr["IDPESSOARESPONSAVEL"], typeof(string)) as string) : null),
                        SegmentoComercial = SegmentoComercial.RecuperarSegmentoComercialItem(IdentificadorSegmento),
                        SituacaoPessoa = SituacaoPessoa.RecuperarSituacaoPessoa(IdentificadorSituacao).FirstOrDefault(),
                        TiposPessoa = null,
                        Usuario = frmUtil.Util.AtribuirValorObj(dr["CODLOGIN"], typeof(string)) as string

                    });

                }

            }
            return objPessoas;
        }

        public static List<Comum.Clases.Pessoa> RecuperarPessoasSimples(List<string> IdentificadoresPessoa)
        {

            if (IdentificadoresPessoa == null)
            {
                return null;
            }

            List<Comum.Clases.Pessoa> objPessoas = null;

            Sql objSql = new Sql();
            string objQuery = string.Empty;

            ParametroColecao objParametros = null;

            objQuery += frmUtil.Util.MontarClausulaIn(IdentificadoresPessoa, "IDPESSOA", ref objParametros, "WHERE", "P");

            if (objParametros != null && objParametros.Count > 0)
            {
                foreach (AmgSistemas.Framework.AcessoDados.Parametro objParametro in objParametros)
                {
                    objSql.AdicionarParametro(objParametro.Campo, objParametro.Valor);
                }
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.PessoaRecuperarPessoasSimples + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);


            if (dt != null && dt.Rows.Count > 0)
            {

                objPessoas = new List<Comum.Clases.Pessoa>();

                foreach (DataRow dr in dt.Rows)
                {
                    string IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string;


                    objPessoas.Add(new Comum.Clases.Pessoa
                    {
                        Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODPESSOA"], typeof(int))),
                        DesNome = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string,
                        Consultor = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLCONSULTOR"], typeof(Boolean))),
                        Identificador = IdentificadorPessoa,
                        Usuario = frmUtil.Util.AtribuirValorObj(dr["CODLOGIN"], typeof(string)) as string

                    });

                }

            }
            return objPessoas;
        }

        public static List<Comum.Clases.Pessoa> PreencherPessoaSimples(DataTable dt)
        {
            List<Comum.Clases.Pessoa> objPessoas = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                objPessoas = new List<Comum.Clases.Pessoa>();

                foreach (DataRow dr in dt.Rows)
                {
                    string IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string;


                    objPessoas.Add(new Comum.Clases.Pessoa
                    {
                        Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODPESSOA"], typeof(int))),
                        DesNome = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string,
                        Consultor = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLCONSULTOR"], typeof(Boolean))),
                        Identificador = IdentificadorPessoa,
                        Usuario = frmUtil.Util.AtribuirValorObj(dr["CODLOGIN"], typeof(string)) as string,
                        DesTelefoneCelular = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONECELULAR"], typeof(string)) as string,
                        DesTelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFIXO"], typeof(string)) as string

                    });

                }

            }
            return objPessoas;
        }

        public static List<Comum.Clases.Pessoa> PreencherPessoaSimples(DataTable dt, string IdentificadorCrm)
        {
            List<Comum.Clases.Pessoa> objPessoas = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                objPessoas = new List<Comum.Clases.Pessoa>();

                foreach (DataRow dr in (from DataRow dr1 in dt.Rows where frmUtil.Util.AtribuirValorObj(dr1["IDPESSOACRM"], typeof(string)) as string == IdentificadorCrm select dr1))
                {
                    string IdentificadorPessoa = frmUtil.Util.AtribuirValorObj(dr["IDPESSOA"], typeof(string)) as string;


                    objPessoas.Add(new Comum.Clases.Pessoa
                    {
                        Codigo = (int)(frmUtil.Util.AtribuirValorObj(dr["CODPESSOA"], typeof(int))),
                        DesNome = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string,
                        Consultor = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLCONSULTOR"], typeof(Boolean))),
                        Identificador = IdentificadorPessoa,
                        Usuario = frmUtil.Util.AtribuirValorObj(dr["CODLOGIN"], typeof(string)) as string,
                        DesTelefoneCelular = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONECELULAR"], typeof(string)) as string,
                        DesTelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFIXO"], typeof(string)) as string

                    });

                }

            }
            return objPessoas;
        }

        public static Comum.Clases.Pessoa PreencherPessoaSimplesV2(DataTable dt)
        {
            Comum.Clases.Pessoa objPessoa = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                objPessoa = new Comum.Clases.Pessoa();

                objPessoa = new Comum.Clases.Pessoa
                {
                    Codigo = (int)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODPESSOA"], typeof(int))),
                    DesNome = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESNOME"], typeof(string)) as string,
                    Consultor = (Boolean)(frmUtil.Util.AtribuirValorObj(dt.Rows[0]["BOLCONSULTOR"], typeof(Boolean))),
                    Identificador = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["IDPESSOA"], typeof(string)) as string,
                    Usuario = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["CODLOGIN"], typeof(string)) as string,
                    DesTelefoneCelular = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTELEFONECELULAR"], typeof(string)) as string,
                    DesTelefoneFixo = frmUtil.Util.AtribuirValorObj(dt.Rows[0]["DESTELEFONEFIXO"], typeof(string)) as string

                };

            }
            return objPessoa;
        }

        public static Boolean ValidarLoginExiste(string Login, string IdentificadorPessoa, Boolean UtilizarArquivoConexao)
        {

            Sql objSql = new Sql();
            string objQuery = string.Empty;

            objSql.AdicionarParametro("CODLOGIN", Login);

            if (!string.IsNullOrEmpty(IdentificadorPessoa))
            {

                objQuery = " AND IDPESSOA <> @IDPESSOA ";
                objSql.AdicionarParametro("IDPESSOA", IdentificadorPessoa);
            }

            Object resultado = null;

            if (UtilizarArquivoConexao)
            {
                resultado = objSql.ExecutarScalarArquivo(Properties.Resources.PessoaValidarLoginExiste + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);
            }
            else
            {
                resultado = objSql.ExecutarScalar(Properties.Resources.PessoaValidarLoginExiste + objQuery, Comum.Clases.Constantes.STRING_CONEXAO);
            }


            int NelResultado = (resultado != null ? (int)(resultado) : 0);

            Boolean Existe = (NelResultado != 0 ? true : false);

            return Existe;
        }
    }
}
