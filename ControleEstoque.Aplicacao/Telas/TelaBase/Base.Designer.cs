namespace Informatiz.ControleEstoque.Aplicacao.Telas.TelaBase
{
    partial class Base
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base));
            this.tlpTopo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.tlpTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTopo
            // 
            this.tlpTopo.ColumnCount = 1;
            this.tlpTopo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopo.Controls.Add(this.pnlMenu, 0, 0);
            this.tlpTopo.Controls.Add(this.pnlBase, 0, 1);
            this.tlpTopo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopo.Location = new System.Drawing.Point(0, 0);
            this.tlpTopo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopo.Name = "tlpTopo";
            this.tlpTopo.RowCount = 2;
            this.tlpTopo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpTopo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopo.Size = new System.Drawing.Size(1500, 1102);
            this.tlpTopo.TabIndex = 6;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1500, 130);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlBase
            // 
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(3, 133);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(1494, 966);
            this.pnlBase.TabIndex = 1;
            // 
            // Base
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1500, 1102);
            this.Controls.Add(this.tlpTopo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Base";
            this.Text = "Base";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Base_KeyDown);
            this.tlpTopo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTopo;
        private System.Windows.Forms.Panel pnlMenu;
        public System.Windows.Forms.Panel pnlBase;
    }
}