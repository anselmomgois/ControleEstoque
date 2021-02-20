using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Aplicacao.Controles.CustomTabControl;
using Informatiz.ControleEstoque.Comum.Clases;
using MyTabControl;

namespace Informatiz.ControleEstoque.Aplicacao.Telas.VendaTouch
{
    public partial class VendaTouch : TelaBase.BaseVenda
    {

        #region propriedades / variaveis

        Color corUltimaLinha = System.Drawing.Color.Black;

        private static ucProduto ucPSelecionado;

        private Controles.ucDadosVenda _ucDadosVenda;
        private Controles.ucGridVenda _ucGridVenda;

        #endregion

        #region"Constantes"

        private const string btnBuscarComanda = "btnBuscarComanda";
        private const string btnCancelarItem = "btnCancelarItem";
        private const string btnAplicarAcrescimoDesconto = "btnAplicarAcrescimoDesconto";
        private const string btnCancelarVenda = "btnCancelarVenda";
        private const string btnInformarAtendente = "btnInformarAtendente";
        private const string btnSairComanda = "btnSairComanda";

        #endregion

        public VendaTouch()
        {
            _tipoTela = TelaVenda.VendaTouch;
            InitializeComponent();
            this.pnlBase.Controls.Add(tlpGeral);
        }

        #region metodos

        private void CarregarControleGridVenda()
        {
            _ucGridVenda = new Controles.ucGridVenda(true);
            _ucGridVenda.Dock = DockStyle.Fill;
            _ucGridVenda.Visible = false;
            tlpSomaTotal.Visible = false;
            pnlGrid.Controls.Add(_ucGridVenda);
        }

        protected override void LimparGridVenda()
        {
            base.LimparGridVenda();

            _ucGridVenda.LimparGrid();
        }

        private void DefinirTamanhoNumericUpDown()
        {
            nudQuantidade.Value = 1;
            nudQuantidade.Font = new Font("Microsoft Sans Serif", 28);
        }

        private void Limpar()
        {
            _ucDadosVenda.SetarValorAtendente(string.Empty);
            _ucDadosVenda.SetarValorMesa(string.Empty);

            this.OcultarItemMenu(string.Empty, string.Empty, btnInformarAtendente, true);
            _ucDadosVenda.SetarValorComanda(string.Empty);
            _ucDadosVenda.SetarFocus();

        }

        #endregion

        #region eventos_override

        protected override void OcultarBotaoInformarAtendente(bool Ocultar)
        {
            base.OcultarBotaoInformarAtendente(Ocultar);

            this.OcultarItemMenu(string.Empty, string.Empty, btnInformarAtendente, Ocultar);
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

        protected override void SetarValorComanda(string Valor)
        {
            base.SetarValorComanda(Valor);

            _ucDadosVenda.SetarValorComanda(Valor);
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

        protected override void SetarValorMesa(string Valor)
        {
            base.SetarValorMesa(Valor);

            _ucDadosVenda.SetarValorMesa(Valor);
        }

        protected override string RecuperarCodigoComanda()
        {
            return _ucDadosVenda.RecuperarValorComanda();
        }

        protected override void SetarValorAtendente(string Valor)
        {
            base.SetarValorAtendente(Valor);

            _ucDadosVenda.SetarValorAtendente(Valor);
        }

        protected override void PreencherCodigoComanda(string CodigoComanda)
        {
            _ucDadosVenda.SetarValorComanda(CodigoComanda);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            base.Inicializar();
            this.DefinirTamanhoNumericUpDown();
            this.CarregarControleDadosVenda();
            this.CarregarControleGridVenda();
            this.pnlBase.Controls.Add(tlpGeral);
            tlpListaGruposEProdutos.RowStyles[1].Height = 0;
            txtSubTotal.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtAcrescimo.Text = "0,00";
            txtTotal.Text = "0,00";
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Cancelar Item (F2)", btnCancelarItem, Properties.Resources.product_cancel, new EventHandler(btnCancelarItem_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aplicar Acrescímo/Desconto (F3)", btnAplicarAcrescimoDesconto, Properties.Resources.discount, new EventHandler(btnAplicarDesconto_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Cancelar Venda (F4)", btnCancelarVenda, Properties.Resources.goods, new EventHandler(btnCancelarVenda_Click), Keys.F4, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Informar Atendente/Mesa (ALT + M)", btnInformarAtendente, Properties.Resources.preferences_desktop_user, new EventHandler(btnInformarAtendenteMesa_Click), Keys.M, true, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Sair da Comanda(ALT + S)", btnSairComanda, Properties.Resources.dispatch_order_close, new EventHandler(btnSairComanda_Click), Keys.S, true, false, false);

            base.MontarMenu(GerarGrupo, (_Caixa == null || string.IsNullOrEmpty(_Caixa.Identificador)));
        }

        protected override void ConfigurarVisibilidadeBotoes()
        {
            base.ConfigurarVisibilidadeBotoes();
            _ucGridVenda.Visible = true;
            tlpSomaTotal.Visible = true;
        }

        protected override void AplicarConfiguracoesIniciais()
        {
            base.AplicarConfiguracoesIniciais();

            if (_ProdutosServicosMemoria != null && _ProdutosServicosMemoria.Count > 0)
            {
                List<GrupoProduto> gruposProduto = (from prod in _ProdutosServicosMemoria
                                                    where prod.Produto != null &&
                                                          prod.Produto.GrupoProduto != null &&
                                                          !string.IsNullOrEmpty(prod.Produto.GrupoProduto.Identificador)
                                                    select prod.Produto.GrupoProduto).ToList();


                if (_ProdutosServicosMemoria != null && _ProdutosServicosMemoria.Count > 0)
                {
                    List<string> gps = new List<string>();
                    string identificadorGrupoProduto = null;
                    string descricaoGrupoProduto = null;

                    TabControlX tab = new TabControlX();
                    tab.Dock = DockStyle.Fill;
                    tab.EventoTabSelecionada += new TabControlX.dTabSelecionada(SelectedIndexChanged_tab);

                    pnlProdutos.Controls.Add(tab);
                    foreach (var p in _ProdutosServicosMemoria.OrderBy(o => o.Produto.GrupoProduto.Descricao).ToList())
                    {

                        if (p.Produto.GrupoProduto != null)
                        {
                            identificadorGrupoProduto = p.Produto.GrupoProduto.Identificador;
                            descricaoGrupoProduto = p.Produto.GrupoProduto.Descricao;
                        }
                        else
                        {
                            identificadorGrupoProduto = "semgrupo";
                            descricaoGrupoProduto = "Sem Grupo";
                        }

                        if (!gps.Exists(e => e == identificadorGrupoProduto))
                        {


                            TabPanelControl tpc = new TabPanelControl();

                            tpc.Dock = DockStyle.Fill;
                            tpc.Tag = p.Produto.GrupoProduto.Identificador;
                            tpc.Name = p.Produto.GrupoProduto.Descricao;
                            tab.AddTab(tpc.Name, tpc);
                            gps.Add(identificadorGrupoProduto);

                        }
                    }
                    SelectedIndexChanged_tab(tab.tabPanelCtrlList[0]);
                    tab.button_Click(tab.buttonlist[0], null);
                }

            }
            ConfigurarVisibilidadeBotoes();
        }

        private void SelectedIndexChanged_tab(TabPanelControl tabSelecionada)
        {

            if (tabSelecionada != null)
            {
                pnlRegistrarItem.Visible = false;
                string identificadorGrupo = Convert.ToString(tabSelecionada.Tag);

                List<Comum.Clases.ProdutoDisponivelVenda> produtos = (from p in _ProdutosServicosMemoria
                                                                      where p.Produto.GrupoProduto.Identificador == identificadorGrupo || (p.Produto.GrupoProduto == null || string.IsNullOrEmpty(identificadorGrupo))
                                                                      select p).ToList();

                GrupoProduto_Click(identificadorGrupo, produtos, tabSelecionada);
            }

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado, operacao);
            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);
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

        private void CarregarControleDadosVenda()
        {
            int comprimento=0;
            int altura=0;

            if (Parametros.Parametros.ParametrosAplicacao.TrabalhaPorComanda)
            {
                comprimento = pnlControleDadosVenda.Location.X + 5;
                altura = pnlControleDadosVenda.Location.Y + 130;
            }
            else
            {
                comprimento = this.Location.X - 400;
                altura = pnlControleDadosVenda.Location.Y + 130;
            }

            _ucDadosVenda = new Controles.ucDadosVenda(true, this, comprimento, altura);
            _ucDadosVenda.Dock = DockStyle.Fill;
            _ucDadosVenda.GetValorDigitado += _ucDadosVenda_GetValorDigitado;
            _ucDadosVenda.LimparTela += _ucDadosVenda_LimparTela;
            pnlControleDadosVenda.Controls.Add(_ucDadosVenda);
        }

        #endregion

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

        #region eventos_grupo_produtos

        private void GrupoProduto_Click(string identificadorGrupo,
                                        List<Comum.Clases.ProdutoDisponivelVenda> produtos,
                                        TabPanelControl tp)
        {

            if (produtos != null && produtos.Count > 0)
            {

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.AutoScroll = true;

                tp.Controls.Add(flp);

                flp.Tag = identificadorGrupo;

                foreach (var p in produtos)
                {
                    ucProduto ucP = new ucProduto(p);

                    ucP.EventoProdutoSelecionado += new ucProduto.dProdutoSelecionado(Produto_Click);
                    flp.Controls.Add(ucP);
                }
            }
        }

        #endregion

        #region eventos_produtos

        private void Produto_Click(ProdutoDisponivelVenda p)
        {
            SetBorderStyleImage(p.Produto.Identificador);
            pnlRegistrarItem.Visible = true;
            nudQuantidade.Value = 1;
            tlpListaGruposEProdutos.RowStyles[1].Height = 74;
        }

        private void SetBorderStyleImage(string identificador)
        {
            foreach (Control controle1 in pnlProdutos.Controls)
            {
                if (controle1 is TabControlX)
                {
                    TabControlX tc = (TabControlX)controle1;

                    if (tc.tabPanelCtrlList[tc.selected_index] != null)
                    {
                        foreach (Control controle2 in tc.tabPanelCtrlList[tc.selected_index].Controls)
                        {
                            if (controle2 is FlowLayoutPanel)
                            {
                                FlowLayoutPanel flp = (FlowLayoutPanel)controle2;

                                foreach (Control controle3 in flp.Controls)
                                {
                                    if (controle3 is ucProduto)
                                    {
                                        ucProduto ucP = (ucProduto)controle3;

                                        if (Convert.ToString(ucP.Tag) != identificador)
                                        {
                                            if (ucP.BorderStyleImagem == BorderStyle.Fixed3D)
                                            {
                                                ucP.BorderStyleImagem = BorderStyle.None;
                                            }
                                        }
                                        else
                                        {
                                            ucPSelecionado = ucP;
                                        }

                                    }
                                }

                            }

                        }
                    }
                }

            }
        }

        #endregion

        #region eventos_listview


        #endregion

        #region eventos_menu

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
                        CancelarItemsTouch frmModificarValorProduto = new CancelarItemsTouch(_Venda.Items, _Venda.Identificador, IdentificadorSupervisor);
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
                    Venda.InformarMesaAtendenteTouch frmInformarMesaAtendente = new Venda.InformarMesaAtendenteTouch(_Venda.Identificador, objFuncionarioSelecionado, _Venda.Mesas, true);

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

        #endregion

        private void btnRegistrarItem_Click(object sender, EventArgs e)
        {
            ucPSelecionado.P.NumQuantidadeVendido = nudQuantidade.Value;
            RegistrarItem(ucPSelecionado.P, true, false, true);
        }

        protected override void PreencherControlesRegistrarVenda(ProdutoDisponivelVenda ProdutoVenda)
        {
            base.PreencherControlesRegistrarVenda(ProdutoVenda);
            _ucGridVenda.AdicionarItemGrid(ProdutoVenda);

            txtSubTotal.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select (pr.NumValorProdutoCalculado * pr.NumQuantidadeVendido) + pr.NumValorAcrescimoProdutoCalculado).Sum().ToString("N2");
            txtDesconto.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select pr.NumValorDescontoCalculado * pr.NumQuantidadeVendido).Sum().ToString("N2");
            txtAcrescimo.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select pr.NumValorAcrescimoCalculado * pr.NumQuantidadeVendido).Sum().ToString("N2");
            txtTotal.Text = (from Comum.Clases.ProdutoDisponivelVenda pr in _ProdutosServicosRegistrados select (pr.NumValorProdutoCalculado * pr.NumQuantidadeVendido) + pr.NumValorAcrescimoProdutoCalculado).Sum().ToString("N2");


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

                RegistrarAcrescimosTouch frmRegistrarAcrescimos = new RegistrarAcrescimosTouch(ProdutosAcrescimos, Observacoes, Quantidade);

                if (AbrirFormulario(frmRegistrarAcrescimos) == DialogResult.OK)
                {
                    ProdutosAcrescimosRetorno = frmRegistrarAcrescimos.AcrescimosRetorno;
                    ObservacoesRetorno = frmRegistrarAcrescimos.ObservacoesRetorno;
                }
            }
        }

    }
}
