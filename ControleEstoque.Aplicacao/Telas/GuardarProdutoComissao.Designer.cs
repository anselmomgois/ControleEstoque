namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoComissao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarProdutoComissao));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblPercentual = new System.Windows.Forms.Label();
            this.txtPercentual = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.chkHabilitada = new System.Windows.Forms.CheckBox();
            this.lblHabilitada = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(90, 4);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 22);
            this.txtNome.TabIndex = 18;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(11, 9);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 17;
            this.lblNome.Text = "Descrição";
            // 
            // lblPercentual
            // 
            this.lblPercentual.AutoSize = true;
            this.lblPercentual.Location = new System.Drawing.Point(11, 40);
            this.lblPercentual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentual.Name = "lblPercentual";
            this.lblPercentual.Size = new System.Drawing.Size(76, 17);
            this.lblPercentual.TabIndex = 19;
            this.lblPercentual.Text = "Percentual";
            // 
            // txtPercentual
            // 
            this.txtPercentual.Location = new System.Drawing.Point(90, 35);
            this.txtPercentual.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentual.MaxLength = 50;
            this.txtPercentual.Name = "txtPercentual";
            this.txtPercentual.Size = new System.Drawing.Size(105, 22);
            this.txtPercentual.TabIndex = 20;
            this.txtPercentual.Enter += new System.EventHandler(this.txtPercentual_Enter);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(11, 70);
            this.lblValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(41, 17);
            this.lblValor.TabIndex = 21;
            this.lblValor.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(90, 65);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor.MaxLength = 50;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(105, 22);
            this.txtValor.TabIndex = 22;
            this.txtValor.Enter += new System.EventHandler(this.txtValor_Enter);
            // 
            // chkHabilitada
            // 
            this.chkHabilitada.AutoSize = true;
            this.chkHabilitada.Location = new System.Drawing.Point(90, 95);
            this.chkHabilitada.Margin = new System.Windows.Forms.Padding(4);
            this.chkHabilitada.Name = "chkHabilitada";
            this.chkHabilitada.Size = new System.Drawing.Size(18, 17);
            this.chkHabilitada.TabIndex = 23;
            this.chkHabilitada.UseVisualStyleBackColor = true;
            // 
            // lblHabilitada
            // 
            this.lblHabilitada.AutoSize = true;
            this.lblHabilitada.Location = new System.Drawing.Point(11, 95);
            this.lblHabilitada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHabilitada.Name = "lblHabilitada";
            this.lblHabilitada.Size = new System.Drawing.Size(71, 17);
            this.lblHabilitada.TabIndex = 24;
            this.lblHabilitada.Text = "Habilitada";
            // 
            // GuardarProdutoComissao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(409, 255);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarProdutoComissao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comissão";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblPercentual;
        private System.Windows.Forms.TextBox txtPercentual;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.CheckBox chkHabilitada;
        private System.Windows.Forms.Label lblHabilitada;
        
    }
}