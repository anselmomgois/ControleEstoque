namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GerarBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerarBackup));
            this.lblLocal = new System.Windows.Forms.Label();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.btnDiretorio = new System.Windows.Forms.Button();
            this.sfdBackup = new System.Windows.Forms.SaveFileDialog();
            this.ofdRestaurar = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(4, 29);
            this.lblLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(75, 17);
            this.lblLocal.TabIndex = 2;
            this.lblLocal.Text = "Salvar em:";
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.Enabled = false;
            this.txtDiretorio.Location = new System.Drawing.Point(87, 24);
            this.txtDiretorio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(343, 22);
            this.txtDiretorio.TabIndex = 3;
            // 
            // btnDiretorio
            // 
            this.btnDiretorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDiretorio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDiretorio.ForeColor = System.Drawing.Color.Navy;
            this.btnDiretorio.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.dir;
            this.btnDiretorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiretorio.Location = new System.Drawing.Point(438, 18);
            this.btnDiretorio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDiretorio.Name = "btnDiretorio";
            this.btnDiretorio.Size = new System.Drawing.Size(47, 28);
            this.btnDiretorio.TabIndex = 4;
            this.btnDiretorio.UseVisualStyleBackColor = true;
            this.btnDiretorio.Click += new System.EventHandler(this.btnDiretorio_Click);
            // 
            // GerarBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(517, 242);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "GerarBackup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gerar Backup Sistema";

            this.pnlBase.Controls.Add(lblLocal);
            this.pnlBase.Controls.Add(txtDiretorio);
            this.pnlBase.Controls.Add(btnDiretorio);

            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.TextBox txtDiretorio;
        private System.Windows.Forms.Button btnDiretorio;
        private System.Windows.Forms.SaveFileDialog sfdBackup;
        private System.Windows.Forms.OpenFileDialog ofdRestaurar;
    }
}