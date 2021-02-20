namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class RelatorioEstoque
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
            this.gpbFiltro = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDetalharFilial = new System.Windows.Forms.CheckBox();
            this.gpbAgrupar = new System.Windows.Forms.GroupBox();
            this.rbtProduto = new System.Windows.Forms.RadioButton();
            this.rbtFilial = new System.Windows.Forms.RadioButton();
            this.cmbProduto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilial = new System.Windows.Forms.ComboBox();
            this.gpbFiltro.SuspendLayout();
            this.gpbAgrupar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbFiltro
            // 
            this.gpbFiltro.Controls.Add(this.label3);
            this.gpbFiltro.Controls.Add(this.chkDetalharFilial);
            this.gpbFiltro.Controls.Add(this.gpbAgrupar);
            this.gpbFiltro.Controls.Add(this.cmbProduto);
            this.gpbFiltro.Controls.Add(this.label2);
            this.gpbFiltro.Controls.Add(this.label1);
            this.gpbFiltro.Controls.Add(this.cmbFilial);
            this.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbFiltro.Location = new System.Drawing.Point(0, 0);
            this.gpbFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.gpbFiltro.Name = "gpbFiltro";
            this.gpbFiltro.Padding = new System.Windows.Forms.Padding(4);
            this.gpbFiltro.Size = new System.Drawing.Size(1202, 133);
            this.gpbFiltro.TabIndex = 7;
            this.gpbFiltro.TabStop = false;
            this.gpbFiltro.Text = "Filtro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 1024;
            this.label3.Text = "Detalhar Por Filial";
            // 
            // chkDetalharFilial
            // 
            this.chkDetalharFilial.AutoSize = true;
            this.chkDetalharFilial.Checked = true;
            this.chkDetalharFilial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDetalharFilial.Location = new System.Drawing.Point(136, 89);
            this.chkDetalharFilial.Margin = new System.Windows.Forms.Padding(4);
            this.chkDetalharFilial.Name = "chkDetalharFilial";
            this.chkDetalharFilial.Size = new System.Drawing.Size(18, 17);
            this.chkDetalharFilial.TabIndex = 1023;
            this.chkDetalharFilial.UseVisualStyleBackColor = true;
            this.chkDetalharFilial.CheckedChanged += new System.EventHandler(this.chkDetalharFilial_CheckedChanged);
            // 
            // gpbAgrupar
            // 
            this.gpbAgrupar.Controls.Add(this.rbtProduto);
            this.gpbAgrupar.Controls.Add(this.rbtFilial);
            this.gpbAgrupar.Location = new System.Drawing.Point(511, 22);
            this.gpbAgrupar.Margin = new System.Windows.Forms.Padding(4);
            this.gpbAgrupar.Name = "gpbAgrupar";
            this.gpbAgrupar.Padding = new System.Windows.Forms.Padding(4);
            this.gpbAgrupar.Size = new System.Drawing.Size(247, 54);
            this.gpbAgrupar.TabIndex = 1022;
            this.gpbAgrupar.TabStop = false;
            this.gpbAgrupar.Text = "Agrupar Por";
            // 
            // rbtProduto
            // 
            this.rbtProduto.AutoSize = true;
            this.rbtProduto.Location = new System.Drawing.Point(140, 26);
            this.rbtProduto.Margin = new System.Windows.Forms.Padding(4);
            this.rbtProduto.Name = "rbtProduto";
            this.rbtProduto.Size = new System.Drawing.Size(79, 21);
            this.rbtProduto.TabIndex = 1;
            this.rbtProduto.TabStop = true;
            this.rbtProduto.Text = "Produto";
            this.rbtProduto.UseVisualStyleBackColor = true;
            // 
            // rbtFilial
            // 
            this.rbtFilial.AutoSize = true;
            this.rbtFilial.Checked = true;
            this.rbtFilial.Location = new System.Drawing.Point(21, 26);
            this.rbtFilial.Margin = new System.Windows.Forms.Padding(4);
            this.rbtFilial.Name = "rbtFilial";
            this.rbtFilial.Size = new System.Drawing.Size(57, 21);
            this.rbtFilial.TabIndex = 0;
            this.rbtFilial.TabStop = true;
            this.rbtFilial.Text = "Filial";
            this.rbtFilial.UseVisualStyleBackColor = true;
            // 
            // cmbProduto
            // 
            this.cmbProduto.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.Location = new System.Drawing.Point(136, 52);
            this.cmbProduto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.Size = new System.Drawing.Size(325, 24);
            this.cmbProduto.TabIndex = 1021;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1020;
            this.label2.Text = "Produto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 1019;
            this.label1.Text = "Filial";
            // 
            // cmbFilial
            // 
            this.cmbFilial.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilial.FormattingEnabled = true;
            this.cmbFilial.Location = new System.Drawing.Point(136, 22);
            this.cmbFilial.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilial.Name = "cmbFilial";
            this.cmbFilial.Size = new System.Drawing.Size(325, 24);
            this.cmbFilial.TabIndex = 1018;
            // 
            // RelatorioEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 305);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "RelatorioEstoque";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatório de Estoque";
            this.gpbFiltro.ResumeLayout(false);
            this.gpbFiltro.PerformLayout();
            this.gpbAgrupar.ResumeLayout(false);
            this.gpbAgrupar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilial;
        private System.Windows.Forms.ComboBox cmbProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDetalharFilial;
        private System.Windows.Forms.GroupBox gpbAgrupar;
        private System.Windows.Forms.RadioButton rbtProduto;
        private System.Windows.Forms.RadioButton rbtFilial;

    }
}