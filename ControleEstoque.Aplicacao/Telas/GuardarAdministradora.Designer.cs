namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarAdministradora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarAdministradora));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtDescricaoTela = new System.Windows.Forms.TextBox();
            this.lblDescricaoTela = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.txtPercentualTarifa = new System.Windows.Forms.TextBox();
            this.txtValorTarifa = new System.Windows.Forms.TextBox();
            this.txtPercentualTarifaAnt = new System.Windows.Forms.TextBox();
            this.txtValorTarifaAnt = new System.Windows.Forms.TextBox();
            this.txtPercentualDesconto = new System.Windows.Forms.TextBox();
            this.txtValorDesconto = new System.Windows.Forms.TextBox();
            this.lblPercentualTarifa = new System.Windows.Forms.Label();
            this.lblTarifaValor = new System.Windows.Forms.Label();
            this.lblTarifaAnterior = new System.Windows.Forms.Label();
            this.lblValorTarifaAnt = new System.Windows.Forms.Label();
            this.lblDescontoPercentual = new System.Windows.Forms.Label();
            this.lblValorDesconto = new System.Windows.Forms.Label();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.lnkAlterarFoto = new System.Windows.Forms.LinkLabel();
            this.imgProduto = new System.Windows.Forms.PictureBox();
            this.fdgImgImagemAdministradora = new System.Windows.Forms.OpenFileDialog();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(189, 198);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 22);
            this.txtNome.TabIndex = 14;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(13, 207);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 13;
            this.lblNome.Text = "Descrição";
            // 
            // txtDescricaoTela
            // 
            this.txtDescricaoTela.Location = new System.Drawing.Point(189, 230);
            this.txtDescricaoTela.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricaoTela.MaxLength = 50;
            this.txtDescricaoTela.Name = "txtDescricaoTela";
            this.txtDescricaoTela.Size = new System.Drawing.Size(261, 22);
            this.txtDescricaoTela.TabIndex = 16;
            // 
            // lblDescricaoTela
            // 
            this.lblDescricaoTela.AutoSize = true;
            this.lblDescricaoTela.Location = new System.Drawing.Point(13, 239);
            this.lblDescricaoTela.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricaoTela.Name = "lblDescricaoTela";
            this.lblDescricaoTela.Size = new System.Drawing.Size(103, 17);
            this.lblDescricaoTela.TabIndex = 15;
            this.lblDescricaoTela.Text = "Descrição Tela";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(189, 259);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacao.MaxLength = 50;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(375, 98);
            this.txtObservacao.TabIndex = 17;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(13, 342);
            this.lblObservacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(85, 17);
            this.lblObservacao.TabIndex = 18;
            this.lblObservacao.Text = "Observação";
            // 
            // txtPercentualTarifa
            // 
            this.txtPercentualTarifa.Location = new System.Drawing.Point(189, 396);
            this.txtPercentualTarifa.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentualTarifa.MaxLength = 50;
            this.txtPercentualTarifa.Name = "txtPercentualTarifa";
            this.txtPercentualTarifa.Size = new System.Drawing.Size(169, 22);
            this.txtPercentualTarifa.TabIndex = 19;
            this.txtPercentualTarifa.Enter += new System.EventHandler(this.txtPercentualTarifa_Enter);
            // 
            // txtValorTarifa
            // 
            this.txtValorTarifa.Location = new System.Drawing.Point(189, 428);
            this.txtValorTarifa.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorTarifa.MaxLength = 50;
            this.txtValorTarifa.Name = "txtValorTarifa";
            this.txtValorTarifa.Size = new System.Drawing.Size(169, 22);
            this.txtValorTarifa.TabIndex = 20;
            this.txtValorTarifa.Enter += new System.EventHandler(this.txtValorTarifa_Enter);
            // 
            // txtPercentualTarifaAnt
            // 
            this.txtPercentualTarifaAnt.Location = new System.Drawing.Point(189, 460);
            this.txtPercentualTarifaAnt.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentualTarifaAnt.MaxLength = 50;
            this.txtPercentualTarifaAnt.Name = "txtPercentualTarifaAnt";
            this.txtPercentualTarifaAnt.Size = new System.Drawing.Size(169, 22);
            this.txtPercentualTarifaAnt.TabIndex = 21;
            this.txtPercentualTarifaAnt.Enter += new System.EventHandler(this.txtPercentualTarifaAnt_Enter);
            // 
            // txtValorTarifaAnt
            // 
            this.txtValorTarifaAnt.Location = new System.Drawing.Point(189, 492);
            this.txtValorTarifaAnt.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorTarifaAnt.MaxLength = 50;
            this.txtValorTarifaAnt.Name = "txtValorTarifaAnt";
            this.txtValorTarifaAnt.Size = new System.Drawing.Size(169, 22);
            this.txtValorTarifaAnt.TabIndex = 22;
            this.txtValorTarifaAnt.Enter += new System.EventHandler(this.txtValorTarifaAnt_Enter);
            // 
            // txtPercentualDesconto
            // 
            this.txtPercentualDesconto.Location = new System.Drawing.Point(189, 524);
            this.txtPercentualDesconto.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentualDesconto.MaxLength = 50;
            this.txtPercentualDesconto.Name = "txtPercentualDesconto";
            this.txtPercentualDesconto.Size = new System.Drawing.Size(169, 22);
            this.txtPercentualDesconto.TabIndex = 23;
            this.txtPercentualDesconto.Enter += new System.EventHandler(this.txtPercentualDesconto_Enter);
            // 
            // txtValorDesconto
            // 
            this.txtValorDesconto.Location = new System.Drawing.Point(189, 556);
            this.txtValorDesconto.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorDesconto.MaxLength = 50;
            this.txtValorDesconto.Name = "txtValorDesconto";
            this.txtValorDesconto.Size = new System.Drawing.Size(169, 22);
            this.txtValorDesconto.TabIndex = 24;
            this.txtValorDesconto.Enter += new System.EventHandler(this.txtValorDesconto_Enter);
            // 
            // lblPercentualTarifa
            // 
            this.lblPercentualTarifa.AutoSize = true;
            this.lblPercentualTarifa.Location = new System.Drawing.Point(13, 404);
            this.lblPercentualTarifa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualTarifa.Name = "lblPercentualTarifa";
            this.lblPercentualTarifa.Size = new System.Drawing.Size(137, 17);
            this.lblPercentualTarifa.TabIndex = 25;
            this.lblPercentualTarifa.Text = "Percentual de Tarifa";
            // 
            // lblTarifaValor
            // 
            this.lblTarifaValor.AutoSize = true;
            this.lblTarifaValor.Location = new System.Drawing.Point(13, 436);
            this.lblTarifaValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTarifaValor.Name = "lblTarifaValor";
            this.lblTarifaValor.Size = new System.Drawing.Size(102, 17);
            this.lblTarifaValor.TabIndex = 26;
            this.lblTarifaValor.Text = "Valor da Tarifa";
            // 
            // lblTarifaAnterior
            // 
            this.lblTarifaAnterior.AutoSize = true;
            this.lblTarifaAnterior.Location = new System.Drawing.Point(13, 468);
            this.lblTarifaAnterior.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTarifaAnterior.Name = "lblTarifaAnterior";
            this.lblTarifaAnterior.Size = new System.Drawing.Size(171, 17);
            this.lblTarifaAnterior.TabIndex = 27;
            this.lblTarifaAnterior.Text = "Percentual Tarifa Anterior";
            // 
            // lblValorTarifaAnt
            // 
            this.lblValorTarifaAnt.AutoSize = true;
            this.lblValorTarifaAnt.Location = new System.Drawing.Point(13, 504);
            this.lblValorTarifaAnt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTarifaAnt.Name = "lblValorTarifaAnt";
            this.lblValorTarifaAnt.Size = new System.Drawing.Size(136, 17);
            this.lblValorTarifaAnt.TabIndex = 28;
            this.lblValorTarifaAnt.Text = "Valor Tarifa Anterior";
            // 
            // lblDescontoPercentual
            // 
            this.lblDescontoPercentual.AutoSize = true;
            this.lblDescontoPercentual.Location = new System.Drawing.Point(13, 532);
            this.lblDescontoPercentual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescontoPercentual.Name = "lblDescontoPercentual";
            this.lblDescontoPercentual.Size = new System.Drawing.Size(160, 17);
            this.lblDescontoPercentual.TabIndex = 29;
            this.lblDescontoPercentual.Text = "Percentual de Desconto";
            // 
            // lblValorDesconto
            // 
            this.lblValorDesconto.AutoSize = true;
            this.lblValorDesconto.Location = new System.Drawing.Point(13, 564);
            this.lblValorDesconto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorDesconto.Name = "lblValorDesconto";
            this.lblValorDesconto.Size = new System.Drawing.Size(125, 17);
            this.lblValorDesconto.TabIndex = 30;
            this.lblValorDesconto.Text = "Valor do Desconto";
            // 
            // pnlFoto
            // 
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFoto.Controls.Add(this.lnkAlterarFoto);
            this.pnlFoto.Location = new System.Drawing.Point(369, 550);
            this.pnlFoto.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(195, 32);
            this.pnlFoto.TabIndex = 1012;
            // 
            // lnkAlterarFoto
            // 
            this.lnkAlterarFoto.AutoSize = true;
            this.lnkAlterarFoto.Location = new System.Drawing.Point(36, 5);
            this.lnkAlterarFoto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAlterarFoto.Name = "lnkAlterarFoto";
            this.lnkAlterarFoto.Size = new System.Drawing.Size(118, 17);
            this.lnkAlterarFoto.TabIndex = 12;
            this.lnkAlterarFoto.TabStop = true;
            this.lnkAlterarFoto.Text = "Modificar Imagem";
            this.lnkAlterarFoto.Click += new System.EventHandler(this.lnkAlterarFoto_Click);
            // 
            // imgProduto
            // 
            this.imgProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgProduto.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.product_documentation_g;
            this.imgProduto.Location = new System.Drawing.Point(369, 365);
            this.imgProduto.Margin = new System.Windows.Forms.Padding(4);
            this.imgProduto.Name = "imgProduto";
            this.imgProduto.Size = new System.Drawing.Size(195, 184);
            this.imgProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgProduto.TabIndex = 1013;
            this.imgProduto.TabStop = false;
            // 
            // fdgImgImagemAdministradora
            // 
            this.fdgImgImagemAdministradora.DefaultExt = "jpg";
            this.fdgImgImagemAdministradora.Filter = "JPG files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            // 
            // GuardarAdministradora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(576, 596);
            this.Controls.Add(this.pnlFoto);
            this.Controls.Add(this.imgProduto);
            this.Controls.Add(this.lblValorDesconto);
            this.Controls.Add(this.lblDescontoPercentual);
            this.Controls.Add(this.lblValorTarifaAnt);
            this.Controls.Add(this.lblTarifaAnterior);
            this.Controls.Add(this.lblTarifaValor);
            this.Controls.Add(this.lblPercentualTarifa);
            this.Controls.Add(this.txtValorDesconto);
            this.Controls.Add(this.txtPercentualDesconto);
            this.Controls.Add(this.txtValorTarifaAnt);
            this.Controls.Add(this.txtPercentualTarifaAnt);
            this.Controls.Add(this.txtValorTarifa);
            this.Controls.Add(this.txtPercentualTarifa);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.txtDescricaoTela);
            this.Controls.Add(this.lblDescricaoTela);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarAdministradora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administradora";
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lblDescricaoTela, 0);
            this.Controls.SetChildIndex(this.txtDescricaoTela, 0);
            this.Controls.SetChildIndex(this.txtObservacao, 0);
            this.Controls.SetChildIndex(this.lblObservacao, 0);
            this.Controls.SetChildIndex(this.txtPercentualTarifa, 0);
            this.Controls.SetChildIndex(this.txtValorTarifa, 0);
            this.Controls.SetChildIndex(this.txtPercentualTarifaAnt, 0);
            this.Controls.SetChildIndex(this.txtValorTarifaAnt, 0);
            this.Controls.SetChildIndex(this.txtPercentualDesconto, 0);
            this.Controls.SetChildIndex(this.txtValorDesconto, 0);
            this.Controls.SetChildIndex(this.lblPercentualTarifa, 0);
            this.Controls.SetChildIndex(this.lblTarifaValor, 0);
            this.Controls.SetChildIndex(this.lblTarifaAnterior, 0);
            this.Controls.SetChildIndex(this.lblValorTarifaAnt, 0);
            this.Controls.SetChildIndex(this.lblDescontoPercentual, 0);
            this.Controls.SetChildIndex(this.lblValorDesconto, 0);
            this.Controls.SetChildIndex(this.imgProduto, 0);
            this.Controls.SetChildIndex(this.pnlFoto, 0);
            this.pnlFoto.ResumeLayout(false);
            this.pnlFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtDescricaoTela;
        private System.Windows.Forms.Label lblDescricaoTela;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txtPercentualTarifa;
        private System.Windows.Forms.TextBox txtValorTarifa;
        private System.Windows.Forms.TextBox txtPercentualTarifaAnt;
        private System.Windows.Forms.TextBox txtValorTarifaAnt;
        private System.Windows.Forms.TextBox txtPercentualDesconto;
        private System.Windows.Forms.TextBox txtValorDesconto;
        private System.Windows.Forms.Label lblPercentualTarifa;
        private System.Windows.Forms.Label lblTarifaValor;
        private System.Windows.Forms.Label lblTarifaAnterior;
        private System.Windows.Forms.Label lblValorTarifaAnt;
        private System.Windows.Forms.Label lblDescontoPercentual;
        private System.Windows.Forms.Label lblValorDesconto;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.LinkLabel lnkAlterarFoto;
        private System.Windows.Forms.PictureBox imgProduto;
        private System.Windows.Forms.OpenFileDialog fdgImgImagemAdministradora;
    }
}