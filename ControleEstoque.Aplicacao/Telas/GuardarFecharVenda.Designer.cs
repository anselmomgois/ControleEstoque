namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarFecharVenda
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
            this.gpbFechamento = new System.Windows.Forms.GroupBox();
            this.tlpPagamento = new System.Windows.Forms.TableLayoutPanel();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpValorPagamento = new System.Windows.Forms.TableLayoutPanel();
            this.lblValor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtValorSelecionado = new System.Windows.Forms.Label();
            this.lblValorSelecionado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblValorRestante = new System.Windows.Forms.Label();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.colIdentificadorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChkPago = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colChkProduto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPago = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.lblBuscarProduto = new System.Windows.Forms.Label();
            this.pnlFuncionarios = new System.Windows.Forms.Panel();
            this.gpbFechamento.SuspendLayout();
            this.tlpPagamento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.tlpValorPagamento.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbFechamento
            // 
            this.gpbFechamento.Controls.Add(this.tlpPagamento);
            this.gpbFechamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbFechamento.Location = new System.Drawing.Point(0, 0);
            this.gpbFechamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbFechamento.Name = "gpbFechamento";
            this.gpbFechamento.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbFechamento.Size = new System.Drawing.Size(814, 513);
            this.gpbFechamento.TabIndex = 1;
            this.gpbFechamento.TabStop = false;
            this.gpbFechamento.Text = "Fechamento";
            // 
            // tlpPagamento
            // 
            this.tlpPagamento.ColumnCount = 1;
            this.tlpPagamento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPagamento.Controls.Add(this.pnlClientes, 0, 0);
            this.tlpPagamento.Controls.Add(this.groupBox1, 0, 5);
            this.tlpPagamento.Controls.Add(this.tlpValorPagamento, 0, 2);
            this.tlpPagamento.Controls.Add(this.tableLayoutPanel2, 0, 6);
            this.tlpPagamento.Controls.Add(this.groupBox2, 0, 4);
            this.tlpPagamento.Controls.Add(this.panel1, 0, 3);
            this.tlpPagamento.Controls.Add(this.pnlFuncionarios, 0, 1);
            this.tlpPagamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPagamento.Location = new System.Drawing.Point(3, 17);
            this.tlpPagamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpPagamento.Name = "tlpPagamento";
            this.tlpPagamento.RowCount = 7;
            this.tlpPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpPagamento.Size = new System.Drawing.Size(808, 494);
            this.tlpPagamento.TabIndex = 1;
            // 
            // pnlClientes
            // 
            this.pnlClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClientes.Location = new System.Drawing.Point(3, 2);
            this.pnlClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(802, 86);
            this.pnlClientes.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMarcas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 306);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(802, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pagamentos";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AllowUserToOrderColumns = true;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colFormaPagamento,
            this.colValor});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(3, 17);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(796, 127);
            this.dgvMarcas.TabIndex = 6;
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colFormaPagamento
            // 
            this.colFormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFormaPagamento.HeaderText = "Forma Pagamento";
            this.colFormaPagamento.Name = "colFormaPagamento";
            this.colFormaPagamento.ReadOnly = true;
            this.colFormaPagamento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colValor
            // 
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 200;
            // 
            // tlpValorPagamento
            // 
            this.tlpValorPagamento.ColumnCount = 3;
            this.tlpValorPagamento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tlpValorPagamento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tlpValorPagamento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpValorPagamento.Controls.Add(this.lblValor, 0, 1);
            this.tlpValorPagamento.Controls.Add(this.label1, 0, 0);
            this.tlpValorPagamento.Controls.Add(this.cmbFormaPagamento, 1, 0);
            this.tlpValorPagamento.Controls.Add(this.txtValor, 1, 1);
            this.tlpValorPagamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpValorPagamento.Location = new System.Drawing.Point(3, 182);
            this.tlpValorPagamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpValorPagamento.Name = "tlpValorPagamento";
            this.tlpValorPagamento.RowCount = 3;
            this.tlpValorPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpValorPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpValorPagamento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpValorPagamento.Size = new System.Drawing.Size(802, 53);
            this.tlpValorPagamento.TabIndex = 2;
            // 
            // lblValor
            // 
            this.lblValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(3, 36);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(41, 17);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma Pagamento";
            // 
            // cmbFormaPagamento
            // 
            this.cmbFormaPagamento.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPagamento.FormattingEnabled = true;
            this.cmbFormaPagamento.Location = new System.Drawing.Point(152, 1);
            this.cmbFormaPagamento.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.cmbFormaPagamento.Name = "cmbFormaPagamento";
            this.cmbFormaPagamento.Size = new System.Drawing.Size(244, 24);
            this.cmbFormaPagamento.TabIndex = 1;
            // 
            // txtValor
            // 
            this.txtValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtValor.Location = new System.Drawing.Point(152, 33);
            this.txtValor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(244, 22);
            this.txtValor.TabIndex = 3;
            this.txtValor.Enter += new System.EventHandler(this.txtValor_Enter);
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.txtValorSelecionado, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblValorSelecionado, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblValorRestante, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblValorPago, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 456);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(802, 36);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // txtValorSelecionado
            // 
            this.txtValorSelecionado.AutoSize = true;
            this.txtValorSelecionado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValorSelecionado.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorSelecionado.ForeColor = System.Drawing.Color.Black;
            this.txtValorSelecionado.Location = new System.Drawing.Point(123, 0);
            this.txtValorSelecionado.Name = "txtValorSelecionado";
            this.txtValorSelecionado.Size = new System.Drawing.Size(168, 36);
            this.txtValorSelecionado.TabIndex = 8;
            this.txtValorSelecionado.Text = "R$ 0,00";
            this.txtValorSelecionado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorSelecionado
            // 
            this.lblValorSelecionado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorSelecionado.AutoSize = true;
            this.lblValorSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSelecionado.Location = new System.Drawing.Point(3, 8);
            this.lblValorSelecionado.Name = "lblValorSelecionado";
            this.lblValorSelecionado.Size = new System.Drawing.Size(111, 20);
            this.lblValorSelecionado.TabIndex = 7;
            this.lblValorSelecionado.Text = "Selecionado";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(540, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Restante";
            // 
            // lblValorRestante
            // 
            this.lblValorRestante.AutoSize = true;
            this.lblValorRestante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValorRestante.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorRestante.ForeColor = System.Drawing.Color.Red;
            this.lblValorRestante.Location = new System.Drawing.Point(630, 0);
            this.lblValorRestante.Name = "lblValorRestante";
            this.lblValorRestante.Size = new System.Drawing.Size(169, 36);
            this.lblValorRestante.TabIndex = 6;
            this.lblValorRestante.Text = "R$ 0,00";
            // 
            // lblValorPago
            // 
            this.lblValorPago.AutoSize = true;
            this.lblValorPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValorPago.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblValorPago.Location = new System.Drawing.Point(366, 0);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(168, 36);
            this.lblValorPago.TabIndex = 5;
            this.lblValorPago.Text = "R$ 0,00";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(297, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pago";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvProdutos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 278);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(802, 24);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produtos Registrados";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificadorVenda,
            this.colChkPago,
            this.colChkProduto,
            this.colSequencia,
            this.colCodigo,
            this.colDescricao,
            this.colQuantidade,
            this.colValorProduto,
            this.colValorTotal,
            this.colPago});
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.Location = new System.Drawing.Point(3, 17);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(796, 5);
            this.dgvProdutos.TabIndex = 4;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
            this.dgvProdutos.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdutos_CellMouseMove);
            this.dgvProdutos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvProdutos_RowPostPaint);
            // 
            // colIdentificadorVenda
            // 
            this.colIdentificadorVenda.HeaderText = "Column1";
            this.colIdentificadorVenda.Name = "colIdentificadorVenda";
            this.colIdentificadorVenda.ReadOnly = true;
            this.colIdentificadorVenda.Visible = false;
            // 
            // colChkPago
            // 
            this.colChkPago.HeaderText = "Column1";
            this.colChkPago.Name = "colChkPago";
            this.colChkPago.ReadOnly = true;
            this.colChkPago.Visible = false;
            // 
            // colChkProduto
            // 
            this.colChkProduto.FillWeight = 40F;
            this.colChkProduto.HeaderText = "";
            this.colChkProduto.Name = "colChkProduto";
            this.colChkProduto.ReadOnly = true;
            this.colChkProduto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // colValorProduto
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colValorProduto.DefaultCellStyle = dataGridViewCellStyle1;
            this.colValorProduto.HeaderText = "Valor";
            this.colValorProduto.Name = "colValorProduto";
            this.colValorProduto.ReadOnly = true;
            this.colValorProduto.Width = 80;
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
            // colPago
            // 
            this.colPago.FillWeight = 50F;
            this.colPago.HeaderText = "Pago";
            this.colPago.Name = "colPago";
            this.colPago.ReadOnly = true;
            this.colPago.Width = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 237);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 39);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.txtBuscarProduto, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblBuscarProduto, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(808, 39);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBuscarProduto.Location = new System.Drawing.Point(304, 8);
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
            this.lblBuscarProduto.Location = new System.Drawing.Point(4, 11);
            this.lblBuscarProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscarProduto.Name = "lblBuscarProduto";
            this.lblBuscarProduto.Size = new System.Drawing.Size(287, 17);
            this.lblBuscarProduto.TabIndex = 1002;
            this.lblBuscarProduto.Text = "Informe a sequência que deseja selecionar: ";
            this.lblBuscarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFuncionarios
            // 
            this.pnlFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncionarios.Location = new System.Drawing.Point(3, 92);
            this.pnlFuncionarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFuncionarios.Name = "pnlFuncionarios";
            this.pnlFuncionarios.Size = new System.Drawing.Size(802, 86);
            this.pnlFuncionarios.TabIndex = 7;
            // 
            // GuardarFecharVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 649);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "GuardarFecharVenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fechamento";
            this.gpbFechamento.ResumeLayout(false);
            this.tlpPagamento.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.tlpValorPagamento.ResumeLayout(false);
            this.tlpValorPagamento.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(gpbFechamento);
            

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbFechamento;
        private System.Windows.Forms.TableLayoutPanel tlpPagamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.TableLayoutPanel tlpValorPagamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.ComboBox cmbFormaPagamento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblValorPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblValorRestante;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtBuscarProduto;
        private System.Windows.Forms.Label lblBuscarProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorVenda;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkPago;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
        private System.Windows.Forms.DataGridViewImageColumn colPago;
        private System.Windows.Forms.Panel pnlFuncionarios;
        private System.Windows.Forms.Label txtValorSelecionado;
        private System.Windows.Forms.Label lblValorSelecionado;
    }
}