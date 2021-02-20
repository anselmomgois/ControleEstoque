using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Comum.Extencoes;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarObservacao : TelaBase.BaseCE
    {
        public GuardarObservacao(string IdentificadorObsrvacao)
        {
            InitializeComponent();
            this.pnlBase.Controls.Add(tlpPrincipal);
            _identificadorObsrvacao = IdentificadorObsrvacao;
        }

        #region "Variaveis"
        private string _identificadorObsrvacao;
        private Comum.Clases.ProdutoObservacao _objObservacao;
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Metodos"
        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            CarregarTela();
            this.pnlBase.Controls.Add(tlpPrincipal);
            base.Inicializar();
        }

        private void CarregarTela()
        {

            if (!string.IsNullOrEmpty(_identificadorObsrvacao))
            {
                ContratoServico.Observacao.RecuperarObservacao.PeticaoRecuperarObservacao Peticao = new ContratoServico.Observacao.RecuperarObservacao.PeticaoRecuperarObservacao()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    Identificador = _identificadorObsrvacao
                };

                Agente.Agente.InvocarServico<ContratoServico.Observacao.RecuperarObservacao.RespostaRecuperarObservacao, ContratoServico.Observacao.RecuperarObservacao.PeticaoRecuperarObservacao>(Peticao,
                      SDK.Operacoes.operacao.RecuperarObservacao, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }
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

            if (operacao == SDK.Operacoes.operacao.RecuperarObservacao)
            {
                var objSaidaConvertido = ((ContratoServico.Observacao.RecuperarObservacao.RespostaRecuperarObservacao)objSaida);

                _objObservacao = objSaidaConvertido.Observacao;

                PreencherControles();

            }
            else if (operacao == SDK.Operacoes.operacao.SetObservacao)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void PreencherControles()
        {
            if (_objObservacao != null)
            {
                txtObservacao.Text = _objObservacao.Descricao;
            }
        }
 
        #endregion

        #region "Eventos"
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_objObservacao == null) { _objObservacao = new Comum.Clases.ProdutoObservacao(); }


                _objObservacao.Descricao = txtObservacao.Text;
                
                ContratoServico.Observacao.SetObservacao.PeticaoSetObservacao Peticao = new ContratoServico.Observacao.SetObservacao.PeticaoSetObservacao()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    Observacao = _objObservacao
                };

                Agente.Agente.InvocarServico<ContratoServico.Observacao.SetObservacao.RespostaSetObservacao, ContratoServico.Observacao.SetObservacao.PeticaoSetObservacao>(Peticao,
                      SDK.Operacoes.operacao.SetObservacao, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion
    }
}
