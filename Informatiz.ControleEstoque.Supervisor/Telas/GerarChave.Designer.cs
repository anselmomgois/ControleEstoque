namespace Informatiz.ControleEstoque.Supervisor
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantidadeSessoes = new System.Windows.Forms.TextBox();
            this.chkSessoesInfinitas = new System.Windows.Forms.CheckBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.chkValidadeInfinita = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValidadeDias = new System.Windows.Forms.TextBox();
            this.lblChaveGerada = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantidade Sessões";
            // 
            // txtQuantidadeSessoes
            // 
            this.txtQuantidadeSessoes.Location = new System.Drawing.Point(124, 24);
            this.txtQuantidadeSessoes.Name = "txtQuantidadeSessoes";
            this.txtQuantidadeSessoes.Size = new System.Drawing.Size(37, 20);
            this.txtQuantidadeSessoes.TabIndex = 1;
            // 
            // chkSessoesInfinitas
            // 
            this.chkSessoesInfinitas.AutoSize = true;
            this.chkSessoesInfinitas.Location = new System.Drawing.Point(16, 71);
            this.chkSessoesInfinitas.Name = "chkSessoesInfinitas";
            this.chkSessoesInfinitas.Size = new System.Drawing.Size(105, 17);
            this.chkSessoesInfinitas.TabIndex = 2;
            this.chkSessoesInfinitas.Text = "Sessões Infinitas";
            this.chkSessoesInfinitas.UseVisualStyleBackColor = true;
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(12, 130);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 3;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkValidadeInfinita
            // 
            this.chkValidadeInfinita.AutoSize = true;
            this.chkValidadeInfinita.Location = new System.Drawing.Point(16, 94);
            this.chkValidadeInfinita.Name = "chkValidadeInfinita";
            this.chkValidadeInfinita.Size = new System.Drawing.Size(101, 17);
            this.chkValidadeInfinita.TabIndex = 4;
            this.chkValidadeInfinita.Text = "Validade Infinita";
            this.chkValidadeInfinita.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quantidade de dias que a chave é valida";
            // 
            // txtValidadeDias
            // 
            this.txtValidadeDias.Location = new System.Drawing.Point(221, 47);
            this.txtValidadeDias.Name = "txtValidadeDias";
            this.txtValidadeDias.Size = new System.Drawing.Size(37, 20);
            this.txtValidadeDias.TabIndex = 6;
            // 
            // lblChaveGerada
            // 
            this.lblChaveGerada.AutoSize = true;
            this.lblChaveGerada.Location = new System.Drawing.Point(117, 136);
            this.lblChaveGerada.Name = "lblChaveGerada";
            this.lblChaveGerada.Size = new System.Drawing.Size(0, 13);
            this.lblChaveGerada.TabIndex = 7;
            // 
            // GerarChave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 158);
            this.Controls.Add(this.lblChaveGerada);
            this.Controls.Add(this.txtValidadeDias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkValidadeInfinita);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.chkSessoesInfinitas);
            this.Controls.Add(this.txtQuantidadeSessoes);
            this.Controls.Add(this.label1);
            this.Name = "GerarChave";
            this.Text = "GerarChave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantidadeSessoes;
        private System.Windows.Forms.CheckBox chkSessoesInfinitas;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.CheckBox chkValidadeInfinita;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValidadeDias;
        private System.Windows.Forms.Label lblChaveGerada;
    }
}