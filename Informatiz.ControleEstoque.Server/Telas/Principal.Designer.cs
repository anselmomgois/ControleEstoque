namespace Informatiz.ControleEstoque.Server.Telas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.gpbClientes = new System.Windows.Forms.GroupBox();
            this.dgvCores = new System.Windows.Forms.DataGridView();
            this.tmpAtualizacao = new System.Windows.Forms.Timer(this.components);
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataInicializacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataUltimaExecucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataProximaExecucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErros = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExecucao = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbClientes
            // 
            this.gpbClientes.Controls.Add(this.dgvCores);
            this.gpbClientes.Location = new System.Drawing.Point(0, 0);
            this.gpbClientes.Margin = new System.Windows.Forms.Padding(4);
            this.gpbClientes.Name = "gpbClientes";
            this.gpbClientes.Padding = new System.Windows.Forms.Padding(4);
            this.gpbClientes.Size = new System.Drawing.Size(1157, 411);
            this.gpbClientes.TabIndex = 4;
            this.gpbClientes.TabStop = false;
            this.gpbClientes.Text = "Processos";
            // 
            // dgvCores
            // 
            this.dgvCores.AllowUserToAddRows = false;
            this.dgvCores.AllowUserToDeleteRows = false;
            this.dgvCores.AllowUserToOrderColumns = true;
            this.dgvCores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colProcesso,
            this.colDataInicializacao,
            this.colDataUltimaExecucao,
            this.colDataProximaExecucao,
            this.colErros,
            this.colExecucao});
            this.dgvCores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCores.Location = new System.Drawing.Point(4, 19);
            this.dgvCores.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCores.Name = "dgvCores";
            this.dgvCores.ReadOnly = true;
            this.dgvCores.Size = new System.Drawing.Size(1149, 388);
            this.dgvCores.TabIndex = 6;
            this.dgvCores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCores_CellContentClick);
            this.dgvCores.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCores_CellMouseMove);
            // 
            // tmpAtualizacao
            // 
            this.tmpAtualizacao.Interval = 5000;
            this.tmpAtualizacao.Tick += new System.EventHandler(this.tmpAtualizacao_Tick);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colProcesso
            // 
            this.colProcesso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProcesso.FillWeight = 150F;
            this.colProcesso.HeaderText = "Processo";
            this.colProcesso.Name = "colProcesso";
            this.colProcesso.ReadOnly = true;
            // 
            // colDataInicializacao
            // 
            this.colDataInicializacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDataInicializacao.FillWeight = 150F;
            this.colDataInicializacao.HeaderText = "Inicialização";
            this.colDataInicializacao.Name = "colDataInicializacao";
            this.colDataInicializacao.ReadOnly = true;
            this.colDataInicializacao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDataInicializacao.Width = 150;
            // 
            // colDataUltimaExecucao
            // 
            this.colDataUltimaExecucao.FillWeight = 150F;
            this.colDataUltimaExecucao.HeaderText = "Ultima Execução";
            this.colDataUltimaExecucao.Name = "colDataUltimaExecucao";
            this.colDataUltimaExecucao.ReadOnly = true;
            this.colDataUltimaExecucao.Width = 150;
            // 
            // colDataProximaExecucao
            // 
            this.colDataProximaExecucao.FillWeight = 150F;
            this.colDataProximaExecucao.HeaderText = "Proxima Execução";
            this.colDataProximaExecucao.Name = "colDataProximaExecucao";
            this.colDataProximaExecucao.ReadOnly = true;
            this.colDataProximaExecucao.Width = 150;
            // 
            // colErros
            // 
            this.colErros.HeaderText = "Log Execução";
            this.colErros.Image = global::Informatiz.ControleEstoque.Server.Properties.Resources.exec;
            this.colErros.Name = "colErros";
            this.colErros.ReadOnly = true;
            // 
            // colExecucao
            // 
            this.colExecucao.HeaderText = "Em Execução";
            this.colExecucao.Name = "colExecucao";
            this.colExecucao.ReadOnly = true;
            this.colExecucao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Principal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1163, 547);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "I - GERENCE Server";
            this.gpbClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbClientes;
        private System.Windows.Forms.DataGridView dgvCores;
        private System.Windows.Forms.Timer tmpAtualizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataInicializacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataUltimaExecucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataProximaExecucao;
        private System.Windows.Forms.DataGridViewImageColumn colErros;
        private System.Windows.Forms.DataGridViewImageColumn colExecucao;
    }
}