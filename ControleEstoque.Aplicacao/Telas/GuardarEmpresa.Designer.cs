namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarEmpresa
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
            this.gpbDadosEmpresa = new System.Windows.Forms.GroupBox();
            this.gpbFiliais = new System.Windows.Forms.GroupBox();
            this.dgvEmpresa = new System.Windows.Forms.DataGridView();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificadorProvisorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisualizar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtInscricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtsmtp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSSl = new System.Windows.Forms.CheckBox();
            this.gpbDadosEmpresa.SuspendLayout();
            this.gpbFiliais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDadosEmpresa
            // 
            this.gpbDadosEmpresa.Controls.Add(this.groupBox1);
            this.gpbDadosEmpresa.Controls.Add(this.gpbFiliais);
            this.gpbDadosEmpresa.Controls.Add(this.txtInscricao);
            this.gpbDadosEmpresa.Controls.Add(this.label1);
            this.gpbDadosEmpresa.Controls.Add(this.txtCnpj);
            this.gpbDadosEmpresa.Controls.Add(this.lblCnpj);
            this.gpbDadosEmpresa.Controls.Add(this.txtNome);
            this.gpbDadosEmpresa.Controls.Add(this.lblNome);
            this.gpbDadosEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbDadosEmpresa.Location = new System.Drawing.Point(0, 0);
            this.gpbDadosEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.gpbDadosEmpresa.Name = "gpbDadosEmpresa";
            this.gpbDadosEmpresa.Padding = new System.Windows.Forms.Padding(4);
            this.gpbDadosEmpresa.Size = new System.Drawing.Size(1239, 399);
            this.gpbDadosEmpresa.TabIndex = 7;
            this.gpbDadosEmpresa.TabStop = false;
            this.gpbDadosEmpresa.Text = "Dados da Empresa";
            // 
            // gpbFiliais
            // 
            this.gpbFiliais.Controls.Add(this.dgvEmpresa);
            this.gpbFiliais.Location = new System.Drawing.Point(15, 142);
            this.gpbFiliais.Margin = new System.Windows.Forms.Padding(4);
            this.gpbFiliais.Name = "gpbFiliais";
            this.gpbFiliais.Padding = new System.Windows.Forms.Padding(4);
            this.gpbFiliais.Size = new System.Drawing.Size(1227, 257);
            this.gpbFiliais.TabIndex = 1007;
            this.gpbFiliais.TabStop = false;
            this.gpbFiliais.Text = "Filiais";
            // 
            // dgvEmpresa
            // 
            this.dgvEmpresa.AllowUserToAddRows = false;
            this.dgvEmpresa.AllowUserToDeleteRows = false;
            this.dgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificador,
            this.colIdentificadorProvisorio,
            this.colFilial,
            this.colEmail,
            this.colTelefone,
            this.colVisualizar,
            this.colEditar,
            this.colExcluir});
            this.dgvEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpresa.Location = new System.Drawing.Point(4, 19);
            this.dgvEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmpresa.Name = "dgvEmpresa";
            this.dgvEmpresa.ReadOnly = true;
            this.dgvEmpresa.Size = new System.Drawing.Size(1219, 234);
            this.dgvEmpresa.TabIndex = 23;
            this.dgvEmpresa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresa_CellContentClick);
            this.dgvEmpresa.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmpresa_CellMouseMove);
            // 
            // colIdentificador
            // 
            this.colIdentificador.HeaderText = "Column1";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            this.colIdentificador.Visible = false;
            // 
            // colIdentificadorProvisorio
            // 
            this.colIdentificadorProvisorio.HeaderText = "Column1";
            this.colIdentificadorProvisorio.Name = "colIdentificadorProvisorio";
            this.colIdentificadorProvisorio.ReadOnly = true;
            this.colIdentificadorProvisorio.Visible = false;
            // 
            // colFilial
            // 
            this.colFilial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFilial.HeaderText = "Filial";
            this.colFilial.Name = "colFilial";
            this.colFilial.ReadOnly = true;
            this.colFilial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEmail.Width = 250;
            // 
            // colTelefone
            // 
            this.colTelefone.HeaderText = "Telefone";
            this.colTelefone.Name = "colTelefone";
            this.colTelefone.ReadOnly = true;
            this.colTelefone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colVisualizar
            // 
            this.colVisualizar.HeaderText = "Visualizar";
            this.colVisualizar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.search_16;
            this.colVisualizar.Name = "colVisualizar";
            this.colVisualizar.ReadOnly = true;
            this.colVisualizar.Width = 70;
            // 
            // colEditar
            // 
            this.colEditar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEditar.Width = 70;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Width = 70;
            // 
            // txtInscricao
            // 
            this.txtInscricao.Location = new System.Drawing.Point(148, 97);
            this.txtInscricao.Margin = new System.Windows.Forms.Padding(4);
            this.txtInscricao.MaxLength = 50;
            this.txtInscricao.Name = "txtInscricao";
            this.txtInscricao.Size = new System.Drawing.Size(192, 22);
            this.txtInscricao.TabIndex = 1005;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 1006;
            this.label1.Text = "Inscrição Estadual";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(64, 66);
            this.txtCnpj.Margin = new System.Windows.Forms.Padding(4);
            this.txtCnpj.Mask = "00.000.000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(147, 22);
            this.txtCnpj.TabIndex = 1003;
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(11, 75);
            this.lblCnpj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(43, 17);
            this.lblCnpj.TabIndex = 1004;
            this.lblCnpj.Text = "CNPJ";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(64, 34);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(627, 22);
            this.txtNome.TabIndex = 1001;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(8, 44);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(45, 17);
            this.lblNome.TabIndex = 1002;
            this.lblNome.Text = "Nome";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSSl);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPorta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtsmtp);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(698, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 116);
            this.groupBox1.TabIndex = 1008;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuração Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(55, 20);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(478, 22);
            this.txtEmail.TabIndex = 1009;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 1010;
            this.label3.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(55, 48);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenha.MaxLength = 50;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(182, 22);
            this.txtSenha.TabIndex = 1011;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // txtsmtp
            // 
            this.txtsmtp.Location = new System.Drawing.Point(55, 76);
            this.txtsmtp.Margin = new System.Windows.Forms.Padding(4);
            this.txtsmtp.MaxLength = 50;
            this.txtsmtp.Name = "txtsmtp";
            this.txtsmtp.Size = new System.Drawing.Size(182, 22);
            this.txtsmtp.TabIndex = 1012;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 1013;
            this.label4.Text = "Smtp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 1014;
            this.label5.Text = "Porta";
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(293, 50);
            this.txtPorta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorta.MaxLength = 50;
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(100, 22);
            this.txtPorta.TabIndex = 1015;
            this.txtPorta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorta_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 17);
            this.label6.TabIndex = 1016;
            this.label6.Text = "SSl";
            // 
            // chkSSl
            // 
            this.chkSSl.AutoSize = true;
            this.chkSSl.Location = new System.Drawing.Point(293, 76);
            this.chkSSl.Name = "chkSSl";
            this.chkSSl.Size = new System.Drawing.Size(18, 17);
            this.chkSSl.TabIndex = 1017;
            this.chkSSl.UseVisualStyleBackColor = true;
            // 
            // GuardarEmpresa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1245, 535);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "GuardarEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Empresa";
            this.gpbDadosEmpresa.ResumeLayout(false);
            this.gpbDadosEmpresa.PerformLayout();
            this.gpbFiliais.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDadosEmpresa;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.TextBox txtInscricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbFiliais;
        private System.Windows.Forms.DataGridView dgvEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorProvisorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefone;
        private System.Windows.Forms.DataGridViewImageColumn colVisualizar;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsmtp;
        private System.Windows.Forms.CheckBox chkSSl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label label5;
    }
}