namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class RelatorioPessoa
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
            this.gpbTipoPessoa = new System.Windows.Forms.GroupBox();
            this.rbtCliente = new System.Windows.Forms.RadioButton();
            this.rbtFornecedor = new System.Windows.Forms.RadioButton();
            this.rbtFuncionario = new System.Windows.Forms.RadioButton();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilial = new System.Windows.Forms.ComboBox();
            this.gpbFiltro.SuspendLayout();
            this.gpbTipoPessoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbFiltro
            // 
            this.gpbFiltro.Controls.Add(this.gpbTipoPessoa);
            this.gpbFiltro.Controls.Add(this.txtCPF);
            this.gpbFiltro.Controls.Add(this.lblCPF);
            this.gpbFiltro.Controls.Add(this.txtCnpj);
            this.gpbFiltro.Controls.Add(this.lblCnpj);
            this.gpbFiltro.Controls.Add(this.txtNome);
            this.gpbFiltro.Controls.Add(this.lblNome);
            this.gpbFiltro.Controls.Add(this.label1);
            this.gpbFiltro.Controls.Add(this.cmbFilial);
            this.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbFiltro.Location = new System.Drawing.Point(0, 0);
            this.gpbFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbFiltro.Name = "gpbFiltro";
            this.gpbFiltro.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbFiltro.Size = new System.Drawing.Size(1186, 194);
            this.gpbFiltro.TabIndex = 7;
            this.gpbFiltro.TabStop = false;
            this.gpbFiltro.Text = "Filtros";
            // 
            // gpbTipoPessoa
            // 
            this.gpbTipoPessoa.Controls.Add(this.rbtCliente);
            this.gpbTipoPessoa.Controls.Add(this.rbtFornecedor);
            this.gpbTipoPessoa.Controls.Add(this.rbtFuncionario);
            this.gpbTipoPessoa.Location = new System.Drawing.Point(436, 34);
            this.gpbTipoPessoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbTipoPessoa.Name = "gpbTipoPessoa";
            this.gpbTipoPessoa.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbTipoPessoa.Size = new System.Drawing.Size(343, 53);
            this.gpbTipoPessoa.TabIndex = 1028;
            this.gpbTipoPessoa.TabStop = false;
            this.gpbTipoPessoa.Text = "Tipo de Pessoa";
            // 
            // rbtCliente
            // 
            this.rbtCliente.AutoSize = true;
            this.rbtCliente.Location = new System.Drawing.Point(228, 22);
            this.rbtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.rbtCliente.Name = "rbtCliente";
            this.rbtCliente.Size = new System.Drawing.Size(72, 21);
            this.rbtCliente.TabIndex = 3;
            this.rbtCliente.Text = "Cliente";
            this.rbtCliente.UseVisualStyleBackColor = true;
            this.rbtCliente.CheckedChanged += new System.EventHandler(this.rbtCliente_CheckedChanged);
            // 
            // rbtFornecedor
            // 
            this.rbtFornecedor.AutoSize = true;
            this.rbtFornecedor.Location = new System.Drawing.Point(117, 22);
            this.rbtFornecedor.Margin = new System.Windows.Forms.Padding(4);
            this.rbtFornecedor.Name = "rbtFornecedor";
            this.rbtFornecedor.Size = new System.Drawing.Size(102, 21);
            this.rbtFornecedor.TabIndex = 2;
            this.rbtFornecedor.Text = "Fornecedor";
            this.rbtFornecedor.UseVisualStyleBackColor = true;
            this.rbtFornecedor.CheckedChanged += new System.EventHandler(this.rbtFornecedor_CheckedChanged);
            // 
            // rbtFuncionario
            // 
            this.rbtFuncionario.AutoSize = true;
            this.rbtFuncionario.Checked = true;
            this.rbtFuncionario.Location = new System.Drawing.Point(7, 22);
            this.rbtFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.rbtFuncionario.Name = "rbtFuncionario";
            this.rbtFuncionario.Size = new System.Drawing.Size(103, 21);
            this.rbtFuncionario.TabIndex = 1;
            this.rbtFuncionario.TabStop = true;
            this.rbtFuncionario.Text = "Funcionário";
            this.rbtFuncionario.UseVisualStyleBackColor = true;
            this.rbtFuncionario.CheckedChanged += new System.EventHandler(this.rbtFuncionario_CheckedChanged);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(75, 122);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(113, 22);
            this.txtCPF.TabIndex = 1026;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(5, 127);
            this.lblCPF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(34, 17);
            this.lblCPF.TabIndex = 1027;
            this.lblCPF.Text = "CPF";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(76, 94);
            this.txtCnpj.Margin = new System.Windows.Forms.Padding(4);
            this.txtCnpj.Mask = "00.000.000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(147, 22);
            this.txtCnpj.TabIndex = 1024;
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(5, 98);
            this.lblCnpj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(43, 17);
            this.lblCnpj.TabIndex = 1025;
            this.lblCnpj.Text = "CNPJ";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(76, 65);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(325, 22);
            this.txtNome.TabIndex = 1023;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(5, 70);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(45, 17);
            this.lblNome.TabIndex = 1022;
            this.lblNome.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 1021;
            this.label1.Text = "Filial";
            // 
            // cmbFilial
            // 
            this.cmbFilial.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilial.FormattingEnabled = true;
            this.cmbFilial.Location = new System.Drawing.Point(76, 34);
            this.cmbFilial.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilial.Name = "cmbFilial";
            this.cmbFilial.Size = new System.Drawing.Size(325, 24);
            this.cmbFilial.TabIndex = 1020;
            // 
            // RelatorioPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 354);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "RelatorioPessoa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pessoas";
            this.gpbFiltro.ResumeLayout(false);
            this.gpbFiltro.PerformLayout();
            this.gpbTipoPessoa.ResumeLayout(false);
            this.gpbTipoPessoa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilial;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.GroupBox gpbTipoPessoa;
        private System.Windows.Forms.RadioButton rbtFornecedor;
        private System.Windows.Forms.RadioButton rbtFuncionario;
        private System.Windows.Forms.RadioButton rbtCliente;
    }
}