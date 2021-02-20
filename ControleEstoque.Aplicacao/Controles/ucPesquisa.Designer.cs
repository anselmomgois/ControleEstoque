namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    partial class ucPesquisa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPesquisa.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Black;
            this.txtPesquisa.Location = new System.Drawing.Point(0, 0);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(999, 55);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.SizeChanged += new System.EventHandler(this.txtPesquisa_SizeChanged);
            this.txtPesquisa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisa_KeyDown);
            // 
            // ucPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPesquisa);
            this.Name = "ucPesquisa";
            this.Size = new System.Drawing.Size(999, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPesquisa;
    }
}
