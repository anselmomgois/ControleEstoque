namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarSetorEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarSetorEmpresa));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImpressora = new System.Windows.Forms.TextBox();
            this.tlpGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(145, 6);
            this.txtNome.Margin = new System.Windows.Forms.Padding(5);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(372, 22);
            this.txtNome.TabIndex = 11;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(5, 9);
            this.lblNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(113, 17);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Descrição Setor:";
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 2;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Controls.Add(this.lblNome, 0, 0);
            this.tlpGeral.Controls.Add(this.txtNome, 1, 0);
            this.tlpGeral.Controls.Add(this.label1, 0, 1);
            this.tlpGeral.Controls.Add(this.txtImpressora, 1, 1);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Margin = new System.Windows.Forms.Padding(4);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 3;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeral.Size = new System.Drawing.Size(522, 166);
            this.tlpGeral.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Local Impressora:";
            // 
            // txtImpressora
            // 
            this.txtImpressora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImpressora.Location = new System.Drawing.Point(143, 41);
            this.txtImpressora.Name = "txtImpressora";
            this.txtImpressora.Size = new System.Drawing.Size(376, 22);
            this.txtImpressora.TabIndex = 13;
            // 
            // GuardarSetorEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(528, 302);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarSetorEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setor Empresa";
            this.tlpGeral.ResumeLayout(false);
            this.tlpGeral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImpressora;
    }
}