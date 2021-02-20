namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarTipoCrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarTipoCrm));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.gpbEtapas = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAcima = new System.Windows.Forms.Button();
            this.btnAbaixo = new System.Windows.Forms.Button();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbStatusPadrao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoStatus = new System.Windows.Forms.ComboBox();
            this.gpbEtapas.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpPrincipal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNome.Location = new System.Drawing.Point(154, 44);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(420, 22);
            this.txtNome.TabIndex = 2;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(4, 47);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(137, 17);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Descrição Tipo CRM";
            // 
            // gpbEtapas
            // 
            this.gpbEtapas.Controls.Add(this.tableLayoutPanel1);
            this.gpbEtapas.Location = new System.Drawing.Point(3, 123);
            this.gpbEtapas.Name = "gpbEtapas";
            this.gpbEtapas.Size = new System.Drawing.Size(1075, 165);
            this.gpbEtapas.TabIndex = 12;
            this.gpbEtapas.TabStop = false;
            this.gpbEtapas.Text = "Etapas";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMarcas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1069, 144);
            this.tableLayoutPanel1.TabIndex = 1002;
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AllowUserToOrderColumns = true;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colNivel,
            this.colDescricaoAtendimento,
            this.colEditar,
            this.colExcluir});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(4, 4);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.MultiSelect = false;
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarcas.Size = new System.Drawing.Size(1011, 136);
            this.dgvMarcas.TabIndex = 5;
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
            // colNivel
            // 
            this.colNivel.HeaderText = "Nivel";
            this.colNivel.Name = "colNivel";
            this.colNivel.ReadOnly = true;
            this.colNivel.Width = 200;
            // 
            // colDescricaoAtendimento
            // 
            this.colDescricaoAtendimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricaoAtendimento.HeaderText = "Descrição";
            this.colDescricaoAtendimento.Name = "colDescricaoAtendimento";
            this.colDescricaoAtendimento.ReadOnly = true;
            this.colDescricaoAtendimento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnAcima, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAbaixo, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1022, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(44, 138);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // btnAcima
            // 
            this.btnAcima.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAcima.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.arrow_up;
            this.btnAcima.Location = new System.Drawing.Point(6, 33);
            this.btnAcima.Name = "btnAcima";
            this.btnAcima.Size = new System.Drawing.Size(31, 33);
            this.btnAcima.TabIndex = 6;
            this.btnAcima.UseVisualStyleBackColor = true;
            this.btnAcima.Click += new System.EventHandler(this.btnAcima_Click);
            // 
            // btnAbaixo
            // 
            this.btnAbaixo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAbaixo.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.arrow_down;
            this.btnAbaixo.Location = new System.Drawing.Point(6, 72);
            this.btnAbaixo.Name = "btnAbaixo";
            this.btnAbaixo.Size = new System.Drawing.Size(31, 33);
            this.btnAbaixo.TabIndex = 7;
            this.btnAbaixo.UseVisualStyleBackColor = true;
            this.btnAbaixo.Click += new System.EventHandler(this.btnAbaixo_Click);
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.gpbEtapas, 0, 2);
            this.tlpPrincipal.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpPrincipal.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(1081, 291);
            this.tlpPrincipal.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtNome, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblNome, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCodigo, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1075, 74);
            this.tableLayoutPanel2.TabIndex = 1000;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Código Tipo CRM";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCodigo.Location = new System.Drawing.Point(153, 7);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(125, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel4.Controls.Add(this.cmbStatusPadrao, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbTipoStatus, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 83);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1075, 34);
            this.tableLayoutPanel4.TabIndex = 1001;
            // 
            // cmbStatusPadrao
            // 
            this.cmbStatusPadrao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbStatusPadrao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusPadrao.FormattingEnabled = true;
            this.cmbStatusPadrao.Location = new System.Drawing.Point(649, 4);
            this.cmbStatusPadrao.Name = "cmbStatusPadrao";
            this.cmbStatusPadrao.Size = new System.Drawing.Size(370, 24);
            this.cmbStatusPadrao.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status Padrão";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Status";
            // 
            // cmbTipoStatus
            // 
            this.cmbTipoStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoStatus.FormattingEnabled = true;
            this.cmbTipoStatus.Location = new System.Drawing.Point(153, 4);
            this.cmbTipoStatus.Name = "cmbTipoStatus";
            this.cmbTipoStatus.Size = new System.Drawing.Size(370, 24);
            this.cmbTipoStatus.TabIndex = 3;
            this.cmbTipoStatus.SelectedIndexChanged += new System.EventHandler(this.cmbTipoStatus_SelectedIndexChanged);
            // 
            // GuardarTipoCrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1087, 427);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarTipoCrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipo CRM";
            this.gpbEtapas.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tlpPrincipal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(tlpPrincipal);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox gpbEtapas;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoAtendimento;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnAcima;
        private System.Windows.Forms.Button btnAbaixo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoStatus;
        private System.Windows.Forms.ComboBox cmbStatusPadrao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
    }
}