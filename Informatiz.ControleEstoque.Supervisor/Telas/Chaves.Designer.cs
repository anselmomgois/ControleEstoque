namespace Informatiz.ControleEstoque.Supervisor
{
    partial class Chaves
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chaves));
            this.dgvChaves = new System.Windows.Forms.DataGridView();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSessoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Validade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSessoesInfinitas = new System.Windows.Forms.DataGridViewImageColumn();
            this.colValidadeInfinita = new System.Windows.Forms.DataGridViewImageColumn();
            this.colImprimir = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChaves)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChaves
            // 
            this.dgvChaves.AllowUserToAddRows = false;
            this.dgvChaves.AllowUserToDeleteRows = false;
            this.dgvChaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificador,
            this.colChave,
            this.colSessoes,
            this.Validade,
            this.ColSessoesInfinitas,
            this.colValidadeInfinita,
            this.colImprimir});
            this.dgvChaves.Location = new System.Drawing.Point(12, 95);
            this.dgvChaves.Name = "dgvChaves";
            this.dgvChaves.ReadOnly = true;
            this.dgvChaves.Size = new System.Drawing.Size(924, 326);
            this.dgvChaves.TabIndex = 0;
            this.dgvChaves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChaves_CellContentClick);
            this.dgvChaves.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvChaves_CellMouseMove);
            // 
            // colIdentificador
            // 
            this.colIdentificador.HeaderText = "Column1";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            this.colIdentificador.Visible = false;
            // 
            // colChave
            // 
            this.colChave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChave.HeaderText = "Chave";
            this.colChave.Name = "colChave";
            this.colChave.ReadOnly = true;
            this.colChave.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colSessoes
            // 
            this.colSessoes.HeaderText = "Sessoes";
            this.colSessoes.Name = "colSessoes";
            this.colSessoes.ReadOnly = true;
            this.colSessoes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Validade
            // 
            this.Validade.HeaderText = "Validade";
            this.Validade.Name = "Validade";
            this.Validade.ReadOnly = true;
            this.Validade.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColSessoesInfinitas
            // 
            this.ColSessoesInfinitas.HeaderText = "Sessões Infinitas";
            this.ColSessoesInfinitas.Name = "ColSessoesInfinitas";
            this.ColSessoesInfinitas.ReadOnly = true;
            this.ColSessoesInfinitas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colValidadeInfinita
            // 
            this.colValidadeInfinita.HeaderText = "Validade Infinita";
            this.colValidadeInfinita.Name = "colValidadeInfinita";
            this.colValidadeInfinita.ReadOnly = true;
            this.colValidadeInfinita.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colImprimir
            // 
            this.colImprimir.HeaderText = "Imprimir";
            this.colImprimir.Image = global::Informatiz.ControleEstoque.Supervisor.Properties.Resources.printer_red;
            this.colImprimir.Name = "colImprimir";
            this.colImprimir.ReadOnly = true;
            this.colImprimir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Chaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 431);
            this.Controls.Add(this.dgvChaves);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chaves";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chaves";
            this.Controls.SetChildIndex(this.dgvChaves, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChaves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSessoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Validade;
        private System.Windows.Forms.DataGridViewImageColumn ColSessoesInfinitas;
        private System.Windows.Forms.DataGridViewImageColumn colValidadeInfinita;
        private System.Windows.Forms.DataGridViewImageColumn colImprimir;
    }
}