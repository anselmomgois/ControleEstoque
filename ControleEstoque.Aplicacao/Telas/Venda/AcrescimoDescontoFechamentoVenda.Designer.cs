namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class AcrescimoDescontoFechamentoVenda
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
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrecoPorcentagem = new System.Windows.Forms.Panel();
            this.tlpPrecoPorcentagem = new System.Windows.Forms.TableLayoutPanel();
            this.rbPorcentagem = new System.Windows.Forms.RadioButton();
            this.rbPreco = new System.Windows.Forms.RadioButton();
            this.pnlAcrescimoDesconto = new System.Windows.Forms.Panel();
            this.tlpAcrescimoDesconto = new System.Windows.Forms.TableLayoutPanel();
            this.rbAcrescimo = new System.Windows.Forms.RadioButton();
            this.rbDesconto = new System.Windows.Forms.RadioButton();
            this.txtNovoValor = new System.Windows.Forms.TextBox();
            this.tlpGeral.SuspendLayout();
            this.pnlPrecoPorcentagem.SuspendLayout();
            this.tlpPrecoPorcentagem.SuspendLayout();
            this.pnlAcrescimoDesconto.SuspendLayout();
            this.tlpAcrescimoDesconto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 2;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.11839F));
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.88161F));
            this.tlpGeral.Controls.Add(this.pnlPrecoPorcentagem, 1, 0);
            this.tlpGeral.Controls.Add(this.pnlAcrescimoDesconto, 0, 0);
            this.tlpGeral.Controls.Add(this.txtNovoValor, 0, 1);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 2;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGeral.Size = new System.Drawing.Size(419, 114);
            this.tlpGeral.TabIndex = 3;
            // 
            // pnlPrecoPorcentagem
            // 
            this.pnlPrecoPorcentagem.Controls.Add(this.tlpPrecoPorcentagem);
            this.pnlPrecoPorcentagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrecoPorcentagem.Location = new System.Drawing.Point(208, 3);
            this.pnlPrecoPorcentagem.Name = "pnlPrecoPorcentagem";
            this.pnlPrecoPorcentagem.Size = new System.Drawing.Size(208, 52);
            this.pnlPrecoPorcentagem.TabIndex = 18;
            // 
            // tlpPrecoPorcentagem
            // 
            this.tlpPrecoPorcentagem.ColumnCount = 2;
            this.tlpPrecoPorcentagem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.28571F));
            this.tlpPrecoPorcentagem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.71429F));
            this.tlpPrecoPorcentagem.Controls.Add(this.rbPorcentagem, 0, 0);
            this.tlpPrecoPorcentagem.Controls.Add(this.rbPreco, 0, 0);
            this.tlpPrecoPorcentagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrecoPorcentagem.Location = new System.Drawing.Point(0, 0);
            this.tlpPrecoPorcentagem.Name = "tlpPrecoPorcentagem";
            this.tlpPrecoPorcentagem.RowCount = 1;
            this.tlpPrecoPorcentagem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrecoPorcentagem.Size = new System.Drawing.Size(208, 52);
            this.tlpPrecoPorcentagem.TabIndex = 0;
            // 
            // rbPorcentagem
            // 
            this.rbPorcentagem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbPorcentagem.AutoSize = true;
            this.rbPorcentagem.Location = new System.Drawing.Point(84, 17);
            this.rbPorcentagem.Name = "rbPorcentagem";
            this.rbPorcentagem.Size = new System.Drawing.Size(105, 17);
            this.rbPorcentagem.TabIndex = 5;
            this.rbPorcentagem.TabStop = true;
            this.rbPorcentagem.Text = "Porcentagem (%)";
            this.rbPorcentagem.UseVisualStyleBackColor = true;
            // 
            // rbPreco
            // 
            this.rbPreco.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbPreco.AutoSize = true;
            this.rbPreco.Location = new System.Drawing.Point(25, 17);
            this.rbPreco.Name = "rbPreco";
            this.rbPreco.Size = new System.Drawing.Size(53, 17);
            this.rbPreco.TabIndex = 4;
            this.rbPreco.TabStop = true;
            this.rbPreco.Text = "Preço";
            this.rbPreco.UseVisualStyleBackColor = true;
            // 
            // pnlAcrescimoDesconto
            // 
            this.pnlAcrescimoDesconto.Controls.Add(this.tlpAcrescimoDesconto);
            this.pnlAcrescimoDesconto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAcrescimoDesconto.Location = new System.Drawing.Point(3, 3);
            this.pnlAcrescimoDesconto.Name = "pnlAcrescimoDesconto";
            this.pnlAcrescimoDesconto.Size = new System.Drawing.Size(199, 52);
            this.pnlAcrescimoDesconto.TabIndex = 17;
            // 
            // tlpAcrescimoDesconto
            // 
            this.tlpAcrescimoDesconto.ColumnCount = 2;
            this.tlpAcrescimoDesconto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcrescimoDesconto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpAcrescimoDesconto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcrescimoDesconto.Controls.Add(this.rbAcrescimo, 0, 0);
            this.tlpAcrescimoDesconto.Controls.Add(this.rbDesconto, 1, 0);
            this.tlpAcrescimoDesconto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAcrescimoDesconto.Location = new System.Drawing.Point(0, 0);
            this.tlpAcrescimoDesconto.Name = "tlpAcrescimoDesconto";
            this.tlpAcrescimoDesconto.RowCount = 1;
            this.tlpAcrescimoDesconto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcrescimoDesconto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpAcrescimoDesconto.Size = new System.Drawing.Size(199, 52);
            this.tlpAcrescimoDesconto.TabIndex = 0;
            // 
            // rbAcrescimo
            // 
            this.rbAcrescimo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbAcrescimo.AutoSize = true;
            this.rbAcrescimo.Location = new System.Drawing.Point(3, 17);
            this.rbAcrescimo.Name = "rbAcrescimo";
            this.rbAcrescimo.Size = new System.Drawing.Size(74, 17);
            this.rbAcrescimo.TabIndex = 1;
            this.rbAcrescimo.TabStop = true;
            this.rbAcrescimo.Text = "Acrescimo";
            this.rbAcrescimo.UseVisualStyleBackColor = true;
            // 
            // rbDesconto
            // 
            this.rbDesconto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbDesconto.AutoSize = true;
            this.rbDesconto.Location = new System.Drawing.Point(104, 17);
            this.rbDesconto.Name = "rbDesconto";
            this.rbDesconto.Size = new System.Drawing.Size(71, 17);
            this.rbDesconto.TabIndex = 2;
            this.rbDesconto.TabStop = true;
            this.rbDesconto.Text = "Desconto";
            this.rbDesconto.UseVisualStyleBackColor = true;
            // 
            // txtNovoValor
            // 
            this.tlpGeral.SetColumnSpan(this.txtNovoValor, 2);
            this.txtNovoValor.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNovoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNovoValor.Location = new System.Drawing.Point(3, 61);
            this.txtNovoValor.Name = "txtNovoValor";
            this.txtNovoValor.Size = new System.Drawing.Size(413, 29);
            this.txtNovoValor.TabIndex = 99;
            this.txtNovoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNovoValor.Enter += new System.EventHandler(this.txtNovoValor_Enter);
            this.txtNovoValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNovoValor_KeyPress);
            // 
            // AcrescimoDescontoFechamentoVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 250);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AcrescimoDescontoFechamentoVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fechamento Venda - Acréscimo / Desconto";
            this.tlpGeral.ResumeLayout(false);
            this.tlpGeral.PerformLayout();
            this.pnlPrecoPorcentagem.ResumeLayout(false);
            this.tlpPrecoPorcentagem.ResumeLayout(false);
            this.tlpPrecoPorcentagem.PerformLayout();
            this.pnlAcrescimoDesconto.ResumeLayout(false);
            this.tlpAcrescimoDesconto.ResumeLayout(false);
            this.tlpAcrescimoDesconto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.TextBox txtNovoValor;
        private System.Windows.Forms.Panel pnlPrecoPorcentagem;
        private System.Windows.Forms.TableLayoutPanel tlpPrecoPorcentagem;
        private System.Windows.Forms.RadioButton rbPorcentagem;
        private System.Windows.Forms.RadioButton rbPreco;
        private System.Windows.Forms.Panel pnlAcrescimoDesconto;
        private System.Windows.Forms.TableLayoutPanel tlpAcrescimoDesconto;
        private System.Windows.Forms.RadioButton rbAcrescimo;
        private System.Windows.Forms.RadioButton rbDesconto;
    }
}