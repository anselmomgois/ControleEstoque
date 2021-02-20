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
using frmUtil = AmgSistemas.Framework.Utilitarios;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarCompra : TelaBase.BaseCE
    {
        public GuardarCompra(Boolean Visualizar, string IdentificadorCompra)
        {
            InitializeComponent();

            _Visualizar = Visualizar;
            _IdentificadorCompra = IdentificadorCompra;
            //this.Height = 980;
        }

        #region"Variaveis"
        private Controles.ucHelper _ucHelper;
        private Boolean _Visualizar;
        private string _IdentificadorCompra;
        private List<Comum.Clases.Filiais> _Filiais;
        private Comum.Clases.Compra _Compra;
        private List<Comum.Clases.UnidadeMedida> _unidadesMedidas;
        private CurrencyTextBox CurrencyTextBox;
        #endregion

        #region"Constantes"
        private const string btnInserir = "btnInserir";
        private const string btnConverter = "btnConverter";
        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Gerar Ordem Compra (F2)", btnInserir, Properties.Resources.buy, new EventHandler(btnInserir_Click), Keys.F2, false, false, false,120);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Converter a Compra (F3)", btnConverter, Properties.Resources.shopping_full, new EventHandler(btnConverter_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            this.pnlBase.Controls.Add(tableLayoutPanel1);
            CarregarTela();
            base.Inicializar();
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
            BloquearControles();
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarCompra)
            {
                ContratoServico.Telas.GuardarCompra.Carregar.RespostaGuardarCompraCarregar objSaidaConvertido = (ContratoServico.Telas.GuardarCompra.Carregar.RespostaGuardarCompraCarregar)objSaida;

                _Filiais = objSaidaConvertido.Filiais;
                lblValorCodigo.Text = objSaidaConvertido.NumeroCompra;
                _unidadesMedidas = objSaidaConvertido.UnidadesMedidas;
                _Compra = objSaidaConvertido.Compra;

                if (_Compra == null)
                {
                    lblValorEstado.Text = "Nova";
                    dtpDataRecebimento.Checked = false;
                }
                else
                {
                    if (_Compra.EstadoCompra == Comum.Enumeradores.EstadoCompra.CompraFinalizada)
                    {
                        _Visualizar = true;
                    }
                }

                CarregarFiliais();
                CarregarGridProdutos();
                PreencherControles();

            }
            else if (operacao == SDK.Operacoes.operacao.SetCompra)
            {

                ContratoServico.Compra.SetCompra.RespostaSetCompra objSaidaConvertido = (ContratoServico.Compra.SetCompra.RespostaSetCompra)objSaida;

                _Compra.Identificador = objSaidaConvertido.IdentificadorCompra;
                TraduzirEstado();
                ConfigurarVisualizacaoBotoes();
                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);

                if (_Compra.EstadoCompra == Comum.Enumeradores.EstadoCompra.CompraFinalizada)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }

        }

        private void CarregarTela()
        {
            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_REALIZAR_COMPRA_OUTRA_FILIAL, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                cmbFilial.Enabled = false;

            }

            CarregarControleCliente();
            RecuperarDados();

        }

        private void TraduzirEstado()
        {
            switch (_Compra.EstadoCompra)
            {
                case Comum.Enumeradores.EstadoCompra.CompraFinalizada:

                    lblValorEstado.Text = "Compra Finalizada";
                    break;
                case Comum.Enumeradores.EstadoCompra.OrdemEmitida:

                    lblValorEstado.Text = "Ordem Emitida";
                    break;
                case Comum.Enumeradores.EstadoCompra.CompraGerada:

                    lblValorEstado.Text = "Compra Gerada";
                    break;
            }
        }

        private void ConfigurarVisualizacaoBotoes()
        {
            if (_Compra != null)
            {
                this.AtualizarItemMenu(string.Empty, string.Empty, btnInserir,"Salvar (F2)",Properties.Resources.save,90);
                this.OcultarItemMenu(string.Empty, string.Empty, btnConverter, false);
              
                if (_Compra.EstadoCompra == Comum.Enumeradores.EstadoCompra.CompraGerada)
                {
                    this.AtualizarItemMenu(string.Empty, string.Empty, btnConverter, "Finalizar Compra (F3)", Properties.Resources.track_icon);
                }
            }
        }

        private void PreencherControles()
        {
            if (_Compra != null)
            {
                txtCodigoNotaFiscal.Text = _Compra.CodigoNotaFiscal;
                txtCodigoRastreio.Text = _Compra.CodigoRastreio;
                txtObservacao.Text = _Compra.ObservacaoCompra;
                lblValorCodigo.Text = _Compra.CodigoCompra;

                TraduzirEstado();

                CarregarGridProdutos();
                _ucHelper.PreencherDados(_Compra.Fornecedor);
                dtpDataCompra.Value = _Compra.DataCompra;
                if (_Compra.DataRecebimento != null)
                {
                    dtpDataRecebimento.Value = (DateTime)_Compra.DataRecebimento;
                    dtpDataRecebimento.Checked = true;
                }
                else
                {
                    dtpDataRecebimento.Checked = false;
                }
                txtBaseCalculo.Text = (_Compra.NumeroBaseCalculo > 0 ? _Compra.NumeroBaseCalculo.ToString("N2") : string.Empty);
                txtValorIcms.Text = (_Compra.NumeroValorIcms > 0 ? _Compra.NumeroValorIcms.ToString("N2") : string.Empty);
                txtBaseSubstituicao.Text = (_Compra.NumeroBaseSubstituicao > 0 ? _Compra.NumeroBaseSubstituicao.ToString("N2") : string.Empty);
                txtFrete.Text = (_Compra.NumeroValorFrete > 0 ? _Compra.NumeroValorFrete.ToString("N2") : string.Empty);
                txtSeguro.Text = (_Compra.NumeroSeguro > 0 ? _Compra.NumeroSeguro.ToString("N2") : string.Empty);
                txtOutrasDespesas.Text = (_Compra.NumeroOutrasDespesas > 0 ? _Compra.NumeroOutrasDespesas.ToString("N2") : string.Empty);
                txtValorIPI.Text = (_Compra.NumeroValorIPI > 0 ? _Compra.NumeroValorIPI.ToString("N2") : string.Empty);
                txtQuantidadeVolumes.Text = (_Compra.QuantidadeVolumes > 0 ? _Compra.QuantidadeVolumes.ToString() : string.Empty);
                txtEspecie.Text = _Compra.Especie;
                txtNumeroVolumes.Text = (_Compra.QuantidadeVolumes > 0 ? _Compra.QuantidadeVolumes.ToString() : string.Empty);
                txtPesoBruto.Text = (_Compra.PesoBruto > 0 ? _Compra.PesoBruto.ToString("N2") : string.Empty);
                txtPesoLiquido.Text = (_Compra.PesoLiquido > 0 ? _Compra.PesoLiquido.ToString("N2") : string.Empty);
                txtMarca.Text = _Compra.Marca;

                ConfigurarVisualizacaoBotoes();

                CalcularValorTotal();
            }
            else
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnConverter, true);
            }
        }

        private void CarregarControleCliente()
        {

            _ucHelper = new Controles.ucHelper(Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR, _Visualizar,false);
            _ucHelper.Dock = DockStyle.Fill;

            _ucHelper.DescricaoGrupo = "Dados do Fornecedor";
            _ucHelper.CarregarControle();

            pnlFornecedor.Controls.Add(_ucHelper);

        }

        private void RecuperarDados()
        {
            ContratoServico.Telas.GuardarCompra.Carregar.PeticaoGuardarCompraCarregar Peticao = new ContratoServico.Telas.GuardarCompra.Carregar.PeticaoGuardarCompraCarregar();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorCompra = _IdentificadorCompra;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarCompra.Carregar.RespostaGuardarCompraCarregar, ContratoServico.Telas.GuardarCompra.Carregar.PeticaoGuardarCompraCarregar>(Peticao, SDK.Operacoes.operacao.CarregarGuardarCompra,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);
        }

        private void CarregarFiliais()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_Filiais, "Identificador", "Nome");
            cmbFilial = frmWindows.Util.PreencherCombobox(cmbFilial, Items);

            if (_Filiais != null)
            {
                cmbFilial = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbFilial, Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Identificador, "Identificador"));
            }

        }

        private void CarregarGridProdutos()
        {

            dgvProdutos.Rows.Clear();

            if (_Compra != null && _Compra.Produtos != null && _Compra.Produtos.Count > 0)
            {

                foreach (Comum.Clases.ProdutoCompra prod in _Compra.Produtos)
                {

                    dgvProdutos.Rows.Add();

                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colIdProdutoServ.Index].Value = prod.Produto.Identificador;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colDescricao.Index].Value = prod.Produto.Descricao;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colIdProdutoFilial.Index].Value = prod.Produto.IdentificadorProdutoFilial;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colCodigo.Index].Value = prod.Produto.Codigo;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colQuantidade.Index].Value = prod.NumeroQuantidadeCompra + " " + prod.UnidadeMedidaCompra.Descricao;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValorUnitario.Index].Value = string.Format("R$ {0}", prod.ValorCompra.ToString("N2")) + " " + prod.UnidadeMedidaValorProduto.Descricao;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValorTotal.Index].Value = CalcularValorProduto(prod);

                    if (_Visualizar)
                    {
                        dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                        if (!prod.Produto.VendaPorNumeroSerie)
                        {
                            dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colNumeroSerial.Index].Value = Properties.Resources.not_serial_number_gray;
                        }
                    }
                    else
                    {
                        if (!prod.Produto.VendaPorNumeroSerie)
                        {
                            dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colNumeroSerial.Index].Value = Properties.Resources.not_serial_number;
                        }
                    }

                }

                CalcularValorCompra();
            }

        }

        private string CalcularValorProduto(Comum.Clases.ProdutoCompra objProduto)
        {
            string Valor = "R$ 0,00";
            decimal ValorTotal = 0;

            if (objProduto.UnidadeMedidaCompra != null && objProduto.UnidadeMedidaValorProduto != null)
            {
                if (objProduto.UnidadeMedidaCompra.Identificador == objProduto.UnidadeMedidaValorProduto.Identificador)
                {
                    ValorTotal += (objProduto.NumeroQuantidadeCompra * objProduto.ValorCompra);
                }
                else
                {
                    decimal QuantidadeCompra = objProduto.NumeroQuantidadeCompra;
                    decimal ValorCompra = objProduto.ValorCompra;

                    RecuperarValorUnidadePai(objProduto.UnidadeMedidaCompra, objProduto.UnidadeMedidaValorProduto, ref QuantidadeCompra, ref ValorCompra);
                    ValorTotal += (QuantidadeCompra * ValorCompra);
                }
            }

            Valor = string.Format("R$ {0}", ValorTotal.ToString("N2"));

            return Valor;
        }

        private void CalcularValorCompra()
        {
            decimal ValorTotal = 0;

            if (_Compra.Produtos != null && _Compra.Produtos.Count > 0)
            {

                foreach (Comum.Clases.ProdutoCompra pc in _Compra.Produtos)
                {
                    if (pc.UnidadeMedidaCompra != null && pc.UnidadeMedidaValorProduto != null)
                    {
                        if (pc.UnidadeMedidaCompra.Identificador == pc.UnidadeMedidaValorProduto.Identificador)
                        {
                            ValorTotal += (pc.NumeroQuantidadeCompra * pc.ValorCompra);
                        }
                        else
                        {
                            decimal QuantidadeCompra = pc.NumeroQuantidadeCompra;
                            decimal ValorCompra = pc.ValorCompra;

                            RecuperarValorUnidadePai(pc.UnidadeMedidaCompra, pc.UnidadeMedidaValorProduto, ref QuantidadeCompra, ref ValorCompra);
                            ValorTotal += (QuantidadeCompra * ValorCompra);
                        }
                    }
                }

            }
            lblValorCompraExibir.Text = string.Format("R$ {0}", ValorTotal.ToString("N2"));

            CalcularValorTotal();
        }

        private void RecuperarValorUnidadePai(Comum.Clases.UnidadeMedida UnidadeCompra, Comum.Clases.UnidadeMedida UnidadeValor, ref decimal QuantidadeCompra, ref decimal ValorCompra)
        {
            Comum.Clases.UnidadeMedida UnidadeCompraCompleto = _unidadesMedidas.Find(um => um.Identificador == UnidadeCompra.Identificador);
            Comum.Clases.UnidadeMedida UnidadeValorCompleto = _unidadesMedidas.Find(um => um.Identificador == UnidadeValor.Identificador);

            if (UnidadeCompraCompleto != null && UnidadeCompraCompleto.UnidademedidaPai != null)
            {

                if (UnidadeCompraCompleto.UnidademedidaPai.Identificador == UnidadeValor.Identificador)
                {
                    QuantidadeCompra = QuantidadeCompra * (decimal)UnidadeCompraCompleto.NumValorUnidadePai;
                }
                else
                {
                    QuantidadeCompra = QuantidadeCompra * (decimal)UnidadeCompraCompleto.NumValorUnidadePai;
                    RecuperarValorUnidadePai(UnidadeCompraCompleto.UnidademedidaPai, UnidadeValorCompleto, ref QuantidadeCompra, ref ValorCompra);
                }
            }
            else if (UnidadeValorCompleto != null && UnidadeValorCompleto.UnidademedidaPai != null)
            {
                if (UnidadeValorCompleto.UnidademedidaPai.Identificador == UnidadeCompraCompleto.Identificador)
                {

                    ValorCompra = (ValorCompra * QuantidadeCompra) / (decimal)UnidadeValorCompleto.NumValorUnidadePai;
                }
                else
                {
                    ValorCompra = ValorCompra / (decimal)UnidadeValorCompleto.NumValorUnidadePai;
                    RecuperarValorUnidadePai(UnidadeCompraCompleto, UnidadeValorCompleto.UnidademedidaPai, ref QuantidadeCompra, ref ValorCompra);
                }
            }
        }


        private void Salvar(Comum.Enumeradores.EstadoCompra EstadoCompra)
        {
            if (_Compra != null)
            {

                if (_Compra.Produtos == null || _Compra.Produtos.Count == 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Nenhuma produto informado.");
                }

                if (_ucHelper.DadoSelecinado == null || string.IsNullOrEmpty(((Comum.Clases.Pessoa)_ucHelper.DadoSelecinado).Identificador))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O Fornecedor é obrigatório.");
                }

                if (EstadoCompra == Comum.Enumeradores.EstadoCompra.CompraFinalizada)
                {
                    if (_Compra.Produtos.Exists(p => p.Produto != null && p.Produto.VendaPorNumeroSerie))
                    {
                        if (_Compra.Produtos.Exists(p => p.Produto != null && p.Produto.VendaPorNumeroSerie && (p.NumerosSerie == null || p.NumerosSerie.Count == 0)))
                        {
                            throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos comprados que tem a necesidade de informar os numeros de seríe");
                        }

                        foreach (Comum.Clases.ProdutoCompra pc in _Compra.Produtos.FindAll(p => p != null && p.Produto.VendaPorNumeroSerie))
                        {
                            decimal QuantidadeComprada = Classes.Util.RecuperarQuantidadeComprada(pc, _unidadesMedidas);

                            if (QuantidadeComprada < pc.NumerosSerie.Count)
                            {
                                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem produtos sem informar todos os números de seríe.");
                            }
                        }
                    }
                }

                foreach (Comum.Clases.ProdutoCompra pc in _Compra.Produtos)
                {
                    pc.NumeroEstoqueConvertido = Classes.Util.RecuperarQuantidadeComprada(pc, _unidadesMedidas);
                }

                ContratoServico.Compra.SetCompra.PeticaoSetCompra Peticao = new ContratoServico.Compra.SetCompra.PeticaoSetCompra();

                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
                Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;

                _Compra.DataCompra = dtpDataCompra.Value;
                _Compra.CodigoCompra = lblValorCodigo.Text;
                _Compra.CodigoNotaFiscal = txtCodigoNotaFiscal.Text;
                _Compra.CodigoRastreio = txtCodigoRastreio.Text;
                _Compra.DataRecebimento = (dtpDataRecebimento.Checked ? (Nullable<DateTime>)dtpDataRecebimento.Value : null);
                _Compra.EstadoCompra = EstadoCompra;
                _Compra.Fornecedor = (Comum.Clases.Pessoa)_ucHelper.DadoSelecinado;
                _Compra.Filial = (Comum.Clases.Filiais)(frmWindows.Util.RecuperarItemSelecionado(cmbFilial, _Filiais, "Identificador"));
                _Compra.ObservacaoCompra = txtObservacao.Text;
                _Compra.NumeroBaseCalculo = (!string.IsNullOrEmpty(txtBaseCalculo.Text) ? Convert.ToDecimal(txtBaseCalculo.Text) : 0);
                _Compra.NumeroValorIcms = (!string.IsNullOrEmpty(txtValorIcms.Text) ? Convert.ToDecimal(txtValorIcms.Text) : 0);
                _Compra.NumeroBaseSubstituicao = (!string.IsNullOrEmpty(txtBaseSubstituicao.Text) ? Convert.ToDecimal(txtBaseSubstituicao.Text) : 0);
                _Compra.NumeroValorFrete = (!string.IsNullOrEmpty(txtFrete.Text) ? Convert.ToDecimal(txtFrete.Text) : 0);
                _Compra.NumeroSeguro = (!string.IsNullOrEmpty(txtSeguro.Text) ? Convert.ToDecimal(txtSeguro.Text) : 0);
                _Compra.NumeroOutrasDespesas = (!string.IsNullOrEmpty(txtOutrasDespesas.Text) ? Convert.ToDecimal(txtOutrasDespesas.Text) : 0);
                _Compra.NumeroValorIPI = (!string.IsNullOrEmpty(txtValorIPI.Text) ? Convert.ToDecimal(txtValorIPI.Text) : 0);
                _Compra.QuantidadeVolumes = (!string.IsNullOrEmpty(txtQuantidadeVolumes.Text) ? Convert.ToInt32(txtQuantidadeVolumes.Text) : 0);
                _Compra.Especie = txtEspecie.Text;
                _Compra.NumeroVolumes = (!string.IsNullOrEmpty(txtNumeroVolumes.Text) ? Convert.ToInt32(txtNumeroVolumes.Text) : 0);
                _Compra.Marca = txtMarca.Text;
                _Compra.PesoBruto = (!string.IsNullOrEmpty(txtPesoBruto.Text) ? Convert.ToDecimal(txtPesoBruto.Text) : 0);
                _Compra.PesoLiquido = (!string.IsNullOrEmpty(txtPesoLiquido.Text) ? Convert.ToDecimal(txtPesoLiquido.Text) : 0);


                if (_Compra.Produtos != null && _Compra.Produtos.Count > 0)
                {
                    StringBuilder objErro = new StringBuilder();

                    foreach (Comum.Clases.ProdutoCompra pc in _Compra.Produtos)
                    {
                        if (pc.NumeroQuantidadeCompra == 0)
                        {
                            objErro.AppendLine(string.Format("O produto {0} não foi informado a quantidade de compra.", pc.Produto.Descricao));
                        }

                        if (pc.UnidadeMedidaCompra == null)
                        {
                            objErro.AppendLine(string.Format("O produto {0} não foi informado a unidade de medida de compra", pc.Produto.Descricao));
                        }

                        if (pc.ValorCompra == 0)
                        {
                            objErro.AppendLine(string.Format("O produto {0} não foi informado o  valor da compra.", pc.Produto.Descricao));
                        }

                        if (pc.UnidadeMedidaValorProduto == null)
                        {
                            objErro.AppendLine(string.Format("O produto {0} não foi informado a unidade de medida do valor da compra.", pc.Produto.Descricao));
                        }
                    }

                    if (objErro.Length > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, objErro.ToString());
                    }
                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Nenhum produto selecionado.");
                }

                Peticao.Compra = _Compra;

                Agente.Agente.InvocarServico<ContratoServico.Compra.SetCompra.RespostaSetCompra, ContratoServico.Compra.SetCompra.PeticaoSetCompra>(Peticao, SDK.Operacoes.operacao.SetCompra,
                    new Comum.ParametrosTela.Generica
                    {
                        PreencherObjeto = true
                    }, null, true);

            }
            else
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Nenhum produto selecionado.");
            }
        }

        private void CalcularValorTotal()
        {
            decimal ValorTotal = (!string.IsNullOrEmpty(lblValorCompraExibir.Text) ? Convert.ToDecimal(lblValorCompraExibir.Text.Replace("R$", string.Empty)) : 0);

            ValorTotal += (!string.IsNullOrEmpty(txtValorIcms.Text) ? Convert.ToDecimal(txtValorIcms.Text) : 0);
            ValorTotal += (!string.IsNullOrEmpty(txtFrete.Text) ? Convert.ToDecimal(txtFrete.Text) : 0);
            ValorTotal += (!string.IsNullOrEmpty(txtSeguro.Text) ? Convert.ToDecimal(txtSeguro.Text) : 0);
            ValorTotal += (!string.IsNullOrEmpty(txtOutrasDespesas.Text) ? Convert.ToDecimal(txtOutrasDespesas.Text) : 0);
            ValorTotal += (!string.IsNullOrEmpty(txtValorIPI.Text) ? Convert.ToDecimal(txtValorIPI.Text) : 0);

            lblValorTotalCompra.Text = string.Format("R$ {0}", ValorTotal.ToString("N2"));
        }

        private void BloquearControles()
        {
            if (_Visualizar)
            {
                cmbFilial.Enabled = false;
                txtObservacao.Enabled = false;
                btnAdicionarAgendamento.Enabled = false;
                txtBaseCalculo.Enabled = false;
                txtValorIcms.Enabled = false;
                txtBaseSubstituicao.Enabled = false;
                txtFrete.Enabled = false;
                txtSeguro.Enabled = false;
                txtOutrasDespesas.Enabled = false;
                txtValorIPI.Enabled = false;
                dtpDataCompra.Enabled = false;
                txtCodigoNotaFiscal.Enabled = false;
                txtQuantidadeVolumes.Enabled = false;
                txtEspecie.Enabled = false;
                txtNumeroVolumes.Enabled = false;
                txtCodigoRastreio.Enabled = false;
                txtPesoBruto.Enabled = false;
                txtPesoLiquido.Enabled = false;
                txtMarca.Enabled = false;
                dtpDataRecebimento.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnConverter, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

                _ucHelper.SomenteLeitura(_Visualizar);
            }
        }

        #endregion

        #region "Eventos"
        
        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0 && !_Visualizar)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colInfProduto.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colNumeroSerial.Index)
                        {

                            if (e.ColumnIndex == colExcluir.Index)
                            {

                                if (_Compra != null && _Compra.Produtos != null && _Compra.Produtos.Count > 0)
                                {
                                    _Compra.Produtos.RemoveAll(a => a.Produto.Identificador == dgvProdutos.Rows[e.RowIndex].Cells[colIdProdutoServ.Index].Value as string);
                                    CarregarGridProdutos();
                                }

                            }
                            else if (e.ColumnIndex == colNumeroSerial.Index)
                            {
                                if (_Compra != null && _Compra.Produtos != null && _Compra.Produtos.Count > 0)
                                {

                                    Comum.Clases.ProdutoCompra Produto = (from Comum.Clases.ProdutoCompra pc in _Compra.Produtos
                                                                          where pc.Produto.Identificador == dgvProdutos.Rows[e.RowIndex].Cells[colIdProdutoServ.Index].Value as string
                                                                          select pc).FirstOrDefault();

                                    if (Produto != null && Produto.Produto.VendaPorNumeroSerie)
                                    {
                                        GuardarProdutoNumeroSerie frmNumeroSerie = new GuardarProdutoNumeroSerie(Produto, _unidadesMedidas);

                                        if (frmNumeroSerie.ShowDialog() == DialogResult.OK)
                                        {
                                            Produto.NumerosSerie = frmNumeroSerie.NumerosSerieRetorno;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Comum.Clases.ProdutoCompra Produto = (from Comum.Clases.ProdutoCompra pc in _Compra.Produtos
                                                                      where pc.Produto.Identificador == dgvProdutos.Rows[e.RowIndex].Cells[colIdProdutoServ.Index].Value as string
                                                                      select pc).FirstOrDefault();

                                if (Produto != null)
                                {

                                    GuardarQuantidadeProdutoCompra frmQuantidadeProduto = new GuardarQuantidadeProdutoCompra(Produto);

                                    if (frmQuantidadeProduto.ShowDialog() == DialogResult.OK)
                                    {
                                        Produto.NumeroQuantidadeCompra = frmQuantidadeProduto.ProdutoRetorno.NumeroQuantidadeCompra;
                                        Produto.UnidadeMedidaCompra = frmQuantidadeProduto.ProdutoRetorno.UnidadeMedidaCompra;
                                        Produto.UnidadeMedidaValorProduto = frmQuantidadeProduto.ProdutoRetorno.UnidadeMedidaValorProduto;
                                        Produto.ValorCompra = frmQuantidadeProduto.ProdutoRetorno.ValorCompra;

                                        CalcularValorCompra();
                                    }

                                }
                            }
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

        private void btnAdicionarAgendamento_Click(object sender, EventArgs e)
        {
            try
            {

                Comum.Clases.Filiais objFilial = (Comum.Clases.Filiais)(frmWindows.Util.RecuperarItemSelecionado(cmbFilial, _Filiais, "Identificador"));

                if (objFilial == null)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor informar a filial");
                }

                GuardarProdutoCompra frmProdutosSelecionados = new GuardarProdutoCompra((_Compra != null && _Compra.Produtos != null && _Compra.Produtos.Count > 0 ? _Compra.Produtos : null), objFilial.Identificador);

                if (frmProdutosSelecionados.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmProdutosSelecionados.ProdutosSelecionados != null)
                    {
                        if (_Compra == null) _Compra = new Comum.Clases.Compra();
                        if (_Compra.Produtos == null) _Compra.Produtos = new List<Comum.Clases.ProdutoCompra>();

                        foreach (Comum.Clases.ProdutoCompra pc in frmProdutosSelecionados.ProdutosSelecionados)
                        {
                            Comum.Clases.ProdutoCompra objProp = (from Comum.Clases.ProdutoCompra objP in _Compra.Produtos
                                                                  where objP.Produto.Identificador == pc.Produto.Identificador
                                                                  select objP).FirstOrDefault();

                            if (objProp != null)
                            {
                                objProp.NumeroQuantidadeCompra = pc.NumeroQuantidadeCompra;
                                objProp.UnidadeMedidaCompra = pc.UnidadeMedidaCompra;
                                objProp.ValorCompra = pc.ValorCompra;
                                objProp.IdentificadorProdutoFilial = pc.IdentificadorProdutoFilial;

                            }
                            else
                            {
                                _Compra.Produtos.Add(pc);
                            }

                        }
                        CarregarGridProdutos();
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

        private void dgvProdutos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colInfProduto.Index || e.ColumnIndex == colNumeroSerial.Index)
                        {
                            if (e.ColumnIndex == colNumeroSerial.Index)
                            {
                                Comum.Clases.ProdutoCompra Produto = (from Comum.Clases.ProdutoCompra pc in _Compra.Produtos
                                                                      where pc.Produto.Identificador == dgvProdutos.Rows[e.RowIndex].Cells[colIdProdutoServ.Index].Value as string
                                                                      select pc).FirstOrDefault();

                                if (Produto != null && Produto.Produto.VendaPorNumeroSerie)
                                {
                                    Cursor.Current = Cursors.Hand;
                                }
                                else
                                {
                                    Cursor.Current = Cursors.Default;
                                }
                            }
                            else
                            {
                                //Define o cursor para Hand
                                Cursor.Current = Cursors.Hand;
                            }
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Compra != null && _Compra.EstadoCompra != Comum.Enumeradores.EstadoCompra.OrdemEmitida)
                {
                    Salvar(_Compra.EstadoCompra);
                }
                else
                {
                    Salvar(Comum.Enumeradores.EstadoCompra.OrdemEmitida);
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

        private void btnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Compra != null)
                {
                    if (_Compra.EstadoCompra == Comum.Enumeradores.EstadoCompra.OrdemEmitida)
                    {
                        Salvar(Comum.Enumeradores.EstadoCompra.CompraGerada);
                    }
                    else
                    {
                        Salvar(Comum.Enumeradores.EstadoCompra.CompraFinalizada);
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

        private void txtBaseCalculo_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtBaseCalculo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorIcms_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorIcms);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtBaseSubstituicao_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtBaseSubstituicao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtFrete_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtFrete);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtSeguro_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtSeguro);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtOutrasDespesas_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtOutrasDespesas);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorIPI_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorIPI);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPesoBruto_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPesoBruto);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPesoLiquido_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPesoLiquido);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtQuantidadeVolumes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtNumeroVolumes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
           

        private void txtValorIcms_TextChanged(object sender, EventArgs e)
        {
            try
            {

                CalcularValorTotal();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtFrete_TextChanged(object sender, EventArgs e)
        {
            try
            {

                CalcularValorTotal();
            
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtSeguro_TextChanged(object sender, EventArgs e)
        {
            try
            {

                CalcularValorTotal();
            
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtOutrasDespesas_TextChanged(object sender, EventArgs e)
        {
            try
            {

                CalcularValorTotal();
            
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorIPI_TextChanged(object sender, EventArgs e)
        {
            try
            {

                CalcularValorTotal();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }

        }



        #endregion

    }
}
