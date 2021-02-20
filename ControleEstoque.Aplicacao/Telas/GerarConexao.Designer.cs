namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GerarConexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarConexao));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLogar = new System.Windows.Forms.Button();
            this.lblNovaSenha = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNovaSenha = new System.Windows.Forms.MaskedTextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.chkAutenticacao = new System.Windows.Forms.CheckBox();
            this.lblAutenticacao = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.lblPorta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.img_small;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 84);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.ForeColor = System.Drawing.Color.Navy;
            this.btnCancelar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(311, 306);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(152, 28);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnLogar
            // 
            this.btnLogar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogar.ForeColor = System.Drawing.Color.Navy;
            this.btnLogar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.aceitar;
            this.btnLogar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogar.Location = new System.Drawing.Point(152, 306);
            this.btnLogar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(151, 28);
            this.btnLogar.TabIndex = 7;
            this.btnLogar.Text = "&Aceitar";
            this.btnLogar.UseVisualStyleBackColor = true;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // lblNovaSenha
            // 
            this.lblNovaSenha.AutoSize = true;
            this.lblNovaSenha.Location = new System.Drawing.Point(11, 101);
            this.lblNovaSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNovaSenha.Name = "lblNovaSenha";
            this.lblNovaSenha.Size = new System.Drawing.Size(102, 17);
            this.lblNovaSenha.TabIndex = 1000;
            this.lblNovaSenha.Text = "Nome Servidor";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(11, 162);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(154, 17);
            this.lblBanco.TabIndex = 1002;
            this.lblBanco.Text = "Nome Banco de Dados";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(193, 91);
            this.txtServidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(268, 22);
            this.txtServidor.TabIndex = 1;
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(193, 154);
            this.txtBanco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(268, 22);
            this.txtBanco.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(11, 188);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(57, 17);
            this.lblUsuario.TabIndex = 1003;
            this.lblUsuario.Text = "Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(193, 186);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(268, 22);
            this.txtUsuario.TabIndex = 4;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Location = new System.Drawing.Point(193, 218);
            this.txtNovaSenha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.Size = new System.Drawing.Size(268, 22);
            this.txtNovaSenha.TabIndex = 5;
            this.txtNovaSenha.UseSystemPasswordChar = true;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(11, 222);
            this.lblSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(49, 17);
            this.lblSenha.TabIndex = 1004;
            this.lblSenha.Text = "Senha";
            // 
            // chkAutenticacao
            // 
            this.chkAutenticacao.AutoSize = true;
            this.chkAutenticacao.Location = new System.Drawing.Point(193, 251);
            this.chkAutenticacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAutenticacao.Name = "chkAutenticacao";
            this.chkAutenticacao.Size = new System.Drawing.Size(18, 17);
            this.chkAutenticacao.TabIndex = 6;
            this.chkAutenticacao.UseVisualStyleBackColor = true;
            this.chkAutenticacao.CheckedChanged += new System.EventHandler(this.chkAutenticacao_CheckedChanged);
            // 
            // lblAutenticacao
            // 
            this.lblAutenticacao.AutoSize = true;
            this.lblAutenticacao.Location = new System.Drawing.Point(11, 252);
            this.lblAutenticacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutenticacao.Name = "lblAutenticacao";
            this.lblAutenticacao.Size = new System.Drawing.Size(154, 17);
            this.lblAutenticacao.TabIndex = 1005;
            this.lblAutenticacao.Text = "Autenticação Integrada";
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(193, 122);
            this.txtPorta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(63, 22);
            this.txtPorta.TabIndex = 2;
            this.txtPorta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorta_KeyPress);
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(11, 130);
            this.lblPorta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(42, 17);
            this.lblPorta.TabIndex = 1001;
            this.lblPorta.Text = "Porta";
            // 
            // GerarConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(611, 346);
            this.Controls.Add(this.lblPorta);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.lblAutenticacao);
            this.Controls.Add(this.chkAutenticacao);
            this.Controls.Add(this.txtNovaSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.lblNovaSenha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLogar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "GerarConexao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Conexao";
            this.Load += new System.EventHandler(this.GerarConexao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLogar;
        private System.Windows.Forms.Label lblNovaSenha;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.MaskedTextBox txtNovaSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.CheckBox chkAutenticacao;
        private System.Windows.Forms.Label lblAutenticacao;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label lblPorta;
    }
}