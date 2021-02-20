namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoPromocao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtValorDesconto = new System.Windows.Forms.TextBox();
            this.lblValorDesconto = new System.Windows.Forms.Label();
            this.txtPercentual = new System.Windows.Forms.TextBox();
            this.lblPercentualMVA = new System.Windows.Forms.Label();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.gpbPerido = new System.Windows.Forms.GroupBox();
            this.chklistadiassemana = new System.Windows.Forms.CheckedListBox();
            this.gpbProdutosCompra = new System.Windows.Forms.GroupBox();
            this.dgvProdutosEstoque = new System.Windows.Forms.DataGridView();
            this.colSelecionarCompras = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdentificadorProdutoServicoC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificadorProdutoFilialC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificadorCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarrasCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbTipoPromocao = new System.Windows.Forms.GroupBox();
            this.rbnEstoque = new System.Windows.Forms.RadioButton();
            this.rbnFilial = new System.Windows.Forms.RadioButton();
            this.rbnEmpresa = new System.Windows.Forms.RadioButton();
            this.chkHabilitada = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkPorHorario = new System.Windows.Forms.CheckBox();
            this.gpbProdutosEmpresa = new System.Windows.Forms.GroupBox();
            this.dgvProdutoEmpresa = new System.Windows.Forms.DataGridView();
            this.colSelecionarEmpresa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdentificadorEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarrasEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gpbProdutosFilial = new System.Windows.Forms.GroupBox();
            this.dgvProdutosFilial = new System.Windows.Forms.DataGridView();
            this.colSelecionarFilial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdentificadorFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificadorProdutoServicoF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarrasFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbPerido.SuspendLayout();
            this.gpbProdutosCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosEstoque)).BeginInit();
            this.gpbTipoPromocao.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpbProdutosEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoEmpresa)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.gpbProdutosFilial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosFilial)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtNome, 4);
            this.txtNome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNome.Location = new System.Drawing.Point(139, 4);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(499, 20);
            this.txtNome.TabIndex = 16;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(4, 0);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(55, 13);
            this.lblNome.TabIndex = 15;
            this.lblNome.Text = "Descrição";
            // 
            // txtValorDesconto
            // 
            this.txtValorDesconto.Location = new System.Drawing.Point(139, 50);
            this.txtValorDesconto.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorDesconto.MaxLength = 50;
            this.txtValorDesconto.Name = "txtValorDesconto";
            this.txtValorDesconto.Size = new System.Drawing.Size(117, 20);
            this.txtValorDesconto.TabIndex = 20;
            this.txtValorDesconto.Enter += new System.EventHandler(this.txtValorDesconto_Enter);
            // 
            // lblValorDesconto
            // 
            this.lblValorDesconto.AutoSize = true;
            this.lblValorDesconto.Location = new System.Drawing.Point(4, 46);
            this.lblValorDesconto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorDesconto.Name = "lblValorDesconto";
            this.lblValorDesconto.Size = new System.Drawing.Size(95, 13);
            this.lblValorDesconto.TabIndex = 19;
            this.lblValorDesconto.Text = "Valor do Desconto";
            // 
            // txtPercentual
            // 
            this.txtPercentual.Location = new System.Drawing.Point(380, 50);
            this.txtPercentual.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentual.MaxLength = 50;
            this.txtPercentual.Name = "txtPercentual";
            this.txtPercentual.Size = new System.Drawing.Size(117, 20);
            this.txtPercentual.TabIndex = 22;
            this.txtPercentual.Enter += new System.EventHandler(this.txtPercentual_Enter);
            // 
            // lblPercentualMVA
            // 
            this.lblPercentualMVA.AutoSize = true;
            this.lblPercentualMVA.Location = new System.Drawing.Point(277, 46);
            this.lblPercentualMVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualMVA.Name = "lblPercentualMVA";
            this.lblPercentualMVA.Size = new System.Drawing.Size(76, 26);
            this.lblPercentualMVA.TabIndex = 21;
            this.lblPercentualMVA.Text = "Percentual de Desconto";
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Location = new System.Drawing.Point(0, 18);
            this.lblDataInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(139, 13);
            this.lblDataInicio.TabIndex = 23;
            this.lblDataInicio.Text = "Data de Inicio da Promoção";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Checked = false;
            this.dtpInicio.CustomFormat = "";
            this.dtpInicio.Location = new System.Drawing.Point(147, 16);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(375, 20);
            this.dtpInicio.TabIndex = 24;
            // 
            // dtpFim
            // 
            this.dtpFim.CustomFormat = "";
            this.dtpFim.Location = new System.Drawing.Point(147, 42);
            this.dtpFim.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(375, 20);
            this.dtpFim.TabIndex = 26;
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(0, 45);
            this.lblDataFim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(130, 13);
            this.lblDataFim.TabIndex = 25;
            this.lblDataFim.Text = "Data de Fim da Promoção";
            // 
            // gpbPerido
            // 
            this.gpbPerido.Controls.Add(this.chklistadiassemana);
            this.gpbPerido.Controls.Add(this.dtpInicio);
            this.gpbPerido.Controls.Add(this.dtpFim);
            this.gpbPerido.Controls.Add(this.lblDataInicio);
            this.gpbPerido.Controls.Add(this.lblDataFim);
            this.gpbPerido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbPerido.Location = new System.Drawing.Point(652, 4);
            this.gpbPerido.Margin = new System.Windows.Forms.Padding(4);
            this.gpbPerido.Name = "gpbPerido";
            this.gpbPerido.Padding = new System.Windows.Forms.Padding(4);
            this.gpbPerido.Size = new System.Drawing.Size(530, 126);
            this.gpbPerido.TabIndex = 27;
            this.gpbPerido.TabStop = false;
            this.gpbPerido.Text = "Periodo da Promoção";
            // 
            // chklistadiassemana
            // 
            this.chklistadiassemana.CheckOnClick = true;
            this.chklistadiassemana.FormattingEnabled = true;
            this.chklistadiassemana.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.chklistadiassemana.Location = new System.Drawing.Point(2, 69);
            this.chklistadiassemana.MultiColumn = true;
            this.chklistadiassemana.Name = "chklistadiassemana";
            this.chklistadiassemana.Size = new System.Drawing.Size(521, 49);
            this.chklistadiassemana.TabIndex = 27;
            this.chklistadiassemana.Visible = false;
            // 
            // gpbProdutosCompra
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpbProdutosCompra, 2);
            this.gpbProdutosCompra.Controls.Add(this.dgvProdutosEstoque);
            this.gpbProdutosCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbProdutosCompra.Location = new System.Drawing.Point(4, 261);
            this.gpbProdutosCompra.Margin = new System.Windows.Forms.Padding(4);
            this.gpbProdutosCompra.Name = "gpbProdutosCompra";
            this.gpbProdutosCompra.Padding = new System.Windows.Forms.Padding(4);
            this.gpbProdutosCompra.Size = new System.Drawing.Size(1178, 108);
            this.gpbProdutosCompra.TabIndex = 30;
            this.gpbProdutosCompra.TabStop = false;
            this.gpbProdutosCompra.Text = "Produtos Por Compra";
            // 
            // dgvProdutosEstoque
            // 
            this.dgvProdutosEstoque.AllowUserToAddRows = false;
            this.dgvProdutosEstoque.AllowUserToDeleteRows = false;
            this.dgvProdutosEstoque.AllowUserToOrderColumns = true;
            this.dgvProdutosEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecionarCompras,
            this.colIdentificadorProdutoServicoC,
            this.colIdentificadorProdutoFilialC,
            this.colIdentificadorCompras,
            this.colCodigoBarrasCompras,
            this.colDescricaoCompras,
            this.colEstoqueCompra});
            this.dgvProdutosEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutosEstoque.Location = new System.Drawing.Point(4, 17);
            this.dgvProdutosEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutosEstoque.Name = "dgvProdutosEstoque";
            this.dgvProdutosEstoque.ReadOnly = true;
            this.dgvProdutosEstoque.Size = new System.Drawing.Size(1170, 87);
            this.dgvProdutosEstoque.TabIndex = 6;
            this.dgvProdutosEstoque.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutosEstoque_CellContentClick);
            this.dgvProdutosEstoque.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProdutosEstoque_CellPainting);
            // 
            // colSelecionarCompras
            // 
            this.colSelecionarCompras.HeaderText = "";
            this.colSelecionarCompras.Name = "colSelecionarCompras";
            this.colSelecionarCompras.ReadOnly = true;
            this.colSelecionarCompras.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelecionarCompras.Width = 20;
            // 
            // colIdentificadorProdutoServicoC
            // 
            this.colIdentificadorProdutoServicoC.HeaderText = "colIdentificadorProdutoServicoC";
            this.colIdentificadorProdutoServicoC.Name = "colIdentificadorProdutoServicoC";
            this.colIdentificadorProdutoServicoC.ReadOnly = true;
            this.colIdentificadorProdutoServicoC.Visible = false;
            // 
            // colIdentificadorProdutoFilialC
            // 
            this.colIdentificadorProdutoFilialC.HeaderText = "colIdentificadorProdutoFilialC";
            this.colIdentificadorProdutoFilialC.Name = "colIdentificadorProdutoFilialC";
            this.colIdentificadorProdutoFilialC.ReadOnly = true;
            this.colIdentificadorProdutoFilialC.Visible = false;
            // 
            // colIdentificadorCompras
            // 
            this.colIdentificadorCompras.HeaderText = "Column1";
            this.colIdentificadorCompras.Name = "colIdentificadorCompras";
            this.colIdentificadorCompras.ReadOnly = true;
            this.colIdentificadorCompras.Visible = false;
            // 
            // colCodigoBarrasCompras
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoBarrasCompras.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCodigoBarrasCompras.HeaderText = "Código de Barras";
            this.colCodigoBarrasCompras.Name = "colCodigoBarrasCompras";
            this.colCodigoBarrasCompras.ReadOnly = true;
            this.colCodigoBarrasCompras.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigoBarrasCompras.Width = 200;
            // 
            // colDescricaoCompras
            // 
            this.colDescricaoCompras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricaoCompras.HeaderText = "Descrição";
            this.colDescricaoCompras.Name = "colDescricaoCompras";
            this.colDescricaoCompras.ReadOnly = true;
            this.colDescricaoCompras.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEstoqueCompra
            // 
            this.colEstoqueCompra.HeaderText = "Estoque";
            this.colEstoqueCompra.Name = "colEstoqueCompra";
            this.colEstoqueCompra.ReadOnly = true;
            this.colEstoqueCompra.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gpbTipoPromocao
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gpbTipoPromocao, 3);
            this.gpbTipoPromocao.Controls.Add(this.rbnEstoque);
            this.gpbTipoPromocao.Controls.Add(this.rbnFilial);
            this.gpbTipoPromocao.Controls.Add(this.rbnEmpresa);
            this.gpbTipoPromocao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbTipoPromocao.Location = new System.Drawing.Point(4, 86);
            this.gpbTipoPromocao.Margin = new System.Windows.Forms.Padding(4);
            this.gpbTipoPromocao.Name = "gpbTipoPromocao";
            this.gpbTipoPromocao.Padding = new System.Windows.Forms.Padding(4);
            this.gpbTipoPromocao.Size = new System.Drawing.Size(368, 38);
            this.gpbTipoPromocao.TabIndex = 33;
            this.gpbTipoPromocao.TabStop = false;
            this.gpbTipoPromocao.Text = "Promoção a Nivel de";
            // 
            // rbnEstoque
            // 
            this.rbnEstoque.AutoSize = true;
            this.rbnEstoque.Location = new System.Drawing.Point(224, 17);
            this.rbnEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.rbnEstoque.Name = "rbnEstoque";
            this.rbnEstoque.Size = new System.Drawing.Size(64, 17);
            this.rbnEstoque.TabIndex = 2;
            this.rbnEstoque.Text = "Estoque";
            this.rbnEstoque.UseVisualStyleBackColor = true;
            this.rbnEstoque.CheckedChanged += new System.EventHandler(this.rbnEstoque_CheckedChanged);
            // 
            // rbnFilial
            // 
            this.rbnFilial.AutoSize = true;
            this.rbnFilial.Location = new System.Drawing.Point(133, 17);
            this.rbnFilial.Margin = new System.Windows.Forms.Padding(4);
            this.rbnFilial.Name = "rbnFilial";
            this.rbnFilial.Size = new System.Drawing.Size(45, 17);
            this.rbnFilial.TabIndex = 1;
            this.rbnFilial.Text = "Filial";
            this.rbnFilial.UseVisualStyleBackColor = true;
            this.rbnFilial.CheckedChanged += new System.EventHandler(this.rbnFilial_CheckedChanged);
            // 
            // rbnEmpresa
            // 
            this.rbnEmpresa.AutoSize = true;
            this.rbnEmpresa.Location = new System.Drawing.Point(25, 17);
            this.rbnEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.rbnEmpresa.Name = "rbnEmpresa";
            this.rbnEmpresa.Size = new System.Drawing.Size(66, 17);
            this.rbnEmpresa.TabIndex = 0;
            this.rbnEmpresa.Text = "Empresa";
            this.rbnEmpresa.UseVisualStyleBackColor = true;
            this.rbnEmpresa.CheckedChanged += new System.EventHandler(this.rbnEmpresa_CheckedChanged);
            // 
            // chkHabilitada
            // 
            this.chkHabilitada.AutoSize = true;
            this.chkHabilitada.Location = new System.Drawing.Point(380, 86);
            this.chkHabilitada.Margin = new System.Windows.Forms.Padding(4);
            this.chkHabilitada.Name = "chkHabilitada";
            this.chkHabilitada.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitada.TabIndex = 35;
            this.chkHabilitada.Text = "Habilitada";
            this.chkHabilitada.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 648F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gpbPerido, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gpbProdutosEmpresa, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gpbProdutosCompra, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1186, 498);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gpbTipoPromocao, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNome, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNome, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblValorDesconto, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtValorDesconto, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPercentualMVA, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPercentual, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkHabilitada, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkPorHorario, 4, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(642, 128);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // chkPorHorario
            // 
            this.chkPorHorario.AutoSize = true;
            this.chkPorHorario.Location = new System.Drawing.Point(509, 85);
            this.chkPorHorario.Name = "chkPorHorario";
            this.chkPorHorario.Size = new System.Drawing.Size(79, 17);
            this.chkPorHorario.TabIndex = 36;
            this.chkPorHorario.Text = "Por Horário";
            this.chkPorHorario.UseVisualStyleBackColor = true;
            this.chkPorHorario.CheckedChanged += new System.EventHandler(this.chkPorHorario_CheckedChanged);
            // 
            // gpbProdutosEmpresa
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpbProdutosEmpresa, 2);
            this.gpbProdutosEmpresa.Controls.Add(this.dgvProdutoEmpresa);
            this.gpbProdutosEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbProdutosEmpresa.Location = new System.Drawing.Point(4, 138);
            this.gpbProdutosEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.gpbProdutosEmpresa.Name = "gpbProdutosEmpresa";
            this.gpbProdutosEmpresa.Padding = new System.Windows.Forms.Padding(4);
            this.gpbProdutosEmpresa.Size = new System.Drawing.Size(1178, 115);
            this.gpbProdutosEmpresa.TabIndex = 28;
            this.gpbProdutosEmpresa.TabStop = false;
            this.gpbProdutosEmpresa.Text = "Produtos da Empresa";
            // 
            // dgvProdutoEmpresa
            // 
            this.dgvProdutoEmpresa.AllowUserToAddRows = false;
            this.dgvProdutoEmpresa.AllowUserToDeleteRows = false;
            this.dgvProdutoEmpresa.AllowUserToOrderColumns = true;
            this.dgvProdutoEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecionarEmpresa,
            this.colIdentificadorEmpresa,
            this.colCodigoBarrasEmpresa,
            this.colDescricaoEmpresa,
            this.colEstoqueEmpresa});
            this.dgvProdutoEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutoEmpresa.Location = new System.Drawing.Point(4, 17);
            this.dgvProdutoEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutoEmpresa.Name = "dgvProdutoEmpresa";
            this.dgvProdutoEmpresa.ReadOnly = true;
            this.dgvProdutoEmpresa.Size = new System.Drawing.Size(1170, 94);
            this.dgvProdutoEmpresa.TabIndex = 6;
            this.dgvProdutoEmpresa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutoEmpresa_CellContentClick);
            this.dgvProdutoEmpresa.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProdutoEmpresa_CellPainting);
            // 
            // colSelecionarEmpresa
            // 
            this.colSelecionarEmpresa.HeaderText = "";
            this.colSelecionarEmpresa.Name = "colSelecionarEmpresa";
            this.colSelecionarEmpresa.ReadOnly = true;
            this.colSelecionarEmpresa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelecionarEmpresa.Width = 20;
            // 
            // colIdentificadorEmpresa
            // 
            this.colIdentificadorEmpresa.HeaderText = "Column1";
            this.colIdentificadorEmpresa.Name = "colIdentificadorEmpresa";
            this.colIdentificadorEmpresa.ReadOnly = true;
            this.colIdentificadorEmpresa.Visible = false;
            // 
            // colCodigoBarrasEmpresa
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoBarrasEmpresa.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCodigoBarrasEmpresa.HeaderText = "Código de Barras";
            this.colCodigoBarrasEmpresa.Name = "colCodigoBarrasEmpresa";
            this.colCodigoBarrasEmpresa.ReadOnly = true;
            this.colCodigoBarrasEmpresa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigoBarrasEmpresa.Width = 200;
            // 
            // colDescricaoEmpresa
            // 
            this.colDescricaoEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricaoEmpresa.HeaderText = "Descrição";
            this.colDescricaoEmpresa.Name = "colDescricaoEmpresa";
            this.colDescricaoEmpresa.ReadOnly = true;
            this.colDescricaoEmpresa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEstoqueEmpresa
            // 
            this.colEstoqueEmpresa.HeaderText = "Estoque";
            this.colEstoqueEmpresa.Name = "colEstoqueEmpresa";
            this.colEstoqueEmpresa.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.gpbProdutosFilial, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 376);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1180, 119);
            this.tableLayoutPanel3.TabIndex = 37;
            // 
            // gpbProdutosFilial
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.gpbProdutosFilial, 2);
            this.gpbProdutosFilial.Controls.Add(this.dgvProdutosFilial);
            this.gpbProdutosFilial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbProdutosFilial.Location = new System.Drawing.Point(4, 4);
            this.gpbProdutosFilial.Margin = new System.Windows.Forms.Padding(4);
            this.gpbProdutosFilial.Name = "gpbProdutosFilial";
            this.gpbProdutosFilial.Padding = new System.Windows.Forms.Padding(4);
            this.gpbProdutosFilial.Size = new System.Drawing.Size(1172, 111);
            this.gpbProdutosFilial.TabIndex = 29;
            this.gpbProdutosFilial.TabStop = false;
            this.gpbProdutosFilial.Text = "Produtos da Filial";
            // 
            // dgvProdutosFilial
            // 
            this.dgvProdutosFilial.AllowUserToAddRows = false;
            this.dgvProdutosFilial.AllowUserToDeleteRows = false;
            this.dgvProdutosFilial.AllowUserToOrderColumns = true;
            this.dgvProdutosFilial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosFilial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecionarFilial,
            this.colIdentificadorFilial,
            this.colIdentificadorProdutoServicoF,
            this.colCodigoBarrasFilial,
            this.colDescricaoFilial,
            this.colEstoqueFilial});
            this.dgvProdutosFilial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutosFilial.Location = new System.Drawing.Point(4, 17);
            this.dgvProdutosFilial.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutosFilial.Name = "dgvProdutosFilial";
            this.dgvProdutosFilial.ReadOnly = true;
            this.dgvProdutosFilial.Size = new System.Drawing.Size(1164, 90);
            this.dgvProdutosFilial.TabIndex = 6;
            this.dgvProdutosFilial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutosFilial_CellContentClick);
            this.dgvProdutosFilial.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProdutosFilial_CellPainting);
            // 
            // colSelecionarFilial
            // 
            this.colSelecionarFilial.HeaderText = "";
            this.colSelecionarFilial.Name = "colSelecionarFilial";
            this.colSelecionarFilial.ReadOnly = true;
            this.colSelecionarFilial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSelecionarFilial.Width = 20;
            // 
            // colIdentificadorFilial
            // 
            this.colIdentificadorFilial.HeaderText = "Column1";
            this.colIdentificadorFilial.Name = "colIdentificadorFilial";
            this.colIdentificadorFilial.ReadOnly = true;
            this.colIdentificadorFilial.Visible = false;
            // 
            // colIdentificadorProdutoServicoF
            // 
            this.colIdentificadorProdutoServicoF.HeaderText = "colIdentificadorProdutoServicoF";
            this.colIdentificadorProdutoServicoF.Name = "colIdentificadorProdutoServicoF";
            this.colIdentificadorProdutoServicoF.ReadOnly = true;
            this.colIdentificadorProdutoServicoF.Visible = false;
            // 
            // colCodigoBarrasFilial
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoBarrasFilial.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCodigoBarrasFilial.HeaderText = "Código de Barras";
            this.colCodigoBarrasFilial.Name = "colCodigoBarrasFilial";
            this.colCodigoBarrasFilial.ReadOnly = true;
            this.colCodigoBarrasFilial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigoBarrasFilial.Width = 200;
            // 
            // colDescricaoFilial
            // 
            this.colDescricaoFilial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricaoFilial.HeaderText = "Descrição";
            this.colDescricaoFilial.Name = "colDescricaoFilial";
            this.colDescricaoFilial.ReadOnly = true;
            this.colDescricaoFilial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEstoqueFilial
            // 
            this.colEstoqueFilial.HeaderText = "Estoque";
            this.colEstoqueFilial.Name = "colEstoqueFilial";
            this.colEstoqueFilial.ReadOnly = true;
            // 
            // GuardarProdutoPromocao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1192, 634);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarProdutoPromocao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Promoção";
            this.gpbPerido.ResumeLayout(false);
            this.gpbPerido.PerformLayout();
            this.gpbProdutosCompra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosEstoque)).EndInit();
            this.gpbTipoPromocao.ResumeLayout(false);
            this.gpbTipoPromocao.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gpbProdutosEmpresa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoEmpresa)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gpbProdutosFilial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosFilial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtValorDesconto;
        private System.Windows.Forms.Label lblValorDesconto;
        private System.Windows.Forms.TextBox txtPercentual;
        private System.Windows.Forms.Label lblPercentualMVA;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.GroupBox gpbPerido;
        private System.Windows.Forms.GroupBox gpbProdutosCompra;
        private System.Windows.Forms.DataGridView dgvProdutosEstoque;
        private System.Windows.Forms.GroupBox gpbTipoPromocao;
        private System.Windows.Forms.RadioButton rbnEstoque;
        private System.Windows.Forms.RadioButton rbnFilial;
        private System.Windows.Forms.RadioButton rbnEmpresa;
        private System.Windows.Forms.CheckBox chkHabilitada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecionarCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorProdutoServicoC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorProdutoFilialC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarrasCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueCompra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gpbProdutosEmpresa;
        private System.Windows.Forms.DataGridView dgvProdutoEmpresa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecionarEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarrasEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueEmpresa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox gpbProdutosFilial;
        private System.Windows.Forms.DataGridView dgvProdutosFilial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecionarFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorProdutoServicoF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarrasFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueFilial;
        private System.Windows.Forms.CheckBox chkPorHorario;
        private System.Windows.Forms.CheckedListBox chklistadiassemana;
    }
}