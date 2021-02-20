using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Informatiz.ControleEstoque.Server.Classes;
using System.Reflection;

namespace Informatiz.ControleEstoque.Server.Telas
{
    public partial class Controle : TelaBase.BaseCE
    {
        #region "Construtor"
        public Controle()
        {
            try
            {
                InitializeComponent();

                if (Parametros.Parametros.InformacaoUsuario == null)
                {
                    string ArquivoLogin = string.Format("{0}\\IGERENCE\\DADOS.TXT", Path.GetTempPath());
                    if (File.Exists(ArquivoLogin))
                    {
                        String line = string.Empty;
                        // Open the text file using a stream reader.
                        using (StreamReader sr = new StreamReader(ArquivoLogin))
                        {
                            // Read the stream to a string, and write the string to the console.
                            line = sr.ReadToEnd();

                        }

                        Parametros.Parametros.InformacaoUsuario = JsonConvert.DeserializeObject<Comum.Clases.Usuario>(line);
                    }

                    if (Parametros.Parametros.InformacaoUsuario == null)
                    {
                        ntfIgerenceServer.ShowBalloonTip(3, "I - GERENCE", "Login necessário para iniciar.", ToolTipIcon.Info);
                    }
                    else
                    {
                        RecuperarParametros();
                    }

                }
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }

        #endregion

        #region "Variaveis"
        private Principal frmPrincipal = null;
        private Boolean _atualizacaoDadosStarted = false;
        private Dictionary<string, Processos.BaseProcessos> _ProcesosExecucao = new Dictionary<string, Processos.BaseProcessos>();
        #endregion

        #region "Propriedades"


        #endregion

        #region "Variaveis"

        private List<Comum.Clases.Processo> _Processos;

        #endregion

        #region "Metodos"

        private void ExecutarLogin()
        {
            Login frmLogin = new Login();
            frmLogin.ShowDialog();

            if (frmLogin.objUsuario.Empresas.Count > 1 || frmLogin.objUsuario.Empresas.First().Filiais.Count > 1)
            {

                SelecionarEmpresa objFrmSelecionarEmpresa = new SelecionarEmpresa(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Empresas);

                objFrmSelecionarEmpresa.ShowDialog();

                if (objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada == null)
                {
                    Parametros.Parametros.InformacaoUsuario = null;
                    this.Close();
                    return;
                }

                Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada = objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada;
                Parametros.Parametros.InformacaoUsuario.FilialSelecionada = objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada.Filiais.FirstOrDefault();
            }
            else
            {
                Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada = frmLogin.objUsuario.Empresas.FirstOrDefault();

                if (Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada != null &&
                     Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais != null &&
                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.Count > 0)
                {
                    if (Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.Count > 1)
                    {

                        SelecionarEmpresa objFrmSelecionarEmpresa = new SelecionarEmpresa(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Empresas);

                        objFrmSelecionarEmpresa.ShowDialog();

                        if (objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada == null)
                        {
                            Parametros.Parametros.InformacaoUsuario = null;
                            this.Close();
                            return;
                        }

                        Parametros.Parametros.InformacaoUsuario.FilialSelecionada = objFrmSelecionarEmpresa.EmpresaUsuarioSelecionada.Filiais.FirstOrDefault();
                    }
                    else
                    {
                        Parametros.Parametros.InformacaoUsuario.FilialSelecionada = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault();
                    }
                }


            }

            if (Parametros.Parametros.InformacaoUsuario != null)
            {
                var serializedProduto = JsonConvert.SerializeObject(Parametros.Parametros.InformacaoUsuario);

                if (!Directory.Exists(string.Format("{0}IGERENCE", Path.GetTempPath())))
                {
                    Directory.CreateDirectory(string.Format("{0}IGERENCE", Path.GetTempPath()));
                }
                File.WriteAllText(string.Format("{0}IGERENCE\\DADOS.TXT", Path.GetTempPath()), serializedProduto);

                RecuperarParametros();

            }
        }

        private void RecuperarParametros()
        {
            if (Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada != null && Parametros.Parametros.InformacaoUsuario.FilialSelecionada != null &&
                !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador) && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador))
            {
                ContratoServico.Parametro.RecuperarParametros.PeticaoRecuperarParametros Peticao = new ContratoServico.Parametro.RecuperarParametros.PeticaoRecuperarParametros();

                Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Parametro.RecuperarParametros.RespostaRecuperarParametros, ContratoServico.Parametro.RecuperarParametros.PeticaoRecuperarParametros>(Peticao,
                    SDK.Operacoes.operacao.RecuperarParametros, new Comum.ParametrosTela.Generica()
                    {
                        PreencherObjeto = true,
                        ExibirMensagemNenhumRegistro = false
                    }, null, true);
            }
        }


        private void RecuperarProcessos()
        {
            if (Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada != null && Parametros.Parametros.InformacaoUsuario.FilialSelecionada != null &&
                !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador) && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador))
            {
                ContratoServico.Processo.RecuperarProcessos.PeticaoRecuperarProcessos Peticao = new ContratoServico.Processo.RecuperarProcessos.PeticaoRecuperarProcessos();

                Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.Ativo = true;
                Peticao.RecuperarItemProcesso = true;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Processo.RecuperarProcessos.RespostaRecuperarProcessos, ContratoServico.Processo.RecuperarProcessos.PeticaoRecuperarProcessos>(Peticao,
                    SDK.Operacoes.operacao.RecuperarProcessos, new Comum.ParametrosTela.Generica()
                    {
                        PreencherObjeto = true,
                        ExibirMensagemNenhumRegistro = false
                    }, null, true);
            }
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                base.RespostaAgente(objSaida, operacao, Parametros);

                if (operacao == SDK.Operacoes.operacao.RecuperarParametros)
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

                            RecuperarProcessos();
                        }
                    }

                }
                else if (operacao == SDK.Operacoes.operacao.RecuperarProcessos)
                {

                    _Processos = ((ContratoServico.Processo.RecuperarProcessos.RespostaRecuperarProcessos)objSaida).Processos;

                    if (_Processos != null && _Processos.Count > 0)
                    {
                        if (Classes.Processos.ListaProcessos == null) { Classes.Processos.ListaProcessos = new System.Collections.Concurrent.ConcurrentBag<Comum.Clases.Processo>(); }

                        Comum.Clases.Processo objProcesso = null;

                        foreach (Comum.Clases.Processo i in _Processos)
                        {

                            objProcesso = Classes.Processos.ListaProcessos.FirstOrDefault(p => p.Identificador == i.Identificador);


                            if (objProcesso == null)
                            {
                                Classes.Processos.ListaProcessos.Add(new Comum.Clases.Processo()
                                {
                                    Identificador = i.Identificador,
                                    DataStatup = DateTime.Now,
                                    Descricao = i.Descricao,
                                    QuantidadeTentativas = i.QuantidadeTentativas,
                                    Tipo = i.Tipo,
                                    IntervaloExecucao = i.IntervaloExecucao > 0 ? i.IntervaloExecucao : 10,
                                    Items = new List<Comum.Clases.ItemProcesso>()
                                });

                                Classes.Processos.ListaProcessos.LastOrDefault().Items.AddRange(i.Items);
                            }
                            else
                            {
                                objProcesso.Descricao = i.Descricao;
                                if (objProcesso.Items == null) objProcesso.Items = new List<Comum.Clases.ItemProcesso>();
                                objProcesso.Items.AddRange(i.Items);
                            }
                        }


                        if (!_atualizacaoDadosStarted)
                        {
                            tmpAtualizacaoDados.Start();
                            tmpProcesso.Start();
                            _atualizacaoDadosStarted = true;
                        }

                    }
                }
                else if (operacao == SDK.Operacoes.operacao.RegistrarItemProcesso)
                {
                    Comum.Clases.ItemProcesso objItemProcesso = ((ContratoServico.Processo.RegistrarItemProcesso.RespostaRegistrarItemProcesso)objSaida).ItemProcesso;

                    Comum.Clases.Processo objProcesso = Classes.Processos.ListaProcessos.FirstOrDefault(lp => lp.Identificador == Parametros.Processo.Identificador);

                    if (objProcesso.Items == null) { objProcesso.Items = new List<Comum.Clases.ItemProcesso>(); }

                    objProcesso.Items.Add(objItemProcesso);

                    Server.Processos.IntegracaoAPI iapi = new Processos.IntegracaoAPI();
                    iapi.Executar(Parametros.Processo, objItemProcesso);

                }
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (ControleEstoque.Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login) ? ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }

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
            }
        }

        private void AbrirPainel(Boolean TrocaUsuario)
        {
            if (Parametros.Parametros.InformacaoUsuario != null && !TrocaUsuario)
            {
                if (frmPrincipal == null)
                {
                    frmPrincipal = new Principal();
                    frmPrincipal.ShowDialog();
                    frmPrincipal.Dispose();
                    frmPrincipal = null;
                }

            }
            else
            {
                ExecutarLogin();
            }
        }
        #endregion

        #region"Eventos"

        private void ntfIgerenceServer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                AbrirPainel(false);
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }

        private void ntfIgerenceServer_BalloonTipClicked(object sender, EventArgs e)
        {
            try
            {
                if (Parametros.Parametros.InformacaoUsuario == null)
                {
                    ExecutarLogin();
                }
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }
        #endregion

        private void tmpProcesso_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Classes.Processos.ListaProcessos != null && Classes.Processos.ListaProcessos.Count > 0)
                {

                    foreach (Comum.Clases.Processo p in Classes.Processos.ListaProcessos)
                    {
                        if (p.EmExecucao)
                        {
                            var objProcesoExecucao = (from pe in _ProcesosExecucao where pe.Key == p.Identificador select pe).FirstOrDefault();

                            if (!string.IsNullOrEmpty(objProcesoExecucao.Key) && p.Items != null && p.Items.Count > 0 && p.QuantidadeItemsExecutar == p.Items.FindAll(i => !i.EmExecucao).Count)
                            {
                                objProcesoExecucao.Value.Finalizar(p, null, null);
                                _ProcesosExecucao.Remove(objProcesoExecucao.Key);
                            }
                        }

                        if (p.ProximaExecucao <= DateTime.Now && !p.EmExecucao)
                        {
                            if (p.Tipo == Comum.Enumeradores.TipoProcesso.API)
                            {

                                Server.Processos.IntegracaoAPI iapi = new Processos.IntegracaoAPI();

                                iapi.Executar(p, null);

                                _ProcesosExecucao.Add(iapi.IdentificadorProcesso, iapi);
                            }
                            else if (p.Tipo == Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA)
                            {
                                if (p.Items != null && p.Items.Count > 0)
                                {
                                    foreach (var ip in p.Items)
                                    {
                                        if (ip.DataExecucaoProgramada <= DateTime.Now)
                                        {
                                            Server.Processos.EmailFechamentoVenda objProcesso = new Processos.EmailFechamentoVenda();

                                            objProcesso.Executar(p, ip);

                                            _ProcesosExecucao.Add(objProcesso.IdentificadorProcesso, objProcesso);
                                        }
                                    }
                                }


                            }

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }

        private void tlpSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }

        private void tmpAtualizacaoDados_Tick(object sender, EventArgs e)
        {
            try
            {
                RecuperarParametros();
                RecuperarProcessos();
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }

        private void tlpTrocarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirPainel(true);
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }
        private void tlpExibirPainel_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirPainel(false);
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }

        private void tmpAtualizarProcessos_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarParametros();
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
            }
        }
    }
}
