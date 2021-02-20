using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class Controle : TelaBase.BaseCE
    {
        public Controle()
        {
            InitializeComponent();
            this.Visible = false;

        }


        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void FimProcesamento()
        {
            base.FimProcesamento();

        }

        public void PreencherValor(ref Parametros.ParametrosAplicacao objItem, string NomePropriedade, string Valor)
        {
            object propriedadeValor = null;

            if (!string.IsNullOrEmpty(Valor))
            {
                var isNumeric = int.TryParse(Valor, out int n);

                PropertyInfo propriedade = objItem.GetType().GetProperties().FirstOrDefault(p => p.Name.ToUpper().Equals(NomePropriedade.ToUpper()));

                if (propriedade != null)
                {

                    if (isNumeric)
                    {
                        propriedadeValor = Convert.ChangeType(Convert.ToInt32(Valor.Trim()), propriedade.PropertyType);
                    }
                    else
                    {
                        propriedadeValor = Convert.ChangeType(Valor.Trim(), propriedade.PropertyType);
                    }

                    if (propriedadeValor != null)
                    {
                        propriedade.SetValue(objItem, propriedadeValor, null);
                    }
                }

                //foreach (var i in objItem.GetType().GetProperties())
                //{
                //    if (i.Name == NomePropriedade)
                //    {


                //        if (i.GetType() == typeof(bool))
                //            i.SetValue(objItem, Convert.ToBoolean(Valor), i.GetIndexParameters());
                //        else if (i.GetType() == typeof(string))
                //            i.SetValue(objItem, Valor, i.GetIndexParameters());
                //        else if (i.GetType() == typeof(Int32))
                //            i.SetValue(objItem, Convert.ToInt32(Valor), i.GetIndexParameters());

                //        break;
                //    }
                //}
            }
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                base.RespostaAgente(objSaida, operacao, Parametros);

                if (operacao == SDK.Operacoes.operacao.AtivarSessao)
                {
                    ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao Resposta = ((ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao)objSaida);
                    ControleEstoque.Parametros.Parametros.IdentificadorSessao = Resposta.IdentificadorSessao;

                    ContratoServico.Parametro.RecuperarParametros.PeticaoRecuperarParametros Peticao = new ContratoServico.Parametro.RecuperarParametros.PeticaoRecuperarParametros();

                    Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                    Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
                    Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                    Agente.Agente.InvocarServico<ContratoServico.Parametro.RecuperarParametros.RespostaRecuperarParametros, ContratoServico.Parametro.RecuperarParametros.PeticaoRecuperarParametros>(Peticao,
                        SDK.Operacoes.operacao.RecuperarParametros, new Comum.ParametrosTela.Generica()
                        {
                            PreencherObjeto = true,
                            ExibirMensagemNenhumRegistro = false
                        }, null, true);

                }
                else if (operacao == SDK.Operacoes.operacao.RecuperarParametros)
                {

                    ContratoServico.Parametro.RecuperarParametros.RespostaRecuperarParametros Resposta = ((ContratoServico.Parametro.RecuperarParametros.RespostaRecuperarParametros)objSaida);

                    if (Resposta != null)
                    {
                        if (Resposta.CodigoErro != (int)Execao.Constantes.CodigoErro.SEM_ERRO)
                        {
                            throw new Exception(Resposta.DescricaoErro);
                        }
                        else
                        {
                            if (Resposta.Parametros != null && Resposta.Parametros.Count > 0)
                            {
                                Parametros.ParametrosAplicacao objParametrosAplicacao = new Parametros.ParametrosAplicacao();

                                foreach (Comum.Clases.Parametro p in Resposta.Parametros)
                                {
                                    PreencherValor(ref objParametrosAplicacao, p.Codigo, p.DesValor);
                                }

                                ControleEstoque.Parametros.Parametros.ParametrosAplicacao = objParametrosAplicacao;
                            }

                            Principal objFrmPrincipal = new Principal();
                            objFrmPrincipal.ShowDialog();
                            this.Close();

                        }
                    }

                }
                else if (operacao == SDK.Operacoes.operacao.ValidarChave)
                {
                    ContratoServico.ChaveAcesso.ValidarChave.RespuestaValidarChave objSaidaConvertido = (ContratoServico.ChaveAcesso.ValidarChave.RespuestaValidarChave)objSaida;

                    if (!string.IsNullOrEmpty(objSaidaConvertido.CodigoAcesso))
                    {
                        ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.CodAcesso = objSaidaConvertido.CodigoAcesso;
                    }

                    AtivarSessao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Controle_Load(object sender, EventArgs e)
        {
            try
            {
                IniciarAplicacao();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemMsgBox(ex.Descricao, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErroMsgBox(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
                this.Close();
            }


        }

        private void AtivarSessao()
        {
            ContratoServico.Usuario.AtivarSessao.PeticaoAtivarSessao Peticao = new ContratoServico.Usuario.AtivarSessao.PeticaoAtivarSessao();


            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.First().Identificador;
            Peticao.IdentificadorPessoa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.QuantidadeSessoes = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.QuantidadeSessoes;
            Peticao.SessoesIlimitadas = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.SessoesIlimitadas;

            Agente.Agente.InvocarServico<ContratoServico.Usuario.AtivarSessao.RespostaAtivarSessao, ContratoServico.Usuario.AtivarSessao.PeticaoAtivarSessao>(Peticao,
                SDK.Operacoes.operacao.AtivarSessao, new Comum.ParametrosTela.Generica()
                {
                    PreencherObjeto = true,
                    ExibirMensagemNenhumRegistro = false
                }, null, true);
        }
        private void IniciarAplicacao()
        {
            try
            {

                //Telas.Relatorios.Ticket frmTicket = new Telas.Relatorios.Ticket();
                //frmTicket.ShowDialog();

                Login frmLogin = new Login();
                frmLogin.ShowDialog();

                if (frmLogin.objUsuario != null)
                {
                    ControleEstoque.Parametros.Parametros.InformacaoUsuario = frmLogin.objUsuario;
                    ControleEstoque.Parametros.Parametros.Versao = Application.ProductVersion.Replace("1.0.", string.Empty);


                    if (frmLogin.objUsuario.Empresas.Count > 1 || frmLogin.objUsuario.Empresas.First().Filiais.Count > 1)
                    {

                        SelecionarEmpresa objFrmSelecionarEmpresa = new SelecionarEmpresa(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Empresas);

                        objFrmSelecionarEmpresa.ShowDialog();

                        if (objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada == null)
                        {
                            ControleEstoque.Parametros.Parametros.InformacaoUsuario = null;
                            this.Close();
                            return;
                        }

                        ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada = objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada;
                        ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada = objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada.Filiais.FirstOrDefault();
                    }
                    else
                    {
                        ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada = frmLogin.objUsuario.Empresas.FirstOrDefault();

                        if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada != null &&
                             ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais != null &&
                              ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.Count > 0)
                        {
                            if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.Count > 1)
                            {

                                SelecionarEmpresa objFrmSelecionarEmpresa = new SelecionarEmpresa(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Empresas);

                                objFrmSelecionarEmpresa.ShowDialog();

                                if (objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada == null)
                                {
                                    ControleEstoque.Parametros.Parametros.InformacaoUsuario = null;
                                    this.Close();
                                    return;
                                }

                                ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada = objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada.Filiais.FirstOrDefault();
                            }
                            else
                            {
                                ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault();
                            }
                        }


                    }

                    if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco != null &&
                    ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades != null && ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.Count > 0 &&
                    ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros != null && ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros.Count > 0 &&
                    ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos != null &&
                    ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.Count > 0)
                    {
                        ControleEstoque.Parametros.Parametros.InformacaoUsuario.EnderecoEmpresa = string.Format("Rua/Av: {0} - {1} - {2} {3}/{4} ", ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.FirstOrDefault().DescricaoRua,
                                                                                   (ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.FirstOrDefault().Numero != null ?
                                                                                   ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Enderecos.FirstOrDefault().Numero.ToString() : string.Empty),
                                                                                   ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Bairros.FirstOrDefault().Nome,
                                                                                   ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Cidades.FirstOrDefault().Nome,
                                                                                   ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Endereco.Codigo);
                    }

                    if (!string.IsNullOrEmpty(ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.ChaveAcesso))
                    {

                        ContratoServico.ChaveAcesso.ValidarChave.PeticaoValidarChave PeticaoChaveAcesso = new ContratoServico.ChaveAcesso.ValidarChave.PeticaoValidarChave();

                        PeticaoChaveAcesso.Chave = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.ChaveAcesso;
                        PeticaoChaveAcesso.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                        PeticaoChaveAcesso.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
                        PeticaoChaveAcesso.CodigoEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Codigo;

                        Agente.Agente.InvocarServico<ContratoServico.ChaveAcesso.ValidarChave.RespuestaValidarChave, ContratoServico.ChaveAcesso.ValidarChave.PeticaoValidarChave>(PeticaoChaveAcesso,
                       SDK.Operacoes.operacao.ValidarChave, new Comum.ParametrosTela.Generica()
                       {
                           PreencherObjeto = true,
                           ExibirMensagemNenhumRegistro = false
                       }, null, true);
                    }
                    else
                    {
                        ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.QuantidadeSessoes = 1;
                        ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.SessoesIlimitadas = false;

                        AtivarSessao();

                    }
                }
                else
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
