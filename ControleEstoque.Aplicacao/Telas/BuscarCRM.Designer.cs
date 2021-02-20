namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscarCRM
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpClientes = new System.Windows.Forms.TableLayoutPanel();
            this.gpbMarca = new System.Windows.Forms.GroupBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorRGB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefoneFixo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefoneCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncionarioCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colConsultar = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAtualizacao = new System.Windows.Forms.Label();
            this.chkBuscaAutomatica = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.gpbData = new System.Windows.Forms.GroupBox();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.lblFim = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblInicio = new System.Windows.Forms.Label();
            this.chkCriadoPorMim = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.gpbFuncionarioResponsavel = new System.Windows.Forms.GroupBox();
            this.lstFuncionario = new System.Windows.Forms.ListBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.ofdExcel = new System.Windows.Forms.OpenFileDialog();
            this.tmpBusca = new System.Windows.Forms.Timer(this.components);
            this.tlpClientes.SuspendLayout();
            this.gpbMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpbData.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.gpbFuncionarioResponsavel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.gpbMarca, 0, 1);
            this.tlpClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClientes.Location = new System.Drawing.Point(0, 0);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 2;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Size = new System.Drawing.Size(1193, 434);
            this.tlpClientes.TabIndex = 10;
            // 
            // gpbMarca
            // 
            this.gpbMarca.Controls.Add(this.dgvMarcas);
            this.gpbMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbMarca.Location = new System.Drawing.Point(4, 214);
            this.gpbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.gpbMarca.Name = "gpbMarca";
            this.gpbMarca.Padding = new System.Windows.Forms.Padding(4);
            this.gpbMarca.Size = new System.Drawing.Size(1185, 216);
            this.gpbMarca.TabIndex = 13;
            this.gpbMarca.TabStop = false;
            this.gpbMarca.Text = "Compromissos";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AllowUserToOrderColumns = true;
            this.dgvMarcas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colCorRGB,
            this.colCliente,
            this.colTelefoneFixo,
            this.colTelefoneCelular,
            this.colDescricao,
            this.colResponsavel,
            this.colFuncionarioCadastro,
            this.colEditar,
            this.colExcluir,
            this.colConsultar});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(4, 19);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(1177, 193);
            this.dgvMarcas.TabIndex = 14;
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
            // colCorRGB
            // 
            this.colCorRGB.HeaderText = "";
            this.colCorRGB.Name = "colCorRGB";
            this.colCorRGB.ReadOnly = true;
            this.colCorRGB.Width = 10;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCliente.Width = 130;
            // 
            // colTelefoneFixo
            // 
            this.colTelefoneFixo.HeaderText = "Fixo";
            this.colTelefoneFixo.Name = "colTelefoneFixo";
            this.colTelefoneFixo.ReadOnly = true;
            // 
            // colTelefoneCelular
            // 
            this.colTelefoneCelular.HeaderText = "Celular";
            this.colTelefoneCelular.Name = "colTelefoneCelular";
            this.colTelefoneCelular.ReadOnly = true;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescricao.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDescricao.FillWeight = 150F;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colResponsavel
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colResponsavel.DefaultCellStyle = dataGridViewCellStyle2;
            this.colResponsavel.HeaderText = "Responsavel";
            this.colResponsavel.Name = "colResponsavel";
            this.colResponsavel.ReadOnly = true;
            this.colResponsavel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colResponsavel.Width = 340;
            // 
            // colFuncionarioCadastro
            // 
            this.colFuncionarioCadastro.HeaderText = "Criado Por";
            this.colFuncionarioCadastro.Name = "colFuncionarioCadastro";
            this.colFuncionarioCadastro.ReadOnly = true;
            this.colFuncionarioCadastro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFuncionarioCadastro.Width = 120;
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
            // colConsultar
            // 
            this.colConsultar.HeaderText = "Consultar";
            this.colConsultar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.search_16;
            this.colConsultar.Name = "colConsultar";
            this.colConsultar.ReadOnly = true;
            this.colConsultar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colConsultar.Width = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAtualizacao);
            this.groupBox1.Controls.Add(this.chkBuscaAutomatica);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkAtivo);
            this.groupBox1.Controls.Add(this.gpbData);
            this.groupBox1.Controls.Add(this.chkCriadoPorMim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.grpCliente);
            this.groupBox1.Controls.Add(this.gpbFuncionarioResponsavel);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1185, 202);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // lblAtualizacao
            // 
            this.lblAtualizacao.AutoSize = true;
            this.lblAtualizacao.Location = new System.Drawing.Point(1000, 181);
            this.lblAtualizacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtualizacao.Name = "lblAtualizacao";
            this.lblAtualizacao.Size = new System.Drawing.Size(0, 17);
            this.lblAtualizacao.TabIndex = 1003;
            // 
            // chkBuscaAutomatica
            // 
            this.chkBuscaAutomatica.AutoSize = true;
            this.chkBuscaAutomatica.Location = new System.Drawing.Point(918, 181);
            this.chkBuscaAutomatica.Margin = new System.Windows.Forms.Padding(4);
            this.chkBuscaAutomatica.Name = "chkBuscaAutomatica";
            this.chkBuscaAutomatica.Size = new System.Drawing.Size(18, 17);
            this.chkBuscaAutomatica.TabIndex = 1001;
            this.chkBuscaAutomatica.UseVisualStyleBackColor = true;
            this.chkBuscaAutomatica.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(733, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 17);
            this.label3.TabIndex = 1002;
            this.label3.Text = "Habilitar Busca Automática";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Buscar Agendamentos Ativos";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAtivo.Location = new System.Drawing.Point(637, 176);
            this.chkAtivo.Margin = new System.Windows.Forms.Padding(4);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(18, 17);
            this.chkAtivo.TabIndex = 10;
            this.chkAtivo.ThreeState = true;
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // gpbData
            // 
            this.gpbData.Controls.Add(this.dtpFim);
            this.gpbData.Controls.Add(this.lblFim);
            this.gpbData.Controls.Add(this.dtpInicio);
            this.gpbData.Controls.Add(this.lblInicio);
            this.gpbData.Location = new System.Drawing.Point(736, 26);
            this.gpbData.Margin = new System.Windows.Forms.Padding(4);
            this.gpbData.Name = "gpbData";
            this.gpbData.Padding = new System.Windows.Forms.Padding(4);
            this.gpbData.Size = new System.Drawing.Size(333, 118);
            this.gpbData.TabIndex = 5;
            this.gpbData.TabStop = false;
            this.gpbData.Text = "Data";
            // 
            // dtpFim
            // 
            this.dtpFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFim.Location = new System.Drawing.Point(63, 68);
            this.dtpFim.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.ShowCheckBox = true;
            this.dtpFim.Size = new System.Drawing.Size(262, 22);
            this.dtpFim.TabIndex = 7;
            // 
            // lblFim
            // 
            this.lblFim.AutoSize = true;
            this.lblFim.Location = new System.Drawing.Point(9, 76);
            this.lblFim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFim.Name = "lblFim";
            this.lblFim.Size = new System.Drawing.Size(30, 17);
            this.lblFim.TabIndex = 4;
            this.lblFim.Text = "Fim";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(63, 36);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.ShowCheckBox = true;
            this.dtpInicio.Size = new System.Drawing.Size(262, 22);
            this.dtpInicio.TabIndex = 6;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(9, 44);
            this.lblInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(40, 17);
            this.lblInicio.TabIndex = 2;
            this.lblInicio.Text = "Início";
            // 
            // chkCriadoPorMim
            // 
            this.chkCriadoPorMim.AutoSize = true;
            this.chkCriadoPorMim.Location = new System.Drawing.Point(637, 151);
            this.chkCriadoPorMim.Margin = new System.Windows.Forms.Padding(4);
            this.chkCriadoPorMim.Name = "chkCriadoPorMim";
            this.chkCriadoPorMim.Size = new System.Drawing.Size(18, 17);
            this.chkCriadoPorMim.TabIndex = 9;
            this.chkCriadoPorMim.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 17);
            this.label1.TabIndex = 1000;
            this.label1.Text = "Buscar Agendamentos Criados Por Mim";
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lstClientes);
            this.grpCliente.Location = new System.Drawing.Point(374, 22);
            this.grpCliente.Margin = new System.Windows.Forms.Padding(4);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Padding = new System.Windows.Forms.Padding(4);
            this.grpCliente.Size = new System.Drawing.Size(354, 114);
            this.grpCliente.TabIndex = 3;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Clientes";
            // 
            // lstClientes
            // 
            this.lstClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 16;
            this.lstClientes.Location = new System.Drawing.Point(4, 19);
            this.lstClientes.Margin = new System.Windows.Forms.Padding(4);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstClientes.Size = new System.Drawing.Size(346, 91);
            this.lstClientes.TabIndex = 4;
            // 
            // gpbFuncionarioResponsavel
            // 
            this.gpbFuncionarioResponsavel.Controls.Add(this.lstFuncionario);
            this.gpbFuncionarioResponsavel.Location = new System.Drawing.Point(12, 26);
            this.gpbFuncionarioResponsavel.Margin = new System.Windows.Forms.Padding(4);
            this.gpbFuncionarioResponsavel.Name = "gpbFuncionarioResponsavel";
            this.gpbFuncionarioResponsavel.Padding = new System.Windows.Forms.Padding(4);
            this.gpbFuncionarioResponsavel.Size = new System.Drawing.Size(354, 114);
            this.gpbFuncionarioResponsavel.TabIndex = 1;
            this.gpbFuncionarioResponsavel.TabStop = false;
            this.gpbFuncionarioResponsavel.Text = "Agenda do Funcionário";
            // 
            // lstFuncionario
            // 
            this.lstFuncionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFuncionario.FormattingEnabled = true;
            this.lstFuncionario.ItemHeight = 16;
            this.lstFuncionario.Location = new System.Drawing.Point(4, 19);
            this.lstFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.lstFuncionario.Name = "lstFuncionario";
            this.lstFuncionario.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFuncionario.Size = new System.Drawing.Size(346, 91);
            this.lstFuncionario.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(85, 176);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(281, 22);
            this.txtNome.TabIndex = 8;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(13, 181);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Descrição";
            // 
            // tmpBusca
            // 
            this.tmpBusca.Interval = 1000;
            this.tmpBusca.Tick += new System.EventHandler(this.tmpBusca_Tick);
            // 
            // BuscarCRM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1199, 570);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "BuscarCRM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compromissos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpClientes.ResumeLayout(false);
            this.gpbMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbData.ResumeLayout(false);
            this.gpbData.PerformLayout();
            this.grpCliente.ResumeLayout(false);
            this.gpbFuncionarioResponsavel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox gpbMarca;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.GroupBox groupBox1;
       private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox gpbFuncionarioResponsavel;
        private System.Windows.Forms.ListBox lstFuncionario;
        private System.Windows.Forms.CheckBox chkCriadoPorMim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.GroupBox gpbData;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.OpenFileDialog ofdExcel;
        private System.Windows.Forms.Timer tmpBusca;
        private System.Windows.Forms.CheckBox chkBuscaAutomatica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAtualizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorRGB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefoneFixo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefoneCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncionarioCadastro;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.DataGridViewImageColumn colConsultar;
    }
}