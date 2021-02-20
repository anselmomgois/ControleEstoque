namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarGrupoProdutos
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.gpbSubGrupos = new System.Windows.Forms.GroupBox();
            this.dgvGrupoProduto = new System.Windows.Forms.DataGridView();
            this.colIdCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificadorProvisorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpbSubGrupos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(144, 4);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(480, 22);
            this.txtNome.TabIndex = 8;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(17, 9);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(109, 17);
            this.lblNome.TabIndex = 7;
            this.lblNome.Text = "Nome do Grupo";
            // 
            // gpbSubGrupos
            // 
            this.gpbSubGrupos.Controls.Add(this.dgvGrupoProduto);
            this.gpbSubGrupos.Location = new System.Drawing.Point(11, 30);
            this.gpbSubGrupos.Margin = new System.Windows.Forms.Padding(4);
            this.gpbSubGrupos.Name = "gpbSubGrupos";
            this.gpbSubGrupos.Padding = new System.Windows.Forms.Padding(4);
            this.gpbSubGrupos.Size = new System.Drawing.Size(1192, 279);
            this.gpbSubGrupos.TabIndex = 9;
            this.gpbSubGrupos.TabStop = false;
            this.gpbSubGrupos.Text = "Sub Grupos";
            // 
            // dgvGrupoProduto
            // 
            this.dgvGrupoProduto.AllowUserToAddRows = false;
            this.dgvGrupoProduto.AllowUserToDeleteRows = false;
            this.dgvGrupoProduto.AllowUserToOrderColumns = true;
            this.dgvGrupoProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupoProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCor,
            this.colIdentificadorProvisorio,
            this.colDescricao,
            this.colEditar,
            this.colExcluir});
            this.dgvGrupoProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrupoProduto.Location = new System.Drawing.Point(4, 19);
            this.dgvGrupoProduto.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGrupoProduto.Name = "dgvGrupoProduto";
            this.dgvGrupoProduto.ReadOnly = true;
            this.dgvGrupoProduto.Size = new System.Drawing.Size(1184, 256);
            this.dgvGrupoProduto.TabIndex = 5;
            this.dgvGrupoProduto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupoProduto_CellContentClick);
            this.dgvGrupoProduto.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrupoProduto_CellMouseMove);
            // 
            // colIdCor
            // 
            this.colIdCor.HeaderText = "Column1";
            this.colIdCor.Name = "colIdCor";
            this.colIdCor.ReadOnly = true;
            this.colIdCor.Visible = false;
            // 
            // colIdentificadorProvisorio
            // 
            this.colIdentificadorProvisorio.HeaderText = "Column1";
            this.colIdentificadorProvisorio.Name = "colIdentificadorProvisorio";
            this.colIdentificadorProvisorio.ReadOnly = true;
            this.colIdentificadorProvisorio.Visible = false;
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
            // GuardarGrupoProdutos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1213, 451);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "GuardarGrupoProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grupo de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuardarGrupoProdutos_FormClosing);
            this.gpbSubGrupos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupoProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox gpbSubGrupos;
        private System.Windows.Forms.DataGridView dgvGrupoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorProvisorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
    }
}