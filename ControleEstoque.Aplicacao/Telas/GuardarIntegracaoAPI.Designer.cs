namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarIntegracaoAPI
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
            this.gpbClientes = new System.Windows.Forms.GroupBox();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblTipoCrm = new System.Windows.Forms.Label();
            this.cmbTipoCRM = new System.Windows.Forms.ComboBox();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbClientes
            // 
            this.gpbClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbClientes.Location = new System.Drawing.Point(0, 0);
            this.gpbClientes.Name = "gpbClientes";
            this.gpbClientes.Size = new System.Drawing.Size(672, 113);
            this.gpbClientes.TabIndex = 0;
            this.gpbClientes.TabStop = false;
            this.gpbClientes.Text = "API";
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 2;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.cmbTipoCRM, 1, 1);
            this.tlpPrincipal.Controls.Add(this.lblTipo, 0, 0);
            this.tlpPrincipal.Controls.Add(this.cmbTipo, 1, 0);
            this.tlpPrincipal.Controls.Add(this.label1, 0, 2);
            this.tlpPrincipal.Controls.Add(this.txtUrl, 1, 2);
            this.tlpPrincipal.Controls.Add(this.lblTipoCrm, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPrincipal.Size = new System.Drawing.Size(502, 76);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url";
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(2, 5);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(92, 2);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(183, 21);
            this.cmbTipo.TabIndex = 1;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(92, 52);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(408, 20);
            this.txtUrl.TabIndex = 3;
            // 
            // lblTipoCrm
            // 
            this.lblTipoCrm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTipoCrm.AutoSize = true;
            this.lblTipoCrm.Location = new System.Drawing.Point(3, 29);
            this.lblTipoCrm.Name = "lblTipoCrm";
            this.lblTipoCrm.Size = new System.Drawing.Size(55, 13);
            this.lblTipoCrm.TabIndex = 4;
            this.lblTipoCrm.Text = "Tipo CRM";
            // 
            // cmbTipoCRM
            // 
            this.cmbTipoCRM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTipoCRM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCRM.FormattingEnabled = true;
            this.cmbTipoCRM.Location = new System.Drawing.Point(92, 26);
            this.cmbTipoCRM.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoCRM.Name = "cmbTipoCRM";
            this.cmbTipoCRM.Size = new System.Drawing.Size(183, 21);
            this.cmbTipoCRM.TabIndex = 5;
            // 
            // GuardarIntegracaoAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 212);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "GuardarIntegracaoAPI";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "API";
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox gpbClientes;

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ComboBox cmbTipoCRM;
        private System.Windows.Forms.Label lblTipoCrm;
    }
}