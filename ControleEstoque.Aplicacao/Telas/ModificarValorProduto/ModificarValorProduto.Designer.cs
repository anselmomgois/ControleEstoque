namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class ModificarValorProduto
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
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.txtNovoValor = new System.Windows.Forms.TextBox();
            this.lblNovoValor = new System.Windows.Forms.Label();
            this.pnlPrecoPorcentagem = new System.Windows.Forms.Panel();
            this.tlpPrecoPorcentagem = new System.Windows.Forms.TableLayoutPanel();
            this.rbPorcentagem = new System.Windows.Forms.RadioButton();
            this.rbPreco = new System.Windows.Forms.RadioButton();
            this.pnlAcrescimoDesconto = new System.Windows.Forms.Panel();
            this.tlpAcrescimoDesconto = new System.Windows.Forms.TableLayoutPanel();
            this.rbAcrescimo = new System.Windows.Forms.RadioButton();
            this.rbDesconto = new System.Windows.Forms.RadioButton();
            this.rbValorUnitario = new System.Windows.Forms.RadioButton();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.lblBuscarProduto = new System.Windows.Forms.Label();
            this.tlpLegenda = new System.Windows.Forms.TableLayoutPanel();
            this.gpbLegenda = new System.Windows.Forms.GroupBox();
            this.tlpLegendasAtalho = new System.Windows.Forms.TableLayoutPanel();
            this.lblAtalhoAcrescimo = new System.Windows.Forms.Label();
            this.lblAtalhoDesconto = new System.Windows.Forms.Label();
            this.lblAtalhoValorUnitario = new System.Windows.Forms.Label();
            this.lblAtalhoPreco = new System.Windows.Forms.Label();
            this.lblAtalhoPorcentagem = new System.Windows.Forms.Label();
            this.lblAtalhoBuscarProduto = new System.Windows.Forms.Label();
            this.lblAtalhoNovoValor = new System.Windows.Forms.Label();
            this.colSequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdAgrupacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcentagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpGeral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.pnlPrecoPorcentagem.SuspendLayout();
            this.tlpPrecoPorcentagem.SuspendLayout();
            this.pnlAcrescimoDesconto.SuspendLayout();
            this.tlpAcrescimoDesconto.SuspendLayout();
            this.tlpLegenda.SuspendLayout();
            this.gpbLegenda.SuspendLayout();
            this.tlpLegendasAtalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 4;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.27541F));
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.72459F));
            this.tlpGeral.Controls.Add(this.dgvProdutos, 0, 1);
            this.tlpGeral.Controls.Add(this.txtNovoValor, 3, 2);
            this.tlpGeral.Controls.Add(this.lblNovoValor, 2, 2);
            this.tlpGeral.Controls.Add(this.pnlPrecoPorcentagem, 3, 0);
            this.tlpGeral.Controls.Add(this.pnlAcrescimoDesconto, 2, 0);
            this.tlpGeral.Controls.Add(this.txtBuscarProduto, 1, 0);
            this.tlpGeral.Controls.Add(this.lblBuscarProduto, 0, 0);
            this.tlpGeral.Controls.Add(this.tlpLegenda, 0, 2);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 3;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGeral.Size = new System.Drawing.Size(1092, 305);
            this.tlpGeral.TabIndex = 3;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToOrderColumns = true;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequencia,
            this.colQtdAgrupacao,
            this.colCodigo,
            this.colDescricao,
            this.colQuantidade,
            this.colAcrescimo,
            this.colDesconto,
            this.colPorcentagem,
            this.colValor,
            this.colValorTotal});
            this.tlpGeral.SetColumnSpan(this.dgvProdutos, 4);
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.Location = new System.Drawing.Point(4, 62);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(1084, 140);
            this.dgvProdutos.TabIndex = 1000;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.SelectionChanged += new System.EventHandler(this.dgvProdutos_SelectionChanged);
            // 
            // txtNovoValor
            // 
            this.txtNovoValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNovoValor.Location = new System.Drawing.Point(719, 245);
            this.txtNovoValor.Name = "txtNovoValor";
            this.txtNovoValor.Size = new System.Drawing.Size(173, 20);
            this.txtNovoValor.TabIndex = 99;
            this.txtNovoValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNovoValor_KeyPress);
            this.txtNovoValor.Leave += new System.EventHandler(this.txtNovoValor_Leave);
            // 
            // lblNovoValor
            // 
            this.lblNovoValor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNovoValor.AutoSize = true;
            this.lblNovoValor.Location = new System.Drawing.Point(647, 249);
            this.lblNovoValor.Name = "lblNovoValor";
            this.lblNovoValor.Size = new System.Drawing.Size(66, 13);
            this.lblNovoValor.TabIndex = 19;
            this.lblNovoValor.Text = "Novo Valor: ";
            // 
            // pnlPrecoPorcentagem
            // 
            this.pnlPrecoPorcentagem.Controls.Add(this.tlpPrecoPorcentagem);
            this.pnlPrecoPorcentagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrecoPorcentagem.Location = new System.Drawing.Point(719, 3);
            this.pnlPrecoPorcentagem.Name = "pnlPrecoPorcentagem";
            this.pnlPrecoPorcentagem.Size = new System.Drawing.Size(370, 52);
            this.pnlPrecoPorcentagem.TabIndex = 18;
            // 
            // tlpPrecoPorcentagem
            // 
            this.tlpPrecoPorcentagem.ColumnCount = 2;
            this.tlpPrecoPorcentagem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrecoPorcentagem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrecoPorcentagem.Controls.Add(this.rbPorcentagem, 0, 0);
            this.tlpPrecoPorcentagem.Controls.Add(this.rbPreco, 0, 0);
            this.tlpPrecoPorcentagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrecoPorcentagem.Location = new System.Drawing.Point(0, 0);
            this.tlpPrecoPorcentagem.Name = "tlpPrecoPorcentagem";
            this.tlpPrecoPorcentagem.RowCount = 1;
            this.tlpPrecoPorcentagem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrecoPorcentagem.Size = new System.Drawing.Size(370, 52);
            this.tlpPrecoPorcentagem.TabIndex = 0;
            // 
            // rbPorcentagem
            // 
            this.rbPorcentagem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbPorcentagem.AutoSize = true;
            this.rbPorcentagem.Location = new System.Drawing.Point(188, 17);
            this.rbPorcentagem.Name = "rbPorcentagem";
            this.rbPorcentagem.Size = new System.Drawing.Size(105, 17);
            this.rbPorcentagem.TabIndex = 5;
            this.rbPorcentagem.TabStop = true;
            this.rbPorcentagem.Text = "Porcentagem (%)";
            this.rbPorcentagem.UseVisualStyleBackColor = true;
            // 
            // rbPreco
            // 
            this.rbPreco.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbPreco.AutoSize = true;
            this.rbPreco.Location = new System.Drawing.Point(129, 17);
            this.rbPreco.Name = "rbPreco";
            this.rbPreco.Size = new System.Drawing.Size(53, 17);
            this.rbPreco.TabIndex = 4;
            this.rbPreco.TabStop = true;
            this.rbPreco.Text = "Preço";
            this.rbPreco.UseVisualStyleBackColor = true;
            // 
            // pnlAcrescimoDesconto
            // 
            this.pnlAcrescimoDesconto.Controls.Add(this.tlpAcrescimoDesconto);
            this.pnlAcrescimoDesconto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAcrescimoDesconto.Location = new System.Drawing.Point(382, 3);
            this.pnlAcrescimoDesconto.Name = "pnlAcrescimoDesconto";
            this.pnlAcrescimoDesconto.Size = new System.Drawing.Size(331, 52);
            this.pnlAcrescimoDesconto.TabIndex = 17;
            // 
            // tlpAcrescimoDesconto
            // 
            this.tlpAcrescimoDesconto.ColumnCount = 3;
            this.tlpAcrescimoDesconto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcrescimoDesconto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpAcrescimoDesconto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tlpAcrescimoDesconto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcrescimoDesconto.Controls.Add(this.rbAcrescimo, 0, 0);
            this.tlpAcrescimoDesconto.Controls.Add(this.rbDesconto, 1, 0);
            this.tlpAcrescimoDesconto.Controls.Add(this.rbValorUnitario, 2, 0);
            this.tlpAcrescimoDesconto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAcrescimoDesconto.Location = new System.Drawing.Point(0, 0);
            this.tlpAcrescimoDesconto.Name = "tlpAcrescimoDesconto";
            this.tlpAcrescimoDesconto.RowCount = 1;
            this.tlpAcrescimoDesconto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcrescimoDesconto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpAcrescimoDesconto.Size = new System.Drawing.Size(331, 52);
            this.tlpAcrescimoDesconto.TabIndex = 0;
            // 
            // rbAcrescimo
            // 
            this.rbAcrescimo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbAcrescimo.AutoSize = true;
            this.rbAcrescimo.Location = new System.Drawing.Point(54, 17);
            this.rbAcrescimo.Name = "rbAcrescimo";
            this.rbAcrescimo.Size = new System.Drawing.Size(74, 17);
            this.rbAcrescimo.TabIndex = 1;
            this.rbAcrescimo.TabStop = true;
            this.rbAcrescimo.Text = "Acrescimo";
            this.rbAcrescimo.UseVisualStyleBackColor = true;
            this.rbAcrescimo.CheckedChanged += new System.EventHandler(this.rbAcrescimo_CheckedChanged);
            // 
            // rbDesconto
            // 
            this.rbDesconto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbDesconto.AutoSize = true;
            this.rbDesconto.Location = new System.Drawing.Point(134, 17);
            this.rbDesconto.Name = "rbDesconto";
            this.rbDesconto.Size = new System.Drawing.Size(71, 17);
            this.rbDesconto.TabIndex = 2;
            this.rbDesconto.TabStop = true;
            this.rbDesconto.Text = "Desconto";
            this.rbDesconto.UseVisualStyleBackColor = true;
            this.rbDesconto.CheckedChanged += new System.EventHandler(this.rbDesconto_CheckedChanged);
            // 
            // rbValorUnitario
            // 
            this.rbValorUnitario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbValorUnitario.AutoSize = true;
            this.rbValorUnitario.Location = new System.Drawing.Point(212, 17);
            this.rbValorUnitario.Name = "rbValorUnitario";
            this.rbValorUnitario.Size = new System.Drawing.Size(86, 17);
            this.rbValorUnitario.TabIndex = 3;
            this.rbValorUnitario.TabStop = true;
            this.rbValorUnitario.Text = "Valor unitário";
            this.rbValorUnitario.UseVisualStyleBackColor = true;
            this.rbValorUnitario.CheckedChanged += new System.EventHandler(this.rbValorUnitario_CheckedChanged);
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBuscarProduto.Location = new System.Drawing.Point(169, 19);
            this.txtBuscarProduto.Name = "txtBuscarProduto";
            this.txtBuscarProduto.Size = new System.Drawing.Size(161, 20);
            this.txtBuscarProduto.TabIndex = 0;
            this.txtBuscarProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarProduto_KeyPress);
            this.txtBuscarProduto.Leave += new System.EventHandler(this.txtBuscarProduto_Leave);
            // 
            // lblBuscarProduto
            // 
            this.lblBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBuscarProduto.AutoSize = true;
            this.lblBuscarProduto.Location = new System.Drawing.Point(3, 16);
            this.lblBuscarProduto.Name = "lblBuscarProduto";
            this.lblBuscarProduto.Size = new System.Drawing.Size(124, 26);
            this.lblBuscarProduto.TabIndex = 1001;
            this.lblBuscarProduto.Text = "Informe a sequência que\r\ndeseja selecionar:";
            // 
            // tlpLegenda
            // 
            this.tlpLegenda.ColumnCount = 1;
            this.tlpGeral.SetColumnSpan(this.tlpLegenda, 2);
            this.tlpLegenda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.79525F));
            this.tlpLegenda.Controls.Add(this.gpbLegenda, 0, 0);
            this.tlpLegenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLegenda.Location = new System.Drawing.Point(3, 209);
            this.tlpLegenda.Name = "tlpLegenda";
            this.tlpLegenda.RowCount = 1;
            this.tlpLegenda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLegenda.Size = new System.Drawing.Size(373, 93);
            this.tlpLegenda.TabIndex = 1002;
            // 
            // gpbLegenda
            // 
            this.gpbLegenda.Controls.Add(this.tlpLegendasAtalho);
            this.gpbLegenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbLegenda.Location = new System.Drawing.Point(3, 3);
            this.gpbLegenda.Name = "gpbLegenda";
            this.gpbLegenda.Size = new System.Drawing.Size(367, 87);
            this.gpbLegenda.TabIndex = 0;
            this.gpbLegenda.TabStop = false;
            this.gpbLegenda.Text = "  Legenda  ";
            // 
            // tlpLegendasAtalho
            // 
            this.tlpLegendasAtalho.ColumnCount = 3;
            this.tlpLegendasAtalho.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tlpLegendasAtalho.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.12648F));
            this.tlpLegendasAtalho.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.87352F));
            this.tlpLegendasAtalho.Controls.Add(this.lblAtalhoAcrescimo, 1, 0);
            this.tlpLegendasAtalho.Controls.Add(this.lblAtalhoDesconto, 1, 1);
            this.tlpLegendasAtalho.Controls.Add(this.lblAtalhoValorUnitario, 1, 2);
            this.tlpLegendasAtalho.Controls.Add(this.lblAtalhoPreco, 2, 0);
            this.tlpLegendasAtalho.Controls.Add(this.lblAtalhoPorcentagem, 2, 1);
            this.tlpLegendasAtalho.Controls.Add(this.lblAtalhoBuscarProduto, 0, 0);
            this.tlpLegendasAtalho.Controls.Add(this.lblAtalhoNovoValor, 0, 1);
            this.tlpLegendasAtalho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLegendasAtalho.Location = new System.Drawing.Point(3, 16);
            this.tlpLegendasAtalho.Name = "tlpLegendasAtalho";
            this.tlpLegendasAtalho.RowCount = 3;
            this.tlpLegendasAtalho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLegendasAtalho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLegendasAtalho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLegendasAtalho.Size = new System.Drawing.Size(361, 68);
            this.tlpLegendasAtalho.TabIndex = 2;
            // 
            // lblAtalhoAcrescimo
            // 
            this.lblAtalhoAcrescimo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtalhoAcrescimo.AutoSize = true;
            this.lblAtalhoAcrescimo.Location = new System.Drawing.Point(122, 5);
            this.lblAtalhoAcrescimo.Name = "lblAtalhoAcrescimo";
            this.lblAtalhoAcrescimo.Size = new System.Drawing.Size(88, 13);
            this.lblAtalhoAcrescimo.TabIndex = 0;
            this.lblAtalhoAcrescimo.Text = "Ascrescimo ( F5 )";
            // 
            // lblAtalhoDesconto
            // 
            this.lblAtalhoDesconto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtalhoDesconto.AutoSize = true;
            this.lblAtalhoDesconto.Location = new System.Drawing.Point(122, 27);
            this.lblAtalhoDesconto.Name = "lblAtalhoDesconto";
            this.lblAtalhoDesconto.Size = new System.Drawing.Size(80, 13);
            this.lblAtalhoDesconto.TabIndex = 1;
            this.lblAtalhoDesconto.Text = "Desconto ( F6 )";
            // 
            // lblAtalhoValorUnitario
            // 
            this.lblAtalhoValorUnitario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtalhoValorUnitario.AutoSize = true;
            this.lblAtalhoValorUnitario.Location = new System.Drawing.Point(122, 49);
            this.lblAtalhoValorUnitario.Name = "lblAtalhoValorUnitario";
            this.lblAtalhoValorUnitario.Size = new System.Drawing.Size(97, 13);
            this.lblAtalhoValorUnitario.TabIndex = 2;
            this.lblAtalhoValorUnitario.Text = "Valor Unitário ( F7 )";
            // 
            // lblAtalhoPreco
            // 
            this.lblAtalhoPreco.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtalhoPreco.AutoSize = true;
            this.lblAtalhoPreco.Location = new System.Drawing.Point(257, 5);
            this.lblAtalhoPreco.Name = "lblAtalhoPreco";
            this.lblAtalhoPreco.Size = new System.Drawing.Size(62, 13);
            this.lblAtalhoPreco.TabIndex = 3;
            this.lblAtalhoPreco.Text = "Preço ( F8 )";
            // 
            // lblAtalhoPorcentagem
            // 
            this.lblAtalhoPorcentagem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtalhoPorcentagem.AutoSize = true;
            this.lblAtalhoPorcentagem.Location = new System.Drawing.Point(257, 27);
            this.lblAtalhoPorcentagem.Name = "lblAtalhoPorcentagem";
            this.lblAtalhoPorcentagem.Size = new System.Drawing.Size(97, 13);
            this.lblAtalhoPorcentagem.TabIndex = 4;
            this.lblAtalhoPorcentagem.Text = "Porcentagem ( F9 )";
            // 
            // lblAtalhoBuscarProduto
            // 
            this.lblAtalhoBuscarProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtalhoBuscarProduto.AutoSize = true;
            this.lblAtalhoBuscarProduto.Location = new System.Drawing.Point(3, 5);
            this.lblAtalhoBuscarProduto.Name = "lblAtalhoBuscarProduto";
            this.lblAtalhoBuscarProduto.Size = new System.Drawing.Size(107, 13);
            this.lblAtalhoBuscarProduto.TabIndex = 5;
            this.lblAtalhoBuscarProduto.Text = "Buscar Produto ( F3 )";
            // 
            // lblAtalhoNovoValor
            // 
            this.lblAtalhoNovoValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtalhoNovoValor.AutoSize = true;
            this.lblAtalhoNovoValor.Location = new System.Drawing.Point(3, 27);
            this.lblAtalhoNovoValor.Name = "lblAtalhoNovoValor";
            this.lblAtalhoNovoValor.Size = new System.Drawing.Size(87, 13);
            this.lblAtalhoNovoValor.TabIndex = 6;
            this.lblAtalhoNovoValor.Text = "Novo Valor ( F4 )";
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
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 250;
            // 
            // colQuantidade
            // 
            this.colQuantidade.HeaderText = "Qtd";
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.ReadOnly = true;
            this.colQuantidade.Width = 70;
            // 
            // colAcrescimo
            // 
            this.colAcrescimo.HeaderText = "Acrescimo";
            this.colAcrescimo.Name = "colAcrescimo";
            this.colAcrescimo.ReadOnly = true;
            // 
            // colDesconto
            // 
            this.colDesconto.HeaderText = "Desconto";
            this.colDesconto.Name = "colDesconto";
            this.colDesconto.ReadOnly = true;
            // 
            // colPorcentagem
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colPorcentagem.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPorcentagem.HeaderText = "Perc. (%)";
            this.colPorcentagem.Name = "colPorcentagem";
            this.colPorcentagem.ReadOnly = true;
            this.colPorcentagem.ToolTipText = "Porcentagem";
            this.colPorcentagem.Width = 120;
            // 
            // colValor
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle2;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 120;
            // 
            // colValorTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.colValorTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValorTotal.HeaderText = "Valor Total";
            this.colValorTotal.Name = "colValorTotal";
            this.colValorTotal.ReadOnly = true;
            this.colValorTotal.Width = 120;
            // 
            // ModificarValorProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 441);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ModificarValorProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Valor Produto";
            this.Load += new System.EventHandler(this.ModificarValorProduto_Load);
            this.tlpGeral.ResumeLayout(false);
            this.tlpGeral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.pnlPrecoPorcentagem.ResumeLayout(false);
            this.tlpPrecoPorcentagem.ResumeLayout(false);
            this.tlpPrecoPorcentagem.PerformLayout();
            this.pnlAcrescimoDesconto.ResumeLayout(false);
            this.tlpAcrescimoDesconto.ResumeLayout(false);
            this.tlpAcrescimoDesconto.PerformLayout();
            this.tlpLegenda.ResumeLayout(false);
            this.gpbLegenda.ResumeLayout(false);
            this.tlpLegendasAtalho.ResumeLayout(false);
            this.tlpLegendasAtalho.PerformLayout();
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(tlpGeral);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.TextBox txtNovoValor;
        private System.Windows.Forms.Label lblNovoValor;
        private System.Windows.Forms.Panel pnlPrecoPorcentagem;
        private System.Windows.Forms.TableLayoutPanel tlpPrecoPorcentagem;
        private System.Windows.Forms.RadioButton rbPorcentagem;
        private System.Windows.Forms.RadioButton rbPreco;
        private System.Windows.Forms.Panel pnlAcrescimoDesconto;
        private System.Windows.Forms.TableLayoutPanel tlpAcrescimoDesconto;
        private System.Windows.Forms.RadioButton rbAcrescimo;
        private System.Windows.Forms.RadioButton rbDesconto;
        private System.Windows.Forms.RadioButton rbValorUnitario;
        private System.Windows.Forms.TextBox txtBuscarProduto;
        private System.Windows.Forms.Label lblBuscarProduto;
        private System.Windows.Forms.TableLayoutPanel tlpLegenda;
        private System.Windows.Forms.GroupBox gpbLegenda;
        private System.Windows.Forms.TableLayoutPanel tlpLegendasAtalho;
        private System.Windows.Forms.Label lblAtalhoAcrescimo;
        private System.Windows.Forms.Label lblAtalhoDesconto;
        private System.Windows.Forms.Label lblAtalhoValorUnitario;
        private System.Windows.Forms.Label lblAtalhoPreco;
        private System.Windows.Forms.Label lblAtalhoPorcentagem;
        private System.Windows.Forms.Label lblAtalhoBuscarProduto;
        private System.Windows.Forms.Label lblAtalhoNovoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdAgrupacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcentagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
    }
}