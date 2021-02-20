namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarUnidadeMedida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarUnidadeMedida));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescUnidadePai = new System.Windows.Forms.Label();
            this.ddlUnidadePai = new System.Windows.Forms.ComboBox();
            this.lblValorUnidadePai = new System.Windows.Forms.Label();
            this.txtUnidadePai = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNome.Location = new System.Drawing.Point(184, 29);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 22);
            this.txtNome.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(4, 29);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(122, 17);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Nome da Unidade";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCodigo.Location = new System.Drawing.Point(184, 4);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(95, 22);
            this.txtCodigo.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(4, 4);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "Código";
            // 
            // lblDescUnidadePai
            // 
            this.lblDescUnidadePai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescUnidadePai.AutoSize = true;
            this.lblDescUnidadePai.Location = new System.Drawing.Point(4, 54);
            this.lblDescUnidadePai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescUnidadePai.Name = "lblDescUnidadePai";
            this.lblDescUnidadePai.Size = new System.Drawing.Size(155, 17);
            this.lblDescUnidadePai.TabIndex = 8;
            this.lblDescUnidadePai.Text = "Unidade de Medida Pai";
            // 
            // ddlUnidadePai
            // 
            this.ddlUnidadePai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ddlUnidadePai.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ddlUnidadePai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUnidadePai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlUnidadePai.FormattingEnabled = true;
            this.ddlUnidadePai.Location = new System.Drawing.Point(184, 54);
            this.ddlUnidadePai.Margin = new System.Windows.Forms.Padding(4);
            this.ddlUnidadePai.Name = "ddlUnidadePai";
            this.ddlUnidadePai.Size = new System.Drawing.Size(261, 24);
            this.ddlUnidadePai.TabIndex = 2;
            this.ddlUnidadePai.SelectedIndexChanged += new System.EventHandler(this.ddlUnidadePai_SelectedIndexChanged);
            // 
            // lblValorUnidadePai
            // 
            this.lblValorUnidadePai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorUnidadePai.AutoSize = true;
            this.lblValorUnidadePai.Location = new System.Drawing.Point(4, 90);
            this.lblValorUnidadePai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorUnidadePai.Name = "lblValorUnidadePai";
            this.lblValorUnidadePai.Size = new System.Drawing.Size(122, 17);
            this.lblValorUnidadePai.TabIndex = 13;
            this.lblValorUnidadePai.Text = "Valor Unidade Pai";
            // 
            // txtUnidadePai
            // 
            this.txtUnidadePai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUnidadePai.Location = new System.Drawing.Point(184, 87);
            this.txtUnidadePai.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnidadePai.MaxLength = 10;
            this.txtUnidadePai.Name = "txtUnidadePai";
            this.txtUnidadePai.Size = new System.Drawing.Size(95, 22);
            this.txtUnidadePai.TabIndex = 3;
            this.txtUnidadePai.Enter += new System.EventHandler(this.txtUnidadePai_Enter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtUnidadePai, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblValorUnidadePai, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ddlUnidadePai, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDescUnidadePai, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNome, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescricao, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCodigo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCodigo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 122);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // GuardarUnidadeMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(612, 299);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GuardarUnidadeMedida";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unidade de Medida";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescUnidadePai;
        private System.Windows.Forms.ComboBox ddlUnidadePai;
        private System.Windows.Forms.Label lblValorUnidadePai;
        private System.Windows.Forms.TextBox txtUnidadePai;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}