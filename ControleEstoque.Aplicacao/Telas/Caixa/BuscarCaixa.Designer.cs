namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class BuscarCaixa
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
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.tblBotaoInserir = new System.Windows.Forms.TableLayoutPanel();
            this.gpbCaixa = new System.Windows.Forms.GroupBox();
            this.dgvCaixa = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstaAberto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colHostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpbFiltro = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tlpGeral.SuspendLayout();
            this.tblBotaoInserir.SuspendLayout();
            this.gpbCaixa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaixa)).BeginInit();
            this.gpbFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 1;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeral.Controls.Add(this.tblBotaoInserir, 0, 1);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 2;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.18315F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 465F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGeral.Size = new System.Drawing.Size(901, 605);
            this.tlpGeral.TabIndex = 7;
            // 
            // tblBotaoInserir
            // 
            this.tblBotaoInserir.ColumnCount = 2;
            this.tblBotaoInserir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tblBotaoInserir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.20112F));
            this.tblBotaoInserir.Controls.Add(this.gpbCaixa, 0, 1);
            this.tblBotaoInserir.Controls.Add(this.gpbFiltro, 0, 0);
            this.tblBotaoInserir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBotaoInserir.Location = new System.Drawing.Point(3, 143);
            this.tblBotaoInserir.Name = "tblBotaoInserir";
            this.tblBotaoInserir.RowCount = 2;
            this.tblBotaoInserir.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBotaoInserir.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 388F));
            this.tblBotaoInserir.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblBotaoInserir.Size = new System.Drawing.Size(895, 459);
            this.tblBotaoInserir.TabIndex = 0;
            // 
            // gpbCaixa
            // 
            this.tblBotaoInserir.SetColumnSpan(this.gpbCaixa, 2);
            this.gpbCaixa.Controls.Add(this.dgvCaixa);
            this.gpbCaixa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbCaixa.Location = new System.Drawing.Point(3, 74);
            this.gpbCaixa.Name = "gpbCaixa";
            this.gpbCaixa.Size = new System.Drawing.Size(889, 382);
            this.gpbCaixa.TabIndex = 9;
            this.gpbCaixa.TabStop = false;
            this.gpbCaixa.Text = "Caixas";
            // 
            // dgvCaixa
            // 
            this.dgvCaixa.AllowUserToAddRows = false;
            this.dgvCaixa.AllowUserToDeleteRows = false;
            this.dgvCaixa.AllowUserToOrderColumns = true;
            this.dgvCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCodigo,
            this.colEstaAberto,
            this.colHostName,
            this.colEditar,
            this.colExcluir});
            this.dgvCaixa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaixa.Location = new System.Drawing.Point(3, 16);
            this.dgvCaixa.Name = "dgvCaixa";
            this.dgvCaixa.ReadOnly = true;
            this.dgvCaixa.Size = new System.Drawing.Size(883, 363);
            this.dgvCaixa.TabIndex = 5;
            this.dgvCaixa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaixa_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colEstaAberto
            // 
            this.colEstaAberto.HeaderText = "Caixa aberto";
            this.colEstaAberto.Name = "colEstaAberto";
            this.colEstaAberto.ReadOnly = true;
            // 
            // colHostName
            // 
            this.colHostName.HeaderText = "Host Máquina";
            this.colHostName.Name = "colHostName";
            this.colHostName.ReadOnly = true;
            this.colHostName.Width = 150;
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
            // gpbFiltro
            // 
            this.tblBotaoInserir.SetColumnSpan(this.gpbFiltro, 2);
            this.gpbFiltro.Controls.Add(this.txtCodigo);
            this.gpbFiltro.Controls.Add(this.lblCodigo);
            this.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbFiltro.Location = new System.Drawing.Point(3, 3);
            this.gpbFiltro.Name = "gpbFiltro";
            this.gpbFiltro.Size = new System.Drawing.Size(889, 65);
            this.gpbFiltro.TabIndex = 10;
            this.gpbFiltro.TabStop = false;
            this.gpbFiltro.Text = "Filtro";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(82, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(297, 20);
            this.txtCodigo.TabIndex = 9;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 32);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código:";
            // 
            // BuscarCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 605);
            this.Controls.Add(this.tlpGeral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BuscarCaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Caixa";
            this.Load += new System.EventHandler(this.BuscarFormaPagamento_Load);
            this.Controls.SetChildIndex(this.tlpGeral, 0);
            this.tlpGeral.ResumeLayout(false);
            this.tblBotaoInserir.ResumeLayout(false);
            this.gpbCaixa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaixa)).EndInit();
            this.gpbFiltro.ResumeLayout(false);
            this.gpbFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.TableLayoutPanel tblBotaoInserir;
        private System.Windows.Forms.GroupBox gpbCaixa;
        private System.Windows.Forms.DataGridView dgvCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEstaAberto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostName;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.GroupBox gpbFiltro;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
    }
}