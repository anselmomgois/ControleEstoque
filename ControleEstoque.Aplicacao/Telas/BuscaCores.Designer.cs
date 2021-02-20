namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscaCores
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
            this.tlpClientes = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.gpbClientes = new System.Windows.Forms.GroupBox();
            this.dgvCores = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tlpClientes.Controls.Add(this.gpbClientes, 0, 1);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpClientes.Location = new System.Drawing.Point(0, 122);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 2;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Size = new System.Drawing.Size(1537, 652);
            this.tlpClientes.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1528, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(91, 23);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(504, 22);
            this.txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 32);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Descrição";
            // 
            // gpbClientes
            // 
            this.gpbClientes.Controls.Add(this.dgvCores);
            this.gpbClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbClientes.Location = new System.Drawing.Point(4, 102);
            this.gpbClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbClientes.Name = "gpbClientes";
            this.gpbClientes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbClientes.Size = new System.Drawing.Size(1529, 546);
            this.gpbClientes.TabIndex = 4;
            this.gpbClientes.TabStop = false;
            this.gpbClientes.Text = "Cores";
            // 
            // dgvCores
            // 
            this.dgvCores.AllowUserToAddRows = false;
            this.dgvCores.AllowUserToDeleteRows = false;
            this.dgvCores.AllowUserToOrderColumns = true;
            this.dgvCores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colDescricao,
            this.colEditar,
            this.colExcluir});
            this.dgvCores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCores.Location = new System.Drawing.Point(4, 19);
            this.dgvCores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCores.Name = "dgvCores";
            this.dgvCores.ReadOnly = true;
            this.dgvCores.Size = new System.Drawing.Size(1521, 523);
            this.dgvCores.TabIndex = 5;
            this.dgvCores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCores_CellContentClick);
            this.dgvCores.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCores_CellMouseMove);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
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
            // BuscaCores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 774);
            this.Controls.Add(this.tlpClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "BuscaCores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cores";
            this.Controls.SetChildIndex(this.tlpClientes, 0);
            this.tlpClientes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox gpbClientes;
        private System.Windows.Forms.DataGridView dgvCores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}