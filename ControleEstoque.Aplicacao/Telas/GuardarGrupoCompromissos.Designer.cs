namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarGrupoCompromissos
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
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.dgvGrupoProduto = new System.Windows.Forms.DataGridView();
            this.gpbSubGrupos = new System.Windows.Forms.GroupBox();
            this.dgvPerguntas = new System.Windows.Forms.DataGridView();
            this.colIdentificadorPerguntaProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPergunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarPergunta = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluirPergunta = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpbPerguntas = new System.Windows.Forms.GroupBox();
            this.colIdentificadorProvisorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoProduto)).BeginInit();
            this.gpbSubGrupos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerguntas)).BeginInit();
            this.gpbPerguntas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(18, 19);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(100, 17);
            this.lblNome.TabIndex = 14;
            this.lblNome.Text = "Nome do Nivel";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(145, 14);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(480, 22);
            this.txtNome.TabIndex = 1;
            // 
            // dgvGrupoProduto
            // 
            this.dgvGrupoProduto.AllowUserToAddRows = false;
            this.dgvGrupoProduto.AllowUserToDeleteRows = false;
            this.dgvGrupoProduto.AllowUserToOrderColumns = true;
            this.dgvGrupoProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupoProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificadorProvisorio,
            this.colIdCor,
            this.colDescricao,
            this.colEditar,
            this.colExcluir});
            this.dgvGrupoProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrupoProduto.Location = new System.Drawing.Point(4, 19);
            this.dgvGrupoProduto.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrupoProduto.Name = "dgvGrupoProduto";
            this.dgvGrupoProduto.ReadOnly = true;
            this.dgvGrupoProduto.RowHeadersVisible = false;
            this.dgvGrupoProduto.Size = new System.Drawing.Size(1184, 256);
            this.dgvGrupoProduto.TabIndex = 5;
            this.dgvGrupoProduto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupoProduto_CellContentClick);
            this.dgvGrupoProduto.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrupoProduto_CellMouseMove);
            // 
            // gpbSubGrupos
            // 
            this.gpbSubGrupos.Controls.Add(this.dgvGrupoProduto);
            this.gpbSubGrupos.Location = new System.Drawing.Point(20, 200);
            this.gpbSubGrupos.Margin = new System.Windows.Forms.Padding(4);
            this.gpbSubGrupos.Name = "gpbSubGrupos";
            this.gpbSubGrupos.Padding = new System.Windows.Forms.Padding(4);
            this.gpbSubGrupos.Size = new System.Drawing.Size(1192, 279);
            this.gpbSubGrupos.TabIndex = 4;
            this.gpbSubGrupos.TabStop = false;
            this.gpbSubGrupos.Text = "Sub Niveis";
            // 
            // dgvPerguntas
            // 
            this.dgvPerguntas.AllowUserToAddRows = false;
            this.dgvPerguntas.AllowUserToDeleteRows = false;
            this.dgvPerguntas.AllowUserToOrderColumns = true;
            this.dgvPerguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificadorPerguntaProv,
            this.colIdentificador,
            this.colPergunta,
            this.colEditarPergunta,
            this.colExcluirPergunta});
            this.dgvPerguntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerguntas.Location = new System.Drawing.Point(4, 19);
            this.dgvPerguntas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPerguntas.Name = "dgvPerguntas";
            this.dgvPerguntas.ReadOnly = true;
            this.dgvPerguntas.RowHeadersVisible = false;
            this.dgvPerguntas.Size = new System.Drawing.Size(1176, 133);
            this.dgvPerguntas.TabIndex = 3;
            this.dgvPerguntas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerguntas_CellContentClick);
            this.dgvPerguntas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPerguntas_CellMouseMove);
            // 
            // colIdentificadorPerguntaProv
            // 
            this.colIdentificadorPerguntaProv.HeaderText = "Column1";
            this.colIdentificadorPerguntaProv.Name = "colIdentificadorPerguntaProv";
            this.colIdentificadorPerguntaProv.ReadOnly = true;
            this.colIdentificadorPerguntaProv.Visible = false;
            // 
            // colIdentificador
            // 
            this.colIdentificador.HeaderText = "Column1";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            this.colIdentificador.Visible = false;
            // 
            // colPergunta
            // 
            this.colPergunta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPergunta.HeaderText = "Pergunta";
            this.colPergunta.Name = "colPergunta";
            this.colPergunta.ReadOnly = true;
            this.colPergunta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEditarPergunta
            // 
            this.colEditarPergunta.HeaderText = "Editar";
            this.colEditarPergunta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditarPergunta.Name = "colEditarPergunta";
            this.colEditarPergunta.ReadOnly = true;
            this.colEditarPergunta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colExcluirPergunta
            // 
            this.colExcluirPergunta.HeaderText = "Excluir";
            this.colExcluirPergunta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluirPergunta.Name = "colExcluirPergunta";
            this.colExcluirPergunta.ReadOnly = true;
            this.colExcluirPergunta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gpbPerguntas
            // 
            this.gpbPerguntas.Controls.Add(this.dgvPerguntas);
            this.gpbPerguntas.Location = new System.Drawing.Point(21, 40);
            this.gpbPerguntas.Margin = new System.Windows.Forms.Padding(4);
            this.gpbPerguntas.Name = "gpbPerguntas";
            this.gpbPerguntas.Padding = new System.Windows.Forms.Padding(4);
            this.gpbPerguntas.Size = new System.Drawing.Size(1184, 156);
            this.gpbPerguntas.TabIndex = 2;
            this.gpbPerguntas.TabStop = false;
            this.gpbPerguntas.Text = "Perguntas";
            // 
            // colIdentificadorProvisorio
            // 
            this.colIdentificadorProvisorio.HeaderText = "Column1";
            this.colIdentificadorProvisorio.Name = "colIdentificadorProvisorio";
            this.colIdentificadorProvisorio.ReadOnly = true;
            this.colIdentificadorProvisorio.Visible = false;
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GuardarGrupoCompromissos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1228, 623);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "GuardarGrupoCompromissos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nivel de Atendimento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuardarGrupoCompromissos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoProduto)).EndInit();
            this.gpbSubGrupos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerguntas)).EndInit();
            this.gpbPerguntas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.DataGridView dgvGrupoProduto;
        private System.Windows.Forms.GroupBox gpbSubGrupos;
        private System.Windows.Forms.DataGridView dgvPerguntas;
        private System.Windows.Forms.GroupBox gpbPerguntas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorPerguntaProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPergunta;
        private System.Windows.Forms.DataGridViewImageColumn colEditarPergunta;
        private System.Windows.Forms.DataGridViewImageColumn colExcluirPergunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorProvisorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}