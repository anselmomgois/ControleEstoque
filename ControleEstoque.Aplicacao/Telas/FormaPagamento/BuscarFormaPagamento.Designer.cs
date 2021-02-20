namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscarFormaPagamento
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
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.gpbFormaPagamento = new System.Windows.Forms.GroupBox();
            this.dgvFormaPagamento = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpbFiltro = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.tlpGeral.SuspendLayout();
            this.gpbFormaPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormaPagamento)).BeginInit();
            this.gpbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 1;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Controls.Add(this.gpbFormaPagamento, 0, 1);
            this.tlpGeral.Controls.Add(this.gpbFiltro, 0, 0);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 2;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Size = new System.Drawing.Size(1195, 623);
            this.tlpGeral.TabIndex = 7;
            // 
            // gpbFormaPagamento
            // 
            this.gpbFormaPagamento.Controls.Add(this.dgvFormaPagamento);
            this.gpbFormaPagamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbFormaPagamento.Location = new System.Drawing.Point(4, 104);
            this.gpbFormaPagamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbFormaPagamento.Name = "gpbFormaPagamento";
            this.gpbFormaPagamento.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbFormaPagamento.Size = new System.Drawing.Size(1187, 515);
            this.gpbFormaPagamento.TabIndex = 5;
            this.gpbFormaPagamento.TabStop = false;
            this.gpbFormaPagamento.Text = "Formas de pagamento";
            // 
            // dgvFormaPagamento
            // 
            this.dgvFormaPagamento.AllowUserToAddRows = false;
            this.dgvFormaPagamento.AllowUserToDeleteRows = false;
            this.dgvFormaPagamento.AllowUserToOrderColumns = true;
            this.dgvFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormaPagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCodigo,
            this.colDescricao,
            this.colEditar,
            this.colExcluir});
            this.dgvFormaPagamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFormaPagamento.Location = new System.Drawing.Point(4, 19);
            this.dgvFormaPagamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvFormaPagamento.Name = "dgvFormaPagamento";
            this.dgvFormaPagamento.ReadOnly = true;
            this.dgvFormaPagamento.Size = new System.Drawing.Size(1179, 492);
            this.dgvFormaPagamento.TabIndex = 5;
            this.dgvFormaPagamento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormaPagamento_CellContentClick);
            this.dgvFormaPagamento.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFormaPagamento_CellMouseMove);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
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
            this.gpbFiltro.Size = new System.Drawing.Size(1187, 92);
            this.gpbFiltro.TabIndex = 1;
            this.gpbFiltro.TabStop = false;
            this.gpbFiltro.Text = "Filtro";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(91, 23);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(556, 22);
            this.txtDescricao.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(9, 32);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(71, 17);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Descrição";
            // 
            // BuscarFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 759);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "BuscarFormaPagamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formas de Pagamento";
            this.tlpGeral.ResumeLayout(false);
            this.gpbFormaPagamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormaPagamento)).EndInit();
            this.gpbFiltro.ResumeLayout(false);
            this.gpbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.GroupBox gpbFiltro;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.GroupBox gpbFormaPagamento;
        private System.Windows.Forms.DataGridView dgvFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}