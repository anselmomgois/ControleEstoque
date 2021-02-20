using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Aplicacao.Classes;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarTipoCrmConfig : Telas.TelaBase.BaseCE
    {

        #region"Variaveis"

        private Comum.Clases.TipoCrmConfig objTipoCrm;
        private List<Comum.Clases.TipoEmpregado> objTipoEmpregado;
        private List<Comum.Clases.Pessoa> Funcionarios;
        private Boolean ExecutandoCheckBox;
        private Boolean ExecutandoCarregamentoTela;
        #endregion

        #region "Propriedades"
        public Comum.Clases.TipoCrmConfig TipoCrmConfig
        {
            get
            {
                return objTipoCrm;
            }
        }
        #endregion


        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion


        public GuardarTipoCrmConfig(Comum.Clases.TipoCrmConfig TipoCrmConfig)
        {
            InitializeComponent();

            objTipoCrm = TipoCrmConfig;
        }

        #region "Metodos"


        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tableLayoutPanel1);
            CarregarTela();
            base.Inicializar();
        }

        private void RecuperarDados()
        {
            ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.PeticaoGuardarTipoCrmConfigCarregar Peticao = new ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.PeticaoGuardarTipoCrmConfigCarregar();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.RespostaGuardarTipoCrmConfigCarregar, ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.PeticaoGuardarTipoCrmConfigCarregar>(Peticao, SDK.Operacoes.operacao.CarregarGuardarTipoCrmConfig,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = false,
                    PreencherObjeto = true
                }, null, true);
        }

        private void CarregarTela()
        {

            RecuperarDados();
        }


        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarTipoCrmConfig)
            {
                ExecutandoCarregamentoTela = true;

                ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.RespostaGuardarTipoCrmConfigCarregar objSaidaConvertido = (ContratoServico.Telas.GuardarTipoCrmConfig.Carregar.RespostaGuardarTipoCrmConfigCarregar)objSaida;

                objTipoEmpregado = objSaidaConvertido.TiposEmpregado;
                Funcionarios = objSaidaConvertido.Funcionarios;

                if (objTipoEmpregado != null && objTipoEmpregado.Count > 0)
                {
                    objTipoEmpregado.Insert(0, new Comum.Clases.TipoEmpregado { Descricao = "Selecione" });
                }

                cmbTipoEmpregado.Items.Clear();

                List<frmWindows.Item> ItemsTipoEmpregados = frmWindows.Util.ConverterItems(objTipoEmpregado, "Identificador", "Descricao");
                cmbTipoEmpregado = frmWindows.Util.PreencherCombobox(cmbTipoEmpregado, ItemsTipoEmpregados);

                if (Funcionarios == null || Funcionarios.Count == 0)
                {
                    lstFuncionarios.Enabled = false;
                }
                else
                {
                    List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Funcionarios.OrderBy(f=> f.DesNome).ToList(), "Identificador", "DesNome");
                    lstFuncionarios = frmWindows.Util.PreencherListBox(lstFuncionarios, Items);
                    txtQuantidadeFuncionarios.Maximum = Funcionarios.Count;
                }

                PreencherControles();

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

            if (ExecutandoCarregamentoTela)
            {

                ConfigurarVisualizacaoTela();
                ExecutandoCarregamentoTela = false;
            }

        }


        private void PreencherControles()
        {

            if (objTipoCrm != null)
            {

                txtNome.Text = objTipoCrm.DescricaoNivel;
                txtNivel.Text = objTipoCrm.Nivel.ToString();
                txtQuantidadeDias.Value = objTipoCrm.QuantidadeDiasData;
                txtQuantidadeFuncionarios.Value = objTipoCrm.QuantidadeEmpregados;

                if (objTipoCrm.Pessoas != null && objTipoCrm.Pessoas.Count > 0)
                {
                    lstFuncionarios = (ListBox)(frmWindows.Util.SelecionarItemControle(lstFuncionarios, string.Empty, "Identificador", objTipoCrm.Pessoas));
                }

                if (objTipoCrm.TipoEmpregado != null)
                {
                    cmbTipoEmpregado = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbTipoEmpregado, objTipoCrm.TipoEmpregado.Identificador, "Identificador"));
                }

                chkFuncionarioAnterior.Checked = objTipoCrm.EmpregadoAtual;
            }
        }

        private void ConfigurarVisualizacaoTela()
        {
            if (chkFuncionarioAnterior.Checked)
            {
                lstFuncionarios.Enabled = !chkFuncionarioAnterior.Checked;
                txtQuantidadeFuncionarios.Enabled = !chkFuncionarioAnterior.Checked;
                cmbTipoEmpregado.Enabled = !chkFuncionarioAnterior.Checked;
                lstFuncionarios.ClearSelected();
                cmbTipoEmpregado.SelectedIndex = 0;
                txtQuantidadeFuncionarios.Value = 0;
            }
            else if (objTipoCrm.TipoEmpregado != null && !string.IsNullOrEmpty(objTipoCrm.TipoEmpregado.Identificador))
            {
                lstFuncionarios.Enabled = !(cmbTipoEmpregado.SelectedItem != null && cmbTipoEmpregado.SelectedIndex != 0);
                lstFuncionarios.ClearSelected();
                chkFuncionarioAnterior.Checked = false;
                chkFuncionarioAnterior.Enabled = !(cmbTipoEmpregado.SelectedItem != null && cmbTipoEmpregado.SelectedIndex != 0);
            }
            else if (objTipoCrm.Pessoas != null && objTipoCrm.Pessoas.Count > 0)
            {
                if (lstFuncionarios.SelectedItems != null && lstFuncionarios.SelectedItems.Count > 0)
                {
                    cmbTipoEmpregado.SelectedItem = null;
                    cmbTipoEmpregado.Enabled = false;
                    txtQuantidadeFuncionarios.Value = 0;
                    txtQuantidadeFuncionarios.Enabled = false;
                    chkFuncionarioAnterior.Checked = false;
                    chkFuncionarioAnterior.Enabled = false;
                }
                else
                {
                    cmbTipoEmpregado.Enabled = true;
                    txtQuantidadeFuncionarios.Enabled = true;
                    chkFuncionarioAnterior.Enabled = true;

                }
            }
        }

        private void ExecutarGravar()
        {

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A descrição é obrigatória.");
            }

            if (!chkFuncionarioAnterior.Checked)
            {
                if (lstFuncionarios.SelectedItem == null && cmbTipoEmpregado.SelectedItem == null)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor escolher o tipo de funcinário ou os funcionários responsáveis.");
                }

                if (lstFuncionarios.SelectedItem == null && txtQuantidadeFuncionarios.Value == 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor a quantidade de funcionários.");
                }
            }

            if (txtQuantidadeDias.Value == 0)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor escolher a quantidade de dias.");
            }


            if (objTipoCrm == null) { objTipoCrm = new Comum.Clases.TipoCrmConfig(); }

            objTipoCrm.DescricaoNivel = txtNome.Text;
            if (string.IsNullOrEmpty(objTipoCrm.Identificador))
            {
                objTipoCrm.Identificador = Guid.NewGuid().ToString();
            }

            objTipoCrm.EmpregadoAtual = chkFuncionarioAnterior.Checked;
            objTipoCrm.QuantidadeDiasData = Convert.ToInt32(txtQuantidadeDias.Value);
            objTipoCrm.QuantidadeEmpregados = Convert.ToInt32(txtQuantidadeFuncionarios.Value);
            objTipoCrm.Pessoas = (List<Comum.Clases.Pessoa>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Pessoa>(lstFuncionarios, Funcionarios, "Identificador"));
            objTipoCrm.TipoEmpregado = (Comum.Clases.TipoEmpregado)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoEmpregado, objTipoEmpregado, "Identificador"));

            if (objTipoCrm.TipoEmpregado != null && string.IsNullOrEmpty(objTipoCrm.TipoEmpregado.Identificador))
            {
                objTipoCrm.TipoEmpregado = null;
            }

            DialogResult = DialogResult.OK;
            Close();
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


        private void chkFuncionarioAnterior_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ExecutandoCarregamentoTela)
                {
                    ExecutandoCheckBox = true;

                    lstFuncionarios.Enabled = !chkFuncionarioAnterior.Checked;
                    txtQuantidadeFuncionarios.Enabled = !chkFuncionarioAnterior.Checked;
                    cmbTipoEmpregado.Enabled = !chkFuncionarioAnterior.Checked;
                    lstFuncionarios.ClearSelected();
                    cmbTipoEmpregado.SelectedIndex = 0;
                    txtQuantidadeFuncionarios.Value = 0;

                    ExecutandoCheckBox = false;
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void cmbTipoEmpregado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ExecutandoCheckBox && !ExecutandoCarregamentoTela)
                {
                    lstFuncionarios.Enabled = !(cmbTipoEmpregado.SelectedItem != null && cmbTipoEmpregado.SelectedIndex != 0);
                    lstFuncionarios.ClearSelected();
                    chkFuncionarioAnterior.Checked = false;
                    chkFuncionarioAnterior.Enabled = !(cmbTipoEmpregado.SelectedItem != null && cmbTipoEmpregado.SelectedIndex != 0);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void lstFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ExecutandoCheckBox && !ExecutandoCarregamentoTela)
                {
                    if (lstFuncionarios.SelectedItems != null && lstFuncionarios.SelectedItems.Count > 0)
                    {
                        cmbTipoEmpregado.SelectedItem = null;
                        cmbTipoEmpregado.Enabled = false;
                        txtQuantidadeFuncionarios.Value = 0;
                        txtQuantidadeFuncionarios.Enabled = false;
                        chkFuncionarioAnterior.Checked = false;
                        chkFuncionarioAnterior.Enabled = false;
                    }
                    else
                    {
                        cmbTipoEmpregado.Enabled = true;
                        txtQuantidadeFuncionarios.Enabled = true;
                        chkFuncionarioAnterior.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion
    }
}
