namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoCompraEstoqueAtual
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
            this.gpbClientes = new System.Windows.Forms.GroupBox();
            this.dgvCores = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdutoFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueAtual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCodigoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbClientes
            // 
            this.gpbClientes.Controls.Add(this.dgvCores);
            this.gpbClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbClientes.Location = new System.Drawing.Point(0, 0);
            this.gpbClientes.Margin = new System.Windows.Forms.Padding(4);
            this.gpbClientes.Name = "gpbClientes";
            this.gpbClientes.Padding = new System.Windows.Forms.Padding(4);
            this.gpbClientes.Size = new System.Drawing.Size(1013, 378);
            this.gpbClientes.TabIndex = 5;
            this.gpbClientes.TabStop = false;
            this.gpbClientes.Text = "Integrações";
            // 
            // dgvCores
            // 
            this.dgvCores.AllowUserToAddRows = false;
            this.dgvCores.AllowUserToDeleteRows = false;
            this.dgvCores.AllowUserToOrderColumns = true;
            this.dgvCores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colProdutoFilial,
            this.colEstoqueAtual,
            this.colCodigoCompra,
            this.colDataCompra,
            this.colDataVencimento,
            this.colLote,
            this.colEstoque});
            this.dgvCores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCores.Location = new System.Drawing.Point(4, 19);
            this.dgvCores.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCores.Name = "dgvCores";
            this.dgvCores.ReadOnly = true;
            this.dgvCores.Size = new System.Drawing.Size(1005, 355);
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
            // colProdutoFilial
            // 
            this.colProdutoFilial.HeaderText = "Column1";
            this.colProdutoFilial.Name = "colProdutoFilial";
            this.colProdutoFilial.ReadOnly = true;
            this.colProdutoFilial.Visible = false;
            // 
            // colEstoqueAtual
            // 
            this.colEstoqueAtual.HeaderText = "Estoque  Atual";
            this.colEstoqueAtual.Name = "colEstoqueAtual";
            this.colEstoqueAtual.ReadOnly = true;
            this.colEstoqueAtual.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEstoqueAtual.Width = 70;
            // 
            // colCodigoCompra
            // 
            this.colCodigoCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCodigoCompra.HeaderText = "Cod. Compra";
            this.colCodigoCompra.Name = "colCodigoCompra";
            this.colCodigoCompra.ReadOnly = true;
            // 
            // colDataCompra
            // 
            this.colDataCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDataCompra.FillWeight = 120F;
            this.colDataCompra.HeaderText = "Data Compra";
            this.colDataCompra.Name = "colDataCompra";
            this.colDataCompra.ReadOnly = true;
            this.colDataCompra.Width = 120;
            // 
            // colDataVencimento
            // 
            this.colDataVencimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDataVencimento.FillWeight = 120F;
            this.colDataVencimento.HeaderText = "Vencimento";
            this.colDataVencimento.Name = "colDataVencimento";
            this.colDataVencimento.ReadOnly = true;
            this.colDataVencimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDataVencimento.Width = 120;
            // 
            // colLote
            // 
            this.colLote.HeaderText = "Lote";
            this.colLote.Name = "colLote";
            this.colLote.ReadOnly = true;
            this.colLote.Width = 50;
            // 
            // colEstoque
            // 
            this.colEstoque.HeaderText = "Estoque";
            this.colEstoque.Name = "colEstoque";
            this.colEstoque.ReadOnly = true;
            this.colEstoque.Width = 70;
            // 
            // GuardarProdutoCompraEstoqueAtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 514);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "GuardarProdutoCompraEstoqueAtual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estoque Atual";
            this.gpbClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).EndInit();
            this.ResumeLayout(false);
            
        }

        #endregion

        private System.Windows.Forms.GroupBox gpbClientes;
        private System.Windows.Forms.DataGridView dgvCores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdutoFilial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEstoqueAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoque;
    }
}