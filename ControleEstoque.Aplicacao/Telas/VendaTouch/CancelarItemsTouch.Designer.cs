namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class CancelarItemsTouch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscarProduto = new System.Windows.Forms.Label();
            this.pnlTxtBuscaProduto = new System.Windows.Forms.Panel();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.colChkProduto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.tlpGeral.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 1;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpGeral.Controls.Add(this.dgvProdutos, 0, 1);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Margin = new System.Windows.Forms.Padding(2);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 2;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpGeral.Size = new System.Drawing.Size(843, 344);
            this.tlpGeral.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblBuscarProduto, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlTxtBuscaProduto, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(839, 56);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lblBuscarProduto
            // 
            this.lblBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuscarProduto.AutoSize = true;
            this.lblBuscarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProduto.Location = new System.Drawing.Point(3, 4);
            this.lblBuscarProduto.Name = "lblBuscarProduto";
            this.lblBuscarProduto.Size = new System.Drawing.Size(224, 48);
            this.lblBuscarProduto.TabIndex = 1002;
            this.lblBuscarProduto.Text = "Informe a sequência que deseja selecionar: ";
            this.lblBuscarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTxtBuscaProduto
            // 
            this.pnlTxtBuscaProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTxtBuscaProduto.Location = new System.Drawing.Point(280, 3);
            this.pnlTxtBuscaProduto.Name = "pnlTxtBuscaProduto";
            this.pnlTxtBuscaProduto.Size = new System.Drawing.Size(556, 50);
            this.pnlTxtBuscaProduto.TabIndex = 1003;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdutos.ColumnHeadersHeight = 55;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChkProduto,
            this.colSequencia,
            this.colCodigo,
            this.colDescricao,
            this.colQuantidade,
            this.colValor,
            this.colValorTotal});
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.Location = new System.Drawing.Point(0, 60);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(843, 284);
            this.dgvProdutos.TabIndex = 3;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
            this.dgvProdutos.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdutos_CellMouseMove);
            // 
            // colChkProduto
            // 
            this.colChkProduto.FillWeight = 40F;
            this.colChkProduto.HeaderText = "";
            this.colChkProduto.Name = "colChkProduto";
            this.colChkProduto.ReadOnly = true;
            this.colChkProduto.Width = 40;
            // 
            // colSequencia
            // 
            this.colSequencia.HeaderText = "Seq.";
            this.colSequencia.Name = "colSequencia";
            this.colSequencia.ReadOnly = true;
            this.colSequencia.Width = 50;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 70;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            // 
            // colQuantidade
            // 
            this.colQuantidade.HeaderText = "Qtd.";
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.ReadOnly = true;
            this.colQuantidade.Width = 60;
            // 
            // colValor
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle2;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 80;
            // 
            // colValorTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.colValorTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValorTotal.HeaderText = "Valor Total";
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.ReadOnly = true;
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBuscarProduto.Location = new System.Drawing.Point(221, 4);
            this.txtBuscarProduto.Name = "txtBuscarProduto";
            this.txtBuscarProduto.Size = new System.Drawing.Size(161, 20);
            this.txtBuscarProduto.TabIndex = 1003;
            this.txtBuscarProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProduto_KeyDown);
            // 
            // CancelarItemsTouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 510);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CancelarItemsTouch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Items";
            this.tlpGeral.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBuscarProduto;
        private System.Windows.Forms.TextBox txtBuscarProduto;
        private System.Windows.Forms.Panel pnlTxtBuscaProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
    }
}