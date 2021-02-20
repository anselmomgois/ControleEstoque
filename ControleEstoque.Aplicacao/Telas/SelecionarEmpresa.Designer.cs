namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class SelecionarEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelecionarEmpresa));
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.ddlEmpresa = new System.Windows.Forms.ComboBox();
            this.ddlFilial = new System.Windows.Forms.ComboBox();
            this.lblFilial = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Location = new System.Drawing.Point(4, 9);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(64, 17);
            this.lblEmpresa.TabIndex = 8;
            this.lblEmpresa.Text = "Empresa";
            // 
            // ddlEmpresa
            // 
            this.ddlEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlEmpresa.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ddlEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlEmpresa.FormattingEnabled = true;
            this.ddlEmpresa.Location = new System.Drawing.Point(104, 4);
            this.ddlEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.ddlEmpresa.Name = "ddlEmpresa";
            this.ddlEmpresa.Size = new System.Drawing.Size(527, 24);
            this.ddlEmpresa.TabIndex = 9;
            this.ddlEmpresa.SelectedIndexChanged += new System.EventHandler(this.ddlEmpresa_SelectedIndexChanged);
            // 
            // ddlFilial
            // 
            this.ddlFilial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlFilial.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ddlFilial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFilial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlFilial.FormattingEnabled = true;
            this.ddlFilial.Location = new System.Drawing.Point(104, 34);
            this.ddlFilial.Margin = new System.Windows.Forms.Padding(4);
            this.ddlFilial.Name = "ddlFilial";
            this.ddlFilial.Size = new System.Drawing.Size(527, 24);
            this.ddlFilial.TabIndex = 11;
            // 
            // lblFilial
            // 
            this.lblFilial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilial.AutoSize = true;
            this.lblFilial.BackColor = System.Drawing.Color.Transparent;
            this.lblFilial.Location = new System.Drawing.Point(4, 43);
            this.lblFilial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(36, 17);
            this.lblFilial.TabIndex = 10;
            this.lblFilial.Text = "Filial";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lblEmpresa, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblFilial, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.ddlEmpresa, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.ddlFilial, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(661, 112);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // SelecionarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(667, 248);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelecionarEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelecionarEmpresa";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox ddlEmpresa;
        private System.Windows.Forms.ComboBox ddlFilial;
        private System.Windows.Forms.Label lblFilial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}