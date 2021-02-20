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
    public partial class GuardarProcesso : TelaBase.BaseCE
    {
        public GuardarProcesso(string IdentificadorProcesso)
        {
            InitializeComponent();
            this.pnlBase.Controls.Add(tlpPrincipal);
            _identificadorProcesso = IdentificadorProcesso;
        }

        #region "Variaveis"
        private string _identificadorProcesso;
        private Comum.Clases.Processo _objProcesso;
        private List<Classes.ValorDescricao> _tiposProcessos;
        private List<Comum.Clases.Processo> _tiposCRM;
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
            _tiposProcessos = new List<Classes.ValorDescricao>();
            _tiposProcessos.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoProcesso.API.RecuperarValor(),
                Descricao = "INTEGRAÇÃO API"
            });
            _tiposProcessos.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA.RecuperarValor(),
                Descricao = "ENVIAR EMAIL FECHAMENTO CAIXA"
            });

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_tiposProcessos, "Identificador", "Descricao");

            cmbTipoProcesso = frmWindows.Util.PreencherCombobox(cmbTipoProcesso, Items);

            if (!string.IsNullOrEmpty(_identificadorProcesso))
            {
                // buscar os tipos de crm
                ContratoServico.Processo.RecuperarProcesso.PeticaoRecuperarProcesso PeticaoPesquisarTipoCRM = new ContratoServico.Processo.RecuperarProcesso.PeticaoRecuperarProcesso()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorProcesso = _identificadorProcesso
                };

                Agente.Agente.InvocarServico<ContratoServico.Processo.RecuperarProcesso.RespostaRecuperarProcesso, ContratoServico.Processo.RecuperarProcesso.PeticaoRecuperarProcesso>(PeticaoPesquisarTipoCRM,
                      SDK.Operacoes.operacao.RecuperarProcesso, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }
            else
            {
                chkAtivo.Enabled = false;
                chkAtivo.Checked = true;
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

            if (operacao == SDK.Operacoes.operacao.RecuperarProcesso)
            {
                var objSaidaConvertido = ((ContratoServico.Processo.RecuperarProcesso.RespostaRecuperarProcesso)objSaida);

                _objProcesso = objSaidaConvertido.Processo;

                PreencherControles();

            }
            else if (operacao == SDK.Operacoes.operacao.SetProcesso)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void PreencherControles()
        {
            if (_objProcesso != null)
            {
                cmbTipoProcesso = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbTipoProcesso, _objProcesso.Tipo.RecuperarValor(), "Identificador"));               

                txtDescricao.Text = _objProcesso.Descricao;
                chkAtivo.Checked = _objProcesso.Ativo;
                nudIntervaloExecucao.Value = _objProcesso.IntervaloExecucao;
                nudQuantidadeTentativas.Value = _objProcesso.QuantidadeTentativas;
            }
            else
            {
                chkAtivo.Enabled = false;
                chkAtivo.Checked = true;
            }
        }
        #endregion

        #region "Eventos"
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_objProcesso == null) { _objProcesso = new Comum.Clases.Processo(); }

                
                _objProcesso.Descricao = txtDescricao.Text;
                _objProcesso.Ativo = chkAtivo.Checked;
                _objProcesso.IntervaloExecucao = Convert.ToInt32(nudIntervaloExecucao.Value);
                _objProcesso.QuantidadeTentativas = Convert.ToInt32(nudQuantidadeTentativas.Value);

                if (cmbTipoProcesso.SelectedItem != null)
                {
                    _objProcesso.Tipo = Comum.Extencoes.EnumExtension.RecuperarEnum<Comum.Enumeradores.TipoProcesso>(((Classes.ValorDescricao)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoProcesso, _tiposProcessos, "Identificador"))).Identificador);
                }

                ContratoServico.Processo.SetProcesso.PeticaoSetProcesso Peticao = new ContratoServico.Processo.SetProcesso.PeticaoSetProcesso()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    Processo = _objProcesso
                };

                Agente.Agente.InvocarServico<ContratoServico.Processo.SetProcesso.RespostaSetProcesso, ContratoServico.Processo.SetProcesso.PeticaoSetProcesso>(Peticao,
                      SDK.Operacoes.operacao.SetProcesso, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion
    }
}
