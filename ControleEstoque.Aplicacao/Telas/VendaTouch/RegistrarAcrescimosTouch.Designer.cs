namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class RegistrarAcrescimosTouch
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
            this.gpbAcrescimos = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.colSequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdAgrupacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBuscarProduto = new System.Windows.Forms.Label();
            this.pnlTxtBuscaProduto = new System.Windows.Forms.Panel();
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvObservacoes = new System.Windows.Forms.DataGridView();
            this.colSelecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdentificadorObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSequenciaObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoObservacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSeqObservacao = new System.Windows.Forms.Panel();
            this.gpbAcrescimos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpGeral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservacoes)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbAcrescimos
            // 
            this.gpbAcrescimos.Controls.Add(this.tableLayoutPanel1);
            this.gpbAcrescimos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbAcrescimos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbAcrescimos.Location = new System.Drawing.Point(3, 3);
            this.gpbAcrescimos.Name = "gpbAcrescimos";
            this.gpbAcrescimos.Size = new System.Drawing.Size(638, 440);
            this.gpbAcrescimos.TabIndex = 1002;
            this.gpbAcrescimos.TabStop = false;
            this.gpbAcrescimos.Text = "Acrescimos";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvProdutos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequencia,
            this.colQtdAgrupacao,
            this.colCodigo,
            this.colDescricao,
            this.colQuantidade,
            this.colValor,
            this.colValorTotal});
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.Location = new System.Drawing.Point(5, 74);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(5);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(622, 336);
            this.dgvProdutos.TabIndex = 1000;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.SelectionChanged += new System.EventHandler(this.dgvProdutos_SelectionChanged);
            // 
            // colSequencia
            // 
            this.colSequencia.HeaderText = "Seq.";
            this.colSequencia.Name = "colSequencia";
            this.colSequencia.ReadOnly = true;
            this.colSequencia.Width = 80;
            // 
            // colQtdAgrupacao
            // 
            this.colQtdAgrupacao.HeaderText = "";
            this.colQtdAgrupacao.Name = "colQtdAgrupacao";
            this.colQtdAgrupacao.ReadOnly = true;
            this.colQtdAgrupacao.Visible = false;
            this.colQtdAgrupacao.Width = 5;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 80;
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
            this.colQuantidade.Width = 70;
            // 
            // colValor
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel3.Controls.Add(this.lblBuscarProduto, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pnlTxtBuscaProduto, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(626, 63);
            this.tableLayoutPanel3.TabIndex = 1001;
            // 
            // lblBuscarProduto
            // 
            this.lblBuscarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscarProduto.AutoSize = true;
            this.lblBuscarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProduto.Location = new System.Drawing.Point(4, 13);
            this.lblBuscarProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscarProduto.Name = "lblBuscarProduto";
            this.lblBuscarProduto.Size = new System.Drawing.Size(204, 36);
            this.lblBuscarProduto.TabIndex = 1001;
            this.lblBuscarProduto.Text = " Informe a Sequência \r\n que deseja selecionar:";
            // 
            // pnlTxtBuscaProduto
            // 
            this.pnlTxtBuscaProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTxtBuscaProduto.Location = new System.Drawing.Point(215, 3);
            this.pnlTxtBuscaProduto.Name = "pnlTxtBuscaProduto";
            this.pnlTxtBuscaProduto.Size = new System.Drawing.Size(260, 57);
            this.pnlTxtBuscaProduto.TabIndex = 1002;
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 2;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.97436F));
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.02564F));
            this.tlpGeral.Controls.Add(this.groupBox1, 0, 0);
            this.tlpGeral.Controls.Add(this.gpbAcrescimos, 0, 0);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Margin = new System.Windows.Forms.Padding(4);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 1;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Size = new System.Drawing.Size(1092, 446);
            this.tlpGeral.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(647, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 440);
            this.groupBox1.TabIndex = 1003;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Observações";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvObservacoes, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(436, 415);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvObservacoes
            // 
            this.dgvObservacoes.AllowUserToAddRows = false;
            this.dgvObservacoes.AllowUserToDeleteRows = false;
            this.dgvObservacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObservacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecionar,
            this.colIdentificadorObservacao,
            this.colSequenciaObservacao,
            this.colDescricaoObservacao});
            this.dgvObservacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObservacoes.Location = new System.Drawing.Point(5, 74);
            this.dgvObservacoes.Margin = new System.Windows.Forms.Padding(5);
            this.dgvObservacoes.Name = "dgvObservacoes";
            this.dgvObservacoes.ReadOnly = true;
            this.dgvObservacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObservacoes.Size = new System.Drawing.Size(426, 336);
            this.dgvObservacoes.TabIndex = 1000;
            this.dgvObservacoes.TabStop = false;
            // 
            // colSelecionar
            // 
            this.colSelecionar.HeaderText = "";
            this.colSelecionar.Name = "colSelecionar";
            this.colSelecionar.ReadOnly = true;
            this.colSelecionar.Width = 30;
            // 
            // colIdentificadorObservacao
            // 
            this.colIdentificadorObservacao.HeaderText = "Column1";
            this.colIdentificadorObservacao.Name = "colIdentificadorObservacao";
            this.colIdentificadorObservacao.ReadOnly = true;
            this.colIdentificadorObservacao.Visible = false;
            // 
            // colSequenciaObservacao
            // 
            this.colSequenciaObservacao.HeaderText = "Seq.";
            this.colSequenciaObservacao.Name = "colSequenciaObservacao";
            this.colSequenciaObservacao.ReadOnly = true;
            this.colSequenciaObservacao.Width = 80;
            // 
            // colDescricaoObservacao
            // 
            this.colDescricaoObservacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricaoObservacao.HeaderText = "Descrição";
            this.colDescricaoObservacao.Name = "colDescricaoObservacao";
            this.colDescricaoObservacao.ReadOnly = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pnlSeqObservacao, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(430, 63);
            this.tableLayoutPanel4.TabIndex = 1001;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 36);
            this.label1.TabIndex = 1001;
            this.label1.Text = " Informe a Sequência \r\n que deseja selecionar:";
            // 
            // pnlSeqObservacao
            // 
            this.pnlSeqObservacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeqObservacao.Location = new System.Drawing.Point(173, 3);
            this.pnlSeqObservacao.Name = "pnlSeqObservacao";
            this.pnlSeqObservacao.Size = new System.Drawing.Size(254, 57);
            this.pnlSeqObservacao.TabIndex = 1002;
            // 
            // RegistrarAcrescimosTouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 582);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "RegistrarAcrescimosTouch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Acrescimo Touch";
            this.gpbAcrescimos.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tlpGeral.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservacoes)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbAcrescimos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label lblBuscarProduto;
        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdAgrupacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvObservacoes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorObservacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequenciaObservacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoObservacao;
        private System.Windows.Forms.Panel pnlTxtBuscaProduto;
        private System.Windows.Forms.Panel pnlSeqObservacao;
    }
}