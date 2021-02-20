namespace Informatiz.ControleEstoque.Supervisor.Telas.TelaBase
{
    partial class Base
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
            this.imgTitulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitulo)).BeginInit();
            this.SuspendLayout();
            // 
            // imgTitulo
            // 
            this.imgTitulo.BackColor = System.Drawing.Color.White;
            this.imgTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.imgTitulo.Image = global::Informatiz.ControleEstoque.Supervisor.Properties.Resources.imagem_titulo;
            this.imgTitulo.Location = new System.Drawing.Point(0, 0);
            this.imgTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.imgTitulo.Name = "imgTitulo";
            this.imgTitulo.Size = new System.Drawing.Size(944, 80);
            this.imgTitulo.TabIndex = 3;
            this.imgTitulo.TabStop = false;
            // 
            // Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(944, 519);
            this.Controls.Add(this.imgTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Base";
            this.Text = "Base";
            ((System.ComponentModel.ISupportInitialize)(this.imgTitulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgTitulo;
    }
}