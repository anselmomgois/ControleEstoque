namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class DiferencasFecharCaixa
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colFormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorRecebido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiferenca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMarcas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(849, 314);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diferenças";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFormaPagamento,
            this.colValorRecebido,
            this.colValorPago,
            this.colDiferenca});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(3, 17);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(843, 295);
            this.dgvMarcas.TabIndex = 6;
            // 
            // colFormaPagamento
            // 
            this.colFormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFormaPagamento.HeaderText = "Forma Pagamento";
            this.colFormaPagamento.Name = "colFormaPagamento";
            this.colFormaPagamento.ReadOnly = true;
            this.colFormaPagamento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colValorRecebido
            // 
            this.colValorRecebido.HeaderText = "ValorRecebido";
            this.colValorRecebido.Name = "colValorRecebido";
            this.colValorRecebido.ReadOnly = true;
            this.colValorRecebido.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValorRecebido.Width = 150;
            // 
            // colValorPago
            // 
            this.colValorPago.HeaderText = "Valor Pago";
            this.colValorPago.Name = "colValorPago";
            this.colValorPago.ReadOnly = true;
            this.colValorPago.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValorPago.Width = 150;
            // 
            // colDiferenca
            // 
            this.colDiferenca.HeaderText = "Diferença";
            this.colDiferenca.Name = "colDiferenca";
            this.colDiferenca.ReadOnly = true;
            this.colDiferenca.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDiferenca.Width = 150;
            // 
            // DiferencasFecharCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "DiferencasFecharCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diferenças";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(groupBox1);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorRecebido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiferenca;
    }
}