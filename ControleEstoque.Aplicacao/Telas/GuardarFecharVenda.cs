using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using AmgSistemas.Framework.Componentes;
using System.Globalization;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarFecharVenda : TelaBase.BaseCE
    {
        public GuardarFecharVenda(Comum.Clases.Venda Venda,
                                  Boolean PagamentoParcial,
                                  Boolean PagamentoPorProduto,
                                  Comum.Clases.Caixa Caixa,
                                  List<Comum.Clases.Venda> Vendas,
                                  List<Comum.Clases.Sangria> Sangrias,
                                  List<Comum.Clases.Suprimento> Suprimentos,
                                  Decimal SaldoInicialCaixa,
                                  string IdentificadorResponsavelCaixa)
        {
            InitializeComponent();

            _venda = Venda;
            _PagamentoParcial = PagamentoParcial;
            _PagamentoPorProduto = PagamentoPorProduto;
            _Caixa = Caixa;
            _FechamentoCaixa = _Caixa != null;
            _Vendas = Vendas;
            _Sangrias = Sangrias;
            _Suprimentos = Suprimentos;
            _SaldoInicialCaixa = SaldoInicialCaixa;
            _IdentificadorResponsavelCaixa = IdentificadorResponsavelCaixa;

            if (_venda != null)
            {
                _Pagamentos = new List<Comum.Clases.Pagamento>();
                foreach (var p in _venda.Pagamentos)
                {
                    _Pagamentos.Add(p.Clone<Comum.Clases.Pagamento>());
                }

            }

            if (_FechamentoCaixa)
                this.Text = "Fechamento Caixa";
            else if (_PagamentoParcial) this.Text = "Pagamento Parcial";
        }

        #region "Variaveis"
        private Controles.ucHelper _ucHelper;
        private Controles.ucHelper _ucHelperFuncionarios;
        private Comum.Clases.Venda _venda;
        private List<Comum.Clases.FormaPagamento> _FormasPagamento;
        private CurrencyTextBox CurrencyTextBox;
        private decimal _ValorPago;
        private decimal _ValorRestante;
        private Boolean _PagamentoParcial;
        private List<Comum.Clases.Pagamento> _Pagamentos;
        private List<Comum.Clases.FechamentoCaixa> _PagamentosEfetuados;
        private Boolean _PagamentoPorProduto;
        private Comum.Clases.Caixa _Caixa;
        private Boolean _FechamentoCaixa;
        private List<Comum.Clases.Venda> _Vendas;
        private List<Comum.Clases.Sangria> _Sangrias;
        private List<Comum.Clases.Suprimento> _Suprimentos;
        private Decimal _SaldoInicialCaixa;
        private string _IdentificadorResponsavelCaixa;

        private decimal valorAcrescimoDescontoInformado;
        private bool acrescimo;
        private bool desconto;
        public bool porPorcentagem;
        public bool porPreco;

        #endregion

        #region"Propriedades"
        public decimal SaldoCaixa { get; set; }
        public decimal Troco { get; set; }
        public decimal ValorPagamento { get; set; }
        public List<Comum.Clases.Pagamento> Pagamentos
        {
            get
            {
                return _Pagamentos;
            }
        }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnPagamentoMultiplo = "btnPagamentoMultiplo";
        private const string btnAlterarFormaPagamento = "btnAlterarFormaPagamento";
        private const string btnAcrescimoDesconto = "btnAcrescimoDesconto";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region "Metodos"

        private void PreencherFormasPagamento()
        {

            if (_FormasPagamento != null && _FormasPagamento.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_FormasPagamento, "Identificador", "Descricao");

                cmbFormaPagamento = frmWindows.Util.PreencherCombobox(cmbFormaPagamento, Items);

                if (!string.IsNullOrEmpty(Parametros.Parametros.ParametrosAplicacao.FormaPagamentoPadrao))
                {
                    cmbFormaPagamento = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbFormaPagamento, Parametros.Parametros.ParametrosAplicacao.FormaPagamentoPadrao, "Descricao"));
                }

            }
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Alterar Forma Pagamento (F3)", btnAlterarFormaPagamento, Properties.Resources.coin_stacks_gold_edit, new EventHandler(btnAlterarFormaPagamento_Click), Keys.F3, false, false, false);

            if (_PagamentoPorProduto)
            {
                this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Adicionar Pagamento (F4)", btnAlterarFormaPagamento, Properties.Resources.cash_stack_add, new EventHandler(btnAdicionarPagamento_Click), Keys.F4, false, false, false);
            }

            if (!_PagamentoParcial && !_FechamentoCaixa)
            {
                this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Acréscimo/Desconto (F6)", btnAcrescimoDesconto, Properties.Resources.save, new EventHandler(btnAcrescimoDesconto_Click), Keys.F2, false, false, false);
            }
            else if (_FechamentoCaixa)
            {
                this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar Pagamentos (F5)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F5, false, false, false);
            }

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbFechamento);
            CarregarTela();
            base.Inicializar();
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvProdutos.Rows.Clear();

            if (_venda != null && _venda.Items != null && _venda.Items.Count > 0)
            {

                dgvProdutos.Columns[colValor.Index].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-Br");

                int quantidade = 1;

                foreach (Comum.Clases.ItemVenda p in _venda.Items.OrderBy(p => p.Sequencia))
                {
                    dgvProdutos.Rows.Add();
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colIdentificadorVenda.Name].Value = p.Identificador;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colSequencia.Name].Value = p.Sequencia;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colCodigo.Name].Value = p.Produto.Codigo;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colDescricao.Name].Value = p.Produto.Descricao;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colQuantidade.Name].Value = p.Quantidade;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValorProduto.Name].Value = p.ValorItem;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValorTotal.Name].Value = p.ValorTotal;

                    if (_venda.Pagamentos != null && _venda.Pagamentos.Count > 0 && _venda.Pagamentos.Exists(pa => pa.IdentificadoresProdutosPagos != null && pa.IdentificadoresProdutosPagos.Count > 0 &&
                                                                                                             pa.IdentificadoresProdutosPagos.Exists(i => i == p.Identificador)))
                    {
                        dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colPago.Name].Value = Properties.Resources.circle_green;
                        dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colChkPago.Name].Value = true;
                    }
                    else
                    {
                        dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colPago.Name].Value = Properties.Resources.circle_red;
                        dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colChkPago.Name].Value = false;
                    }
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Tag = p;

                }

                base.PreencherGrid(ExibirMensagem);

            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }


        private void CarregarTela()
        {
            if (_FechamentoCaixa)
            {

                tlpPagamento.RowStyles[0].Height = 0;
                tlpPagamento.RowStyles[1].Height = 0;
                tlpPagamento.RowStyles[3].Height = 0;
                tlpPagamento.RowStyles[4].Height = 0;
                tlpPagamento.RowStyles[6].Height = 0;
                tlpPagamento.RowStyles[5].SizeType = SizeType.Percent;
                tlpPagamento.RowStyles[5].Height = 100;
                tlpPagamento.RowStyles[2].SizeType = SizeType.Absolute;
                tlpPagamento.RowStyles[2].Height = 80;
            }
            else
            {
                _ValorRestante = _venda.ValorTotal;

                if (!_PagamentoParcial)
                {
                    tlpPagamento.RowStyles[3].Height = 0;
                    tlpPagamento.RowStyles[4].Height = 0;
                    CarregarControleCliente();
                    CarregarControleFuncionarios();
                    this.Height += 90;
                }
                else
                {
                    pnlClientes.Visible = false;
                    tlpPagamento.RowStyles[0].Height = 0;
                    tlpPagamento.RowStyles[1].Height = 0;

                    if (_PagamentoPorProduto)
                    {
                        tlpValorPagamento.RowStyles[1].Height = 0;
                        tlpValorPagamento.RowStyles[2].Height = 0;
                        tlpPagamento.RowStyles[2].Height = 8;
                        txtValor.Visible = false;
                        lblValor.Visible = false;
                        ExecutarPreencherGrid(false);
                    }
                    else
                    {
                        tlpPagamento.RowStyles[3].Height = 0;
                        tlpPagamento.RowStyles[4].Height = 0;
                        this.Height -= 40;
                    }
                }

            }

            RecuperarDados();
        }


        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        private void RecuperarDados()
        {
            ContratoServico.FormaPagamento.BuscarFormaPagamento.PeticaoBuscarFormaPagamento Peticao = new ContratoServico.FormaPagamento.BuscarFormaPagamento.PeticaoBuscarFormaPagamento();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;


            Agente.Agente.InvocarServico<ContratoServico.FormaPagamento.BuscarFormaPagamento.RespostaBuscarFormaPagamento, ContratoServico.FormaPagamento.BuscarFormaPagamento.PeticaoBuscarFormaPagamento>(Peticao, SDK.Operacoes.operacao.BuscarFormaPagamento,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

            if (_PagamentoPorProduto && Habilitado) txtBuscarProduto.Focus();

        }

        protected override void SetarFocusCarregamento()
        {
            base.SetarFocusCarregamento();
            txtValor.Focus();
        }
        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscarFormaPagamento)
            {

                _FormasPagamento = ((ContratoServico.FormaPagamento.BuscarFormaPagamento.RespostaBuscarFormaPagamento)(objSaida)).FormaPagamento;
                PreencherFormasPagamento();
                if (!_FechamentoCaixa)
                {
                    _ValorRestante = _venda.ValorTotal;
                    _ValorPago = 0;
                    lblValorRestante.Text = _venda.ValorTotal.ToString("N2");
                    txtValor.Text = _venda.ValorTotal.ToString("N2");

                    if (_Pagamentos != null && _Pagamentos.Count > 0 && _FormasPagamento != null && _FormasPagamento.Count > 0)
                    {
                        _ValorPago = (from Comum.Clases.Pagamento p in _Pagamentos select p.Valor).Sum();
                        _ValorRestante -= _ValorPago;

                        foreach (var p in _Pagamentos)
                        {

                            Comum.Clases.FormaPagamento objFormaPagamento = _FormasPagamento.FirstOrDefault(fp => p.FormaPagamento != null && fp.Identificador == p.FormaPagamento.Identificador);

                            if (objFormaPagamento != null)
                            {
                                dgvMarcas.Rows.Add();
                                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Name].Value = objFormaPagamento.Identificador;
                                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = objFormaPagamento.Descricao;
                                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = p.Valor.ToString("N2");
                            }
                        }

                        decimal valorAtual = (from Comum.Clases.Pagamento p in _Pagamentos
                                              where string.IsNullOrEmpty(p.Identificador)
                                              select p.Valor).Sum();

                        txtValorSelecionado.Text = valorAtual.ToString("N2");
                        lblValorPago.Text = _ValorPago.ToString("N2");
                        lblValorRestante.Text = _ValorRestante.ToString("N2");
                        txtValor.Text = _ValorRestante.ToString("N2");
                    }


                    if (_PagamentoPorProduto)
                    {
                        txtBuscarProduto.Focus();
                    }
                    else
                    {
                        txtValor.SelectAll();
                        txtValor.Focus();
                    }
                }
            }
            else if (operacao == SDK.Operacoes.operacao.FecharVenda)
            {
                ContratoServico.Venda.FecharVenda.RespostaFecharVenda objSaidaConvertido = ((ContratoServico.Venda.FecharVenda.RespostaFecharVenda)(objSaida));
                SaldoCaixa = objSaidaConvertido.SaldoCaixa;

                Troco = (from Comum.Clases.Pagamento p in _Pagamentos select p.Valor).Sum() - _venda.ValorTotal;
                if (_PagamentoParcial)
                {
                    ValorPagamento = (from Comum.Clases.Pagamento p in _Pagamentos select p.Valor).Sum();
                    base.objNotificacao.ExibirMensagem("Pagamento parcial registrado com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                }
                else
                {
                    if (!_PagamentoParcial)
                    {

                        List<Comum.Clases.Pagamento> objPagamentos = new List<Comum.Clases.Pagamento>();
                        Comum.Clases.FormaPagamento objFormaPagamento = null;

                        if (_FormasPagamento != null && _FormasPagamento.Count > 0)
                        {
                            objFormaPagamento = _FormasPagamento.FirstOrDefault(fp => fp.TipoPagamento == Comum.Enumeradores.TipoPagamento.Efetivo);
                        }

                        ResumoPagamentoVenda frmResumoPagamentoVenda = new ResumoPagamentoVenda(_Pagamentos, _venda.ValorTotal, objSaidaConvertido.Troco);

                        AbrirFormulario(frmResumoPagamentoVenda);

                    }

                    if (!_PagamentoParcial && ControleEstoque.Parametros.Parametros.ParametrosAplicacao.ImprimirTicketVenda)
                    {
                        List<Comum.Clases.Relatorios.Ticket> objTickets = (from Comum.Clases.ItemVenda iv in _venda.Items
                                                                           select new Comum.Clases.Relatorios.Ticket()
                                                                           {
                                                                               CodigoProduto = iv.Produto.Codigo.ToString(),
                                                                               DescricaoProduto = iv.Produto.Descricao,
                                                                               Quantidade = iv.Quantidade,
                                                                               ValorUnitario = iv.ValorItem,
                                                                               SubTotal = iv.ValorTotal
                                                                           }).ToList();




                        Comum.Clases.Relatorios.FechamentoVenda.FechamentoCaixa objFechamento = new Comum.Clases.Relatorios.FechamentoVenda.FechamentoCaixa()
                        {
                            Atendente = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Nome,
                            cnpj = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Cnpj,
                            EnderecoEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EnderecoEmpresa,
                            NomeEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome,
                            objTickets = objTickets,
                            TelefoneEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.TelefoneFixo
                        };

                        ControleEstoque.Relatorios.Classes.Imprimir.ImprimirTicket(objFechamento, Comum.Enumeradores.TipoRelatorio.FechamentoVenda);
                    }

                    base.objNotificacao.ExibirMensagem("Venda fechada com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (operacao == SDK.Operacoes.operacao.FecharCaixa)
            {

                ContratoServico.Caixa.FecharCaixa.RespostaFecharCaixa objRespostaConvertido = (ContratoServico.Caixa.FecharCaixa.RespostaFecharCaixa)objSaida;

                if (Parametros.CaixaSemDiferenca)
                {

                    FechamentoVendaRelatorio frmFechamento = new FechamentoVendaRelatorio(_Caixa, true, _Sangrias, _Suprimentos, _SaldoInicialCaixa, objRespostaConvertido.PagamentosEfetuados, Parametros.NomeSupervisor);

                    AbrirFormulario(frmFechamento);

                }

                base.objNotificacao.ExibirMensagem("Caixa fechado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void CarregarControleCliente()
        {

            _ucHelper = new Controles.ucHelper(Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE, false, false);
            _ucHelper.Dock = DockStyle.Fill;

            _ucHelper.DescricaoGrupo = "Dados do Cliente";
            _ucHelper.CarregarControle();

            pnlClientes.Controls.Add(_ucHelper);

        }

        private void CarregarControleFuncionarios()
        {

            _ucHelperFuncionarios = new Controles.ucHelper(Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO, false, false);
            _ucHelperFuncionarios.Dock = DockStyle.Fill;

            _ucHelperFuncionarios.DescricaoGrupo = "Dados do Funcionário";
            _ucHelperFuncionarios.CarregarControle();

            pnlFuncionarios.Controls.Add(_ucHelperFuncionarios);

        }

        private void ExecutarFecharVenda()
        {

            if (_FechamentoCaixa)
            {
                List<Comum.Clases.Pagamento> objPagamentos = new List<Comum.Clases.Pagamento>();
                Comum.Clases.FormaPagamento objFormaPagamento = null;

                if (((_Sangrias != null && _Sangrias.Count > 0) || (_Suprimentos != null && _Suprimentos.Count > 0) || _SaldoInicialCaixa > 0) && _FormasPagamento != null && _FormasPagamento.Count > 0)
                {
                    objFormaPagamento = _FormasPagamento.FirstOrDefault(fp => fp.TipoPagamento == Comum.Enumeradores.TipoPagamento.Efetivo);
                }

                if (_Vendas != null && _Vendas.Count > 0)
                {
                    foreach (var v in _Vendas)
                    {
                        if (v.Pagamentos != null && v.Pagamentos.Count > 0)
                        {
                            if (v.ValorTroco > 0)
                            {
                                Comum.Clases.Pagamento objPagamento = v.Pagamentos.FirstOrDefault(p => p.FormaPagamento.TipoPagamento == Comum.Enumeradores.TipoPagamento.Efetivo);

                                if (objPagamento != null)
                                {
                                    objPagamento.ValorTroco = v.ValorTroco;
                                }
                            }

                            objPagamentos.AddRange(v.Pagamentos);
                        }
                    }
                }

                var Somatorio = from Comum.Clases.Pagamento p in objPagamentos
                                group p by p.FormaPagamento.Codigo into Soma
                                select new
                                {
                                    FormaPagamento = Soma.First().FormaPagamento.Descricao,
                                    Total = Soma.Sum(su => su.Valor - su.ValorTroco),
                                    Identificador = Soma.First().FormaPagamento.Identificador
                                };


                List<Comum.Clases.FechamentoCaixa> SomatorioPago = null;

                if (Somatorio != null && Somatorio.Count() > 0)
                {

                    if (_PagamentosEfetuados != null && _PagamentosEfetuados.Count > 0)
                    {

                        SomatorioPago = (from Comum.Clases.FechamentoCaixa p in _PagamentosEfetuados
                                         group p by p.IdentificadorFormaPagamento into Soma
                                         select new Comum.Clases.FechamentoCaixa()
                                         {
                                             ValorFechamento = Soma.Sum(su => su.ValorFechamento),
                                             IdentificadorFormaPagamento = Soma.First().IdentificadorFormaPagamento,
                                             DescricaoFormaPagamento = Soma.First().DescricaoFormaPagamento
                                         }).ToList();


                        foreach (var se in Somatorio)
                        {
                            var sp = SomatorioPago.FirstOrDefault(spaux => spaux.IdentificadorFormaPagamento == se.Identificador);

                            if (sp != null)
                            {
                                sp.ValorDiferenca = sp.ValorFechamento - se.Total;
                                sp.ValorRecebido = se.Total;
                            }
                            else
                            {
                                SomatorioPago.Add(new Comum.Clases.FechamentoCaixa()
                                {
                                    IdentificadorFormaPagamento = se.Identificador,
                                    DescricaoFormaPagamento = se.FormaPagamento,
                                    ValorRecebido = se.Total,
                                    ValorDiferenca = se.Total * -1
                                });
                            }

                        }

                        foreach (var se in SomatorioPago)
                        {
                            var sp = Somatorio.FirstOrDefault(spaux => spaux.Identificador == se.IdentificadorFormaPagamento);

                            if (sp == null)
                            {
                                se.ValorDiferenca = se.ValorRecebido;
                            }

                        }
                    }
                }
                else
                {

                    SomatorioPago = (from Comum.Clases.FechamentoCaixa p in _PagamentosEfetuados
                                     group p by p.IdentificadorFormaPagamento into Soma
                                     select new Comum.Clases.FechamentoCaixa()
                                     {
                                         ValorFechamento = Soma.Sum(su => su.ValorFechamento),
                                         ValorDiferenca = Soma.Sum(su => su.ValorFechamento),
                                         IdentificadorFormaPagamento = Soma.First().IdentificadorFormaPagamento,
                                         DescricaoFormaPagamento = Soma.First().DescricaoFormaPagamento
                                     }).ToList();

                }

                if (objFormaPagamento != null)
                {


                    decimal ValorTotalSangria = 0;
                    decimal ValorTotalSuprimento = 0;

                    if (_Sangrias != null && _Sangrias.Count > 0)
                    {
                        ValorTotalSangria = _Sangrias.Sum(s => s.Valor);
                    }

                    if (_Suprimentos != null && _Suprimentos.Count > 0)
                    {
                        ValorTotalSuprimento = _Suprimentos.Sum(s => s.Valor);
                    }

                    if (SomatorioPago != null && SomatorioPago.Count > 0)
                    {
                        Comum.Clases.FechamentoCaixa objFechamento = SomatorioPago.FirstOrDefault(sp => sp.IdentificadorFormaPagamento == objFormaPagamento.Identificador);

                        if (objFechamento != null)
                        {
                            objFechamento.ValorTotalSangria = ValorTotalSangria;
                            objFechamento.ValorTotalSuprimento = ValorTotalSuprimento;
                            objFechamento.SaldoInicialCaixa = _SaldoInicialCaixa;
                            objFechamento.ValorRecebido += ((_SaldoInicialCaixa + ValorTotalSuprimento) - ValorTotalSangria);
                            objFechamento.ValorDiferenca = (objFechamento.ValorFechamento - objFechamento.ValorRecebido);
                        }
                        else
                        {
                            SomatorioPago.Add(new Comum.Clases.FechamentoCaixa()
                            {
                                SaldoInicialCaixa = _SaldoInicialCaixa,
                                IdentificadorFormaPagamento = objFormaPagamento.Identificador,
                                ValorTotalSangria = ValorTotalSangria,
                                ValorTotalSuprimento = ValorTotalSuprimento,
                                DescricaoFormaPagamento = objFormaPagamento.Descricao,
                                ValorRecebido = ((_SaldoInicialCaixa + ValorTotalSuprimento) - ValorTotalSangria),
                                ValorDiferenca = ((_SaldoInicialCaixa + ValorTotalSuprimento) - ValorTotalSangria) * -1
                            });
                        }
                    }
                    else
                    {
                        SomatorioPago.Add(new Comum.Clases.FechamentoCaixa()
                        {
                            SaldoInicialCaixa = _SaldoInicialCaixa,
                            IdentificadorFormaPagamento = objFormaPagamento.Identificador,
                            ValorTotalSangria = ValorTotalSangria,
                            ValorTotalSuprimento = ValorTotalSuprimento,
                            DescricaoFormaPagamento = objFormaPagamento.Descricao,
                            ValorDiferenca = ((_SaldoInicialCaixa + ValorTotalSuprimento) - ValorTotalSangria) * -1
                        });
                    }


                }

                string IdentificadorSupervisor = string.Empty;
                string NomeSupervisor = string.Empty;

                if (SomatorioPago != null && SomatorioPago.Count > 0 && SomatorioPago.Exists(sp => sp.ValorDiferenca != 0))
                {
                    Classes.Util.ExibirMensagemMsgBox("Diferenças encontradas no fechamento.", MessageBoxIcon.Asterisk);

                    UsuarioTemPermissaoSupervisorGerente(ref IdentificadorSupervisor, ref NomeSupervisor);

                    if (!string.IsNullOrEmpty(IdentificadorSupervisor))
                    {

                        DiferencasFecharCaixa frmDiferencas = new DiferencasFecharCaixa(SomatorioPago, _Caixa, _Sangrias, _Suprimentos, _SaldoInicialCaixa, NomeSupervisor, IdentificadorSupervisor);

                        if (AbrirFormulario(frmDiferencas) == DialogResult.OK)
                        {

                            FechamentoVendaRelatorio frmFechamento = new FechamentoVendaRelatorio(_Caixa, true, _Sangrias, _Suprimentos, _SaldoInicialCaixa, SomatorioPago, NomeSupervisor);

                            AbrirFormulario(frmFechamento);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else
                {

                    UsuarioTemPermissaoSupervisorGerente(ref IdentificadorSupervisor, ref NomeSupervisor);

                    if (!string.IsNullOrEmpty(IdentificadorSupervisor))
                    {

                        ContratoServico.Caixa.FecharCaixa.PeticaoFecharCaixa Peticao = new ContratoServico.Caixa.FecharCaixa.PeticaoFecharCaixa();

                        Peticao.IdentificadorResponsavelCaixa = _IdentificadorResponsavelCaixa;
                        Peticao.IdentificadorCaixa = _Caixa.Identificador;
                        Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
                        Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
                        Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                        Peticao.PagamentosEfetuados = SomatorioPago;

                        Agente.Agente.InvocarServico<ContratoServico.Caixa.FecharCaixa.RespostaFecharCaixa, ContratoServico.Caixa.FecharCaixa.PeticaoFecharCaixa>(Peticao, SDK.Operacoes.operacao.FecharCaixa,
                            new Comum.ParametrosTela.Generica
                            {
                                PreencherObjeto = true,
                                CaixaSemDiferenca = true,
                                NomeSupervisor = NomeSupervisor
                            }, null, true);
                    }

                }

            }
            else
            {


                if (!_PagamentoParcial && _ValorRestante > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Valor insuficiente para fechar a venda.");
                }
                else if (_PagamentoParcial && _Pagamentos != null && _Pagamentos.Count > 0 && (from Comum.Clases.Pagamento p in _Pagamentos select p.Valor).Sum() > _venda.ValorTotal)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Pagamento maior que o valor total da venda.");
                }


                ContratoServico.Venda.FecharVenda.PeticaoFecharVenda Peticao = new ContratoServico.Venda.FecharVenda.PeticaoFecharVenda();

                Peticao.IdentificadorCliente = _ucHelper != null && _ucHelper.DadoSelecinado != null ? ((Comum.Clases.Pessoa)_ucHelper.DadoSelecinado).Identificador : string.Empty;
                Peticao.IdentificadorVendedor = _ucHelperFuncionarios != null && _ucHelperFuncionarios.DadoSelecinado != null ? ((Comum.Clases.Pessoa)_ucHelperFuncionarios.DadoSelecinado).Identificador : string.Empty;
                Peticao.IdentificadorResponsavelCaixa = _IdentificadorResponsavelCaixa;
                Peticao.IdentificadorVenda = _venda.Identificador;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
                Peticao.ValorTotalVenda = _venda.ValorTotal;
                Peticao.ValorAcrescimo = _venda.ValorAcrescimo;
                Peticao.ValorDesconto = _venda.ValorDesconto;                             

                Peticao.PagamentoParcial = _PagamentoParcial;
                Peticao.Pagamentos = _Pagamentos;
                Peticao.FormasPagamento = _FormasPagamento;

                Agente.Agente.InvocarServico<ContratoServico.Venda.FecharVenda.RespostaFecharVenda, ContratoServico.Venda.FecharVenda.PeticaoFecharVenda>(Peticao, SDK.Operacoes.operacao.FecharVenda,
                    new Comum.ParametrosTela.Generica
                    {
                        PreencherObjeto = true
                    }, null, true);
            }
        }

        private void ExecutarAdicionarPagamento(decimal Valor, List<string> IdentificadorProdutos)
        {
            Comum.Clases.FormaPagamento objFormaPagamento = (Comum.Clases.FormaPagamento)(frmWindows.Util.RecuperarItemSelecionado(cmbFormaPagamento, _FormasPagamento, "Identificador"));

            if (objFormaPagamento != null)
            {
                if (_FechamentoCaixa)
                {
                    if (_PagamentosEfetuados == null) _PagamentosEfetuados = new List<Comum.Clases.FechamentoCaixa>();

                    _PagamentosEfetuados.Add(new Comum.Clases.FechamentoCaixa()
                    {
                        ValorFechamento = Valor,
                        IdentificadorFormaPagamento = objFormaPagamento.Identificador,
                        DescricaoFormaPagamento = objFormaPagamento.Descricao,
                        Identificador = Guid.NewGuid().ToString()
                    });

                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Name].Value = objFormaPagamento.Identificador;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = objFormaPagamento.Descricao;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = Valor;

                    txtValor.Focus();
                }
                else
                {
                    if (_Pagamentos == null) _Pagamentos = new List<Comum.Clases.Pagamento>();

                    _Pagamentos.Add(new Comum.Clases.Pagamento()
                    {
                        Valor = Valor,
                        FormaPagamento = objFormaPagamento,
                        IdentificadoresProdutosPagos = IdentificadorProdutos
                    });


                    if (IdentificadorProdutos != null && IdentificadorProdutos.Count > 0)
                    {
                        foreach (var pg in IdentificadorProdutos)
                        {
                            DataGridViewRow row = (from DataGridViewRow r in dgvProdutos.Rows
                                                   where r.Cells[colIdentificadorVenda.Name].Value == pg
                                                   select r).FirstOrDefault();

                            if (row != null)
                            {
                                row.Cells[colChkPago.Name].Value = true;
                                row.Cells[colPago.Name].Value = Properties.Resources.circle_green;
                                row.Cells[colChkProduto.Name].Value = false;
                            }
                        }
                    }

                    if (_PagamentoParcial && _Pagamentos != null && _Pagamentos.Count > 0 && (from Comum.Clases.Pagamento p in _Pagamentos select p.Valor).Sum() > _venda.ValorTotal)
                    {
                        _Pagamentos.RemoveAt(_Pagamentos.Count - 1);

                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Pagamento maior que o valor total da venda.");
                    }

                    _ValorPago += Valor;
                    _ValorRestante -= Valor;

                    if (_ValorRestante <= 0)
                    {
                        ExecutarFecharVenda();
                    }
                    else
                    {
                        dgvMarcas.Rows.Add();
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Name].Value = objFormaPagamento.Identificador;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = objFormaPagamento.Descricao;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = Valor;

                        decimal valorAtual = 0;
                        try
                        {
                            valorAtual = decimal.Parse(txtValorSelecionado.Text);
                        }
                        catch (Exception ex)
                        {
                            valorAtual = 0;
                        }

                        txtValorSelecionado.Text = (Valor + valorAtual).ToString("N2");

                        lblValorPago.Text = _ValorPago.ToString("N2");
                        lblValorRestante.Text = _ValorRestante.ToString("N2");
                        txtValor.Text = _ValorRestante.ToString("N2");
                        txtValor.SelectAll();
                        txtValor.Focus();
                    }
                }
            }
        }

        #endregion

        #region "Eventos"
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarFecharVenda();
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

        private void btnAlterarFormaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormaPagamento.Items != null && cmbFormaPagamento.Items.Count > 0)
                {
                    if (cmbFormaPagamento.SelectedIndex == cmbFormaPagamento.Items.Count - 1)
                    {
                        cmbFormaPagamento.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbFormaPagamento.SelectedIndex += 1;
                    }

                    if (_Pagamentos == null || _Pagamentos.Count == 0)
                    {

                        Comum.Clases.FormaPagamento objFormaPagamento = (Comum.Clases.FormaPagamento)(frmWindows.Util.RecuperarItemSelecionado(cmbFormaPagamento, _FormasPagamento, "Identificador"));

                        if (objFormaPagamento != null && objFormaPagamento.TipoPagamento != Comum.Enumeradores.TipoPagamento.Efetivo)
                        {
                            txtValor.Text = _ValorRestante.ToString("N2");
                            txtValor.SelectAll();
                        }
                    }

                    txtValor.Focus();
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

        private void btnAcrescimoDesconto_Click(object sender, EventArgs e)
        {
            try
            {
                AcrescimoDescontoFechamentoVenda frmFecharVendaAcrescimoDesconto = new AcrescimoDescontoFechamentoVenda(_venda.ValorTotal, valorAcrescimoDescontoInformado, acrescimo, desconto, porPorcentagem, porPreco);

                if (AbrirFormulario(frmFecharVendaAcrescimoDesconto) == DialogResult.OK)
                {
                    valorAcrescimoDescontoInformado = frmFecharVendaAcrescimoDesconto.ValorInformado;
                    _venda.ValorTotal = frmFecharVendaAcrescimoDesconto.ValorTotalModificado;
                    acrescimo = frmFecharVendaAcrescimoDesconto.Acrescimo;
                    desconto = frmFecharVendaAcrescimoDesconto.Desconto;   
                    porPorcentagem = frmFecharVendaAcrescimoDesconto.PorPorcentagem;
                    porPreco = frmFecharVendaAcrescimoDesconto.PorPreco;
                    if(desconto)
                    {
                        _ValorRestante -= frmFecharVendaAcrescimoDesconto.ValorCalculado;
                        _venda.ValorDesconto = frmFecharVendaAcrescimoDesconto.ValorCalculado;
                    }
                    else if(acrescimo)
                    {
                        _ValorRestante += frmFecharVendaAcrescimoDesconto.ValorCalculado;
                        _venda.ValorAcrescimo = frmFecharVendaAcrescimoDesconto.ValorCalculado;
                    }

                    lblValorRestante.Text = _ValorRestante.ToString("N2");
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_PagamentosEfetuados != null && _PagamentosEfetuados.Count > 0)
                {

                    _PagamentosEfetuados.Clear();
                    dgvMarcas.Rows.Clear();
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

        private void btnAdicionarPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormaPagamento.Items != null && cmbFormaPagamento.Items.Count > 0 && cmbFormaPagamento.SelectedItem != null)
                {

                    List<string> IdentificadoresProdutosPagos = new List<string>();
                    decimal ValorPago = 0;

                    foreach (DataGridViewRow p in dgvProdutos.Rows)
                    {

                        string IdentificadorItemVenda = p.Cells[colIdentificadorVenda.Name].Value as string;

                        if (Convert.ToBoolean(p.Cells[colChkProduto.Name].Value) &&
                            ((_venda.Pagamentos == null || _venda.Pagamentos.Count == 0) ||
                            (_venda.Pagamentos != null && _venda.Pagamentos.Count > 0 &&
                            !_venda.Pagamentos.Exists(pa => pa.IdentificadoresProdutosPagos != null && pa.IdentificadoresProdutosPagos.Count > 0 &&
                            pa.IdentificadoresProdutosPagos.Exists(i => i == IdentificadorItemVenda)))))
                        {
                            IdentificadoresProdutosPagos.Add(IdentificadorItemVenda);
                            ValorPago += Convert.ToDecimal(p.Cells[colValorTotal.Name].Value);
                        }
                    }

                    if (IdentificadoresProdutosPagos.Count > 0)
                    {
                        ExecutarAdicionarPagamento(ValorPago, IdentificadoresProdutosPagos);
                    }
                    else
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Nenhum produto selecionado.");
                    }

                    if (_PagamentoPorProduto)
                        txtBuscarProduto.Focus();
                    else
                        txtValor.Focus();
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

        private void txtValor_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValor);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtValor.Text) && Convert.ToDecimal(txtValor.Text) > 0)
                {
                    ExecutarAdicionarPagamento(Convert.ToDecimal(txtValor.Text), null);

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


        private void txtBuscarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtBuscarProduto.Text.Trim()))
                    {
                        int indiceRow = -1;
                        string[] valores = txtBuscarProduto.Text.Trim().Split(Convert.ToChar(";"));

                        foreach (var valor in valores)
                        {
                            foreach (DataGridViewRow row in dgvProdutos.Rows)
                            {
                                row.Selected = false;
                                string sequencia = row.Cells[colSequencia.Index].Value.ToString();

                                if (valor == sequencia)
                                {
                                    indiceRow = row.Index;
                                    break;
                                }
                            }

                            if (indiceRow >= 0)
                            {
                                dgvProdutos.Rows[indiceRow].Selected = true;
                               // dgvProdutos.CurrentCell = dgvProdutos.Rows[indiceRow].Cells[0];
                                dgvProdutos.Rows[indiceRow].Cells[colChkProduto.Index].Value = true;

                            }
                        }

                        txtBuscarProduto.Text = string.Empty;
                        txtBuscarProduto.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colChkProduto.Index && !Convert.ToBoolean(dgvProdutos.Rows[e.RowIndex].Cells[colChkPago.Name].Value))
                        {

                            dgvProdutos.Rows[e.RowIndex].Cells[colChkProduto.Name].Value = dgvProdutos.Rows[e.RowIndex].Cells[colChkProduto.Name].Value != null ?
                                                                                            !Convert.ToBoolean(dgvProdutos.Rows[e.RowIndex].Cells[colChkProduto.Name].Value) : true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colChkProduto.Index)
                        {
                            //Define o cursor para Hand
                            Cursor.Current = Cursors.Hand;
                        }
                        else
                        {
                            //Define o cursor para default
                            Cursor.Current = Cursors.Default;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex > -1 && Convert.ToBoolean(dgvProdutos.Rows[e.RowIndex].Cells[colChkPago.Name].Value))
            {
                int checkBoxColumnIndex = colChkProduto.Index;
                var checkCell = (DataGridViewCheckBoxCell)this.dgvProdutos[checkBoxColumnIndex, e.RowIndex];
                var bounds = this.dgvProdutos.GetCellDisplayRectangle(checkBoxColumnIndex, e.RowIndex, false);

                // i was drawing a disabled checkbox if i had set the cell to read only
                if (checkCell.ReadOnly)
                {
                    const int CheckBoxWidth = 16;
                    const int CheckBoxHeight = 16;

                    // not taking into consideration any cell style paddings
                    bounds.X += (bounds.Width - CheckBoxWidth) / 2;
                    bounds.Y += (bounds.Height - CheckBoxHeight) / 2;
                    bounds.Width = CheckBoxWidth;
                    bounds.Height = CheckBoxHeight;

                    // this method is only drawn if the visual styles of the application
                    // are turned off (this is for full support)
                    ControlPaint.DrawCheckBox(e.Graphics, bounds, ButtonState.Flat);

                }
            }
        }

        #endregion
    }

}
