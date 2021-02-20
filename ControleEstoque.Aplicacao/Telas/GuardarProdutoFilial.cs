using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoFilial : TelaBase.BaseCE
    {
        public GuardarProdutoFilial(string IdentificadorFilial, string IdentificadorProdutoServico)
        {
            InitializeComponent();

            _identificadorFilial = IdentificadorFilial;
            _identificadorProdutoServico = IdentificadorProdutoServico;
        }

        #region"Variavies"

        private string _identificadorFilial;
        private string _identificadorProdutoServico;
        private Comum.Clases.ProdutoServico _ProdutoServico;
        private Comum.Clases.ProdutoFilial _ProdutoFilial;
        private List<Comum.Clases.ProdutoComissao> _Comissoes;
        private List<Comum.Clases.UnidadeMedida> _UnidadesMedidas;
        private List<Comum.Clases.SetorEmpresa> _SetoresEmpresa;
        private CurrencyTextBox CurrencyTextBox;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
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

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarProdutoFilial)
            {
                ContratoServico.Telas.GuardarProdutoFilial.Carregar.RespostaGuardarProdutoFilialCarregar objSaidaConvertido = (ContratoServico.Telas.GuardarProdutoFilial.Carregar.RespostaGuardarProdutoFilialCarregar)objSaida;

                _ProdutoFilial = objSaidaConvertido.ProdutoFilial;
                _ProdutoServico = objSaidaConvertido.ProdutoServico;
                _Comissoes = objSaidaConvertido.Comissoes;
                _UnidadesMedidas = objSaidaConvertido.UnidadesMedida;
                _SetoresEmpresa = objSaidaConvertido.SetoresEmpresa;

                PreencherComboUnidadeMedidaEstoque();
                PreencherComissoes();
                PreencherSetores();
                PreencherCombosUnidadesMedida();
                PreencherControles();
            } else if(operacao == SDK.Operacoes.operacao.SetProdutoFilial)
            {

                base.objNotificacao.ExibirMensagem("Dados gravados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }

        }

        private void PreencherCombosUnidadesMedida()
        {

            if (_ProdutoServico.UnidadesMedida != null && _ProdutoServico.UnidadesMedida.Count > 0)
            {

                List<Comum.Clases.UnidadeMedida> objUnidadesMedidas = new List<Comum.Clases.UnidadeMedida>();

                objUnidadesMedidas.AddRange(_UnidadesMedidas.FindAll(um => um.Identificador == _ProdutoServico.UnidadesMedida.First().Identificador ||
                                                                    (um.UnidademedidaPai != null && um.UnidademedidaPai.Identificador == _ProdutoServico.UnidadesMedida.First().Identificador)));

                Comum.Clases.Util.FiltrarUnidadesMedidas(_UnidadesMedidas, ref objUnidadesMedidas);
                _UnidadesMedidas = objUnidadesMedidas;
            }
            CarregarUnidadesMedida();

        }

        private void CarregarUnidadesMedida()
        {
            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_UnidadesMedidas, "Identificador", "Descricao");

            cmbUMVendaVarejo = frmWindows.Util.PreencherCombobox(cmbUMVendaVarejo, Items);
            cmbUMVendaAtacado = frmWindows.Util.PreencherCombobox(cmbUMVendaAtacado, Items);
            cmbUMQntAtacado = frmWindows.Util.PreencherCombobox(cmbUMQntAtacado, Items);
        }

        private void RecuperarDados()
        {
            ContratoServico.Telas.GuardarProdutoFilial.Carregar.PeticaoGuardarProdutoFilialCarregar Peticao = new ContratoServico.Telas.GuardarProdutoFilial.Carregar.PeticaoGuardarProdutoFilialCarregar();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = _identificadorFilial;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorProdutoServico = _identificadorProdutoServico;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarProdutoFilial.Carregar.RespostaGuardarProdutoFilialCarregar, ContratoServico.Telas.GuardarProdutoFilial.Carregar.PeticaoGuardarProdutoFilialCarregar>(Peticao, SDK.Operacoes.operacao.CarregarGuardarProdutoFilial,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);
        }

        
        private void PreencherComboUnidadeMedidaEstoque()
        {

            if (_ProdutoServico != null && _ProdutoServico.UnidadesMedida != null && _ProdutoServico.UnidadesMedida.Count > 0)
            {
                lblUnidadeMedidaEstoque.Text = string.Format("{0}({1})", _ProdutoServico.UnidadesMedida.FirstOrDefault().Descricao, _ProdutoServico.UnidadesMedida.FirstOrDefault().Codigo);
                lblUnidadeMedidaVenda.Text = string.Format("{0}({1})", _ProdutoServico.UnidadesMedida.FirstOrDefault().Descricao, _ProdutoServico.UnidadesMedida.FirstOrDefault().Codigo);
            }
            else
            {
                txtNumeroMinimo.Enabled = false;
                txtEstoqueMinimo.Enabled = false;
            }

        }

        private void PreencherComissoes()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_Comissoes, "Identificador", "Descricao");

            if (Items != null && Items.Count > 0)
            {
                cmbComissao = frmWindows.Util.PreencherCombobox(cmbComissao, Items);
            }
            else
            {
                cmbComissao.Enabled = false;
            }

        }

        private void PreencherSetores()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_SetoresEmpresa, "IdentificadorSetorEmpresa", "DescricaoSetorEmpresa");

            if (Items != null && Items.Count > 0)
            {
                cmbSetorPreparo = frmWindows.Util.PreencherCombobox(cmbSetorPreparo, Items);
            }
            else
            {
                cmbSetorPreparo.Enabled = false;
            }

        }

        private void PreencherControles()
        {

            if (_ProdutoFilial != null)
            {

                txtDescricaoPrateleira.Text = _ProdutoFilial.DesPrateleira;
                txtEmbalagemPercentual.Text = (_ProdutoFilial.NumEmbalagemPercentual != null ? Convert.ToString(_ProdutoFilial.NumEmbalagemPercentual) : string.Empty);
                txtEstoqueMinimo.Text = (_ProdutoFilial.NumEstoqueMinimo != null ? Convert.ToString(_ProdutoFilial.NumEstoqueMinimo) : string.Empty);
                txtFretePercentual.Text = (_ProdutoFilial.NumFretePercentual != null ? Convert.ToString(_ProdutoFilial.NumFretePercentual) : string.Empty);
                txtIPIPercentual.Text = (_ProdutoFilial.NumIPIPercentual != null ? Convert.ToString(_ProdutoFilial.NumIPIPercentual) : string.Empty);
                txtNumeroMinimo.Text = (_ProdutoFilial.NumMinimoVenda != null ? Convert.ToString(_ProdutoFilial.NumMinimoVenda) : string.Empty);
                txtOutrasDespesasPercentual.Text = (_ProdutoFilial.NumOutrasDespesasPercentual != null ? Convert.ToString(_ProdutoFilial.NumOutrasDespesasPercentual) : string.Empty);

                if (_ProdutoFilial.Comissao != null)
                {
                    cmbComissao = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbComissao, _ProdutoFilial.Comissao.Identificador, "Identificador"));
                }

                if (_ProdutoFilial.SetorEmpresa != null)
                {
                    cmbSetorPreparo = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbSetorPreparo, _ProdutoFilial.SetorEmpresa.IdentificadorSetorEmpresa, "Identificador"));
                }

                txtValorVendaVarejo.Text = (_ProdutoFilial.NumValorVendaVarejo != null ? Convert.ToString(_ProdutoFilial.NumValorVendaVarejo) : string.Empty);
                txtValorVendaAtacado.Text = (_ProdutoFilial.NumValorVendaVarejo != null ? Convert.ToString(_ProdutoFilial.NumValorVendaAtacado) : string.Empty);
                txtQntVendaAtacado.Text = (_ProdutoFilial.NumQuantidadeVendaAtacado != null ? Convert.ToString(_ProdutoFilial.NumQuantidadeVendaAtacado) : string.Empty);
                txtPercentualDescontoAtacado.Text = (_ProdutoFilial.NumDescontoAtacadoPercentual != null ? Convert.ToString(_ProdutoFilial.NumDescontoAtacadoPercentual) : string.Empty);

                if (_ProdutoFilial.UnidadeMedidaVendaVarejo != null)
                {
                    cmbUMVendaVarejo = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbUMVendaVarejo, _ProdutoFilial.UnidadeMedidaVendaVarejo.Identificador, "Identificador"));
                }
                if (_ProdutoFilial.UnidadeMedidaVendaAtacado != null)
                {
                    cmbUMVendaAtacado = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbUMVendaAtacado, _ProdutoFilial.UnidadeMedidaVendaAtacado.Identificador, "Identificador"));
                }
                if (_ProdutoFilial.UnidadeMedidaQuantidadeVendaAtacado != null)
                {
                    cmbUMQntAtacado = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbUMQntAtacado, _ProdutoFilial.UnidadeMedidaQuantidadeVendaAtacado.Identificador, "Identificador"));
                }
            }
        }

        private void CarregarTela()
        {
            RecuperarDados();

        }

        private void ExecutarGravar()
        {

            Comum.Clases.ProdutoFilial objProdutoFilial = new Comum.Clases.ProdutoFilial();

            if (_ProdutoFilial != null) objProdutoFilial.Identificador = _ProdutoFilial.Identificador;

            objProdutoFilial.DesPrateleira = txtDescricaoPrateleira.Text;

            if (!string.IsNullOrEmpty(txtEmbalagemPercentual.Text))
            {
                objProdutoFilial.NumEmbalagemPercentual = Convert.ToDecimal(txtEmbalagemPercentual.Text);
            }

            if (!string.IsNullOrEmpty(txtEstoqueMinimo.Text))
            {
                objProdutoFilial.NumEstoqueMinimo = Convert.ToDecimal(txtEstoqueMinimo.Text);
            }

            if (!string.IsNullOrEmpty(txtFretePercentual.Text))
            {
                objProdutoFilial.NumFretePercentual = Convert.ToDecimal(txtFretePercentual.Text);
            }

            if (!string.IsNullOrEmpty(txtIPIPercentual.Text))
            {
                objProdutoFilial.NumIPIPercentual = Convert.ToDecimal(txtIPIPercentual.Text);
            }

            if (!string.IsNullOrEmpty(txtNumeroMinimo.Text))
            {
                objProdutoFilial.NumMinimoVenda = Convert.ToDecimal(txtNumeroMinimo.Text);
            }

            if (!string.IsNullOrEmpty(txtOutrasDespesasPercentual.Text))
            {
                objProdutoFilial.NumOutrasDespesasPercentual = Convert.ToDecimal(txtOutrasDespesasPercentual.Text);
            }

            if (cmbComissao.SelectedItem != null)
            {
                objProdutoFilial.Comissao = (Comum.Clases.ProdutoComissao)(frmWindows.Util.RecuperarItemSelecionado(cmbComissao, _Comissoes, "Identificador"));
            }

            if (_ProdutoServico != null)
            {
                objProdutoFilial.UnidadeMediaEstoque = _ProdutoServico.UnidadesMedida.FirstOrDefault();
                objProdutoFilial.UnidadeMedidaVenda = _ProdutoServico.UnidadesMedida.FirstOrDefault();
            }

            if (!string.IsNullOrEmpty(txtValorVendaVarejo.Text))
            {
                objProdutoFilial.NumValorVendaVarejo = Convert.ToDecimal(txtValorVendaVarejo.Text);
            }
            if (!string.IsNullOrEmpty(txtValorVendaAtacado.Text))
            {
                objProdutoFilial.NumValorVendaAtacado = Convert.ToDecimal(txtValorVendaAtacado.Text);
            }
            if (!string.IsNullOrEmpty(txtQntVendaAtacado.Text))
            {
                objProdutoFilial.NumQuantidadeVendaAtacado = Convert.ToInt32(txtQntVendaAtacado.Text);
            }
            if (!string.IsNullOrEmpty(txtPercentualDescontoAtacado.Text))
            {
                objProdutoFilial.NumDescontoAtacadoPercentual = Convert.ToDecimal(txtPercentualDescontoAtacado.Text);
            }
            if (cmbUMVendaVarejo.SelectedItem != null)
            {
                objProdutoFilial.UnidadeMedidaVendaVarejo = (Comum.Clases.UnidadeMedida)(frmWindows.Util.RecuperarItemSelecionado(cmbUMVendaVarejo, _UnidadesMedidas, "Identificador"));
            }
            if (cmbUMVendaAtacado.SelectedItem != null)
            {
                objProdutoFilial.UnidadeMedidaVendaAtacado = (Comum.Clases.UnidadeMedida)(frmWindows.Util.RecuperarItemSelecionado(cmbUMVendaAtacado, _UnidadesMedidas, "Identificador"));
            }
            if (cmbUMQntAtacado.SelectedItem != null)
            {
                objProdutoFilial.UnidadeMedidaQuantidadeVendaAtacado = (Comum.Clases.UnidadeMedida)(frmWindows.Util.RecuperarItemSelecionado(cmbUMQntAtacado, _UnidadesMedidas, "Identificador"));
            }

            if (cmbSetorPreparo.SelectedItem != null)
            {
                objProdutoFilial.SetorEmpresa = (Comum.Clases.SetorEmpresa)(frmWindows.Util.RecuperarItemSelecionado(cmbSetorPreparo, _SetoresEmpresa, "IdentificadorSetorEmpresa"));
            }


            ContratoServico.ProdutoFilial.SetProdutoFilial.PeticaoSetProdutoFilial Peticao = new ContratoServico.ProdutoFilial.SetProdutoFilial.PeticaoSetProdutoFilial();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = _identificadorFilial;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorProdutoServico = _identificadorProdutoServico;
            Peticao.ProdutoFilial = objProdutoFilial;

            Agente.Agente.InvocarServico<ContratoServico.ProdutoFilial.SetProdutoFilial.RespostaSetProdutoFilial, ContratoServico.ProdutoFilial.SetProdutoFilial.PeticaoSetProdutoFilial>(Peticao, 
                SDK.Operacoes.operacao.SetProdutoFilial,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);          

        }

        #endregion

        #region"Eventos"

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
                return;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }


        private void txtNumeroMinimo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtNumeroMinimo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtEstoqueMinimo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtEstoqueMinimo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtIPIPercentual_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtIPIPercentual);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtEmbalagemPercentual_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtEmbalagemPercentual);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtFretePercentual_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtFretePercentual);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtOutrasDespesasPercentual_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtOutrasDespesasPercentual);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorVendaVarejo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorVendaVarejo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorVendaAtacado_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorVendaAtacado);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtQntVendaAtacado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPercentualDescontoAtacado_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentualDescontoAtacado);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

        
    }
}
