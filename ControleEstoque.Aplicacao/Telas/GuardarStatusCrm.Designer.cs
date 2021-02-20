namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarStatusCrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarStatusCrm));
            this.frmColor = new System.Windows.Forms.ColorDialog();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCor = new System.Windows.Forms.Label();
            this.btnCidade = new System.Windows.Forms.Button();
            this.pnlCor = new System.Windows.Forms.Panel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(16, 9);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(139, 4);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(92, 22);
            this.txtCodigo.TabIndex = 3;
            // 
            // lblCor
            // 
            this.lblCor.AutoSize = true;
            this.lblCor.Location = new System.Drawing.Point(16, 65);
            this.lblCor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCor.Name = "lblCor";
            this.lblCor.Size = new System.Drawing.Size(30, 17);
            this.lblCor.TabIndex = 500;
            this.lblCor.Text = "Cor";
            // 
            // btnCidade
            // 
            this.btnCidade.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.search_16;
            this.btnCidade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCidade.Location = new System.Drawing.Point(217, 54);
            this.btnCidade.Margin = new System.Windows.Forms.Padding(4);
            this.btnCidade.Name = "btnCidade";
            this.btnCidade.Size = new System.Drawing.Size(35, 28);
            this.btnCidade.TabIndex = 5;
            this.btnCidade.UseVisualStyleBackColor = true;
            this.btnCidade.Click += new System.EventHandler(this.btnCidade_Click);
            // 
            // pnlCor
            // 
            this.pnlCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCor.Location = new System.Drawing.Point(139, 54);
            this.pnlCor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCor.Name = "pnlCor";
            this.pnlCor.Size = new System.Drawing.Size(70, 28);
            this.pnlCor.TabIndex = 9;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(139, 29);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 22);
            this.txtNome.TabIndex = 4;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(16, 34);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(115, 17);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Descrição Status";
            // 
            // GuardarStatusCrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(497, 229);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarStatusCrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Status CRM";
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(lblNome);
            this.pnlBase.Controls.Add(lblCodigo);
            this.pnlBase.Controls.Add(txtCodigo);
            this.pnlBase.Controls.Add(lblCor);
            this.pnlBase.Controls.Add(pnlCor);
            this.pnlBase.Controls.Add(btnCidade);
        }

        #endregion
        private System.Windows.Forms.ColorDialog frmColor;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCor;
        private System.Windows.Forms.Button btnCidade;
        private System.Windows.Forms.Panel pnlCor;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;

    }
}