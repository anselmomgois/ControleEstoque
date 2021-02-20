namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class ExibirFoto
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
            this.imgProduto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // imgProduto
            // 
            this.imgProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgProduto.Location = new System.Drawing.Point(0, 0);
            this.imgProduto.Name = "imgProduto";
            this.imgProduto.Size = new System.Drawing.Size(377, 462);
            this.imgProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgProduto.TabIndex = 0;
            this.imgProduto.TabStop = false;
            this.imgProduto.Click += new System.EventHandler(this.imgProduto_Click);
            this.imgProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgProduto_MouseMove);
            // 
            // ExibirFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 462);
            this.Controls.Add(this.imgProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExibirFoto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExibirFoto";
            this.Load += new System.EventHandler(this.ExibirFoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgProduto;
    }
}