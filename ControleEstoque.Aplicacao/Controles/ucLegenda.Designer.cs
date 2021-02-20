namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    partial class ucLegenda
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
            this.txtCorLegenda = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCorLegenda
            // 
            this.txtCorLegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorLegenda.Location = new System.Drawing.Point(3, 3);
            this.txtCorLegenda.Name = "txtCorLegenda";
            this.txtCorLegenda.ReadOnly = true;
            this.txtCorLegenda.Size = new System.Drawing.Size(15, 15);
            this.txtCorLegenda.TabIndex = 0;
            this.txtCorLegenda.TabStop = false;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(24, 5);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(41, 15);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "label1";
            // 
            // ucLegenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtCorLegenda);
            this.MinimumSize = new System.Drawing.Size(100, 21);
            this.Name = "ucLegenda";
            this.Size = new System.Drawing.Size(100, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCorLegenda;
        private System.Windows.Forms.Label lblDescricao;
    }
}
