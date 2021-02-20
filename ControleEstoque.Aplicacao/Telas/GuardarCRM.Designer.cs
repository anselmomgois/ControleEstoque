namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarCRM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.gpbAtendimento = new System.Windows.Forms.GroupBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNivelAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSouResponsavel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpbPropostas = new System.Windows.Forms.GroupBox();
            this.dgvProposta = new System.Windows.Forms.DataGridView();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorManut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContraPropVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContraPropManut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtende = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEditarProposta = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluirProposta = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.lblAtivo = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlObservacao = new System.Windows.Forms.Panel();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.pnlCompromisso = new System.Windows.Forms.Panel();
            this.btnAdicionarAgendamento = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTipoCrm = new System.Windows.Forms.Label();
            this.cmbStatusCompromisso = new System.Windows.Forms.ComboBox();
            this.cmbTipoCrm = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gpbAtendimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.gpbPropostas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProposta)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.pnlObservacao.SuspendLayout();
            this.pnlCliente.SuspendLayout();
            this.pnlCompromisso.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(223, 6);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(614, 22);
            this.txtNome.TabIndex = 2;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 11);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(180, 17);
            this.lblNome.TabIndex = 1000;
            this.lblNome.Text = "Descrição do Compromisso";
            // 
            // gpbAtendimento
            // 
            this.gpbAtendimento.Controls.Add(this.dgvMarcas);
            this.gpbAtendimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbAtendimento.Location = new System.Drawing.Point(4, 299);
            this.gpbAtendimento.Margin = new System.Windows.Forms.Padding(4);
            this.gpbAtendimento.Name = "gpbAtendimento";
            this.gpbAtendimento.Padding = new System.Windows.Forms.Padding(4);
            this.gpbAtendimento.Size = new System.Drawing.Size(964, 131);
            this.gpbAtendimento.TabIndex = 8;
            this.gpbAtendimento.TabStop = false;
            this.gpbAtendimento.Text = "Atendimentos";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AllowUserToOrderColumns = true;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colDescricaoAtendimento,
            this.colNivelAtendimento,
            this.colResponsavel,
            this.colData,
            this.colSouResponsavel,
            this.colEditar,
            this.colExcluir});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(4, 19);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(956, 108);
            this.dgvMarcas.TabIndex = 9;
            this.dgvMarcas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellContentClick);
            this.dgvMarcas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMarcas_CellMouseMove);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colDescricaoAtendimento
            // 
            this.colDescricaoAtendimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricaoAtendimento.HeaderText = "Descrição";
            this.colDescricaoAtendimento.Name = "colDescricaoAtendimento";
            this.colDescricaoAtendimento.ReadOnly = true;
            this.colDescricaoAtendimento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colNivelAtendimento
            // 
            this.colNivelAtendimento.HeaderText = "Nivel de Atendimento";
            this.colNivelAtendimento.Name = "colNivelAtendimento";
            this.colNivelAtendimento.ReadOnly = true;
            this.colNivelAtendimento.Width = 200;
            // 
            // colResponsavel
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colResponsavel.DefaultCellStyle = dataGridViewCellStyle1;
            this.colResponsavel.HeaderText = "Responsavel";
            this.colResponsavel.Name = "colResponsavel";
            this.colResponsavel.ReadOnly = true;
            this.colResponsavel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colResponsavel.Width = 200;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colData.Width = 150;
            // 
            // colSouResponsavel
            // 
            this.colSouResponsavel.HeaderText = "Sou Resp. Atendimento";
            this.colSouResponsavel.Name = "colSouResponsavel";
            this.colSouResponsavel.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEditar.Width = 50;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluir.Width = 50;
            // 
            // gpbPropostas
            // 
            this.gpbPropostas.Controls.Add(this.dgvProposta);
            this.gpbPropostas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbPropostas.Location = new System.Drawing.Point(4, 478);
            this.gpbPropostas.Margin = new System.Windows.Forms.Padding(4);
            this.gpbPropostas.Name = "gpbPropostas";
            this.gpbPropostas.Padding = new System.Windows.Forms.Padding(4);
            this.gpbPropostas.Size = new System.Drawing.Size(964, 131);
            this.gpbPropostas.TabIndex = 10;
            this.gpbPropostas.TabStop = false;
            this.gpbPropostas.Text = "Propostas";
            // 
            // dgvProposta
            // 
            this.dgvProposta.AllowUserToAddRows = false;
            this.dgvProposta.AllowUserToDeleteRows = false;
            this.dgvProposta.AllowUserToOrderColumns = true;
            this.dgvProposta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProposta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificador,
            this.colDescricao,
            this.colValorVenda,
            this.colValorManut,
            this.colContraPropVenda,
            this.colContraPropManut,
            this.colAtende,
            this.colEditarProposta,
            this.colExcluirProposta});
            this.dgvProposta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProposta.Location = new System.Drawing.Point(4, 19);
            this.dgvProposta.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProposta.Name = "dgvProposta";
            this.dgvProposta.ReadOnly = true;
            this.dgvProposta.Size = new System.Drawing.Size(956, 108);
            this.dgvProposta.TabIndex = 11;
            this.dgvProposta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProposta_CellContentClick);
            this.dgvProposta.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProposta_CellMouseMove);
            // 
            // colIdentificador
            // 
            this.colIdentificador.HeaderText = "Column1";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            this.colIdentificador.Visible = false;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição da Proposta";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colValorVenda
            // 
            this.colValorVenda.HeaderText = "Valor Venda";
            this.colValorVenda.Name = "colValorVenda";
            this.colValorVenda.ReadOnly = true;
            this.colValorVenda.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colValorManut
            // 
            this.colValorManut.HeaderText = "Valor Manut.";
            this.colValorManut.Name = "colValorManut";
            this.colValorManut.ReadOnly = true;
            this.colValorManut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colContraPropVenda
            // 
            this.colContraPropVenda.HeaderText = "Valor Contra Proposta Venda";
            this.colContraPropVenda.Name = "colContraPropVenda";
            this.colContraPropVenda.ReadOnly = true;
            this.colContraPropVenda.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colContraPropManut
            // 
            this.colContraPropManut.HeaderText = "Valor Contra Proposta Manut.";
            this.colContraPropManut.Name = "colContraPropManut";
            this.colContraPropManut.ReadOnly = true;
            this.colContraPropManut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAtende
            // 
            this.colAtende.HeaderText = "Atende";
            this.colAtende.Name = "colAtende";
            this.colAtende.ReadOnly = true;
            this.colAtende.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEditarProposta
            // 
            this.colEditarProposta.HeaderText = "Editar";
            this.colEditarProposta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditarProposta.Name = "colEditarProposta";
            this.colEditarProposta.ReadOnly = true;
            this.colEditarProposta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEditarProposta.Width = 50;
            // 
            // colExcluirProposta
            // 
            this.colExcluirProposta.HeaderText = "Excluir";
            this.colExcluirProposta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluirProposta.Name = "colExcluirProposta";
            this.colExcluirProposta.ReadOnly = true;
            this.colExcluirProposta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluirProposta.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Data";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacao.Location = new System.Drawing.Point(113, 9);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(847, 79);
            this.txtObservacao.TabIndex = 7;
            // 
            // lblObservacao
            // 
            this.lblObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(3, 69);
            this.lblObservacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(85, 17);
            this.lblObservacao.TabIndex = 1000;
            this.lblObservacao.Text = "Observação";
            // 
            // lblAtivo
            // 
            this.lblAtivo.AutoSize = true;
            this.lblAtivo.Location = new System.Drawing.Point(845, 11);
            this.lblAtivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.Size = new System.Drawing.Size(39, 17);
            this.lblAtivo.TabIndex = 1000;
            this.lblAtivo.Text = "Ativo";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(892, 12);
            this.chkAtivo.Margin = new System.Windows.Forms.Padding(4);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(18, 17);
            this.chkAtivo.TabIndex = 5;
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.gpbPropostas, 0, 6);
            this.tlpPrincipal.Controls.Add(this.gpbAtendimento, 0, 4);
            this.tlpPrincipal.Controls.Add(this.pnlObservacao, 0, 3);
            this.tlpPrincipal.Controls.Add(this.pnlCliente, 0, 1);
            this.tlpPrincipal.Controls.Add(this.pnlCompromisso, 0, 0);
            this.tlpPrincipal.Controls.Add(this.btnAdicionarAgendamento, 0, 5);
            this.tlpPrincipal.Controls.Add(this.pnlStatus, 0, 2);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 7;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(972, 613);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // pnlObservacao
            // 
            this.pnlObservacao.Controls.Add(this.txtObservacao);
            this.pnlObservacao.Controls.Add(this.lblObservacao);
            this.pnlObservacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObservacao.Location = new System.Drawing.Point(4, 199);
            this.pnlObservacao.Margin = new System.Windows.Forms.Padding(4);
            this.pnlObservacao.Name = "pnlObservacao";
            this.pnlObservacao.Size = new System.Drawing.Size(964, 92);
            this.pnlObservacao.TabIndex = 6;
            // 
            // pnlCliente
            // 
            this.pnlCliente.Controls.Add(this.pnlClientes);
            this.pnlCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCliente.Location = new System.Drawing.Point(4, 44);
            this.pnlCliente.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(964, 107);
            this.pnlCliente.TabIndex = 3;
            // 
            // pnlClientes
            // 
            this.pnlClientes.Location = new System.Drawing.Point(7, 7);
            this.pnlClientes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(600, 95);
            this.pnlClientes.TabIndex = 1001;
            // 
            // pnlCompromisso
            // 
            this.pnlCompromisso.Controls.Add(this.txtNome);
            this.pnlCompromisso.Controls.Add(this.chkAtivo);
            this.pnlCompromisso.Controls.Add(this.lblAtivo);
            this.pnlCompromisso.Controls.Add(this.lblNome);
            this.pnlCompromisso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompromisso.Location = new System.Drawing.Point(4, 4);
            this.pnlCompromisso.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCompromisso.Name = "pnlCompromisso";
            this.pnlCompromisso.Size = new System.Drawing.Size(964, 32);
            this.pnlCompromisso.TabIndex = 1;
            // 
            // btnAdicionarAgendamento
            // 
            this.btnAdicionarAgendamento.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdicionarAgendamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarAgendamento.ForeColor = System.Drawing.Color.Navy;
            this.btnAdicionarAgendamento.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources._new;
            this.btnAdicionarAgendamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarAgendamento.Location = new System.Drawing.Point(725, 437);
            this.btnAdicionarAgendamento.Name = "btnAdicionarAgendamento";
            this.btnAdicionarAgendamento.Size = new System.Drawing.Size(244, 33);
            this.btnAdicionarAgendamento.TabIndex = 13;
            this.btnAdicionarAgendamento.Text = "&Adicionar Agendamento";
            this.btnAdicionarAgendamento.UseVisualStyleBackColor = true;
            this.btnAdicionarAgendamento.Click += new System.EventHandler(this.btnAdicionarAgendamento_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.tableLayoutPanel1);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Location = new System.Drawing.Point(3, 158);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(966, 34);
            this.pnlStatus.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTipoCrm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbStatusCompromisso, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbTipoCrm, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(966, 34);
            this.tableLayoutPanel1.TabIndex = 1005;
            // 
            // lblTipoCrm
            // 
            this.lblTipoCrm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTipoCrm.AutoSize = true;
            this.lblTipoCrm.Location = new System.Drawing.Point(4, 8);
            this.lblTipoCrm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoCrm.Name = "lblTipoCrm";
            this.lblTipoCrm.Size = new System.Drawing.Size(70, 17);
            this.lblTipoCrm.TabIndex = 1003;
            this.lblTipoCrm.Text = "Tipo CRM";
            // 
            // cmbStatusCompromisso
            // 
            this.cmbStatusCompromisso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbStatusCompromisso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusCompromisso.FormattingEnabled = true;
            this.cmbStatusCompromisso.Location = new System.Drawing.Point(646, 4);
            this.cmbStatusCompromisso.Name = "cmbStatusCompromisso";
            this.cmbStatusCompromisso.Size = new System.Drawing.Size(284, 24);
            this.cmbStatusCompromisso.TabIndex = 1002;
            // 
            // cmbTipoCrm
            // 
            this.cmbTipoCrm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTipoCrm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCrm.FormattingEnabled = true;
            this.cmbTipoCrm.Location = new System.Drawing.Point(153, 4);
            this.cmbTipoCrm.Name = "cmbTipoCrm";
            this.cmbTipoCrm.Size = new System.Drawing.Size(267, 24);
            this.cmbTipoCrm.TabIndex = 1004;
            this.cmbTipoCrm.SelectedIndexChanged += new System.EventHandler(this.cmbTipoCrm_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(477, 8);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(157, 17);
            this.lblStatus.TabIndex = 1001;
            this.lblStatus.Text = "Status do Compromisso";
            // 
            // GuardarCRM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(978, 749);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "GuardarCRM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compromisso";
            this.gpbAtendimento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.gpbPropostas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProposta)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlObservacao.ResumeLayout(false);
            this.pnlObservacao.PerformLayout();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCompromisso.ResumeLayout(false);
            this.pnlCompromisso.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox gpbAtendimento;
        private System.Windows.Forms.GroupBox gpbPropostas;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dgvProposta;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Label lblAtivo;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlObservacao;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Panel pnlCompromisso;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.Button btnAdicionarAgendamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorManut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContraPropVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContraPropManut;
        private System.Windows.Forms.DataGridViewImageColumn colAtende;
        private System.Windows.Forms.DataGridViewImageColumn colEditarProposta;
        private System.Windows.Forms.DataGridViewImageColumn colExcluirProposta;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.ComboBox cmbStatusCompromisso;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbTipoCrm;
        private System.Windows.Forms.Label lblTipoCrm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNivelAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSouResponsavel;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}