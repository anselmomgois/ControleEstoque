using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmgSistemas.Framework.AcessoDados;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.LogicaNegocio
{
    public class Pessoa
    {

        public static void TrocarSenhaPessoa(string Identificador, string Senha, Boolean SolicitarTrocarSenha, string Usuario)
        {
            try
            {

                System.Text.StringBuilder Erros = new System.Text.StringBuilder();

                frmUtil.Util.ValidarCampo(Senha, "Favor informar a senha", typeof(string), false, ref Erros);

                if (Erros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());
                }

                AcessoDados.Classes.Pessoa.AlterarSenhaUsuario(Identificador, Senha, SolicitarTrocarSenha);

            }
            catch (Exception ex)
            {
                LogicaNegocio.Erro.InserirErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static void DesativarPessoa(string Identificador, Comum.Enumeradores.Enumeradores.TipoPessoaEnum TipoPessoa, string Usuario)
        {
            try
            {

                AcessoDados.Classes.Pessoa.DesativarPessoa(Identificador, TipoPessoa); 

            }
            catch (Exception ex)
            {
                LogicaNegocio.Erro.InserirErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }
        }

        public static ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas RecuperarPessoas(ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao)
        {
            ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas Resposta = new ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas();

            try
            {

              Resposta.Pessoas  = AcessoDados.Classes.Pessoa.RecuperarPessoas(Peticao.Codigo, Peticao.Descricao, Peticao.Cpf, Peticao.Cnpj, 
                                                                              Peticao.Login, Peticao.TipoPessoa, Peticao.IdentificadorEmpresa, Peticao.FuncionarioAtivo);

            }
            catch (Exception ex)
            {
                LogicaNegocio.Erro.InserirErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Peticao.Usuario });
                throw ex;
            }

            return Resposta;
        }

        public static Comum.Clases.Pessoa RecuperarPessoa(string IdentificadorPessoa, string Usuario)
        {

            Comum.Clases.Pessoa objPessoa = null;

            try
            {
                if (!string.IsNullOrEmpty(IdentificadorPessoa))
                {
                    objPessoa = AcessoDados.Classes.Pessoa.RecuperarPessoa(IdentificadorPessoa);
                }

            }
            catch (Exception ex)
            {
                LogicaNegocio.Erro.InserirErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objPessoa;


        }

        public static string InserirPessoa(Comum.Clases.Pessoa objPessoa, string Usuario)
        {
                        
            try
            {

                StringBuilder Erros = ValidarCamposInserirPessoa(objPessoa);

                if (Erros.Length > 0) throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());

                Sql objSql = new Sql();
                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);
                
                objPessoa.Identificador = AcessoDados.Classes.Pessoa.InserirPessoa(objPessoa, ref objSql);

                foreach (Comum.Clases.TipoPessoa tp in objPessoa.TiposPessoa)
                {
                    AcessoDados.Classes.TipoPessoa.InserirTipoPessoa(objPessoa.Identificador, tp.Identificador, ref objSql);
                }

                if (objPessoa.HorarioTrabalho != null && objPessoa.HorarioTrabalho.Count > 0)
                {

                    foreach (Comum.Clases.HorarioTrabalho HT in objPessoa.HorarioTrabalho)
                    {

                        AcessoDados.Classes.HoraTrabalho.InserirHoraTrabalho(HT, objPessoa.Identificador, ref objSql);

                    }
                }

                if (objPessoa.Filiais != null && objPessoa.Filiais.Count > 0)
                {

                    foreach (Comum.Clases.Filiais Filial in objPessoa.Filiais)
                    {

                        AcessoDados.Classes.FilialPessoa.InseirPessoaFilial(Filial.Identificador, objPessoa.Identificador, ref objSql);
                    }
                }

                objSql.ExecutarTransacao();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                LogicaNegocio.Erro.InserirErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }

            return objPessoa.Identificador;
        }

        public static void AtualizarPessoa(Comum.Clases.Pessoa objPessoa, string Usuario)
        {

            try
            {

                StringBuilder Erros = ValidarCamposAtualizarPessoa(objPessoa);

                if (Erros.Length > 0) throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, Erros.ToString());

                Sql objSql = new Sql();
                objSql.IniciarTransacaoArquivo(Comum.Clases.Constantes.ARQUIVO_CONEXAO);


                AcessoDados.Classes.Pessoa.AtualizarPessoa(objPessoa, ref objSql);

                AcessoDados.Classes.HoraTrabalho.DeletarHoraTrabalho(objPessoa.Identificador, ref objSql);

                if (objPessoa.HorarioTrabalho != null && objPessoa.HorarioTrabalho.Count > 0)
                {

                    foreach (Comum.Clases.HorarioTrabalho HT in objPessoa.HorarioTrabalho)
                    {

                        AcessoDados.Classes.HoraTrabalho.InserirHoraTrabalho(HT, objPessoa.Identificador, ref objSql);

                    }
                }

                AcessoDados.Classes.FilialPessoa.DeletarPessoaFilial(objPessoa.Identificador, ref objSql);

                if (objPessoa.Filiais != null && objPessoa.Filiais.Count > 0)
                {

                    foreach (Comum.Clases.Filiais Filial in objPessoa.Filiais)
                    {

                        AcessoDados.Classes.FilialPessoa.InseirPessoaFilial(Filial.Identificador, objPessoa.Identificador, ref objSql);
                    }
                }

                objSql.ExecutarTransacao();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                LogicaNegocio.Erro.InserirErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Usuario });
                throw ex;
            }


        }

        private static System.Text.StringBuilder ValidarCamposInserirPessoa(Comum.Clases.Pessoa objPessoa)
        {

            System.Text.StringBuilder Erros = new System.Text.StringBuilder();

            frmUtil.Util.ValidarCampo(objPessoa.DesNome, "Favor informar o nome.", typeof(string), false, ref Erros);
            frmUtil.Util.ValidarCampo(objPessoa.TiposPessoa, "Tipo pessoa não informado", typeof(List<Comum.Clases.TipoPessoa>), true, ref Erros);

            if (!string.IsNullOrEmpty(objPessoa.DesEmail) && !frmUtil.Validacao.ValidarValorCampo(objPessoa.DesEmail,frmUtil.Enumeradores.TipoValidacao.EMAIL))
            {
                Erros.AppendLine("Email invalido.");
            }

            if (!string.IsNullOrEmpty(objPessoa.cpf) && !frmUtil.Validacao.ValidarValorCampo(objPessoa.cpf, frmUtil.Enumeradores.TipoValidacao.CPF))
            {
                Erros.AppendLine("CPF invalido.");
            }

            if (!string.IsNullOrEmpty(objPessoa.cnpj) && !frmUtil.Validacao.ValidarValorCampo(objPessoa.cnpj, frmUtil.Enumeradores.TipoValidacao.CNPJ))
            {
                Erros.AppendLine("CNPJ invalido.");
            }

            if (objPessoa.TiposPessoa.FindAll(f => f.Codigo == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO).Count > 0)
            {

                frmUtil.Util.ValidarCampo(objPessoa.Usuario, "Favor informar o usuário.", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objPessoa.DesSenha, "Favor informar a senha.", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objPessoa.DesConfirmarSenha, "Favor confirmar a senha.", typeof(string), false, ref Erros);
                frmUtil.Util.ValidarCampo(objPessoa.Filiais, "Favor informar ao menos uma filial.", typeof(List<Comum.Clases.Filiais>), true, ref Erros);

                if (objPessoa.DesSenha != objPessoa.DesConfirmarSenha)
                {
                    Erros.AppendLine("Os campos senha e confirmar senha são diferentes.");
                }

                if (AcessoDados.Classes.Pessoa.ValidarLoginExiste(objPessoa.Usuario, objPessoa.Identificador,true))
                {
                    Erros.AppendLine("Usuario já existe");
                }
            }


            return Erros;
        }

        private static System.Text.StringBuilder ValidarCamposAtualizarPessoa(Comum.Clases.Pessoa objPessoa)
        {

            System.Text.StringBuilder Erros = new System.Text.StringBuilder();

            frmUtil.Util.ValidarCampo(objPessoa.Identificador, "Identificador não informado", typeof(string), false, ref Erros);
            frmUtil.Util.ValidarCampo(objPessoa.DesNome, "Favor informar o nome.", typeof(string), false, ref Erros);
            frmUtil.Util.ValidarCampo(objPessoa.TiposPessoa, "Tipo pessoa não informado", typeof(List<Comum.Clases.TipoPessoa>), true, ref Erros);

            if (!string.IsNullOrEmpty(objPessoa.DesEmail) && !frmUtil.Validacao.ValidarValorCampo(objPessoa.DesEmail, frmUtil.Enumeradores.TipoValidacao.EMAIL))
            {
                Erros.AppendLine("Email invalido.");
            }

            if (!string.IsNullOrEmpty(objPessoa.cpf) && !frmUtil.Validacao.ValidarValorCampo(objPessoa.cpf, frmUtil.Enumeradores.TipoValidacao.CPF))
            {
                Erros.AppendLine("CPF invalido.");
            }

            if (!string.IsNullOrEmpty(objPessoa.cnpj) && !frmUtil.Validacao.ValidarValorCampo(objPessoa.cnpj, frmUtil.Enumeradores.TipoValidacao.CNPJ))
            {
                Erros.AppendLine("CNPJ invalido.");
            }

            if (objPessoa.TiposPessoa.FindAll(f => f.Codigo == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO).Count > 0)
            {

                frmUtil.Util.ValidarCampo(objPessoa.Filiais, "Favor informar ao menos uma filial.", typeof(List<Comum.Clases.Filiais>), true, ref Erros);

            }

            if (objPessoa.TiposPessoa.FindAll(f => f.Codigo == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO).Count > 0)
            {
                
                if (!string.IsNullOrEmpty(objPessoa.Usuario) && AcessoDados.Classes.Pessoa.ValidarLoginExiste(objPessoa.Usuario, objPessoa.Identificador, true))
                {
                    Erros.AppendLine("Usuario já existe");
                }
            }


            return Erros;
        }
    }
}
