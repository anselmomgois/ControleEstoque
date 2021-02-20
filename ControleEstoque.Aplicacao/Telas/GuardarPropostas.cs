using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmgSistemas.Framework.Componentes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarPropostas : TelaBase.BaseCE
    {
        public GuardarPropostas(Boolean Visualizar, string IdentificadorProposta, Comum.Clases.Proposta objPropostaTrans,
                                Boolean TelaCRM, Comum.Clases.Pessoa Cliente)
        {
            InitializeComponent();

            _Visualizar = Visualizar;
            _IdentificadorProposta = IdentificadorProposta;
            _objPropostaTrans = objPropostaTrans;
            _TelaCRM = TelaCRM;
            _Cliente = Cliente;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private Boolean _TelaCRM;
        private Boolean _Visualizar;
        private string _IdentificadorProposta;
        private Comum.Clases.Proposta _objProposta;
        private Comum.Clases.Pessoa _Cliente;
        private CurrencyTextBox CurrencyTextBox;
        private Controles.ucHelper _ucHelper;
        private Comum.Clases.Proposta _objPropostaTrans;

        #endregion

        #region"Propriedades"

        public Comum.Clases.Proposta objPropostaTrans
        {
            get
            {
                return _objPropostaTrans;
            }
        }
        #endregion

        #region"Metodos"

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

            if (operacao == SDK.Operacoes.operacao.RecuperarProposta)
            {
                ContratoServico.Proposta.RecuperarProposta.RespostaRecuperarProposta objSaidaConvertido = (ContratoServico.Proposta.RecuperarProposta.RespostaRecuperarProposta)objSaida;

                _objProposta = objSaidaConvertido.Proposta;
                PreencherControles();
                BloquearControles();
            }
            else if(operacao == SDK.Operacoes.operacao.SetProposta)
            {
                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }
        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbProposta);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {
            CarregarControleCliente();
            RecuperarProposta();
           
        }

        private void BloquearControles()
        {
            if (_Visualizar)
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                txtNome.Enabled = false;
                txtDuvida.Enabled = false;
                txtOpniao.Enabled = false;
                txtValorContraPropostaManutencao.Enabled = false;
                txtValorContraPropostaVenda.Enabled = false;
                txtValorPropostaManutencao.Enabled = false;
                txtValorPropostaVenda.Enabled = false;
                dtpDataInstalacao.Enabled = false;
                chkAtende.Enabled = false;
                chkAtivo.Enabled = false;

            }

        }
        private void RecuperarProposta()
        {

            if (!string.IsNullOrEmpty(_IdentificadorProposta))
            {
                ContratoServico.Proposta.RecuperarProposta.PeticaoRecuperarProposta Peticao = new ContratoServico.Proposta.RecuperarProposta.PeticaoRecuperarProposta()
                {
                    IdentificadorProposta = _IdentificadorProposta,
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
                };

                Agente.Agente.InvocarServico<ContratoServico.Proposta.RecuperarProposta.RespostaRecuperarProposta, ContratoServico.Proposta.RecuperarProposta.PeticaoRecuperarProposta>(Peticao,
                      SDK.Operacoes.operacao.RecuperarProposta, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
            }
            else if (_TelaCRM)
            {
                _objProposta = _objPropostaTrans;
                PreencherControles();
                BloquearControles();
            }

        }

        private void PreencherControles()
        {

            if (_objProposta != null)
            {

                txtNome.Text = _objProposta.Descricao;
                txtCodigo.Text = _objProposta.Codigo.ToString();
                txtValorPropostaVenda.Text = _objProposta.ValorPropostaVenda.ToString();
                txtValorPropostaManutencao.Text = _objProposta.ValorPropostaManutencao.ToString();
                txtValorContraPropostaVenda.Text = _objProposta.ValorContraPropostaVenda.ToString();
                txtValorContraPropostaManutencao.Text = _objProposta.ValorContraPropostaManutencao.ToString();
                txtOpniao.Text = _objProposta.DesOpniao;
                txtDuvida.Text = _objProposta.DesDuvida;
                chkAtende.Checked = _objProposta.AtendeNecessidade;
                chkAtivo.Checked = _objProposta.Ativa;

                if (_ucHelper != null)
                {

                    if (_TelaCRM && _Cliente != null)
                    {
                        _ucHelper.PreencherDados(_Cliente);
                    }
                    else
                    {
                        _ucHelper.PreencherDados(_objProposta.Cliente);
                    }
                }

                if (_TelaCRM)
                {
                    chkAtivo.Visible = false;
                    lblAtivo.Visible = false;
                }
            }
            else
            {
                chkAtivo.Visible = false;
                lblAtivo.Visible = false;

                if (_TelaCRM)
                {
                    if (_ucHelper != null && _Cliente != null)
                    {

                        _ucHelper.PreencherDados(_Cliente);

                    }
                }
            }
        }

        private void CarregarControleCliente()
        {

            Boolean Visualizar = _Visualizar;

            if (_TelaCRM)
            {
                Visualizar = true;
            }

            _ucHelper = new Controles.ucHelper(Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE, Visualizar, false);
            _ucHelper.Dock = DockStyle.Fill;

            _ucHelper.DescricaoGrupo = "Dados do Cliente";
            _ucHelper.CarregarControle();

            pnlClientes.Controls.Add(_ucHelper);

        }

        #endregion

        #region "Eventos"         

        private void ExecutarGravar()
        {

            Comum.Clases.Proposta objProposta = new Comum.Clases.Proposta();

            if (_objPropostaTrans != null)
            {
                objProposta = _objPropostaTrans;
            }

            objProposta.Descricao = txtNome.Text.Trim();
            objProposta.Identificador = _IdentificadorProposta;
            objProposta.AtendeNecessidade = chkAtende.Checked;
            objProposta.Ativa = chkAtivo.Checked;

            if (dtpDataInstalacao.Checked)
            {
                objProposta.DataHoraInstalacao = dtpDataInstalacao.Value;
            }

            objProposta.DesDuvida = txtDuvida.Text;
            objProposta.DesOpniao = txtOpniao.Text;
            objProposta.PessoaResponsavel = new Comum.Clases.Pessoa();
            objProposta.PessoaResponsavel.Identificador = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador;

            if (_ucHelper != null && _ucHelper.DadoSelecinado != null)
            {
                objProposta.Cliente = (Comum.Clases.Pessoa)(_ucHelper.DadoSelecinado);
            }

            if (!string.IsNullOrEmpty(txtValorContraPropostaManutencao.Text))
            {
                objProposta.ValorContraPropostaManutencao = Convert.ToDecimal(txtValorContraPropostaManutencao.Text);
            }

            if (!string.IsNullOrEmpty(txtValorContraPropostaVenda.Text))
            {
                objProposta.ValorContraPropostaVenda = Convert.ToDecimal(txtValorContraPropostaVenda.Text);
            }

            if (!string.IsNullOrEmpty(txtValorPropostaManutencao.Text))
            {
                objProposta.ValorPropostaManutencao = Convert.ToDecimal(txtValorPropostaManutencao.Text);
            }

            if (!string.IsNullOrEmpty(txtValorPropostaVenda.Text))
            {
                objProposta.ValorPropostaVenda = Convert.ToDecimal(txtValorPropostaVenda.Text);
            }

            if (_TelaCRM)
            {
                _objPropostaTrans = objProposta;
                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                ContratoServico.Proposta.SetProposta.PeticaoSetProposta Peticao = new ContratoServico.Proposta.SetProposta.PeticaoSetProposta()
                {
                    IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    Proposta = objProposta,
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
                };

                Agente.Agente.InvocarServico<ContratoServico.Proposta.SetProposta.RespostaSetProposta, ContratoServico.Proposta.SetProposta.PeticaoSetProposta>(Peticao,
                      SDK.Operacoes.operacao.SetProposta, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
                
            }

            
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                ExecutarGravar();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorPropostaVenda_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorPropostaVenda);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorPropostaManutencao_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorPropostaManutencao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorContraPropostaVenda_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorContraPropostaVenda);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtValorContraPropostaManutencao_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtValorContraPropostaManutencao);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion
    }
}
