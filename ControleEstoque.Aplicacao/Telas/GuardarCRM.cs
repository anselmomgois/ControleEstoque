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
    public partial class GuardarCRM : TelaBase.BaseCE
    {
        public GuardarCRM(Boolean Visualizar, string IdentificadorCRM)
        {
            InitializeComponent();

            _Visualizar = Visualizar;
            _IdentificadorCRM = IdentificadorCRM;

        }


        #region"Variaveis"

        private Boolean _Visualizar;
        private string _IdentificadorCRM;
        private Comum.Clases.CRM _objAgendamento;
        private List<Comum.Clases.Agendamento> _objAtendimentos = null;
        private List<Comum.Clases.Proposta> _objPropostas = null;
        private List<Comum.Clases.Pessoa> Funcionarios = null;
        private List<Comum.Clases.StatusCrm> _StatusCrms = null;
        private Comum.Clases.GrupoCompromisso objGrupoCompromisso = null;
        private List<Comum.Clases.Pergunta> _objPerguntas = null;
        private Controles.ucHelper _ucHelper;
        private List<Comum.Clases.StatusCrmAgrupador> _objStatusCrmAgrup = null;
        private List<Comum.Clases.TipoCrm> _objTiposCrm = null;
        private Int32 QuantidadeServicos = 0;
        private Random _objRandomFuncionarios;
        private Comum.Clases.TipoCrm _objTipoCrmSelecionado;
        private Boolean _GerarAgendamentoAutomatico = false;


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
            tlpPrincipal.Dock = DockStyle.Fill;
            this.pnlBase.Controls.Add(tlpPrincipal);
            CarregarTela();
            base.Inicializar();
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        private void RecuperarDados()
        {
            ContratoServico.Telas.GuardarCRM.Carregar.PeticaoGuardarCRMCarregar Peticao = new ContratoServico.Telas.GuardarCRM.Carregar.PeticaoGuardarCRMCarregar();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorCRM = _IdentificadorCRM;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarCRM.Carregar.RespostaGuardarCRMCarregar, ContratoServico.Telas.GuardarCRM.Carregar.PeticaoGuardarCRMCarregar>(Peticao, SDK.Operacoes.operacao.CarregarGuardarCRM,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarCRM)
            {
                ContratoServico.Telas.GuardarCRM.Carregar.RespostaGuardarCRMCarregar objSaidaConvertido = (ContratoServico.Telas.GuardarCRM.Carregar.RespostaGuardarCRMCarregar)objSaida;

                _objAgendamento = objSaidaConvertido.CRM;
                Funcionarios = objSaidaConvertido.Funcionarios;
                _objStatusCrmAgrup = objSaidaConvertido.StatusCRMAgrupador;
                _objTiposCrm = objSaidaConvertido.TiposCrm;


                PreencherTiposCrm();
                PreencherObjetos();
                dgvMarcas.ClearSelection();

            }
            else if (operacao == SDK.Operacoes.operacao.BuscarTipoCrm)
            {

                _objTipoCrmSelecionado = ((ContratoServico.TipoCrm.BuscarTipoCrm.RespostaBuscarTipoCrm)objSaida).TipoCrm;

                if (_objTipoCrmSelecionado != null)
                {
                    if (_objStatusCrmAgrup != null && _objStatusCrmAgrup.Count > 0 && !string.IsNullOrEmpty(_objTipoCrmSelecionado.IdentificadorStatusCrmAgrup))
                    {
                        _StatusCrms = (from Comum.Clases.StatusCrmAgrupador sa in _objStatusCrmAgrup
                                       where sa.Identificador == _objTipoCrmSelecionado.IdentificadorStatusCrmAgrup
                                       select sa.StatusCrms).FirstOrDefault();

                        PreencherStatusCrm();

                        if (_objAgendamento != null && _objAgendamento.StatusCrm != null && !string.IsNullOrEmpty(_objAgendamento.StatusCrm.Identificador))
                        {
                            cmbStatusCompromisso = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbStatusCompromisso, _objAgendamento.StatusCrm.Identificador, "Identificador"));
                        }
                        else if (!string.IsNullOrEmpty(_objTipoCrmSelecionado.IdentificadorStatusPadrao))
                        {
                            cmbStatusCompromisso = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbStatusCompromisso, _objTipoCrmSelecionado.IdentificadorStatusPadrao, "Identificador"));
                        }

                    }

                    if (_GerarAgendamentoAutomatico)
                    {
                        GerarAgendamento(false, null);
                        CarregarGridAgendamentos();
                    }
                    else
                    {
                        _GerarAgendamentoAutomatico = true;
                    }
                }
            }
            else if (operacao == SDK.Operacoes.operacao.InserirAgendamento || operacao == SDK.Operacoes.operacao.AtualizarAgendamento)
            {
                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void PreencherStatusCrm()
        {
            cmbStatusCompromisso.Items.Clear();

            if (_StatusCrms != null && _StatusCrms.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems((from s in _StatusCrms
                                                                              orderby s.Descricao
                                                                              select new Comum.Clases.StatusCrm()
                                                                              {
                                                                                  Codigo = s.Codigo,
                                                                                  CorRGB = s.CorRGB,
                                                                                  Descricao = s.Descricao,
                                                                                  Identificador = s.Identificador
                                                                              }).ToList(), "Identificador", "Descricao");

                cmbStatusCompromisso = frmWindows.Util.PreencherCombobox(cmbStatusCompromisso, Items);

            }
        }

        private void PreencherTiposCrm()
        {

            if (_objTiposCrm != null && _objTiposCrm.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems((from t in _objTiposCrm
                                                                              orderby t.Descricao
                                                                              select new Comum.Clases.TipoCrm()
                                                                              {
                                                                                  Codigo = t.Codigo,
                                                                                  Descricao = t.Descricao,
                                                                                  Identificador = t.Identificador,
                                                                                  IdentificadorStatusCrmAgrup = t.IdentificadorStatusCrmAgrup,
                                                                                  IdentificadorStatusPadrao = t.IdentificadorStatusPadrao,
                                                                                  TiposCrmConfig = t.TiposCrmConfig
                                                                              }).ToList(), "Identificador", "Descricao");

                cmbTipoCrm = frmWindows.Util.PreencherCombobox(cmbTipoCrm, Items);

            }
        }

        private void PreencherObjetos()
        {
            if (_objAgendamento != null)
            {
                txtNome.Text = _objAgendamento.Descricao;
                txtObservacao.Text = _objAgendamento.Observacao;
                chkAtivo.Checked = _objAgendamento.Ativo;


                if (_objAgendamento.Cliente != null && _ucHelper != null)
                {
                    _ucHelper.PreencherDados(_objAgendamento.Cliente);
                }


                if (_objAgendamento.TipoCrm != null)
                {
                    cmbTipoCrm = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbTipoCrm, _objAgendamento.TipoCrm.Identificador, "Identificador"));

                    if (_objAgendamento.Atendimentos != null && _objAgendamento.Atendimentos.Count > 0 &&
                        _objAgendamento.Atendimentos.FindAll(a => a.Concluido).Count() > 0)
                    {
                        cmbTipoCrm.Enabled = false;
                    }

                    if (_objAgendamento.StatusCrm != null)
                    {
                        cmbStatusCompromisso = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbStatusCompromisso, _objAgendamento.StatusCrm.Identificador, "Identificador"));
                    }
                }


            }
            else
            {
                chkAtivo.Visible = false;
                lblAtivo.Visible = false;
            }


            if (_objAgendamento != null && _objAgendamento.Propostas != null && _objAgendamento.Propostas.Count > 0)
            {
                _objPropostas = _objAgendamento.Propostas;
            }
            else
            {
                _objPropostas = new List<Comum.Clases.Proposta>();
            }

            if (_objAgendamento != null && _objAgendamento.Atendimentos != null && _objAgendamento.Atendimentos.Count > 0)
            {
                _objAtendimentos = _objAgendamento.Atendimentos;
            }
            else
            {

                GerarAgendamento(false, null);
            }

            CarregarGridAgendamentos();
            CarregarGridPropostas(true);
            BloquearControles();
        }

        private void GerarAgendamento(Boolean bolDesconsiderarFuncionarioAtual, Comum.Clases.Agendamento objAgendamentoAtual)
        {

            Int32 nivel = 0;

            if (objAgendamentoAtual == null)
            {

                if (_objAtendimentos != null && _objAtendimentos.Count > 0)
                {
                    nivel = _objAtendimentos.Count + 1;

                }


                if (_objTipoCrmSelecionado == null || _objTipoCrmSelecionado.TiposCrmConfig == null || _objTipoCrmSelecionado.TiposCrmConfig.Count == 0 ||
                    (_objTipoCrmSelecionado.TiposCrmConfig.Count < nivel) || (_objAtendimentos != null && !_objAtendimentos.Exists(a => a.Concluido)))
                {
                    return;
                }

                if (nivel == 0)
                {
                    nivel = 1;
                }
            }
            else
            {
                Int32 index = 0;
                foreach (Comum.Clases.Agendamento ag in _objAtendimentos)
                {
                    index += 1;

                    if (ag.Identificador == objAgendamentoAtual.Identificador)
                    {
                        nivel = index;
                    }
                }
            }

            Comum.Clases.TipoCrmConfig TipoConfigNivel = _objTipoCrmSelecionado.TiposCrmConfig.FindAll(tc => tc.Nivel == nivel).FirstOrDefault();
            DateTime DataAtendimentoInicio = DateTime.Now;
            DateTime DataAtendimentoFim = DateTime.Now;

            if (TipoConfigNivel != null)
            {
                DataAtendimentoInicio = (objAgendamentoAtual != null ? objAgendamentoAtual.DataAtendimento : DateTime.Now);
                DataAtendimentoFim = (objAgendamentoAtual != null ? objAgendamentoAtual.DataAtendimentoFim : DateTime.Now.AddDays(TipoConfigNivel.QuantidadeDiasData));
                List<Comum.Clases.Pessoa> objFuncionarios = TipoConfigNivel.Pessoas;

                if (nivel == 1)
                {

                    if (TipoConfigNivel.Pessoas == null || TipoConfigNivel.Pessoas.Count == 0)
                    {
                        Int32 QuantidadeFuncionarios = 0;
                        List<Comum.Clases.Pessoa> objPessoasEscolher = new List<Comum.Clases.Pessoa>();

                        if (TipoConfigNivel.TipoEmpregado != null)
                        {
                            QuantidadeFuncionarios = Funcionarios.FindAll(f => f.TipoEmpregado.Identificador == TipoConfigNivel.TipoEmpregado.Identificador).Count();
                            objPessoasEscolher = Funcionarios.FindAll(f => f.TipoEmpregado.Identificador == TipoConfigNivel.TipoEmpregado.Identificador).ToList();
                        }
                        else
                        {
                            QuantidadeFuncionarios = Funcionarios.Count;
                            objPessoasEscolher = Funcionarios;
                        }

                        if (bolDesconsiderarFuncionarioAtual)
                        {
                            if (objPessoasEscolher.Count > 1)
                            {
                                objPessoasEscolher.RemoveAll(pe => pe.Identificador == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador);
                                QuantidadeFuncionarios -= 1;
                            }
                            else
                            {
                                base.objNotificacao.ExibirMensagem("Funcionarios insuficientes para relalizar a ação.", Controles.UcNotificacao.TipoImagem.INFORMACAO);
                                return;
                            }
                        }
                        List<Int32> IndicesEscolhidos = new List<Int32>();


                        for (int i = 0; i < TipoConfigNivel.QuantidadeEmpregados; i++)
                        {
                            Nullable<Int32> indice = GerarIndice(QuantidadeFuncionarios, IndicesEscolhidos);

                            if (indice != null)
                            {
                                objFuncionarios.Add(objPessoasEscolher[(Int32)indice]);
                                IndicesEscolhidos.Add((Int32)indice);
                            }

                        }
                    }
                }
                else
                {

                    if (TipoConfigNivel.EmpregadoAtual && _objAtendimentos != null && _objAtendimentos.Count > 0)
                    {
                        objFuncionarios = _objAtendimentos.LastOrDefault().FuncionariosResponsaveis;
                    }
                    else if (TipoConfigNivel.Pessoas == null || TipoConfigNivel.Pessoas.Count == 0)
                    {
                        Int32 QuantidadeFuncionarios = 0;
                        List<Comum.Clases.Pessoa> objPessoasEscolher = new List<Comum.Clases.Pessoa>();

                        if (TipoConfigNivel.TipoEmpregado != null)
                        {
                            QuantidadeFuncionarios = Funcionarios.FindAll(f => f.TipoEmpregado.Identificador == TipoConfigNivel.TipoEmpregado.Identificador).Count();
                            objPessoasEscolher = Funcionarios.FindAll(f => f.TipoEmpregado.Identificador == TipoConfigNivel.TipoEmpregado.Identificador).ToList();
                        }
                        else
                        {
                            QuantidadeFuncionarios = Funcionarios.Count;
                            objPessoasEscolher = Funcionarios;
                        }

                        List<Int32> IndicesEscolhidos = new List<Int32>();

                        if (bolDesconsiderarFuncionarioAtual)
                        {
                            if (objPessoasEscolher.Count > 1)
                            {
                                objPessoasEscolher.RemoveAll(pe => pe.Identificador == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador);
                                QuantidadeFuncionarios -= 1;
                            }
                            else
                            {
                                base.objNotificacao.ExibirMensagem("Funcionarios insuficientes para relalizar a ação.", Controles.UcNotificacao.TipoImagem.INFORMACAO);
                                return;
                            }
                        }


                        for (int i = 0; i < TipoConfigNivel.QuantidadeEmpregados; i++)
                        {
                            Nullable<Int32> indice = GerarIndice(QuantidadeFuncionarios, IndicesEscolhidos);

                            if (indice != null)
                            {
                                objFuncionarios.Add(objPessoasEscolher[(Int32)indice]);
                                IndicesEscolhidos.Add((Int32)indice);
                            }

                        }
                    }
                }

                if (_objAtendimentos == null) { _objAtendimentos = new List<Comum.Clases.Agendamento>(); }

                if (objAgendamentoAtual != null)
                {
                    _objAtendimentos.RemoveAll(a => a.Identificador == objAgendamentoAtual.Identificador);
                }
                _objAtendimentos.Add(new Comum.Clases.Agendamento()
                {
                    Identificador = Guid.NewGuid().ToString(),
                    FuncionariosResponsaveis = objFuncionarios,
                    DataAtendimento = DataAtendimentoInicio,
                    DataAtendimentoFim = DataAtendimentoFim,
                    Descricao = TipoConfigNivel.DescricaoNivel
                });
            }
        }

        private Nullable<Int32> GerarIndice(int IndiceMaximo, List<Int32> IndicesEscolhidos)
        {
            if (IndiceMaximo == IndicesEscolhidos.Count)
            {
                return null;
            }

            Int32 Indice = GerarIndice(IndiceMaximo - 1);

            if (IndicesEscolhidos.Exists(ie => ie == Indice))
            {
                while (IndicesEscolhidos.Exists(ie => ie == Indice))
                {
                    Indice = GerarIndice(IndiceMaximo - 1);
                }

            }

            return Indice;
        }

        private Int32 GerarIndice(int IndiceMaximo)
        {
            Int32 Indice = 0;
            Int64 QuantidadeVezes = DateTime.Now.Second;

            for (int i = 0; i < QuantidadeVezes; i++)
            {
                if (Indice == IndiceMaximo)
                {
                    Indice = -1;
                }

                Indice += 1;
            }


            return Indice;
        }


        private void CarregarTela()
        {

            CarregarControleCliente();
            RecuperarDados();

        }

        private void CarregarControleCliente()
        {

            _ucHelper = new Controles.ucHelper(Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE, _Visualizar, false);
            _ucHelper.Dock = DockStyle.Fill;

            _ucHelper.DescricaoGrupo = "Dados do Cliente";
            _ucHelper.CarregarControle();

            pnlClientes.Controls.Add(_ucHelper);

        }

        private void BloquearControles()
        {

            if (_Visualizar)
            {
                txtNome.Enabled = false;
                txtObservacao.Enabled = false;
                chkAtivo.Enabled = false;
                cmbStatusCompromisso.Enabled = false;
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

                foreach (Comum.Clases.GrupoCompromisso gp in Grupo.SubGrupos)
                {

                    NodoFilho = new TreeNode();

                    PreencherNode(ref NodoFilho, gp);

                    Nodo.Nodes.Add(NodoFilho);
                }

            }

        }

        protected override void PreencherGrid(bool ExibirMensagem, string NomeGrid)
        {
            if (NomeGrid == "dgvMarcas")
            {
                CarregarGridAgendamentos();
            }
            else
            {
                CarregarGridPropostas(false);
            }
            base.PreencherGrid(ExibirMensagem, NomeGrid);
        }
        private void CarregarGridAgendamentos()
        {

            dgvMarcas.Rows.Clear();

            if (_objAtendimentos != null && _objAtendimentos.Count > 0)
            {
                if (_objAtendimentos.Exists(a => a.Concluido))
                {
                    cmbTipoCrm.Enabled = false;
                }

                foreach (Comum.Clases.Agendamento objAg in _objAtendimentos.OrderByDescending(da => da.DataAtendimento))
                {
                    StringBuilder objFuncResponsavel = new StringBuilder();
                    List<string> objListFuncResp = new List<string>();
                    Boolean primeiraVeiz = true;
                    dgvMarcas.Rows.Add();

                    if (objAg.FuncionariosResponsaveis != null && objAg.FuncionariosResponsaveis.Count > 0)
                    {

                        foreach (Comum.Clases.Pessoa objFunc in objAg.FuncionariosResponsaveis)
                        {
                            if (!objListFuncResp.Contains(objFunc.DesNome))
                            {
                                if (!primeiraVeiz)
                                {
                                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Height += 10;
                                }
                                primeiraVeiz = false;

                                objFuncResponsavel.AppendLine(objFunc.DesNome);
                                objListFuncResp.Add(objFunc.DesNome);
                            }
                        }
                    }

                    if (objAg.Concluido)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }

                    if (string.IsNullOrEmpty(objAg.Identificador))
                    {
                        objAg.Identificador = Guid.NewGuid().ToString();
                    }

                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = objAg.Identificador;

                    if (objAg.NivelAtendimento != null)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colNivelAtendimento.Index].Value = objAg.NivelAtendimento.Descricao;
                    }
                    else
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colNivelAtendimento.Index].Value = string.Empty;
                    }
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricaoAtendimento.Index].Value = objAg.Descricao;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colResponsavel.Index].Value = objFuncResponsavel.ToString();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colData.Index].Value = objAg.DataAtendimento;

                    if (objAg.FuncionariosResponsaveis != null &&
                        objAg.FuncionariosResponsaveis.Exists(f => f.Identificador == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador))
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colSouResponsavel.Index].Value = true;
                    }
                    else
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colSouResponsavel.Index].Value = false;
                    }

                    if (_Visualizar || objAg.Concluido)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                        if (_Visualizar)
                        {
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colEditar.Index].Value = Properties.Resources.edit_gray;
                        }
                        else
                        {
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colEditar.Index].Value = Properties.Resources.search_16;
                        }
                    }

                }
            }


        }

        private void CarregarGridPropostas(Boolean AlterarTamanhoTela)
        {

            if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.EmpresaMestre)
            {
                dgvProposta.Rows.Clear();

                if (_objPropostas != null && _objPropostas.Count > 0)
                {

                    foreach (Comum.Clases.Proposta objProp in _objPropostas)
                    {

                        dgvProposta.Rows.Add();
                        objProp.IdentificadorAuxiliar = Guid.NewGuid().ToString();
                        dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colIdentificador.Index].Value = objProp.IdentificadorAuxiliar;
                        dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colDescricao.Index].Value = objProp.Descricao;
                        dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colValorVenda.Index].Value = objProp.ValorPropostaVenda;
                        dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colValorManut.Index].Value = objProp.ValorPropostaManutencao;
                        dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colContraPropVenda.Index].Value = objProp.ValorContraPropostaVenda;
                        dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colContraPropManut.Index].Value = objProp.ValorContraPropostaManutencao;


                        if (objProp.AtendeNecessidade)
                        {
                            dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colAtende.Index].Value = Properties.Resources.positive;
                        }
                        else
                        {
                            dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colAtende.Index].Value = Properties.Resources.negative;
                        }

                        if (_Visualizar)
                        {
                            dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colExcluirProposta.Index].Value = Properties.Resources.x_gray;
                            dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colEditarProposta.Index].Value = Properties.Resources.edit_gray;
                        }

                    }
                }


                if (!_Visualizar)
                {
                    dgvProposta.Rows.Add();
                    dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colAtende.Index].Value = Properties.Resources.fundo_branco;
                    dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colEditarProposta.Index].Value = Properties.Resources.fundo_branco;
                    dgvProposta.Rows[dgvProposta.Rows.Count - 1].Cells[colExcluirProposta.Index].Value = Properties.Resources._new;
                }
            }
            else
            {
                if (AlterarTamanhoTela)
                {
                    gpbPropostas.Visible = false;
                    tlpPrincipal.RowStyles[6].SizeType = SizeType.Percent;
                    tlpPrincipal.RowStyles[6].Height = 0;
                    tlpPrincipal.Height = tlpPrincipal.Height - 180;
                    this.Height = this.Height - 180;
                }
            }
        }

        private void ExecutarGravar()
        {


            Comum.Clases.CRM objAgendamento = new Comum.Clases.CRM();

            objAgendamento.Descricao = txtNome.Text.Trim();
            objAgendamento.Identificador = _IdentificadorCRM;
            objAgendamento.Ativo = chkAtivo.Checked;
            objAgendamento.FuncionarioCadastro = new Comum.Clases.Pessoa() { Identificador = Parametros.Parametros.InformacaoUsuario.Identificador };
            objAgendamento.Observacao = txtObservacao.Text;

            objAgendamento.StatusCrm = (Comum.Clases.StatusCrm)(frmWindows.Util.RecuperarItemSelecionado(cmbStatusCompromisso, _StatusCrms, "Identificador"));

            objAgendamento.TipoCrm = (Comum.Clases.TipoCrm)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoCrm, _objTiposCrm, "Identificador"));


            if (_objPropostas != null && _objPropostas.Count > 0)
            {
                objAgendamento.Propostas = _objPropostas;
            }

            objAgendamento.Atendimentos = _objAtendimentos;

            if (_ucHelper != null && _ucHelper.DadoSelecinado != null)
            {
                objAgendamento.Cliente = (Comum.Clases.Pessoa)(_ucHelper.DadoSelecinado);
            }
            else
            {
                objAgendamento.Cliente = null;
            }

            if (string.IsNullOrEmpty(objAgendamento.Observacao))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A observação é obrigatoria");
            }

            if (string.IsNullOrEmpty(objAgendamento.Descricao))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "A descrição é obrigatoria");
            }

            if (objAgendamento.Cliente == null || string.IsNullOrEmpty(objAgendamento.Cliente.Identificador))
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O cliente é obrigatório");
            }

            if (objAgendamento.Atendimentos == null || objAgendamento.Atendimentos.Count == 0)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O atendimento é obrigatório");
            }

            if (objAgendamento.TipoCrm == null)
            {
                throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "O tipo do crm é obrigatório");
            }

            if (string.IsNullOrEmpty(_IdentificadorCRM))
            {
                ContratoServico.CRM.InserirAgendamento.PeticaoInserirAgendamento Peticao = new ContratoServico.CRM.InserirAgendamento.PeticaoInserirAgendamento();

                Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
                Peticao.CRM = objAgendamento;

                Agente.Agente.InvocarServico<ContratoServico.CRM.InserirAgendamento.RespostaInserirAgendamento, ContratoServico.CRM.InserirAgendamento.PeticaoInserirAgendamento>(Peticao, SDK.Operacoes.operacao.InserirAgendamento,
                    new Comum.ParametrosTela.Generica
                    {
                        PreencherObjeto = true
                    }, null, true);

            }
            else
            {
                ContratoServico.CRM.AtualizarAgendamento.PeticaoAtualizarAgendamento Peticao = new ContratoServico.CRM.AtualizarAgendamento.PeticaoAtualizarAgendamento();

                Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
                Peticao.CRM = objAgendamento;

                Agente.Agente.InvocarServico<ContratoServico.CRM.AtualizarAgendamento.RespostaAtualizarAgendamento, ContratoServico.CRM.AtualizarAgendamento.PeticaoAtualizarAgendamento>(Peticao, SDK.Operacoes.operacao.AtualizarAgendamento,
                    new Comum.ParametrosTela.Generica
                    {
                        PreencherObjeto = true
                    }, null, true);

            }

        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            if (NomeGrid == "dgvMarcas")
            {

                string identificadorCrm = string.Empty;

                if (_objAgendamento != null)
                {
                    identificadorCrm = _objAgendamento.Identificador;
                }

                Comum.Clases.Agendamento objAgenAux = (from Comum.Clases.Agendamento objA in _objAtendimentos
                                                       where objA.Identificador == Identificador.Value
                                                       select objA).FirstOrDefault();

                GuardarAgendamento frmAgendamento = new GuardarAgendamento((objAgenAux.Concluido ? true : false), objAgenAux, identificadorCrm);

                this.Cursor = Cursors.Default;
                if (frmAgendamento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmAgendamento.Agendamento != null)
                    {
                        if (_objAtendimentos == null) _objAtendimentos = new List<Comum.Clases.Agendamento>();

                        Comum.Clases.Agendamento objAgen = (from Comum.Clases.Agendamento objA in _objAtendimentos
                                                            where objA.Identificador == frmAgendamento.Agendamento.Identificador
                                                            select objA).FirstOrDefault();

                        if (objAgen != null)
                        {
                            objAgen.DataAtendimento = frmAgendamento.Agendamento.DataAtendimento;
                            objAgen.FuncionariosResponsaveis = frmAgendamento.Agendamento.FuncionariosResponsaveis;
                        }
                        else
                        {
                            _objAtendimentos.Add(frmAgendamento.Agendamento);
                        }

                        if (frmAgendamento.Agendamento.Concluido)
                        {
                            GerarAgendamento(false, null);
                        }

                        CarregarGridAgendamentos();
                    }
                }

            }
            else
            {
                if (_ucHelper != null && _ucHelper.DadoSelecinado == null)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor selecionar o cliente");
                }


                Comum.Clases.Proposta objPropAux = (from Comum.Clases.Proposta objP in _objPropostas
                                                    where objP.IdentificadorAuxiliar == Identificador.Value
                                                    select objP).FirstOrDefault();

                Comum.Clases.Pessoa objCliente = (Comum.Clases.Pessoa)(_ucHelper.DadoSelecinado);

                GuardarPropostas frmProposta = new GuardarPropostas(false, string.Empty, objPropAux, true, objCliente);

                if (frmProposta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmProposta.objPropostaTrans != null)
                    {
                        if (_objPropostas == null) _objPropostas = new List<Comum.Clases.Proposta>();

                        Comum.Clases.Proposta objProp = (from Comum.Clases.Proposta objP in _objPropostas
                                                         where objP.IdentificadorAuxiliar == frmProposta.objPropostaTrans.IdentificadorAuxiliar
                                                         select objP).FirstOrDefault();

                        if (objProp != null)
                        {
                            objProp.AtendeNecessidade = frmProposta.objPropostaTrans.AtendeNecessidade;
                            objProp.Ativa = frmProposta.objPropostaTrans.Ativa;
                            objProp.Cliente = frmProposta.objPropostaTrans.Cliente;
                            objProp.DataHoraInstalacao = frmProposta.objPropostaTrans.DataHoraInstalacao;
                            objProp.Descricao = frmProposta.objPropostaTrans.Descricao;
                            objProp.DesDuvida = frmProposta.objPropostaTrans.DesDuvida;
                            objProp.DesOpniao = frmProposta.objPropostaTrans.DesOpniao;
                            objProp.PessoaResponsavel = frmProposta.objPropostaTrans.PessoaResponsavel;
                            objProp.ValorContraPropostaManutencao = frmProposta.objPropostaTrans.ValorContraPropostaManutencao;
                            objProp.ValorContraPropostaVenda = frmProposta.objPropostaTrans.ValorContraPropostaVenda;
                            objProp.ValorPropostaManutencao = frmProposta.objPropostaTrans.ValorPropostaManutencao;
                            objProp.ValorPropostaVenda = frmProposta.objPropostaTrans.ValorPropostaVenda;
                        }
                        else
                        {
                            _objPropostas.Add(frmProposta.objPropostaTrans);
                        }
                        CarregarGridPropostas(false);
                    }
                }
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            if (NomeGrid == "dgvMarcas")
            {
                Comum.Clases.Agendamento objAgenAux = (from Comum.Clases.Agendamento objA in _objAtendimentos
                                                       where objA.Identificador == Identificador.Value
                                                       select objA).FirstOrDefault();

                if (!objAgenAux.Concluido)
                {
                    if (_objAtendimentos.Count > 1)
                    {
                        _objAtendimentos.RemoveAll(a => a.Identificador == Identificador.Value);
                        CarregarGridAgendamentos();
                    }
                    else
                    {
                        Aplicacao.Classes.Util.ExibirMensagemInformacao("Obrigatório ter pelo menos um agendamento.");
                    }
                }

            }
            else
            {
                if (dgvProposta.Rows.Count - 1 == RowIndex)
                {
                    if (_ucHelper != null && _ucHelper.DadoSelecinado == null)
                    {
                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor selecionar o cliente");
                    }

                    Comum.Clases.Pessoa objCliente = (Comum.Clases.Pessoa)(_ucHelper.DadoSelecinado);

                    GuardarPropostas frmProposta = new GuardarPropostas(false, string.Empty, null, true, objCliente);

                    if (frmProposta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (frmProposta.objPropostaTrans != null)
                        {
                            if (_objAtendimentos == null) _objAtendimentos = new List<Comum.Clases.Agendamento>();

                            Comum.Clases.Proposta objProp = (from Comum.Clases.Proposta objP in _objPropostas
                                                             where objP.IdentificadorAuxiliar == frmProposta.objPropostaTrans.IdentificadorAuxiliar
                                                             select objP).FirstOrDefault();

                            if (objProp != null)
                            {
                                objProp.AtendeNecessidade = frmProposta.objPropostaTrans.AtendeNecessidade;
                                objProp.Ativa = frmProposta.objPropostaTrans.Ativa;
                                objProp.Cliente = frmProposta.objPropostaTrans.Cliente;
                                objProp.DataHoraInstalacao = frmProposta.objPropostaTrans.DataHoraInstalacao;
                                objProp.Descricao = frmProposta.objPropostaTrans.Descricao;
                                objProp.DesDuvida = frmProposta.objPropostaTrans.DesDuvida;
                                objProp.DesOpniao = frmProposta.objPropostaTrans.DesOpniao;
                                objProp.PessoaResponsavel = frmProposta.objPropostaTrans.PessoaResponsavel;
                                objProp.ValorContraPropostaManutencao = frmProposta.objPropostaTrans.ValorContraPropostaManutencao;
                                objProp.ValorContraPropostaVenda = frmProposta.objPropostaTrans.ValorContraPropostaVenda;
                                objProp.ValorPropostaManutencao = frmProposta.objPropostaTrans.ValorPropostaManutencao;
                                objProp.ValorPropostaVenda = frmProposta.objPropostaTrans.ValorPropostaVenda;
                            }
                            else
                            {
                                _objPropostas.Add(frmProposta.objPropostaTrans);
                            }

                            CarregarGridPropostas(false);
                        }
                    }
                }
            }

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string identificadorCrm = string.Empty;

                if (_objAgendamento != null)
                {
                    identificadorCrm = _objAgendamento.Identificador;
                }

                if (dgvMarcas.RowCount > 0 && !_Visualizar)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colSouResponsavel.Index)
                        {
                            Comum.Clases.Agendamento objAgenAux = (from Comum.Clases.Agendamento objA in _objAtendimentos
                                                                   where objA.Identificador == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value
                                                                   select objA).FirstOrDefault();

                            if (e.ColumnIndex == colExcluir.Index)
                            {
                                if (!objAgenAux.Concluido)
                                {
                                    if (_objAtendimentos.Count > 1)
                                    {
                                        _objAtendimentos.RemoveAll(a => a.Identificador == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value);
                                        CarregarGridAgendamentos();
                                    }
                                    else
                                    {
                                        Aplicacao.Classes.Util.ExibirMensagemInformacao("Obrigatório ter pelo menos um agendamento.");
                                    }
                                }
                            }
                            else if (e.ColumnIndex == colSouResponsavel.Index)
                            {
                                if (objAgenAux != null && !objAgenAux.Concluido)
                                {
                                    if (!Convert.ToBoolean(dgvMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                                    {
                                        Comum.Clases.Pessoa objFuncAtual = Funcionarios.FindAll(f => f.Identificador == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador).FirstOrDefault();
                                        if (objFuncAtual != null)
                                        {

                                            objAgenAux.FuncionariosResponsaveis.Clear();
                                            objAgenAux.FuncionariosResponsaveis.Add(objFuncAtual);
                                            CarregarGridAgendamentos();
                                        }
                                    }
                                    else
                                    {
                                        objAgenAux.FuncionariosResponsaveis.RemoveAll(fr => fr.Identificador == ControleEstoque.Parametros.Parametros.InformacaoUsuario.Identificador);

                                        if (objAgenAux.FuncionariosResponsaveis.Count == 0)
                                        {
                                            GerarAgendamento(true, objAgenAux);
                                            CarregarGridAgendamentos();
                                        }
                                    }
                                }
                            }
                            else
                            {

                                GuardarAgendamento frmAgendamento = new GuardarAgendamento((objAgenAux.Concluido ? true : false), objAgenAux, identificadorCrm);

                                this.Cursor = Cursors.Default;
                                if (frmAgendamento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frmAgendamento.Agendamento != null)
                                    {
                                        if (_objAtendimentos == null) _objAtendimentos = new List<Comum.Clases.Agendamento>();

                                        Comum.Clases.Agendamento objAgen = (from Comum.Clases.Agendamento objA in _objAtendimentos
                                                                            where objA.Identificador == frmAgendamento.Agendamento.Identificador
                                                                            select objA).FirstOrDefault();

                                        if (objAgen != null)
                                        {
                                            objAgen.DataAtendimento = frmAgendamento.Agendamento.DataAtendimento;
                                            objAgen.FuncionariosResponsaveis = frmAgendamento.Agendamento.FuncionariosResponsaveis;
                                        }
                                        else
                                        {
                                            _objAtendimentos.Add(frmAgendamento.Agendamento);
                                        }

                                        if (frmAgendamento.Agendamento.Concluido)
                                        {
                                            GerarAgendamento(false, null);
                                        }

                                        CarregarGridAgendamentos();
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgvMarcas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0 && !_Visualizar)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        Comum.Clases.Agendamento objAgenAux = (from Comum.Clases.Agendamento objA in _objAtendimentos
                                                               where objA.Identificador == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value
                                                               select objA).FirstOrDefault();

                        if (e.ColumnIndex == colEditar.Index || (e.ColumnIndex == colExcluir.Index && !objAgenAux.Concluido))
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

        private void dgvProposta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProposta.RowCount > 0 && !_Visualizar)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditarProposta.Index || e.ColumnIndex == colExcluirProposta.Index)
                        {

                            if (e.ColumnIndex == colExcluirProposta.Index)
                            {

                                if (dgvProposta.Rows.Count - 1 == e.RowIndex)
                                {
                                    if (_ucHelper != null && _ucHelper.DadoSelecinado == null)
                                    {
                                        throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor selecionar o cliente");
                                    }

                                    Comum.Clases.Pessoa objCliente = (Comum.Clases.Pessoa)(_ucHelper.DadoSelecinado);

                                    GuardarPropostas frmProposta = new GuardarPropostas(false, string.Empty, null, true, objCliente);

                                    if (frmProposta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        if (frmProposta.objPropostaTrans != null)
                                        {
                                            if (_objAtendimentos == null) _objAtendimentos = new List<Comum.Clases.Agendamento>();

                                            Comum.Clases.Proposta objProp = (from Comum.Clases.Proposta objP in _objPropostas
                                                                             where objP.IdentificadorAuxiliar == frmProposta.objPropostaTrans.IdentificadorAuxiliar
                                                                             select objP).FirstOrDefault();

                                            if (objProp != null)
                                            {
                                                objProp.AtendeNecessidade = frmProposta.objPropostaTrans.AtendeNecessidade;
                                                objProp.Ativa = frmProposta.objPropostaTrans.Ativa;
                                                objProp.Cliente = frmProposta.objPropostaTrans.Cliente;
                                                objProp.DataHoraInstalacao = frmProposta.objPropostaTrans.DataHoraInstalacao;
                                                objProp.Descricao = frmProposta.objPropostaTrans.Descricao;
                                                objProp.DesDuvida = frmProposta.objPropostaTrans.DesDuvida;
                                                objProp.DesOpniao = frmProposta.objPropostaTrans.DesOpniao;
                                                objProp.PessoaResponsavel = frmProposta.objPropostaTrans.PessoaResponsavel;
                                                objProp.ValorContraPropostaManutencao = frmProposta.objPropostaTrans.ValorContraPropostaManutencao;
                                                objProp.ValorContraPropostaVenda = frmProposta.objPropostaTrans.ValorContraPropostaVenda;
                                                objProp.ValorPropostaManutencao = frmProposta.objPropostaTrans.ValorPropostaManutencao;
                                                objProp.ValorPropostaVenda = frmProposta.objPropostaTrans.ValorPropostaVenda;
                                            }
                                            else
                                            {
                                                _objPropostas.Add(frmProposta.objPropostaTrans);
                                            }

                                            CarregarGridPropostas(false);
                                        }
                                    }
                                }
                                else
                                {
                                    if (_objPropostas.Count > 0)
                                    {
                                        _objPropostas.RemoveAll(a => a.IdentificadorAuxiliar == dgvProposta.Rows[e.RowIndex].Cells[colIdentificador.Index].Value);
                                        CarregarGridPropostas(false);
                                    }
                                    else
                                    {
                                        Aplicacao.Classes.Util.ExibirMensagemInformacao("Obrigatório ter pelo menos um agendamento.");
                                    }
                                }
                            }
                            else
                            {
                                if (_ucHelper != null && _ucHelper.DadoSelecinado == null)
                                {
                                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Favor selecionar o cliente");
                                }


                                Comum.Clases.Proposta objPropAux = (from Comum.Clases.Proposta objP in _objPropostas
                                                                    where objP.IdentificadorAuxiliar == dgvProposta.Rows[e.RowIndex].Cells[colIdentificador.Index].Value
                                                                    select objP).FirstOrDefault();

                                Comum.Clases.Pessoa objCliente = (Comum.Clases.Pessoa)(_ucHelper.DadoSelecinado);

                                GuardarPropostas frmProposta = new GuardarPropostas(false, string.Empty, objPropAux, true, objCliente);

                                if (frmProposta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (frmProposta.objPropostaTrans != null)
                                    {
                                        if (_objPropostas == null) _objPropostas = new List<Comum.Clases.Proposta>();

                                        Comum.Clases.Proposta objProp = (from Comum.Clases.Proposta objP in _objPropostas
                                                                         where objP.IdentificadorAuxiliar == frmProposta.objPropostaTrans.IdentificadorAuxiliar
                                                                         select objP).FirstOrDefault();

                                        if (objProp != null)
                                        {
                                            objProp.AtendeNecessidade = frmProposta.objPropostaTrans.AtendeNecessidade;
                                            objProp.Ativa = frmProposta.objPropostaTrans.Ativa;
                                            objProp.Cliente = frmProposta.objPropostaTrans.Cliente;
                                            objProp.DataHoraInstalacao = frmProposta.objPropostaTrans.DataHoraInstalacao;
                                            objProp.Descricao = frmProposta.objPropostaTrans.Descricao;
                                            objProp.DesDuvida = frmProposta.objPropostaTrans.DesDuvida;
                                            objProp.DesOpniao = frmProposta.objPropostaTrans.DesOpniao;
                                            objProp.PessoaResponsavel = frmProposta.objPropostaTrans.PessoaResponsavel;
                                            objProp.ValorContraPropostaManutencao = frmProposta.objPropostaTrans.ValorContraPropostaManutencao;
                                            objProp.ValorContraPropostaVenda = frmProposta.objPropostaTrans.ValorContraPropostaVenda;
                                            objProp.ValorPropostaManutencao = frmProposta.objPropostaTrans.ValorPropostaManutencao;
                                            objProp.ValorPropostaVenda = frmProposta.objPropostaTrans.ValorPropostaVenda;
                                        }
                                        else
                                        {
                                            _objPropostas.Add(frmProposta.objPropostaTrans);
                                        }
                                        CarregarGridPropostas(false);
                                    }
                                }
                            }
                        }

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

        private void dgvProposta_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProposta.RowCount > 0 && !_Visualizar)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditarProposta.Index || e.ColumnIndex == colExcluirProposta.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index && e.RowIndex == dgvMarcas.Rows.Count - 1)
                            {
                                //Define o cursor para default
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                //Define o cursor para Hand
                                Cursor.Current = Cursors.Hand;
                            }
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarGravar();

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

        private void btnAdicionarAgendamento_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string identificadorCrm = string.Empty;

                if (_objAgendamento != null)
                {
                    identificadorCrm = _objAgendamento.Identificador;
                }

                GuardarAgendamento frmAgendamento = new GuardarAgendamento(false, null, identificadorCrm);

                if (frmAgendamento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmAgendamento.Agendamento != null)
                    {


                        if (_objAtendimentos == null) _objAtendimentos = new List<Comum.Clases.Agendamento>();

                        Comum.Clases.Agendamento objAgen = (from Comum.Clases.Agendamento objA in _objAtendimentos
                                                            where objA.Identificador == frmAgendamento.Agendamento.Identificador
                                                            select objA).FirstOrDefault();

                        if (objAgen != null)
                        {
                            objAgen.DataAtendimento = frmAgendamento.Agendamento.DataAtendimento;
                            objAgen.FuncionariosResponsaveis = frmAgendamento.Agendamento.FuncionariosResponsaveis;
                        }
                        else
                        {
                            _objAtendimentos.Add(frmAgendamento.Agendamento);
                        }
                        CarregarGridAgendamentos();
                    }
                }

                Cursor = Cursors.Default;
            }

            catch (Execao.ExecaoNegocio ex)
            {
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void cmbTipoCrm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Comum.Clases.TipoCrm TipoSelcionado = (Comum.Clases.TipoCrm)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoCrm, _objTiposCrm, "Identificador"));

                if (TipoSelcionado != null)
                {
                    ContratoServico.TipoCrm.BuscarTipoCrm.PeticaoBuscarTipoCrm Peticao = new ContratoServico.TipoCrm.BuscarTipoCrm.PeticaoBuscarTipoCrm();

                    Peticao.Identificador = TipoSelcionado.Identificador;
                    Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                    Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                    Agente.Agente.InvocarServico<ContratoServico.TipoCrm.BuscarTipoCrm.RespostaBuscarTipoCrm, ContratoServico.TipoCrm.BuscarTipoCrm.PeticaoBuscarTipoCrm>(Peticao, SDK.Operacoes.operacao.BuscarTipoCrm,
                        new Comum.ParametrosTela.Generica
                        {
                            PreencherObjeto = true
                        }, null, true);

                }

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

    }
}
