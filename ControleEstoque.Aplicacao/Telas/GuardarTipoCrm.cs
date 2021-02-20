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
    public partial class GuardarTipoCrm : Telas.TelaBase.BaseCE
    {

        #region"Variaveis"

        private string _IdentificadorTipoCrm;
        private Comum.Clases.TipoCrm objTipoCrm;
        private List<Comum.Clases.StatusCrmAgrupador> _objStatusCrmAgrupador;
        private Comum.Clases.StatusCrmAgrupador _objStatusCrmAgrupSelecionado;
        private ContratoServico.TipoCrm.SetTipoCrm.PeticaoSetTipoCrm PeticaoGravar = new ContratoServico.TipoCrm.SetTipoCrm.PeticaoSetTipoCrm();
        #endregion


        public GuardarTipoCrm(string IdentificadorTipoCrm)
        {
            InitializeComponent();

            _IdentificadorTipoCrm = IdentificadorTipoCrm;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnInserir = "btnInserir";
        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir Configuração (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpPrincipal);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarTipoEmpregado();
        }

        private void CarregarConfiguracao()
        {
            dgvMarcas.Rows.Clear();

            if (objTipoCrm != null && objTipoCrm.TiposCrmConfig != null && objTipoCrm.TiposCrmConfig.Count > 0)
            {

                objTipoCrm.TiposCrmConfig = objTipoCrm.TiposCrmConfig.OrderBy(tc => tc.Nivel).ToList();

                foreach (Comum.Clases.TipoCrmConfig tc in objTipoCrm.TiposCrmConfig)
                {
                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Name].Value = tc.Identificador;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colNivel.Name].Value = tc.Nivel;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricaoAtendimento.Name].Value = tc.DescricaoNivel;

                }
            }

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarTipoCrm)
            {
                objTipoCrm = ((ContratoServico.Telas.GuardarTipoCrm.Carregar.RespostaGuardarTipoCrmCarregar)objSaida).TipoCrm;
                _objStatusCrmAgrupador = ((ContratoServico.Telas.GuardarTipoCrm.Carregar.RespostaGuardarTipoCrmCarregar)objSaida).StatusAgrupador;

                PreencherControles();


            }
            else if (operacao == SDK.Operacoes.operacao.SetTipoCrm)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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


        private void RecuperarTipoEmpregado()
        {

            ContratoServico.Telas.GuardarTipoCrm.Carregar.PeticaoGuardarTipoCrmCarregar Peticao = new ContratoServico.Telas.GuardarTipoCrm.Carregar.PeticaoGuardarTipoCrmCarregar();
            Peticao.IdentificadorTipoCrm = _IdentificadorTipoCrm;
            Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarTipoCrm.Carregar.RespostaGuardarTipoCrmCarregar, ContratoServico.Telas.GuardarTipoCrm.Carregar.PeticaoGuardarTipoCrmCarregar>(Peticao,
                SDK.Operacoes.operacao.CarregarGuardarTipoCrm, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);


        }

        private void PreencherControles()
        {

            if (_objStatusCrmAgrupador != null && _objStatusCrmAgrupador.Count > 0)
            {


                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_objStatusCrmAgrupador.OrderBy(s=> s.Descricao).ToList(), "Identificador", "Descricao");

                cmbTipoStatus = frmWindows.Util.PreencherCombobox(cmbTipoStatus, Items);
                cmbStatusPadrao.Enabled = false;
            }
            else
            {
                cmbTipoStatus.Enabled = false;
                cmbStatusPadrao.Enabled = false;
            }

            if (objTipoCrm != null)
            {

                txtNome.Text = objTipoCrm.Descricao;
                txtCodigo.Text = objTipoCrm.Codigo;

                if (!string.IsNullOrEmpty(objTipoCrm.IdentificadorStatusCrmAgrup))
                {
                    cmbTipoStatus = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbTipoStatus, objTipoCrm.IdentificadorStatusCrmAgrup, "Identificador"));
                }

                if (!string.IsNullOrEmpty(objTipoCrm.IdentificadorStatusPadrao))
                {
                    cmbStatusPadrao = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbStatusPadrao, objTipoCrm.IdentificadorStatusPadrao, "Identificador"));
                }

                CarregarConfiguracao();
            }
        }

        private void ExecutarGravar()
        {
            try
            {
                PeticaoGravar = new ContratoServico.TipoCrm.SetTipoCrm.PeticaoSetTipoCrm();

                PeticaoGravar.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;


                Comum.Clases.StatusCrm objStatusGravar = null;

                if (_objStatusCrmAgrupSelecionado != null && _objStatusCrmAgrupSelecionado.StatusCrms != null && _objStatusCrmAgrupSelecionado.StatusCrms.Count > 0)
                {
                    objStatusGravar = (Comum.Clases.StatusCrm)(frmWindows.Util.RecuperarItemSelecionado(cmbStatusPadrao, _objStatusCrmAgrupSelecionado.StatusCrms, "Identificador"));
                }

                PeticaoGravar.TipoCrm = new Comum.Clases.TipoCrm()
                {

                    Descricao = txtNome.Text.Trim(),
                    Codigo = txtCodigo.Text.Trim(),
                    Identificador = _IdentificadorTipoCrm,
                    IdentificadorStatusCrmAgrup = (_objStatusCrmAgrupSelecionado != null ? _objStatusCrmAgrupSelecionado.Identificador : null),
                    IdentificadorStatusPadrao = (objStatusGravar != null ? objStatusGravar.Identificador : null),
                    TiposCrmConfig = (objTipoCrm != null ? objTipoCrm.TiposCrmConfig : null)

                };
                PeticaoGravar.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.TipoCrm.SetTipoCrm.RespostaSetTipoCrm, ContratoServico.TipoCrm.SetTipoCrm.PeticaoSetTipoCrm>(PeticaoGravar, SDK.Operacoes.operacao.SetTipoCrm, null, null, true);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            Comum.Clases.TipoCrmConfig objConfig = (from Comum.Clases.TipoCrmConfig tc in objTipoCrm.TiposCrmConfig
                                                    where tc.Identificador == Identificador.Value
                                                    select tc).FirstOrDefault();

            GuardarTipoCrmConfig frmCores = new GuardarTipoCrmConfig(objConfig);

            if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
            {
                if (frmCores.TipoCrmConfig != null)
                {
                    objConfig.DescricaoNivel = frmCores.TipoCrmConfig.DescricaoNivel;
                    objConfig.EmpregadoAtual = frmCores.TipoCrmConfig.EmpregadoAtual;
                    objConfig.Pessoas = frmCores.TipoCrmConfig.Pessoas;
                    objConfig.QuantidadeDiasData = frmCores.TipoCrmConfig.QuantidadeDiasData;
                    objConfig.QuantidadeEmpregados = frmCores.TipoCrmConfig.QuantidadeEmpregados;
                    objConfig.TipoEmpregado = frmCores.TipoCrmConfig.TipoEmpregado;
                }

                CarregarConfiguracao();
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            if (MessageBox.Show("Deseja excluir o registro?", "I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objTipoCrm.TiposCrmConfig.RemoveAll(tc => tc.Identificador == Identificador.Value);
                CarregarConfiguracao();
            }
            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region "Eventos"

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {

                Int32 NelNivel = 1;

                if (objTipoCrm != null && objTipoCrm.TiposCrmConfig != null && objTipoCrm.TiposCrmConfig.Count > 0)
                {
                    NelNivel = objTipoCrm.TiposCrmConfig.Count + 1;
                }
                GuardarTipoCrmConfig frmTipoCrmConfig = new GuardarTipoCrmConfig(new Comum.Clases.TipoCrmConfig() { Nivel = NelNivel });

                if (AbrirFormulario(frmTipoCrmConfig) == DialogResult.OK)
                {
                    if (objTipoCrm == null)
                    {
                        objTipoCrm = new Comum.Clases.TipoCrm();
                        objTipoCrm.TiposCrmConfig = new List<Comum.Clases.TipoCrmConfig>();
                    }

                    objTipoCrm.TiposCrmConfig.Add(frmTipoCrmConfig.TipoCrmConfig);
                    CarregarConfiguracao();

                }
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
                ExecutarGravar();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                Comum.Clases.TipoCrmConfig objConfig = (from Comum.Clases.TipoCrmConfig tc in objTipoCrm.TiposCrmConfig
                                                                        where tc.Identificador == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string
                                                                        select tc).FirstOrDefault();

                                GuardarTipoCrmConfig frmCores = new GuardarTipoCrmConfig(objConfig);

                                if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frmCores.TipoCrmConfig != null)
                                    {
                                        objConfig.DescricaoNivel = frmCores.TipoCrmConfig.DescricaoNivel;
                                        objConfig.EmpregadoAtual = frmCores.TipoCrmConfig.EmpregadoAtual;
                                        objConfig.Pessoas = frmCores.TipoCrmConfig.Pessoas;
                                        objConfig.QuantidadeDiasData = frmCores.TipoCrmConfig.QuantidadeDiasData;
                                        objConfig.QuantidadeEmpregados = frmCores.TipoCrmConfig.QuantidadeEmpregados;
                                        objConfig.TipoEmpregado = frmCores.TipoCrmConfig.TipoEmpregado;
                                    }

                                    CarregarConfiguracao();
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                if (MessageBox.Show("Deseja excluir o registro?", "I - GERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    objTipoCrm.TiposCrmConfig.RemoveAll(tc => tc.Identificador == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);
                                    CarregarConfiguracao();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvMarcas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {
                            //Define o cursor para Hand
                            Cursor.Current = Cursors.Hand;
                        }
                        else
                        {
                            //Define o cursor para default
                            Cursor.Current = Cursors.Default;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnAcima_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0 && dgvMarcas.SelectedRows != null && dgvMarcas.SelectedRows.Count > 0 && objTipoCrm != null &&
                    objTipoCrm.TiposCrmConfig != null && objTipoCrm.TiposCrmConfig.Count > 0)
                {
                    Int32 Index = dgvMarcas.SelectedRows[0].Cells[colIdCor.Index].RowIndex;

                    if (Index > 0)
                    {
                        Comum.Clases.TipoCrmConfig objTipoCrmConfig = objTipoCrm.TiposCrmConfig[Index];

                        Comum.Clases.TipoCrmConfig objTipoCrmConfigAnterior = objTipoCrm.TiposCrmConfig[Index - 1];

                        objTipoCrm.TiposCrmConfig.RemoveAll(tc => tc.Identificador == objTipoCrmConfig.Identificador);
                        objTipoCrm.TiposCrmConfig.RemoveAll(tc => tc.Identificador == objTipoCrmConfigAnterior.Identificador);

                        objTipoCrmConfig.Nivel -= 1;
                        objTipoCrmConfigAnterior.Nivel += 1;


                        objTipoCrm.TiposCrmConfig.Insert((Index - 1), objTipoCrmConfig);
                        objTipoCrm.TiposCrmConfig.Insert(Index, objTipoCrmConfigAnterior);


                        CarregarConfiguracao();

                        dgvMarcas.Rows[Index - 1].Selected = true;
                    }
                }
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

        private void btnAbaixo_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvMarcas.RowCount > 0 && dgvMarcas.SelectedRows != null && dgvMarcas.SelectedRows.Count > 0 && objTipoCrm != null &&
                     objTipoCrm.TiposCrmConfig != null && objTipoCrm.TiposCrmConfig.Count > 0)
                {
                    Int32 Index = dgvMarcas.SelectedRows[0].Cells[colIdCor.Index].RowIndex;

                    if (Index < objTipoCrm.TiposCrmConfig.Count - 1)
                    {
                        Comum.Clases.TipoCrmConfig objTipoCrmConfig = objTipoCrm.TiposCrmConfig[Index];

                        Comum.Clases.TipoCrmConfig objTipoCrmConfigAnterior = objTipoCrm.TiposCrmConfig[Index + 1];

                        objTipoCrm.TiposCrmConfig.RemoveAll(tc => tc.Identificador == objTipoCrmConfig.Identificador);
                        objTipoCrm.TiposCrmConfig.RemoveAll(tc => tc.Identificador == objTipoCrmConfigAnterior.Identificador);

                        objTipoCrmConfig.Nivel += 1;
                        objTipoCrmConfigAnterior.Nivel -= 1;


                        objTipoCrm.TiposCrmConfig.Insert(Index, objTipoCrmConfigAnterior);
                        objTipoCrm.TiposCrmConfig.Insert((Index + 1), objTipoCrmConfig);


                        CarregarConfiguracao();

                        dgvMarcas.Rows[Index + 1].Selected = true;
                    }
                }
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

        private void cmbTipoStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbTipoStatus.SelectedItem != null)
                {
                    _objStatusCrmAgrupSelecionado = (Comum.Clases.StatusCrmAgrupador)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoStatus, _objStatusCrmAgrupador, "Identificador"));

                    if (_objStatusCrmAgrupSelecionado != null && _objStatusCrmAgrupSelecionado.StatusCrms != null && _objStatusCrmAgrupSelecionado.StatusCrms.Count > 0)
                    {
                        if (cmbStatusPadrao.Items != null) { cmbStatusPadrao.Items.Clear(); }

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_objStatusCrmAgrupSelecionado.StatusCrms.OrderBy(s => s.Descricao).ToList(), "Identificador", "Descricao");

                        cmbStatusPadrao = frmWindows.Util.PreencherCombobox(cmbStatusPadrao, Items);

                        cmbStatusPadrao.Enabled = true;

                    }
                    else
                    {
                        cmbStatusPadrao.Enabled = false;
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
