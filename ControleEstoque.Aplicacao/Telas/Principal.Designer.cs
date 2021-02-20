namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class Principal : TelaBase.BaseCE
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tlpAtualizarSessao = new System.Windows.Forms.Timer(this.components);
            this.pnlImagem = new System.Windows.Forms.Panel();
            this.pnlNotificacao = new System.Windows.Forms.Panel();
            this.tlpRodape = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.psbAtualizar = new System.Windows.Forms.ProgressBar();
            this.lblDesFilial = new System.Windows.Forms.Label();
            this.lblFilial = new System.Windows.Forms.Label();
            this.imgCadeado = new System.Windows.Forms.PictureBox();
            this.lblAcesso = new System.Windows.Forms.Label();
            this.lblUsuarioValor = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblVersaoPreencher = new System.Windows.Forms.Label();
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlImagem.SuspendLayout();
            this.tlpRodape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeado)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAtualizarSessao
            // 
            this.tlpAtualizarSessao.Interval = 50000;
            this.tlpAtualizarSessao.Tick += new System.EventHandler(this.tlpAtualizarSessao_Tick);
            // 
            // pnlImagem
            // 
            this.pnlImagem.BackgroundImage = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.imagem_sistema;
            this.pnlImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlImagem.Controls.Add(this.pnlNotificacao);
            this.pnlImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagem.Location = new System.Drawing.Point(4, 4);
            this.pnlImagem.Margin = new System.Windows.Forms.Padding(4);
            this.pnlImagem.Name = "pnlImagem";
            this.pnlImagem.Size = new System.Drawing.Size(1142, 439);
            this.pnlImagem.TabIndex = 5;
            // 
            // pnlNotificacao
            // 
            this.pnlNotificacao.BackColor = System.Drawing.Color.Transparent;
            this.pnlNotificacao.Location = new System.Drawing.Point(4, 3);
            this.pnlNotificacao.Name = "pnlNotificacao";
            this.pnlNotificacao.Size = new System.Drawing.Size(716, 370);
            this.pnlNotificacao.TabIndex = 0;
            // 
            // tlpRodape
            // 
            this.tlpRodape.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tlpRodape.ColumnCount = 10;
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRodape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpRodape.Controls.Add(this.label1, 2, 0);
            this.tlpRodape.Controls.Add(this.psbAtualizar, 0, 0);
            this.tlpRodape.Controls.Add(this.lblDesFilial, 4, 0);
            this.tlpRodape.Controls.Add(this.lblFilial, 5, 0);
            this.tlpRodape.Controls.Add(this.imgCadeado, 8, 0);
            this.tlpRodape.Controls.Add(this.lblAcesso, 9, 0);
            this.tlpRodape.Controls.Add(this.lblUsuarioValor, 7, 0);
            this.tlpRodape.Controls.Add(this.lblUsuario, 6, 0);
            this.tlpRodape.Controls.Add(this.lblEmpresa, 3, 0);
            this.tlpRodape.Controls.Add(this.lblVersaoPreencher, 1, 0);
            this.tlpRodape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRodape.Location = new System.Drawing.Point(4, 451);
            this.tlpRodape.Margin = new System.Windows.Forms.Padding(4);
            this.tlpRodape.Name = "tlpRodape";
            this.tlpRodape.RowCount = 1;
            this.tlpRodape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRodape.Size = new System.Drawing.Size(1142, 35);
            this.tlpRodape.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Empresa:";
            // 
            // psbAtualizar
            // 
            this.psbAtualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.psbAtualizar.Location = new System.Drawing.Point(4, 4);
            this.psbAtualizar.Margin = new System.Windows.Forms.Padding(4);
            this.psbAtualizar.Name = "psbAtualizar";
            this.psbAtualizar.Size = new System.Drawing.Size(1, 27);
            this.psbAtualizar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.psbAtualizar.TabIndex = 1;
            this.psbAtualizar.Visible = false;
            // 
            // lblDesFilial
            // 
            this.lblDesFilial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDesFilial.AutoSize = true;
            this.lblDesFilial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesFilial.ForeColor = System.Drawing.Color.Navy;
            this.lblDesFilial.Location = new System.Drawing.Point(485, 9);
            this.lblDesFilial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesFilial.Name = "lblDesFilial";
            this.lblDesFilial.Size = new System.Drawing.Size(47, 17);
            this.lblDesFilial.TabIndex = 7;
            this.lblDesFilial.Text = "Filial:";
            // 
            // lblFilial
            // 
            this.lblFilial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilial.AutoSize = true;
            this.lblFilial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilial.ForeColor = System.Drawing.Color.Navy;
            this.lblFilial.Location = new System.Drawing.Point(540, 9);
            this.lblFilial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(52, 17);
            this.lblFilial.TabIndex = 6;
            this.lblFilial.Text = "Matriz";
            // 
            // imgCadeado
            // 
            this.imgCadeado.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.cadeado_fechado;
            this.imgCadeado.Location = new System.Drawing.Point(906, 4);
            this.imgCadeado.Margin = new System.Windows.Forms.Padding(4);
            this.imgCadeado.Name = "imgCadeado";
            this.imgCadeado.Size = new System.Drawing.Size(32, 27);
            this.imgCadeado.TabIndex = 5;
            this.imgCadeado.TabStop = false;
            // 
            // lblAcesso
            // 
            this.lblAcesso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAcesso.AutoSize = true;
            this.lblAcesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcesso.ForeColor = System.Drawing.Color.Navy;
            this.lblAcesso.Location = new System.Drawing.Point(981, 9);
            this.lblAcesso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcesso.Name = "lblAcesso";
            this.lblAcesso.Size = new System.Drawing.Size(122, 17);
            this.lblAcesso.TabIndex = 2;
            this.lblAcesso.Text = "Acesso Restrito";
            // 
            // lblUsuarioValor
            // 
            this.lblUsuarioValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsuarioValor.AutoSize = true;
            this.lblUsuarioValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioValor.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuarioValor.Location = new System.Drawing.Point(773, 9);
            this.lblUsuarioValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioValor.Name = "lblUsuarioValor";
            this.lblUsuarioValor.Size = new System.Drawing.Size(69, 17);
            this.lblUsuarioValor.TabIndex = 1;
            this.lblUsuarioValor.Text = "Anselmo";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuario.Location = new System.Drawing.Point(696, 9);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(69, 17);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.Color.Navy;
            this.lblEmpresa.Location = new System.Drawing.Point(340, 9);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(71, 17);
            this.lblEmpresa.TabIndex = 8;
            this.lblEmpresa.Text = "Empresa";
            // 
            // lblVersaoPreencher
            // 
            this.lblVersaoPreencher.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVersaoPreencher.AutoSize = true;
            this.lblVersaoPreencher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersaoPreencher.ForeColor = System.Drawing.Color.Navy;
            this.lblVersaoPreencher.Location = new System.Drawing.Point(232, 9);
            this.lblVersaoPreencher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersaoPreencher.Name = "lblVersaoPreencher";
            this.lblVersaoPreencher.Size = new System.Drawing.Size(0, 17);
            this.lblVersaoPreencher.TabIndex = 11;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(11, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.miniToolStrip.ShowItemToolTips = true;
            this.miniToolStrip.Size = new System.Drawing.Size(571, 31);
            this.miniToolStrip.TabIndex = 1;
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.tlpRodape, 0, 1);
            this.tlpPrincipal.Controls.Add(this.pnlImagem, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.ForeColor = System.Drawing.Color.Red;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPrincipal.Size = new System.Drawing.Size(1150, 490);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1156, 646);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.miniToolStrip;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Controle Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.pnlImagem.ResumeLayout(false);
            this.tlpRodape.ResumeLayout(false);
            this.tlpRodape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCadeado)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(tlpPrincipal);

        }

        #endregion
        private System.Windows.Forms.Timer tlpAtualizarSessao;
        private System.Windows.Forms.Panel pnlImagem;
        private System.Windows.Forms.Panel pnlNotificacao;
        private System.Windows.Forms.TableLayoutPanel tlpRodape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar psbAtualizar;
        private System.Windows.Forms.Label lblDesFilial;
        private System.Windows.Forms.Label lblFilial;
        private System.Windows.Forms.PictureBox imgCadeado;
        private System.Windows.Forms.Label lblAcesso;
        private System.Windows.Forms.Label lblUsuarioValor;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblVersaoPreencher;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
    }
}