using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Data;

namespace Informatiz.ControleEstoque.AcessoDados.Classes
{
    public class Endereco
    {

        #region "Consultas"

        public static Comum.Clases.Estado RecuperarEndereco(string Cep, string IdentificadorEstado, string IdentificadorCidade, string IdentificadorBairro,
                                                            string Rua, string RuaPesquisar, string IdentificadorEndereco)
        {

            Sql objFrm = new Sql();

            string objSql = string.Empty;

            if (!string.IsNullOrEmpty(Cep) || !string.IsNullOrEmpty(IdentificadorEndereco))
            {

                if (!string.IsNullOrEmpty(Cep))
                {
                    objSql = " WHERE  E.CODCEP = @CODCEP ";
                    objFrm.AdicionarParametro("CODCEP", Cep);
                }
                else
                {
                    objSql = " WHERE  E.IDENDERECO = @IDENDERECO ";
                    objFrm.AdicionarParametro("IDENDERECO", IdentificadorEndereco);
                }
            }
            else
            {

                if (!string.IsNullOrEmpty(IdentificadorEstado))
                {

                    objSql = " WHERE EST.IDESTADO = @IDESTADO ";
                    objFrm.AdicionarParametro("IDESTADO", IdentificadorEstado);
                }

                if (!string.IsNullOrEmpty(IdentificadorCidade))
                {

                    if (objSql.Length > 0)
                    {
                        objSql += " AND ";
                    }
                    else
                    {
                        objSql = " WHERE ";
                    }

                    objSql += " C.IDCIDADE = @IDCIDADE ";
                    objFrm.AdicionarParametro("IDCIDADE", IdentificadorCidade);
                }

                if (!string.IsNullOrEmpty(IdentificadorBairro))
                {

                    if (objSql.Length > 0)
                    {
                        objSql += " AND ";
                    }
                    else
                    {
                        objSql = " WHERE ";
                    }

                    objSql += " B.IDBAIRRO = @IDBAIRRO ";
                    objFrm.AdicionarParametro("IDBAIRRO", IdentificadorBairro);
                }

                if (!string.IsNullOrEmpty(Rua))
                {

                    if (objSql.Length > 0)
                    {
                        objSql += " AND ";
                    }
                    else
                    {
                        objSql = " WHERE ";
                    }

                    objSql += " E.DESRUA = @DESRUA ";
                    objFrm.AdicionarParametro("DESRUA", Rua);
                }

                if (!string.IsNullOrEmpty(RuaPesquisar))
                {

                    if (objSql.Length > 0)
                    {
                        objSql += " AND ";
                    }
                    else
                    {
                        objSql = " WHERE ";
                    }

                    objSql += " E.DESRUA LIKE @DESRUAPESQ ";
                    objFrm.AdicionarParametro("DESRUAPESQ", "%" + RuaPesquisar + "%");
                }
            }

            DataTable dt = objFrm.ExecutarDataTableArquivo(string.Format(Properties.Resources.EnderecoRecuperar, objSql), Comum.Clases.Constantes.ARQUIVO_CONEXAO);
  
            return PopularEndereco(dt);
        }

        private static Comum.Clases.Estado PopularEndereco(DataTable dt)
        {

            Comum.Clases.Estado objEstado = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                Comum.Clases.Cidade objCidade = null;
                Comum.Clases.Bairro objBairro = null;
                Comum.Clases.Endereco objEndereco = null;
                string IdentificadorCidade = string.Empty;
                string IdentificadorBairro = string.Empty;
                string IdentificadorEndereco = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {

                    if (objEstado == null)
                    {

                        objEstado = new Comum.Clases.Estado
                        {
                            Cidades = new List<Comum.Clases.Cidade>(),
                            CodIbge = frmUtil.Util.AtribuirValorObj(dr["CODIBGE"], typeof(string)) as string,
                            Codigo = frmUtil.Util.AtribuirValorObj(dr["CODESTADO"], typeof(string)) as string,
                            ICMS = (decimal)frmUtil.Util.AtribuirValorObj(dr["NUMICMS"], typeof(decimal)),
                            Identificador = frmUtil.Util.AtribuirValorObj(dr["IDESTADO"], typeof(string)) as string,
                            Nome = frmUtil.Util.AtribuirValorObj(dr["DESESTADO"], typeof(string)) as string
                        };


                    }

                    IdentificadorCidade = frmUtil.Util.AtribuirValorObj(dr["IDCIDADE"], typeof(string)) as string;
                    objCidade = (from c in objEstado.Cidades where c.Identificador == IdentificadorCidade select c).FirstOrDefault();

                    if (objCidade == null)
                    {

                        objEstado.Cidades.Add(new Comum.Clases.Cidade
                        {
                            Bairros = new List<Comum.Clases.Bairro>(),
                            Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODCIDADE"], typeof(int)),
                            DDD = frmUtil.Util.AtribuirValorObj(dr["CODDDD"], typeof(string)) as string,
                            IBGE = frmUtil.Util.AtribuirValorObj(dr["CODIBGE"], typeof(string)) as string,
                            Identificador = IdentificadorCidade,
                            Nome = frmUtil.Util.AtribuirValorObj(dr["DESCIDADE"], typeof(string)) as string
                        });

                        objCidade = (from c in objEstado.Cidades where c.Identificador == IdentificadorCidade select c).FirstOrDefault();
                    }

                    IdentificadorBairro = frmUtil.Util.AtribuirValorObj(dr["IDBAIRRO"], typeof(string)) as string;
                    objBairro = (from b in objCidade.Bairros where b.Identificador == IdentificadorBairro select b).FirstOrDefault();

                    if (objBairro == null)
                    {

                        objCidade.Bairros.Add(new Comum.Clases.Bairro()
                        {
                            Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODBAIRRO"], typeof(int)),
                            Enderecos = new List<Comum.Clases.Endereco>(),
                            Identificador = IdentificadorBairro,
                            Nome = frmUtil.Util.AtribuirValorObj(dr["DESBAIRRO"], typeof(string)) as string
                        });

                        objBairro = (from b in objCidade.Bairros where b.Identificador == IdentificadorBairro select b).FirstOrDefault();

                    }

                    IdentificadorEndereco = frmUtil.Util.AtribuirValorObj(dr["IDENDERECO"], typeof(string)) as string;
                    objEndereco = (from e in objBairro.Enderecos where e.Identificador == IdentificadorEndereco select e).FirstOrDefault();

                    if (objEndereco == null)
                    {

                        objBairro.Enderecos.Add(new Comum.Clases.Endereco()
                        {
                            Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODENDERECO"], typeof(int)),
                            DescricaoCep = frmUtil.Util.AtribuirValorObj(dr["CODCEP"], typeof(string)) as string,
                            DescricaoRua = frmUtil.Util.AtribuirValorObj(dr["DESRUA"], typeof(string)) as string,
                            Identificador = IdentificadorEndereco
                        });
                    }
                }
            }

            return objEstado;
        }

        #endregion

        #region "Atualizar"


        public static void AtualizarEndereco(string Nome, string Identificador, string Cep, ref Sql objSql)
        {

            objSql.AdicionarParametro("IDENDERECO", Identificador, true);
            objSql.AdicionarParametro("DESRUA", Nome.ToUpper());
            objSql.AdicionarParametro("CODCEP", string.IsNullOrEmpty(Cep) ? DBNull.Value.ToString() : Cep);

            objSql.AdicionarTransacao(Properties.Resources.EnderecoAtualiar);
        }

        #endregion

        #region"Inserir"

        public static string InserirEndereco(string Nome, string IdentificadorBairro, string Cep, ref Sql objSql)
        {

            string IdentificadorEndereco = Convert.ToString(Guid.NewGuid());

            objSql.AdicionarParametro("IDENDERECO", IdentificadorEndereco, true);
            objSql.AdicionarParametro("IDBAIRRO", IdentificadorBairro);
            objSql.AdicionarParametro("DESRUA", Nome.ToUpper());
            objSql.AdicionarParametro("CODCEP", string.IsNullOrEmpty(Cep) ? DBNull.Value.ToString() : Cep);

            objSql.AdicionarTransacao(Properties.Resources.EnderecoInserir);

            return IdentificadorEndereco;
        }

        public static List<Comum.Clases.Endereco> Pesquisar(string Cep, string IdentificadorBairro, string Rua, Nullable<int> Codigo, string Identificador)
        {

            Sql objFrm = new Sql();

            string objSql = string.Empty;
            List<Comum.Clases.Endereco> Enderecos = null;

            if (!string.IsNullOrEmpty(IdentificadorBairro))
            {

                objSql = " WHERE IDBAIRRO = @IDBAIRRO ";
                objFrm.AdicionarParametro("IDBAIRRO", IdentificadorBairro);

            }
            else
            {

                objSql = " WHERE IDENDERECO = @IDENDERECO ";
                objFrm.AdicionarParametro("IDENDERECO", Identificador);

            }

            if (!string.IsNullOrEmpty(Cep))
            {

                objSql += " AND  CODCEP = @CODCEP ";
                objFrm.AdicionarParametro("CODCEP", Cep);
            }
            else
            {

                if (!string.IsNullOrEmpty(Rua))
                {
                    objSql += " AND DESRUA LIKE @DESRUA ";
                    objFrm.AdicionarParametro("DESRUA", "%" + Rua + "%");
                }

                if (Codigo != null)
                {
                    objSql += " AND CODENDERECO = @CODENDERECO ";
                    objFrm.AdicionarParametro("CODENDERECO", Codigo);
                }
            }

            DataTable dt = objFrm.ExecutarDataTableArquivo(Properties.Resources.EnderecoPesquisar + objSql, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

            if (dt != null && dt.Rows.Count > 0)
            {
                Enderecos = new List<Comum.Clases.Endereco>();

                foreach (DataRow dr in dt.Rows)
                {

                    Enderecos.Add(new Comum.Clases.Endereco()
                    {
                        Codigo = (int)frmUtil.Util.AtribuirValorObj(dr["CODENDERECO"], typeof(int)),
                        DescricaoCep = frmUtil.Util.AtribuirValorObj(dr["CODCEP"], typeof(string)) as string,
                        DescricaoRua = frmUtil.Util.AtribuirValorObj(dr["DESRUA"], typeof(string)) as string,
                        Identificador = frmUtil.Util.AtribuirValorObj(dr["IDENDERECO"], typeof(string)) as string
                    });

                }
            }
            return Enderecos;
        }

        #endregion

    }
}
