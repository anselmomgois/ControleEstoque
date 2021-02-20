namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarFormaPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarFormaPagamento));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtPercentualAcrescimo = new System.Windows.Forms.TextBox();
            this.lblPercentualAcrescimo = new System.Windows.Forms.Label();
            this.txtValorAcrescimo = new System.Windows.Forms.TextBox();
            this.txtPercentualDesconto = new System.Windows.Forms.TextBox();
            this.txtValorDesconto = new System.Windows.Forms.TextBox();
            this.lblValorAcrescimo = new System.Windows.Forms.Label();
            this.lblPercentualDesconto = new System.Windows.Forms.Label();
            this.lblValorDesconto = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lstTipoPagamento = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(665, 331);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstTipoPagamento);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Controls.Add(this.txtPercentualAcrescimo);
            this.panel2.Controls.Add(this.lblPercentualAcrescimo);
            this.panel2.Controls.Add(this.txtValorAcrescimo);
            this.panel2.Controls.Add(this.txtPercentualDesconto);
            this.panel2.Controls.Add(this.txtValorDesconto);
            this.panel2.Controls.Add(this.lblValorAcrescimo);
            this.panel2.Controls.Add(this.lblPercentualDesconto);
            this.panel2.Controls.Add(this.lblValorDesconto);
            this.panel2.Controls.Add(this.lblDescricao);
            this.panel2.Controls.Add(this.lblCodigo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 323);
            this.panel2.TabIndex = 6;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(133, 30);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(349, 22);
            this.txtDescricao.TabIndex = 30;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(133, 6);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(151, 22);
            this.txtCodigo.TabIndex = 29;
            // 
            // txtPercentualAcrescimo
            // 
            this.txtPercentualAcrescimo.Location = new System.Drawing.Point(133, 126);
            this.txtPercentualAcrescimo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentualAcrescimo.Name = "txtPercentualAcrescimo";
            this.txtPercentualAcrescimo.Size = new System.Drawing.Size(151, 22);
            this.txtPercentualAcrescimo.TabIndex = 40;
            this.txtPercentualAcrescimo.Enter += new System.EventHandler(this.txtPercentualAcrescimo_Enter);
            // 
            // lblPercentualAcrescimo
            // 
            this.lblPercentualAcrescimo.AutoSize = true;
            this.lblPercentualAcrescimo.Location = new System.Drawing.Point(23, 131);
            this.lblPercentualAcrescimo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualAcrescimo.Name = "lblPercentualAcrescimo";
            this.lblPercentualAcrescimo.Size = new System.Drawing.Size(99, 17);
            this.lblPercentualAcrescimo.TabIndex = 38;
            this.lblPercentualAcrescimo.Text = "Acréscimo (%)";
            // 
            // txtValorAcrescimo
            // 
            this.txtValorAcrescimo.Location = new System.Drawing.Point(133, 102);
            this.txtValorAcrescimo.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorAcrescimo.Name = "txtValorAcrescimo";
            this.txtValorAcrescimo.Size = new System.Drawing.Size(151, 22);
            this.txtValorAcrescimo.TabIndex = 37;
            this.txtValorAcrescimo.Enter += new System.EventHandler(this.txtValorAcrescimo_Enter);
            // 
            // txtPercentualDesconto
            // 
            this.txtPercentualDesconto.Location = new System.Drawing.Point(133, 78);
            this.txtPercentualDesconto.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercentualDesconto.Name = "txtPercentualDesconto";
            this.txtPercentualDesconto.Size = new System.Drawing.Size(151, 22);
            this.txtPercentualDesconto.TabIndex = 36;
            this.txtPercentualDesconto.Enter += new System.EventHandler(this.txtPercentualDesconto_Enter);
            // 
            // txtValorDesconto
            // 
            this.txtValorDesconto.Location = new System.Drawing.Point(133, 54);
            this.txtValorDesconto.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorDesconto.Name = "txtValorDesconto";
            this.txtValorDesconto.Size = new System.Drawing.Size(151, 22);
            this.txtValorDesconto.TabIndex = 35;
            this.txtValorDesconto.Enter += new System.EventHandler(this.txtValorDesconto_Enter);
            // 
            // lblValorAcrescimo
            // 
            this.lblValorAcrescimo.AutoSize = true;
            this.lblValorAcrescimo.Location = new System.Drawing.Point(20, 107);
            this.lblValorAcrescimo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorAcrescimo.Name = "lblValorAcrescimo";
            this.lblValorAcrescimo.Size = new System.Drawing.Size(110, 17);
            this.lblValorAcrescimo.TabIndex = 34;
            this.lblValorAcrescimo.Text = "Valor Acréscimo";
            // 
            // lblPercentualDesconto
            // 
            this.lblPercentualDesconto.AutoSize = true;
            this.lblPercentualDesconto.Location = new System.Drawing.Point(23, 83);
            this.lblPercentualDesconto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualDesconto.Name = "lblPercentualDesconto";
            this.lblPercentualDesconto.Size = new System.Drawing.Size(94, 17);
            this.lblPercentualDesconto.TabIndex = 33;
            this.lblPercentualDesconto.Text = "Desconto (%)";
            // 
            // lblValorDesconto
            // 
            this.lblValorDesconto.AutoSize = true;
            this.lblValorDesconto.Location = new System.Drawing.Point(20, 59);
            this.lblValorDesconto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorDesconto.Name = "lblValorDesconto";
            this.lblValorDesconto.Size = new System.Drawing.Size(105, 17);
            this.lblValorDesconto.TabIndex = 32;
            this.lblValorDesconto.Text = "Valor Desconto";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(23, 35);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(71, 17);
            this.lblDescricao.TabIndex = 31;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(23, 10);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 27;
            this.lblCodigo.Text = "Código";
            // 
            // lstTipoPagamento
            // 
            this.lstTipoPagamento.FormattingEnabled = true;
            this.lstTipoPagamento.ItemHeight = 16;
            this.lstTipoPagamento.Location = new System.Drawing.Point(133, 150);
            this.lstTipoPagamento.Name = "lstTipoPagamento";
            this.lstTipoPagamento.Size = new System.Drawing.Size(349, 84);
            this.lstTipoPagamento.TabIndex = 41;
            // 
            // GuardarFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 467);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarFormaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forma de Pagamento";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtPercentualAcrescimo;
        private System.Windows.Forms.Label lblPercentualAcrescimo;
        private System.Windows.Forms.TextBox txtValorAcrescimo;
        private System.Windows.Forms.TextBox txtPercentualDesconto;
        private System.Windows.Forms.TextBox txtValorDesconto;
        private System.Windows.Forms.Label lblValorAcrescimo;
        private System.Windows.Forms.Label lblPercentualDesconto;
        private System.Windows.Forms.Label lblValorDesconto;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ListBox lstTipoPagamento;
    }
}