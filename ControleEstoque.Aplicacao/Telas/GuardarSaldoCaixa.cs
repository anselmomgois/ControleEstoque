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
    public partial class GuardarSaldoCaixa : TelaBase.BaseCE
    {

        Comum.Enumeradores.Enumeradores.TipoSaldoCaixa TipoSaldoCaixa;

        public GuardarSaldoCaixa(Comum.Enumeradores.Enumeradores.TipoSaldoCaixa tipoSaldoCaixa,
                                 string IdentificadorResponsavelCaixa,
                                 string IdentificadorSupervisor,
                                 decimal SaldoCaixa,
                                 Boolean Obrigatorio)
        {
            InitializeComponent();

            this.TipoSaldoCaixa = tipoSaldoCaixa;
            this.Text = TipoSaldoCaixa == Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria ? "Sangria" : "Suprimento";

            _IdentificadorResponsavelCaixa = IdentificadorResponsavelCaixa;
            _IdentificadorSupervisor = IdentificadorSupervisor;
            _Saldo = SaldoCaixa;
            _Obrigatorio = Obrigatorio;
            this.pnlBase.Controls.Add(tableLayoutPanel1);
        }

        #region "Variaveis"
        private string _IdentificadorResponsavelCaixa;
        private string _IdentificadorSupervisor;
        private CurrencyTextBox CurrencyTextBox;
        private decimal _Saldo;
        private Boolean _Obrigatorio;
        private Boolean _SangriaEfetuada = false;
        #endregion

        #region "Propriedades"
        public decimal Saldo
        {
            get
            {
                return _Saldo;
            }
        }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Metodos" 
        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo, !_Obrigatorio);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbSangria);
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

            if (operacao == SDK.Operacoes.operacao.RegistrarSangria)
            {

                ContratoServico.Venda.RegistrarSangria.RespostaRegistrarSangria objRespostaConvertido = (ContratoServico.Venda.RegistrarSangria.RespostaRegistrarSangria)objSaida;

                if (objRespostaConvertido != null)
                {
                    _Saldo = objRespostaConvertido.Saldo;
                }

                _SangriaEfetuada = true;
            }
            else if (operacao == SDK.Operacoes.operacao.RegistrarSuprimento)
            {

                ContratoServico.Venda.RegistrarSuprimento.RespostaRegistrarSuprimento objRespostaConvertido = (ContratoServico.Venda.RegistrarSuprimento.RespostaRegistrarSuprimento)objSaida;

                if (objRespostaConvertido != null)
                {
                    _Saldo = objRespostaConvertido.Saldo;
                }
            }

            if (TipoSaldoCaixa == Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria)
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Sangria efetuada com sucesso.");
            else
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Suprimento efetuado com sucesso.");

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ExecutarGravarSangria()
        {
            if (string.IsNullOrEmpty(txtObservacao.Text.Trim()))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Observação Obrigatória.");
            }

            if (string.IsNullOrEmpty(txtValor.Text.Trim()) || Convert.ToDecimal(txtValor.Text) == 0)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório informar um valor.");
            }

            if (!string.IsNullOrEmpty(txtValor.Text.Trim()) && Convert.ToDecimal(txtValor.Text) > _Saldo)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Saldo insuficiente para realizar sangria.");
            }

            if (_Obrigatorio && (Parametros.Parametros.ParametrosAplicacao.ValorRealizarSangria < (_Saldo - Convert.ToDecimal(txtValor.Text))))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Valor sangria insuficiente.");
            }

            ContratoServico.Venda.RegistrarSangria.PeticaoRegistrarSangria Peticao = new ContratoServico.Venda.RegistrarSangria.PeticaoRegistrarSangria()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Sangria = new Comum.Clases.Sangria()
            };

            Peticao.Sangria.IdentificadorResponsavelCaixa = _IdentificadorResponsavelCaixa;
            Peticao.Sangria.IdentificadorSupervisor = _IdentificadorSupervisor;
            Peticao.Sangria.Observacao = txtObservacao.Text.Trim();
            Peticao.Sangria.Valor = Convert.ToDecimal(txtValor.Text.Trim());

            Agente.Agente.InvocarServico<ContratoServico.Venda.RegistrarSangria.RespostaRegistrarSangria, ContratoServico.Venda.RegistrarSangria.PeticaoRegistrarSangria>(Peticao,
                  SDK.Operacoes.operacao.RegistrarSangria, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        private void ExecutarGravarSuprimento()
        {
            if (string.IsNullOrEmpty(txtObservacao.Text.Trim()))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Observação Obrigatória.");
            }

            if (string.IsNullOrEmpty(txtValor.Text.Trim()) || Convert.ToDecimal(txtValor.Text) == 0)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório informar um valor.");
            }

            ContratoServico.Venda.RegistrarSuprimento.PeticaoRegistrarSuprimento Peticao = new ContratoServico.Venda.RegistrarSuprimento.PeticaoRegistrarSuprimento()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Suprimento = new Comum.Clases.Suprimento()
            };

            Peticao.Suprimento.IdentificadorResponsavelCaixa = _IdentificadorResponsavelCaixa;
            Peticao.Suprimento.IdentificadorSupervisor = _IdentificadorSupervisor;
            Peticao.Suprimento.Observacao = txtObservacao.Text.Trim();
            Peticao.Suprimento.Valor = Convert.ToDecimal(txtValor.Text.Trim());

            Agente.Agente.InvocarServico<ContratoServico.Venda.RegistrarSuprimento.RespostaRegistrarSuprimento, ContratoServico.Venda.RegistrarSuprimento.PeticaoRegistrarSuprimento>(Peticao,
                  SDK.Operacoes.operacao.RegistrarSuprimento, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        #endregion

        #region "Eventos"


        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {
                if (TipoSaldoCaixa == Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria)
                    ExecutarGravarSangria();
                else
                    ExecutarGravarSuprimento();

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

        #endregion

        private void textBox1_Enter(object sender, EventArgs e)
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

        private void GuardarSangria_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Obrigatorio && !_SangriaEfetuada && TipoSaldoCaixa == Comum.Enumeradores.Enumeradores.TipoSaldoCaixa.Sangria)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
