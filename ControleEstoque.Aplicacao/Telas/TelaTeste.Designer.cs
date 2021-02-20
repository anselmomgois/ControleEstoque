namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class TelaTeste
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
            this.pnlTexto1 = new System.Windows.Forms.Panel();
            this.pnlTexto2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlTexto1
            // 
            this.pnlTexto1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTexto1.Location = new System.Drawing.Point(12, 12);
            this.pnlTexto1.Name = "pnlTexto1";
            this.pnlTexto1.Size = new System.Drawing.Size(784, 269);
            this.pnlTexto1.TabIndex = 0;
            // 
            // pnlTexto2
            // 
            this.pnlTexto2.Location = new System.Drawing.Point(12, 300);
            this.pnlTexto2.Name = "pnlTexto2";
            this.pnlTexto2.Size = new System.Drawing.Size(784, 100);
            this.pnlTexto2.TabIndex = 1;
            // 
            // TelaTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlTexto2);
            this.Controls.Add(this.pnlTexto1);
            this.Name = "TelaTeste";
            this.Text = "TelaTeste";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTexto1;
        private System.Windows.Forms.Panel pnlTexto2;
    }
}