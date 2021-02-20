namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoCompra
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
            this.tlpClientes = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvProdutosSelecionados = new System.Windows.Forms.DataGridView();
            this.colIdProdutoServSel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoSelecionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarrasSel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoSelecionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInfCompraVenda = new System.Windows.Forms.DataGridViewImageColumn();
            this.colRemover = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDescricao = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.lblCodigoBarras = new System.Windows.Forms.Label();
            this.gpbProdutoServico = new System.Windows.Forms.GroupBox();
            this.dgvProdutoServico = new System.Windows.Forms.DataGridView();
            this.colIdProdutoServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdicionar = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosSelecionados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpbProdutoServico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoServico)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.groupBox2, 0, 2);
            this.tlpClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tlpClientes.Controls.Add(this.gpbProdutoServico, 0, 1);
            this.tlpClientes.Location = new System.Drawing.Point(0, 0);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 3;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpClientes.Size = new System.Drawing.Size(1335, 677);
            this.tlpClientes.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvProdutosSelecionados);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 402);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1327, 271);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produtos e Serviços";
            // 
            // dgvProdutosSelecionados
            // 
            this.dgvProdutosSelecionados.AllowUserToAddRows = false;
            this.dgvProdutosSelecionados.AllowUserToDeleteRows = false;
            this.dgvProdutosSelecionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosSelecionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProdutoServSel,
            this.colCodigoSelecionado,
            this.colCodigoBarrasSel,
            this.colDescricaoSelecionado,
            this.colInfCompraVenda,
            this.colRemover});
            this.dgvProdutosSelecionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutosSelecionados.Location = new System.Drawing.Point(4, 19);
            this.dgvProdutosSelecionados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutosSelecionados.Name = "dgvProdutosSelecionados";
            this.dgvProdutosSelecionados.ReadOnly = true;
            this.dgvProdutosSelecionados.Size = new System.Drawing.Size(1319, 248);
            this.dgvProdutosSelecionados.TabIndex = 7;
            this.dgvProdutosSelecionados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutosSelecionados_CellContentClick);
            this.dgvProdutosSelecionados.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdutosSelecionados_CellMouseMove);
            // 
            // colIdProdutoServSel
            // 
            this.colIdProdutoServSel.HeaderText = "Column1";
            this.colIdProdutoServSel.Name = "colIdProdutoServSel";
            this.colIdProdutoServSel.ReadOnly = true;
            this.colIdProdutoServSel.Visible = false;
            // 
            // colCodigoSelecionado
            // 
            this.colCodigoSelecionado.HeaderText = "Código";
            this.colCodigoSelecionado.Name = "colCodigoSelecionado";
            this.colCodigoSelecionado.ReadOnly = true;
            this.colCodigoSelecionado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colCodigoBarrasSel
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoBarrasSel.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCodigoBarrasSel.HeaderText = "Código de Barras";
            this.colCodigoBarrasSel.Name = "colCodigoBarrasSel";
            this.colCodigoBarrasSel.ReadOnly = true;
            this.colCodigoBarrasSel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigoBarrasSel.Width = 200;
            // 
            // colDescricaoSelecionado
            // 
            this.colDescricaoSelecionado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricaoSelecionado.HeaderText = "Descrição";
            this.colDescricaoSelecionado.Name = "colDescricaoSelecionado";
            this.colDescricaoSelecionado.ReadOnly = true;
            this.colDescricaoSelecionado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colInfCompraVenda
            // 
            this.colInfCompraVenda.HeaderText = "Inf. Compra e Venda";
            this.colInfCompraVenda.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.gear_yellow;
            this.colInfCompraVenda.Name = "colInfCompraVenda";
            this.colInfCompraVenda.ReadOnly = true;
            this.colInfCompraVenda.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRemover
            // 
            this.colRemover.HeaderText = "Remover";
            this.colRemover.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.cancel;
            this.colRemover.Name = "colRemover";
            this.colRemover.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDescricao);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.lblDescricao);
            this.groupBox1.Controls.Add(this.txtCodigoBarras);
            this.groupBox1.Controls.Add(this.lblCodigoBarras);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1327, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // cmbDescricao
            // 
            this.cmbDescricao.FormattingEnabled = true;
            this.cmbDescricao.Location = new System.Drawing.Point(271, 57);
            this.cmbDescricao.Name = "cmbDescricao";
            this.cmbDescricao.Size = new System.Drawing.Size(504, 24);
            this.cmbDescricao.TabIndex = 3;
            this.cmbDescricao.TextChanged += new System.EventHandler(this.cmbDescricao_TextChanged);
            this.cmbDescricao.Enter += new System.EventHandler(this.cmbDescricao_Enter);
            this.cmbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDescricao_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(594, 23);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(181, 22);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(513, 28);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "Código";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(8, 64);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(256, 17);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Filtrar (Descrição, Codigo, Cod. Barras)";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(135, 23);
            this.txtCodigoBarras.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(322, 22);
            this.txtCodigoBarras.TabIndex = 1;
            this.txtCodigoBarras.Enter += new System.EventHandler(this.txtCodigoBarras_Enter);
            this.txtCodigoBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarras_KeyDown);
            // 
            // lblCodigoBarras
            // 
            this.lblCodigoBarras.AutoSize = true;
            this.lblCodigoBarras.Location = new System.Drawing.Point(9, 32);
            this.lblCodigoBarras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoBarras.Name = "lblCodigoBarras";
            this.lblCodigoBarras.Size = new System.Drawing.Size(118, 17);
            this.lblCodigoBarras.TabIndex = 1;
            this.lblCodigoBarras.Text = "Código de Barras";
            // 
            // gpbProdutoServico
            // 
            this.gpbProdutoServico.Controls.Add(this.dgvProdutoServico);
            this.gpbProdutoServico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbProdutoServico.Location = new System.Drawing.Point(4, 124);
            this.gpbProdutoServico.Margin = new System.Windows.Forms.Padding(4);
            this.gpbProdutoServico.Name = "gpbProdutoServico";
            this.gpbProdutoServico.Padding = new System.Windows.Forms.Padding(4);
            this.gpbProdutoServico.Size = new System.Drawing.Size(1327, 270);
            this.gpbProdutoServico.TabIndex = 4;
            this.gpbProdutoServico.TabStop = false;
            this.gpbProdutoServico.Text = "Produtos e Serviços (Use a barra de espaço para selecionar o produto)";
            // 
            // dgvProdutoServico
            // 
            this.dgvProdutoServico.AllowUserToAddRows = false;
            this.dgvProdutoServico.AllowUserToDeleteRows = false;
            this.dgvProdutoServico.AllowUserToOrderColumns = true;
            this.dgvProdutoServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoServico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProdutoServico,
            this.colCodigo,
            this.colCodigoBarras,
            this.colDescricao,
            this.colAdicionar});
            this.dgvProdutoServico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutoServico.Location = new System.Drawing.Point(4, 19);
            this.dgvProdutoServico.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutoServico.Name = "dgvProdutoServico";
            this.dgvProdutoServico.ReadOnly = true;
            this.dgvProdutoServico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutoServico.Size = new System.Drawing.Size(1319, 247);
            this.dgvProdutoServico.TabIndex = 6;
            this.dgvProdutoServico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutoServico_CellContentClick);
            this.dgvProdutoServico.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdutoServico_CellMouseMove);
            this.dgvProdutoServico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProdutoServico_KeyDown);
            // 
            // colIdProdutoServico
            // 
            this.colIdProdutoServico.HeaderText = "Column1";
            this.colIdProdutoServico.Name = "colIdProdutoServico";
            this.colIdProdutoServico.ReadOnly = true;
            this.colIdProdutoServico.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colCodigoBarras
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoBarras.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCodigoBarras.HeaderText = "Código de Barras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            this.colCodigoBarras.ReadOnly = true;
            this.colCodigoBarras.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigoBarras.Width = 200;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAdicionar
            // 
            this.colAdicionar.HeaderText = "Adicionar";
            this.colAdicionar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.tab_new_r;
            this.colAdicionar.Name = "colAdicionar";
            this.colAdicionar.ReadOnly = true;
            this.colAdicionar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GuardarProdutoCompra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1198, 667);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarProdutoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produtos da Compra";
            this.Load += new System.EventHandler(this.GuardarProdutoCompra_Load);
            this.tlpClientes.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosSelecionados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbProdutoServico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoServico)).EndInit();
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(tlpClientes);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label lblCodigoBarras;
        private System.Windows.Forms.GroupBox gpbProdutoServico;
        private System.Windows.Forms.DataGridView dgvProdutoServico;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProdutosSelecionados;
        private System.Windows.Forms.ComboBox cmbDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProdutoServSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoSelecionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarrasSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoSelecionado;
        private System.Windows.Forms.DataGridViewImageColumn colInfCompraVenda;
        private System.Windows.Forms.DataGridViewImageColumn colRemover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProdutoServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colAdicionar;
    }
}