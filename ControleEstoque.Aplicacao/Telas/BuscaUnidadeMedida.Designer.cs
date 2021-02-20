namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscaUnidadeMedida
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
            this.tlpClientes = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.gpbUnidadeMedida = new System.Windows.Forms.GroupBox();
            this.dgvUnidadesMedida = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescUnidadePai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbUnidadeMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadesMedida)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tlpClientes.Controls.Add(this.gpbUnidadeMedida, 0, 1);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpClientes.Location = new System.Drawing.Point(0, 107);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 2;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Size = new System.Drawing.Size(1533, 652);
            this.tlpClientes.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1525, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(123, 23);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(504, 22);
            this.txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 32);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(91, 17);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome da Cor";
            // 
            // gpbUnidadeMedida
            // 
            this.gpbUnidadeMedida.Controls.Add(this.dgvUnidadesMedida);
            this.gpbUnidadeMedida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbUnidadeMedida.Location = new System.Drawing.Point(4, 102);
            this.gpbUnidadeMedida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbUnidadeMedida.Name = "gpbUnidadeMedida";
            this.gpbUnidadeMedida.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbUnidadeMedida.Size = new System.Drawing.Size(1525, 546);
            this.gpbUnidadeMedida.TabIndex = 4;
            this.gpbUnidadeMedida.TabStop = false;
            this.gpbUnidadeMedida.Text = "Unidades de Medida";
            // 
            // dgvUnidadesMedida
            // 
            this.dgvUnidadesMedida.AllowUserToAddRows = false;
            this.dgvUnidadesMedida.AllowUserToDeleteRows = false;
            this.dgvUnidadesMedida.AllowUserToOrderColumns = true;
            this.dgvUnidadesMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidadesMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colCodigo,
            this.colDescricao,
            this.colDescUnidadePai,
            this.colEditar,
            this.colExcluir});
            this.dgvUnidadesMedida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnidadesMedida.Location = new System.Drawing.Point(4, 19);
            this.dgvUnidadesMedida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvUnidadesMedida.Name = "dgvUnidadesMedida";
            this.dgvUnidadesMedida.ReadOnly = true;
            this.dgvUnidadesMedida.Size = new System.Drawing.Size(1517, 523);
            this.dgvUnidadesMedida.TabIndex = 5;
            this.dgvUnidadesMedida.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnidadesMedida_CellContentClick);
            this.dgvUnidadesMedida.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUnidadesMedida_CellMouseMove);
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
            // colDescricao
            // 
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDescricao.Width = 250;
            // 
            // colDescUnidadePai
            // 
            this.colDescUnidadePai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescUnidadePai.HeaderText = "Descrição Unidade Pai";
            this.colDescUnidadePai.Name = "colDescUnidadePai";
            this.colDescUnidadePai.ReadOnly = true;
            this.colDescUnidadePai.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // BuscaUnidadeMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 759);
            this.Controls.Add(this.tlpClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "BuscaUnidadeMedida";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unidade de Medida";
            this.Controls.SetChildIndex(this.tlpClientes, 0);
            this.tlpClientes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbUnidadeMedida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadesMedida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox gpbUnidadeMedida;
        private System.Windows.Forms.DataGridView dgvUnidadesMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescUnidadePai;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}