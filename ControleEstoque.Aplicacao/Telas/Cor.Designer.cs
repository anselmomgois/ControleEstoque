namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class Cor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.frmColor = new System.Windows.Forms.ColorDialog();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCor = new System.Windows.Forms.Label();
            this.btnCidade = new System.Windows.Forms.Button();
            this.pnlCor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.img_small;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 84);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(16, 206);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(91, 17);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome da Cor";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(115, 204);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 22);
            this.txtNome.TabIndex = 3;
            // 
            // lblCor
            // 
            this.lblCor.AutoSize = true;
            this.lblCor.Location = new System.Drawing.Point(17, 244);
            this.lblCor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCor.Name = "lblCor";
            this.lblCor.Size = new System.Drawing.Size(30, 17);
            this.lblCor.TabIndex = 4;
            this.lblCor.Text = "Cor";
            // 
            // btnCidade
            // 
            this.btnCidade.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.search_16;
            this.btnCidade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCidade.Location = new System.Drawing.Point(191, 233);
            this.btnCidade.Margin = new System.Windows.Forms.Padding(4);
            this.btnCidade.Name = "btnCidade";
            this.btnCidade.Size = new System.Drawing.Size(35, 30);
            this.btnCidade.TabIndex = 6;
            this.btnCidade.UseVisualStyleBackColor = true;
            this.btnCidade.Click += new System.EventHandler(this.btnCidade_Click);
            // 
            // pnlCor
            // 
            this.pnlCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCor.Location = new System.Drawing.Point(115, 233);
            this.pnlCor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCor.Name = "pnlCor";
            this.pnlCor.Size = new System.Drawing.Size(70, 28);
            this.pnlCor.TabIndex = 9;
            // 
            // Cor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(465, 288);
            this.Controls.Add(this.pnlCor);
            this.Controls.Add(this.btnCidade);
            this.Controls.Add(this.lblCor);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cor";
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lblCor, 0);
            this.Controls.SetChildIndex(this.btnCidade, 0);
            this.Controls.SetChildIndex(this.pnlCor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog frmColor;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCor;
        private System.Windows.Forms.Button btnCidade;
        private System.Windows.Forms.Panel pnlCor;
    }
}