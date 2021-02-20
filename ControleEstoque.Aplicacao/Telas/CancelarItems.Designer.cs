namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class CancelarItems
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
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.colChkProduto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.lblBuscarProduto = new System.Windows.Forms.Label();
            this.tlpGeral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 1;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Controls.Add(this.dgvProdutos, 0, 1);
            this.tlpGeral.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 2;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGeral.Size = new System.Drawing.Size(763, 314);
            this.tlpGeral.TabIndex = 0;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
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
            this.dgvProdutos.Location = new System.Drawing.Point(0, 40);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(763, 274);
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
            this.colSequencia.Width = 40;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 60;
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
            this.colQuantidade.HeaderText = "Qtd";
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.ReadOnly = true;
            this.colQuantidade.Width = 60;
            // 
            // colValor
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 80;
            // 
            // colValorTotal
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.colValorTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.colValorTotal.HeaderText = "Valor Total";
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtBuscarProduto, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBuscarProduto, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(757, 34);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBuscarProduto.Location = new System.Drawing.Point(294, 6);
            this.txtBuscarProduto.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarProduto.Name = "txtBuscarProduto";
            this.txtBuscarProduto.Size = new System.Drawing.Size(213, 22);
            this.txtBuscarProduto.TabIndex = 1003;
            this.txtBuscarProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarProduto_KeyDown);
            // 
            // lblBuscarProduto
            // 
            this.lblBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuscarProduto.AutoSize = true;
            this.lblBuscarProduto.Location = new System.Drawing.Point(4, 0);
            this.lblBuscarProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscarProduto.Name = "lblBuscarProduto";
            this.lblBuscarProduto.Size = new System.Drawing.Size(214, 34);
            this.lblBuscarProduto.TabIndex = 1002;
            this.lblBuscarProduto.Text = "Informe a sequência que deseja selecionar: ";
            this.lblBuscarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CancelarItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CancelarItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Items";
            this.tlpGeral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(tlpGeral);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBuscarProduto;
        private System.Windows.Forms.TextBox txtBuscarProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
    }
}