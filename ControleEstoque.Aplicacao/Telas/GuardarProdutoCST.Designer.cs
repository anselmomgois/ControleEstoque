namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoCST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarProdutoCST));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtCodigoCST = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblTemCST = new System.Windows.Forms.Label();
            this.chkTemCST = new System.Windows.Forms.CheckBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(108, 34);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 22);
            this.txtNome.TabIndex = 20;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(22, 39);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 19;
            this.lblNome.Text = "Descrição";
            // 
            // txtCodigoCST
            // 
            this.txtCodigoCST.Location = new System.Drawing.Point(108, 4);
            this.txtCodigoCST.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoCST.MaxLength = 50;
            this.txtCodigoCST.Name = "txtCodigoCST";
            this.txtCodigoCST.Size = new System.Drawing.Size(105, 22);
            this.txtCodigoCST.TabIndex = 22;
            this.txtCodigoCST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentual_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(22, 9);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(74, 17);
            this.lblCodigo.TabIndex = 21;
            this.lblCodigo.Text = "Código ST";
            // 
            // lblTemCST
            // 
            this.lblTemCST.AutoSize = true;
            this.lblTemCST.Location = new System.Drawing.Point(22, 64);
            this.lblTemCST.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemCST.Name = "lblTemCST";
            this.lblTemCST.Size = new System.Drawing.Size(75, 17);
            this.lblTemCST.TabIndex = 26;
            this.lblTemCST.Text = "Tem CST?";
            // 
            // chkTemCST
            // 
            this.chkTemCST.AutoSize = true;
            this.chkTemCST.Location = new System.Drawing.Point(108, 64);
            this.chkTemCST.Margin = new System.Windows.Forms.Padding(4);
            this.chkTemCST.Name = "chkTemCST";
            this.chkTemCST.Size = new System.Drawing.Size(18, 17);
            this.chkTemCST.TabIndex = 25;
            this.chkTemCST.UseVisualStyleBackColor = true;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(108, 89);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacao.MaxLength = 4000;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(484, 120);
            this.txtObservacao.TabIndex = 27;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(8, 192);
            this.lblObservacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(85, 17);
            this.lblObservacao.TabIndex = 28;
            this.lblObservacao.Text = "Observação";
            // 
            // GuardarProdutoCST
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(609, 357);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarProdutoCST";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Situação Tributária";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtCodigoCST;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblTemCST;
        private System.Windows.Forms.CheckBox chkTemCST;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacao;
    }
}