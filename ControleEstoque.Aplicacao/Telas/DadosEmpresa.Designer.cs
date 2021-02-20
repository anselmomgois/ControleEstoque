namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class DadosEmpresa
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
            Informatiz.ControleEstoque.Aplicacao.Classes.AgenteServico agenteServico1 = new Informatiz.ControleEstoque.Aplicacao.Classes.AgenteServico();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DadosEmpresa));
            this.gpbInformacoes = new System.Windows.Forms.GroupBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.lblSalario = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.ucEnderecoEmpresa = new Informatiz.ControleEstoque.Aplicacao.Controles.ucEndereco();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.gpbInformacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbInformacoes
            // 
            this.gpbInformacoes.Controls.Add(this.txtReferencia);
            this.gpbInformacoes.Controls.Add(this.lblReferencia);
            this.gpbInformacoes.Controls.Add(this.txtSalario);
            this.gpbInformacoes.Controls.Add(this.lblSalario);
            this.gpbInformacoes.Controls.Add(this.txtCargo);
            this.gpbInformacoes.Controls.Add(this.lblCargo);
            this.gpbInformacoes.Controls.Add(this.ucEnderecoEmpresa);
            this.gpbInformacoes.Controls.Add(this.txtTelefone);
            this.gpbInformacoes.Controls.Add(this.lblTelefone);
            this.gpbInformacoes.Controls.Add(this.txtEmpresa);
            this.gpbInformacoes.Controls.Add(this.lblEmpresa);
            this.gpbInformacoes.Location = new System.Drawing.Point(17, 183);
            this.gpbInformacoes.Margin = new System.Windows.Forms.Padding(4);
            this.gpbInformacoes.Name = "gpbInformacoes";
            this.gpbInformacoes.Padding = new System.Windows.Forms.Padding(4);
            this.gpbInformacoes.Size = new System.Drawing.Size(1224, 490);
            this.gpbInformacoes.TabIndex = 0;
            this.gpbInformacoes.TabStop = false;
            this.gpbInformacoes.Text = "Informações Profissionais";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(184, 395);
            this.txtReferencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtReferencia.MaxLength = 50;
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(864, 75);
            this.txtReferencia.TabIndex = 6;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(25, 395);
            this.lblReferencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(143, 17);
            this.lblReferencia.TabIndex = 40;
            this.lblReferencia.Text = "Referência Comercial";
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(616, 351);
            this.txtSalario.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalario.MaxLength = 20;
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(129, 22);
            this.txtSalario.TabIndex = 5;
            this.txtSalario.Enter += new System.EventHandler(this.txtSalario_Enter);
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.Location = new System.Drawing.Point(556, 359);
            this.lblSalario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(52, 17);
            this.lblSalario.TabIndex = 39;
            this.lblSalario.Text = "Salário";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(184, 356);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCargo.MaxLength = 50;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(351, 22);
            this.txtCargo.TabIndex = 4;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(25, 359);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(46, 17);
            this.lblCargo.TabIndex = 33;
            this.lblCargo.Text = "Cargo";
            // 
            // ucEnderecoEmpresa
            // 
            this.ucEnderecoEmpresa.Agente = agenteServico1;
            this.ucEnderecoEmpresa.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ucEnderecoEmpresa.Location = new System.Drawing.Point(12, 80);
            this.ucEnderecoEmpresa.Margin = new System.Windows.Forms.Padding(5);
            this.ucEnderecoEmpresa.Name = "ucEnderecoEmpresa";
            this.ucEnderecoEmpresa.ServicosEmProcesamento = null;
            this.ucEnderecoEmpresa.Size = new System.Drawing.Size(1200, 263);
            this.ucEnderecoEmpresa.TabIndex = 3;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(708, 34);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefone.Mask = "(00) 0000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(113, 22);
            this.txtTelefone.TabIndex = 2;
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(635, 43);
            this.lblTelefone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(64, 17);
            this.lblTelefone.TabIndex = 31;
            this.lblTelefone.Text = "Telefone";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(243, 34);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpresa.MaxLength = 50;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(351, 22);
            this.txtEmpresa.TabIndex = 1;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new System.Drawing.Point(8, 43);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(228, 17);
            this.lblEmpresa.TabIndex = 16;
            this.lblEmpresa.Text = "Empresa que Trabalha Atualmente";
            // 
            // DadosEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 686);
            this.Controls.Add(this.gpbInformacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DadosEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informações Profissionais";
            this.Controls.SetChildIndex(this.gpbInformacoes, 0);
            this.gpbInformacoes.ResumeLayout(false);
            this.gpbInformacoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbInformacoes;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblCargo;
        private Controles.ucEndereco ucEnderecoEmpresa;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label lblSalario;
    }
}