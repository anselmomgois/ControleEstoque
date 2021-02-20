using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarResposta : TelaBase.BaseCE
    {
        public GuardarResposta(Comum.Clases.Pergunta objPergunta)
        {
            InitializeComponent();

            _objPergunta = objPergunta;
           CarregarTela();
        }

        #region"Variaveis"

        private Comum.Clases.Pergunta _objPergunta = null;
        private TextBox objTextbox = null;
        private CheckBox objCheckbox = null;
        private ComboBox objComboBox = null;
        private RadioButton objRadioYes = null;
        private RadioButton objRadioNO = null;
        private string _Valor = string.Empty;

        #endregion

        #region "Propriedades"

        public string Valor
        {
            get
            {
                return _Valor;
            }
        }
        #endregion


        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
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
            this.pnlBase.Controls.Add(tlpPrincipal);
            base.Inicializar();
        }

        private void CarregarTela()
        {

            if (_objPergunta != null)
            {

                lblPergunta.Text = _objPergunta.DesPergunta;

                CriarControle();

            }
        }

        private void CriarControle()
        {

            switch (_objPergunta.TipoComponente)
            {
                case Comum.Enumeradores.Enumeradores.TipoComponente.CHECKBOX:

                    objCheckbox = new CheckBox();
                    objCheckbox.Anchor = AnchorStyles.None;
                    pnlControle.Controls.Add(objCheckbox);

                    if (!string.IsNullOrEmpty(_objPergunta.Resposta))
                    {

                        if (_objPergunta.Resposta == "1")
                        {
                            objCheckbox.Checked = true;
                        }
                        else
                        {
                            objCheckbox.Checked = false;
                        }
                    }

                    break;

                case Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX:

                    objComboBox = new ComboBox();
                    objComboBox.Dock = DockStyle.Fill;
                    objComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (_objPergunta.Opcoes != null && _objPergunta.Opcoes.Count > 0)
                    {
                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_objPergunta.Opcoes, "Identificador", "Descricao");
                        objComboBox = frmWindows.Util.PreencherCombobox(objComboBox, Items);
                    }
                    pnlControle.Controls.Add(objComboBox);

                    if (!string.IsNullOrEmpty(_objPergunta.Resposta))
                    {
                        objComboBox = (ComboBox)(frmWindows.Util.SelecionarItemControle(objComboBox, _objPergunta.Resposta, "Identificador"));
                    }

                    break;

                case Comum.Enumeradores.Enumeradores.TipoComponente.SIMONAO:

                    GroupBox objGroupBox = new GroupBox();
                    objGroupBox.Dock = DockStyle.Fill;
                    objGroupBox.Text = "Dados da Resposta";
                    objRadioYes = new RadioButton();
                    objRadioNO = new RadioButton();

                    Panel objPanelYes = new Panel();
                    Panel objPanelNo = new Panel();

                    objRadioYes.Text = "Sim";
                    objRadioNO.Text = "Não";

                    objRadioYes.CheckedChanged += objRadioYes_CheckedChanged;
                    objRadioNO.CheckedChanged += objRadioNO_CheckedChanged;

                    objRadioYes.Dock = DockStyle.None;
                    objRadioYes.Dock = DockStyle.Right;

                    objRadioNO.Dock = DockStyle.None;
                    objRadioNO.Dock = DockStyle.Left;

                    objPanelYes.Controls.Add(objRadioYes);
                    objPanelNo.Controls.Add(objRadioNO);

                    objPanelNo.Width = (pnlControle.Width / 2) - 10;
                    objPanelYes.Width = (pnlControle.Width / 2) - 10;

                    objPanelYes.Anchor = AnchorStyles.Left;
                    objPanelNo.Anchor = AnchorStyles.Right;
                    objPanelYes.Dock = DockStyle.Left;
                    objPanelNo.Dock = DockStyle.Right;

                    objGroupBox.Controls.Add(objPanelYes);
                    objGroupBox.Controls.Add(objPanelNo);

                    pnlControle.Controls.Add(objGroupBox);

                    if (!string.IsNullOrEmpty(_objPergunta.Resposta))
                    {

                        if (_objPergunta.Resposta == "Sim")
                        {
                            objRadioYes.Checked = true;
                        }
                        else
                        {
                            objRadioNO.Checked = true;
                        }
                    }

                    break;

                case Comum.Enumeradores.Enumeradores.TipoComponente.TEXTBOX:

                    objTextbox = new TextBox();
                    objTextbox.Dock = DockStyle.Fill;
                    objTextbox.Multiline = true;

                    pnlControle.Controls.Add(objTextbox);

                    objTextbox.Text = _objPergunta.Resposta;

                    if (_objPergunta.Numerico)
                    {
                        objTextbox.KeyPress += objTextBox_KeyPress;
                    }

                    break;
            }



        }
        #endregion

        private void objTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

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
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                switch (_objPergunta.TipoComponente)
                {
                    case Comum.Enumeradores.Enumeradores.TipoComponente.CHECKBOX:

                        if (objCheckbox.Checked)
                        {
                            _Valor = "1";
                        }
                        else
                        {
                            _Valor = "0";
                        }

                        break;

                    case Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX:

                        if (objComboBox.SelectedItem != null && _objPergunta.Opcoes != null && _objPergunta.Opcoes.Count > 0)
                        {
                            Comum.Clases.PerguntaOpcao objOpcao = (Comum.Clases.PerguntaOpcao)(frmWindows.Util.RecuperarItemSelecionado(objComboBox, _objPergunta.Opcoes, "Identificador"));

                            if (objOpcao != null)
                            {
                                _Valor = objOpcao.Identificador;
                            }
                        }


                        break;

                    case Comum.Enumeradores.Enumeradores.TipoComponente.SIMONAO:

                        if (objRadioYes.Checked)
                        {
                            _Valor = "Sim";
                        }
                        else if(objRadioNO.Checked)
                        {
                            _Valor = "Não";
                        }

                        break;

                    case Comum.Enumeradores.Enumeradores.TipoComponente.TEXTBOX:

                        _Valor = objTextbox.Text;

                        break;
                }

                if (string.IsNullOrEmpty(_Valor))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor informar a resposta");
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

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

        private void objRadioYes_CheckedChanged(object sender, EventArgs e)
        {
            objRadioNO.Checked = !objRadioYes.Checked;
        }

        private void objRadioNO_CheckedChanged(object sender, EventArgs e)
        {
            objRadioYes.Checked = !objRadioNO.Checked;
        }

    }
}
