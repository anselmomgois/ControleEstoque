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
    public partial class GuardarIntegracaoAPI : TelaBase.BaseCE
    {
        public GuardarIntegracaoAPI(string IdentificadorAPI)
        {
            InitializeComponent();
            this.pnlBase.Controls.Add(tlpPrincipal);
            _identificadorAPI = IdentificadorAPI;
        }

        #region "Variaveis"
        private string _identificadorAPI;
        private Comum.Clases.IntegracaoAPI _objIntegracaoAPI;
        private List<Classes.ValorDescricao> _tiposIntegracoes;
        private List<Comum.Clases.TipoCrm> _tiposCRM;
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
            _tiposIntegracoes = new List<Classes.ValorDescricao>();
            _tiposIntegracoes.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoIntegracao.SHORT.RecuperarValor(),
                Descricao = "SHORT"
            });
            _tiposIntegracoes.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoIntegracao.SHORT2.RecuperarValor(),
                Descricao = "SHORT 2"
            });
            _tiposIntegracoes.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoIntegracao.SMS.RecuperarValor(),
                Descricao = "SMS"
            });
            _tiposIntegracoes.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.TipoIntegracao.ZERO800.RecuperarValor(),
                Descricao = "0800"
            });

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_tiposIntegracoes, "Identificador", "Descricao");

            cmbTipo = frmWindows.Util.PreencherCombobox(cmbTipo, Items);

            // buscar os tipos de crm
            ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.PeticaoGuardarIntegracaoAPICarregar PeticaoPesquisarTipoCRM = new ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.PeticaoGuardarIntegracaoAPICarregar()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                IdentificadorAPI = _identificadorAPI
            };

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.RespostaGuardarIntegracaoAPICarregar, ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.PeticaoGuardarIntegracaoAPICarregar>(PeticaoPesquisarTipoCRM,
                  SDK.Operacoes.operacao.CarregarGuardarIntegracaoAPI, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

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

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarIntegracaoAPI)
            {
                var objSaidaConvertido = ((ContratoServico.Telas.GuardarIntegracaoAPI.Carregar.RespostaGuardarIntegracaoAPICarregar)objSaida);

                _objIntegracaoAPI = objSaidaConvertido.IntegracaoAPI;
                _tiposCRM = objSaidaConvertido.TiposCrm;

                PreencherComboTiposCRM();
                PreencherControles();

            }
            else if (operacao == SDK.Operacoes.operacao.SetIntegracaoAPI)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void PreencherControles()
        {
            if (_objIntegracaoAPI != null)
            {
                if (_objIntegracaoAPI.IdentificadorTipoCRM != null)
                {
                    cmbTipoCRM = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbTipoCRM, _objIntegracaoAPI.IdentificadorTipoCRM, "Identificador"));
                }
                txtUrl.Text = _objIntegracaoAPI.Url;
                if (_objIntegracaoAPI.TipoIntegracao != null)
                {
                    cmbTipo = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbTipo, _objIntegracaoAPI.TipoIntegracao.RecuperarValor(), "Identificador"));
                }
            }
        }

        private void PreencherComboTiposCRM()
        {

            if (_tiposCRM != null && _tiposCRM.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_tiposCRM, "Identificador", "Descricao");

                cmbTipoCRM = frmWindows.Util.PreencherCombobox(cmbTipoCRM, Items);

            }
        }
        #endregion

        #region "Eventos"
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_objIntegracaoAPI == null) { _objIntegracaoAPI = new Comum.Clases.IntegracaoAPI(); }

                if (cmbTipoCRM.SelectedItem != null)
                {
                    _objIntegracaoAPI.IdentificadorTipoCRM = ((Comum.Clases.TipoCrm)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoCRM, _tiposCRM, "Identificador"))).Identificador;
                }

                _objIntegracaoAPI.Url = txtUrl.Text;
                if (cmbTipo.SelectedItem != null)
                {
                    _objIntegracaoAPI.TipoIntegracao = Comum.Extencoes.EnumExtension.RecuperarEnum<Comum.Enumeradores.TipoIntegracao>(((Classes.ValorDescricao)(frmWindows.Util.RecuperarItemSelecionado(cmbTipo, _tiposIntegracoes, "Identificador"))).Identificador);
                }

                ContratoServico.IntegracaoAPI.SetIntegracaoAPI.PeticaoSetIntegracaoAPI Peticao = new ContratoServico.IntegracaoAPI.SetIntegracaoAPI.PeticaoSetIntegracaoAPI()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpesa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    IntegracaoAPI = _objIntegracaoAPI
                };

                Agente.Agente.InvocarServico<ContratoServico.IntegracaoAPI.SetIntegracaoAPI.RespostaSetIntegracaoAPI, ContratoServico.IntegracaoAPI.SetIntegracaoAPI.PeticaoSetIntegracaoAPI>(Peticao,
                      SDK.Operacoes.operacao.SetIntegracaoAPI, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion
    }
}
