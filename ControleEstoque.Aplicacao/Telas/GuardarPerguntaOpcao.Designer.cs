namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarPerguntaOpcao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarPerguntaOpcao));
            this.txtPergunta = new System.Windows.Forms.TextBox();
            this.lblPergunta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPergunta
            // 
            this.txtPergunta.Location = new System.Drawing.Point(158, 4);
            this.txtPergunta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPergunta.MaxLength = 100;
            this.txtPergunta.Name = "txtPergunta";
            this.txtPergunta.Size = new System.Drawing.Size(441, 22);
            this.txtPergunta.TabIndex = 8;
            // 
            // lblPergunta
            // 
            this.lblPergunta.AutoSize = true;
            this.lblPergunta.Location = new System.Drawing.Point(13, 9);
            this.lblPergunta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPergunta.Name = "lblPergunta";
            this.lblPergunta.Size = new System.Drawing.Size(137, 17);
            this.lblPergunta.TabIndex = 7;
            this.lblPergunta.Text = "Descrição da Opção";
            // 
            // GuardarPerguntaOpcao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(615, 171);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarPerguntaOpcao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opção da Pergunta";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtPergunta;
        private System.Windows.Forms.Label lblPergunta;
    }
}