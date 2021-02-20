using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class AlterarSenha : TelaBase.BaseCE
    {

        private Boolean _SolicitarUsuarioAlterarSenha;
        private string _Identificador;
        private Boolean _FechaTela = false;

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        public AlterarSenha(string Identificador, Boolean SolicitarUsuarioAlterarSenha)
        {
            InitializeComponent();

            _SolicitarUsuarioAlterarSenha = SolicitarUsuarioAlterarSenha;
            _Identificador = Identificador;

            _FechaTela = true;
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnLogar_Click), Keys.F2, false, false, false);

            if (!_SolicitarUsuarioAlterarSenha)
            {
                _FechaTela = false;
                base.MontarMenu(GerarGrupo, false);
            }
            else
            {
                base.MontarMenu(GerarGrupo);
            }

        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tableLayoutPanel3);
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

        private void ExecutarGravar()
        {

            if (string.IsNullOrEmpty(txtNovaSenha.Text.Trim()))
            {
                Aplicacao.Classes.Util.ExibirMensagemErro("Favor informar a senha.");
                txtNovaSenha.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtConfirmarSenha.Text.Trim()))
            {
                Aplicacao.Classes.Util.ExibirMensagemErro("Favor informar a confirmação da senha.");
                txtConfirmarSenha.Focus();
                return;
            }

            if (!txtNovaSenha.Text.Equals(txtConfirmarSenha.Text))
            {
                Aplicacao.Classes.Util.ExibirMensagemErro("Os campos senha e confirmar senha são diferentes.");
                txtNovaSenha.Focus();
                return;
            }

            ContratoServico.Pessoa.TrocarSenhaPessoa.PeticaoTrocarSenhaPessoa Peticao = new ContratoServico.Pessoa.TrocarSenhaPessoa.PeticaoTrocarSenhaPessoa()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Identificador = _Identificador,
                SolicitarTrocarSenha = _SolicitarUsuarioAlterarSenha,
                Senha = txtNovaSenha.Text.Trim()
            };

            Agente.Agente.InvocarServico<ContratoServico.Pessoa.TrocarSenhaPessoa.RespostaTrocarSenhaPessoa, ContratoServico.Pessoa.TrocarSenhaPessoa.PeticaoTrocarSenhaPessoa>(Peticao,
                  SDK.Operacoes.operacao.TrocarSenhaPessoa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

          
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.TrocarSenhaPessoa)
            {

                base.objNotificacao.ExibirMensagem("Cor deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);

                Aplicacao.Classes.Util.ExibirMensagemSucesso("Senha alterada com sucesso.");

                _FechaTela = true;
                this.Close();

            }


        }

        private void btnLogar_Click(object sender, EventArgs e)
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void AlterarSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!_FechaTela)
                {

                    Aplicacao.Classes.Util.ExibirMensagemErro("Janela não pode ser fechada, é obrigatório alterar a senha.");
                    e.Cancel = true;
                }


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }

        }

        
    }
}
