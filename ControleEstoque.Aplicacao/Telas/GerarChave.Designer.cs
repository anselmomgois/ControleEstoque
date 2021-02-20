namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GerarChave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarChave));
            this.lblChaveGerada = new System.Windows.Forms.Label();
            this.txtValidadeDias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkValidadeInfinita = new System.Windows.Forms.CheckBox();
            this.chkSessoesInfinitas = new System.Windows.Forms.CheckBox();
            this.txtQuantidadeSessoes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChaveGerada
            // 
            this.lblChaveGerada.AutoSize = true;
            this.lblChaveGerada.Location = new System.Drawing.Point(21, 30);
            this.lblChaveGerada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChaveGerada.Name = "lblChaveGerada";
            this.lblChaveGerada.Size = new System.Drawing.Size(0, 17);
            this.lblChaveGerada.TabIndex = 15;
            // 
            // txtValidadeDias
            // 
            this.txtValidadeDias.Location = new System.Drawing.Point(285, 54);
            this.txtValidadeDias.Margin = new System.Windows.Forms.Padding(4);
            this.txtValidadeDias.Name = "txtValidadeDias";
            this.txtValidadeDias.Size = new System.Drawing.Size(48, 22);
            this.txtValidadeDias.TabIndex = 14;
            this.txtValidadeDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidadeDias_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quantidade de dias que a chave é valida";
            // 
            // chkValidadeInfinita
            // 
            this.chkValidadeInfinita.AutoSize = true;
            this.chkValidadeInfinita.Location = new System.Drawing.Point(12, 123);
            this.chkValidadeInfinita.Margin = new System.Windows.Forms.Padding(4);
            this.chkValidadeInfinita.Name = "chkValidadeInfinita";
            this.chkValidadeInfinita.Size = new System.Drawing.Size(130, 21);
            this.chkValidadeInfinita.TabIndex = 12;
            this.chkValidadeInfinita.Text = "Validade Infinita";
            this.chkValidadeInfinita.UseVisualStyleBackColor = true;
            // 
            // chkSessoesInfinitas
            // 
            this.chkSessoesInfinitas.AutoSize = true;
            this.chkSessoesInfinitas.Location = new System.Drawing.Point(12, 95);
            this.chkSessoesInfinitas.Margin = new System.Windows.Forms.Padding(4);
            this.chkSessoesInfinitas.Name = "chkSessoesInfinitas";
            this.chkSessoesInfinitas.Size = new System.Drawing.Size(136, 21);
            this.chkSessoesInfinitas.TabIndex = 10;
            this.chkSessoesInfinitas.Text = "Sessões Infinitas";
            this.chkSessoesInfinitas.UseVisualStyleBackColor = true;
            // 
            // txtQuantidadeSessoes
            // 
            this.txtQuantidadeSessoes.Location = new System.Drawing.Point(156, 23);
            this.txtQuantidadeSessoes.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantidadeSessoes.Name = "txtQuantidadeSessoes";
            this.txtQuantidadeSessoes.Size = new System.Drawing.Size(48, 22);
            this.txtQuantidadeSessoes.TabIndex = 9;
            this.txtQuantidadeSessoes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidadeSessoes_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Quantidade Sessões";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQuantidadeSessoes);
            this.groupBox1.Controls.Add(this.txtValidadeDias);
            this.groupBox1.Controls.Add(this.chkSessoesInfinitas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkValidadeInfinita);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(587, 155);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Chave";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblChaveGerada);
            this.groupBox2.Location = new System.Drawing.Point(4, 177);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(587, 57);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chave";
            // 
            // GerarChave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(611, 428);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GerarChave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gerar Chave";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblChaveGerada;
        private System.Windows.Forms.TextBox txtValidadeDias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkValidadeInfinita;
        private System.Windows.Forms.CheckBox chkSessoesInfinitas;
        private System.Windows.Forms.TextBox txtQuantidadeSessoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}