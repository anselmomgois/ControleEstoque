namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarCliente
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
            Informatiz.ControleEstoque.Aplicacao.Classes.AgenteServico agenteServico1 = new Informatiz.ControleEstoque.Aplicacao.Classes.AgenteServico();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarCliente));
            this.gbpCliente = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gpbDadosCliente = new System.Windows.Forms.GroupBox();
            this.cmbSituacao = new System.Windows.Forms.ComboBox();
            this.txtTabelaMercadoria = new System.Windows.Forms.TextBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.lblNascimento = new System.Windows.Forms.Label();
            this.txtNomeMae = new System.Windows.Forms.TextBox();
            this.dtpNascimento = new System.Windows.Forms.DateTimePicker();
            this.lblNomeMae = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtNomePai = new System.Windows.Forms.TextBox();
            this.lblRG = new System.Windows.Forms.Label();
            this.lblNomePai = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.cmbSegmento = new System.Windows.Forms.ComboBox();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lblSegmentoComercial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.txtInscricao = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefoneFixo = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTelefoneFixo = new System.Windows.Forms.MaskedTextBox();
            this.lblTelefoneCelular = new System.Windows.Forms.Label();
            this.lblSalario = new System.Windows.Forms.Label();
            this.txtTelefoneCelular = new System.Windows.Forms.MaskedTextBox();
            this.lblContato = new System.Windows.Forms.Label();
            this.lblTabelaVenda = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEmpresa = new System.Windows.Forms.DataGridView();
            this.colEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.ucEndereco = new Informatiz.ControleEstoque.Aplicacao.Controles.ucEndereco();
            this.lblNomeFantasia = new System.Windows.Forms.Label();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.gbpCliente.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpbDadosCliente.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // gbpCliente
            // 
            this.gbpCliente.Controls.Add(this.tableLayoutPanel1);
            this.gbpCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbpCliente.Location = new System.Drawing.Point(0, 0);
            this.gbpCliente.Name = "gbpCliente";
            this.gbpCliente.Size = new System.Drawing.Size(1213, 559);
            this.gbpCliente.TabIndex = 0;
            this.gbpCliente.TabStop = false;
            this.gbpCliente.Text = "Cliente";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.943357F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.03605F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.840371F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.45417F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.622204F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.83761F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.gpbDadosCliente, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCodigo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCodigo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNome, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNome, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucEndereco, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNomeFantasia, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNomeFantasia, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.68687F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.31313F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1207, 540);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gpbDadosCliente
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gpbDadosCliente, 7);
            this.gpbDadosCliente.Controls.Add(this.cmbSituacao);
            this.gpbDadosCliente.Controls.Add(this.txtTabelaMercadoria);
            this.gpbDadosCliente.Controls.Add(this.lblSituacao);
            this.gpbDadosCliente.Controls.Add(this.lblNascimento);
            this.gpbDadosCliente.Controls.Add(this.txtNomeMae);
            this.gpbDadosCliente.Controls.Add(this.dtpNascimento);
            this.gpbDadosCliente.Controls.Add(this.lblNomeMae);
            this.gpbDadosCliente.Controls.Add(this.lblCPF);
            this.gpbDadosCliente.Controls.Add(this.txtLimite);
            this.gpbDadosCliente.Controls.Add(this.txtFax);
            this.gpbDadosCliente.Controls.Add(this.txtCPF);
            this.gpbDadosCliente.Controls.Add(this.lblFax);
            this.gpbDadosCliente.Controls.Add(this.txtNomePai);
            this.gpbDadosCliente.Controls.Add(this.lblRG);
            this.gpbDadosCliente.Controls.Add(this.lblNomePai);
            this.gpbDadosCliente.Controls.Add(this.txtRG);
            this.gpbDadosCliente.Controls.Add(this.cmbVendedor);
            this.gpbDadosCliente.Controls.Add(this.lblCnpj);
            this.gpbDadosCliente.Controls.Add(this.cmbSegmento);
            this.gpbDadosCliente.Controls.Add(this.txtCnpj);
            this.gpbDadosCliente.Controls.Add(this.lblSegmentoComercial);
            this.gpbDadosCliente.Controls.Add(this.label1);
            this.gpbDadosCliente.Controls.Add(this.lblVendedor);
            this.gpbDadosCliente.Controls.Add(this.txtInscricao);
            this.gpbDadosCliente.Controls.Add(this.txtEmail);
            this.gpbDadosCliente.Controls.Add(this.lblTelefoneFixo);
            this.gpbDadosCliente.Controls.Add(this.lblEmail);
            this.gpbDadosCliente.Controls.Add(this.txtTelefoneFixo);
            this.gpbDadosCliente.Controls.Add(this.lblTelefoneCelular);
            this.gpbDadosCliente.Controls.Add(this.lblSalario);
            this.gpbDadosCliente.Controls.Add(this.txtTelefoneCelular);
            this.gpbDadosCliente.Controls.Add(this.lblContato);
            this.gpbDadosCliente.Controls.Add(this.lblTabelaVenda);
            this.gpbDadosCliente.Controls.Add(this.txtContato);
            this.gpbDadosCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbDadosCliente.Location = new System.Drawing.Point(3, 246);
            this.gpbDadosCliente.Name = "gpbDadosCliente";
            this.gpbDadosCliente.Size = new System.Drawing.Size(1201, 197);
            this.gpbDadosCliente.TabIndex = 1039;
            this.gpbDadosCliente.TabStop = false;
            // 
            // cmbSituacao
            // 
            this.cmbSituacao.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSituacao.FormattingEnabled = true;
            this.cmbSituacao.Location = new System.Drawing.Point(934, 42);
            this.cmbSituacao.Name = "cmbSituacao";
            this.cmbSituacao.Size = new System.Drawing.Size(182, 21);
            this.cmbSituacao.TabIndex = 1008;
            // 
            // txtTabelaMercadoria
            // 
            this.txtTabelaMercadoria.Location = new System.Drawing.Point(439, 76);
            this.txtTabelaMercadoria.MaxLength = 10;
            this.txtTabelaMercadoria.Name = "txtTabelaMercadoria";
            this.txtTabelaMercadoria.Size = new System.Drawing.Size(86, 20);
            this.txtTabelaMercadoria.TabIndex = 1014;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(879, 45);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(49, 13);
            this.lblSituacao.TabIndex = 1037;
            this.lblSituacao.Text = "Situação";
            // 
            // lblNascimento
            // 
            this.lblNascimento.AutoSize = true;
            this.lblNascimento.Location = new System.Drawing.Point(14, 17);
            this.lblNascimento.Name = "lblNascimento";
            this.lblNascimento.Size = new System.Drawing.Size(104, 13);
            this.lblNascimento.TabIndex = 1038;
            this.lblNascimento.Text = "Data de Nascimento";
            // 
            // txtNomeMae
            // 
            this.txtNomeMae.Location = new System.Drawing.Point(739, 111);
            this.txtNomeMae.MaxLength = 100;
            this.txtNomeMae.Name = "txtNomeMae";
            this.txtNomeMae.Size = new System.Drawing.Size(200, 20);
            this.txtNomeMae.TabIndex = 1021;
            // 
            // dtpNascimento
            // 
            this.dtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNascimento.Location = new System.Drawing.Point(124, 14);
            this.dtpNascimento.Name = "dtpNascimento";
            this.dtpNascimento.ShowCheckBox = true;
            this.dtpNascimento.Size = new System.Drawing.Size(107, 20);
            this.dtpNascimento.TabIndex = 1004;
            // 
            // lblNomeMae
            // 
            this.lblNomeMae.AutoSize = true;
            this.lblNomeMae.Location = new System.Drawing.Point(649, 115);
            this.lblNomeMae.Name = "lblNomeMae";
            this.lblNomeMae.Size = new System.Drawing.Size(74, 13);
            this.lblNomeMae.TabIndex = 1036;
            this.lblNomeMae.Text = "Nome da Mãe";
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(393, 17);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(27, 13);
            this.lblCPF.TabIndex = 1016;
            this.lblCPF.Text = "CPF";
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(739, 76);
            this.txtLimite.MaxLength = 20;
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.Size = new System.Drawing.Size(98, 20);
            this.txtLimite.TabIndex = 1015;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(934, 71);
            this.txtFax.Mask = "(00) 0000-0000";
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(86, 20);
            this.txtFax.TabIndex = 1012;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(439, 14);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(86, 20);
            this.txtCPF.TabIndex = 1005;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(879, 75);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(27, 13);
            this.lblFax.TabIndex = 1028;
            this.lblFax.Text = "FAX";
            // 
            // txtNomePai
            // 
            this.txtNomePai.Location = new System.Drawing.Point(439, 111);
            this.txtNomePai.MaxLength = 100;
            this.txtNomePai.Name = "txtNomePai";
            this.txtNomePai.Size = new System.Drawing.Size(200, 20);
            this.txtNomePai.TabIndex = 1019;
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Location = new System.Drawing.Point(710, 17);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(23, 13);
            this.lblRG.TabIndex = 1018;
            this.lblRG.Text = "RG";
            // 
            // lblNomePai
            // 
            this.lblNomePai.AutoSize = true;
            this.lblNomePai.Location = new System.Drawing.Point(349, 115);
            this.lblNomePai.Name = "lblNomePai";
            this.lblNomePai.Size = new System.Drawing.Size(68, 13);
            this.lblNomePai.TabIndex = 1035;
            this.lblNomePai.Text = "Nome do Pai";
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(739, 14);
            this.txtRG.MaxLength = 50;
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(114, 20);
            this.txtRG.TabIndex = 1006;
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(439, 137);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(200, 21);
            this.cmbVendedor.TabIndex = 1023;
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(879, 17);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(34, 13);
            this.lblCnpj.TabIndex = 1020;
            this.lblCnpj.Text = "CNPJ";
            // 
            // cmbSegmento
            // 
            this.cmbSegmento.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbSegmento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSegmento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSegmento.FormattingEnabled = true;
            this.cmbSegmento.Location = new System.Drawing.Point(124, 137);
            this.cmbSegmento.Name = "cmbSegmento";
            this.cmbSegmento.Size = new System.Drawing.Size(195, 21);
            this.cmbSegmento.TabIndex = 1022;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(934, 14);
            this.txtCnpj.Mask = "00.000.000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(111, 20);
            this.txtCnpj.TabIndex = 1007;
            // 
            // lblSegmentoComercial
            // 
            this.lblSegmentoComercial.AutoSize = true;
            this.lblSegmentoComercial.Location = new System.Drawing.Point(14, 141);
            this.lblSegmentoComercial.Name = "lblSegmentoComercial";
            this.lblSegmentoComercial.Size = new System.Drawing.Size(104, 13);
            this.lblSegmentoComercial.TabIndex = 1034;
            this.lblSegmentoComercial.Text = "Segmento Comercial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1024;
            this.label1.Text = "Inscrição Estadual";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(349, 137);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(64, 26);
            this.lblVendedor.TabIndex = 1033;
            this.lblVendedor.Text = "Vendedor \r\nresponsável";
            // 
            // txtInscricao
            // 
            this.txtInscricao.Location = new System.Drawing.Point(124, 42);
            this.txtInscricao.MaxLength = 50;
            this.txtInscricao.Name = "txtInscricao";
            this.txtInscricao.Size = new System.Drawing.Size(195, 20);
            this.txtInscricao.TabIndex = 1009;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(124, 111);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 20);
            this.txtEmail.TabIndex = 1017;
            // 
            // lblTelefoneFixo
            // 
            this.lblTelefoneFixo.AutoSize = true;
            this.lblTelefoneFixo.Location = new System.Drawing.Point(349, 45);
            this.lblTelefoneFixo.Name = "lblTelefoneFixo";
            this.lblTelefoneFixo.Size = new System.Drawing.Size(71, 13);
            this.lblTelefoneFixo.TabIndex = 1026;
            this.lblTelefoneFixo.Text = "Telefone Fixo";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(14, 115);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 1032;
            this.lblEmail.Text = "Email";
            // 
            // txtTelefoneFixo
            // 
            this.txtTelefoneFixo.Location = new System.Drawing.Point(439, 42);
            this.txtTelefoneFixo.Mask = "(00) 0000-0000";
            this.txtTelefoneFixo.Name = "txtTelefoneFixo";
            this.txtTelefoneFixo.Size = new System.Drawing.Size(86, 20);
            this.txtTelefoneFixo.TabIndex = 1010;
            // 
            // lblTelefoneCelular
            // 
            this.lblTelefoneCelular.AutoSize = true;
            this.lblTelefoneCelular.Location = new System.Drawing.Point(649, 45);
            this.lblTelefoneCelular.Name = "lblTelefoneCelular";
            this.lblTelefoneCelular.Size = new System.Drawing.Size(84, 13);
            this.lblTelefoneCelular.TabIndex = 1027;
            this.lblTelefoneCelular.Text = "Telefone Celular";
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.Location = new System.Drawing.Point(649, 75);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(84, 26);
            this.lblSalario.TabIndex = 1031;
            this.lblSalario.Text = "Limite de crédito\r\npara venda";
            // 
            // txtTelefoneCelular
            // 
            this.txtTelefoneCelular.Location = new System.Drawing.Point(739, 42);
            this.txtTelefoneCelular.Mask = "(00) 0000-0000";
            this.txtTelefoneCelular.Name = "txtTelefoneCelular";
            this.txtTelefoneCelular.Size = new System.Drawing.Size(114, 20);
            this.txtTelefoneCelular.TabIndex = 1011;
            // 
            // lblContato
            // 
            this.lblContato.AutoSize = true;
            this.lblContato.Location = new System.Drawing.Point(14, 75);
            this.lblContato.Name = "lblContato";
            this.lblContato.Size = new System.Drawing.Size(105, 26);
            this.lblContato.TabIndex = 1029;
            this.lblContato.Text = "Pessoa responsável \r\npelo contato";
            // 
            // lblTabelaVenda
            // 
            this.lblTabelaVenda.AutoSize = true;
            this.lblTabelaVenda.Location = new System.Drawing.Point(349, 75);
            this.lblTabelaVenda.Name = "lblTabelaVenda";
            this.lblTabelaVenda.Size = new System.Drawing.Size(88, 26);
            this.lblTabelaVenda.TabIndex = 1030;
            this.lblTabelaVenda.Text = "Tabela de venda\r\n padrão\r\n";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(124, 76);
            this.txtContato.MaxLength = 100;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(195, 20);
            this.txtContato.TabIndex = 1013;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(3, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1039;
            this.lblCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(62, 3);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(128, 20);
            this.txtCodigo.TabIndex = 1001;
            this.txtCodigo.TabStop = false;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 7);
            this.groupBox1.Controls.Add(this.dgvEmpresa);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 449);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1201, 88);
            this.groupBox1.TabIndex = 1025;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações Profissionais";
            // 
            // dgvEmpresa
            // 
            this.dgvEmpresa.AllowUserToAddRows = false;
            this.dgvEmpresa.AllowUserToDeleteRows = false;
            this.dgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmpresa,
            this.colCargo,
            this.colSalario,
            this.colEditar});
            this.dgvEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpresa.Location = new System.Drawing.Point(3, 16);
            this.dgvEmpresa.Name = "dgvEmpresa";
            this.dgvEmpresa.ReadOnly = true;
            this.dgvEmpresa.Size = new System.Drawing.Size(1195, 69);
            this.dgvEmpresa.TabIndex = 22;
            // 
            // colEmpresa
            // 
            this.colEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmpresa.HeaderText = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.ReadOnly = true;
            this.colEmpresa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colCargo
            // 
            this.colCargo.HeaderText = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.ReadOnly = true;
            this.colCargo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCargo.Width = 250;
            // 
            // colSalario
            // 
            this.colSalario.HeaderText = "Salário";
            this.colSalario.Name = "colSalario";
            this.colSalario.ReadOnly = true;
            this.colSalario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(243, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 1040;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(301, 3);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(343, 20);
            this.txtNome.TabIndex = 1002;
            // 
            // ucEndereco
            // 
            this.ucEndereco.Agente = agenteServico1;
            this.ucEndereco.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel1.SetColumnSpan(this.ucEndereco, 7);
            this.ucEndereco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEndereco.Location = new System.Drawing.Point(4, 32);
            this.ucEndereco.Margin = new System.Windows.Forms.Padding(4);
            this.ucEndereco.Name = "ucEndereco";
            this.ucEndereco.ServicosEmProcesamento = null;
            this.ucEndereco.Size = new System.Drawing.Size(1199, 207);
            this.ucEndereco.TabIndex = 1004;
            // 
            // lblNomeFantasia
            // 
            this.lblNomeFantasia.AutoSize = true;
            this.lblNomeFantasia.Location = new System.Drawing.Point(657, 0);
            this.lblNomeFantasia.Name = "lblNomeFantasia";
            this.lblNomeFantasia.Size = new System.Drawing.Size(84, 13);
            this.lblNomeFantasia.TabIndex = 1041;
            this.lblNomeFantasia.Text = "Nome Fantansia";
            // 
            // txtNomeFantasia
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtNomeFantasia, 2);
            this.txtNomeFantasia.Location = new System.Drawing.Point(749, 3);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(343, 20);
            this.txtNomeFantasia.TabIndex = 1003;
            // 
            // GuardarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1219, 695);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarCliente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cliente";
            this.gbpCliente.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gpbDadosCliente.ResumeLayout(false);
            this.gpbDadosCliente.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbpCliente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gpbDadosCliente;
        private System.Windows.Forms.ComboBox cmbSituacao;
        private System.Windows.Forms.TextBox txtTabelaMercadoria;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lblNascimento;
        private System.Windows.Forms.TextBox txtNomeMae;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.Label lblNomeMae;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtLimite;
        private System.Windows.Forms.MaskedTextBox txtFax;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtNomePai;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.Label lblNomePai;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.ComboBox cmbSegmento;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label lblSegmentoComercial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.TextBox txtInscricao;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefoneFixo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.MaskedTextBox txtTelefoneFixo;
        private System.Windows.Forms.Label lblTelefoneCelular;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.MaskedTextBox txtTelefoneCelular;
        private System.Windows.Forms.Label lblContato;
        private System.Windows.Forms.Label lblTabelaVenda;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalario;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private Controles.ucEndereco ucEndereco;
        private System.Windows.Forms.Label lblNomeFantasia;
        private System.Windows.Forms.TextBox txtNomeFantasia;
    }
}