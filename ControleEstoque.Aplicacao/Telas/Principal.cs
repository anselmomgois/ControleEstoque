using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Execao;
using System.IO;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using System.Configuration;
using Informatiz.ControleEstoque.Aplicacao;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class Principal : TelaBase.BaseCE
    {
        public Principal()
        {
            InitializeComponent();

            string Versao = Application.ProductVersion.Replace("1.0.", string.Empty);

            lblVersaoPreencher.Text = "Versão: 1.0 Build(" + Versao + ")";

            bgwImagemCentro = new System.ComponentModel.BackgroundWorker();

            bgwImagemCentro.DoWork += new System.ComponentModel.DoWorkEventHandler(bgwImagemCentro_DoWork);
            bgwImagemCentro.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgwImagemCentro_RunWorkerCompleted);

            bgwVersao = new System.ComponentModel.BackgroundWorker();

            bgwVersao.DoWork += new System.ComponentModel.DoWorkEventHandler(bgwVersao_DoWork);
            bgwVersao.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgwVersao_RunWorkerCompleted);
            pnlNotificacao.Dock = DockStyle.Fill;
            pnlNotificacao.Visible = false;

        }

        #region "Constantes"

        private const string tCadastros = "tCadastros";
        private const string tProdutosServicos = "tProdutosServicos";
        private const string tRelatorios = "tRelatorios";
        private const string tCompra = "tCompra";
        private const string tVenda = "tVenda";
        private const string tPermissoes = "tPermissoes";
        private const string tSobre = "tSobre";
        private const string tCrm = "tCrm";
        private const string tInformatiz = "tInformatiz";
        private const string tInformacoes = "tInformacoes";
        private const string tConfiguracoes = "tConfiguracoes";
        private const string tBackup = "tBackup";


        private const string gPessoas = "gPessoas";
        private const string gGeral = "gGeral";
        private const string gProdutosServicos = "gProdutosServicos";
        private const string gRelatorios = "gRelatorios";
        private const string gCompra = "gCompra";
        private const string gPermissoes = "gPermissoes";
        private const string gRegistrarSistema = "gRegistrarSistema";
        private const string gAgenda = "gAgenda";
        private const string gProposta = "gProposta";
        private const string gCadastrosInformatiz = "gCadastrosInformatiz";
        private const string gLicenca = "gLicenca";
        private const string gConfiguracoesInformatiz = "gConfiguracoesInformatiz";
        private const string gParametros = "gParametros";
        private const string gBackup = "gBackup";
        private const string gNovaVersao = "gNovaVersao";
        private const string gVenda = "gVenda";

        private const string btnclientes = "btnClientes";
        private const string btnFuncionarios = "btnFuncionarios";
        private const string btnFornecedor = "btnFornecedor";
        private const string btnTipoEmpregado = "btnTipoEmpregado";
        private const string btnEmpresa = "btnEmpresa";
        private const string btnSegmentoComercial = "btnSegmentoComercial";
        private const string btnAdminCartao = "btnAdminCartao";
        private const string btnFormaPagamento = "btnFormaPagamento";
        private const string btnCaixa = "btnCaixa";
        private const string btnSetor = "btnSetor";
        private const string btnMesa = "btnMesa";
        private const string btnProcessos = "btnProcessos";
        private const string btnCores = "btnCores";
        private const string btnUnidadeMedida = "btnUnidadeMedida";
        private const string btnCategoria = "btnCategoria";
        private const string btnMarca = "btnMarca";
        private const string btnDerivacao = "btnDerivacao";
        private const string btnGrupoProdutos = "btnGrupoProdutos";
        private const string btnProdutosServicos = "btnProdutosServicos";
        private const string btnComissao = "btnComissao";
        private const string btnObservacao = "btnObservacao";
        private const string btnCfop = "btnCfop";
        private const string btnCst = "btnCst";
        private const string btnNcm = "btnNcm";
        private const string btnPromocoes = "btnPromocoes";
        private const string btnRelatorioEstoque = "btnRelatorioEstoque";
        private const string btnRelatorioPessoas = "btnRelatorioPessoas";
        private const string btnCompra = "btnCompra";
        private const string btnGrupoPermissoes = "btnGrupoPermissoes";
        private const string btnPermissoes = "btnPermissoes";
        private const string btnStatusCrm = "btnStatusCrm";
        private const string btnTipoCrm = "btnStatusCrm";
        private const string btnIntegracaoAPI = "btnIntegracaoAPI";
        private const string btnProposta = "btnProposta";
        private const string btnPublicidade = "btnPublicidade";
        private const string btnLicencaDisponivel = "btnLicencaDisponivel";
        private const string btnGerarLicenca = "btnGerarLicenca";
        private const string btnAlterarImagemCentral = "btnAlterarImagemCentral";
        private const string btnParametros = "btnParametros";
        private const string btnGerarBackup = "btnGerarBackup";
        private const string btnNivelAtendimento = "btnNivelAtendimento";
        private const string btnCompromissos = "btnCompromissos";
        private const string btnRegistrarSistema = "btnRegistrarSistema";
        private const string btnNovaVersao = "btnNovaVersao";
        private const string btnVendaSupermercado = "btnVendaSupermercado";
        private const string btnVendaComanda = "btnVendaComanda";
        private const string btnVendaTouch = "btnVendaTouch";

        #endregion
        #region "Metodos"

        private string RecuperarDescricao(string Identificador, Boolean Tab)
        {
            if (Tab)
            {
                if (objTabMenu != null && objTabMenu.Count > 0 && objTabMenu.Exists(m => m.Identificador == Identificador))
                {
                    return objTabMenu.Find(m => m.Identificador == Identificador).Descricao;
                }
            }
            else
            {
                if (objGrupoMenu != null && objGrupoMenu.Count > 0 && objGrupoMenu.Exists(m => m.Identificador == Identificador))
                {
                    return objGrupoMenu.Find(m => m.Identificador == Identificador).Descricao;
                }
            }
            return string.Empty;
        }
        private void AdicionarGrupoMenu()
        {
            objTabMenu = new List<Classes.ValorDescricao>();
            objGrupoMenu = new List<Classes.ValorDescricao>();

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tCadastros,
                Descricao = "Cadastros"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tRelatorios,
                Descricao = "Relatórios"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tProdutosServicos,
                Descricao = "Produtos e Serviços"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tInformacoes,
                Descricao = "Informações"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tBackup,
                Descricao = "Backup"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tInformatiz,
                Descricao = "Informatiz"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tSobre,
                Descricao = "Sobre"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tConfiguracoes,
                Descricao = "Configurações"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tPermissoes,
                Descricao = "Permissões"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tCompra,
                Descricao = "Compra"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tVenda,
                Descricao = "Venda"
            });

            objTabMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = tCrm,
                Descricao = "CRM"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gPessoas,
                Descricao = "Pessoas"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gGeral,
                Descricao = "Geral"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gProdutosServicos,
                Descricao = "Produtos e Serviços"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gRelatorios,
                Descricao = "Relatórios"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gCompra,
                Descricao = "Compra"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gPermissoes,
                Descricao = "Permissões"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gRegistrarSistema,
                Descricao = "Registrar Sistema"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gAgenda,
                Descricao = "Agenda"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gProposta,
                Descricao = "Proposta"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gCadastrosInformatiz,
                Descricao = "Cadastro"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gLicenca,
                Descricao = "Licenças"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gConfiguracoesInformatiz,
                Descricao = "Configurações"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gBackup,
                Descricao = "Backup"
            });

            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gNovaVersao,
                Descricao = "Nova Versão"
            });
            objGrupoMenu.Add(new Classes.ValorDescricao()
            {
                Identificador = gVenda,
                Descricao = "Venda"
            });


        }

        private void RecuperarAgendamentos()
        {
            List<string> IdentificadoresFuncionario = null;
            Nullable<DateTime> DataFim = null;

            DataFim = DateTime.Now.AddDays(1);


            if (IdentificadoresFuncionario == null) { IdentificadoresFuncionario = new List<string>(); }
            IdentificadoresFuncionario.Add(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador);

            ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples Peticao = new ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples();

            Peticao.IdentificadoresFuncionariosResponsaveis = IdentificadoresFuncionario;
            //Peticao.DataFim = DataFim;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.ValidacoesExpecificas = false;
            Peticao.Ativo = true;


            Agente.Agente.InvocarServico<ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples, ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples>(Peticao,
                    SDK.Operacoes.operacao.RecuperarAgendamentosSimples, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarAgendamentosSimples)
            {
                Agendamentos = ((ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples)objSaida).Agendamentos;

                if (Agendamentos != null && Agendamentos.Count > 0 && Agendamentos.Exists(a => a.UsuariosResponsaveis != null && a.UsuariosResponsaveis.Exists(u => u == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador)))
                {
                    pnlNotificacao.Controls.Clear();

                    Controles.ucNotificacoesUsuario objNotificacoes = new Controles.ucNotificacoesUsuario(Agendamentos);
                    objNotificacoes.Dock = DockStyle.Fill;

                    pnlNotificacao.Controls.Add(objNotificacoes);


                    try
                    {

                        Int32 Quantidade = 0;

                        Agendamentos.ForEach(a => Quantidade = (a.UsuariosResponsaveis != null && a.UsuariosResponsaveis.Exists(u => u == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador) ? Quantidade + 1 : Quantidade));

                        if (!this.ExisteOrbMenu("btnNotificacao"))
                        {


                            this.AdicionarOrbMenu("btnNotificacao",
                                (Quantidade == 1 ? Quantidade + " Notificação" : Quantidade + " Notificações"), false, new EventHandler(tsmNotificacao_Click),
                                Properties.Resources.new_yellow);
                        }
                        else
                        {

                            this.AtualizarTextoOrbMenu("btnNotificacao", (Quantidade == 1 ? Quantidade + " Notificação" : Quantidade + " Notificações"));
                        }

                        if (_QuantidadeNotificacoes != Quantidade)
                        {
                            Classes.Util.ExibirMensagemInformacao(String.Format("Você tem {0}", (Quantidade == 1 ? Quantidade + " Notificação" : Quantidade + " Notificações")));
                        }

                        _QuantidadeNotificacoes = Quantidade;
                    }
                    catch (Exception ex)
                    {
                        Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
                    }

                }
            }
            else if (operacao == SDK.Operacoes.operacao.AtualizarSessao)
            {
                ContratoServico.Sessao.AtualizarSessao.RespostaAtualizarSessao objSaidaSessao = ((ContratoServico.Sessao.AtualizarSessao.RespostaAtualizarSessao)objSaida);

                if (objSaidaSessao.SessaoExpirada)
                {
                    Classes.Util.ExibirMensagemInformacao("Sessão expirada");
                    System.Threading.Thread.Sleep(3000);
                    this.Close();
                }

            }
            else if (operacao == SDK.Operacoes.operacao.BuscarCaixaByHost)
            {
                Comum.Clases.Caixa objCaixa = ((ContratoServico.Caixa.BuscarCaixaByHost.RespostaBuscarCaixaByHost)objSaida).Caixa;

                if (Parametros.DiferenciadorChamada == "SIMPLES")
                {
                    if (objCaixa != null)
                    {

                        if (objCaixa.EstaAberto)
                        {
                            if (objCaixa.OperacaoCaixa != null && objCaixa.OperacaoCaixa.FuncionarioCaixa.Identificador == Informatiz.ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador)
                            {
                                VendaSupermercado frmVendaSupermercado = new VendaSupermercado(objCaixa);
                                AbrirFormulario(frmVendaSupermercado);
                            }
                            else
                            {
                                throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO,
                                                              string.Format("O caixa já está sendo operado pelo funcionário {0}, favor fazer o fechamento do caixa para trocar o operador.", objCaixa.OperacaoCaixa.FuncionarioCaixa.DesNome));
                            }
                        }
                        else
                        {
                            AberturaCaixa frmAberturaCaixa = new AberturaCaixa(objCaixa);
                            if (AbrirFormulario(frmAberturaCaixa) == DialogResult.OK)
                            {
                                objCaixa.EstaAberto = true;
                                if (objCaixa.OperacaoCaixa == null) objCaixa.OperacaoCaixa = new Comum.Clases.OperacaoCaixa();
                                objCaixa.OperacaoCaixa.Identificador = frmAberturaCaixa.IdentificadorResponsavelCaixa;

                                VendaSupermercado frmVendaSupermercado = new VendaSupermercado(objCaixa);
                                AbrirFormulario(frmVendaSupermercado);
                            }
                        }

                    }
                    else
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não foi cadastrado nenhum caixa para este computador.");
                    }
                }
                else
                {

                    if (objCaixa != null)
                    {

                        if (objCaixa.EstaAberto)
                        {
                            if (objCaixa.OperacaoCaixa != null && objCaixa.OperacaoCaixa.FuncionarioCaixa.Identificador == Informatiz.ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador)
                            {
                                VendaPorComanda frmVendaSupermercado = new VendaPorComanda(objCaixa);
                                AbrirFormulario(frmVendaSupermercado);
                            }
                            else
                            {
                                throw new Execao.ExecaoNegocio(Constantes.CodigoErro.ERRO_NEGOCIO,
                                                              string.Format("O caixa já está sendo operado pelo funcionário {0}, favor fazer o fechamento do caixa para trocar o operador.", objCaixa.OperacaoCaixa.FuncionarioCaixa.DesNome));
                            }
                        }
                        else
                        {
                            AberturaCaixa frmAberturaCaixa = new AberturaCaixa(objCaixa);
                            if (AbrirFormulario(frmAberturaCaixa) == DialogResult.OK)
                            {
                                objCaixa.EstaAberto = true;
                                if (objCaixa.OperacaoCaixa == null) objCaixa.OperacaoCaixa = new Comum.Clases.OperacaoCaixa();
                                objCaixa.OperacaoCaixa.Identificador = frmAberturaCaixa.IdentificadorResponsavelCaixa;

                                VendaPorComanda frmVendaSupermercado = new VendaPorComanda(objCaixa);
                                AbrirFormulario(frmVendaSupermercado);
                            }
                        }

                    }
                    else
                    {
                        VendaPorComanda frmVendaSupermercado = new VendaPorComanda(null);
                        AbrirFormulario(frmVendaSupermercado);
                    }

                }

            }
        }


        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            CarregarMenu();
            base.MontarMenu(GerarGrupo);
        }


        private void CarregarMenu()
        {

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_ADMINISTRADORA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_TIPO_EMPREGADO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_EMPRESA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CAIXA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SEGMENTO_COMERCIAL, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SETOREMPRESA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_MESA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROCESSO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORMA_PAGAMENTO, null))
            {

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, null))
                {
                    this.AdicionarItemMenu(gPessoas, RecuperarDescricao(gPessoas, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Clientes", btnclientes, Properties.Resources.cliente, new EventHandler(tsmClientes_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, null))
                {

                    this.AdicionarItemMenu(gPessoas, RecuperarDescricao(gPessoas, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Funcionário", btnFuncionarios, Properties.Resources.empregado, new EventHandler(tsmFuncionario_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, null))
                {
                    this.AdicionarItemMenu(gPessoas, RecuperarDescricao(gPessoas, false), tCadastros, RecuperarDescricao(tCadastros, true), "F&ornecedor", btnFornecedor, Properties.Resources.lorrygreen, new EventHandler(tsmFornecedor_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_TIPO_EMPREGADO, null))
                {

                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Tipo Empregado", btnTipoEmpregado, Properties.Resources.employee, new EventHandler(tsmTipoEmpregado_Click));

                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_EMPRESA, null))
                {
                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Empresa", btnEmpresa,
                        Properties.Resources.office_building, new EventHandler(tsmEmpresa_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SEGMENTO_COMERCIAL, null))
                {
                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Segmento Comercial", btnSegmentoComercial,
                       Properties.Resources.kchart, new EventHandler(tsmSegmentoComercial_Click));
                }


                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_ADMINISTRADORA, null))
                {

                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Admin. Cartão Credito", btnAdminCartao,
                       Properties.Resources.card_back_share, new EventHandler(tsmAdministradora_Click));

                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORMA_PAGAMENTO, null))
                {

                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Forma de Pagamento", btnFormaPagamento,
                      Properties.Resources.forma_pagamento, new EventHandler(tsmFormaPagamento_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CAIXA, null))
                {
                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Caixa", btnCaixa,
                      Properties.Resources.img_caixa, new EventHandler(tsmCaixa_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SETOREMPRESA, null))
                {
                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Setor", btnSetor,
                      Properties.Resources.share_alt_2, new EventHandler(tsmSetor_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_MESA, null))
                {
                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Mesa", btnMesa,
                      Properties.Resources.table, new EventHandler(tsmMesa_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROCESSO, null))
                {
                    this.AdicionarItemMenu(gGeral, RecuperarDescricao(gGeral, false), tCadastros, RecuperarDescricao(tCadastros, true), "&Processos", btnProcessos,
                      Properties.Resources.process, new EventHandler(tsmProcesso_Click));
                }


            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CORES, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_UNIDADE_MEDIDA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CATEGORIA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_MARCA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_DERIVACAO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_PRODUTO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_SERVICO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_COMISSAO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CST, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CFOP, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_NCM, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_OBSERVACAO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_PROMOCAO, null))
            {
                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CORES, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "&Cores", btnCores,
                     Properties.Resources.color, new EventHandler(tsmCores_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_UNIDADE_MEDIDA, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "&Unidade de Medida", btnUnidadeMedida,
                     Properties.Resources.diagram_v2_19, new EventHandler(tsmUnidadeMedida_Click));
                }


                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CATEGORIA, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "C&ategoria", btnCategoria,
                    Properties.Resources.category, new EventHandler(tsmCategoria_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_MARCA, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "&Marca", btnMarca,
                   Properties.Resources.mark, new EventHandler(tsmMarca_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_DERIVACAO, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "&Derivação", btnDerivacao,
                  Properties.Resources.material, new EventHandler(tsmDerivacao_Click));

                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_PRODUTO, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "&Grupo de Produtos", btnGrupoProdutos,
                 Properties.Resources.work_group, new EventHandler(tsmGrupoProduto_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_SERVICO, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "&Produtos e Serviços", btnProdutosServicos,
                Properties.Resources.product_documentation, new EventHandler(tsmProdutoServico_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_COMISSAO, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "Co&missão", btnComissao,
                Properties.Resources.coins, new EventHandler(tsmProdutoComissao_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_OBSERVACAO, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true), "&Observação", btnObservacao,
                Properties.Resources.product_in_process_info, new EventHandler(tsmProdutoObservacao_Click));
                }

                //this.AdicionarComboMenu(gProdutosServicos, tCadastros);
                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CST, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true),
                        "Cod. Situação Tributária", btnCst,
               Properties.Resources.taxa1, new EventHandler(tsmProdutoCST_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CFOP, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true),
                       "Cod. Fiscal Op. e Prestações", btnCfop,
              Properties.Resources.taxa2, new EventHandler(tsmProdutoCFOP_Click));

                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_NCM, null))
                {
                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true),
                     "Código &NCM", btnNcm,
            Properties.Resources.taxa3, new EventHandler(tsmProdutoNCM_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_PROMOCAO, null))
                {

                    this.AdicionarItemMenu(gProdutosServicos, RecuperarDescricao(gProdutosServicos, false), tProdutosServicos, RecuperarDescricao(tProdutosServicos, true),
                     "Promoçõ&es", btnPromocoes,
            Properties.Resources.promocao, new EventHandler(tsmProdutoPromocao_Click));

                }
            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_RELATORIO_ESTOQUE, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_RELATORIO_PESSOAS, null))
            {
                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_RELATORIO_ESTOQUE, null))
                {

                    this.AdicionarItemMenu(gRelatorios, RecuperarDescricao(gRelatorios, false), tRelatorios, RecuperarDescricao(tRelatorios, true),
                    "Relatório de &Estoque", btnRelatorioEstoque,
           Properties.Resources.bar_chart, new EventHandler(tsmRelatorioEstoque_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_RELATORIO_PESSOAS, null))
                {

                    this.AdicionarItemMenu(gRelatorios, RecuperarDescricao(gRelatorios, false), tRelatorios, RecuperarDescricao(tRelatorios, true),
                    "Relatório de &Pessoas", btnRelatorioPessoas,
           Properties.Resources.report_user, new EventHandler(tsmRelatorioPessoas_Click));

                }
            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPRAS, null))
            {

                this.AdicionarItemMenu(gCompra, RecuperarDescricao(gCompra, false), tCompra, RecuperarDescricao(tCompra, true),
                 "&Compras", btnCompra,
        Properties.Resources.shopcart, new EventHandler(tsmCompras_Click));
            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_VENDASIMPLES, null))
            {

                this.AdicionarItemMenu(gVenda, RecuperarDescricao(gVenda, false), tVenda, RecuperarDescricao(tVenda, true),
                "Venda Simples", btnVendaSupermercado,
       Properties.Resources.order, new EventHandler(tsmVendaSupermercado_Click));
            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_VENDASIMPLES, null))
            {

                this.AdicionarItemMenu(gVenda, RecuperarDescricao(gVenda, false), tVenda, RecuperarDescricao(tVenda, true),
                "Venda Touch", btnVendaTouch,
       Properties.Resources.order, new EventHandler(tsmVendaTouch_Click));
            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_VENDACOMANDA, null))
            {

                this.AdicionarItemMenu(gVenda, RecuperarDescricao(gVenda, false), tVenda, RecuperarDescricao(tVenda, true),
                "Venda Comanda", btnVendaComanda,
       Properties.Resources.order_orange, new EventHandler(tsmVendaComanda_Click));
            }


            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPOPERMISSAO, null) ||
            Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PERMISSAOUSUARIO, null))
            {

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPOPERMISSAO, null))
                {
                    this.AdicionarItemMenu(gPermissoes, RecuperarDescricao(gPermissoes, false), tPermissoes, RecuperarDescricao(tPermissoes, true),
                 "&Grupo de Permissões", btnGrupoPermissoes,
        Properties.Resources.group_key, new EventHandler(tsmGrupo_Click));
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PERMISSAOUSUARIO, null))
                {

                    this.AdicionarItemMenu(gPermissoes, RecuperarDescricao(gPermissoes, false), tPermissoes, RecuperarDescricao(tPermissoes, true),
                 "Permissões do &Usuário", btnPermissoes,
        Properties.Resources.cadeado_fechado, new EventHandler(tsmPermissoesUsuario_Click));
                }


            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_COMPROMISSO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROPOSTA, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPROMISSO, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_TIPO_CRM, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_INTEGRACAOAPI, null) ||
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_STATUS_CRM, null))
            {

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_COMPROMISSO, null) ||
                    Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPROMISSO, null) ||
                    Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_TIPO_CRM, null) ||
                    Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_INTEGRACAOAPI, null) ||
                    Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_STATUS_CRM, null))
                {

                    if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPROMISSO, null))
                    {

                        this.AdicionarItemMenu(gAgenda, RecuperarDescricao(gAgenda, false), tCrm, RecuperarDescricao(tCrm, true),
                "&Compromissos", btnCompromissos,
       Properties.Resources.date, new EventHandler(tsmCompromissos_Click));
                    }

                    if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_COMPROMISSO, null))
                    {

                        this.AdicionarItemMenu(gAgenda, RecuperarDescricao(gAgenda, false), tCrm, RecuperarDescricao(tCrm, true),
                 "&Nivel de Atendimento", btnNivelAtendimento,
        Properties.Resources.purple_group, new EventHandler(tsmGrupoCompromissos_Click));
                    }

                    if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_TIPO_CRM, null))
                    {
                        this.AdicionarItemMenu(gAgenda, RecuperarDescricao(gAgenda, false), tCrm, RecuperarDescricao(tCrm, true),
               "&Tipo CRM", btnTipoCrm,
      Properties.Resources.tipo_crm, new EventHandler(tsmTipoCrm_Click));
                    }

                    if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_STATUS_CRM, null))
                    {
                        this.AdicionarItemMenu(gAgenda, RecuperarDescricao(gAgenda, false), tCrm, RecuperarDescricao(tCrm, true),
               "&Status CRM", btnStatusCrm,
      Properties.Resources.status_crm, new EventHandler(tsmStatusCrm_Click));
                    }

                    if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_INTEGRACAOAPI, null))
                    {
                        this.AdicionarItemMenu(gAgenda, RecuperarDescricao(gAgenda, false), tCrm, RecuperarDescricao(tCrm, true),
               "&Integração API", btnIntegracaoAPI,
      Properties.Resources.smart_folder, new EventHandler(tsmIntegracaoAPI_Click));
                    }
                }

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROPOSTA, null))
                {

                    this.AdicionarItemMenu(gProposta, RecuperarDescricao(gProposta, false), tCrm, RecuperarDescricao(tCrm, true),
               "&Proposta", btnProposta,
      Properties.Resources.contract_zoom, new EventHandler(tsmPropostas_Click));
                }
            }

            if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.EmpresaMestre && !ControleEstoque.Parametros.Parametros.InformacaoUsuario.Consultor)
            {

                this.AdicionarItemMenu(gCadastrosInformatiz, RecuperarDescricao(gCadastrosInformatiz, false), tInformatiz, RecuperarDescricao(tInformatiz, true),
              "&Publicidades", btnPublicidade,
     Properties.Resources.the_news_location_icon, new EventHandler(tsmPublicidade_Click));

                this.AdicionarItemMenu(gLicenca, RecuperarDescricao(gLicenca, false), tInformatiz, RecuperarDescricao(tInformatiz, true),
"Lincenças &Disponiveis", btnLicencaDisponivel,
Properties.Resources.key_info, new EventHandler(tsmChaves_Click));

                this.AdicionarItemMenu(gLicenca, RecuperarDescricao(gLicenca, false), tInformatiz, RecuperarDescricao(tInformatiz, true),
"&Gerar Licença", btnGerarLicenca,
Properties.Resources.key_add, new EventHandler(tsmGerarChaves_Click));

                this.AdicionarItemMenu(gConfiguracoesInformatiz, RecuperarDescricao(gConfiguracoesInformatiz, false), tInformatiz, RecuperarDescricao(tInformatiz, true),
"&Alterar Imagem Central", btnAlterarImagemCentral,
Properties.Resources.pics_1, new EventHandler(tsmAlterarImagem_Click));

            }

            if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PARAMETROS, null))
            {
                this.AdicionarItemMenu(gParametros, RecuperarDescricao(gParametros, false), tConfiguracoes, RecuperarDescricao(tConfiguracoes, true),
"&Parametros", btnParametros,
Properties.Resources.settings1, new EventHandler(tsmParametros_Click));
            }

            this.AdicionarItemMenu(gBackup, RecuperarDescricao(gBackup, false), tBackup, RecuperarDescricao(tBackup, true),
"&Gerar Backup", btnGerarBackup,
Properties.Resources.hard_drive_backups, new EventHandler(tsmBackup_Click));

            this.AdicionarItemMenu(gBackup, RecuperarDescricao(gBackup, false), tBackup, RecuperarDescricao(tBackup, true),
"&Restaurar Backup", btnGerarBackup,
Properties.Resources.system_restore, new EventHandler(tsmRestaurar_Click));

            if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.CodAcesso == Comum.Clases.Constantes.COD_ACESSO_LIMITADO)
            {

                this.AdicionarItemMenu(gRegistrarSistema, RecuperarDescricao(gRegistrarSistema, false), tSobre, RecuperarDescricao(tSobre, true),
                "&Registrar Sistema", btnRegistrarSistema,
       Properties.Resources.logoff, new EventHandler(btnRegistrar_Click));
            }

            this.AdicionarItemMenu(gNovaVersao, RecuperarDescricao(gNovaVersao, false), tInformacoes, RecuperarDescricao(tInformacoes, true),
            "&Nova Versão Disponivel", btnNovaVersao,
   Properties.Resources.agt_reload, new EventHandler(tsmAtualizarVersao_Click), true);

            this.OcultarTab(tInformacoes, true);

        }

        private void CarregarInformacoesIniciais()
        {

            if (Comum.Clases.Constantes.COD_ACESSO_LIMITADO == ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.CodAcesso)
            {
                lblAcesso.Text = "Acesso Limitado";
                imgCadeado.Image = Properties.Resources.cadeado_fechado;
                lblAcesso.ForeColor = Color.Red;
            }
            else
            {
                lblAcesso.Text = "Acesso Total";
                imgCadeado.Image = Properties.Resources.cadeado_aberto;
            }

            lblUsuarioValor.Text = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            lblFilial.Text = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.First().Nome;
            lblEmpresa.Text = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome;
        }

        private void CarregarImagem()
        {

            ContratoServico.RecuperarImagem.Peticao objPeticao = new ContratoServico.RecuperarImagem.Peticao();
            Comunicacao.Proxy objProxy = new Comunicacao.Proxy();

            objPeticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            ContratoServico.RecuperarImagem.Resposta objRespuesta = objProxy.RecuperarImagem(objPeticao);

            if (objRespuesta != null && objRespuesta.objImagem != null && objRespuesta.objImagem.ImgImagemCentral != null)
            {

                MemoryStream imgBits = new MemoryStream(objRespuesta.objImagem.ImgImagemCentral);
                Bitmap img = new Bitmap(imgBits);
                objFoto = img;
                //pnlImagem.BackgroundImage = objFoto;

            }

        }

        private void RecuperarVersao()
        {

            ContratoServico.RecuperarVersao.Peticao objPeticao = new ContratoServico.RecuperarVersao.Peticao();
            Comunicacao.Proxy objProxy = new Comunicacao.Proxy();

            objPeticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            ContratoServico.RecuperarVersao.Resposta objRespuesta = objProxy.RecuperarVersao(objPeticao);

            if (objRespuesta != null)
            {
                VersaoDownload = objRespuesta.CodigoVersao;
            }

        }

        protected override void Inicializar()
        {
            ControleEstoque.Parametros.Parametros.DiretorioArquivos = ConfigurationManager.AppSettings["UrlDiretorioArquivo"];
            CarregarInformacoesIniciais();
            AdicionarGrupoMenu();
            MontarMenu(true);

            tlpAtualizarSessao.Start();

            Form.CheckForIllegalCrossThreadCalls = false;

            bgwImagemCentro.RunWorkerAsync();
            bgwVersao.RunWorkerAsync();
            base.Inicializar();
        }

        #endregion


        #region"Variaveis"

        private System.ComponentModel.BackgroundWorker bgwImagemCentro;
        private System.ComponentModel.BackgroundWorker bgwVersao;
        private Image objFoto;
        private string Executavel;
        private System.Net.WebClient wc;
        private string VersaoDownload;
        private List<Comum.Clases.CRMSimples> Agendamentos;
        private List<Classes.ValorDescricao> objTabMenu;
        private List<Classes.ValorDescricao> objGrupoMenu;
        private Int32 _QuantidadeNotificacoes = 0;
        // private List<Comum.Clases.Caixa> objCaixas = null;

        #endregion

        #region "Eventos" 

        private void tsmFuncionario_Click(object sender, EventArgs e)
        {

            try
            {

                Cliente frmcliente = new Cliente(Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO);
                AbrirFormulario(frmcliente);


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmClientes_Click(object sender, EventArgs e)
        {

            try
            {

                Cliente frmcliente = new Cliente(Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE);
                AbrirFormulario(frmcliente);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void tsmPermissoesUsuario_Click(object sender, EventArgs e)
        {

            try
            {

                Cliente frmcliente = new Cliente(Comum.Enumeradores.Enumeradores.TipoPessoaEnum.PERMISSAO);
                AbrirFormulario(frmcliente);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void tsmBackup_Click(object sender, EventArgs e)
        {

            try
            {

                GerarBackup frmBackup = new GerarBackup(false);
                AbrirFormulario(frmBackup);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void tsmPublicidade_Click(object sender, EventArgs e)
        {

            try
            {

                BuscaPublicidade frmPublicidade = new BuscaPublicidade();
                AbrirFormulario(frmPublicidade);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void tsmChaves_Click(object sender, EventArgs e)
        {

            try
            {

                Chaves frmChaves = new Chaves();
                AbrirFormulario(frmChaves);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void tsmAlterarImagem_Click(object sender, EventArgs e)
        {

            try
            {

                ModificarImagem frmChaves = new ModificarImagem();
                AbrirFormulario(frmChaves);

                Form.CheckForIllegalCrossThreadCalls = false;
                bgwImagemCentro.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void tsmGerarChaves_Click(object sender, EventArgs e)
        {

            try
            {

                GerarChave frmChaves = new GerarChave();
                AbrirFormulario(frmChaves);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void tsmRestaurar_Click(object sender, EventArgs e)
        {

            try
            {

                GerarBackup frmBackup = new GerarBackup(true);
                AbrirFormulario(frmBackup);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }


        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarChave frmValidarChave = new ValidarChave();


                if (AbrirFormulario(frmValidarChave) == System.Windows.Forms.DialogResult.OK)
                {

                    Aplicacao.Classes.Util.ExibirMensagemInformacao("A aplicação deve ser reiniciada.");
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }


        }

        private void tsmFornecedor_Click(object sender, EventArgs e)
        {
            try
            {

                Cliente frmcliente = new Cliente(Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR);
                AbrirFormulario(frmcliente);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmTipoEmpregado_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaTipoEmpregado frmcliente = new BuscaTipoEmpregado();
                AbrirFormulario(frmcliente);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmEmpresa_Click(object sender, EventArgs e)
        {
            try
            {

                GuardarEmpresa frmEmpresa = new GuardarEmpresa();
                AbrirFormulario(frmEmpresa);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmSegmentoComercial_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaSegmentoComercial frmEmpresa = new BuscaSegmentoComercial();
                AbrirFormulario(frmEmpresa);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmAdministradora_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaAdministradora frmAdministradora = new BuscaAdministradora();
                AbrirFormulario(frmAdministradora);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmFormaPagamento_Click(object sender, EventArgs e)
        {
            try
            {

                BuscarFormaPagamento frmBuscaFormaPagamento = new BuscarFormaPagamento();
                AbrirFormulario(frmBuscaFormaPagamento);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmCaixa_Click(object sender, EventArgs e)
        {
            try
            {

                BuscarCaixa frmBuscaCaixa = new BuscarCaixa();
                AbrirFormulario(frmBuscaCaixa);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmSetor_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaSetorEmpresa frmBuscaCaixa = new BuscaSetorEmpresa();
                AbrirFormulario(frmBuscaCaixa);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmMesa_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaMesa frmBuscaMesa = new BuscaMesa();
                AbrirFormulario(frmBuscaMesa);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProcesso_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProcesso frmBuscaProcessos= new BuscaProcesso();
                AbrirFormulario(frmBuscaProcessos);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmCores_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaCores frmCores = new BuscaCores();
                AbrirFormulario(frmCores);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmUnidadeMedida_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaUnidadeMedida frmUnidadeMedida = new BuscaUnidadeMedida();
                AbrirFormulario(frmUnidadeMedida);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmCategoria_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProdutoCategoria frmProdutoCategoria = new BuscaProdutoCategoria();
                AbrirFormulario(frmProdutoCategoria);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmMarca_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProdutoMarca frmProdutoMarca = new BuscaProdutoMarca();
                AbrirFormulario(frmProdutoMarca);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmDerivacao_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProdutoDerivacao frmProdutoDerivacao = new BuscaProdutoDerivacao();
                AbrirFormulario(frmProdutoDerivacao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmGrupoProduto_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaGrupoProduto frmGrupoProduto = new BuscaGrupoProduto();
                AbrirFormulario(frmGrupoProduto);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProdutoServico_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProdutoServico frmProdutoServico = new BuscaProdutoServico();
                AbrirFormulario(frmProdutoServico);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmCompras_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaCompras frmCompras = new BuscaCompras();
                AbrirFormulario(frmCompras);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }
        
        private void tsmVendaSupermercado_Click(object sender, EventArgs e)
        {
            try
            {

                ContratoServico.Caixa.BuscarCaixaByHost.PeticaoBuscarCaixaByHost Peticao = new ContratoServico.Caixa.BuscarCaixaByHost.PeticaoBuscarCaixaByHost();

                Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Identificador;
                Peticao.HostName = System.Net.Dns.GetHostName();
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Caixa.BuscarCaixaByHost.RespostaBuscarCaixaByHost, ContratoServico.Caixa.BuscarCaixaByHost.PeticaoBuscarCaixaByHost>(Peticao, SDK.Operacoes.operacao.BuscarCaixaByHost,
                    new Comum.ParametrosTela.Generica
                    {
                        ExibirMensagemNenhumRegistro = false,
                        PreencherObjeto = false,
                        DiferenciadorChamada = "SIMPLES"
                    }, null, true);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmVendaComanda_Click(object sender, EventArgs e)
        {
            try
            {

                ContratoServico.Caixa.BuscarCaixaByHost.PeticaoBuscarCaixaByHost Peticao = new ContratoServico.Caixa.BuscarCaixaByHost.PeticaoBuscarCaixaByHost();

                Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Identificador;
                Peticao.HostName = System.Net.Dns.GetHostName();
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Caixa.BuscarCaixaByHost.RespostaBuscarCaixaByHost, ContratoServico.Caixa.BuscarCaixaByHost.PeticaoBuscarCaixaByHost>(Peticao, SDK.Operacoes.operacao.BuscarCaixaByHost,
                    new Comum.ParametrosTela.Generica
                    {
                        ExibirMensagemNenhumRegistro = false,
                        PreencherObjeto = false,
                        DiferenciadorChamada = "COMANDA"
                    }, null, true);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmVendaTouch_Click(object sender, EventArgs e)
        {
            try
            {
               VendaTouch.VendaTouch frmVendaTouch = new VendaTouch.VendaTouch();
                AbrirFormulario(frmVendaTouch);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmParametros_Click(object sender, EventArgs e)
        {
            try
            {

                GuardarParametroValor frmParametroValor = new GuardarParametroValor();
                AbrirFormulario(frmParametroValor);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProdutoComissao_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProdutoComissao frmProdutoComissao = new BuscaProdutoComissao();
                AbrirFormulario(frmProdutoComissao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProdutoObservacao_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaObservacao frmProdutoObsrvacao = new BuscaObservacao();
                AbrirFormulario(frmProdutoObsrvacao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProdutoCST_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProdutoCST frmProdutoCST = new BuscaProdutoCST();
                AbrirFormulario(frmProdutoCST);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProdutoCFOP_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaProdutoCFOP frmProdutoCFOP = new BuscaProdutoCFOP();
                AbrirFormulario(frmProdutoCFOP);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProdutoNCM_Click(object sender, EventArgs e)
        {
            try
            {

                BuscarProdutoNCM frmProdutoNCM = new BuscarProdutoNCM();
                AbrirFormulario(frmProdutoNCM);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmProdutoPromocao_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaPromocao frmProdutoPromocao = new BuscaPromocao();
                AbrirFormulario(frmProdutoPromocao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmGrupo_Click(object sender, EventArgs e)
        {
            try
            {

                GrupoPermissao frmGrupo = new GrupoPermissao();
                AbrirFormulario(frmGrupo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmGrupoCompromissos_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaGrupoCompromisso frmGrupo = new BuscaGrupoCompromisso();
                AbrirFormulario(frmGrupo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmCompromissos_Click(object sender, EventArgs e)
        {
            try
            {

                BuscarCRM frmCRM = new BuscarCRM();
                AbrirFormulario(frmCRM);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmStatusCrm_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaStatusCrm frmCRM = new BuscaStatusCrm();
                AbrirFormulario(frmCRM);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmTipoCrm_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaTipoCrm frmCRM = new BuscaTipoCrm();
                AbrirFormulario(frmCRM);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmIntegracaoAPI_Click(object sender, EventArgs e)
        {
            try
            {

                BuscaIntegracaoAPI frmCRM = new BuscaIntegracaoAPI();
                AbrirFormulario(frmCRM);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmPropostas_Click(object sender, EventArgs e)
        {
            try
            {

                BuscarProposta frmProposta = new BuscarProposta();
                AbrirFormulario(frmProposta);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmAtualizarVersao_Click(object sender, EventArgs e)
        {
            try
            {

                psbAtualizar.Visible = true;

                string Diretorio = Path.GetTempPath();

                Diretorio += "\\IGERENCE";

                Executavel = Diretorio + "\\IGERENCE.msi";

                if (System.IO.Directory.Exists(Diretorio))
                {
                    if (System.IO.File.Exists(Executavel))
                    {
                        System.IO.File.Delete(Executavel);
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Diretorio);
                }

                wc = new System.Net.WebClient();
                Uri uri = new Uri(ControleEstoque.Parametros.Parametros.DiretorioArquivos + "/IGERENCE.msi");

                wc.DownloadFileAsync(uri, Executavel);

                Classes.Util.ExibirMensagemDownload("Download iniciado.");

                wc.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DownloadProgressChangedCallback);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompletedCallback);

                //objMenuVersao.Enabled = false;


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmNotificacao_Click(object sender, EventArgs e)
        {
            try
            {
                pnlNotificacao.Visible = !pnlNotificacao.Visible;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmRelatorioEstoque_Click(object sender, EventArgs e)
        {
            try
            {

                RelatorioEstoque frmRelatorioEstoque = new RelatorioEstoque();
                AbrirFormulario(frmRelatorioEstoque);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tsmRelatorioPessoas_Click(object sender, EventArgs e)
        {
            try
            {

                RelatorioPessoa frmRelatorioPessoas = new RelatorioPessoa();
                AbrirFormulario(frmRelatorioPessoas);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void tlpAtualizarSessao_Tick(object sender, EventArgs e)
        {
            try
            {
                ContratoServico.Sessao.AtualizarSessao.PeticaoAtualizarSessao Peticao = new ContratoServico.Sessao.AtualizarSessao.PeticaoAtualizarSessao();

                Peticao.IdentificadorSessao = ControleEstoque.Parametros.Parametros.IdentificadorSessao;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;


                Agente.Agente.InvocarServico<ContratoServico.Sessao.AtualizarSessao.RespostaAtualizarSessao, ContratoServico.Sessao.AtualizarSessao.PeticaoAtualizarSessao>(Peticao,
                        SDK.Operacoes.operacao.AtualizarSessao, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);


            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);

                if (ex.Codigo == Constantes.CodigoErro.ERRO_FIM_APLICACAO)
                {
                    // The user wants to exit the application. Close everything down.
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                ContratoServico.Usuario.DeletarSessao.PeticaoDeletarSessao Peticao = new ContratoServico.Usuario.DeletarSessao.PeticaoDeletarSessao();
                ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao Resposta;

                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
                Peticao.IdentificadorSessao = ControleEstoque.Parametros.Parametros.IdentificadorSessao;

                Agente.Agente.InvocarServico<ContratoServico.Usuario.DeletarSessao.RespostaDeletarSessao, ContratoServico.Usuario.DeletarSessao.PeticaoDeletarSessao>(Peticao,
                    SDK.Operacoes.operacao.DeletarSessao, new Comum.ParametrosTela.Generica()
                    {
                        PreencherObjeto = true,
                        ExibirMensagemNenhumRegistro = false
                    }, null, true);


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void bgwImagemCentro_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                CarregarImagem();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void bgwImagemCentro_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (objFoto != null)
                {
                    pnlImagem.BackgroundImage = objFoto;
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void DownloadProgressChangedCallback(Object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            try
            {
                psbAtualizar.Value = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void DownloadFileCompletedCallback(Object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

            try
            {
                wc.DownloadProgressChanged -= this.DownloadProgressChangedCallback;
                wc.DownloadFileCompleted -= this.DownloadFileCompletedCallback;

                if (objFormularioNormal != null)
                {
                    objFormularioNormal.Close();
                }

                if (objFormulario != null)
                {
                    objFormulario.Close();
                }

                System.Diagnostics.Process.Start(Executavel);
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

        }

        //private void lnkDownload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        string Diretorio = frmUtil.Util.RetonarLocalRaiz();

        //        Diretorio += "\\CE";

        //        Executavel = Diretorio + "\\CE - Controle de Estoque.msi";

        //        if (System.IO.Directory.Exists(Diretorio))
        //        {
        //            if (System.IO.File.Exists(Executavel))
        //            {
        //                System.IO.File.Delete(Executavel);
        //            }
        //        }
        //        else
        //        {
        //            System.IO.Directory.CreateDirectory(Diretorio);
        //        }

        //        wc = new System.Net.WebClient();
        //        Uri uri = new Uri(ControleEstoque.Parametros.Parametros.DiretorioArquivos + "/CE - Controle de Estoque.msi");

        //        wc.DownloadFileAsync(uri, Executavel);

        //        wc.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DownloadProgressChangedCallback);
        //        wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompletedCallback);

        //    }
        //    catch (Exception ex)
        //    {
        //        Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
        //    }
        //}

        private void bgwVersao_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                RecuperarVersao();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void bgwVersao_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (!ControleEstoque.Parametros.Parametros.Versao.Equals(VersaoDownload))
                {

                    this.OcultarTab(tInformacoes, false);
                    Classes.Util.ExibirMensagemUpdate("Nova versão disponível.");

                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        #endregion

        #region "Vendas"

        #endregion

    }
}
