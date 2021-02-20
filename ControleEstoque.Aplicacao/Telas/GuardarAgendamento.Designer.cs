namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarAgendamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblData = new System.Windows.Forms.Label();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.lblGrupoSelecionado = new System.Windows.Forms.Label();
            this.trvNivelAtendimento = new System.Windows.Forms.TreeView();
            this.lblNivelAtentidimento = new System.Windows.Forms.Label();
            this.gpbPerguntas = new System.Windows.Forms.GroupBox();
            this.dgvPerguntas = new System.Windows.Forms.DataGridView();
            this.colIdentificadorPergunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPergunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResposta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarResposta = new System.Windows.Forms.DataGridViewImageColumn();
            this.colLimparResposta = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlControle = new System.Windows.Forms.Panel();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lstFuncionarios = new System.Windows.Forms.ListBox();
            this.cachedRelatorioFuncionario1 = new Informatiz.ControleEstoque.Aplicacao.Report.CachedRelatorioFuncionario();
            this.gpbPerguntas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(193, 144);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(203, 22);
            this.dtpInicio.TabIndex = 3;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(28, 151);
            this.lblData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(74, 17);
            this.lblData.TabIndex = 1000;
            this.lblData.Text = "Data Inicio";
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Location = new System.Drawing.Point(27, 89);
            this.lblFuncionario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(82, 17);
            this.lblFuncionario.TabIndex = 1000;
            this.lblFuncionario.Text = "Funcionario";
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFim.Location = new System.Drawing.Point(193, 175);
            this.dtpDataFim.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(203, 22);
            this.dtpDataFim.TabIndex = 4;
            this.dtpDataFim.ValueChanged += new System.EventHandler(this.dtpDataFim_ValueChanged);
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(28, 183);
            this.lblDataFim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(64, 17);
            this.lblDataFim.TabIndex = 1000;
            this.lblDataFim.Text = "Data Fim";
            // 
            // lblGrupoSelecionado
            // 
            this.lblGrupoSelecionado.AutoSize = true;
            this.lblGrupoSelecionado.Location = new System.Drawing.Point(189, 347);
            this.lblGrupoSelecionado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrupoSelecionado.Name = "lblGrupoSelecionado";
            this.lblGrupoSelecionado.Size = new System.Drawing.Size(16, 17);
            this.lblGrupoSelecionado.TabIndex = 1029;
            this.lblGrupoSelecionado.Text = "1";
            // 
            // trvNivelAtendimento
            // 
            this.trvNivelAtendimento.HideSelection = false;
            this.trvNivelAtendimento.HotTracking = true;
            this.trvNivelAtendimento.Location = new System.Drawing.Point(193, 204);
            this.trvNivelAtendimento.Margin = new System.Windows.Forms.Padding(4);
            this.trvNivelAtendimento.Name = "trvNivelAtendimento";
            this.trvNivelAtendimento.Size = new System.Drawing.Size(419, 138);
            this.trvNivelAtendimento.TabIndex = 5;
            this.trvNivelAtendimento.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvNivelAtendimento_AfterSelect);
            // 
            // lblNivelAtentidimento
            // 
            this.lblNivelAtentidimento.AutoSize = true;
            this.lblNivelAtentidimento.Location = new System.Drawing.Point(28, 326);
            this.lblNivelAtentidimento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNivelAtentidimento.Name = "lblNivelAtentidimento";
            this.lblNivelAtentidimento.Size = new System.Drawing.Size(142, 17);
            this.lblNivelAtentidimento.TabIndex = 1027;
            this.lblNivelAtentidimento.Text = "Nivel do Atendimento";
            // 
            // gpbPerguntas
            // 
            this.gpbPerguntas.Controls.Add(this.dgvPerguntas);
            this.gpbPerguntas.Location = new System.Drawing.Point(25, 367);
            this.gpbPerguntas.Margin = new System.Windows.Forms.Padding(4);
            this.gpbPerguntas.Name = "gpbPerguntas";
            this.gpbPerguntas.Padding = new System.Windows.Forms.Padding(4);
            this.gpbPerguntas.Size = new System.Drawing.Size(591, 226);
            this.gpbPerguntas.TabIndex = 6;
            this.gpbPerguntas.TabStop = false;
            this.gpbPerguntas.Text = "Perguntas Importantes";
            // 
            // dgvPerguntas
            // 
            this.dgvPerguntas.AllowUserToAddRows = false;
            this.dgvPerguntas.AllowUserToDeleteRows = false;
            this.dgvPerguntas.AllowUserToOrderColumns = true;
            this.dgvPerguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificadorPergunta,
            this.colPergunta,
            this.colResposta,
            this.colEditarResposta,
            this.colLimparResposta});
            this.dgvPerguntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerguntas.Location = new System.Drawing.Point(4, 19);
            this.dgvPerguntas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPerguntas.Name = "dgvPerguntas";
            this.dgvPerguntas.ReadOnly = true;
            this.dgvPerguntas.Size = new System.Drawing.Size(583, 203);
            this.dgvPerguntas.TabIndex = 7;
            this.dgvPerguntas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerguntas_CellContentClick);
            this.dgvPerguntas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPerguntas_CellMouseMove);
            // 
            // colIdentificadorPergunta
            // 
            this.colIdentificadorPergunta.HeaderText = "Column1";
            this.colIdentificadorPergunta.Name = "colIdentificadorPergunta";
            this.colIdentificadorPergunta.ReadOnly = true;
            this.colIdentificadorPergunta.Visible = false;
            // 
            // colPergunta
            // 
            this.colPergunta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colPergunta.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPergunta.HeaderText = "Pergunta";
            this.colPergunta.Name = "colPergunta";
            this.colPergunta.ReadOnly = true;
            this.colPergunta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colResposta
            // 
            this.colResposta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colResposta.DefaultCellStyle = dataGridViewCellStyle4;
            this.colResposta.HeaderText = "Resposta";
            this.colResposta.Name = "colResposta";
            this.colResposta.ReadOnly = true;
            this.colResposta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEditarResposta
            // 
            this.colEditarResposta.HeaderText = "Editar Resposta";
            this.colEditarResposta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditarResposta.Name = "colEditarResposta";
            this.colEditarResposta.ReadOnly = true;
            this.colEditarResposta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colLimparResposta
            // 
            this.colLimparResposta.HeaderText = "Limpar Resposta";
            this.colLimparResposta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.gnome_edit_clear;
            this.colLimparResposta.Name = "colLimparResposta";
            this.colLimparResposta.ReadOnly = true;
            this.colLimparResposta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pnlControle
            // 
            this.pnlControle.AutoScroll = true;
            this.pnlControle.Location = new System.Drawing.Point(626, 4);
            this.pnlControle.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControle.Name = "pnlControle";
            this.pnlControle.Size = new System.Drawing.Size(432, 589);
            this.pnlControle.TabIndex = 1032;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(193, 111);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(419, 22);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.TextChanged += new System.EventHandler(this.txtDescricao_TextChanged);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(28, 119);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(71, 17);
            this.lblDescricao.TabIndex = 1034;
            this.lblDescricao.Text = "Descrição";
            // 
            // lstFuncionarios
            // 
            this.lstFuncionarios.FormattingEnabled = true;
            this.lstFuncionarios.ItemHeight = 16;
            this.lstFuncionarios.Location = new System.Drawing.Point(193, 4);
            this.lstFuncionarios.Margin = new System.Windows.Forms.Padding(4);
            this.lstFuncionarios.Name = "lstFuncionarios";
            this.lstFuncionarios.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFuncionarios.Size = new System.Drawing.Size(419, 100);
            this.lstFuncionarios.TabIndex = 1;
            this.lstFuncionarios.SelectedIndexChanged += new System.EventHandler(this.lstFuncionarios_SelectedIndexChanged);
            // 
            // GuardarAgendamento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1069, 734);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarAgendamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agendamento";
            this.gpbPerguntas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerguntas)).EndInit();
            this.ResumeLayout(false);
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
        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.Label lblGrupoSelecionado;
        private System.Windows.Forms.TreeView trvNivelAtendimento;
        private System.Windows.Forms.Label lblNivelAtentidimento;
        private System.Windows.Forms.GroupBox gpbPerguntas;
        private System.Windows.Forms.DataGridView dgvPerguntas;
        private System.Windows.Forms.Panel pnlControle;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.ListBox lstFuncionarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorPergunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPergunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResposta;
        private System.Windows.Forms.DataGridViewImageColumn colEditarResposta;
        private System.Windows.Forms.DataGridViewImageColumn colLimparResposta;
        private Report.CachedRelatorioFuncionario cachedRelatorioFuncionario1;
    }
}