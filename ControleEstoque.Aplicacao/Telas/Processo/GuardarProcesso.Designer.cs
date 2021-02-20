namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProcesso
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
            this.nudQuantidadeTentativas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoProcesso = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoCrm = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.nudIntervaloExecucao = new System.Windows.Forms.NumericUpDown();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tlpPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeTentativas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloExecucao)).BeginInit();
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
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.label3, 0, 4);
            this.tlpPrincipal.Controls.Add(this.nudQuantidadeTentativas, 1, 3);
            this.tlpPrincipal.Controls.Add(this.label2, 0, 3);
            this.tlpPrincipal.Controls.Add(this.cmbTipoProcesso, 1, 1);
            this.tlpPrincipal.Controls.Add(this.lblTipo, 0, 0);
            this.tlpPrincipal.Controls.Add(this.label1, 0, 2);
            this.tlpPrincipal.Controls.Add(this.lblTipoCrm, 0, 1);
            this.tlpPrincipal.Controls.Add(this.txtDescricao, 1, 0);
            this.tlpPrincipal.Controls.Add(this.nudIntervaloExecucao, 1, 2);
            this.tlpPrincipal.Controls.Add(this.chkAtivo, 1, 4);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 6;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(671, 194);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // nudQuantidadeTentativas
            // 
            this.nudQuantidadeTentativas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudQuantidadeTentativas.Location = new System.Drawing.Point(163, 78);
            this.nudQuantidadeTentativas.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudQuantidadeTentativas.Name = "nudQuantidadeTentativas";
            this.nudQuantidadeTentativas.Size = new System.Drawing.Size(120, 22);
            this.nudQuantidadeTentativas.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quantidade Tentativas";
            // 
            // cmbTipoProcesso
            // 
            this.cmbTipoProcesso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbTipoProcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProcesso.FormattingEnabled = true;
            this.cmbTipoProcesso.Location = new System.Drawing.Point(163, 27);
            this.cmbTipoProcesso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipoProcesso.Name = "cmbTipoProcesso";
            this.cmbTipoProcesso.Size = new System.Drawing.Size(243, 24);
            this.cmbTipoProcesso.TabIndex = 5;
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(3, 4);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(71, 17);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Intervalo Execução";
            // 
            // lblTipoCrm
            // 
            this.lblTipoCrm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTipoCrm.AutoSize = true;
            this.lblTipoCrm.Location = new System.Drawing.Point(4, 29);
            this.lblTipoCrm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoCrm.Name = "lblTipoCrm";
            this.lblTipoCrm.Size = new System.Drawing.Size(99, 17);
            this.lblTipoCrm.TabIndex = 4;
            this.lblTipoCrm.Text = "Tipo Processo";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(163, 2);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(505, 22);
            this.txtDescricao.TabIndex = 3;
            // 
            // nudIntervaloExecucao
            // 
            this.nudIntervaloExecucao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudIntervaloExecucao.Location = new System.Drawing.Point(163, 53);
            this.nudIntervaloExecucao.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudIntervaloExecucao.Name = "nudIntervaloExecucao";
            this.nudIntervaloExecucao.Size = new System.Drawing.Size(120, 22);
            this.nudIntervaloExecucao.TabIndex = 6;
            // 
            // chkAtivo
            // 
            this.chkAtivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(163, 104);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(18, 17);
            this.chkAtivo.TabIndex = 10;
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ativo";
            // 
            // GuardarProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 330);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "GuardarProcesso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processo";
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeTentativas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloExecucao)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox gpbClientes;

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.ComboBox cmbTipoProcesso;
        private System.Windows.Forms.Label lblTipoCrm;
        private System.Windows.Forms.NumericUpDown nudQuantidadeTentativas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudIntervaloExecucao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAtivo;
    }
}