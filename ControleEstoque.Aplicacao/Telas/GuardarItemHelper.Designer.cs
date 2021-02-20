namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarItemHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarItemHelper));
            this.txtItemFilho = new System.Windows.Forms.TextBox();
            this.txtItemPai = new System.Windows.Forms.TextBox();
            this.lblItemFilho = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.tlpControles = new System.Windows.Forms.TableLayoutPanel();
            this.tlpControlesTexto = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDDD = new System.Windows.Forms.TextBox();
            this.lblIbge = new System.Windows.Forms.Label();
            this.txtIbge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.tlpLabelPai = new System.Windows.Forms.TableLayoutPanel();
            this.lblItemPai = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlControles.SuspendLayout();
            this.tlpControles.SuspendLayout();
            this.tlpControlesTexto.SuspendLayout();
            this.tlpLabelPai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtItemFilho
            // 
            this.txtItemFilho.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtItemFilho.Enabled = false;
            this.txtItemFilho.Location = new System.Drawing.Point(137, 4);
            this.txtItemFilho.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemFilho.Name = "txtItemFilho";
            this.txtItemFilho.Size = new System.Drawing.Size(672, 22);
            this.txtItemFilho.TabIndex = 3;
            // 
            // txtItemPai
            // 
            this.txtItemPai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtItemPai.Enabled = false;
            this.txtItemPai.Location = new System.Drawing.Point(137, 6);
            this.txtItemPai.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemPai.Name = "txtItemPai";
            this.txtItemPai.Size = new System.Drawing.Size(672, 22);
            this.txtItemPai.TabIndex = 1;
            // 
            // lblItemFilho
            // 
            this.lblItemFilho.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemFilho.AutoSize = true;
            this.lblItemFilho.Location = new System.Drawing.Point(58, 5);
            this.lblItemFilho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemFilho.Name = "lblItemFilho";
            this.lblItemFilho.Size = new System.Drawing.Size(71, 17);
            this.lblItemFilho.TabIndex = 1;
            this.lblItemFilho.Text = "Descrição";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.tlpControles);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControles.Location = new System.Drawing.Point(4, 4);
            this.pnlControles.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(989, 443);
            this.pnlControles.TabIndex = 1;
            // 
            // tlpControles
            // 
            this.tlpControles.ColumnCount = 1;
            this.tlpControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControles.Controls.Add(this.tlpControlesTexto, 0, 2);
            this.tlpControles.Controls.Add(this.tlpLabelPai, 0, 0);
            this.tlpControles.Controls.Add(this.dgvItems, 0, 1);
            this.tlpControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControles.Location = new System.Drawing.Point(0, 0);
            this.tlpControles.Margin = new System.Windows.Forms.Padding(4);
            this.tlpControles.Name = "tlpControles";
            this.tlpControles.RowCount = 3;
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tlpControles.Size = new System.Drawing.Size(989, 443);
            this.tlpControles.TabIndex = 7;
            // 
            // tlpControlesTexto
            // 
            this.tlpControlesTexto.ColumnCount = 2;
            this.tlpControlesTexto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlpControlesTexto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControlesTexto.Controls.Add(this.lblItemFilho, 0, 0);
            this.tlpControlesTexto.Controls.Add(this.txtItemFilho, 1, 0);
            this.tlpControlesTexto.Controls.Add(this.label1, 0, 1);
            this.tlpControlesTexto.Controls.Add(this.txtDDD, 1, 1);
            this.tlpControlesTexto.Controls.Add(this.lblIbge, 0, 2);
            this.tlpControlesTexto.Controls.Add(this.txtIbge, 1, 2);
            this.tlpControlesTexto.Controls.Add(this.label3, 0, 3);
            this.tlpControlesTexto.Controls.Add(this.txtCep, 1, 3);
            this.tlpControlesTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControlesTexto.Location = new System.Drawing.Point(4, 324);
            this.tlpControlesTexto.Margin = new System.Windows.Forms.Padding(4);
            this.tlpControlesTexto.Name = "tlpControlesTexto";
            this.tlpControlesTexto.RowCount = 4;
            this.tlpControlesTexto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControlesTexto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControlesTexto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControlesTexto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpControlesTexto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpControlesTexto.Size = new System.Drawing.Size(981, 115);
            this.tlpControlesTexto.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código DDD";
            // 
            // txtDDD
            // 
            this.txtDDD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDDD.Enabled = false;
            this.txtDDD.Location = new System.Drawing.Point(137, 32);
            this.txtDDD.Margin = new System.Windows.Forms.Padding(4);
            this.txtDDD.Name = "txtDDD";
            this.txtDDD.Size = new System.Drawing.Size(105, 22);
            this.txtDDD.TabIndex = 4;
            this.txtDDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDDD_KeyPress);
            // 
            // lblIbge
            // 
            this.lblIbge.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIbge.AutoSize = true;
            this.lblIbge.Location = new System.Drawing.Point(41, 61);
            this.lblIbge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIbge.Name = "lblIbge";
            this.lblIbge.Size = new System.Drawing.Size(88, 17);
            this.lblIbge.TabIndex = 6;
            this.lblIbge.Text = "Código IBGE";
            // 
            // txtIbge
            // 
            this.txtIbge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIbge.Enabled = false;
            this.txtIbge.Location = new System.Drawing.Point(137, 60);
            this.txtIbge.Margin = new System.Windows.Forms.Padding(4);
            this.txtIbge.Name = "txtIbge";
            this.txtIbge.Size = new System.Drawing.Size(240, 22);
            this.txtIbge.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "CEP";
            // 
            // txtCep
            // 
            this.txtCep.Enabled = false;
            this.txtCep.Location = new System.Drawing.Point(137, 88);
            this.txtCep.Margin = new System.Windows.Forms.Padding(4);
            this.txtCep.Mask = "00.000-000";
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(95, 22);
            this.txtCep.TabIndex = 6;
            this.txtCep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCep_KeyPress);
            // 
            // tlpLabelPai
            // 
            this.tlpLabelPai.ColumnCount = 2;
            this.tlpLabelPai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlpLabelPai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLabelPai.Controls.Add(this.lblItemPai, 0, 0);
            this.tlpLabelPai.Controls.Add(this.txtItemPai, 1, 0);
            this.tlpLabelPai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLabelPai.Location = new System.Drawing.Point(4, 4);
            this.tlpLabelPai.Margin = new System.Windows.Forms.Padding(4);
            this.tlpLabelPai.Name = "tlpLabelPai";
            this.tlpLabelPai.RowCount = 1;
            this.tlpLabelPai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLabelPai.Size = new System.Drawing.Size(981, 35);
            this.tlpLabelPai.TabIndex = 10;
            // 
            // lblItemPai
            // 
            this.lblItemPai.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblItemPai.AutoSize = true;
            this.lblItemPai.Location = new System.Drawing.Point(77, 9);
            this.lblItemPai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemPai.Name = "lblItemPai";
            this.lblItemPai.Size = new System.Drawing.Size(52, 17);
            this.lblItemPai.TabIndex = 0;
            this.lblItemPai.Text = "Codigo";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificador,
            this.colCodigo,
            this.colDescricao,
            this.colEditar});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(4, 47);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(981, 269);
            this.dgvItems.TabIndex = 2;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            this.dgvItems.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvItems_CellMouseMove);
            this.dgvItems.Leave += new System.EventHandler(this.dgvItems_Leave);
            // 
            // colIdentificador
            // 
            this.colIdentificador.HeaderText = "Column1";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            this.colIdentificador.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlControles, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 1;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 966F));
            this.tlpPrincipal.Size = new System.Drawing.Size(997, 451);
            this.tlpPrincipal.TabIndex = 1;
            // 
            // GuardarItemHelper
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1003, 587);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarItemHelper";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GuardarItemHelper";
            this.pnlControles.ResumeLayout(false);
            this.tlpControles.ResumeLayout(false);
            this.tlpControlesTexto.ResumeLayout(false);
            this.tlpControlesTexto.PerformLayout();
            this.tlpLabelPai.ResumeLayout(false);
            this.tlpLabelPai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtItemFilho;
        private System.Windows.Forms.TextBox txtItemPai;
        private System.Windows.Forms.Label lblItemFilho;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Label lblItemPai;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpControles;
        private System.Windows.Forms.TableLayoutPanel tlpControlesTexto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDDD;
        private System.Windows.Forms.TextBox txtIbge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIbge;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.TableLayoutPanel tlpLabelPai;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
    }
}