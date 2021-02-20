namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarResposta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarResposta));
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.lblPergunta = new System.Windows.Forms.Label();
            this.pnlControle = new System.Windows.Forms.Panel();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.lblPergunta, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlControle, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(605, 230);
            this.tlpPrincipal.TabIndex = 2;
            // 
            // lblPergunta
            // 
            this.lblPergunta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPergunta.AutoSize = true;
            this.lblPergunta.Location = new System.Drawing.Point(4, 22);
            this.lblPergunta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPergunta.Name = "lblPergunta";
            this.lblPergunta.Size = new System.Drawing.Size(46, 17);
            this.lblPergunta.TabIndex = 0;
            this.lblPergunta.Text = "label1";
            // 
            // pnlControle
            // 
            this.pnlControle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControle.Location = new System.Drawing.Point(4, 66);
            this.pnlControle.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControle.Name = "pnlControle";
            this.pnlControle.Size = new System.Drawing.Size(597, 160);
            this.pnlControle.TabIndex = 1;
            // 
            // GuardarResposta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(624, 279);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarResposta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informatiz";
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(tlpPrincipal);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Label lblPergunta;
        private System.Windows.Forms.Panel pnlControle;
    }
}