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
    public partial class GuardarCaixa : TelaBase.BaseCE
    {

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorCaixa;
        private Comum.Clases.Caixa objCaixa;

        #endregion

        public GuardarCaixa(string identificadorCaixa)
        {
            InitializeComponent();
            _IdentificadorCaixa = identificadorCaixa;
        }

        #region "Metodos

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        private void CarregarTela()
        {

            RecuperarCaixaDetalhe();
        }

        private void RecuperarCaixaDetalhe()
        {

            if (!string.IsNullOrEmpty(_IdentificadorCaixa))
            {
                ContratoServico.Caixa.BuscarCaixaDetalhe.PeticaoBuscarCaixaDetalhe Peticao = new ContratoServico.Caixa.BuscarCaixaDetalhe.PeticaoBuscarCaixaDetalhe();
                Peticao.IdentificadorCaixa = _IdentificadorCaixa;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Caixa.BuscarCaixaDetalhe.RespostaBuscarCaixaDetalhe, ContratoServico.Caixa.BuscarCaixaDetalhe.PeticaoBuscarCaixaDetalhe>(Peticao,
                    SDK.Operacoes.operacao.BuscarCaixaDetalhe, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
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

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscarCaixaDetalhe)
            {
                objCaixa = ((ContratoServico.Caixa.BuscarCaixaDetalhe.RespostaBuscarCaixaDetalhe)objSaida).Caixa;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    PreencherControles();
                }

            }
            else if (operacao == SDK.Operacoes.operacao.SetCaixa)
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
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O código do Caixa é obrigatório.");
            }

            if (string.IsNullOrEmpty(txtHostName.Text))
            {
                txtHostName.Focus();
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O Host da máquina é obrigatório.");
            }

            ContratoServico.Caixa.SetCaixa.PeticaoSetCaixa Peticao = new ContratoServico.Caixa.SetCaixa.PeticaoSetCaixa();

            Peticao.Caixa = new Comum.Clases.Caixa();

            Peticao.Caixa.Identificador = _IdentificadorCaixa;
            Peticao.Caixa.Codigo = int.Parse(txtCodigo.Text);
            Peticao.Caixa.EstaAberto = (objCaixa != null ? objCaixa.EstaAberto : false);
            Peticao.Caixa.HostName = txtHostName.Text;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;

            Agente.Agente.InvocarServico<ContratoServico.Caixa.SetCaixa.RespostaSetCaixa, ContratoServico.Caixa.SetCaixa.PeticaoSetCaixa>(Peticao, SDK.Operacoes.operacao.SetCaixa, null, null, true);

        }

        private void PreencherControles()
        {

            if (objCaixa != null)
            {

                txtCodigo.Text = objCaixa.Codigo.ToString();
                txtHostName.Text = objCaixa.HostName;
            }
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            CarregarTela();
            this.pnlBase.Controls.Add(tableLayoutPanel2);
            base.Inicializar();
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion


    }
}
