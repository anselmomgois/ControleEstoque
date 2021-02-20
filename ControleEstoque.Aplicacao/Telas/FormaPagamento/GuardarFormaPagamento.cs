using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmgSistemas.Framework.Componentes;
using Informatiz.ControleEstoque.Comum.Extencoes;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarFormaPagamento : TelaBase.BaseCE
    {

        #region"Variaveis"

        private string _IdentificadorFormaPagamento;
        private Comum.Clases.FormaPagamento objFormaPagamento;
        private CurrencyTextBox CurrencyTextBox;
        private List<Classes.ValorDescricao> _TiposPagamento;

        #endregion

        public GuardarFormaPagamento(string identificadorFormaPagamento)
        {
            InitializeComponent();
            _IdentificadorFormaPagamento = identificadorFormaPagamento;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Metodos

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            CarregarTela();
            this.pnlBase.Controls.Add(tableLayoutPanel2);
            base.Inicializar();
        }

        private void CarregarTela()
        {
            PreencherTipoPagamento();
            RecuperarFormaPagamentDetalhe();
        }

        private void RecuperarFormaPagamentDetalhe()
        {

            if (!string.IsNullOrEmpty(_IdentificadorFormaPagamento))
            {
                ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.PeticaoBuscarFormaPagamentoDetalhe Peticao = new ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.PeticaoBuscarFormaPagamentoDetalhe();
                Peticao.IdentificadorFormaPagamento = _IdentificadorFormaPagamento;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.RespostaBuscarFormaPagamentoDetalhe, ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.PeticaoBuscarFormaPagamentoDetalhe>(Peticao,
                    SDK.Operacoes.operacao.BuscarFormaPagamentoDetalhe, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }

        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        private void PreencherTipoPagamento()
        {

            _TiposPagamento = new List<Classes.ValorDescricao>();

            _TiposPagamento.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoPagamento.Cartao.RecuperarValor(),
                Descricao = "Cartão"
            });

            _TiposPagamento.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoPagamento.Efetivo.RecuperarValor(),
                Descricao = "Dinheiro"
            });

            _TiposPagamento.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoPagamento.PrePago.RecuperarValor(),
                Descricao = "Pre - Pago"
            });

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_TiposPagamento, "Identificador", "Descricao");

            lstTipoPagamento = frmWindows.Util.PreencherListBox(lstTipoPagamento, Items);
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscarFormaPagamentoDetalhe)
            {
                objFormaPagamento = ((ContratoServico.FormaPagamento.BuscarFormaPagamentoDetalhe.RespostaBuscarFormaPagamentoDetalhe)objSaida).FormaPagamento;

                if (Parametros != null && Parametros.PreencherObjeto)
                {                    
                    PreencherControles();
                }

            }
            else if (operacao == SDK.Operacoes.operacao.SetFormaPagamento)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void ExecutarGravar()
        {

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                txtCodigo.Focus();
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O código da forma de pagamento é obrigatório.");

            }
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                txtDescricao.Focus();
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A descrição da forma de pagamento é obrigatório.");
            }
            ContratoServico.FormaPagamento.SetFormaPagamento.PeticaoSetFormaPagamento Peticao = new ContratoServico.FormaPagamento.SetFormaPagamento.PeticaoSetFormaPagamento();

            Peticao.FormaPagamento = new Comum.Clases.FormaPagamento();

            Peticao.FormaPagamento.Identificador = _IdentificadorFormaPagamento;
            Peticao.FormaPagamento.Codigo = txtCodigo.Text.Trim();
            Peticao.FormaPagamento.Descricao = txtDescricao.Text.Trim();

            if (!string.IsNullOrEmpty(txtValorDesconto.Text))
            {
                Peticao.FormaPagamento.ValorDesconto = decimal.Parse(txtValorDesconto.Text);
            }
            if (!string.IsNullOrEmpty(txtPercentualDesconto.Text))
            {
                Peticao.FormaPagamento.PercentualDesconto = decimal.Parse(txtPercentualDesconto.Text);
            }
            if (!string.IsNullOrEmpty(txtValorAcrescimo.Text))
            {
                Peticao.FormaPagamento.ValorAcrescimo = decimal.Parse(txtValorAcrescimo.Text);
            }
            if (!string.IsNullOrEmpty(txtPercentualAcrescimo.Text))
            {
                Peticao.FormaPagamento.PercentualAcrescimo = decimal.Parse(txtPercentualAcrescimo.Text);
            }
            //Peticao.FormaPagamento.Cartao = chkCartao.Checked;
            //Peticao.FormaPagamento.Credito = chkCredito.Checked;
            if (lstTipoPagamento.SelectedItem != null)
            {
                Peticao.FormaPagamento.TipoPagamento = Comum.Extencoes.EnumExtension.RecuperarEnum<Comum.Enumeradores.TipoPagamento>(((Classes.ValorDescricao)(frmWindows.Util.RecuperarItemSelecionado(lstTipoPagamento, _TiposPagamento, "Identificador"))).Identificador);
            }
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;

            Agente.Agente.InvocarServico<ContratoServico.FormaPagamento.SetFormaPagamento.RespostaSetFormaPagamento, ContratoServico.FormaPagamento.SetFormaPagamento.PeticaoSetFormaPagamento>(Peticao, SDK.Operacoes.operacao.SetFormaPagamento, null, null, true);

        }

        private void PreencherControles()
        {

            if (objFormaPagamento != null)
            {

                txtCodigo.Text = objFormaPagamento.Codigo;
                txtDescricao.Text = objFormaPagamento.Descricao;
                txtPercentualAcrescimo.Text = Convert.ToString(objFormaPagamento.PercentualAcrescimo);
                txtPercentualDesconto.Text = Convert.ToString(objFormaPagamento.PercentualDesconto);
                txtValorAcrescimo.Text = Convert.ToString(objFormaPagamento.ValorAcrescimo);
                txtValorDesconto.Text = Convert.ToString(objFormaPagamento.ValorDesconto);
                lstTipoPagamento = (ListBox)(frmWindows.Util.SelecionarItemControle(lstTipoPagamento, objFormaPagamento.TipoPagamento.RecuperarValor(), "Identificador"));

            }
        }

        #endregion

        #region "Eventos"            

        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {
                ExecutarGravar();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorDesconto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorDesconto);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPercentualDesconto_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentualDesconto);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorAcrescimo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorAcrescimo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtPercentualAcrescimo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtPercentualAcrescimo);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

        private void chlTiposPagamento_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
             
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }

}
