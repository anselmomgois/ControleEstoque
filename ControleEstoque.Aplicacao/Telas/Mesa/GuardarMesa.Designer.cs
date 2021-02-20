namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarMesa
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
            this.lblAtivo = new System.Windows.Forms.Label();
            this.lstMesas = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoMesa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidadeLugares = new System.Windows.Forms.NumericUpDown();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.tlpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeLugares)).BeginInit();
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
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.lblAtivo, 0, 3);
            this.tlpPrincipal.Controls.Add(this.lstMesas, 1, 2);
            this.tlpPrincipal.Controls.Add(this.label3, 0, 2);
            this.tlpPrincipal.Controls.Add(this.txtCodigoMesa, 1, 0);
            this.tlpPrincipal.Controls.Add(this.label1, 0, 0);
            this.tlpPrincipal.Controls.Add(this.label2, 0, 1);
            this.tlpPrincipal.Controls.Add(this.txtQuantidadeLugares, 1, 1);
            this.tlpPrincipal.Controls.Add(this.chkAtivo, 1, 3);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 4;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPrincipal.Size = new System.Drawing.Size(386, 213);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // lblAtivo
            // 
            this.lblAtivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAtivo.AutoSize = true;
            this.lblAtivo.Location = new System.Drawing.Point(3, 189);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.Size = new System.Drawing.Size(77, 17);
            this.lblAtivo.TabIndex = 18;
            this.lblAtivo.Text = "Mesa Ativa";
            // 
            // lstMesas
            // 
            this.lstMesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMesas.FormattingEnabled = true;
            this.lstMesas.ItemHeight = 16;
            this.lstMesas.Location = new System.Drawing.Point(154, 64);
            this.lstMesas.Margin = new System.Windows.Forms.Padding(4);
            this.lstMesas.Name = "lstMesas";
            this.lstMesas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstMesas.Size = new System.Drawing.Size(228, 115);
            this.lstMesas.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mesas Proximas";
            // 
            // txtCodigoMesa
            // 
            this.txtCodigoMesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoMesa.Location = new System.Drawing.Point(153, 4);
            this.txtCodigoMesa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoMesa.Name = "txtCodigoMesa";
            this.txtCodigoMesa.Size = new System.Drawing.Size(230, 22);
            this.txtCodigoMesa.TabIndex = 3;
            this.txtCodigoMesa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoMesa_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantidade Lugares";
            // 
            // txtQuantidadeLugares
            // 
            this.txtQuantidadeLugares.Location = new System.Drawing.Point(153, 33);
            this.txtQuantidadeLugares.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantidadeLugares.Name = "txtQuantidadeLugares";
            this.txtQuantidadeLugares.Size = new System.Drawing.Size(120, 22);
            this.txtQuantidadeLugares.TabIndex = 5;
            this.txtQuantidadeLugares.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // chkAtivo
            // 
            this.chkAtivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(153, 189);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(18, 17);
            this.chkAtivo.TabIndex = 17;
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // GuardarMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 349);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "GuardarMesa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mesa";
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeLugares)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox gpbClientes;

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoMesa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtQuantidadeLugares;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstMesas;
        private System.Windows.Forms.Label lblAtivo;
        private System.Windows.Forms.CheckBox chkAtivo;
    }
}