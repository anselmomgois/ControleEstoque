namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarTipoCrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarTipoCrmConfig));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lstFuncionarios = new System.Windows.Forms.ListBox();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.lblResponsavelEtapaAnterior = new System.Windows.Forms.Label();
            this.chkFuncionarioAnterior = new System.Windows.Forms.CheckBox();
            this.txtQuantidadeDias = new System.Windows.Forms.NumericUpDown();
            this.txtQuantidadeFuncionarios = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidadeDias = new System.Windows.Forms.Label();
            this.lblQuantidadeFuncionarios = new System.Windows.Forms.Label();
            this.cmbTipoEmpregado = new System.Windows.Forms.ComboBox();
            this.lblTipoFuncionario = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeFuncionarios)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNome.Location = new System.Drawing.Point(104, 9);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(249, 22);
            this.txtNome.TabIndex = 11;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(4, 11);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(71, 17);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Descrição";
            // 
            // lstFuncionarios
            // 
            this.lstFuncionarios.FormattingEnabled = true;
            this.lstFuncionarios.ItemHeight = 16;
            this.lstFuncionarios.Location = new System.Drawing.Point(104, 44);
            this.lstFuncionarios.Margin = new System.Windows.Forms.Padding(4);
            this.lstFuncionarios.Name = "lstFuncionarios";
            this.lstFuncionarios.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFuncionarios.Size = new System.Drawing.Size(249, 116);
            this.lstFuncionarios.TabIndex = 1001;
            this.lstFuncionarios.SelectedIndexChanged += new System.EventHandler(this.lstFuncionarios_SelectedIndexChanged);
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Location = new System.Drawing.Point(4, 40);
            this.lblFuncionario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(82, 17);
            this.lblFuncionario.TabIndex = 1002;
            this.lblFuncionario.Text = "Funcionario";
            // 
            // lblResponsavelEtapaAnterior
            // 
            this.lblResponsavelEtapaAnterior.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblResponsavelEtapaAnterior.AutoSize = true;
            this.lblResponsavelEtapaAnterior.Location = new System.Drawing.Point(4, 30);
            this.lblResponsavelEtapaAnterior.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResponsavelEtapaAnterior.Name = "lblResponsavelEtapaAnterior";
            this.lblResponsavelEtapaAnterior.Size = new System.Drawing.Size(263, 30);
            this.lblResponsavelEtapaAnterior.TabIndex = 1003;
            this.lblResponsavelEtapaAnterior.Text = "O(s) funcionário(s) da estapa anterior é responsavel por está etapa?";
            // 
            // chkFuncionarioAnterior
            // 
            this.chkFuncionarioAnterior.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkFuncionarioAnterior.AutoSize = true;
            this.chkFuncionarioAnterior.Location = new System.Drawing.Point(282, 36);
            this.chkFuncionarioAnterior.Name = "chkFuncionarioAnterior";
            this.chkFuncionarioAnterior.Size = new System.Drawing.Size(18, 17);
            this.chkFuncionarioAnterior.TabIndex = 1004;
            this.chkFuncionarioAnterior.UseVisualStyleBackColor = true;
            this.chkFuncionarioAnterior.CheckedChanged += new System.EventHandler(this.chkFuncionarioAnterior_CheckedChanged);
            // 
            // txtQuantidadeDias
            // 
            this.txtQuantidadeDias.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtQuantidadeDias.Location = new System.Drawing.Point(282, 64);
            this.txtQuantidadeDias.Name = "txtQuantidadeDias";
            this.txtQuantidadeDias.Size = new System.Drawing.Size(107, 22);
            this.txtQuantidadeDias.TabIndex = 1005;
            // 
            // txtQuantidadeFuncionarios
            // 
            this.txtQuantidadeFuncionarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtQuantidadeFuncionarios.Location = new System.Drawing.Point(282, 94);
            this.txtQuantidadeFuncionarios.Name = "txtQuantidadeFuncionarios";
            this.txtQuantidadeFuncionarios.Size = new System.Drawing.Size(107, 22);
            this.txtQuantidadeFuncionarios.TabIndex = 1006;
            // 
            // lblQuantidadeDias
            // 
            this.lblQuantidadeDias.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuantidadeDias.AutoSize = true;
            this.lblQuantidadeDias.Location = new System.Drawing.Point(4, 60);
            this.lblQuantidadeDias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantidadeDias.Name = "lblQuantidadeDias";
            this.lblQuantidadeDias.Size = new System.Drawing.Size(257, 30);
            this.lblQuantidadeDias.TabIndex = 1007;
            this.lblQuantidadeDias.Text = "Quantidade de minutos para concluir à etapa";
            // 
            // lblQuantidadeFuncionarios
            // 
            this.lblQuantidadeFuncionarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQuantidadeFuncionarios.AutoSize = true;
            this.lblQuantidadeFuncionarios.Location = new System.Drawing.Point(4, 96);
            this.lblQuantidadeFuncionarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantidadeFuncionarios.Name = "lblQuantidadeFuncionarios";
            this.lblQuantidadeFuncionarios.Size = new System.Drawing.Size(224, 17);
            this.lblQuantidadeFuncionarios.TabIndex = 1008;
            this.lblQuantidadeFuncionarios.Text = "Quantidade funcionários alocados";
            // 
            // cmbTipoEmpregado
            // 
            this.cmbTipoEmpregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEmpregado.FormattingEnabled = true;
            this.cmbTipoEmpregado.Location = new System.Drawing.Point(282, 123);
            this.cmbTipoEmpregado.Name = "cmbTipoEmpregado";
            this.cmbTipoEmpregado.Size = new System.Drawing.Size(267, 24);
            this.cmbTipoEmpregado.TabIndex = 1010;
            this.cmbTipoEmpregado.SelectedIndexChanged += new System.EventHandler(this.cmbTipoEmpregado_SelectedIndexChanged);
            // 
            // lblTipoFuncionario
            // 
            this.lblTipoFuncionario.AutoSize = true;
            this.lblTipoFuncionario.Location = new System.Drawing.Point(4, 120);
            this.lblTipoFuncionario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoFuncionario.Name = "lblTipoFuncionario";
            this.lblTipoFuncionario.Size = new System.Drawing.Size(114, 17);
            this.lblTipoFuncionario.TabIndex = 1009;
            this.lblTipoFuncionario.Text = "Tipo Funcionário";
            // 
            // lblNivel
            // 
            this.lblNivel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(4, 6);
            this.lblNivel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(39, 17);
            this.lblNivel.TabIndex = 1011;
            this.lblNivel.Text = "Nivel";
            // 
            // txtNivel
            // 
            this.txtNivel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNivel.Enabled = false;
            this.txtNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNivel.Location = new System.Drawing.Point(283, 4);
            this.txtNivel.Margin = new System.Windows.Forms.Padding(4);
            this.txtNivel.MaxLength = 50;
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(108, 23);
            this.txtNivel.TabIndex = 1012;
            this.txtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 217);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblNome, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtNome, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lstFuncionarios, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblFuncionario, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(557, 211);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cmbTipoEmpregado, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblTipoFuncionario, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblQuantidadeFuncionarios, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtQuantidadeFuncionarios, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblQuantidadeDias, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtNivel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblNivel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblResponsavelEtapaAnterior, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtQuantidadeDias, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkFuncionarioAnterior, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(566, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(558, 211);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // GuardarTipoCrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1133, 353);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GuardarTipoCrmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipo CRM";
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeFuncionarios)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ListBox lstFuncionarios;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.Label lblResponsavelEtapaAnterior;
        private System.Windows.Forms.CheckBox chkFuncionarioAnterior;
        private System.Windows.Forms.NumericUpDown txtQuantidadeDias;
        private System.Windows.Forms.NumericUpDown txtQuantidadeFuncionarios;
        private System.Windows.Forms.Label lblQuantidadeDias;
        private System.Windows.Forms.Label lblQuantidadeFuncionarios;
        private System.Windows.Forms.ComboBox cmbTipoEmpregado;
        private System.Windows.Forms.Label lblTipoFuncionario;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}