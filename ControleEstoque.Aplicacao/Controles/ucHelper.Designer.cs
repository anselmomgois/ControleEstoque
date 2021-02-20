namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    partial class ucHelper
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
            this.gpbDados = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.gpbDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDados
            // 
            this.gpbDados.Controls.Add(this.btnModificar);
            this.gpbDados.Controls.Add(this.btnLimpar);
            this.gpbDados.Controls.Add(this.btnInserir);
            this.gpbDados.Controls.Add(this.lblDescricao);
            this.gpbDados.Controls.Add(this.lblCodigo);
            this.gpbDados.Controls.Add(this.txtDescricao);
            this.gpbDados.Controls.Add(this.btnPesquisar);
            this.gpbDados.Controls.Add(this.txtCodigo);
            this.gpbDados.Location = new System.Drawing.Point(5, 5);
            this.gpbDados.Margin = new System.Windows.Forms.Padding(4);
            this.gpbDados.Name = "gpbDados";
            this.gpbDados.Padding = new System.Windows.Forms.Padding(4);
            this.gpbDados.Size = new System.Drawing.Size(624, 87);
            this.gpbDados.TabIndex = 0;
            this.gpbDados.TabStop = false;
            this.gpbDados.Text = "Dados";
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.btnModificar.Location = new System.Drawing.Point(523, 50);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(45, 28);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.gnome_edit_clear;
            this.btnLimpar.Location = new System.Drawing.Point(571, 50);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(45, 28);
            this.btnLimpar.TabIndex = 6;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.tab_new_r;
            this.btnInserir.Location = new System.Drawing.Point(476, 50);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(4);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(45, 28);
            this.btnInserir.TabIndex = 5;
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(9, 63);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(71, 17);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(9, 32);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(91, 54);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(328, 22);
            this.txtDescricao.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.search_16;
            this.btnPesquisar.Location = new System.Drawing.Point(428, 50);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(45, 28);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(91, 23);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(132, 22);
            this.txtCodigo.TabIndex = 0;
            // 
            // ucHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.gpbDados);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucHelper";
            this.Size = new System.Drawing.Size(633, 101);
            this.gpbDados.ResumeLayout(false);
            this.gpbDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDados;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnModificar;
    }
}
