namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscaProcesso
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
            this.gpbClientes = new System.Windows.Forms.GroupBox();
            this.dgvCores = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoProcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntervalo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpClientes.SuspendLayout();
            this.gpbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpClientes
            // 
            this.tlpClientes.ColumnCount = 1;
            this.tlpClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.Controls.Add(this.gpbClientes, 0, 0);
            this.tlpClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpClientes.Location = new System.Drawing.Point(0, 122);
            this.tlpClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tlpClientes.Name = "tlpClientes";
            this.tlpClientes.RowCount = 1;
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 652F));
            this.tlpClientes.Size = new System.Drawing.Size(1537, 652);
            this.tlpClientes.TabIndex = 7;
            // 
            // gpbClientes
            // 
            this.gpbClientes.Controls.Add(this.dgvCores);
            this.gpbClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbClientes.Location = new System.Drawing.Point(4, 4);
            this.gpbClientes.Margin = new System.Windows.Forms.Padding(4);
            this.gpbClientes.Name = "gpbClientes";
            this.gpbClientes.Padding = new System.Windows.Forms.Padding(4);
            this.gpbClientes.Size = new System.Drawing.Size(1529, 644);
            this.gpbClientes.TabIndex = 4;
            this.gpbClientes.TabStop = false;
            this.gpbClientes.Text = "Processos";
            // 
            // dgvCores
            // 
            this.dgvCores.AllowUserToAddRows = false;
            this.dgvCores.AllowUserToDeleteRows = false;
            this.dgvCores.AllowUserToOrderColumns = true;
            this.dgvCores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colTipoProcesso,
            this.colDescricao,
            this.colIntervalo,
            this.colEditar,
            this.colExcluir});
            this.dgvCores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCores.Location = new System.Drawing.Point(4, 19);
            this.dgvCores.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCores.Name = "dgvCores";
            this.dgvCores.ReadOnly = true;
            this.dgvCores.Size = new System.Drawing.Size(1521, 621);
            this.dgvCores.TabIndex = 5;
            this.dgvCores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCores_CellContentClick);
            this.dgvCores.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCores_CellMouseMove);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colTipoProcesso
            // 
            this.colTipoProcesso.FillWeight = 150F;
            this.colTipoProcesso.HeaderText = "Tipo Processo";
            this.colTipoProcesso.Name = "colTipoProcesso";
            this.colTipoProcesso.ReadOnly = true;
            this.colTipoProcesso.Width = 150;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colIntervalo
            // 
            this.colIntervalo.FillWeight = 150F;
            this.colIntervalo.HeaderText = "Intervalo Execuçao";
            this.colIntervalo.Name = "colIntervalo";
            this.colIntervalo.ReadOnly = true;
            this.colIntervalo.Width = 150;
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
            this.colExcluir.HeaderText = "Desativar";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BuscaProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 774);
            this.Controls.Add(this.tlpClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "BuscaProcesso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processos";
            this.Controls.SetChildIndex(this.tlpClientes, 0);
            this.tlpClientes.ResumeLayout(false);
            this.gpbClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpClientes;
        private System.Windows.Forms.GroupBox gpbClientes;
        private System.Windows.Forms.DataGridView dgvCores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoProcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIntervalo;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}