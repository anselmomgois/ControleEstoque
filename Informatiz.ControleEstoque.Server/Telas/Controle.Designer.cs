namespace Informatiz.ControleEstoque.Server.Telas
{
    partial class Controle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controle));
            this.ntfIgerenceServer = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnMenuPrincipal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlpExibirPainel = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpTrocarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpSair = new System.Windows.Forms.ToolStripMenuItem();
            this.tmpProcesso = new System.Windows.Forms.Timer(this.components);
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.tmpAtualizacaoDados = new System.Windows.Forms.Timer(this.components);
            this.tmpAtualizarProcessos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntfIgerenceServer
            // 
            this.ntfIgerenceServer.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfIgerenceServer.BalloonTipTitle = "I - GERENCE Server";
            this.ntfIgerenceServer.ContextMenuStrip = this.mnMenuPrincipal;
            this.ntfIgerenceServer.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIgerenceServer.Icon")));
            this.ntfIgerenceServer.Text = "I - GERENCE Server";
            this.ntfIgerenceServer.Visible = true;
            this.ntfIgerenceServer.BalloonTipClicked += new System.EventHandler(this.ntfIgerenceServer_BalloonTipClicked);
            this.ntfIgerenceServer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfIgerenceServer_MouseDoubleClick);
            // 
            // mnMenuPrincipal
            // 
            this.mnMenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlpExibirPainel,
            this.tmpAtualizarProcessos,
            this.tlpTrocarUsuario,
            this.tlpSair});
            this.mnMenuPrincipal.Name = "mnPrincipal";
            this.mnMenuPrincipal.Size = new System.Drawing.Size(206, 100);
            // 
            // tlpExibirPainel
            // 
            this.tlpExibirPainel.Name = "tlpExibirPainel";
            this.tlpExibirPainel.Size = new System.Drawing.Size(210, 24);
            this.tlpExibirPainel.Text = "Exibir Painel";
            this.tlpExibirPainel.Click += new System.EventHandler(this.tlpExibirPainel_Click);
            // 
            // tlpTrocarUsuario
            // 
            this.tlpTrocarUsuario.Name = "tlpTrocarUsuario";
            this.tlpTrocarUsuario.Size = new System.Drawing.Size(210, 24);
            this.tlpTrocarUsuario.Text = "Trocar de Usuário";
            this.tlpTrocarUsuario.Click += new System.EventHandler(this.tlpTrocarUsuario_Click);
            // 
            // tlpSair
            // 
            this.tlpSair.Name = "tlpSair";
            this.tlpSair.Size = new System.Drawing.Size(210, 24);
            this.tlpSair.Text = "Sair";
            this.tlpSair.Click += new System.EventHandler(this.tlpSair_Click);
            // 
            // tmpProcesso
            // 
            this.tmpProcesso.Interval = 1000;
            this.tmpProcesso.Tick += new System.EventHandler(this.tmpProcesso_Tick);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // tmpAtualizacaoDados
            // 
            this.tmpAtualizacaoDados.Interval = 100000;
            this.tmpAtualizacaoDados.Tick += new System.EventHandler(this.tmpAtualizacaoDados_Tick);
            // 
            // tmpAtualizarProcessos
            // 
            this.tmpAtualizarProcessos.Name = "tmpAtualizarProcessos";
            this.tmpAtualizarProcessos.Size = new System.Drawing.Size(210, 24);
            this.tmpAtualizarProcessos.Text = "Atualizar Processos";
            this.tmpAtualizarProcessos.Click += new System.EventHandler(this.tmpAtualizarProcessos_Click);
            // 
            // Controle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Controle";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle";
            this.mnMenuPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.NotifyIcon ntfIgerenceServer;
        private System.Windows.Forms.Timer tmpProcesso;
        private System.Windows.Forms.ContextMenuStrip mnMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tlpSair;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.Timer tmpAtualizacaoDados;
        private System.Windows.Forms.ToolStripMenuItem tlpExibirPainel;
        private System.Windows.Forms.ToolStripMenuItem tlpTrocarUsuario;
        private System.Windows.Forms.ToolStripMenuItem tmpAtualizarProcessos;
    }
}