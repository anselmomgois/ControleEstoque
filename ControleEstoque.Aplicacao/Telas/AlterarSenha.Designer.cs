namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class AlterarSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlterarSenha));
            this.lblNovaSenha = new System.Windows.Forms.Label();
            this.lblConfirmarSenha = new System.Windows.Forms.Label();
            this.txtNovaSenha = new System.Windows.Forms.MaskedTextBox();
            this.txtConfirmarSenha = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNovaSenha
            // 
            this.lblNovaSenha.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNovaSenha.AutoSize = true;
            this.lblNovaSenha.Location = new System.Drawing.Point(4, 6);
            this.lblNovaSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNovaSenha.Name = "lblNovaSenha";
            this.lblNovaSenha.Size = new System.Drawing.Size(86, 17);
            this.lblNovaSenha.TabIndex = 1;
            this.lblNovaSenha.Text = "Nova Senha";
            // 
            // lblConfirmarSenha
            // 
            this.lblConfirmarSenha.AutoSize = true;
            this.lblConfirmarSenha.Location = new System.Drawing.Point(4, 30);
            this.lblConfirmarSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmarSenha.Name = "lblConfirmarSenha";
            this.lblConfirmarSenha.Size = new System.Drawing.Size(151, 17);
            this.lblConfirmarSenha.TabIndex = 2;
            this.lblConfirmarSenha.Text = "Confirmar Nova Senha";
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNovaSenha.Location = new System.Drawing.Point(174, 4);
            this.txtNovaSenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.Size = new System.Drawing.Size(261, 22);
            this.txtNovaSenha.TabIndex = 1;
            this.txtNovaSenha.UseSystemPasswordChar = true;
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Location = new System.Drawing.Point(174, 30);
            this.txtConfirmarSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(261, 22);
            this.txtConfirmarSenha.TabIndex = 2;
            this.txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblNovaSenha, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtConfirmarSenha, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblConfirmarSenha, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtNovaSenha, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(607, 101);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // AlterarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(613, 237);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlterarSenha";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alterar Senha Usuário";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlterarSenha_FormClosing);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNovaSenha;
        private System.Windows.Forms.Label lblConfirmarSenha;
        private System.Windows.Forms.MaskedTextBox txtNovaSenha;
        private System.Windows.Forms.MaskedTextBox txtConfirmarSenha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}