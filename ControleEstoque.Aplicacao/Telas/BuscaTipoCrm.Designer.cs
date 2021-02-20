namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscaTipoCrm
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
            this.gpbMarca = new System.Windows.Forms.GroupBox();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescTipoStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescStatusPadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.gpbMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.gpbMarca, 0, 1);
            this.tlpClientes.Controls.Add(this.groupBox1, 0, 0);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpClientes.Location = new System.Drawing.Point(0, 107);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 2;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Size = new System.Drawing.Size(1201, 652);
            this.tlpClientes.TabIndex = 10;
            // 
            // gpbMarca
            // 
            this.gpbMarca.Controls.Add(this.dgvMarcas);
            this.gpbMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbMarca.Location = new System.Drawing.Point(4, 102);
            this.gpbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.gpbMarca.Name = "gpbMarca";
            this.gpbMarca.Padding = new System.Windows.Forms.Padding(4);
            this.gpbMarca.Size = new System.Drawing.Size(1193, 546);
            this.gpbMarca.TabIndex = 4;
            this.gpbMarca.TabStop = false;
            this.gpbMarca.Text = "Administradoras";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToDeleteRows = false;
            this.dgvMarcas.AllowUserToOrderColumns = true;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colDescricao,
            this.colDescTipoStatus,
            this.colDescStatusPadrao,
            this.colEditar,
            this.colExcluir});
            this.dgvMarcas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarcas.Location = new System.Drawing.Point(4, 19);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.Size = new System.Drawing.Size(1185, 523);
            this.dgvMarcas.TabIndex = 5;
            this.dgvMarcas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellContentClick);
            this.dgvMarcas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMarcas_CellMouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1193, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(91, 23);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(556, 22);
            this.txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 32);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Descrição";
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDescTipoStatus
            // 
            this.colDescTipoStatus.FillWeight = 150F;
            this.colDescTipoStatus.HeaderText = "Tipo de Status";
            this.colDescTipoStatus.Name = "colDescTipoStatus";
            this.colDescTipoStatus.ReadOnly = true;
            this.colDescTipoStatus.Width = 150;
            // 
            // colDescStatusPadrao
            // 
            this.colDescStatusPadrao.FillWeight = 150F;
            this.colDescStatusPadrao.HeaderText = "Status Padrão";
            this.colDescStatusPadrao.Name = "colDescStatusPadrao";
            this.colDescStatusPadrao.ReadOnly = true;
            this.colDescStatusPadrao.Width = 150;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEditar.Width = 80;
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
            // BuscaTipoCrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 759);
            this.Controls.Add(this.tlpClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "BuscaTipoCrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipo CRM";
            this.Controls.SetChildIndex(this.tlpClientes, 0);
            this.tlpClientes.ResumeLayout(false);
            this.gpbMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox gpbMarca;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescTipoStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescStatusPadrao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}