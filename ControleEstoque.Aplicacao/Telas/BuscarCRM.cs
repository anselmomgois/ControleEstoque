using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscarCRM : TelaBase.BaseCE
    {
        public BuscarCRM()
        {
            InitializeComponent();
            this.pnlBase.Controls.Add(tlpClientes);
            tlpClientes.Dock = DockStyle.Fill;
        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        private const string btnExcel = "btnExcel";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.Pessoa> Funcionarios = null;
        private List<Comum.Clases.Pessoa> Clientes = null;
        private List<Comum.Clases.CRMSimples> Agendamentos = null;
        private Int32 _cronometro = 0;
        private Boolean ExecutouCtrlHome = false;

        #endregion

        #region"Metodos"

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        private void CarregarTela()
        {
            CarredarDados();
            ConfigurarVisualizacao();
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);
                        
        }

        private void CarredarDados()
        {
            ContratoServico.Telas.BuscarCRM.Carregar.PeticaoBuscarCRMCarregar Peticao = new ContratoServico.Telas.BuscarCRM.Carregar.PeticaoBuscarCRMCarregar()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                Login = (ControleEstoque.Parametros.Parametros.InformacaoUsuario.Consultor ? ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login : string.Empty)
            };

            Agente.Agente.InvocarServico<ContratoServico.Telas.BuscarCRM.Carregar.RespostaBuscarCRMCarregar, ContratoServico.Telas.BuscarCRM.Carregar.PeticaoBuscarCRMCarregar>(Peticao,
                  SDK.Operacoes.operacao.CarregarBuscarCRM, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPROMISSO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnExcel, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPROMISSO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPROMISSO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPROMISSO, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
            {
                colConsultar.Visible = false;
            }

        }

        private void RecuperarAgendamentos(Boolean PreencherObjeto, Boolean ExibirMensagem, Boolean BuscaAutomatica)
        {
            Comum.Clases.Pessoa objCliente = (Comum.Clases.Pessoa)(frmWindows.Util.RecuperarItemSelecionado(lstClientes, Clientes, "Identificador"));
            List<Comum.Clases.Pessoa> objFuncionarios = (List<Comum.Clases.Pessoa>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Pessoa>(lstFuncionario, Funcionarios, "Identificador"));
            string IdentificadorCliente = string.Empty;
            List<string> IdentificadoresFuncionario = null;
            string IdentificadorFuncionarioCadastro = null;
            Nullable<Int32> Codigo = null;
            Nullable<DateTime> DataInicio = null;
            Nullable<DateTime> DataFim = null;
            Nullable<Boolean> Ativo = null;

            //if (!BuscaAutomatica)
            //{
            if (objCliente != null)
            {

                IdentificadorCliente = objCliente.Identificador;

            }

            if (dtpInicio.Checked)
            {
                DataInicio = dtpInicio.Value;
            }

            if (dtpFim.Checked)
            {
                DataFim = dtpFim.Value;
            }

            if (chkCriadoPorMim.Checked)
            {
                IdentificadorFuncionarioCadastro = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador;
            }

            if (chkAtivo.CheckState != CheckState.Indeterminate)
            {
                Ativo = chkAtivo.Checked;
            }

            if (objFuncionarios != null && objFuncionarios.Count > 0 && (!ControleEstoque.Parametros.Parametros.InformacaoUsuario.Consultor || 
                Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_VER_AGENDA_TODOS, null)))
            {
                IdentificadoresFuncionario = new List<string>();

                foreach (Comum.Clases.Pessoa objFunc in objFuncionarios)
                {
                    IdentificadoresFuncionario.Add(objFunc.Identificador);
                }
            }

            if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.Consultor && !Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_VER_AGENDA_TODOS, null))
            {
                if (IdentificadoresFuncionario == null || !IdentificadoresFuncionario.Exists(f => f == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador))
                {
                    if (IdentificadoresFuncionario == null) { IdentificadoresFuncionario = new List<string>(); }
                    IdentificadoresFuncionario.Add(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador);
                }
            }
            //}
            //else
            //{
            //    if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_VER_AGENDA_TODOS, null))
            //    {
            //        IdentificadoresFuncionario = new List<string>();
            //        IdentificadoresFuncionario.Add(Parametros.Parametros.InformacaoUsuario.Identificador);
            //    }

            //}

            ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples Peticao = new ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples();

            Peticao.IdentificadoresFuncionariosResponsaveis = IdentificadoresFuncionario;
            Peticao.DataInicio = DataInicio;
            Peticao.DataFim = DataFim;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.ValidacoesExpecificas = false;
            Peticao.Ativo = true;
            Peticao.IdentificadorFuncionarioCadastro = IdentificadorFuncionarioCadastro;
            Peticao.Descricao = txtNome.Text;
            Peticao.IdentificadorCliente = IdentificadorCliente;
            Peticao.BuscarSomenteNaoConcluidos = false;


            Agente.Agente.InvocarServico<ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples, ContratoServico.CRM.RecuperarAgendamentosSimples.PeticaoRecuperarAgendamentosSimples>(Peticao,
                    SDK.Operacoes.operacao.RecuperarAgendamentosSimples, new Comum.ParametrosTela.Generica() { PreencherObjeto = PreencherObjeto,
                        ExibirMensagemNenhumRegistro = ExibirMensagem, NaoDesabilitarControles = true
                    }, null, true);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarAgendamentosSimples)
            {
                Agendamentos = ((ContratoServico.CRM.RecuperarAgendamentosSimples.RespostaRecuperarAgendamentosSimples)objSaida).Agendamentos;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.ExcluirSetStatusCrm)
            {
                base.objNotificacao.ExibirMensagem("Status CRM deletado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);

            }
            else if (operacao == SDK.Operacoes.operacao.DesativarAgendamento)
            {
                base.objNotificacao.ExibirMensagem("Agendamento desativado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarAgendamentos(true, false, false);
            }
            else if (operacao == SDK.Operacoes.operacao.GerarAgendamentoAutomatico)
            {
                base.objNotificacao.ExibirMensagem("Agendamentos gerados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarAgendamentos(true, false, false);
            }
            else if (operacao == SDK.Operacoes.operacao.CarregarBuscarCRM)
            {

                ContratoServico.Telas.BuscarCRM.Carregar.RespostaBuscarCRMCarregar objRespostaConvertido = (ContratoServico.Telas.BuscarCRM.Carregar.RespostaBuscarCRMCarregar)objSaida;

                Clientes = objRespostaConvertido.Clientes;

                if (Clientes == null || Clientes.Count == 0)
                {
                    lstClientes.Enabled = false;
                }
                else
                {
                    List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Clientes, "Identificador", "DesNome");
                    lstClientes = frmWindows.Util.PreencherListBox(lstClientes, Items);
                }


                Funcionarios = objRespostaConvertido.Funcionarios;

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_VER_AGENDA_TODOS, null))
                {
                    if (Funcionarios != null)
                    {
                        Funcionarios.RemoveAll(f => f.Identificador != ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador);

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Funcionarios, "Identificador", "DesNome");
                        lstFuncionario = frmWindows.Util.PreencherListBox(lstFuncionario, Items);
                        lstFuncionario = (ListBox)(frmWindows.Util.SelecionarItemControle(lstFuncionario, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador, "Identificador"));
                        lstFuncionario.Enabled = false;
                        chkCriadoPorMim.Checked = true;
                        chkCriadoPorMim.Enabled = false;

                    }
                }
                else
                {

                    if (Funcionarios == null || Funcionarios.Count == 0)
                    {
                        lstFuncionario.Enabled = false;
                    }
                    else
                    {

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Funcionarios, "Identificador", "DesNome");
                        lstFuncionario = frmWindows.Util.PreencherListBox(lstFuncionario, Items);
                    }
                }
                dtpInicio.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                dtpFim.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(1);
                dtpFim.Checked = true;
                dtpInicio.Checked = true;

            }

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            Comum.Clases.Agendamento objAgendamento = null;

            if (Agendamentos != null && Agendamentos.Count > 0)
            {
                DataGridViewRow rowSelecionada = null;

                if(dgvMarcas.SelectedRows != null && dgvMarcas.SelectedRows.Count > 0)
                {
                    rowSelecionada = dgvMarcas.SelectedRows[0];
                }
                foreach (Comum.Clases.CRMSimples c in Agendamentos.OrderBy(a => a.DataProximoCompromisso))
                {

                    var row = (from DataGridViewRow g in dgvMarcas.Rows where g.Cells[colIdCor.Index].Value.Equals(c.Identificador) select g).FirstOrDefault();

                    if (row == null || row.Cells[colIdCor.Index].Value == null || string.IsNullOrEmpty(row.Cells[colIdCor.Index].Value as string))
                    {
                        StringBuilder objFuncResponsavel = new StringBuilder();
                        StringBuilder objData = new StringBuilder();
                        List<string> objListFuncResp = new List<string>();
                        List<string> objListaData = new List<string>();
                        string objDescricaoFuncionario = string.Empty;

                        dgvMarcas.Rows.Add();

                        if (c.Responsaveis != null && c.Responsaveis.Length > 0)
                        {


                            if (c.Itens > 1)
                            {
                                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Height += ((c.Itens * 11) - 10);
                            }

                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;

                            if (c.Ativo)
                            {
                                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x;
                            }
                            else
                            {
                                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                            }


                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCliente.Index].Value = c.Cliente;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFuncionarioCadastro.Index].Value = c.UsuarioCriacao;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colResponsavel.Index].Value = c.Responsaveis.ToString();
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colTelefoneCelular.Index].Value = c.TelefoneCelular;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colTelefoneFixo.Index].Value = c.TelefoneFixo;

                            if (!string.IsNullOrEmpty(c.CorStatus))
                            {
                                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCorRGB.Index].Style.BackColor = Classes.Util.ConverterStringEmCor(c.CorStatus);
                            }

                        }
                    }
                    else
                    {
                        StringBuilder objFuncResponsavel = new StringBuilder();
                        StringBuilder objData = new StringBuilder();
                        List<string> objListFuncResp = new List<string>();
                        List<string> objListaData = new List<string>();
                        string objDescricaoFuncionario = string.Empty;

                        if (c.Responsaveis != null && c.Responsaveis.Length > 0)
                        {


                            if (c.Itens > 1)
                            {
                                row.Height += ((c.Itens * 11) - 10);
                            }

                            row.Cells[colDescricao.Index].Value = c.Descricao;
                           
                            if (c.Ativo)
                            {
                                row.Cells[colExcluir.Index].Value = Properties.Resources.x;
                            }
                            else
                            {
                                row.Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                            }


                            row.Cells[colCliente.Index].Value = c.Cliente;
                            row.Cells[colFuncionarioCadastro.Index].Value = c.UsuarioCriacao;
                            row.Cells[colResponsavel.Index].Value = c.Responsaveis.ToString();
                            row.Cells[colTelefoneCelular.Index].Value = c.TelefoneCelular;
                            row.Cells[colTelefoneFixo.Index].Value = c.TelefoneFixo;

                            if (!string.IsNullOrEmpty(c.CorStatus))
                            {
                                row.Cells[colCorRGB.Index].Style.BackColor = Classes.Util.ConverterStringEmCor(c.CorStatus);
                            }

                        }
                    }
                }

                List<DataGridViewRow> objRows = new List<DataGridViewRow>();

                foreach(DataGridViewRow row in dgvMarcas.Rows)
                {
                   if(!Agendamentos.Exists(a => a.Identificador == row.Cells[colIdCor.Index].Value as string))
                    {
                        objRows.Add(row);
                    }
                   else if (rowSelecionada != null && rowSelecionada.Cells[colIdCor.Index].Value as string == row.Cells[colIdCor.Index].Value as string)
                    {
                        row.Selected = true;
                    }
                }

                if(objRows.Count > 0)
                {
                    foreach (DataGridViewRow row in objRows)
                    {
                        dgvMarcas.Rows.Remove(row);
                    }
                }

                
                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                dgvMarcas.Rows.Clear();
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }
            else
            {
                dgvMarcas.Rows.Clear();
            }

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F4)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F4, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Carga Por Excel (F5)", btnExcel, Properties.Resources.excel, new EventHandler(btnExcel_Click), Keys.F5, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            CarregarTela();
            this.pnlBase.Controls.Add(tlpClientes);
            base.Inicializar();
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            GuardarCRM frmCores = new GuardarCRM(false, Identificador.Value);


            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                RecuperarAgendamentos(true, false, false);

            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            ContratoServico.CRM.DesativarAgendamento.PeticaoDesativarAgendamento Peticao = new ContratoServico.CRM.DesativarAgendamento.PeticaoDesativarAgendamento()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorCRM = Identificador.Value
            };

            Agente.Agente.InvocarServico<ContratoServico.CRM.DesativarAgendamento.RespostaDesativarAgendamento, ContratoServico.CRM.DesativarAgendamento.PeticaoDesativarAgendamento>(Peticao,
                  SDK.Operacoes.operacao.DesativarAgendamento, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, NaoDesabilitarControles = true }, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        #region "Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarAgendamentos(true, true, false);

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                Agendamentos = null;
                lstClientes.SelectedIndices.Clear();
                lstFuncionario.SelectedItem = null;
                dtpFim.Checked = false;
                dtpInicio.Checked = false;
                chkAtivo.CheckState = CheckState.Indeterminate;
                chkCriadoPorMim.Checked = false;
                dgvMarcas.Rows.Clear();
                txtNome.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {

                ImportarExcelCrm frmExcel = new ImportarExcelCrm();
                if (frmExcel.ShowDialog() == DialogResult.OK)
                {
                    RecuperarAgendamentos(true, false, false);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCRM frmCRM = new GuardarCRM(false, string.Empty);


                if (frmCRM.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarAgendamentos(true, false, false);

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
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

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colConsultar.Index)
                        {

                            Cursor = Cursors.WaitCursor;

                            if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colConsultar.Index)
                            {

                                GuardarCRM frmCores = new GuardarCRM((e.ColumnIndex == colConsultar.Index),
                                    dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);


                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    RecuperarAgendamentos(true, false, false);

                                }

                                Cursor = Cursors.Default;

                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {
                                ContratoServico.CRM.DesativarAgendamento.PeticaoDesativarAgendamento Peticao = new ContratoServico.CRM.DesativarAgendamento.PeticaoDesativarAgendamento()
                                {
                                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                                    IdentificadorCRM = dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string
                                };

                                Agente.Agente.InvocarServico<ContratoServico.CRM.DesativarAgendamento.RespostaDesativarAgendamento, ContratoServico.CRM.DesativarAgendamento.PeticaoDesativarAgendamento>(Peticao,
                                      SDK.Operacoes.operacao.DesativarAgendamento, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, NaoDesabilitarControles = true }, null, true);

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
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

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colConsultar.Index)
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
        
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBuscaAutomatica.Checked)
                {
                    tmpBusca.Start();
                    _cronometro = 15;
                }
                else
                {
                    tmpBusca.Stop();
                    _cronometro = 0;
                    lblAtualizacao.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void tmpBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_cronometro <= 0)
                {
                    RecuperarAgendamentos(true, false, true);
                    _cronometro = 15;
                    lblAtualizacao.Text = string.Format("Atualizando em {0} segundos", _cronometro);
                }
                else
                {
                    _cronometro -= 1;
                    lblAtualizacao.Text = string.Format("Atualizando em {0} segundos", _cronometro);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }     

    }
}
