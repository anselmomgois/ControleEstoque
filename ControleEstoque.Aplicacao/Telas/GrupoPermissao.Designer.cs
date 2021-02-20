namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GrupoPermissao
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
            this.tlpClientes = new System.Windows.Forms.TableLayoutPanel();
            this.gpbFiltro = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.gpbGrupo = new System.Windows.Forms.GroupBox();
            this.dgvGrupo = new System.Windows.Forms.DataGridView();
            this.colIdGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.gpbFiltro.SuspendLayout();
            this.gpbGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.gpbFiltro, 0, 0);
            this.tlpClientes.Controls.Add(this.gpbGrupo, 0, 1);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpClientes.Location = new System.Drawing.Point(0, 4);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 2;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Size = new System.Drawing.Size(1559, 579);
            this.tlpClientes.TabIndex = 7;
            // 
            // gpbFiltro
            // 
            this.gpbFiltro.Controls.Add(this.txtDescricao);
            this.gpbFiltro.Controls.Add(this.lblDescricao);
            this.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbFiltro.Location = new System.Drawing.Point(4, 4);
            this.gpbFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbFiltro.Name = "gpbFiltro";
            this.gpbFiltro.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbFiltro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpbFiltro.Size = new System.Drawing.Size(1551, 92);
            this.gpbFiltro.TabIndex = 0;
            this.gpbFiltro.TabStop = false;
            this.gpbFiltro.Text = "Filtro";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(93, 25);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(504, 22);
            this.txtDescricao.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 33);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(71, 17);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Descrição";
            // 
            // gpbGrupo
            // 
            this.gpbGrupo.Controls.Add(this.dgvGrupo);
            this.gpbGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbGrupo.Location = new System.Drawing.Point(4, 104);
            this.gpbGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbGrupo.Name = "gpbGrupo";
            this.gpbGrupo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbGrupo.Size = new System.Drawing.Size(1551, 471);
            this.gpbGrupo.TabIndex = 4;
            this.gpbGrupo.TabStop = false;
            this.gpbGrupo.Text = "Grupos";
            // 
            // dgvGrupo
            // 
            this.dgvGrupo.AllowUserToAddRows = false;
            this.dgvGrupo.AllowUserToDeleteRows = false;
            this.dgvGrupo.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdGrupo,
            this.colDescricao,
            this.colEditar,
            this.colExcluir});
            this.dgvGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrupo.Location = new System.Drawing.Point(4, 19);
            this.dgvGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGrupo.Name = "dgvGrupo";
            this.dgvGrupo.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrupo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrupo.Size = new System.Drawing.Size(1543, 448);
            this.dgvGrupo.TabIndex = 5;
            this.dgvGrupo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupo_CellContentClick);
            this.dgvGrupo.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrupo_CellMouseMove);
            // 
            // colIdGrupo
            // 
            this.colIdGrupo.HeaderText = "Column1";
            this.colIdGrupo.Name = "colIdGrupo";
            this.colIdGrupo.ReadOnly = true;
            this.colIdGrupo.Visible = false;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GrupoPermissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 759);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.pnlBase.Controls.Add(tlpClientes);
            this.Name = "GrupoPermissao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grupos de Permissão";
            this.tlpClientes.ResumeLayout(false);
            this.gpbFiltro.ResumeLayout(false);
            this.gpbFiltro.PerformLayout();
            this.gpbGrupo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox gpbFiltro;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.GroupBox gpbGrupo;
        private System.Windows.Forms.DataGridView dgvGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}