namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    partial class ucItensLegenda
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
            this.gpbLegenda = new System.Windows.Forms.GroupBox();
            this.flpLegenda = new System.Windows.Forms.FlowLayoutPanel();
            this.gpbLegenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbLegenda
            // 
            this.gpbLegenda.Controls.Add(this.flpLegenda);
            this.gpbLegenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbLegenda.Location = new System.Drawing.Point(0, 0);
            this.gpbLegenda.Name = "gpbLegenda";
            this.gpbLegenda.Size = new System.Drawing.Size(712, 57);
            this.gpbLegenda.TabIndex = 1;
            this.gpbLegenda.TabStop = false;
            this.gpbLegenda.Text = "Legenda";
            // 
            // flpLegenda
            // 
            this.flpLegenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLegenda.Location = new System.Drawing.Point(3, 18);
            this.flpLegenda.Name = "flpLegenda";
            this.flpLegenda.Size = new System.Drawing.Size(706, 36);
            this.flpLegenda.TabIndex = 0;
            // 
            // ucItensLegenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.gpbLegenda);
            this.Name = "ucItensLegenda";
            this.Size = new System.Drawing.Size(712, 57);
            this.Load += new System.EventHandler(this.ucItensLegenda_Load);
            this.gpbLegenda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbLegenda;
        private System.Windows.Forms.FlowLayoutPanel flpLegenda;
    }
}
