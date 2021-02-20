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

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class AberturaCaixa : TelaBase.BaseCE
    {

        #region"Constantes"
        private const string btnAbrirCaixa = "btnAbrirCaixa";
        private CurrencyTextBox CurrencyTextBox;
        #endregion

        #region"Variaveis"
        Comum.Clases.Caixa Caixa;
        #endregion

        public AberturaCaixa(Comum.Clases.Caixa objCaixa)
        {
            InitializeComponent();
            Caixa = objCaixa;
        }

        #region "Propriedades"
        public string IdentificadorResponsavelCaixa { get; set; }
        #endregion
        #region "Metodos

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

             if (operacao == SDK.Operacoes.operacao.SetAberturaCaixa)
            {
                IdentificadorResponsavelCaixa = ((ContratoServico.Caixa.SetAberturaCaixa.RespostaSetAberturaCaixa)objSaida).IdentificadorResponsavelCaixa;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }


        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Abrir Caixa (F2)", btnAbrirCaixa, Properties.Resources.save, new EventHandler(btnAbrirCaixa_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        private void ExecutarAbrirCaixa()
        {

            ContratoServico.Caixa.SetAberturaCaixa.PeticaoSetAberturaCaixa Peticao = new ContratoServico.Caixa.SetAberturaCaixa.PeticaoSetAberturaCaixa();

            Peticao.IdentificadorCaixa = Caixa.Identificador;

            Peticao.IdentificadorResponsavel = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador;
            Peticao.ValorInicial =  string.IsNullOrEmpty(txtSaldoInicial.Text) ? 0 : Convert.ToDecimal(txtSaldoInicial.Text);
            Peticao.ValorSaldo = Peticao.ValorInicial;
            Peticao.InicioOperacao = DateTime.Now;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
           
            Agente.Agente.InvocarServico<ContratoServico.Caixa.SetAberturaCaixa.RespostaSetAberturaCaixa, ContratoServico.Caixa.SetAberturaCaixa.PeticaoSetAberturaCaixa>(Peticao, SDK.Operacoes.operacao.SetAberturaCaixa, null, null, true);

        }

        #endregion

        #region "Eventos"

        private void AberturaCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                MontarMenu(false);

                Aplicacao.Classes.Util.ConfigurarEstilo(this);
                Aplicacao.Classes.Util.ConfigurarFocoComponentes(this);

                this.pnlBase.Controls.Add(tableLayoutPanel2);

                lblSaldoInicial.Text = "Informe o saldo inicial para o Caixa: '" + Caixa.Codigo.ToString() + "'";

                base.Inicializar();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnAbrirCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarAbrirCaixa();
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

        private void txtSaldoInicial_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtSaldoInicial);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

    }
}
