using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmCep = AmgSistemas.Framework.ConsultaCep;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Endereco
    {

        public static Comum.Clases.Estado RegistrarEndereco(string Cep, string IdentificadorEstado, string IdentificadorCidade, string IdentificadorBairro,
                                                            string Rua, string Usuario, string RuaPesquisar, string IdentificadorEndereco)
        {
            Comum.Clases.Estado EnderecoRetorno = null;
            try
            {
                //Pesquisa o endereço na base
                EnderecoRetorno = AcessoDados.Classes.Endereco.RecuperarEndereco(Cep, IdentificadorEstado, IdentificadorCidade, IdentificadorBairro, Rua, RuaPesquisar, IdentificadorEndereco);

                if (EnderecoRetorno == null && !string.IsNullOrEmpty(Cep))
                {

                    //pesquisa o cep no webservice de cep
                    frmCep.DadosCep objCep = frmCep.Consultar.BuscaCep(Cep);

                    if (objCep != null && objCep.Tipo == 1)
                    {
                        Sql objFrmSql = new Sql();

                        objFrmSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                        //recupera o estado
                        EnderecoRetorno = AcessoDados.Classes.Estado.RecuperarEstado(objCep.UF, string.Empty).FirstOrDefault();

                        if (EnderecoRetorno != null)
                        {

                            string IdentificadorBairroInserido = string.Empty;

                            //recupera a cidade
                            EnderecoRetorno.Cidades = AcessoDados.Classes.Cidade.RecuperarCidades(string.Empty, EnderecoRetorno.Identificador, objCep.Cidade,
                                                                                                  string.Empty, null);

                            if (EnderecoRetorno.Cidades != null && EnderecoRetorno.Cidades.Count > 0)
                            {
                                //Recupera o bairro
                                EnderecoRetorno.Cidades.First().Bairros = AcessoDados.Classes.Bairro.RecuperarBairro(EnderecoRetorno.Cidades.First().Identificador,
                                                                                                                     string.Empty, objCep.Bairro, string.Empty, null);

                                if (EnderecoRetorno.Cidades.First().Bairros != null && EnderecoRetorno.Cidades.First().Bairros.Count > 0)
                                {

                                    //Recupera o Endereco
                                    Comum.Clases.Estado EnderecoPesquisado = AcessoDados.Classes.Endereco.RecuperarEndereco(string.Empty, EnderecoRetorno.Identificador,
                                                                                                                           EnderecoRetorno.Cidades.First().Identificador,
                                                                                                                           EnderecoRetorno.Cidades.First().Bairros.First().Identificador, objCep.Logradouro,
                                                                                                                           string.Empty, string.Empty);

                                    if (EnderecoPesquisado != null)
                                    {
                                        EnderecoRetorno = EnderecoPesquisado;
                                    }
                                    else
                                    {
                                        //Insere o endereço
                                        AcessoDados.Classes.Endereco.InserirEndereco(objCep.Logradouro, EnderecoRetorno.Cidades.First().Bairros.First().Identificador,
                                                                                     Cep, ref objFrmSql);


                                    }

                                }
                                else
                                {
                                    //Insere o Bairro
                                    IdentificadorBairroInserido = AcessoDados.Classes.Bairro.InserirBairro(EnderecoRetorno.Cidades.First().Identificador,
                                                                                                            objCep.Bairro, ref objFrmSql);

                                    //Insere o endereço
                                    AcessoDados.Classes.Endereco.InserirEndereco(objCep.Logradouro, IdentificadorBairroInserido,
                                                                                 Cep, ref objFrmSql);

                                }

                            }
                            else
                            {

                                string IdentificadorCidadeInserida = AcessoDados.Classes.Cidade.InserirCidade(objCep.Cidade, EnderecoRetorno.Identificador, string.Empty, string.Empty, ref objFrmSql);
                                IdentificadorBairroInserido = AcessoDados.Classes.Bairro.InserirBairro(IdentificadorCidadeInserida, objCep.Bairro, ref objFrmSql);

                                //Insere o endereço
                                AcessoDados.Classes.Endereco.InserirEndereco(objCep.Logradouro, IdentificadorBairroInserido,
                                                                             Cep, ref objFrmSql);

                            }
                        }

                        objFrmSql.ExecutarTransacao();

                        //Pesquisa o endereço na base
                        EnderecoRetorno = AcessoDados.Classes.Endereco.RecuperarEndereco(Cep, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return EnderecoRetorno;
        }

        public static List<Comum.Clases.Endereco> PesquisarEndereco(string Usuario, string cep, string rua, string identificadorBairro, Nullable<int> codigo, string Identificador)
        {

            List<Comum.Clases.Endereco> Enderecos = null;

            try
            {

                Enderecos = AcessoDados.Classes.Endereco.Pesquisar(cep, identificadorBairro, rua, codigo, Identificador);

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return Enderecos;
        }

        public static Comum.Clases.Endereco SetEndereco(Comum.Clases.Endereco Endereco, string IdentificadorBairro, string Usuario)
        {

            Comum.Clases.Endereco objEndereco = null;

            try
            {

                Sql objSql = new Sql();
                List<Comum.Clases.Endereco> objEnderecos = null;

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                objEnderecos = AcessoDados.Classes.Endereco.Pesquisar(string.Empty, IdentificadorBairro, Endereco.DescricaoRua, null, string.Empty);

                if (string.IsNullOrEmpty(Endereco.Identificador))
                {


                    if (objEnderecos != null && objEnderecos.Count > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O endereço informado já existe na base de dados.");
                    }

                    Endereco.Identificador = AcessoDados.Classes.Endereco.InserirEndereco(Endereco.DescricaoRua, IdentificadorBairro, Endereco.DescricaoCep, ref objSql);

                }
                else
                {

                    if (objEnderecos != null && objEnderecos.FindAll(b => b.Identificador != Endereco.Identificador).Count > 0)
                    {

                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O bairro informado já existe na base de dados.");
                    }

                    AcessoDados.Classes.Endereco.AtualizarEndereco(Endereco.DescricaoRua, Endereco.Identificador, Endereco.DescricaoCep, ref objSql);

                }

                objSql.ExecutarTransacao();

                objEndereco = AcessoDados.Classes.Endereco.Pesquisar(string.Empty, string.Empty, string.Empty, null, Endereco.Identificador).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objEndereco;
        }

    }
}
