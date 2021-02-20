using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using System.Data;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Relatorio
    {

        public static List<Comum.Clases.Relatorios.RelatorioEstoque> RecuperarItensRelatorioEstoque(string IdentificadorFilial,
                                                                                                    string IdentificadorProduto,
                                                                                                    string IdentificadorEmpresa)
        {

            List<Comum.Clases.Relatorios.RelatorioEstoque> Produtos = null;

            Sql objSql = new Sql();
            string objQuery = string.Empty;

            if (!string.IsNullOrEmpty(IdentificadorFilial))
            {
                objQuery = " AND F.IDFILIAL = @IDFILIAL ";
                objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
            }

            if (!string.IsNullOrEmpty(IdentificadorProduto))
            {
                objQuery += " AND PS.IDPRODUTOSERVICO = @IDPRODUTOSERVICO ";
                objSql.AdicionarParametro("IDPRODUTOSERVICO", IdentificadorProduto);
            }

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);

            DataTable dt = objSql.ExecutarDataTableArquivo(string.Format(Properties.Resources.RelatorioEstoqueRecuperar, objQuery), Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                Produtos = new List<Comum.Clases.Relatorios.RelatorioEstoque>();

                foreach (DataRow dr in dt.Rows)
                {
                    Produtos.Add(new Comum.Clases.Relatorios.RelatorioEstoque()
                    {
                        Codigo = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODPRODUTO"], typeof(Int32))),
                        CodigoBarras = frmUtil.Util.AtribuirValorObj(dr["DESCODBARRAS"], typeof(string)) as string,
                        CodigoFilial = (Int32)(frmUtil.Util.AtribuirValorObj(dr["CODFILIAL"], typeof(Int32))),
                        Descricao = frmUtil.Util.AtribuirValorObj(dr["DESPRODUTO"], typeof(string)) as string,
                        DescricaoFilial = frmUtil.Util.AtribuirValorObj(dr["DESFILIAL"], typeof(string)) as string,
                        Email = frmUtil.Util.AtribuirValorObj(dr["DESEMAIL"], typeof(string)) as string,
                        TelefoneCelular = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONECEL"], typeof(string)) as string,
                        TelefoneFax = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFAX"], typeof(string)) as string,
                        TelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFIXO"], typeof(string)) as string,
                        Estoque = (decimal)(frmUtil.Util.AtribuirValorObj(dr["ESTOQUE"], typeof(decimal)))
                    });

                }
            }

            return Produtos;
        }


        public static List<Comum.Clases.Relatorios.RelatorioPessoas> RecuperarPessoas(string IdentificadorFilial,
                                                                              string IdentificadorEmpresa,
                                                                              string Nome,
                                                                              string CPF,
                                                                              string CNPJ,
                                                                              string IdentificadortipoPessoa)
        {

            List<Comum.Clases.Relatorios.RelatorioPessoas> objPessoas = null;

            Sql objSql = new Sql();
            string objQuery = string.Empty;

            objSql.AdicionarParametro("IDEMPRESA", IdentificadorEmpresa);
            objSql.AdicionarParametro("IDTIPOPESSOA", IdentificadortipoPessoa);

            if (!string.IsNullOrEmpty(IdentificadorFilial))
            {
                objQuery += " AND F.IDFILIAL = @IDFILIAL ";
                objSql.AdicionarParametro("IDFILIAL", IdentificadorFilial);
            }

            if (!string.IsNullOrEmpty(Nome))
            {
                objQuery += " AND P.DESNOME LIKE @DESNOME ";
                objSql.AdicionarParametro("DESNOME","%" + Nome + "%");
            }

            if (!string.IsNullOrEmpty(CPF))
            {
                objQuery += " AND P.DESCPF = @DESCPF ";
                objSql.AdicionarParametro("DESCPF", CPF);
            }

            if (!string.IsNullOrEmpty(CNPJ))
            {
                objQuery += " AND P.DESCNPJ = @DESCNPJ ";
                objSql.AdicionarParametro("DESCNPJ", CNPJ);
            }

            DataTable dt = objSql.ExecutarDataTableArquivo(Properties.Resources.RelatorioPessoaRecuperar + objQuery, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                
                objPessoas = new List<Comum.Clases.Relatorios.RelatorioPessoas>();
                Comum.Clases.Relatorios.RelatorioPessoas objPessoa = null;

                foreach (DataRow dr in dt.Rows)
                {
                    objPessoa = new Comum.Clases.Relatorios.RelatorioPessoas();

                         objPessoa.Bairro = frmUtil.Util.AtribuirValorObj(dr["DESBAIRRO"], typeof(string)) as string;
                        objPessoa.Cargo = frmUtil.Util.AtribuirValorObj(dr["DESCARGO"], typeof(string)) as string;
                        objPessoa.Cidade = frmUtil.Util.AtribuirValorObj(dr["DESCIDADE"], typeof(string)) as string;
                        objPessoa.CNPJ = frmUtil.Util.AtribuirValorObj(dr["DESCIDADE"], typeof(string)) as string;

                    if(frmUtil.Util.AtribuirValorObj2(dr["NUMCOMISSAO"], typeof(Nullable<decimal>),true) != null)
                    {
                        objPessoa.Comissao = (decimal)(frmUtil.Util.AtribuirValorObj2(dr["NUMCOMISSAO"], typeof(decimal),true));
                    }
                        objPessoa.CPF = frmUtil.Util.AtribuirValorObj(dr["DESCPF"], typeof(string)) as string;

                    if(frmUtil.Util.AtribuirValorObj2(dr["DTHADMISSAO"], typeof(Nullable<DateTime>),true) != null)
                    {
                        objPessoa.DataAdmissao = (DateTime)(frmUtil.Util.AtribuirValorObj2(dr["DTHADMISSAO"], typeof(DateTime),true));
                    }

                    if(frmUtil.Util.AtribuirValorObj2(dr["DTHNASCIMENTO"], typeof(Nullable<DateTime>),true) != null)
                    {
                        objPessoa.DataNascimento = (DateTime)(frmUtil.Util.AtribuirValorObj2(dr["DTHNASCIMENTO"], typeof(DateTime),true));
                    }
                    
                        objPessoa.Email = frmUtil.Util.AtribuirValorObj(dr["DESEMAIL"], typeof(string)) as string;
                        objPessoa.EmpresaTrabalha = frmUtil.Util.AtribuirValorObj(dr["DESEMPRESA"], typeof(string)) as string;
                        objPessoa.Endereco = frmUtil.Util.AtribuirValorObj(dr["DESRUA"], typeof(string)) as string;
                        objPessoa.Estado = frmUtil.Util.AtribuirValorObj(dr["DESESTADO"], typeof(string)) as string;
                        objPessoa.Fax = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFAX"], typeof(string)) as string;
                        objPessoa.FornecedorAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLFORNECEDORATIVO"], typeof(Boolean)));
                        objPessoa.FuncionarioAtivo = (Boolean)(frmUtil.Util.AtribuirValorObj(dr["BOLFUNICIONARIOATIVO"], typeof(Boolean)));
                        objPessoa.LimiteCredito = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj2(dr["NUMLIMITE"], typeof(Nullable<decimal>),true));
                        objPessoa.Nome = frmUtil.Util.AtribuirValorObj(dr["DESNOME"], typeof(string)) as string;
                        objPessoa.NomeFantasia = frmUtil.Util.AtribuirValorObj(dr["DESNOMEFANTASIA"], typeof(string)) as string;
                        objPessoa.Numero = (Nullable<Int32>)(frmUtil.Util.AtribuirValorObj(dr["NUMENDERECO"], typeof(Nullable<Int32>)));
                        objPessoa.RG = frmUtil.Util.AtribuirValorObj(dr["DESRG"], typeof(string)) as string;
                        objPessoa.Salario = (Nullable<decimal>)(frmUtil.Util.AtribuirValorObj2(dr["NUMSALARIO"], typeof(Nullable<decimal>),true));
                        objPessoa.SegmentoComercial = frmUtil.Util.AtribuirValorObj(dr["DESSEGMENTOCOMERCIAL"], typeof(string)) as string;
                        objPessoa.SituacaoCliente = frmUtil.Util.AtribuirValorObj(dr["DESSITUACAO"], typeof(string)) as string;
                        objPessoa.TelefoneCelular = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONECELULAR"], typeof(string)) as string;
                        objPessoa.TelefoneFixo = frmUtil.Util.AtribuirValorObj(dr["DESTELEFONEFIXO"], typeof(string)) as string;
                        objPessoa.Usuario = frmUtil.Util.AtribuirValorObj(dr["CODLOGIN"], typeof(string)) as string;
                        objPessoa.CEP = frmUtil.Util.AtribuirValorObj(dr["CODCEP"], typeof(string)) as string;

                    objPessoas.Add(objPessoa);

                               
                }
            }
            return objPessoas;
        }
    }
}
