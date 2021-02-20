using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using System.IO;
using System.Windows.Forms.Calendar;
using Informatiz.ControleEstoque.Aplicacao.Classes;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarAgendamento : TelaBase.BaseCE
    {
        public GuardarAgendamento(Boolean Visualizar, Comum.Clases.Agendamento Agendamento, string IdentificadorCrm)
        {
            InitializeComponent();

            _Agendamento = Agendamento;
            _IdentificadorCrm = IdentificadorCrm;
            _Visualizar = Visualizar;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnFinalizarEtapa = "btnFinalizarEtapa";
        private const string btnImprimir = "btnImprimir";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.GrupoCompromisso> _objGruposCompromissos = null;
        private Comum.Clases.Agendamento _Agendamento = null;
        private List<Comum.Clases.Pessoa> Funcionarios = null;
        private List<Comum.Clases.Pergunta> _objPerguntas = null;
        private Boolean _Visualizar;
        private List<CalendarItem> _items = new List<CalendarItem>();
        private List<CalendarItem> _itemsConflitantes = new List<CalendarItem>();
        private System.Windows.Forms.Calendar.Calendar objCalendar = null;
        private string _IdentificadorCrm;

        #endregion

        #region"Propriedades"

        protected override void FimProcesamento()
        {
            try
            {
                CarregarControlesTela();
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

        public Comum.Clases.Agendamento Agendamento
        {
            get
            {
                return _Agendamento;
            }
        }

        public FileInfo ItemsFile
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }       

        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.aceitar, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Finalizar Etapa (F3)", btnFinalizarEtapa, Properties.Resources.finish, new EventHandler(btnFinalizarEtapa_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Imprimir Ficha (F4)", btnImprimir, Properties.Resources.printer_red, new EventHandler(btnImprimirFicha_Click), Keys.F4, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(dtpInicio);
            this.pnlBase.Controls.Add(lblData);
            this.pnlBase.Controls.Add(lblFuncionario);
            this.pnlBase.Controls.Add(dtpDataFim);
            this.pnlBase.Controls.Add(lblDataFim);
            this.pnlBase.Controls.Add(lblGrupoSelecionado);
            this.pnlBase.Controls.Add(trvNivelAtendimento);
            this.pnlBase.Controls.Add(lblNivelAtentidimento);
            this.pnlBase.Controls.Add(gpbPerguntas);
            this.pnlBase.Controls.Add(pnlControle);
            this.pnlBase.Controls.Add(txtDescricao);
            this.pnlBase.Controls.Add(lblDescricao);
            this.pnlBase.Controls.Add(lstFuncionarios);
            CarregarTela();

            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarDados();
        }

        private void RecuperarDados()
        {
            ContratoServico.Telas.GuardarAgendamento.Carregar.PeticaoGuardarAgendamentoCarregar Peticao = new ContratoServico.Telas.GuardarAgendamento.Carregar.PeticaoGuardarAgendamentoCarregar()
            {
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
            };
            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarAgendamento.Carregar.RespostaGuardarAgendamentoCarregar, ContratoServico.Telas.GuardarAgendamento.Carregar.PeticaoGuardarAgendamentoCarregar>(Peticao,
                    SDK.Operacoes.operacao.CarregarGuardarAgendamento, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        private void PlaceItems()
        {
            objCalendar.Items.Clear();

            if (_items != null && _items.Count > 0)
            {
                foreach (CalendarItem item in _items)
                {
                    if (objCalendar.ViewIntersects(item))
                    {
                        objCalendar.Items.Add(item);
                    }
                }
            }

            if (_itemsConflitantes != null && _itemsConflitantes.Count > 0)
            {

                foreach (CalendarItem item in _itemsConflitantes)
                {
                    if (objCalendar.ViewIntersects(item))
                    {
                        objCalendar.Items.Add(item);
                    }
                }
            }
        }

        private void CarregarControlesTela()
        {
            if (_Agendamento != null)
            {
                dtpInicio.Value = _Agendamento.DataAtendimento;
                dtpDataFim.Value = _Agendamento.DataAtendimentoFim;
                txtDescricao.Text = _Agendamento.Descricao;

                if (_Agendamento.FuncionariosResponsaveis != null && _Agendamento.FuncionariosResponsaveis.Count > 0)
                {
                    lstFuncionarios = (ListBox)(frmWindows.Util.SelecionarItemControle(lstFuncionarios, string.Empty, "Identificador", _Agendamento.FuncionariosResponsaveis));
                }


                if (_Agendamento.NivelAtendimento != null)
                {

                    SelecionarNodo(trvNivelAtendimento.Nodes, _Agendamento.NivelAtendimento.Identificador);

                    if (_Agendamento.Perguntas != null && _Agendamento.Perguntas.Count > 0)
                    {

                        if (_objPerguntas != null && _objPerguntas.Count > 0)
                        {

                            Comum.Clases.Pergunta objPergunAux = null;

                            foreach (Comum.Clases.Pergunta objPergunta in _objPerguntas)
                            {

                                objPergunAux = _Agendamento.Perguntas.FindAll(p => p.Identificador == objPergunta.Identificador).FirstOrDefault();

                                if (objPergunAux != null)
                                {
                                    objPergunta.Resposta = objPergunAux.Resposta;
                                }
                            }
                        }
                        else
                        {
                            _objPerguntas = _Agendamento.Perguntas;
                        }

                        CarregarGridPerguntas();
                    }

                }
                BloquearTela();
            }
        }

        private void BloquearTela()
        {
            if (_Visualizar)
            {
                txtDescricao.Enabled = false;
                dgvPerguntas.Enabled = false;
                lstFuncionarios.Enabled = false;
                dtpDataFim.Enabled = false;
                dtpInicio.Enabled = false;
                trvNivelAtendimento.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                this.OcultarItemMenu(string.Empty, string.Empty, btnFinalizarEtapa, true);
            }
        }

        private void PreencherListGrupos()
        {
            lblGrupoSelecionado.Text = string.Empty;

            if (_objGruposCompromissos != null && _objGruposCompromissos.Count > 0)
            {

                TreeNode Nodo = null;
                foreach (Comum.Clases.GrupoCompromisso gp in _objGruposCompromissos.OrderBy(g => g.Descricao))
                {

                    Nodo = new TreeNode();

                    PreencherNode(ref Nodo, gp);

                    trvNivelAtendimento.Nodes.Add(Nodo);
                }

               // PreencherLabelGrupoSelecionado(trvNivelAtendimento.SelectedNode);
            }
        }

        private void PreencherNode(ref TreeNode Nodo, Comum.Clases.GrupoCompromisso Grupo)
        {

            Nodo.Name = Grupo.Identificador;
            Nodo.Text = Grupo.Descricao;
            Nodo.Tag = Grupo.Perguntas;

            if (Grupo.SubGrupos != null && Grupo.SubGrupos.Count > 0)
            {

                TreeNode NodoFilho = null;

                foreach (Comum.Clases.GrupoCompromisso gp in Grupo.SubGrupos.OrderBy(sg => sg.Descricao))
                {

                    NodoFilho = new TreeNode();

                    PreencherNode(ref NodoFilho, gp);

                    Nodo.Nodes.Add(NodoFilho);
                }

            }

        }

        private void PreencherLabelGrupoSelecionado(TreeNode nodo)
        {
            if (nodo.Parent != null)
            {
                PreencherLabelGrupoSelecionado(nodo.Parent);
            }

            if (nodo.Tag != null)
            {

                if (_objPerguntas == null) { _objPerguntas = new List<Comum.Clases.Pergunta>(); };

                _objPerguntas.AddRange((List<Comum.Clases.Pergunta>)(nodo.Tag));

            }

            lblGrupoSelecionado.Text += " > " + nodo.Text;
        }

        private void CarregarGridPerguntas()
        {

            dgvPerguntas.Rows.Clear();


            if (_objPerguntas != null && _objPerguntas.Count > 0)
            {

                foreach (Comum.Clases.Pergunta objPergunta in _objPerguntas.OrderBy(p => p.DesPergunta))
                {

                    dgvPerguntas.Rows.Add();
                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Tag = objPergunta;
                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colIdentificadorPergunta.Index].Value = objPergunta.Identificador;
                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colPergunta.Index].Value = objPergunta.DesPergunta;

                    if (!string.IsNullOrEmpty(objPergunta.Resposta))
                    {
                        switch (objPergunta.TipoComponente)
                        {
                            case Comum.Enumeradores.Enumeradores.TipoComponente.CHECKBOX:

                                if (objPergunta.Resposta == "1")
                                {
                                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colResposta.Index].Value = "Verdadeiro";
                                }
                                else
                                {
                                    dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colResposta.Index].Value = "Falso";
                                }

                                break;

                            case Comum.Enumeradores.Enumeradores.TipoComponente.COMBOBOX:

                                if (objPergunta.Opcoes != null && objPergunta.Opcoes.Count > 0)
                                {
                                    Comum.Clases.PerguntaOpcao objOp = objPergunta.Opcoes.FindAll(o => o.Identificador == objPergunta.Resposta).FirstOrDefault();

                                    if (objOp != null)
                                    {
                                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colResposta.Index].Value = objOp.Descricao;
                                    }
                                }

                                break;

                            case Comum.Enumeradores.Enumeradores.TipoComponente.SIMONAO:

                                dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colResposta.Index].Value = objPergunta.Resposta;

                                break;

                            case Comum.Enumeradores.Enumeradores.TipoComponente.TEXTBOX:

                                dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colResposta.Index].Value = objPergunta.Resposta;

                                break;
                        }
                    }
                    if (_Visualizar)
                    {
                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colLimparResposta.Index].Value = Properties.Resources.x_gray;
                        dgvPerguntas.Rows[dgvPerguntas.Rows.Count - 1].Cells[colEditarResposta.Index].Value = Properties.Resources.edit_gray;
                    }

                }
            }
        }

        private void RecuperarAgendamentos()
        {

            if (lstFuncionarios.SelectedItems != null && lstFuncionarios.SelectedItems.Count > 0)
            {
                List<Comum.Clases.Pessoa> objFuncionarios = (List<Comum.Clases.Pessoa>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Pessoa>(lstFuncionarios, Funcionarios, "Identificador"));

                if (objFuncionarios != null)
                {


                    ContratoServico.CRM.RecuperarAgendamentos.PeticaoRecuperarAgendamentos Peticao = new ContratoServico.CRM.RecuperarAgendamentos.PeticaoRecuperarAgendamentos();
                    ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos Resposta;

                    Peticao.IdentificadoresFuncionariosResponsaveis = (from Comum.Clases.Pessoa p in objFuncionarios select p.Identificador).ToList();
                    Peticao.DataInicio = dtpInicio.Value;
                    Peticao.DataFim = dtpDataFim.Value;
                    Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                    Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
                    Peticao.ValidacoesExpecificas = true;
                    Peticao.Ativo = true;

                    _itemsConflitantes.Clear();

                    Agente.Agente.InvocarServico<ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos, ContratoServico.CRM.RecuperarAgendamentos.PeticaoRecuperarAgendamentos>(Peticao,
                    SDK.Operacoes.operacao.RecuperarAgendamentos, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
                }
            }
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarAgendamentos)
            {
                List<Comum.Clases.CRM> Agendamentos = ((ContratoServico.CRM.RecuperarAgendamentos.RespostaRecuperarAgendamentos)objSaida).Agendamentos;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    if (Agendamentos != null)
                    {

                        string objTexto = string.Empty;

                        Dictionary<string, Color> objColorUsuario = new Dictionary<string, Color>();
                        List<Color> objCores = new List<Color>();
                        Color objCor;

                        objCores.Add(Color.Red);
                        objCores.Add(Color.Orange);
                        objCores.Add(Color.Purple);
                        objCores.Add(Color.Pink);
                        objCores.Add(Color.Yellow);
                        objCores.Add(Color.Violet);
                        objCores.Add(Color.Blue);
                        objCores.Add(Color.Brown);
                        objCores.Add(Color.BlueViolet);
                        objCores.Add(Color.Green);


                        if (Funcionarios != null && Funcionarios.Count > 0)
                        {
                            int indice = 0;

                            foreach (Comum.Clases.Pessoa objfunc in Funcionarios)
                            {
                                objColorUsuario.Add(objfunc.Identificador, objCores[indice]);
                                indice += 1;

                                if (indice == 10)
                                {
                                    indice = 0;
                                }
                            }
                        }
                        foreach (Comum.Clases.CRM objCrm in Agendamentos)
                        {
                            if (_Agendamento == null || (_IdentificadorCrm != objCrm.Identificador))
                            {
                                if (objCrm.Atendimentos != null && objCrm.Atendimentos.Count > 0)
                                {
                                    foreach (Comum.Clases.Agendamento objAg in objCrm.Atendimentos)
                                    {

                                        if (objAg.FuncionariosResponsaveis != null && objAg.FuncionariosResponsaveis.Count > 0)
                                        {
                                            foreach (Comum.Clases.Pessoa objF in objAg.FuncionariosResponsaveis)
                                            {
                                                if (objAg.NivelAtendimento != null)
                                                {
                                                    objTexto = objF.DesNome + " - " + "(" + objAg.DataAtendimento.ToString() + " - " + objAg.DataAtendimentoFim.ToString() + ") " + objAg.NivelAtendimento.Descricao + " - " + txtDescricao.Text;
                                                }
                                                else
                                                {
                                                    objTexto = objF.DesNome + " - " + "(" + objAg.DataAtendimento.ToString() + " - " + objAg.DataAtendimentoFim.ToString() + ") " + txtDescricao.Text;
                                                }

                                                CalendarItem objc = new CalendarItem(objCalendar, objAg.DataAtendimento, objAg.DataAtendimentoFim, objTexto);
                                                objCor = objColorUsuario.SingleOrDefault(co => co.Key == objF.Identificador).Value;
                                                objc.BackgroundColor = objCor;
                                                _itemsConflitantes.Add(objc);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    PlaceItems();
                }

            }
            else if (operacao == SDK.Operacoes.operacao.CarregarGuardarAgendamento)
            {
                ContratoServico.Telas.GuardarAgendamento.Carregar.RespostaGuardarAgendamentoCarregar objRespostaConvertido = (ContratoServico.Telas.GuardarAgendamento.Carregar.RespostaGuardarAgendamentoCarregar)objSaida;

                if (objRespostaConvertido != null)
                {
                    _objGruposCompromissos = objRespostaConvertido.GruposCompromisso;
                    Funcionarios = objRespostaConvertido.Funcionarios;
                }

                PreencherListGrupos();


                objCalendar = new System.Windows.Forms.Calendar.Calendar();
                objCalendar.Width = 510;

                PlaceItems();

                objCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif",7);
                objCalendar.VerticalScroll.Enabled = true;
                objCalendar.AutoScroll = true;
                objCalendar.Enabled = false;
                objCalendar.Dock = DockStyle.Fill;
                objCalendar.Height = pnlControle.Height;
                pnlControle.Controls.Add(objCalendar);
                dtpDataFim.Value = DateTime.Now.AddMinutes(30);
                dtpInicio.Value = DateTime.Now;

                if (Funcionarios == null || Funcionarios.Count == 0)
                {
                    lstFuncionarios.Enabled = false;
                }
                else
                {
                    List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Funcionarios.OrderBy(f=> f.DesNome).ToList(), "Identificador", "DesNome");
                    lstFuncionarios = frmWindows.Util.PreencherListBox(lstFuncionarios, Items);
                }

            }
        }

        private void ExecutarGravar(Boolean FinalizarEtapa)
        {
            if (lstFuncionarios.SelectedItems == null || lstFuncionarios.SelectedItems.Count == 0)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Obrigatório Selecionar um Funcionário");
            }

            if (dtpInicio.Value > dtpDataFim.Value)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Intervalo de data invalido");
            }

            if (_itemsConflitantes != null && _itemsConflitantes.Count > 0)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem compromissos conflitando com  o atual.");
            }

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A descrição é obrigatória.");
            }


            if (_Agendamento == null) _Agendamento = new Comum.Clases.Agendamento();

            if (_objPerguntas != null && _objPerguntas.Count > 0)
            {
                Boolean ExibirMensagemCampoObrigatorio = false;

                foreach (DataGridViewRow dr in dgvPerguntas.Rows)
                {

                    if (_objPerguntas.FindAll(p => p.Identificador == dr.Cells[colIdentificadorPergunta.Index].Value && p.Obrigatoria && string.IsNullOrEmpty(p.Resposta)).Count > 0)
                    {
                        dr.DefaultCellStyle.BackColor = Color.Red;
                        ExibirMensagemCampoObrigatorio = true;
                    }

                }

                if (ExibirMensagemCampoObrigatorio)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Existem campos obrigatórios em branco.");
                }
            }

            if (_objPerguntas != null && _objPerguntas.Count > 0)
            {
                _Agendamento.Perguntas = _objPerguntas.FindAll(p => !string.IsNullOrEmpty(p.Resposta));
            }

            if (trvNivelAtendimento.SelectedNode != null)
            {
                _Agendamento.NivelAtendimento = new Comum.Clases.GrupoCompromisso()
                {
                    Identificador = trvNivelAtendimento.SelectedNode.Name,
                    Descricao = trvNivelAtendimento.SelectedNode.Text
                };

            }


            _Agendamento.DataAtendimento = dtpInicio.Value;
            _Agendamento.DataAtendimentoFim = dtpDataFim.Value;
            _Agendamento.Descricao = txtDescricao.Text;
            _Agendamento.Concluido = FinalizarEtapa;
            _Agendamento.FuncionariosResponsaveis = (List<Comum.Clases.Pessoa>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Pessoa>(lstFuncionarios, Funcionarios, "Identificador"));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void SelecionarNodo(TreeNodeCollection Nodes, string IdentificadorGrupo)
        {

            if (Nodes != null && Nodes.Count > 0)
            {

                foreach (TreeNode Nodo in Nodes)
                {

                    if (Nodo.Name == IdentificadorGrupo)
                    {
                        trvNivelAtendimento.SelectedNode = Nodo;                        
                        trvNivelAtendimento.Focus();
                        return;
                    }

                    if (Nodo.Nodes != null && Nodo.Nodes.Count > 0)
                    {
                        SelecionarNodo(Nodo.Nodes, IdentificadorGrupo);
                    }
                }
            }
        }

        private void SelecionarItems(Boolean BolRecuperarAgendamentos)
        {
            if (dtpInicio.Value > dtpDataFim.Value)
            {
                return;
            }

            try
            {
                objCalendar.SetViewRange(dtpInicio.Value, dtpDataFim.Value);
            }
            catch (Exception ex)
            {

            }

            string NivelAtendimento = string.Empty;

            if (trvNivelAtendimento.SelectedNode != null)
            {
                NivelAtendimento = trvNivelAtendimento.SelectedNode.Text;

            }
            string objTexto = string.Empty;

            if (!string.IsNullOrEmpty(NivelAtendimento))
            {
                objTexto = "(" + dtpInicio.Value.ToString() + " - " + dtpDataFim.Value.ToString() + ") " + NivelAtendimento + " - " + txtDescricao.Text;
            }
            else
            {
                objTexto = "(" + dtpInicio.Value.ToString() + " - " + dtpDataFim.Value.ToString() + ") " + txtDescricao.Text;
            }
            CalendarItem objc = new CalendarItem(objCalendar, dtpInicio.Value, dtpDataFim.Value, objTexto);
            _items.Clear();
            _items.Add(objc);

            // if (BolRecuperarAgendamentos) { RecuperarAgendamentos(); }

            PlaceItems();
        }

        private void ModificarPergunta(string IdentificadorPergunta, int rowIndex)
        {
            Comum.Clases.Pergunta objPer = (from Comum.Clases.Pergunta p in _objPerguntas
                                            where p.Identificador == IdentificadorPergunta
                                            select p).FirstOrDefault();

            if (objPer != null)
            {
                GuardarResposta frmCores = new GuardarResposta(objPer);

                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frmCores.Valor))
                    {
                        dgvPerguntas.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                    }

                    objPer.Resposta = frmCores.Valor;
                    CarregarGridPerguntas();
                    dgvPerguntas.ClearSelection();

                    if (rowIndex < dgvPerguntas.Rows.Count - 1)
                    {
                        dgvPerguntas.Rows[rowIndex + 1].Cells[colEditarResposta.Index].Selected = true;
                    }
                }
            }
        }

        private void LimparPergunta(string Identificador, Int32 RowIndex)
        {
            Comum.Clases.Pergunta objPer = (from Comum.Clases.Pergunta p in _objPerguntas
                                            where p.Identificador == Identificador
                                            select p).FirstOrDefault();

            if (objPer != null)
            {
                objPer.Resposta = string.Empty;
            }
            dgvPerguntas.Rows[RowIndex].Cells[colResposta.Index].Value = string.Empty;
            dgvPerguntas.ClearSelection();

            if (RowIndex < dgvPerguntas.Rows.Count - 1)
            {
                dgvPerguntas.Rows[RowIndex + 1].Cells[colLimparResposta.Index].Selected = true;
            }
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            ModificarPergunta(Identificador.Value, RowIndex);

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            LimparPergunta(Identificador.Value, RowIndex);
            
            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        private void trvNivelAtendimento_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                _objPerguntas = null;
                lblGrupoSelecionado.Text = string.Empty;
                PreencherLabelGrupoSelecionado(e.Node);
                CarregarGridPerguntas();
                SelecionarItems(false);
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

        private void dgvPerguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPerguntas.RowCount > 0 && !_Visualizar)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditarResposta.Index || e.ColumnIndex == colLimparResposta.Index)
                        {

                            if (e.ColumnIndex == colEditarResposta.Index)
                            {
                                ModificarPergunta(dgvPerguntas.Rows[e.RowIndex].Cells[colIdentificadorPergunta.Index].Value as string, e.RowIndex);
                            }
                            else if (e.ColumnIndex == colLimparResposta.Index)
                            {
                                LimparPergunta(dgvPerguntas.Rows[e.RowIndex].Cells[colIdentificadorPergunta.Index].Value as string, e.RowIndex);
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

        private void dgvPerguntas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvPerguntas.RowCount > 0 && !_Visualizar)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditarResposta.Index || e.ColumnIndex == colLimparResposta.Index)
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                ExecutarGravar(false);

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

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            try
            {                
                SelecionarItems(true);

                if (!dtpInicio.Value.Equals(DateTime.MinValue))
                {
                    if (Parametros.Parametros.ParametrosAplicacao.IntervaloCompromissoCrm > 0)
                    {
                        dtpDataFim.Value = dtpInicio.Value.AddMinutes(Parametros.Parametros.ParametrosAplicacao.IntervaloCompromissoCrm);
                    }
                    else
                    {
                        dtpDataFim.Value = dtpInicio.Value.AddMinutes(30);
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

        private void dtpDataFim_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SelecionarItems(true);
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

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SelecionarItems(false);
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

        private void lstFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelecionarItems(true);
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

        private void btnImprimirFicha_Click(object sender, EventArgs e)
        {
            try
            {

                if (_objPerguntas != null && _objPerguntas.Count > 0)
                {

                    RelatorioVisualizar frmRelatorio = new RelatorioVisualizar();

                    DataSet.dtFicha objDataSet = new DataSet.dtFicha();
                    objDataSet.PopularDataSet(_objPerguntas, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada);

                    frmRelatorio.FonteDados = objDataSet;
                    frmRelatorio.Relatorio = "FichaPerguntas.rpt";

                    frmRelatorio.ShowDialog();
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

        private void btnFinalizarEtapa_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar(true);
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

    }
}
