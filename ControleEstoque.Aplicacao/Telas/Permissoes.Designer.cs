namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class Permissoes
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
            this.gpbPermissoes = new System.Windows.Forms.GroupBox();
            this.tlpControles = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPermissoes = new System.Windows.Forms.DataGridView();
            this.colPermissoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsultar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInserir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colModificar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDeletar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlDrowGrupo = new System.Windows.Forms.Panel();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.ddlGrupo = new System.Windows.Forms.ComboBox();
            this.pnlTxtGrupo = new System.Windows.Forms.Panel();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lblNomeGrupo = new System.Windows.Forms.Label();
            this.gpbPermissoes.SuspendLayout();
            this.tlpControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissoes)).BeginInit();
            this.pnlDrowGrupo.SuspendLayout();
            this.pnlTxtGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPermissoes
            // 
            this.gpbPermissoes.Controls.Add(this.tlpControles);
            this.gpbPermissoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbPermissoes.Location = new System.Drawing.Point(0, 0);
            this.gpbPermissoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbPermissoes.Name = "gpbPermissoes";
            this.gpbPermissoes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbPermissoes.Size = new System.Drawing.Size(1559, 623);
            this.gpbPermissoes.TabIndex = 0;
            this.gpbPermissoes.TabStop = false;
            this.gpbPermissoes.Text = "Permissões";
            // 
            // tlpControles
            // 
            this.tlpControles.ColumnCount = 1;
            this.tlpControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControles.Controls.Add(this.dgvPermissoes, 0, 2);
            this.tlpControles.Controls.Add(this.pnlDrowGrupo, 0, 1);
            this.tlpControles.Controls.Add(this.pnlTxtGrupo, 0, 0);
            this.tlpControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControles.Location = new System.Drawing.Point(4, 19);
            this.tlpControles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpControles.Name = "tlpControles";
            this.tlpControles.RowCount = 3;
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControles.Size = new System.Drawing.Size(1551, 600);
            this.tlpControles.TabIndex = 0;
            // 
            // dgvPermissoes
            // 
            this.dgvPermissoes.AllowUserToAddRows = false;
            this.dgvPermissoes.AllowUserToDeleteRows = false;
            this.dgvPermissoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPermissoes,
            this.colIdentificador,
            this.colConsultar,
            this.colInserir,
            this.colModificar,
            this.colDeletar});
            this.dgvPermissoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPermissoes.Location = new System.Drawing.Point(4, 102);
            this.dgvPermissoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPermissoes.Name = "dgvPermissoes";
            this.dgvPermissoes.ReadOnly = true;
            this.dgvPermissoes.Size = new System.Drawing.Size(1543, 494);
            this.dgvPermissoes.TabIndex = 3;
            this.dgvPermissoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermissoes_CellContentClick);
            this.dgvPermissoes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPermissoes_CellPainting);
            // 
            // colPermissoes
            // 
            this.colPermissoes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPermissoes.HeaderText = "Permissoes";
            this.colPermissoes.Name = "colPermissoes";
            this.colPermissoes.ReadOnly = true;
            this.colPermissoes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colIdentificador
            // 
            this.colIdentificador.HeaderText = "Column1";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            this.colIdentificador.Visible = false;
            // 
            // colConsultar
            // 
            this.colConsultar.HeaderText = "Consultar";
            this.colConsultar.Name = "colConsultar";
            this.colConsultar.ReadOnly = true;
            this.colConsultar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colInserir
            // 
            this.colInserir.HeaderText = "Inserir";
            this.colInserir.Name = "colInserir";
            this.colInserir.ReadOnly = true;
            this.colInserir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colModificar
            // 
            this.colModificar.HeaderText = "Modificar";
            this.colModificar.Name = "colModificar";
            this.colModificar.ReadOnly = true;
            this.colModificar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDeletar
            // 
            this.colDeletar.HeaderText = "Deletar";
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.ReadOnly = true;
            this.colDeletar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pnlDrowGrupo
            // 
            this.pnlDrowGrupo.Controls.Add(this.lblGrupo);
            this.pnlDrowGrupo.Controls.Add(this.ddlGrupo);
            this.pnlDrowGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDrowGrupo.Location = new System.Drawing.Point(4, 53);
            this.pnlDrowGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDrowGrupo.Name = "pnlDrowGrupo";
            this.pnlDrowGrupo.Size = new System.Drawing.Size(1543, 41);
            this.pnlDrowGrupo.TabIndex = 12;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.BackColor = System.Drawing.Color.Transparent;
            this.lblGrupo.Location = new System.Drawing.Point(4, 14);
            this.lblGrupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(48, 17);
            this.lblGrupo.TabIndex = 10;
            this.lblGrupo.Text = "Grupo";
            // 
            // ddlGrupo
            // 
            this.ddlGrupo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ddlGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlGrupo.FormattingEnabled = true;
            this.ddlGrupo.Location = new System.Drawing.Point(60, 4);
            this.ddlGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlGrupo.Name = "ddlGrupo";
            this.ddlGrupo.Size = new System.Drawing.Size(371, 24);
            this.ddlGrupo.TabIndex = 2;
            this.ddlGrupo.SelectedIndexChanged += new System.EventHandler(this.ddlGrupo_SelectedIndexChanged);
            // 
            // pnlTxtGrupo
            // 
            this.pnlTxtGrupo.Controls.Add(this.txtGrupo);
            this.pnlTxtGrupo.Controls.Add(this.lblNomeGrupo);
            this.pnlTxtGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTxtGrupo.Location = new System.Drawing.Point(4, 4);
            this.pnlTxtGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTxtGrupo.Name = "pnlTxtGrupo";
            this.pnlTxtGrupo.Size = new System.Drawing.Size(1543, 41);
            this.pnlTxtGrupo.TabIndex = 13;
            // 
            // txtGrupo
            // 
            this.txtGrupo.ForeColor = System.Drawing.Color.Black;
            this.txtGrupo.Location = new System.Drawing.Point(121, 11);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGrupo.MaxLength = 50;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(309, 22);
            this.txtGrupo.TabIndex = 1;
            // 
            // lblNomeGrupo
            // 
            this.lblNomeGrupo.AutoSize = true;
            this.lblNomeGrupo.BackColor = System.Drawing.Color.Transparent;
            this.lblNomeGrupo.Location = new System.Drawing.Point(4, 20);
            this.lblNomeGrupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeGrupo.Name = "lblNomeGrupo";
            this.lblNomeGrupo.Size = new System.Drawing.Size(109, 17);
            this.lblNomeGrupo.TabIndex = 11;
            this.lblNomeGrupo.Text = "Nome do Grupo";
            // 
            // Permissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 759);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Permissoes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Permissoes";
            this.gpbPermissoes.ResumeLayout(false);
            this.tlpControles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissoes)).EndInit();
            this.pnlDrowGrupo.ResumeLayout(false);
            this.pnlDrowGrupo.PerformLayout();
            this.pnlTxtGrupo.ResumeLayout(false);
            this.pnlTxtGrupo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPermissoes;
        private System.Windows.Forms.TableLayoutPanel tlpControles;
        private System.Windows.Forms.DataGridView dgvPermissoes;
        private System.Windows.Forms.Panel pnlDrowGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox ddlGrupo;
        private System.Windows.Forms.Panel pnlTxtGrupo;
        private System.Windows.Forms.Label lblNomeGrupo;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPermissoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colConsultar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInserir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colModificar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDeletar;
    }
}