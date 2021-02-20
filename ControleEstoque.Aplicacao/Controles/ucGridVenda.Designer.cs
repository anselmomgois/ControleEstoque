namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    partial class ucGridVenda
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcrescimoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.dgvMarcas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1221, 665);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens Registrados";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AllowUserToOrderColumns = true;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colItem,
            this.colCodigo,
            this.colCodigoBarras,
            this.colDescricao,
            this.colQuantidade,
            this.colValor,
            this.colDesconto,
            this.colAcrescimo,
            this.colDescontoTotal,
            this.colAcrescimoTotal,
            this.colValorTotal});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(3, 17);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(1215, 646);
            this.dgvMarcas.TabIndex = 6;
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colItem
            // 
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            this.colItem.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colItem.Width = 35;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigo.Width = 50;
            // 
            // colCodigoBarras
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoBarras.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCodigoBarras.HeaderText = "Codigo Barras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            this.colCodigoBarras.ReadOnly = true;
            this.colCodigoBarras.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigoBarras.Width = 150;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colQuantidade
            // 
            this.colQuantidade.HeaderText = "Quantidade";
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.ReadOnly = true;
            this.colQuantidade.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQuantidade.Width = 70;
            // 
            // colValor
            // 
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValor.Width = 70;
            // 
            // colDesconto
            // 
            this.colDesconto.HeaderText = "Desconto";
            this.colDesconto.Name = "colDesconto";
            this.colDesconto.ReadOnly = true;
            this.colDesconto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDesconto.Width = 70;
            // 
            // colAcrescimo
            // 
            this.colAcrescimo.HeaderText = "Acrescimo";
            this.colAcrescimo.Name = "colAcrescimo";
            this.colAcrescimo.ReadOnly = true;
            this.colAcrescimo.Width = 70;
            // 
            // colDescontoTotal
            // 
            this.colDescontoTotal.HeaderText = "Desc. T.";
            this.colDescontoTotal.Name = "colDescontoTotal";
            this.colDescontoTotal.ReadOnly = true;
            this.colDescontoTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDescontoTotal.Width = 75;
            // 
            // colAcrescimoTotal
            // 
            this.colAcrescimoTotal.HeaderText = "Acr. T.";
            this.colAcrescimoTotal.Name = "colAcrescimoTotal";
            this.colAcrescimoTotal.ReadOnly = true;
            this.colAcrescimoTotal.Width = 75;
            // 
            // colValorTotal
            // 
            this.colValorTotal.HeaderText = "Sub T.";
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.ReadOnly = true;
            this.colValorTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValorTotal.Width = 75;
            // 
            // ucGridVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucGridVenda";
            this.Size = new System.Drawing.Size(1221, 665);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescontoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcrescimoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
    }
}
