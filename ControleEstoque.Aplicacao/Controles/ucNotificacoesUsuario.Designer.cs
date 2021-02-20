namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    partial class ucNotificacoesUsuario
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
            this.gpbLegenda.AutoSize = true;
            this.gpbLegenda.Controls.Add(this.flpLegenda);
            this.gpbLegenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbLegenda.Location = new System.Drawing.Point(0, 0);
            this.gpbLegenda.Name = "gpbLegenda";
            this.gpbLegenda.Size = new System.Drawing.Size(1145, 325);
            this.gpbLegenda.TabIndex = 2;
            this.gpbLegenda.TabStop = false;
            this.gpbLegenda.Text = "Notificacoes";
            // 
            // flpLegenda
            // 
            this.flpLegenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLegenda.Location = new System.Drawing.Point(3, 18);
            this.flpLegenda.Name = "flpLegenda";
            this.flpLegenda.Size = new System.Drawing.Size(1139, 304);
            this.flpLegenda.TabIndex = 0;
            // 
            // ucNotificacoesUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbLegenda);
            this.Name = "ucNotificacoesUsuario";
            this.Size = new System.Drawing.Size(1145, 325);
            this.Load += new System.EventHandler(this.ucNotificacoesUsuario_Load);
            this.gpbLegenda.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbLegenda;
        private System.Windows.Forms.FlowLayoutPanel flpLegenda;
    }
}
