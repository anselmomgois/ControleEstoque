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
    public partial class DadosEmpresa : TelaBase.BaseCE
    {
        
        private Comum.Clases.Pessoa _Pessoa;
        private CurrencyTextBox CurrencyTextBox;
        private Boolean _Visualizar;

        public DadosEmpresa(Comum.Clases.Pessoa objPessoa, Boolean Visualizar)
        {
            InitializeComponent();

            _Pessoa = objPessoa;
            _Visualizar = Visualizar;

        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Propriedade"

        public Comum.Clases.Pessoa Pessoa
        {
            get 
            {
                return _Pessoa;
            }
        }

        #endregion

        #region "Metodos"

        private void BloquerarTela()
        {
            if (_Visualizar)
            {
                txtEmpresa.Enabled = false;
                txtTelefone.Enabled = false;
                txtSalario.Enabled = false;
                txtReferencia.Enabled = false;
                txtCargo.Enabled = false;
                ucEnderecoEmpresa.BloquearControle();
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }
        }

        private void CarregarTela()
        {
            CarregarEmpresa();
            BloquerarTela();

            ucEnderecoEmpresa.InformarParametrosObrigatorios(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes);
        }

        private void CarregarEmpresa()
        {

            if (_Pessoa != null)
            {
                txtEmpresa.Text = _Pessoa.DesEmpresaAnterior;
                txtTelefone.Text = _Pessoa.DesTelefoneEmpresaAnterior;
                txtCargo.Text = _Pessoa.DesCargo;
                txtReferencia.Text = _Pessoa.ObservacaoRefPessoa;
                txtSalario.Text = Convert.ToString(_Pessoa.NumSalario);
                if (_Pessoa.EnderecoCompletoEmpresa != null)
                {
                    ucEnderecoEmpresa.CarregarControle(_Pessoa.EnderecoCompletoEmpresa);
                }
            }
        }

        private void ExecutarAceitar()
        {

            if (_Pessoa == null)
            {
                _Pessoa = new Comum.Clases.Pessoa();
            }

            if (!string.IsNullOrEmpty(txtEmpresa.Text))
            {
                _Pessoa.DesEmpresaAnterior = txtEmpresa.Text;
            }

            if (!string.IsNullOrEmpty(txtSalario.Text))
            {
                _Pessoa.NumSalario = Convert.ToDecimal(txtSalario.Text);
            }

            if (!string.IsNullOrEmpty(txtCargo.Text))
            {

                _Pessoa.DesCargo = txtCargo.Text;
            }

            if (!string.IsNullOrEmpty(txtReferencia.Text))
            {
                _Pessoa.ObservacaoRefPessoa = txtReferencia.Text;
            }

            if (!string.IsNullOrEmpty(txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim()))
            {
                _Pessoa.DesTelefoneEmpresaAnterior = txtTelefone.Text;
            }

            _Pessoa.EnderecoCompletoEmpresa = ucEnderecoEmpresa.RecuperarEndereco();

            if (_Pessoa.EnderecoCompletoEmpresa != null)
            {
                _Pessoa.EnderecoEmpresa = _Pessoa.EnderecoCompletoEmpresa.Cidades.First().Bairros.First().Enderecos.First();
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {

            MontarMenu(false);
            CarregarTela();
            this.pnlBase.Controls.Add(gpbInformacoes);
            gpbInformacoes.Dock = DockStyle.Fill;

            base.Inicializar();
        }

        #endregion

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            try
            {

                ExecutarAceitar();

                           }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void txtSalario_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtSalario);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }


    }
}
