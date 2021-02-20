namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class Documento
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
            this.gpbDatosDocumento = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gpbDatosDocumento
            // 
            this.gpbDatosDocumento.Location = new System.Drawing.Point(0, 87);
            this.gpbDatosDocumento.Name = "gpbDatosDocumento";
            this.gpbDatosDocumento.Size = new System.Drawing.Size(969, 528);
            this.gpbDatosDocumento.TabIndex = 7;
            this.gpbDatosDocumento.TabStop = false;
            this.gpbDatosDocumento.Text = "Dados do Documento";
            // 
            // Documento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 617);
            this.Controls.Add(this.gpbDatosDocumento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Documento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Documento";
            this.Controls.SetChildIndex(this.gpbDatosDocumento, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDatosDocumento;
    }
}