using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarFilial : TelaBase.BaseCE
    {
        public GuardarFilial(Comum.Clases.Filiais objFilial,
                             Boolean Visualizar)
        {
            InitializeComponent();

            _objFilial = objFilial;
            _Visualizar = Visualizar;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Variaveis"

        private Comum.Clases.Filiais _objFilial = null;
        private List<Comum.Clases.Pessoa> Pessoas = null;
        private Boolean _Visualizar = false;
        #endregion

        #region"Propriedades"

        public Comum.Clases.Filiais FilialSalva { get; set; }

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
            this.pnlBase.Controls.Add(gpbFilial);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarGerente();
            PreencherControles();
            ConfigurarVisualizacao();
        }

        private void ConfigurarVisualizacao()
        {

            if (_Visualizar)
            {
                txtNome.Enabled = false;
                ucEndereco.BloquearControle();
                dtpAbertura.Enabled = false;
                chkMatriz.Enabled = false;
                txtEmail.Enabled = false;
                txtTabelaMercadoria.Enabled = false;
                txtTelefoneCelular.Enabled = false;
                txtTelefoneFixo.Enabled = false;
                txtFax.Enabled = false;
                txtObservacao.Enabled = false;
                cmbGerente.Enabled = false;
                txtPercentualConfins.Enabled = false;
                txtPercentualPis.Enabled = false;
                txtOutrasDespesas.Enabled = false;
                txtContribuicaoSocial.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);

            }
            else if (_objFilial == null || string.IsNullOrEmpty(_objFilial.Identificador))
            {
                chkMatriz.Checked = true;
                chkMatriz.Enabled = false;
            }
        }
        private void ExecutarGravar()
        {

            if (_objFilial == null) _objFilial = new Comum.Clases.Filiais();

            _objFilial.Nome = txtNome.Text.ToUpper();
            _objFilial.Matriz = chkMatriz.Checked;
            _objFilial.Observacao = txtObservacao.Text.ToUpper();
            _objFilial.Endereco = ucEndereco.RecuperarEndereco();
            _objFilial.Email = txtEmail.Text;
            _objFilial.Ativa = chkAtiva.Checked;

            if (chkAtiva.Checked)
            {
                _objFilial.Apagar = false;
            }

            if (!string.IsNullOrEmpty(txtTabelaMercadoria.Text))
            {
                _objFilial.CodigoTabelaMercadoria = Convert.ToInt32(txtTabelaMercadoria.Text);
            }
            else
            {
                _objFilial.CodigoTabelaMercadoria = null;
            }

            string telefone = txtTelefoneFixo.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                _objFilial.TelefoneFixo = txtTelefoneFixo.Text;
            }
            else
            {
                _objFilial.TelefoneFixo = string.Empty;
            }

            telefone = txtTelefoneCelular.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");


            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                _objFilial.TelefoneMovel = txtTelefoneCelular.Text;
            }
            else
            {
                _objFilial.TelefoneMovel = string.Empty;
            }


            telefone = txtFax.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                _objFilial.TelefoneFax = txtFax.Text;
            }
            else
            {
                _objFilial.TelefoneFax = string.Empty;
            }

            if (!string.IsNullOrEmpty(txtContribuicaoSocial.Text))
            {
                _objFilial.NumContribuicaoSocialPer = Convert.ToDecimal(txtContribuicaoSocial.Text);
            }

            if (!string.IsNullOrEmpty(txtPercentualConfins.Text))
            {
                _objFilial.NumPercentualConfins = Convert.ToDecimal(txtPercentualConfins.Text);
            }

            if (!string.IsNullOrEmpty(txtOutrasDespesas.Text))
            {
                _objFilial.NumOutrasDespesas = Convert.ToDecimal(txtOutrasDespesas.Text);
            }

            if (!string.IsNullOrEmpty(txtPercentualPis.Text))
            {
                _objFilial.NumPercentualPis = Convert.ToDecimal(txtPercentualPis.Text);
            }


            if (cmbGerente.SelectedItem != null)
            {
                _objFilial.Gerente = (Comum.Clases.Pessoa)(frmWindows.Util.RecuperarItemSelecionado(cmbGerente, Pessoas, "Identificador"));
            }
            else
            {
                _objFilial.Gerente = null;
            }

            FilialSalva = _objFilial;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void PreencherControles()
        {

            if (_objFilial != null)
            {

                txtCodigo.Text = Convert.ToString(_objFilial.Codigo);
                txtNome.Text = _objFilial.Nome;

                if (_objFilial.Apagar)
                {
                    chkAtiva.Checked = false;
                }
                else
                {
                    chkAtiva.Checked = _objFilial.Ativa;
                }

                if (_objFilial.DataAbertura != null)
                {
                    dtpAbertura.Value = Convert.ToDateTime(_objFilial.DataAbertura);
                }

                ucEndereco.CarregarControle(_objFilial.Endereco);

                if (_objFilial.Gerente != null)
                {
                    cmbGerente = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbGerente, _objFilial.Gerente.Identificador, "Identificador"));
                }

                chkMatriz.Checked = _objFilial.Matriz;
                txtTelefoneFixo.Text = _objFilial.TelefoneFixo;
                txtTelefoneCelular.Text = _objFilial.TelefoneMovel;
                txtFax.Text = _objFilial.TelefoneFax;
                txtObservacao.Text = _objFilial.Observacao;
                txtEmail.Text = _objFilial.Email;
                txtTabelaMercadoria.Text = (_objFilial.CodigoTabelaMercadoria != null ? Convert.ToString(_objFilial.CodigoTabelaMercadoria) : string.Empty);
                txtPercentualConfins.Text = (_objFilial.NumPercentualConfins != null ? Convert.ToString(_objFilial.NumPercentualConfins) : string.Empty);
                txtPercentualPis.Text = (_objFilial.NumPercentualPis != null ? Convert.ToString(_objFilial.NumPercentualPis) : string.Empty);
                txtContribuicaoSocial.Text = (_objFilial.NumContribuicaoSocialPer != null ? Convert.ToString(_objFilial.NumContribuicaoSocialPer) : string.Empty);
                txtOutrasDespesas.Text = (_objFilial.NumOutrasDespesas != null ? Convert.ToString(_objFilial.NumOutrasDespesas) : string.Empty);

            }
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }
                
        private void RecuperarGerente()
        {
            ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao = new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
            {
                TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO,
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas, ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas>(Peticao,
                  SDK.Operacoes.operacao.RecuperarPessoas, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                base.RespostaAgente(objSaida, operacao, Parametros);

                if (operacao == SDK.Operacoes.operacao.RecuperarPessoas)
                {

                    Pessoas = ((ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas)objSaida).Pessoas;
                    PreencherComboGerente();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void PreencherComboGerente()
        {

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Pessoas, "Identificador", "DesNome");
            cmbGerente = frmWindows.Util.PreencherCombobox(cmbGerente, Items);

        }
        #endregion

        #region"Eventos"         

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }
        #endregion

    }
}
