namespace Informatiz.ControleEstoque.Supervisor
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.mnPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmGerarChave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChavesDisponiveis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSair = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpRodape = new System.Windows.Forms.TableLayoutPanel();
            this.imgCadeado = new System.Windows.Forms.PictureBox();
            this.pnlImagem = new System.Windows.Forms.Panel();
            this.tlpPrincipal.SuspendLayout();
            this.mnPrincipal.SuspendLayout();
            this.tlpRodape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeado)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.mnPrincipal, 0, 0);
            this.tlpPrincipal.Controls.Add(this.tlpRodape, 0, 2);
            this.tlpPrincipal.Controls.Add(this.pnlImagem, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.ForeColor = System.Drawing.Color.Red;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 80);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpPrincipal.Size = new System.Drawing.Size(1007, 430);
            this.tlpPrincipal.TabIndex = 4;
            // 
            // mnPrincipal
            // 
            this.mnPrincipal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mnPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mnPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGerarChave,
            this.tsmChavesDisponiveis,
            this.tsmSair});
            this.mnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnPrincipal.Name = "mnPrincipal";
            this.mnPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnPrincipal.ShowItemToolTips = true;
            this.mnPrincipal.Size = new System.Drawing.Size(1007, 25);
            this.mnPrincipal.TabIndex = 1;
            this.mnPrincipal.Text = "mnPrincipal";
            // 
            // tsmGerarChave
            // 
            this.tsmGerarChave.Image = global::Informatiz.ControleEstoque.Supervisor.Properties.Resources.group_key;
            this.tsmGerarChave.Name = "tsmGerarChave";
            this.tsmGerarChave.Size = new System.Drawing.Size(99, 21);
            this.tsmGerarChave.Text = "Gerar Chave";
            this.tsmGerarChave.Click += new System.EventHandler(this.tsmGerarChave_Click);
            // 
            // tsmChavesDisponiveis
            // 
            this.tsmChavesDisponiveis.Image = global::Informatiz.ControleEstoque.Supervisor.Properties.Resources.key;
            this.tsmChavesDisponiveis.Name = "tsmChavesDisponiveis";
            this.tsmChavesDisponiveis.Size = new System.Drawing.Size(136, 21);
            this.tsmChavesDisponiveis.Text = "Chaves Disponiveis";
            this.tsmChavesDisponiveis.Click += new System.EventHandler(this.tsmChavesDisponiveis_Click);
            // 
            // tsmSair
            // 
            this.tsmSair.Image = global::Informatiz.ControleEstoque.Supervisor.Properties.Resources.cancel;
            this.tsmSair.Name = "tsmSair";
            this.tsmSair.Size = new System.Drawing.Size(54, 21);
            this.tsmSair.Text = "Sair";
            this.tsmSair.Click += new System.EventHandler(this.tsmSair_Click);
            // 
            // tlpRodape
            // 
            this.tlpRodape.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tlpRodape.ColumnCount = 6;
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpRodape.Controls.Add(this.imgCadeado, 4, 0);
            this.tlpRodape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRodape.Location = new System.Drawing.Point(3, 398);
            this.tlpRodape.Name = "tlpRodape";
            this.tlpRodape.RowCount = 1;
            this.tlpRodape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRodape.Size = new System.Drawing.Size(1001, 29);
            this.tlpRodape.TabIndex = 4;
            // 
            // imgCadeado
            // 
            this.imgCadeado.Location = new System.Drawing.Point(824, 3);
            this.imgCadeado.Name = "imgCadeado";
            this.imgCadeado.Size = new System.Drawing.Size(24, 22);
            this.imgCadeado.TabIndex = 5;
            this.imgCadeado.TabStop = false;
            // 
            // pnlImagem
            // 
            this.pnlImagem.BackgroundImage = global::Informatiz.ControleEstoque.Supervisor.Properties.Resources.imagem_sistema;
            this.pnlImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagem.Location = new System.Drawing.Point(3, 28);
            this.pnlImagem.Name = "pnlImagem";
            this.pnlImagem.Size = new System.Drawing.Size(1001, 364);
            this.pnlImagem.TabIndex = 5;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1007, 510);
            this.Controls.Add(this.tlpPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.tlpPrincipal, 0);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.mnPrincipal.ResumeLayout(false);
            this.mnPrincipal.PerformLayout();
            this.tlpRodape.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.MenuStrip mnPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmGerarChave;
        private System.Windows.Forms.ToolStripMenuItem tsmChavesDisponiveis;
        private System.Windows.Forms.TableLayoutPanel tlpRodape;
        private System.Windows.Forms.PictureBox imgCadeado;
        private System.Windows.Forms.Panel pnlImagem;
        private System.Windows.Forms.ToolStripMenuItem tsmSair;

    }
}