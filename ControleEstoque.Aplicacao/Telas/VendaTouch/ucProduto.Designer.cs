namespace Informatiz.ControleEstoque.Aplicacao.Telas.VendaTouch
{
    partial class ucProduto
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
            this.tlpProduto = new System.Windows.Forms.TableLayoutPanel();
            this.imgProduto = new System.Windows.Forms.PictureBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.tlpProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpProduto
            // 
            this.tlpProduto.ColumnCount = 1;
            this.tlpProduto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProduto.Controls.Add(this.imgProduto, 0, 0);
            this.tlpProduto.Controls.Add(this.lblProduto, 0, 1);
            this.tlpProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProduto.Location = new System.Drawing.Point(0, 0);
            this.tlpProduto.Name = "tlpProduto";
            this.tlpProduto.RowCount = 2;
            this.tlpProduto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.17647F));
            this.tlpProduto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.82353F));
            this.tlpProduto.Size = new System.Drawing.Size(130, 103);
            this.tlpProduto.TabIndex = 3;
            // 
            // imgProduto
            // 
            this.imgProduto.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.imgProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgProduto.Location = new System.Drawing.Point(3, 3);
            this.imgProduto.Name = "imgProduto";
            this.imgProduto.Size = new System.Drawing.Size(124, 77);
            this.imgProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgProduto.TabIndex = 0;
            this.imgProduto.TabStop = false;
            this.imgProduto.Click += new System.EventHandler(this.imgProduto_Click);
            this.imgProduto.MouseLeave += new System.EventHandler(this.imgProduto_MouseLeave);
            this.imgProduto.MouseHover += new System.EventHandler(this.imgProduto_MouseHover);
            // 
            // lblProduto
            // 
            this.lblProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Arial Black", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(43, 85);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(43, 15);
            this.lblProduto.TabIndex = 1;
            this.lblProduto.Text = "label1";
            // 
            // ucProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpProduto);
            this.Name = "ucProduto";
            this.Size = new System.Drawing.Size(130, 103);
            this.tlpProduto.ResumeLayout(false);
            this.tlpProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).EndInit();
            this.ResumeLayout(false);
           
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpProduto;
        private System.Windows.Forms.PictureBox imgProduto;
        private System.Windows.Forms.Label lblProduto;
    }
}
