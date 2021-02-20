namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscaProdutoServico
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
            this.tlpClientes = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.lblCodigoBarras = new System.Windows.Forms.Label();
            this.gpbProdutoServico = new System.Windows.Forms.GroupBox();
            this.dgvProdutoServico = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImgProduto = new System.Windows.Forms.DataGridViewImageColumn();
            this.colAtalhoImagem = new System.Windows.Forms.DataGridViewImageColumn();
            this.colInformacoesFilial = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDefinirEstoqueAtual = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colConsultar = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbProdutoServico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoServico)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tlpClientes.Controls.Add(this.gpbProdutoServico, 0, 1);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpClientes.Location = new System.Drawing.Point(0, 107);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 2;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Size = new System.Drawing.Size(1528, 652);
            this.tlpClientes.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Controls.Add(this.lblDescricao);
            this.groupBox1.Controls.Add(this.txtCodigoBarras);
            this.groupBox1.Controls.Add(this.lblCodigoBarras);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1520, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(467, 23);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(172, 22);
            this.txtCodigo.TabIndex = 7;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(405, 32);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "Código";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(135, 55);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(504, 22);
            this.txtDescricao.TabIndex = 5;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(8, 64);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(71, 17);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(135, 23);
            this.txtCodigoBarras.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(232, 22);
            this.txtCodigoBarras.TabIndex = 1;
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
            this.gpbProdutoServico.Size = new System.Drawing.Size(1520, 524);
            this.gpbProdutoServico.TabIndex = 4;
            this.gpbProdutoServico.TabStop = false;
            this.gpbProdutoServico.Text = "Produtos e Serviços";
            // 
            // dgvProdutoServico
            // 
            this.dgvProdutoServico.AllowUserToAddRows = false;
            this.dgvProdutoServico.AllowUserToDeleteRows = false;
            this.dgvProdutoServico.AllowUserToOrderColumns = true;
            this.dgvProdutoServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoServico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colCodigo,
            this.colCodigoBarras,
            this.colDescricao,
            this.colImgProduto,
            this.colAtalhoImagem,
            this.colInformacoesFilial,
            this.colDefinirEstoqueAtual,
            this.colEditar,
            this.colExcluir,
            this.colConsultar});
            this.dgvProdutoServico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutoServico.Location = new System.Drawing.Point(4, 19);
            this.dgvProdutoServico.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutoServico.Name = "dgvProdutoServico";
            this.dgvProdutoServico.ReadOnly = true;
            this.dgvProdutoServico.Size = new System.Drawing.Size(1512, 501);
            this.dgvProdutoServico.TabIndex = 5;
            this.dgvProdutoServico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellContentClick);
            this.dgvProdutoServico.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMarcas_CellMouseMove);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colCodigoBarras.DefaultCellStyle = dataGridViewCellStyle1;
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
            // colImgProduto
            // 
            this.colImgProduto.HeaderText = "Imagem";
            this.colImgProduto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colImgProduto.Name = "colImgProduto";
            this.colImgProduto.ReadOnly = true;
            this.colImgProduto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImgProduto.ToolTipText = "Clique na imagem  para auementar o zoom.";
            this.colImgProduto.Visible = false;
            this.colImgProduto.Width = 150;
            // 
            // colAtalhoImagem
            // 
            this.colAtalhoImagem.HeaderText = "Imagem";
            this.colAtalhoImagem.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.image;
            this.colAtalhoImagem.Name = "colAtalhoImagem";
            this.colAtalhoImagem.ReadOnly = true;
            this.colAtalhoImagem.ToolTipText = "Clique na imagem  para auementar o zoom.";
            // 
            // colInformacoesFilial
            // 
            this.colInformacoesFilial.HeaderText = "Outras Informações do Produto";
            this.colInformacoesFilial.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.gear_yellow;
            this.colInformacoesFilial.Name = "colInformacoesFilial";
            this.colInformacoesFilial.ReadOnly = true;
            this.colInformacoesFilial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDefinirEstoqueAtual
            // 
            this.colDefinirEstoqueAtual.HeaderText = "Estoque Atual";
            this.colDefinirEstoqueAtual.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.stock_market;
            this.colDefinirEstoqueAtual.Name = "colDefinirEstoqueAtual";
            this.colDefinirEstoqueAtual.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colConsultar
            // 
            this.colConsultar.HeaderText = "Consultar";
            this.colConsultar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.search_16;
            this.colConsultar.Name = "colConsultar";
            this.colConsultar.ReadOnly = true;
            this.colConsultar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BuscaProdutoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 759);
            this.Controls.Add(this.tlpClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "BuscaProdutoServico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produtos e Serviços";
            this.Controls.SetChildIndex(this.tlpClientes, 0);
            this.tlpClientes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbProdutoServico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoServico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label lblCodigoBarras;
        private System.Windows.Forms.GroupBox gpbProdutoServico;
        private System.Windows.Forms.DataGridView dgvProdutoServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colImgProduto;
        private System.Windows.Forms.DataGridViewImageColumn colAtalhoImagem;
        private System.Windows.Forms.DataGridViewImageColumn colInformacoesFilial;
        private System.Windows.Forms.DataGridViewImageColumn colDefinirEstoqueAtual;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.DataGridViewImageColumn colConsultar;
    }
}