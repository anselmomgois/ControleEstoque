namespace Informatiz.ControleEstoque.Server.Controles
{
    partial class UcNotificacao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ppNotificacao = new NotificationWindow.PopupNotifier();
            this.tmpTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ppNotificacao
            // 
            this.ppNotificacao.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ppNotificacao.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.ppNotificacao.ContentText = null;
            this.ppNotificacao.GradientPower = 300;
            this.ppNotificacao.HeaderColor = System.Drawing.Color.White;
            this.ppNotificacao.HeaderHeight = 20;
            this.ppNotificacao.Image = null;
            this.ppNotificacao.OptionsMenu = null;
            this.ppNotificacao.Size = new System.Drawing.Size(400, 100);
            this.ppNotificacao.TitleColor = System.Drawing.Color.White;
            this.ppNotificacao.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ppNotificacao.TitleText = null;
            // 
            // tmpTimer
            // 
            this.tmpTimer.Tick += new System.EventHandler(this.tmpTimer_Tick);
            // 
            // UcNotificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcNotificacao";
            this.Size = new System.Drawing.Size(403, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private NotificationWindow.PopupNotifier ppNotificacao;
        private System.Windows.Forms.Timer tmpTimer;
    }
}
