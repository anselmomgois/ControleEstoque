namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscaCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.gpbMarca = new System.Windows.Forms.GroupBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodNotaFiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRastreio = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colConsultar = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.gpbFiliais = new System.Windows.Forms.GroupBox();
            this.lstFiliais = new System.Windows.Forms.ListBox();
            this.gpbData = new System.Windows.Forms.GroupBox();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.lblFim = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblInicio = new System.Windows.Forms.Label();
            this.tlpPrincipal.SuspendLayout();
            this.gpbMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpbFiliais.SuspendLayout();
            this.gpbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.gpbMarca, 0, 1);
            this.tlpPrincipal.Controls.Add(this.groupBox1, 0, 0);
            this.tlpPrincipal.Location = new System.Drawing.Point(6, 176);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPrincipal.Size = new System.Drawing.Size(1523, 621);
            this.tlpPrincipal.TabIndex = 7;
            // 
            // gpbMarca
            // 
            this.gpbMarca.Controls.Add(this.dgvMarcas);
            this.gpbMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbMarca.Location = new System.Drawing.Point(4, 204);
            this.gpbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.gpbMarca.Name = "gpbMarca";
            this.gpbMarca.Padding = new System.Windows.Forms.Padding(4);
            this.gpbMarca.Size = new System.Drawing.Size(1515, 413);
            this.gpbMarca.TabIndex = 14;
            this.gpbMarca.TabStop = false;
            this.gpbMarca.Text = "Compras";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificador,
            this.colCodigoCompra,
            this.colCodNotaFiscal,
            this.colDataCompra,
            this.colFornecedor,
            this.colDataRecebimento,
            this.colRastreio,
            this.colEditar,
            this.colExcluir,
            this.colConsultar});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(4, 19);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(1507, 390);
            this.dgvMarcas.TabIndex = 14;
            this.dgvMarcas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellContentClick);
            this.dgvMarcas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMarcas_CellMouseMove);
            // 
            // colIdentificador
            // 
            this.colIdentificador.HeaderText = "Column1";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            this.colIdentificador.Visible = false;
            // 
            // colCodigoCompra
            // 
            this.colCodigoCompra.HeaderText = "Código";
            this.colCodigoCompra.Name = "colCodigoCompra";
            this.colCodigoCompra.ReadOnly = true;
            this.colCodigoCompra.Width = 250;
            // 
            // colCodNotaFiscal
            // 
            this.colCodNotaFiscal.HeaderText = "Nota Fiscal";
            this.colCodNotaFiscal.Name = "colCodNotaFiscal";
            this.colCodNotaFiscal.ReadOnly = true;
            this.colCodNotaFiscal.Width = 180;
            // 
            // colDataCompra
            // 
            this.colDataCompra.HeaderText = "Data";
            this.colDataCompra.Name = "colDataCompra";
            this.colDataCompra.ReadOnly = true;
            this.colDataCompra.Width = 150;
            // 
            // colFornecedor
            // 
            this.colFornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colFornecedor.DefaultCellStyle = dataGridViewCellStyle6;
            this.colFornecedor.HeaderText = "Fornecedor";
            this.colFornecedor.Name = "colFornecedor";
            this.colFornecedor.ReadOnly = true;
            this.colFornecedor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colDataRecebimento
            // 
            this.colDataRecebimento.HeaderText = "Recebimento";
            this.colDataRecebimento.Name = "colDataRecebimento";
            this.colDataRecebimento.ReadOnly = true;
            this.colDataRecebimento.Width = 120;
            // 
            // colRastreio
            // 
            this.colRastreio.HeaderText = "Rastreio";
            this.colRastreio.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.lorrygreen;
            this.colRastreio.Name = "colRastreio";
            this.colRastreio.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEditar.Width = 50;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluir.Width = 50;
            // 
            // colConsultar
            // 
            this.colConsultar.HeaderText = "Consultar";
            this.colConsultar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.search_16;
            this.colConsultar.Name = "colConsultar";
            this.colConsultar.ReadOnly = true;
            this.colConsultar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colConsultar.Width = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.gpbFiliais);
            this.groupBox1.Controls.Add(this.gpbData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1517, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(102, 160);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(279, 22);
            this.txtCodigo.TabIndex = 12;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 165);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(52, 17);
            this.lblNome.TabIndex = 13;
            this.lblNome.Text = "Código";
            // 
            // cmbEstado
            // 
            this.cmbEstado.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(102, 128);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(279, 24);
            this.cmbEstado.TabIndex = 11;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(9, 135);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(52, 17);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado";
            // 
            // gpbFiliais
            // 
            this.gpbFiliais.Controls.Add(this.lstFiliais);
            this.gpbFiliais.Location = new System.Drawing.Point(10, 22);
            this.gpbFiliais.Margin = new System.Windows.Forms.Padding(4);
            this.gpbFiliais.Name = "gpbFiliais";
            this.gpbFiliais.Padding = new System.Windows.Forms.Padding(4);
            this.gpbFiliais.Size = new System.Drawing.Size(593, 98);
            this.gpbFiliais.TabIndex = 7;
            this.gpbFiliais.TabStop = false;
            this.gpbFiliais.Text = "Filiais";
            // 
            // lstFiliais
            // 
            this.lstFiliais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiliais.FormattingEnabled = true;
            this.lstFiliais.ItemHeight = 16;
            this.lstFiliais.Location = new System.Drawing.Point(4, 19);
            this.lstFiliais.Margin = new System.Windows.Forms.Padding(4);
            this.lstFiliais.Name = "lstFiliais";
            this.lstFiliais.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiliais.Size = new System.Drawing.Size(585, 75);
            this.lstFiliais.TabIndex = 2;
            // 
            // gpbData
            // 
            this.gpbData.Controls.Add(this.dtpFim);
            this.gpbData.Controls.Add(this.lblFim);
            this.gpbData.Controls.Add(this.dtpInicio);
            this.gpbData.Controls.Add(this.lblInicio);
            this.gpbData.Location = new System.Drawing.Point(620, 22);
            this.gpbData.Margin = new System.Windows.Forms.Padding(4);
            this.gpbData.Name = "gpbData";
            this.gpbData.Padding = new System.Windows.Forms.Padding(4);
            this.gpbData.Size = new System.Drawing.Size(362, 98);
            this.gpbData.TabIndex = 6;
            this.gpbData.TabStop = false;
            this.gpbData.Text = "Data";
            // 
            // dtpFim
            // 
            this.dtpFim.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFim.Location = new System.Drawing.Point(63, 68);
            this.dtpFim.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.ShowCheckBox = true;
            this.dtpFim.Size = new System.Drawing.Size(291, 22);
            this.dtpFim.TabIndex = 7;
            // 
            // lblFim
            // 
            this.lblFim.AutoSize = true;
            this.lblFim.Location = new System.Drawing.Point(9, 76);
            this.lblFim.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFim.Name = "lblFim";
            this.lblFim.Size = new System.Drawing.Size(30, 17);
            this.lblFim.TabIndex = 4;
            this.lblFim.Text = "Fim";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(63, 36);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.ShowCheckBox = true;
            this.dtpInicio.Size = new System.Drawing.Size(291, 22);
            this.dtpInicio.TabIndex = 6;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(9, 44);
            this.lblInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(40, 17);
            this.lblInicio.TabIndex = 2;
            this.lblInicio.Text = "Início";
            // 
            // BuscaCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 797);
            this.Controls.Add(this.tlpPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscaCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras";
            this.Controls.SetChildIndex(this.tlpPrincipal, 0);
            this.tlpPrincipal.ResumeLayout(false);
            this.gpbMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbFiliais.ResumeLayout(false);
            this.gpbData.ResumeLayout(false);
            this.gpbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gpbData;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.GroupBox gpbFiliais;
        private System.Windows.Forms.ListBox lstFiliais;
        private System.Windows.Forms.GroupBox gpbMarca;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodNotaFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataRecebimento;
        private System.Windows.Forms.DataGridViewImageColumn colRastreio;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.DataGridViewImageColumn colConsultar;
    }
}