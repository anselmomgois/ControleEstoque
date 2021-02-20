using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.AcessoDados;

namespace Informatiz.ControleEstoque.LogicaNegocio.Servico
{
    public class Empresa
    {

        public ContratoServico.InserirEmpresa.Respuesta InserirEmpresa(ContratoServico.InserirEmpresa.Peticao Peticao)
        {
            ContratoServico.InserirEmpresa.Respuesta objResposta = new ContratoServico.InserirEmpresa.Respuesta();

            try
            {

                frmUtil.Util.ValidarCampo(Peticao.DescricaoEmpresa, "O nome da empresa é obrigatório", typeof(string), false);
                frmUtil.Util.ValidarCampo(Peticao.NomeUsuario, "O Nome do usuário é obrigatório", typeof(string), false);
                frmUtil.Util.ValidarCampo(Peticao.Senha, "A senha é obrigatória", typeof(string), false);
                frmUtil.Util.ValidarCampo(Peticao.Usuario, "O usuário é obrigatório", typeof(string), false);

                if (AcessoDados.Classes.Pessoa.ValidarLoginExiste(Peticao.Usuario, string.Empty, false))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Usuário informado já existe.");
                }

                Sql objSql = new Sql();

                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                Int32 CodigoEmpresa = AcessoDados.Classes.Empresa.RetornarProximoCodigoEmpresa();

                string IdentificadorEmpresa = AcessoDados.Classes.Empresa.InserirEmpresa(Peticao.DescricaoEmpresa, CodigoEmpresa,
                                              Peticao.IdentificadorPublicidade,Peticao.IdentificadorConsultor, Peticao.DescricaoIndicacao, ref objSql);

                Comum.Clases.Filiais objFilial = new Comum.Clases.Filiais();

                if (Peticao.objEstado != null && Peticao.objCidade != null && Peticao.objEndereco == null)
                {

                    List<Comum.Clases.Bairro> objBairros = null;
                    List<Comum.Clases.Endereco> objEnderecos = null;
                    Comum.Clases.Endereco objEndereco = null;
                    Comum.Clases.Bairro objBairro = null;
                                        
                    objBairros = AcessoDados.Classes.Bairro.RecuperarBairro(Peticao.objCidade.Identificador, string.Empty, Peticao.DescricaoBairro,
                                                                            string.Empty, null);

                    if (objBairros == null || objBairros.Count == 0)
                    {
                        objBairro.Identificador = AcessoDados.Classes.Bairro.InserirBairro(Peticao.objCidade.Identificador, Peticao.DescricaoBairro, ref objSql);
                    }

                    if (objBairro != null && !string.IsNullOrEmpty(objBairro.Identificador))
                    {
                        objEnderecos = AcessoDados.Classes.Endereco.Pesquisar(string.Empty, objBairro.Identificador, Peticao.Logradouro, null, string.Empty);

                        if (objEnderecos == null || objEnderecos.Count == 0)
                        {
                            objEndereco.Identificador = AcessoDados.Classes.Endereco.InserirEndereco(Peticao.Logradouro, objBairro.Identificador,
                                                                                                     Convert.ToString(Peticao.CEP), ref objSql);
                        }

                        if (objEndereco != null && !string.IsNullOrEmpty(objEndereco.Identificador))
                        {

                            objEndereco.Numero = Peticao.Numero;
                            objEndereco.DescricaoCep = Convert.ToString(Peticao.CEP);

                            objBairro.Enderecos = new List<Comum.Clases.Endereco>();
                            objBairro.Enderecos.Add(objEndereco);

                            Comum.Clases.Cidade objCidade = Peticao.objCidade;

                            objCidade.Bairros = new List<Comum.Clases.Bairro>();
                            objCidade.Bairros.Add(objBairro);

                            Peticao.objEstado.Cidades = new List<Comum.Clases.Cidade>();
                            Peticao.objEstado.Cidades.Add(objCidade);

                            objFilial.Endereco = Peticao.objEstado;
                        }
                    }

                }
                else if (Peticao.objEndereco != null)
                {
                    objFilial.Endereco = Peticao.objEndereco;
                }

                objFilial.Nome = "FILIAL DEFAULT";
                objFilial.TelefoneFixo = Peticao.TelefoneFixo;
                objFilial.TelefoneMovel = Peticao.TelefoneCelular;
                objFilial.Email = Peticao.Email;
                objFilial.Matriz = true;
                objFilial.Ativa = true;

                string IdentificadorFilial = AcessoDados.Classes.Filial.InserirFilial(objFilial, IdentificadorEmpresa, ref objSql);

                Comum.Clases.Pessoa objPessoa = new Comum.Clases.Pessoa();

                objPessoa.DesNome = Peticao.NomeUsuario;
                objPessoa.Usuario = Peticao.Usuario;
                objPessoa.DesSenha = Peticao.Senha;
                objPessoa.FornecedorAtivo = false;
                objPessoa.Empresa = new Comum.Clases.Empresa() { Identificador = IdentificadorEmpresa };

                string IdentificadorPessoa = AcessoDados.Classes.Pessoa.InserirPessoa(objPessoa, ref objSql);

                AcessoDados.Classes.TipoPessoa.InserirTipoPessoa(IdentificadorPessoa, "1", ref objSql);

                AcessoDados.Classes.FilialPessoa.InseirPessoaFilial(IdentificadorFilial, IdentificadorPessoa, ref objSql);

                List<Comum.Clases.Permissao> objPermissoes = AcessoDados.Classes.Permissao.RecuperarPermissoes(false);


                if (objPermissoes != null && objPermissoes.Count > 0)
                {

                    Comum.Clases.GrupoPermissao objGrupoPermissao = new Comum.Clases.GrupoPermissao();
                    objGrupoPermissao.Nome = "ADMINISTRADOR";
                    objGrupoPermissao.IdentificadorEmpresa = IdentificadorEmpresa;
                    objGrupoPermissao.Permissoes = objPermissoes;

                    string IdentificadorGrupo = AcessoDados.Classes.GrupoPermissao.InserirGrupoPermissao(objGrupoPermissao, ref objSql);

                    if (objGrupoPermissao.Permissoes != null && objGrupoPermissao.Permissoes.Count > 0)
                    {

                        foreach (Comum.Clases.Permissao objPermissao in objGrupoPermissao.Permissoes)
                        {

                            if (objPermissao.Acoes != null && objPermissao.Acoes.Count > 0)
                            {

                                foreach (Comum.Clases.Acao objAcao in objPermissao.Acoes)
                                {
                                    AcessoDados.Classes.GrupoPermissao.InserirPermissao(IdentificadorGrupo, objPermissao.Identificador, objAcao.Identificador, ref objSql);
                                }
                            }
                        }
                    }

                    foreach (Comum.Clases.Permissao objPermissao in objPermissoes)
                    {

                        if (objPermissao.Acoes != null && objPermissao.Acoes.Count > 0)
                        {

                            foreach (Comum.Clases.Acao objAcao in objPermissao.Acoes)
                            {

                                AcessoDados.Classes.Permissao.InserirPermissoesPessoa(IdentificadorPessoa, objPermissao.Identificador,
                                                                                       objAcao.Identificador, null, ref objSql);
                            }
                        }
                    }
                }

                objSql.ExecutarTransacao();

                objResposta.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objResposta.CodigoErro = Convert.ToInt32(ex.Codigo);
                objResposta.DescricaoErro = ex.Descricao;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                objResposta.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objResposta.DescricaoErro = ex.ToString();

            }

            return objResposta;
        }

        public ContratoServico.ValidarUsuario.Respuesta ValidarUsuario(ContratoServico.ValidarUsuario.Peticao Peticao)
        {

            ContratoServico.ValidarUsuario.Respuesta objResposta = new ContratoServico.ValidarUsuario.Respuesta();

            try
            {

                objResposta.UsuarioOK = AcessoDados.Classes.Pessoa.ValidarLoginExiste(Peticao.Usuario, string.Empty, false);

                objResposta.CodigoErro = (Int32)(Execao.Constantes.CodigoErro.SEM_ERRO);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                objResposta.CodigoErro = Convert.ToInt32(ex.Codigo);
                objResposta.DescricaoErro = ex.Descricao;
            }
            catch (Exception ex)
            {
                Erro.InserirErro(new Comum.Clases.Erro() { DesErro = ex.Message, Usuario = Peticao.Usuario });
                objResposta.CodigoErro = Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_EXECUCAO);
                objResposta.DescricaoErro = ex.ToString();

            }

            return objResposta;
        }
    }
}
