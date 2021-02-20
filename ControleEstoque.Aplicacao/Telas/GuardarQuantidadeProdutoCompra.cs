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

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarQuantidadeProdutoCompra : TelaBase.BaseCE
    {
        public GuardarQuantidadeProdutoCompra(Comum.Clases.ProdutoCompra Produto)
        {
            InitializeComponent();
            _Produto = Produto;

        }

        #region "Variaveis"

        private List<Comum.Clases.UnidadeMedida> _UnidadesMedidas;
        private Comum.Clases.ProdutoCompra _Produto;
        private CurrencyTextBox CurrencyTextBox;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Propriedades"
        public Comum.Clases.ProdutoCompra ProdutoRetorno { get; set; }
        #endregion

        #region  "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnInserir_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tableLayoutPanel1);
            RecuperarDados();
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
            txtQuantidadeCompra.Focus();
            txtQuantidadeCompra.SelectAll();
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarUnidadesMedida)
            {
                ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida objSaidaConvertido = (ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida)objSaida;

                _UnidadesMedidas = objSaidaConvertido.UnidadesMedida;

                if (_Produto.Produto.UnidadesMedida != null && _Produto.Produto.UnidadesMedida.Count > 0)
                {

                    List<Comum.Clases.UnidadeMedida> objUnidadesMedidas = new List<Comum.Clases.UnidadeMedida>();

                    objUnidadesMedidas.AddRange(_UnidadesMedidas.FindAll(um => um.Identificador == _Produto.Produto.UnidadesMedida.First().Identificador ||
                                                                        (um.UnidademedidaPai != null && um.UnidademedidaPai.Identificador == _Produto.Produto.UnidadesMedida.First().Identificador)));

                    Comum.Clases.Util.FiltrarUnidadesMedidas(_UnidadesMedidas, ref objUnidadesMedidas);
                   
                    _UnidadesMedidas = objUnidadesMedidas;

                }
                CarregarUnidadesMedida();
                PreencherControles();
            }

        }

        private void FiltrarUnidadesMedidas(ref List<Comum.Clases.UnidadeMedida> objUnidadesMedida)
        {
            if (objUnidadesMedida != null && objUnidadesMedida.Count > 0)
            {
                List<Comum.Clases.UnidadeMedida> objUnidadesFiltradas = null;
                List<Comum.Clases.UnidadeMedida> objUnidadesComparar = objUnidadesMedida;

                foreach (Comum.Clases.UnidadeMedida unidade in objUnidadesMedida.FindAll(ump => ump.UnidademedidaPai != null))
                {
                    if (_UnidadesMedidas.Exists(um => um.UnidademedidaPai != null && um.UnidademedidaPai.Identificador == unidade.Identificador && !objUnidadesComparar.Exists(ume => ume.Identificador == um.Identificador)))
                    {
                        if (objUnidadesFiltradas == null) { objUnidadesFiltradas = new List<Comum.Clases.UnidadeMedida>(); }
                        objUnidadesFiltradas.Add(_UnidadesMedidas.Find(um => um.UnidademedidaPai != null && um.UnidademedidaPai.Identificador == unidade.Identificador && !objUnidadesComparar.Exists(ume => ume.Identificador == um.Identificador)));
                    }
                }

                if (objUnidadesFiltradas != null && objUnidadesFiltradas.Count > 0)
                {
                    FiltrarUnidadesMedidas(ref objUnidadesFiltradas);
                    objUnidadesMedida.AddRange(objUnidadesFiltradas);
                }

            }
        }

        private void CarregarUnidadesMedida()
        {
            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_UnidadesMedidas, "Identificador", "Descricao");

            cmbUnidadeMedidaQuantidadeCompra = frmWindows.Util.PreencherCombobox(cmbUnidadeMedidaQuantidadeCompra, Items);
            cmbUnidadeMedidaValor = frmWindows.Util.PreencherCombobox(cmbUnidadeMedidaValor, Items);

        }

        private void RecuperarDados()
        {
            ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida Peticao = new ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.RecuperarUnidadesFilhas = true;

            Agente.Agente.InvocarServico<ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida, ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida>(Peticao, SDK.Operacoes.operacao.RecuperarUnidadesMedida,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);
        }

        private void PreencherControles()
        {

            if (_Produto != null)
            {
                txtQuantidadeCompra.Text = Convert.ToString(_Produto.NumeroQuantidadeCompra);
                txtValorCompra.Text = Convert.ToString(_Produto.ValorCompra);
                txtCodigoLote.Text = _Produto.CodigoLote;
                dtpDataValidade.Value = (DateTime)(_Produto.DataValidade == null ? DateTime.Now : _Produto.DataValidade);
                txtCstIcms.Text = (_Produto.NumeroCstIcms > 0 ? _Produto.NumeroCstIcms.ToString("N2") : string.Empty);
                txtPorcentagemIcms.Text = (_Produto.NumeroPorcentagemIcms > 0 ? _Produto.NumeroPorcentagemIcms.ToString("N2") : string.Empty);
                txtPorcentagemBcIcms.Text = (_Produto.NumeroPorcentagemBcIcms > 0 ? _Produto.NumeroPorcentagemBcIcms.ToString("N2") : string.Empty);
                txtCstIpi.Text = (_Produto.NumeroCstIpi > 0 ? _Produto.NumeroCstIpi.ToString("N2") : string.Empty);
                txtPorcentagemIpi.Text = (_Produto.NumeroPorcentagemIpi > 0 ? _Produto.NumeroPorcentagemIpi.ToString("N2") : string.Empty);
                txtIpi.Text = (_Produto.NumeroIpi > 0 ? _Produto.NumeroIpi.ToString("N2") : string.Empty);
                txtCfop.Text = (_Produto.NumeroCfop > 0 ? _Produto.NumeroCfop.ToString("N2") : string.Empty);
                txtIcms.Text = (_Produto.NumeroIcms > 0 ? _Produto.NumeroIcms.ToString("N2") : string.Empty);
                txtBcIcms.Text = (_Produto.NumeroBcIcms > 0 ? _Produto.NumeroBcIcms.ToString("N2") : string.Empty);
                txtBcSt.Text = (_Produto.NumeroBcSt > 0 ? _Produto.NumeroBcSt.ToString("N2") : string.Empty);
                txtIcmsSt.Text = (_Produto.NumeroIcmsSt > 0 ? _Produto.NumeroIcmsSt.ToString("N2") : string.Empty);

                if (_Produto.UnidadeMedidaCompra != null)
                {
                    cmbUnidadeMedidaQuantidadeCompra = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbUnidadeMedidaQuantidadeCompra, _Produto.UnidadeMedidaCompra.Identificador, "Identificador"));
                }


                if (_Produto.UnidadeMedidaValorProduto != null)
                {
                    cmbUnidadeMedidaValor = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbUnidadeMedidaValor, _Produto.UnidadeMedidaValorProduto.Identificador, "Identificador"));
                }

            }
        }

        #endregion

        #region "Eventos"


        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Produto == null) { _Produto = new Comum.Clases.ProdutoCompra(); }

                if (!string.IsNullOrEmpty(txtCodigoLote.Text))
                {
                    _Produto.CodigoLote = txtCodigoLote.Text;
                }


                if (!string.IsNullOrEmpty(txtQuantidadeCompra.Text))
                {

                    if (cmbUnidadeMedidaQuantidadeCompra.SelectedItem != null)
                    {
                        _Produto.UnidadeMedidaCompra = (Comum.Clases.UnidadeMedida)(frmWindows.Util.RecuperarItemSelecionado(cmbUnidadeMedidaQuantidadeCompra, _UnidadesMedidas, "Identificador"));
                    }
                    else if (Convert.ToDecimal(txtQuantidadeCompra.Text) > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Unidade de medida quantidade compra não foi informada.");
                    }

                    _Produto.NumeroQuantidadeCompra = Convert.ToDecimal(txtQuantidadeCompra.Text.Trim());
                }


                if (!string.IsNullOrEmpty(txtValorCompra.Text))
                {

                    if (cmbUnidadeMedidaValor.SelectedItem != null)
                    {
                        _Produto.UnidadeMedidaValorProduto = (Comum.Clases.UnidadeMedida)(frmWindows.Util.RecuperarItemSelecionado(cmbUnidadeMedidaValor, _UnidadesMedidas, "Identificador"));
                    }
                    else if (Convert.ToDecimal(txtValorCompra.Text) > 0)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Unidade de medida valor produto não foi informada.");
                    }

                    _Produto.ValorCompra = Convert.ToDecimal(txtValorCompra.Text.Trim());
                }


                _Produto.DataValidade = dtpDataValidade.Value;
                _Produto.NumeroBcIcms = (string.IsNullOrEmpty(txtBcIcms.Text) ? 0 : Convert.ToDecimal(txtBcIcms.Text));
                _Produto.NumeroBcSt = (string.IsNullOrEmpty(txtBcSt.Text) ? 0 : Convert.ToDecimal(txtBcSt.Text));
                _Produto.NumeroCfop = (string.IsNullOrEmpty(txtCfop.Text) ? 0 : Convert.ToDecimal(txtCfop.Text));
                _Produto.NumeroCstIcms = (string.IsNullOrEmpty(txtCstIcms.Text) ? 0 : Convert.ToDecimal(txtCstIcms.Text));
                _Produto.NumeroCstIpi = (string.IsNullOrEmpty(txtCstIpi.Text) ? 0 : Convert.ToDecimal(txtCstIpi.Text));
                _Produto.NumeroIcms = (string.IsNullOrEmpty(txtIcms.Text) ? 0 : Convert.ToDecimal(txtIcms.Text));
                _Produto.NumeroIcmsSt = (string.IsNullOrEmpty(txtIcmsSt.Text) ? 0 : Convert.ToDecimal(txtIcmsSt.Text));
                _Produto.NumeroIpi = (string.IsNullOrEmpty(txtIpi.Text) ? 0 : Convert.ToDecimal(txtIpi.Text));
                _Produto.NumeroPorcentagemBcIcms = (string.IsNullOrEmpty(txtPorcentagemBcIcms.Text) ? 0 : Convert.ToDecimal(txtPorcentagemBcIcms.Text));
                _Produto.NumeroPorcentagemIcms = (string.IsNullOrEmpty(txtPorcentagemIcms.Text) ? 0 : Convert.ToDecimal(txtPorcentagemIcms.Text));
                _Produto.NumeroPorcentagemIpi = (string.IsNullOrEmpty(txtPorcentagemIpi.Text) ? 0 : Convert.ToDecimal(txtPorcentagemIpi.Text));
                
                ProdutoRetorno = _Produto;

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtQuantidadeCompra_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtQuantidadeCompra);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorCompra_Enter(object sender, EventArgs e)
        {
            try
            {

                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorCompra);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

    }
}