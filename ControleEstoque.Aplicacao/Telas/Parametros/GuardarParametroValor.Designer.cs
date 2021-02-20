namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarParametroValor
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
            this.tlpGeral = new System.Windows.Forms.TableLayoutPanel();
            this.tbcGrupoParametros = new System.Windows.Forms.TabControl();
            this.tlpGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeral
            // 
            this.tlpGeral.ColumnCount = 1;
            this.tlpGeral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeral.Controls.Add(this.tbcGrupoParametros, 0, 0);
            this.tlpGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeral.Name = "tlpGeral";
            this.tlpGeral.RowCount = 1;
            this.tlpGeral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.10054F));
            this.tlpGeral.Size = new System.Drawing.Size(1030, 449);
            this.tlpGeral.TabIndex = 7;
            // 
            // tbcGrupoParametros
            // 
            this.tbcGrupoParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcGrupoParametros.Location = new System.Drawing.Point(3, 3);
            this.tbcGrupoParametros.Name = "tbcGrupoParametros";
            this.tbcGrupoParametros.SelectedIndex = 0;
            this.tbcGrupoParametros.Size = new System.Drawing.Size(1024, 443);
            this.tbcGrupoParametros.TabIndex = 0;
            // 
            // GuardarParametroValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1034, 591);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "GuardarParametroValor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Guardar Valores Parâmetros";
            this.tlpGeral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.pnlBase.Controls.Add(tlpGeral);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeral;
        private System.Windows.Forms.TabControl tbcGrupoParametros;
    }
}