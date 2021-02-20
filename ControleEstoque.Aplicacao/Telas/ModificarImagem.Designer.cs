namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class ModificarImagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarImagem));
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.lnkAlterarFoto = new System.Windows.Forms.LinkLabel();
            this.imgProduto = new System.Windows.Forms.PictureBox();
            this.fdgImgImagemCentral = new System.Windows.Forms.OpenFileDialog();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFoto
            // 
            this.pnlFoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFoto.Controls.Add(this.lnkAlterarFoto);
            this.pnlFoto.Location = new System.Drawing.Point(102, 264);
            this.pnlFoto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(243, 32);
            this.pnlFoto.TabIndex = 1010;
            // 
            // lnkAlterarFoto
            // 
            this.lnkAlterarFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lnkAlterarFoto.AutoSize = true;
            this.lnkAlterarFoto.Location = new System.Drawing.Point(76, 5);
            this.lnkAlterarFoto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAlterarFoto.Name = "lnkAlterarFoto";
            this.lnkAlterarFoto.Size = new System.Drawing.Size(82, 17);
            this.lnkAlterarFoto.TabIndex = 12;
            this.lnkAlterarFoto.TabStop = true;
            this.lnkAlterarFoto.Text = "Alterar Foto";
            this.lnkAlterarFoto.Click += new System.EventHandler(this.lnkAlterarFoto_Click);
            // 
            // imgProduto
            // 
            this.imgProduto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.imgProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgProduto.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.product_documentation_g;
            this.imgProduto.Location = new System.Drawing.Point(102, 29);
            this.imgProduto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.imgProduto.Name = "imgProduto";
            this.imgProduto.Size = new System.Drawing.Size(243, 235);
            this.imgProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgProduto.TabIndex = 1011;
            this.imgProduto.TabStop = false;
            // 
            // fdgImgImagemCentral
            // 
            this.fdgImgImagemCentral.DefaultExt = "jpg";
            this.fdgImgImagemCentral.Filter = "JPG files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlFoto, 0, 1);
            this.tlpPrincipal.Controls.Add(this.imgProduto, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPrincipal.Size = new System.Drawing.Size(447, 304);
            this.tlpPrincipal.TabIndex = 13;
            // 
            // ModificarImagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(453, 440);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarImagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Imagem";
            this.pnlFoto.ResumeLayout(false);
            this.pnlFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.LinkLabel lnkAlterarFoto;
        private System.Windows.Forms.PictureBox imgProduto;
        private System.Windows.Forms.OpenFileDialog fdgImgImagemCentral;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
    }
}