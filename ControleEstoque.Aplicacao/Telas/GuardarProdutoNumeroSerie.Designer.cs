namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoNumeroSerie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarProdutoNumeroSerie));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.gpbNumerosSerie = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNumeroSerie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroSerie = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblQuantidadeLidaValor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblQuantidaCompradaValor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.gpbNumerosSerie.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlPrincipal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 406);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.gpbNumerosSerie);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(503, 370);
            this.pnlPrincipal.TabIndex = 17;
            // 
            // gpbNumerosSerie
            // 
            this.gpbNumerosSerie.Controls.Add(this.tableLayoutPanel2);
            this.gpbNumerosSerie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbNumerosSerie.Location = new System.Drawing.Point(0, 0);
            this.gpbNumerosSerie.Name = "gpbNumerosSerie";
            this.gpbNumerosSerie.Size = new System.Drawing.Size(503, 370);
            this.gpbNumerosSerie.TabIndex = 16;
            this.gpbNumerosSerie.TabStop = false;
            this.gpbNumerosSerie.Text = "Números de Seríe";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dgvMarcas, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(497, 349);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AllowUserToOrderColumns = true;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colNumeroSerie,
            this.colExcluir});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(4, 44);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(489, 301);
            this.dgvMarcas.TabIndex = 3;
            this.dgvMarcas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellContentClick);
            this.dgvMarcas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMarcas_CellMouseMove);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colNumeroSerie
            // 
            this.colNumeroSerie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNumeroSerie.HeaderText = "Descrição";
            this.colNumeroSerie.Name = "colNumeroSerie";
            this.colNumeroSerie.ReadOnly = true;
            this.colNumeroSerie.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluir.Width = 80;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel3.Controls.Add(this.btnNumeroSerie, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtNumeroSerie, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(491, 34);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnNumeroSerie
            // 
            this.btnNumeroSerie.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNumeroSerie.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnNumeroSerie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNumeroSerie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNumeroSerie.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.sub_blue_add;
            this.btnNumeroSerie.Location = new System.Drawing.Point(450, 5);
            this.btnNumeroSerie.Margin = new System.Windows.Forms.Padding(4);
            this.btnNumeroSerie.Name = "btnNumeroSerie";
            this.btnNumeroSerie.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNumeroSerie.Size = new System.Drawing.Size(37, 24);
            this.btnNumeroSerie.TabIndex = 2;
            this.btnNumeroSerie.UseVisualStyleBackColor = false;
            this.btnNumeroSerie.Click += new System.EventHandler(this.btnNumeroSerie_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de Seríe:";
            // 
            // txtNumeroSerie
            // 
            this.txtNumeroSerie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroSerie.Location = new System.Drawing.Point(143, 6);
            this.txtNumeroSerie.Name = "txtNumeroSerie";
            this.txtNumeroSerie.Size = new System.Drawing.Size(300, 22);
            this.txtNumeroSerie.TabIndex = 1;
            this.txtNumeroSerie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroSerie_KeyDown);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel4.Controls.Add(this.lblQuantidadeLidaValor, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblQuantidaCompradaValor, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 379);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(503, 24);
            this.tableLayoutPanel4.TabIndex = 18;
            // 
            // lblQuantidadeLidaValor
            // 
            this.lblQuantidadeLidaValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuantidadeLidaValor.AutoSize = true;
            this.lblQuantidadeLidaValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeLidaValor.ForeColor = System.Drawing.Color.Green;
            this.lblQuantidadeLidaValor.Location = new System.Drawing.Point(425, 3);
            this.lblQuantidadeLidaValor.Name = "lblQuantidadeLidaValor";
            this.lblQuantidadeLidaValor.Size = new System.Drawing.Size(17, 17);
            this.lblQuantidadeLidaValor.TabIndex = 3;
            this.lblQuantidadeLidaValor.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quant. Lida:";
            // 
            // lblQuantidaCompradaValor
            // 
            this.lblQuantidaCompradaValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuantidaCompradaValor.AutoSize = true;
            this.lblQuantidaCompradaValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidaCompradaValor.ForeColor = System.Drawing.Color.Red;
            this.lblQuantidaCompradaValor.Location = new System.Drawing.Point(174, 3);
            this.lblQuantidaCompradaValor.Name = "lblQuantidaCompradaValor";
            this.lblQuantidaCompradaValor.Size = new System.Drawing.Size(17, 17);
            this.lblQuantidaCompradaValor.TabIndex = 1;
            this.lblQuantidaCompradaValor.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quant. Comprada:";
            // 
            // GuardarProdutoNumeroSerie
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(515, 542);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarProdutoNumeroSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Números de Seríe";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.gpbNumerosSerie.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.GroupBox gpbNumerosSerie;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroSerie;
        private System.Windows.Forms.Button btnNumeroSerie;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroSerie;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblQuantidadeLidaValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblQuantidaCompradaValor;
        private System.Windows.Forms.Label label2;
    }
}