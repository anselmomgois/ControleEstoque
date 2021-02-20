namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarTipoEmpregado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarTipoEmpregado));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.chkSupervisor = new System.Windows.Forms.CheckBox();
            this.chkrespfinanceiro = new System.Windows.Forms.CheckBox();
            this.chkEntregador = new System.Windows.Forms.CheckBox();
            this.chkGerente = new System.Windows.Forms.CheckBox();
            this.chkEnviarEmailFechamento = new System.Windows.Forms.CheckBox();
            this.tlpGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(245, 5);
            this.txtNome.Margin = new System.Windows.Forms.Padding(5);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(327, 22);
            this.txtNome.TabIndex = 11;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(5, 6);
            this.lblNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(180, 17);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Descrição Tipo Empregado";
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 2;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Controls.Add(this.lblNome, 0, 0);
            this.tlpGeral.Controls.Add(this.txtNome, 1, 0);
            this.tlpGeral.Controls.Add(this.chkSupervisor, 1, 1);
            this.tlpGeral.Controls.Add(this.chkrespfinanceiro, 1, 2);
            this.tlpGeral.Controls.Add(this.chkEntregador, 1, 3);
            this.tlpGeral.Controls.Add(this.chkGerente, 1, 4);
            this.tlpGeral.Controls.Add(this.chkEnviarEmailFechamento, 1, 5);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Margin = new System.Windows.Forms.Padding(4);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 7;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Size = new System.Drawing.Size(577, 189);
            this.tlpGeral.TabIndex = 7;
            // 
            // chkSupervisor
            // 
            this.chkSupervisor.AutoSize = true;
            this.chkSupervisor.Location = new System.Drawing.Point(244, 34);
            this.chkSupervisor.Margin = new System.Windows.Forms.Padding(4);
            this.chkSupervisor.Name = "chkSupervisor";
            this.chkSupervisor.Size = new System.Drawing.Size(98, 21);
            this.chkSupervisor.TabIndex = 12;
            this.chkSupervisor.Text = "Supervisor";
            this.chkSupervisor.UseVisualStyleBackColor = true;
            // 
            // chkrespfinanceiro
            // 
            this.chkrespfinanceiro.AutoSize = true;
            this.chkrespfinanceiro.Location = new System.Drawing.Point(244, 64);
            this.chkrespfinanceiro.Margin = new System.Windows.Forms.Padding(4);
            this.chkrespfinanceiro.Name = "chkrespfinanceiro";
            this.chkrespfinanceiro.Size = new System.Drawing.Size(182, 21);
            this.chkrespfinanceiro.TabIndex = 13;
            this.chkrespfinanceiro.Text = "Responsável Financeiro";
            this.chkrespfinanceiro.UseVisualStyleBackColor = true;
            // 
            // chkEntregador
            // 
            this.chkEntregador.AutoSize = true;
            this.chkEntregador.Location = new System.Drawing.Point(244, 94);
            this.chkEntregador.Margin = new System.Windows.Forms.Padding(4);
            this.chkEntregador.Name = "chkEntregador";
            this.chkEntregador.Size = new System.Drawing.Size(101, 21);
            this.chkEntregador.TabIndex = 14;
            this.chkEntregador.Text = "Entregador";
            this.chkEntregador.UseVisualStyleBackColor = true;
            // 
            // chkGerente
            // 
            this.chkGerente.AutoSize = true;
            this.chkGerente.Location = new System.Drawing.Point(244, 124);
            this.chkGerente.Margin = new System.Windows.Forms.Padding(4);
            this.chkGerente.Name = "chkGerente";
            this.chkGerente.Size = new System.Drawing.Size(82, 21);
            this.chkGerente.TabIndex = 15;
            this.chkGerente.Text = "Gerente";
            this.chkGerente.UseVisualStyleBackColor = true;
            // 
            // chkEnviarEmailFechamento
            // 
            this.chkEnviarEmailFechamento.AutoSize = true;
            this.chkEnviarEmailFechamento.Location = new System.Drawing.Point(244, 154);
            this.chkEnviarEmailFechamento.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnviarEmailFechamento.Name = "chkEnviarEmailFechamento";
            this.chkEnviarEmailFechamento.Size = new System.Drawing.Size(228, 21);
            this.chkEnviarEmailFechamento.TabIndex = 16;
            this.chkEnviarEmailFechamento.Text = "Enviar Email Fechamento Caixa";
            this.chkEnviarEmailFechamento.UseVisualStyleBackColor = true;
            // 
            // GuardarTipoEmpregado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(583, 325);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarTipoEmpregado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipo Empregado";
            this.tlpGeral.ResumeLayout(false);
            this.tlpGeral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.CheckBox chkSupervisor;
        private System.Windows.Forms.CheckBox chkrespfinanceiro;
        private System.Windows.Forms.CheckBox chkEntregador;
        private System.Windows.Forms.CheckBox chkGerente;
        private System.Windows.Forms.CheckBox chkEnviarEmailFechamento;
    }
}