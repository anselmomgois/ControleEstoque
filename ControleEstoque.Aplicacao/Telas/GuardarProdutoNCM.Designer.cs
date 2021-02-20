namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoNCM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarProdutoNCM));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtCodigoNCM = new System.Windows.Forms.TextBox();
            this.lblNCM = new System.Windows.Forms.Label();
            this.txtPercentualMVA = new System.Windows.Forms.TextBox();
            this.lblPercentualMVA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(147, 40);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 22);
            this.txtNome.TabIndex = 14;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(10, 45);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 13;
            this.lblNome.Text = "Descrição";
            // 
            // txtCodigoNCM
            // 
            this.txtCodigoNCM.Location = new System.Drawing.Point(147, 10);
            this.txtCodigoNCM.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoNCM.MaxLength = 50;
            this.txtCodigoNCM.Name = "txtCodigoNCM";
            this.txtCodigoNCM.Size = new System.Drawing.Size(117, 22);
            this.txtCodigoNCM.TabIndex = 16;
            this.txtCodigoNCM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoNCM_KeyPress);
            // 
            // lblNCM
            // 
            this.lblNCM.AutoSize = true;
            this.lblNCM.Location = new System.Drawing.Point(10, 15);
            this.lblNCM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNCM.Name = "lblNCM";
            this.lblNCM.Size = new System.Drawing.Size(86, 17);
            this.lblNCM.TabIndex = 15;
            this.lblNCM.Text = "Código NCM";
            // 
            // txtPercentualMVA
            // 
            this.txtPercentualMVA.Location = new System.Drawing.Point(147, 72);
            this.txtPercentualMVA.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentualMVA.MaxLength = 50;
            this.txtPercentualMVA.Name = "txtPercentualMVA";
            this.txtPercentualMVA.Size = new System.Drawing.Size(117, 22);
            this.txtPercentualMVA.TabIndex = 18;
            this.txtPercentualMVA.Enter += new System.EventHandler(this.txtPercentualMVA_Enter);
            // 
            // lblPercentualMVA
            // 
            this.lblPercentualMVA.AutoSize = true;
            this.lblPercentualMVA.Location = new System.Drawing.Point(10, 75);
            this.lblPercentualMVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualMVA.Name = "lblPercentualMVA";
            this.lblPercentualMVA.Size = new System.Drawing.Size(129, 17);
            this.lblPercentualMVA.TabIndex = 17;
            this.lblPercentualMVA.Text = "Percentual de MVA";
            // 
            // GuardarProdutoNCM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(437, 255);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarProdutoNCM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NCM";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtCodigoNCM;
        private System.Windows.Forms.Label lblNCM;
        private System.Windows.Forms.TextBox txtPercentualMVA;
        private System.Windows.Forms.Label lblPercentualMVA;
    }
}