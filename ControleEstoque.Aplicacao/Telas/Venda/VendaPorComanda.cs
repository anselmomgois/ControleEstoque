using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using Informatiz.ControleEstoque.Aplicacao.Telas.ValidarTiposEmpregados;
using Informatiz.ControleEstoque.Comum.Extencoes;
using System.Threading;
using Informatiz.ControleEstoque.Comum.Clases;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class VendaPorComanda : Telas.TelaBase.BaseVenda
    {
        public VendaPorComanda(Comum.Clases.Caixa Caixa)
        {
            InitializeComponent();
            _Caixa = Caixa;
            _tipoTela = TelaVenda.VendaPorComanda;
        }

        #region"Variaveis"
        private Boolean _CaixaPausado = false;
        private Controles.ucPesquisa _ucPesquisa = null;
        private Boolean _FechamentoPermitido = false;
        private Controles.ucDadosVenda _ucDadosVenda;
        private Controles.ucGridVenda _ucGridVenda;
        #endregion

        #region"Constantes"
        private const string btnBuscarComanda = "btnBuscarComanda";
        private const string btnCancelarItem = "btnCancelarItem";
        private const string btnAplicarAcrescimoDesconto = "btnAplicarAcrescimoDesconto";
        private const string btnCancelarVenda = "btnCancelarVenda";
        private const string btnFecharCupom = "btnFecharCupom";
        private const string btnPausarCaixa = "btnPausarCaixa";
        private const string btnInformarAtendente = "btnInformarAtendente";
        private const string btnSairComanda = "btnSairComanda";
        private const string btnPagamentoParcValor = "btnPagamentoParcValor";
        private const string btnSangria = "btnSangria";
        private const string btnSuprimento = "btnSuprimento";
        private const string btnFechamentoCaixa = "btnFechamentoCaixa";
        private const string btnPagamentoParcProduto = "btnPagamentoParcProduto";
        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar Comanda (F12)", btnBuscarComanda, Properties.Resources.product_cancel, new EventHandler(btnBuscarComanda_Click), Keys.F12, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Cancelar Item (F2)", btnCancelarItem, Properties.Resources.product_cancel, new EventHandler(btnCancelarItem_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aplicar Acrescímo/Desconto (F3)", btnAplicarAcrescimoDesconto, Properties.Resources.discount, new EventHandler(btnAplicarDesconto_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Cancelar Venda (F4)", btnCancelarVenda, Properties.Resources.goods, new EventHandler(btnCancelarVenda_Click), Keys.F4, false, false, false);
            if (_Caixa != null) this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Fechar Cupom (F5)", btnFecharCupom, Properties.Resources.badge, new EventHandler(btnFecharCupom_Click), Keys.F5, false, false, false);
            if (_Caixa != null) this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Pagamento Parc. Produto (F6)", btnPagamentoParcProduto, Properties.Resources.diagram_v2_17, new EventHandler(btnPagamentoParcialProduto_Click), Keys.F6, false, false, false);
            if (_Caixa != null) this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Pagamento Parc. Valor (F7)", btnPagamentoParcValor, Properties.Resources.cash_stack_add, new EventHandler(btnPagamentoParcial_Click), Keys.F7, false, false, false);
            if (_Caixa != null) this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Sangria (F8)", btnSangria, Properties.Resources.dollars, new EventHandler(btnSangria_Click), Keys.F8, false, false, false);
            if (_Caixa != null) this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Suprimento (F9)", btnSuprimento, Properties.Resources.coins_add, new EventHandler(btnSuprimento_Click), Keys.F9, false, false, false);
            if (_Caixa != null) this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Fechamento Caixa (F10)", btnFechamentoCaixa, Properties.Resources.cash_stack_add, new EventHandler(btnFechamento_Click), Keys.F10, false, false, false);
            if (_Caixa != null) this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Interromper Atendimento (ALT + P)", btnPausarCaixa, Properties.Resources.player_pause, new EventHandler(btnPause_Click), Keys.P, true, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Informar Atendente/Mesa (ALT + M)", btnInformarAtendente, Properties.Resources.preferences_desktop_user, new EventHandler(btnInformarAtendenteMesa_Click), Keys.M, true, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Sair da Comanda(ALT + S)", btnSairComanda, Properties.Resources.dispatch_order_close, new EventHandler(btnSairComanda_Click), Keys.S, true, false, false);


            base.MontarMenu(GerarGrupo, (_Caixa == null || string.IsNullOrEmpty(_Caixa.Identificador)));
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            CarregarControleDadosVenda();
            AdicionarControleFiltro();
            CarregarControleGridVenda();
            this.pnlBase.Controls.Add(tableLayoutPanel1);
            base.Inicializar();
            txtExibir.ForeColor = System.Drawing.Color.Lime;
            txtSubTotal.ForeColor = System.Drawing.Color.Red;
            txtDesconto.ForeColor = System.Drawing.Color.Green;
            txtAcrescimo.ForeColor = System.Drawing.Color.Red;
            txtSubTotal.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtAcrescimo.Text = "0,00";
            txtTotal.Text = "0,00";
            txtExibir.Text = "PESQUISAR COMANDA";
            _FechamentoPermitido = (_Caixa == null);

        }
        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        private void CarregarControleDadosVenda()
        {
            _ucDadosVenda = new Controles.ucDadosVenda(false, this, tableLayoutPanel1.Location.X + 10, tableLayoutPanel1.Location.Y + 235);
            _ucDadosVenda.Dock = DockStyle.Fill;
            _ucDadosVenda.GetValorDigitado += _ucDadosVenda_GetValorDigitado;
            _ucDadosVenda.LimparTela += _ucDadosVenda_LimparTela;
            pnlDadosVenda.Controls.Add(_ucDadosVenda);
        }

        private void CarregarControleGridVenda()
        {
            _ucGridVenda = new Controles.ucGridVenda(false);
            _ucGridVenda.Dock = DockStyle.Fill;
            pnlGrid.Controls.Add(_ucGridVenda);
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado, operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

            switch (operacao)
            {
                case SDK.Operacoes.operacao.RecuperarVendaPorComanda | SDK.Operacoes.operacao.RecuperarVendaPorMesa:
                    if (_Venda != null)
                    {
                        _ucPesquisa.SetarFocus();
                    }
                    else
                    {
                        _ucDadosVenda.Focus();
                    }
                    break;
                case SDK.Operacoes.operacao.RecuperarProdutos:
                    _ucDadosVenda.Focus();
                    break;
            }

        }

        protected override void AplicarConfiguracoesIniciais()
        {
            base.AplicarConfiguracoesIniciais();

            ConfigurarVisibilidadeBotoes();
            _ucPesquisa.Dados = _ProdutosServicosMemoria;
        }

        protected override void OcultarBotaoInformarAtendente(bool Ocultar)
        {
            base.OcultarBotaoInformarAtendente(Ocultar);

            this.OcultarItemMenu(string.Empty, string.Empty, btnInformarAtendente, Ocultar);
        }

        protected override void SetarValorComanda(string Valor)
        {
            base.SetarValorComanda(Valor);

            _ucDadosVenda.SetarValorComanda(Valor);
        }

        protected override void SetarValorMesa(string Valor)
        {
            base.SetarValorMesa(Valor);

            _ucDadosVenda.SetarValorMesa(Valor);
        }

        protected override void SetarValorAtendente(string Valor)
        {
            base.SetarValorAtendente(Valor);

            _ucDadosVenda.SetarValorAtendente(Valor);
        }

        protected override void SetarFocusControlePesquisa()
        {
            base.SetarFocusControlePesquisa();

            _ucPesquisa.SetarFocus();
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarPagamentosCaixa)
            {

                ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa objSaidaConvertido = (ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa)objSaida;

                GuardarFecharVenda frmFecharVenda = new GuardarFecharVenda(null, false, false, _Caixa, objSaidaConvertido.Vendas, objSaidaConvertido.Sangrias, objSaidaConvertido.Suprimentos,
                                                                           objSaidaConvertido.SaldoInicial, (_Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : string.Empty));

                if (AbrirFormulario(frmFecharVenda) == DialogResult.OK)
                {

                    _FechamentoPermitido = true;
                    this.Close();
                }
            }

        }

        protected override string RecuperarCodigoComanda()
        {
            return _ucDadosVenda.RecuperarValorComanda();
        }

        protected override void LimparGridVenda()
        {
            base.LimparGridVenda();

            _ucGridVenda.LimparGrid();
        }

        protected override void ExibirTelaAcrescimos(List<Comum.Clases.ProdutoDisponivelVenda> ProdutosAcrescimos,
                                                   List<Comum.Clases.ProdutoObservacao> Observacoes,
                                                   ref List<Comum.Clases.ProdutoDisponivelVenda> ProdutosAcrescimosRetorno,
                                                   ref List<Comum.Clases.ProdutoObservacao> ObservacoesRetorno,
                                                   decimal Quantidade,
                                                    bool vendaTouch)
        {

            if ((ProdutosAcrescimos != null && ProdutosAcrescimos.Count > 0) || (Observacoes != null && Observacoes.Count > 0))
            {

                RegistrarAcrescimos frmRegistrarAcrescimos = new RegistrarAcrescimos(ProdutosAcrescimos, Observacoes, Quantidade);

                if (AbrirFormulario(frmRegistrarAcrescimos) == DialogResult.OK)
                {
                    ProdutosAcrescimosRetorno = frmRegistrarAcrescimos.AcrescimosRetorno;
                    ObservacoesRetorno = frmRegistrarAcrescimos.ObservacoesRetorno;
                }
            }
        }

        private void Limpar()
        {
            _ucDadosVenda.SetarValorAtendente(string.Empty);
            _ucDadosVenda.SetarValorMesa(string.Empty);

            this.OcultarItemMenu(string.Empty, string.Empty, btnInformarAtendente, true);
            _ucDadosVenda.SetarValorComanda(string.Empty);
            _ucDadosVenda.SetarFocus();

        }
        protected override void PreencherControles()
        {
            base.PreencherControles();

            if (_Venda != null)
            {

                if (_Venda.Atendente != null)
                {
                    _ucDadosVenda.SetarValorAtendente(_Venda.Atendente.CodigoDescricao);
                }

                if (_Venda.Mesas != null && _Venda.Mesas.Count > 0)
                {
                    _ucDadosVenda.SetarValorMesa(string.Join(" - ", (from m in _Venda.Mesas select m.Codigo).ToArray()));
                }

                if (_Venda.Items == null || _Venda.Items.Count == 0 || _ProdutosServicosMemoria == null || _ProdutosServicosMemoria.Count == 0)
                {
                    txtSubTotal.Text = "0,00";
                    txtDesconto.Text = "0,00";
                    txtAcrescimo.Text = "0,00";
                    txtTotal.Text = "0,00";
                }
            }
        }

        private void AdicionarControleFiltro()
        {
            _ucPesquisa = new Controles.ucPesquisa(Comum.Enumeradores.TipoControle.ProdutosTelaVenda, pnlFiltro.Location.X + 6, txtExibir.Location.Y + 175 + tableLayoutPanel1.Location.Y + tlpPesquisa.Location.Y + pnlFiltro.Location.Y);

            _ucPesquisa.TabIndex = 0;
            _ucPesquisa.Dock = DockStyle.Fill;
            _ucPesquisa.ExibirGrid += _ucPesquisa_ExibirGrid;
            _ucPesquisa.OcultarGrid += _ucPesquisa_OcultarGrid;
            _ucPesquisa.SelecionarItem += _ucPesquisa_SelecionarItem;
            pnlFiltro.Controls.Add(_ucPesquisa);
            _ucPesquisa.CriarGrid();
        }

        private void _ucPesquisa_SelecionarItem(object Item)
        {
            try
            {
                if (Item != null)
                {
                    Comum.Clases.ProdutoDisponivelVenda ProdutoSelecionado = (Comum.Clases.ProdutoDisponivelVenda)Item;

                    RegistrarItem(ProdutoSelecionado, true, false, false);
                }
            }

            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void _ucPesquisa_OcultarGrid(DataGridView Grid)
        {
            try
            {
                if (this.Controls.Contains(Grid)) this.Controls.Remove(Grid);
            }

            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void _ucPesquisa_ExibirGrid(DataGridView Grid)
        {
            try
            {
                if (this.Controls.Contains(Grid)) this.Controls.Remove(Grid);

                this.Controls.Add(Grid);
                Grid.SendToBack();
                Grid.BringToFront();
            }

            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        protected override void ConfigurarVisibilidadeBotoes()
        {
            base.ConfigurarVisibilidadeBotoes();

            if (_Venda == null)
            {

                this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarItem, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnAplicarAcrescimoDesconto, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarVenda, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcProduto, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcValor, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnFecharCupom, true);

                if (_Caixa == null)
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFechamentoCaixa, true);
                }
                else
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFechamentoCaixa, false);
                }
            }
            else
            {

                if (_Venda.Items != null && _Venda.Items.Count > 0)
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarItem, false);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAplicarAcrescimoDesconto, false);
                }
                else
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarItem, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAplicarAcrescimoDesconto, true);
                }


                this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarVenda, false);



                if (_Caixa == null)
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFecharCupom, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcProduto, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcValor, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFechamentoCaixa, true);
                }
                else
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFecharCupom, false);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcProduto, false);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcValor, false);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFechamentoCaixa, false);
                }
            }

        }

        protected override void ExibirTextoLetreiro(string Texto)
        {
            txtExibir.Text = Texto;
        }

        protected override void PreencherControlesRegistrarVenda(Comum.Clases.ProdutoDisponivelVenda ProdutoVenda)
        {

            _ucGridVenda.AdicionarItemGrid(ProdutoVenda);

            txtSubTotal.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select (pr.NumValorProdutoCalculado * pr.NumQuantidadeVendido) + pr.NumValorAcrescimoProdutoCalculado).Sum().ToString("N2");
            txtDesconto.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select pr.NumValorDescontoCalculado * pr.NumQuantidadeVendido).Sum().ToString("N2");
            txtAcrescimo.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select pr.NumValorAcrescimoCalculado * pr.NumQuantidadeVendido).Sum().ToString("N2");
            txtTotal.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select (pr.NumValorProdutoCalculado * pr.NumQuantidadeVendido) + pr.NumValorAcrescimoProdutoCalculado).Sum().ToString("N2");

        }

        protected override void ExibirTelaInformacoesMesaAtendente(ref Pessoa Funcionario, ref List<Mesa> Mesas, ref DialogResult Resultado)
        {
            base.ExibirTelaInformacoesMesaAtendente(ref Funcionario, ref Mesas, ref Resultado);

            Venda.InformarMesaAtendente frmInformarMesaAtendente = new Venda.InformarMesaAtendente(null, null, null, false);

            if (AbrirFormulario(frmInformarMesaAtendente) == DialogResult.OK)
            {

                Resultado = DialogResult.OK;

                if (frmInformarMesaAtendente.Funcionario != null)
                {
                    Funcionario = frmInformarMesaAtendente.Funcionario;
                }

                if (frmInformarMesaAtendente.Mesas != null && frmInformarMesaAtendente.Mesas.Count > 0)
                {
                    Mesas = frmInformarMesaAtendente.Mesas;
                }
            }
            else
            {
                Resultado = DialogResult.None;
            }
        }

        private void ExecutarRealizarSaldoCaixa(Comum.Enumeradores.Enumeradores.TipoSaldoCaixa tipoSaldoCaixa, Boolean Obrigatorio)
        {
            string IdentificadorSupervisor = UsuarioTemPermissaoSupervisorGerente();

            if (!string.IsNullOrEmpty(IdentificadorSupervisor))
            {
                GuardarSaldoCaixa frmSuprimento = new GuardarSaldoCaixa(tipoSaldoCaixa, _Caixa.OperacaoCaixa.Identificador, IdentificadorSupervisor, _Caixa.OperacaoCaixa.Saldo, Obrigatorio);

                if (AbrirFormulario(frmSuprimento) == DialogResult.OK)
                {
                    _Caixa.OperacaoCaixa.Saldo = frmSuprimento.Saldo;
                }
            }
        }

        protected override void PreencherCodigoComanda(string CodigoComanda)
        {
            _ucDadosVenda.SetarValorComanda(CodigoComanda);
        }

        protected override void LimparVenda()
        {
            base.LimparVenda();

            _ucGridVenda.LimparGrid();

            txtSubTotal.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtAcrescimo.Text = "0,00";
            txtTotal.Text = "0,00";

            Limpar();

            ConfigurarVisibilidadeBotoes();

        }

        private void AtualizarIdentificadoresPagamentos()
        {
            if (_Venda.Pagamentos != null && _Venda.Pagamentos.Count > 0)
            {
                foreach (Comum.Clases.Pagamento pg in _Venda.Pagamentos)
                {
                    if (string.IsNullOrEmpty(pg.Identificador))
                    {
                        pg.Identificador = Guid.NewGuid().ToString();
                    }
                }
            }
        }

        #endregion

        #region "Eventos"
        private void btnCancelarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ProdutosServicosRegistrados != null && _ProdutosServicosRegistrados.Count > 0)
                {
                    string IdentificadorSupervisor = UsuarioTemPermissaoSupervisorGerente();

                    if (!string.IsNullOrEmpty(IdentificadorSupervisor))
                    {
                        // relaizar ação modificar preço
                        CancelarItems frmModificarValorProduto = new CancelarItems(_Venda.Items, _Venda.Identificador, IdentificadorSupervisor);
                        if (AbrirFormulario(frmModificarValorProduto) == DialogResult.OK)
                        {
                            if (frmModificarValorProduto.ProdutosCancelados != null && frmModificarValorProduto.ProdutosCancelados.Count > 0)
                            {
                                _ProdutosServicosRegistrados.Clear();
                                foreach (var produto in frmModificarValorProduto.ProdutosCancelados)
                                {
                                    var produtovendido = _Venda.Items.Find(p => p.Identificador == produto.Identificador);

                                    if (produtovendido != null)
                                    {
                                        produtovendido.Cancelado = true;
                                        _Venda.ValorDesconto -= (produtovendido.ValorDesconto * produtovendido.Quantidade);
                                        _Venda.ValorVenda -= (produtovendido.ValorItem * produtovendido.Quantidade);
                                        _Venda.ValorTotal -= (produtovendido.ValorTotal);

                                        _Venda.Items.RemoveAll(p => p.Identificador == produto.Identificador);


                                    }
                                }

                                PreencherControles();
                                ConfigurarVisibilidadeBotoes();
                            }

                        }
                    }
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não tem produtos registrados para serem modificados!");
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnBuscarComanda_Click(object sender, EventArgs e)
        {
            try
            {

                _ucDadosVenda.SetarValorComanda(string.Empty);
                _ucDadosVenda.SetarFocus();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnAplicarDesconto_Click(object sender, EventArgs e)
        {
            try
            {

                if (_ProdutosServicosRegistrados != null && _ProdutosServicosRegistrados.Count > 0)
                {
                    string IdentificadorSupervisor = UsuarioTemPermissaoSupervisorGerente();

                    if (!string.IsNullOrEmpty(IdentificadorSupervisor))
                    {
                        // relaizar ação modificar preço
                        ModificarValorProduto frmModificarValorProduto = new ModificarValorProduto(_ProdutosServicosRegistrados);
                        if (AbrirFormulario(frmModificarValorProduto) == DialogResult.OK)
                        {
                            if (frmModificarValorProduto.ProdutosRegistradosModificados != null)
                            {

                                ContratoServico.Venda.ModificarPrecoProdutoVenda.PeticaoModificarPrecoProdutoVenda Peticao = new ContratoServico.Venda.ModificarPrecoProdutoVenda.PeticaoModificarPrecoProdutoVenda()
                                {
                                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                                    IdentificadorVenda = _Venda.Identificador,
                                    Items = (from p in frmModificarValorProduto.ProdutosRegistradosModificados
                                             select new Comum.Clases.ItemVenda()
                                             {
                                                 Acrescimo = p.NumValorAcrescimoCalculado,
                                                 Produto = p.Produto,
                                                 Quantidade = p.NumQuantidadeVendido,
                                                 ValorDesconto = p.NumValorDescontoCalculado,
                                                 ValorItem = Convert.ToDecimal(p.NumValorVendaVarejo != null ? p.NumValorVendaVarejo : 0)
                                             }).ToList()
                                };

                                Agente.Agente.InvocarServico<ContratoServico.Venda.ModificarPrecoProdutoVenda.RespostaModificarPrecoProdutoVenda, ContratoServico.Venda.ModificarPrecoProdutoVenda.PeticaoModificarPrecoProdutoVenda>(Peticao,
                                      SDK.Operacoes.operacao.ModificarPrecoProdutoVenda, new Comum.ParametrosTela.Generica() { ParametroGenerico = frmModificarValorProduto.ProdutosRegistradosModificados }, null, true);

                            }
                        }
                    }
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Não existem produtos registrados para serem modificados!");
                }

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void _ucDadosVenda_GetValorDigitado(string Item)
        {
            try
            {
                RecuperarComanda(Item);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja cancelar a venda?", " I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    string IdentificadorSupervisor = UsuarioTemPermissaoSupervisorGerente();

                    if (!string.IsNullOrEmpty(IdentificadorSupervisor))
                    {
                        ContratoServico.Venda.SetVenda.PeticaoSetVenda Peticao = new ContratoServico.Venda.SetVenda.PeticaoSetVenda()
                        {
                            Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                            IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                            Venda = new Comum.Clases.Venda()
                            {
                                DataInicio = DateTime.Now,
                                Estado = Comum.Enumeradores.EstadoVenda.Cancelada,
                                FuncionarioCaixa = new Comum.Clases.Pessoa() { Identificador = Parametros.Parametros.InformacaoUsuario.Identificador },
                                IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                                Identificador = _Venda != null && !string.IsNullOrEmpty(_Venda.Identificador) ? _Venda.Identificador : string.Empty,
                                IdentificadorResponsavelCaixa = _Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : string.Empty,
                                SupervisorCancelamento = new Comum.Clases.Pessoa() { Identificador = IdentificadorSupervisor }
                            }
                        };

                        Agente.Agente.InvocarServico<ContratoServico.Venda.SetVenda.RespostaSetVenda, ContratoServico.Venda.SetVenda.PeticaoSetVenda>(Peticao,
                              SDK.Operacoes.operacao.SetVenda, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, NaoDesabilitarControles = true, DiferenciadorChamada = "CANCELARVENDA" }, null, true);
                    }
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnFecharCupom_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarFecharVenda frmFecharVenda = new GuardarFecharVenda(_Venda, false, false, null, null, null, null, 0, (_Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : string.Empty));
                if (AbrirFormulario(frmFecharVenda) == DialogResult.OK)
                {
                    AtualizarIdentificadoresPagamentos();
                    if (frmFecharVenda.Troco > 0)
                    {
                        txtExibir.Text = string.Format("TROCO - {0}", frmFecharVenda.Troco.ToString("N2"));
                        System.Threading.Thread.Sleep(5000);
                        txtExibir.Text = "VENDA FECHADA";
                    }
                    else
                    {
                        txtExibir.Text = "VENDA FECHADA";
                    }

                    _Caixa.OperacaoCaixa.Saldo = frmFecharVenda.SaldoCaixa;
                    LimparVenda();

                    if (_Caixa.OperacaoCaixa.Saldo >= Parametros.Parametros.ParametrosAplicacao.ValorRealizarSangria && Parametros.Parametros.ParametrosAplicacao.ValorRealizarSangria > 0)
                    {
                        ExecutarRealizarSaldoCaixa(Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria, true);
                    }
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnPagamentoParcial_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarFecharVenda frmFecharVenda = new GuardarFecharVenda(_Venda, true, false, null, null, null, null, 0, (_Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : string.Empty));
                if (AbrirFormulario(frmFecharVenda) == DialogResult.OK)
                {

                    txtExibir.Text = string.Format("PAGAMENTO PARCIAL VALOR - R$ {0}", frmFecharVenda.ValorPagamento.ToString("N2"));

                    _Caixa.OperacaoCaixa.Saldo = frmFecharVenda.SaldoCaixa;
                    _Venda.Pagamentos = frmFecharVenda.Pagamentos;
                    AtualizarIdentificadoresPagamentos();

                    if (_Caixa.OperacaoCaixa.Saldo >= Parametros.Parametros.ParametrosAplicacao.ValorRealizarSangria && Parametros.Parametros.ParametrosAplicacao.ValorRealizarSangria > 0)
                    {
                        ExecutarRealizarSaldoCaixa(Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria, true);
                    }
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnPagamentoParcialProduto_Click(object sender, EventArgs e)
        {
            try
            {

                GuardarFecharVenda frmFecharVenda = new GuardarFecharVenda(_Venda, true, true, null, null, null, null, 0, (_Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : string.Empty));
                if (AbrirFormulario(frmFecharVenda) == DialogResult.OK)
                {

                    txtExibir.Text = string.Format("PAGAMENTO PARCIAL VALOR - R$ {0}", frmFecharVenda.ValorPagamento.ToString("N2"));

                    _Caixa.OperacaoCaixa.Saldo = frmFecharVenda.SaldoCaixa;
                    _Venda.Pagamentos = frmFecharVenda.Pagamentos;
                    AtualizarIdentificadoresPagamentos();
                    if (_Caixa.OperacaoCaixa.Saldo >= Parametros.Parametros.ParametrosAplicacao.ValorRealizarSangria && Parametros.Parametros.ParametrosAplicacao.ValorRealizarSangria > 0)
                    {
                        ExecutarRealizarSaldoCaixa(Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria, true);
                    }
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {

                if (!_CaixaPausado)
                {

                    this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarItem, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnAplicarAcrescimoDesconto, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarVenda, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFecharCupom, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcProduto, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcValor, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnSangria, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnSuprimento, true);
                    this.OcultarItemMenu(string.Empty, string.Empty, btnFechamentoCaixa, true);
                    _ucPesquisa.Enabled = false;
                    this.AtualizarItemMenu(string.Empty, string.Empty, btnPausarCaixa, "Retornar Operacional (F8)", Properties.Resources.player_play);
                    txtExibir.Text = "ATENDIMENTO ITERROMPIDO";
                    _CaixaPausado = true;

                }
                else
                {
                    if (SolicitarUsuarioSenha())
                    {
                        this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarItem, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnAplicarAcrescimoDesconto, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnCancelarVenda, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnFecharCupom, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcProduto, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnPagamentoParcValor, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnSangria, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnSuprimento, false);
                        this.OcultarItemMenu(string.Empty, string.Empty, btnFechamentoCaixa, false);
                        _ucPesquisa.Enabled = true;
                        _ucPesquisa.SetarFocus();
                        this.AtualizarItemMenu(string.Empty, string.Empty, btnPausarCaixa, "Interromper Atendimento (F11)", Properties.Resources.player_play);
                        txtExibir.Text = "ATENDIMENTO RETOMADO";
                        _CaixaPausado = false;
                    }
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInformarAtendenteMesa_Click(object sender, EventArgs e)
        {
            try
            {

                if (_Venda != null)
                {
                    Comum.Clases.Pessoa objFuncionarioSelecionado = null;

                    if (_Venda.Atendente != null)
                    {
                        objFuncionarioSelecionado = new Comum.Clases.Pessoa()
                        {
                            Codigo = Convert.ToInt32(_Venda.Atendente.Codigo),
                            Identificador = _Venda.Atendente.Identificador,
                            DesNome = _Venda.Atendente.Descricao
                        };
                    }
                    Venda.InformarMesaAtendente frmInformarMesaAtendente = new Venda.InformarMesaAtendente(_Venda.Identificador, objFuncionarioSelecionado, _Venda.Mesas,true);

                    if (AbrirFormulario(frmInformarMesaAtendente) == DialogResult.OK)
                    {

                        if (frmInformarMesaAtendente.Funcionario != null)
                        {
                            _ucDadosVenda.SetarValorAtendente(frmInformarMesaAtendente.Funcionario.NomeCodigo);
                        }

                        if (frmInformarMesaAtendente.Mesas != null && frmInformarMesaAtendente.Mesas.Count > 0)
                        {
                            _ucDadosVenda.SetarValorMesa(string.Join(" - ", (from m in frmInformarMesaAtendente.Mesas select m.Codigo).ToArray()));
                        }
                    }
                }

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnSairComanda_Click(object sender, EventArgs e)
        {
            try
            {

                LimparVenda();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnFechamento_Click(object sender, EventArgs e)
        {
            try
            {

                if (Parametros.Parametros.ParametrosAplicacao.ExibirRelatorioFechamento)
                {

                    FechamentoVendaRelatorio frmFechamento = new FechamentoVendaRelatorio(_Caixa, false, null, null, 0, null, string.Empty);

                    if (AbrirFormulario(frmFechamento) == DialogResult.OK)
                    {
                        _FechamentoPermitido = true;
                        this.Close();
                    }

                }
                else
                {
                    ContratoServico.Venda.RecuperarPagamentosCaixa.PeticaoRecuperarPagamentosCaixa Peticao = new ContratoServico.Venda.RecuperarPagamentosCaixa.PeticaoRecuperarPagamentosCaixa()
                    {
                        Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                        IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                        IdentificadorResponsavelCaixa = _Caixa.OperacaoCaixa.Identificador
                    };

                    Agente.Agente.InvocarServico<ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa, ContratoServico.Venda.RecuperarPagamentosCaixa.PeticaoRecuperarPagamentosCaixa>(Peticao,
                          SDK.Operacoes.operacao.RecuperarPagamentosCaixa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

                }

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnSangria_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarRealizarSaldoCaixa(Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria, false);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnSuprimento_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarRealizarSaldoCaixa(Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Suprimento, false);
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void VendaSupermercado_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = !_FechamentoPermitido;
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void _ucDadosVenda_LimparTela(object sender, EventArgs e)
        {
            try
            {
                LimparVenda();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion
    }
}
