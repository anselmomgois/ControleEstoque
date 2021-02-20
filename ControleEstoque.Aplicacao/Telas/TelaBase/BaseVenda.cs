using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Comum.Extencoes;
using Informatiz.ControleEstoque.Aplicacao.Telas.ValidarTiposEmpregados;

namespace Informatiz.ControleEstoque.Aplicacao.Telas.TelaBase
{
    public partial class BaseVenda : TelaBase.BaseCE
    {
        #region "Construtor"

        public BaseVenda()
        {
            InitializeComponent();
        }

        #endregion

        #region"Enumeradores"   

        public enum TelaVenda
        {
            VendaSupermercado,
            VendaPorComanda,
            VendaTouch
        }

        #endregion
        #region "Variaveis"
        public List<Comum.Clases.ProdutoDisponivelVenda> _ProdutosServicosRegistrados = null;
        public List<Comum.Clases.ProdutoDisponivelVenda> _ProdutosServicosMemoria = null;
        public List<Comum.Clases.ProdutoDisponivelVenda> _ProdutosServicosOriginais = null;
        public List<Comum.Clases.ProdutoDisponivelVenda> _ProdutosServicosDisponiveisVenda = null;
        public Comum.Clases.Venda _Venda = null;
        public Comum.Clases.Caixa _Caixa = null;
        private object _objLock = new object();
        private object _objLockResposta = new object();
        public TelaVenda _tipoTela;
        private Comum.Clases.Pessoa _objFuncionarioInicioComanda = null;
        private List<Comum.Clases.Mesa> _objMesasInicioComanda = null;

        #endregion

        #region "Metodos"

        protected override void Inicializar()
        {
            RecuperarDados();
            base.Inicializar();
        }


        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarProdutos)
            {
                ContratoServico.ProdutoServico.RecuperarProdutos.RespostaRecuperarProdutos objSaidaConvertido = (ContratoServico.ProdutoServico.RecuperarProdutos.RespostaRecuperarProdutos)objSaida;
                _ProdutosServicosOriginais = objSaidaConvertido.ProdutosDisponiveisVenda;

                if (_ProdutosServicosOriginais != null && _ProdutosServicosOriginais.Count > 0)
                {

                    _ProdutosServicosDisponiveisVenda = _ProdutosServicosOriginais.FindAll(p => !p.Produto.ProdutoInterno);

                    if (_ProdutosServicosDisponiveisVenda != null && _ProdutosServicosDisponiveisVenda.Count > 0)
                    {
                        _ProdutosServicosMemoria = new List<Comum.Clases.ProdutoDisponivelVenda>();

                        foreach (var p in _ProdutosServicosOriginais)
                        {
                            _ProdutosServicosMemoria.Add(p.Clone<Comum.Clases.ProdutoDisponivelVenda>());
                        }
                    }
                }

                AplicarConfiguracoesIniciais();

            }
            else if (operacao == SDK.Operacoes.operacao.CarregarGuardarVendaSupermercado)
            {
                ContratoServico.Telas.GuardarVendaSupermercado.Carregar.RespostaGuardarVendaSupermercadoCarregar objSaidaConvertido = (ContratoServico.Telas.GuardarVendaSupermercado.Carregar.RespostaGuardarVendaSupermercadoCarregar)objSaida;
                _ProdutosServicosOriginais = objSaidaConvertido.ProdutosDisponiveisVenda;

                if (_ProdutosServicosOriginais != null && _ProdutosServicosOriginais.Count > 0)
                {

                    _ProdutosServicosDisponiveisVenda = _ProdutosServicosOriginais.FindAll(p => !p.Produto.ProdutoInterno);

                    if (_ProdutosServicosDisponiveisVenda != null && _ProdutosServicosDisponiveisVenda.Count > 0)
                    {
                        _ProdutosServicosMemoria = new List<Comum.Clases.ProdutoDisponivelVenda>();

                        foreach (var p in _ProdutosServicosOriginais)
                        {
                            _ProdutosServicosMemoria.Add(p.Clone<Comum.Clases.ProdutoDisponivelVenda>());
                        }
                    }
                }


                _Venda = objSaidaConvertido.Venda;

                ConfigurarVisibilidadeBotoes();

                if (_Venda != null && _Venda.Items != null && _Venda.Items.Count > 0)
                {
                    foreach (var iv in _Venda.Items)
                    {
                        var pm = _ProdutosServicosMemoria.Find(pdm => pdm.Produto.Identificador == iv.Produto.Identificador);

                        if (pm != null)
                        {
                            pm.NumValorVendaVarejo = iv.ValorItem;
                            pm.NumValorAcrescimoCalculado = iv.Acrescimo;
                            pm.NumValorDescontoCalculado = iv.ValorDesconto;
                            pm.NumValorProdutoCalculado = (iv.ValorItem + iv.Acrescimo) - iv.ValorDesconto;
                            iv.Produto.Codigo = pm.Produto.Codigo;
                            iv.Produto.Descricao = pm.Produto.Descricao;
                        }
                    }
                }
                AtualizarControleFiltro();
                PreencherControles();
            }
            else if (operacao == SDK.Operacoes.operacao.ModificarPrecoProdutoVenda)
            {
                if (Parametros.ParametroGenerico != null)
                {
                    List<Comum.Clases.ProdutoDisponivelVenda> ProdutosModificados = (List<Comum.Clases.ProdutoDisponivelVenda>)Parametros.ParametroGenerico;

                    foreach (var p in ProdutosModificados)
                    {
                        var produtos = _ProdutosServicosRegistrados.FindAll(pm => pm.Produto.Identificador == p.Produto.Identificador);
                        var produtosMemoria = _ProdutosServicosMemoria.FindAll(pm => pm.Produto.Identificador == p.Produto.Identificador);


                        if (produtos != null && produtos.Count > 0)
                        {
                            foreach (var psm in produtos)
                            {
                                psm.NumValorAcrescimoCalculado = p.NumValorAcrescimoCalculado;
                                psm.NumValorVendaVarejo = p.NumValorVendaVarejo > 0 ? p.NumValorVendaVarejo : psm.NumValorVendaVarejo;
                                psm.NumValorDescontoCalculado = p.NumValorDescontoCalculado > 0 ? p.NumValorDescontoCalculado : psm.NumValorDescontoCalculado;
                                psm.NumValorProdutoCalculado = Convert.ToDecimal(((psm.NumValorVendaVarejo != null ? psm.NumValorVendaVarejo : 0) + psm.NumValorAcrescimoCalculado) - psm.NumValorDescontoCalculado);
                            }
                        }

                        if (produtosMemoria != null && produtosMemoria.Count > 0)
                        {
                            foreach (var psm in produtosMemoria)
                            {
                                psm.NumValorAcrescimoCalculado = p.NumValorAcrescimoCalculado;
                                psm.NumValorVendaVarejo = p.NumValorVendaVarejo > 0 ? p.NumValorVendaVarejo : psm.NumValorVendaVarejo;
                                psm.NumValorDescontoCalculado = p.NumValorDescontoCalculado > 0 ? p.NumValorDescontoCalculado : psm.NumValorDescontoCalculado;
                            }
                        }
                    }

                    AtualizarControleFiltro();

                    LimparGridVenda();

                    foreach (var ps in _ProdutosServicosRegistrados)
                    {
                        RegistrarItem(ps, false, true, false);
                    }

                }
            }
            else if (operacao == SDK.Operacoes.operacao.RecuperarVendaPorComanda)
            {
                ContratoServico.Venda.RecuperarVendaPorComanda.RespostaRecuperarVendaPorComanda objSaidaConvertido = (ContratoServico.Venda.RecuperarVendaPorComanda.RespostaRecuperarVendaPorComanda)objSaida;

                _Venda = objSaidaConvertido.Venda;

                if (_Venda != null)
                {

                    PreencherCodigoComanda(_Venda.CodigoComanda.PadLeft(15, Convert.ToChar("0")));

                    if (_Venda.Items != null && _Venda.Items.Count > 0)
                    {
                        foreach (var iv in _Venda.Items)
                        {
                            var pm = _ProdutosServicosMemoria.Find(pdm => pdm.Produto.Identificador == iv.Produto.Identificador);

                            if (pm != null)
                            {
                                pm.NumValorVendaVarejo = iv.ValorItem;
                                pm.NumValorAcrescimoCalculado = iv.Acrescimo;
                                pm.NumValorDescontoCalculado = iv.ValorDesconto;
                                pm.NumValorProdutoCalculado = (iv.ValorItem + iv.Acrescimo) - iv.ValorDesconto;
                                iv.Produto.Codigo = pm.Produto.Codigo;
                                iv.Produto.Descricao = pm.Produto.Descricao;
                            }
                        }

                        PreencherControles();
                    }

                    ConfigurarVisibilidadeBotoes();
                    OcultarBotaoInformarAtendente(false);
                }
                else
                {
                    if (Informatiz.ControleEstoque.Parametros.Parametros.ParametrosAplicacao.GerarComandaAutomatico)
                    {
                        SetarValorComanda(string.Empty);
                        Aplicacao.Classes.Util.ExibirMensagemInformacao("Comanda não encontrada.");
                    }
                    else
                    {
                        if (MessageBox.Show("Comanda não encontrada, deseja criar uma nova comanda?", "I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            SetarValorComanda(string.Empty);
                        }
                        else
                        {
                            SetarFocusControlePesquisa();
                        }
                    }
                }

            }
            else if (operacao == SDK.Operacoes.operacao.RecuperarVendaPorMesa)
            {

                ContratoServico.Venda.RecuperarVendaPorMesa.RespostaRecuperarVendaPorMesa objSaidaConvertido = (ContratoServico.Venda.RecuperarVendaPorMesa.RespostaRecuperarVendaPorMesa)objSaida;

                _Venda = objSaidaConvertido.Venda;

                if (_Venda != null)
                {
                    PreencherCodigoComanda(_Venda.CodigoComanda.PadLeft(15, Convert.ToChar("0")));

                    if (_Venda.Items != null && _Venda.Items.Count > 0)
                    {
                        foreach (var iv in _Venda.Items)
                        {
                            var pm = _ProdutosServicosMemoria.Find(pdm => pdm.Produto.Identificador == iv.Produto.Identificador);

                            if (pm != null)
                            {
                                pm.NumValorVendaVarejo = iv.ValorItem;
                                pm.NumValorAcrescimoCalculado = iv.Acrescimo;
                                pm.NumValorDescontoCalculado = iv.ValorDesconto;
                                pm.NumValorProdutoCalculado = (iv.ValorItem + iv.Acrescimo) - iv.ValorDesconto;
                                iv.Produto.Codigo = pm.Produto.Codigo;
                                iv.Produto.Descricao = pm.Produto.Descricao;
                            }
                        }

                        PreencherControles();
                    }


                    ConfigurarVisibilidadeBotoes();
                    OcultarBotaoInformarAtendente(false);

                    if (_Venda.Items == null || _Venda.Items.Count == 0)
                    {
                        SetarFocusControlePesquisa();
                    }
                }
                else
                {
                    if (MessageBox.Show("Comanda não encontrada, deseja criar uma nova comanda?", "I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        SetarValorMesa(string.Empty);
                    }
                    else
                    {
                        Comum.Clases.Pessoa objFunciionario = null;
                        List<Comum.Clases.Mesa> objMesas = null;
                        DialogResult objResultado = DialogResult.None;

                        ExibirTelaInformacoesMesaAtendente(ref objFunciionario, ref objMesas, ref objResultado);

                        if (objResultado == DialogResult.OK)
                        {

                            if (objFunciionario != null)
                            {
                                _objFuncionarioInicioComanda = objFunciionario;
                                SetarValorAtendente(objFunciionario.NomeCodigo);
                            }

                            if (objMesas != null && objMesas.Count > 0)
                            {
                                _objMesasInicioComanda = objMesas;
                                SetarValorMesa(string.Join(" - ", (from m in objMesas select m.Codigo).ToArray()));
                            }

                            RegistrarItem(null, true, false, false);
                        }

                    }
                }
            }
            else if (operacao == SDK.Operacoes.operacao.SetVenda)
            {
                ContratoServico.Venda.SetVenda.RespostaSetVenda objSaidaConvertido = (ContratoServico.Venda.SetVenda.RespostaSetVenda)objSaida;

                if (Parametros.DiferenciadorChamada == "CANCELARVENDA")
                {
                    if (objSaidaConvertido.CodigoErro == Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_TRATADO_TELA))
                    {
                        ExibirTextoLetreiro(objSaidaConvertido.DescricaoErro);
                        base.objNotificacao.ExibirMensagem(objSaidaConvertido.DescricaoErro, Controles.UcNotificacao.TipoImagem.WARNING);
                    }
                    else
                    {
                        LimparVenda();
                        base.objNotificacao.ExibirMensagem("Venda cancelada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                        ExibirTextoLetreiro("VENDA CANCELADA");
                    }
                }
                else
                {

                    lock (_objLockResposta)
                    {

                        if (objSaidaConvertido.CodigoErro == Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_TRATADO_TELA))
                        {
                            ExibirTextoLetreiro(objSaidaConvertido.DescricaoErro);
                            base.objNotificacao.ExibirMensagem(objSaidaConvertido.DescricaoErro, Controles.UcNotificacao.TipoImagem.WARNING);
                        }
                        else
                        {
                            _Venda = objSaidaConvertido.Venda;

                            ConfigurarVisibilidadeBotoes();

                            if (Parametros.ProdutoVenda != null)
                            {
                                _ProdutosServicosRegistrados.Add(Parametros.ProdutoVenda);

                                if (!string.IsNullOrEmpty(_Venda.CodigoComanda)) PreencherCodigoComanda(_Venda.CodigoComanda.PadLeft(15, Convert.ToChar("0")));
                                PreencherControlesRegistrarVenda(Parametros.ProdutoVenda);

                                OcultarBotaoInformarAtendente(false);

                                if (ControleEstoque.Parametros.Parametros.ParametrosAplicacao.ImprimirTicketSetor &&
                                    Parametros.ProdutoVenda.SetorEmpresa != null && !string.IsNullOrEmpty(Parametros.ProdutoVenda.SetorEmpresa.DescricaoImpressora))
                                {
                                    try
                                    {
                                        List<Comum.Clases.Relatorios.Ticket> objTickets = new List<Comum.Clases.Relatorios.Ticket>();
                                        objTickets.Add(new Comum.Clases.Relatorios.Ticket()
                                        {
                                            CodigoProduto = Parametros.ProdutoVenda.Produto.Codigo.ToString(),
                                            DescricaoProduto = Parametros.ProdutoVenda.Produto.Descricao,
                                            Quantidade = Parametros.ProdutoVenda.NumQuantidadeVendido,
                                            Sequencia = Parametros.ProdutoVenda.Sequencia.ToString()
                                        });

                                        if (Parametros.ProdutoVenda.Acrescimos != null && Parametros.ProdutoVenda.Acrescimos.Count > 0)
                                        {

                                            foreach (var a in Parametros.ProdutoVenda.Acrescimos)
                                            {


                                                objTickets.Add(new Comum.Clases.Relatorios.Ticket()
                                                {
                                                    CodigoProduto = a.Codigo.ToString(),
                                                    DescricaoProduto = string.Format("{0} - Acrescímo Item: {1}", a.Descricao, Parametros.ProdutoVenda.Sequencia),
                                                    Quantidade = a.Quantidade,
                                                    Sequencia = "AC"
                                                });
                                            }
                                        }

                                        if (Parametros.ProdutoVenda.Observacoes != null && Parametros.ProdutoVenda.Observacoes.Count > 0)
                                        {
                                            foreach (var a in Parametros.ProdutoVenda.Observacoes)
                                            {

                                                objTickets.Add(new Comum.Clases.Relatorios.Ticket()
                                                {
                                                    CodigoProduto = string.Empty,
                                                    Sequencia = "OBS",
                                                    DescricaoProduto = string.Format("{0} - Observação Item: {1}", a.Descricao, Parametros.ProdutoVenda.Sequencia),
                                                    Quantidade = 0
                                                });
                                            }
                                        }

                                        Comum.Clases.Relatorios.FechamentoVenda.FechamentoCaixa objFechamento = new Comum.Clases.Relatorios.FechamentoVenda.FechamentoCaixa()
                                        {
                                            Atendente = _Venda.Atendente != null ? _Venda.Atendente.Descricao : string.Empty,
                                            cnpj = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Cnpj,
                                            EnderecoEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EnderecoEmpresa,
                                            NomeEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome,
                                            objTickets = objTickets,
                                            Data = DateTime.Now,
                                            TelefoneEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.TelefoneFixo
                                        };

                                        ControleEstoque.Relatorios.Classes.Imprimir.ImprimirRelatorio(objFechamento, Comum.Enumeradores.TipoRelatorio.PedidoSetor, Parametros.ProdutoVenda.SetorEmpresa.DescricaoImpressora);

                                    }
                                    catch (Exception ex)
                                    {
                                        Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                                    }
                                }
                            }
                            else
                            {
                                SetarFocusControlePesquisa();
                            }

                        }
                    }
                }
            }

        }

        protected virtual void ExibirTelaInformacoesMesaAtendente(ref Comum.Clases.Pessoa Funcionario, ref List<Comum.Clases.Mesa> Mesas, ref DialogResult Resultado)
        {

        }

        protected virtual void AtualizarControleFiltro()
        {

        }
        protected virtual void SetarFocusControlePesquisa()
        {

        }
        protected virtual void SetarValorComanda(string Valor)
        {

        }

        protected virtual void SetarValorAtendente(string Valor)
        {

        }

        protected virtual void SetarValorMesa(string Valor)
        {

        }

        protected virtual void PreencherControles()
        {
            if (_Venda != null)
            {

                if (_Venda.Items != null && _Venda.Items.Count > 0 && _ProdutosServicosMemoria != null && _ProdutosServicosMemoria.Count > 0)
                {
                    LimparGridVenda();

                    foreach (var iv in _Venda.Items.OrderBy(i => i.Sequencia))
                    {
                        var pd = _ProdutosServicosMemoria.Find(pdm => pdm.Produto.Identificador == iv.Produto.Identificador);
                        if (pd != null)
                        {
                            var pri = pd.Clone<Comum.Clases.ProdutoDisponivelVenda>();

                            pri.NumQuantidadeVendido = iv.Quantidade;
                            pri.NumValorDescontoCalculado = iv.ValorDesconto;
                            pri.NumValorProdutoCalculado = (iv.ValorItem + iv.Acrescimo) - iv.ValorDesconto;
                            pri.Sequencia = iv.Sequencia;
                            pri.NumValorAcrescimoCalculado = iv.Acrescimo;
                            pri.Acrescimos = iv.Acrescimos;
                            pri.Observacoes = iv.Observacoes;
                            pri.NumValorAcrescimoProdutoCalculado = iv.Acrescimos != null && iv.Acrescimos.Count > 0 ? iv.Acrescimos.Sum(a => a.ValorTotal) : 0;
                            RegistrarItem(pri, false, false, false);
                        }
                    }
                }
                else
                {
                    LimparGridVenda();
                }
            }
            else
            {
                LimparGridVenda();
            }
        }

        protected virtual void OcultarBotaoInformarAtendente(Boolean Ocultar)
        {

        }

        protected virtual void ConfigurarVisibilidadeBotoes()
        {

        }

        protected virtual void LimparGridVenda()
        {

        }

        protected virtual void LimparVenda()
        {
            _Venda = null;
            _ProdutosServicosRegistrados = null;

        }

        protected virtual void AplicarConfiguracoesIniciais()
        {

        }

        public void RecuperarComanda(string Valor)
        {
            if (Parametros.Parametros.ParametrosAplicacao.TrabalhaPorComanda)
            {
                ContratoServico.Venda.RecuperarVendaPorComanda.PeticaoRecuperarVendaPorComanda Peticao = new ContratoServico.Venda.RecuperarVendaPorComanda.PeticaoRecuperarVendaPorComanda()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                    CodigoComanda = Valor
                };

                Agente.Agente.InvocarServico<ContratoServico.Venda.RecuperarVendaPorComanda.RespostaRecuperarVendaPorComanda, ContratoServico.Venda.RecuperarVendaPorComanda.PeticaoRecuperarVendaPorComanda>(Peticao,
                      SDK.Operacoes.operacao.RecuperarVendaPorComanda, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }
            else
            {
                ContratoServico.Venda.RecuperarVendaPorMesa.PeticaoRecuperarVendaPorMesa Peticao = new ContratoServico.Venda.RecuperarVendaPorMesa.PeticaoRecuperarVendaPorMesa()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                    CodigoMesa = Valor
                };

                Agente.Agente.InvocarServico<ContratoServico.Venda.RecuperarVendaPorMesa.RespostaRecuperarVendaPorMesa, ContratoServico.Venda.RecuperarVendaPorMesa.PeticaoRecuperarVendaPorMesa>(Peticao,
                      SDK.Operacoes.operacao.RecuperarVendaPorMesa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, NaoDesabilitarControles = true }, null, true);
            }
        }

        public void RegistrarItem(Comum.Clases.ProdutoDisponivelVenda ProdutoVenda, Boolean RegistrarItemBanco, Boolean PrecoModificado, bool vendaTouch)
        {
            lock (_objLock)
            {
                if (Parametros.Parametros.ParametrosAplicacao.TrabalhaPorComanda)
                {
                    string CodigoComanda = RecuperarCodigoComanda();

                    if (Parametros.Parametros.ParametrosAplicacao.GerarComandaAutomatico)
                    {
                        if (string.IsNullOrEmpty(CodigoComanda))
                        {

                            if (MessageBox.Show("Deseja criar uma nova comanda?", "I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                LimparVenda();
                                return;
                            }
                        }
                    }
                    else if (_tipoTela != TelaVenda.VendaSupermercado && string.IsNullOrEmpty(CodigoComanda))
                    {
                        Classes.Util.ExibirMensagemInformacao("Código da comanda não foi informado");
                        return;
                    }
                }

                if (ProdutoVenda != null)
                {

                    Comum.Clases.ProdutoDisponivelVenda objProdutoVenda = ProdutoVenda.Clone<Comum.Clases.ProdutoDisponivelVenda>();

                    if (_ProdutosServicosRegistrados == null) _ProdutosServicosRegistrados = new List<Comum.Clases.ProdutoDisponivelVenda>();

                    if (RegistrarItemBanco)
                    {

                        if (objProdutoVenda.NumValorProdutoCalculado > 0)
                        {
                            objProdutoVenda.NumQuantidadeVendido = objProdutoVenda.NumValorProdutoCalculado / Convert.ToDecimal(objProdutoVenda.NumValorVendaVarejo != null ? objProdutoVenda.NumValorVendaVarejo : 1);
                            objProdutoVenda.NumQuantidadeVendido = decimal.Round(objProdutoVenda.NumQuantidadeVendido, 3);
                            objProdutoVenda.CalculoTotalEfetuado = true;
                        }
                        else
                        {
                            objProdutoVenda.NumValorProdutoCalculado = Convert.ToDecimal(objProdutoVenda.NumValorVendaVarejo != null ? objProdutoVenda.NumValorVendaVarejo : 0);
                        }

                        if (objProdutoVenda.PercentualDescontoPromocao != null || objProdutoVenda.ValorDescontoPromocao != null)
                        {
                            if (objProdutoVenda.PercentualDescontoPromocao != null)
                            {
                                objProdutoVenda.NumValorDescontoCalculado += ((objProdutoVenda.NumValorProdutoCalculado * Convert.ToDecimal(objProdutoVenda.PercentualDescontoPromocao)) / 100);
                                objProdutoVenda.NumValorProdutoCalculado = objProdutoVenda.NumValorProdutoCalculado - objProdutoVenda.NumValorDescontoCalculado;
                            }
                            else
                            {
                                objProdutoVenda.NumValorDescontoCalculado += Convert.ToDecimal(objProdutoVenda.ValorDescontoPromocao);
                                objProdutoVenda.NumValorProdutoCalculado = objProdutoVenda.NumValorProdutoCalculado - Convert.ToDecimal(objProdutoVenda.ValorDescontoPromocao);
                            }

                            if (objProdutoVenda.NumValorProdutoCalculado < 0)
                            {
                                objProdutoVenda.NumValorProdutoCalculado = 0;
                            }
                        }
                        else
                        {
                            objProdutoVenda.NumValorProdutoCalculado -= objProdutoVenda.NumValorDescontoCalculado;
                            if (objProdutoVenda.NumValorProdutoCalculado < 0) objProdutoVenda.NumValorProdutoCalculado = 0;
                        }

                        if (objProdutoVenda.NumValorAcrescimoCalculado > 0)
                        {
                            objProdutoVenda.NumValorProdutoCalculado += objProdutoVenda.NumValorAcrescimoCalculado;
                        }



                        objProdutoVenda.Sequencia = (_ProdutosServicosRegistrados.Count == 0 ? 1 : _ProdutosServicosRegistrados.Max(pr => pr.Sequencia) + 1);

                        List<Comum.Clases.ProdutoDisponivelVenda> objProdutosAcrescimos = null;
                        List<Comum.Clases.ProdutoObservacao> objObservacoes = null;

                        RegistrarAcrescimos(ref objProdutosAcrescimos, ref objObservacoes, objProdutoVenda, vendaTouch);

                        ExibirTextoLetreiro(string.Format("{0} - {1}", objProdutoVenda.Produto.Descricao, objProdutoVenda.NumValorProdutoCalculado.ToString("N2")));

                        List<Comum.Clases.Acrescimo> objAcrescimos = null;
                        if (objProdutosAcrescimos != null && objProdutosAcrescimos.Count > 0)
                        {
                            objAcrescimos = new List<Comum.Clases.Acrescimo>();

                            foreach (Comum.Clases.ProdutoDisponivelVenda p in objProdutosAcrescimos)
                            {
                                objAcrescimos.Add(new Comum.Clases.Acrescimo()
                                {
                                    Identificador = p.Produto.Identificador,
                                    Codigo = p.Produto.Codigo,
                                    Descricao = p.Produto.Descricao,
                                    Quantidade = p.NumQuantidadeVendido,
                                    ValorItem = Convert.ToDecimal(p.NumValorVendaVarejo != null ? p.NumValorVendaVarejo : 0),
                                    ValorTotal = (p.NumQuantidadeVendido * Convert.ToDecimal(p.NumValorVendaVarejo != null ? p.NumValorVendaVarejo : 0))
                                });

                                objProdutoVenda.NumValorAcrescimoProdutoCalculado += objAcrescimos.LastOrDefault().ValorItem;
                            }
                        }

                        ContratoServico.Venda.SetVenda.PeticaoSetVenda Peticao = new ContratoServico.Venda.SetVenda.PeticaoSetVenda()
                        {
                            Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                            IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                            TelaPorComanda = true,
                            Venda = new Comum.Clases.Venda()
                            {
                                DataInicio = DateTime.Now,
                                Estado = Comum.Enumeradores.EstadoVenda.EmCurso,
                                Atendente = _objFuncionarioInicioComanda != null ? new Comum.Clases.Geral() { Identificador = _objFuncionarioInicioComanda.Identificador } : null,
                                Mesas = _objMesasInicioComanda,
                                FuncionarioCaixa = new Comum.Clases.Pessoa() { Identificador = Parametros.Parametros.InformacaoUsuario.Identificador },
                                IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                                Identificador = _Venda != null && !string.IsNullOrEmpty(_Venda.Identificador) ? _Venda.Identificador : string.Empty,
                                IdentificadorResponsavelCaixa = _Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : null,
                                CodigoComanda = Parametros.Parametros.ParametrosAplicacao.TrabalhaPorComanda ? RecuperarCodigoComanda() : string.Empty,
                                ItemRegistrar = new Comum.Clases.ItemVenda()
                                {
                                    Cancelado = false,
                                    Produto = objProdutoVenda.Produto,
                                    Quantidade = objProdutoVenda.NumQuantidadeVendido,
                                    ValorDesconto = objProdutoVenda.NumValorDescontoCalculado,
                                    ValorItem = objProdutoVenda.NumValorVendaVarejo != null ? (decimal)objProdutoVenda.NumValorVendaVarejo : 0,
                                    ValorTotal = objProdutoVenda.NumValorProdutoCalculado * objProdutoVenda.NumQuantidadeVendido,
                                    Acrescimo = objProdutoVenda.NumValorAcrescimoCalculado,
                                    Observacoes = objObservacoes,
                                    Acrescimos = objAcrescimos,
                                    Sequencia = objProdutoVenda.Sequencia
                                }

                            }
                        };

                        objProdutoVenda.Observacoes = objObservacoes;
                        objProdutoVenda.Acrescimos = objAcrescimos;

                        Agente.Agente.InvocarServico<ContratoServico.Venda.SetVenda.RespostaSetVenda, ContratoServico.Venda.SetVenda.PeticaoSetVenda>(Peticao,
                              SDK.Operacoes.operacao.SetVenda, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, NaoDesabilitarControles = true, ProdutoVenda = objProdutoVenda }, null, true);
                    }
                    else
                    {
                        if (!PrecoModificado) _ProdutosServicosRegistrados.Add(ProdutoVenda);

                        if (objProdutoVenda != null) objProdutoVenda.CalculoTotalEfetuado = false;
                        PreencherControlesRegistrarVenda(objProdutoVenda);
                    }
                }
                else
                {

                    ContratoServico.Venda.SetVenda.PeticaoSetVenda Peticao = new ContratoServico.Venda.SetVenda.PeticaoSetVenda()
                    {
                        Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                        IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                        TelaPorComanda = true,
                        Venda = new Comum.Clases.Venda()
                        {
                            DataInicio = DateTime.Now,
                            Estado = Comum.Enumeradores.EstadoVenda.EmCurso,
                            Atendente = _objFuncionarioInicioComanda != null ? new Comum.Clases.Geral() { Identificador = _objFuncionarioInicioComanda.Identificador } : null,
                            Mesas = _objMesasInicioComanda,
                            FuncionarioCaixa = new Comum.Clases.Pessoa() { Identificador = Parametros.Parametros.InformacaoUsuario.Identificador },
                            IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                            Identificador = _Venda != null && !string.IsNullOrEmpty(_Venda.Identificador) ? _Venda.Identificador : string.Empty,
                            IdentificadorResponsavelCaixa = _Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : null,
                            CodigoComanda = Parametros.Parametros.ParametrosAplicacao.TrabalhaPorComanda ? RecuperarCodigoComanda() : string.Empty
                        }
                    };

                    Agente.Agente.InvocarServico<ContratoServico.Venda.SetVenda.RespostaSetVenda, ContratoServico.Venda.SetVenda.PeticaoSetVenda>(Peticao,
                          SDK.Operacoes.operacao.SetVenda, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, NaoDesabilitarControles = true }, null, true);

                }
            }
        }

        public bool SolicitarUsuarioSenha()
        {
            ValidarTipoEmpregado frmValidarTipoEmpregado = new ValidarTipoEmpregado(false, true);
            if (AbrirFormulario(frmValidarTipoEmpregado) == DialogResult.OK)
            {
                if (frmValidarTipoEmpregado.UsuarioTemPermissao)
                {
                    return true;
                }
                else
                {
                    Aplicacao.Classes.Util.ExibirMensagemInformacao("O Usuário informado é distinto do usuário logado.");
                    return false;
                }
            }

            return false;
        }

        private void RegistrarAcrescimos(ref List<Comum.Clases.ProdutoDisponivelVenda> ProdutosAcrescimos,
                                         ref List<Comum.Clases.ProdutoObservacao> Observacoes,
                                         Comum.Clases.ProdutoDisponivelVenda ProdutosVenda,
                                         bool vendaTouch)
        {

            if (ProdutosVenda != null && ProdutosVenda.Produto != null && ProdutosVenda.Produto.Acrescimos != null &&
               ProdutosVenda.Produto.Acrescimos.Count > 0)
            {

                List<Comum.Clases.ProdutoDisponivelVenda> objProdutoAcrescimos = null;

                objProdutoAcrescimos = (from Comum.Clases.Acrescimo a in ProdutosVenda.Produto.Acrescimos
                                        join Comum.Clases.ProdutoDisponivelVenda pv in _ProdutosServicosOriginais on a.Identificador equals pv.Produto.Identificador
                                        select pv).ToList();

                if (objProdutoAcrescimos != null && objProdutoAcrescimos.Count > 0)
                {
                    Int32 Sequencia = 0;

                    foreach (var p in objProdutoAcrescimos.OrderBy(p => p.Produto.Descricao))
                    {
                        Sequencia += 1;
                        p.Sequencia = Sequencia;
                    }
                }

                List<Comum.Clases.ProdutoDisponivelVenda> ProdutosAcrescimosRetorno = null;
                List<Comum.Clases.ProdutoObservacao> ObservacoesRetorno = null;

                ExibirTelaAcrescimos(objProdutoAcrescimos,
                                     ProdutosVenda.Produto.ObservacoesProduto,
                                     ref ProdutosAcrescimosRetorno,
                                     ref ObservacoesRetorno,
                                     ProdutosVenda.NumQuantidadeVendido,
                                     vendaTouch);


                ProdutosAcrescimos = ProdutosAcrescimosRetorno;
                Observacoes = ObservacoesRetorno;

            }
        }

        protected virtual void ExibirTelaAcrescimos(List<Comum.Clases.ProdutoDisponivelVenda> ProdutosAcrescimos,
                                                    List<Comum.Clases.ProdutoObservacao> Observacoes,
                                                    ref List<Comum.Clases.ProdutoDisponivelVenda> ProdutosAcrescimosRetorno,
                                                    ref List<Comum.Clases.ProdutoObservacao> ObservacoesRetorno,
                                                    decimal Quantidade,
                                                    bool vendaTouch)
        {

        }

        protected virtual void PreencherControlesRegistrarVenda(Comum.Clases.ProdutoDisponivelVenda ProdutoVenda)
        {

        }

        protected virtual void PreencherCodigoComanda(string CodigoComanda)
        {

        }

        protected virtual string RecuperarCodigoComanda()
        {

            return string.Empty;
        }

        protected virtual void ExibirTextoLetreiro(string Texto)
        {

        }

        public void RecuperarDados()
        {
            if (_tipoTela == TelaVenda.VendaSupermercado)
            {
                ContratoServico.Telas.GuardarVendaSupermercado.Carregar.PeticaoGuardarVendaSupermercadoCarregar Peticao = new ContratoServico.Telas.GuardarVendaSupermercado.Carregar.PeticaoGuardarVendaSupermercadoCarregar()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                    DataAtual = DateTime.Now,
                    RecuperarImagensProduto = Parametros.Parametros.ParametrosAplicacao.RecuperarImagemProduto,
                    IdentificadorResponsavelCaixa = _Caixa.OperacaoCaixa.Identificador
                };

                Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarVendaSupermercado.Carregar.RespostaGuardarVendaSupermercadoCarregar, ContratoServico.Telas.GuardarVendaSupermercado.Carregar.PeticaoGuardarVendaSupermercadoCarregar>(Peticao,
                      SDK.Operacoes.operacao.CarregarGuardarVendaSupermercado, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }
            else
            {
                ContratoServico.ProdutoServico.RecuperarProdutos.PeticaoRecuperarProdutos Peticao = new ContratoServico.ProdutoServico.RecuperarProdutos.PeticaoRecuperarProdutos()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                    DataAtual = DateTime.Now,
                    RecuperarImagensProduto = Parametros.Parametros.ParametrosAplicacao.RecuperarImagemProduto
                };

                Agente.Agente.InvocarServico<ContratoServico.ProdutoServico.RecuperarProdutos.RespostaRecuperarProdutos, ContratoServico.ProdutoServico.RecuperarProdutos.PeticaoRecuperarProdutos>(Peticao,
                      SDK.Operacoes.operacao.RecuperarProdutos, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }

        }

        #endregion

    }
}
