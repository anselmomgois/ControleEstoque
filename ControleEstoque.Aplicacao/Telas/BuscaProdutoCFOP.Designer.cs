namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscaProdutoCFOP
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
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.gpbComissoes = new System.Windows.Forms.GroupBox();
            this.dgvComissoes = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoCFOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDesativar = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.grpFiltro.SuspendLayout();
            this.gpbComissoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComissoes)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.grpFiltro, 0, 0);
            this.tlpClientes.Controls.Add(this.gpbComissoes, 0, 1);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpClientes.Location = new System.Drawing.Point(0, 117);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 2;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Size = new System.Drawing.Size(1285, 652);
            this.tlpClientes.TabIndex = 13;
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.txtNome);
            this.grpFiltro.Controls.Add(this.lblNome);
            this.grpFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFiltro.Location = new System.Drawing.Point(4, 4);
            this.grpFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFiltro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpFiltro.Size = new System.Drawing.Size(1277, 90);
            this.grpFiltro.TabIndex = 0;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Filtro";
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
            // gpbComissoes
            // 
            this.gpbComissoes.Controls.Add(this.dgvComissoes);
            this.gpbComissoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbComissoes.Location = new System.Drawing.Point(4, 102);
            this.gpbComissoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbComissoes.Name = "gpbComissoes";
            this.gpbComissoes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbComissoes.Size = new System.Drawing.Size(1277, 546);
            this.gpbComissoes.TabIndex = 4;
            this.gpbComissoes.TabStop = false;
            this.gpbComissoes.Text = "Comissões";
            // 
            // dgvComissoes
            // 
            this.dgvComissoes.AllowUserToAddRows = false;
            this.dgvComissoes.AllowUserToDeleteRows = false;
            this.dgvComissoes.AllowUserToOrderColumns = true;
            this.dgvComissoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComissoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colCodigoCFOP,
            this.colDescricao,
            this.colEditar,
            this.colDesativar});
            this.dgvComissoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComissoes.Location = new System.Drawing.Point(4, 19);
            this.dgvComissoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvComissoes.Name = "dgvComissoes";
            this.dgvComissoes.ReadOnly = true;
            this.dgvComissoes.Size = new System.Drawing.Size(1269, 523);
            this.dgvComissoes.TabIndex = 5;
            this.dgvComissoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComissoes_CellContentClick);
            this.dgvComissoes.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvComissoes_CellMouseMove);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colCodigoCFOP
            // 
            this.colCodigoCFOP.HeaderText = "Código Fiscal";
            this.colCodigoCFOP.Name = "colCodigoCFOP";
            this.colCodigoCFOP.ReadOnly = true;
            this.colCodigoCFOP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigoCFOP.Width = 200;
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
            // colDesativar
            // 
            this.colDesativar.HeaderText = "Deletar";
            this.colDesativar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colDesativar.Name = "colDesativar";
            this.colDesativar.ReadOnly = true;
            this.colDesativar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BuscaProdutoCFOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 769);
            this.Controls.Add(this.tlpClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "BuscaProdutoCFOP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Código Fiscal de Operações e Prestações";
            this.Controls.SetChildIndex(this.tlpClientes, 0);
            this.tlpClientes.ResumeLayout(false);
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            this.gpbComissoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComissoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox gpbComissoes;
        private System.Windows.Forms.DataGridView dgvComissoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCFOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colDesativar;
    }
}