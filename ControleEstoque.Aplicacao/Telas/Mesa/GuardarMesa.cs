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
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarMesa : TelaBase.BaseCE
    {
        public GuardarMesa(string IdentificadorMesa)
        {
            InitializeComponent();
            _identificadorMesa = IdentificadorMesa;
        }

        #region "Variaveis"
        private string _identificadorMesa;
        private Comum.Clases.Mesa _objMesa;
        private List<Comum.Clases.MesaProxima> _objMesas;
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

            ContratoServico.Telas.GuardarMesa.Carregar.PeticaoGuardarMesaCarregar Peticao = new ContratoServico.Telas.GuardarMesa.Carregar.PeticaoGuardarMesaCarregar()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorMesa = _identificadorMesa,
                IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarMesa.Carregar.RespostaGuardarMesaCarregar, ContratoServico.Telas.GuardarMesa.Carregar.PeticaoGuardarMesaCarregar>(Peticao,
                  SDK.Operacoes.operacao.CarregarGuardarMesa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado, operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarMesa)
            {
                var objSaidaConvertido = ((ContratoServico.Telas.GuardarMesa.Carregar.RespostaGuardarMesaCarregar)objSaida);

                _objMesa = objSaidaConvertido.Mesa;
                _objMesas = objSaidaConvertido.Mesas;
                PreencherControles();

            }
            else if (operacao == SDK.Operacoes.operacao.SetMesa)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }


        private void PreencherMesas()
        {

            if (_objMesas != null && _objMesas.Count > 0)
            {
                lstMesas.Items.Clear();

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_objMesas, "Identificador", "Codigo");
                lstMesas = frmWindows.Util.PreencherListBox(lstMesas, Items);
            }
        }

        private void PreencherControles()
        {
            PreencherMesas();

            if (_objMesa != null)
            {
                txtCodigoMesa.Text = _objMesa.Codigo;
                txtQuantidadeLugares.Value = _objMesa.QuantidadeLugar;
                chkAtivo.Checked = _objMesa.Ativa;

                if (_objMesa.MesasProximas != null && _objMesa.MesasProximas.Count > 0)
                {
                    lstMesas = (ListBox)(frmWindows.Util.SelecionarItemControle(lstMesas, string.Empty, "Identificador", _objMesa.MesasProximas));
                }
            }
            else
            {
                chkAtivo.Checked = true;
                chkAtivo.Enabled = false;
            }
        }

        #endregion

        #region "Eventos"
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_objMesa == null) { _objMesa = new Comum.Clases.Mesa(); }


                _objMesa.Codigo = txtCodigoMesa.Text;
                _objMesa.QuantidadeLugar = Convert.ToInt32(txtQuantidadeLugares.Value);
                _objMesa.Ativa = chkAtivo.Checked;

                if (lstMesas.SelectedItems != null)
                {
                    _objMesa.MesasProximas = (List<Comum.Clases.MesaProxima>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.MesaProxima>(lstMesas, _objMesas, "Identificador"));
                }

                ContratoServico.Mesa.SetMesa.PeticaoSetMesa Peticao = new ContratoServico.Mesa.SetMesa.PeticaoSetMesa()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                    Mesa = _objMesa
                };

                Agente.Agente.InvocarServico<ContratoServico.Mesa.SetMesa.RespostaSetMesa, ContratoServico.Mesa.SetMesa.PeticaoSetMesa>(Peticao,
                      SDK.Operacoes.operacao.SetMesa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCodigoMesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion


    }
}
