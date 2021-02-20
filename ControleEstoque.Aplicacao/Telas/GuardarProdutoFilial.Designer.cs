namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarProdutoFilial
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
            this.txtDescricaoPrateleira = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblNumeroMinimoVenda = new System.Windows.Forms.Label();
            this.txtNumeroMinimo = new System.Windows.Forms.TextBox();
            this.gpbNumeroVenda = new System.Windows.Forms.GroupBox();
            this.cmbSetorPreparo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUMQntAtacado = new System.Windows.Forms.ComboBox();
            this.lblUnidadeMedidaVenda = new System.Windows.Forms.Label();
            this.txtQntVendaAtacado = new System.Windows.Forms.TextBox();
            this.cmbUMVendaAtacado = new System.Windows.Forms.ComboBox();
            this.lblQuantidadeVendaAtacado = new System.Windows.Forms.Label();
            this.cmbUMVendaVarejo = new System.Windows.Forms.ComboBox();
            this.txtValorVendaAtacado = new System.Windows.Forms.TextBox();
            this.lblNumeroEstoqueMinimo = new System.Windows.Forms.Label();
            this.lblValorVendaAtacado = new System.Windows.Forms.Label();
            this.txtEstoqueMinimo = new System.Windows.Forms.TextBox();
            this.txtValorVendaVarejo = new System.Windows.Forms.TextBox();
            this.lblValorVendaVarejo = new System.Windows.Forms.Label();
            this.txtIPIPercentual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gpbOutrosDados = new System.Windows.Forms.GroupBox();
            this.txtPercentualDescontoAtacado = new System.Windows.Forms.TextBox();
            this.lblPercentualDescontoAtacado = new System.Windows.Forms.Label();
            this.cmbComissao = new System.Windows.Forms.ComboBox();
            this.lblComissao = new System.Windows.Forms.Label();
            this.txtOutrasDespesasPercentual = new System.Windows.Forms.TextBox();
            this.lblPercentualOutrasDespesas = new System.Windows.Forms.Label();
            this.txtFretePercentual = new System.Windows.Forms.TextBox();
            this.lblFretePercentual = new System.Windows.Forms.Label();
            this.txtEmbalagemPercentual = new System.Windows.Forms.TextBox();
            this.lblPercentualEmbalagem = new System.Windows.Forms.Label();
            this.lblUnidadeMedidaEstoque = new System.Windows.Forms.Label();
            this.gpbNumeroVenda.SuspendLayout();
            this.gpbOutrosDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescricaoPrateleira
            // 
            this.txtDescricaoPrateleira.Location = new System.Drawing.Point(175, 134);
            this.txtDescricaoPrateleira.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescricaoPrateleira.MaxLength = 100;
            this.txtDescricaoPrateleira.Name = "txtDescricaoPrateleira";
            this.txtDescricaoPrateleira.Size = new System.Drawing.Size(327, 22);
            this.txtDescricaoPrateleira.TabIndex = 1005;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(11, 143);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(156, 17);
            this.lblNome.TabIndex = 1006;
            this.lblNome.Text = "Descrição da Prateleira";
            // 
            // lblNumeroMinimoVenda
            // 
            this.lblNumeroMinimoVenda.AutoSize = true;
            this.lblNumeroMinimoVenda.Location = new System.Drawing.Point(8, 33);
            this.lblNumeroMinimoVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroMinimoVenda.Name = "lblNumeroMinimoVenda";
            this.lblNumeroMinimoVenda.Size = new System.Drawing.Size(171, 17);
            this.lblNumeroMinimoVenda.TabIndex = 1012;
            this.lblNumeroMinimoVenda.Text = "Número Mínimo de Venda";
            // 
            // txtNumeroMinimo
            // 
            this.txtNumeroMinimo.Location = new System.Drawing.Point(191, 28);
            this.txtNumeroMinimo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroMinimo.MaxLength = 10;
            this.txtNumeroMinimo.Name = "txtNumeroMinimo";
            this.txtNumeroMinimo.Size = new System.Drawing.Size(107, 22);
            this.txtNumeroMinimo.TabIndex = 1011;
            this.txtNumeroMinimo.Enter += new System.EventHandler(this.txtNumeroMinimo_Enter);
            // 
            // gpbNumeroVenda
            // 
            this.gpbNumeroVenda.Controls.Add(this.lblUnidadeMedidaEstoque);
            this.gpbNumeroVenda.Controls.Add(this.cmbSetorPreparo);
            this.gpbNumeroVenda.Controls.Add(this.label1);
            this.gpbNumeroVenda.Controls.Add(this.cmbUMQntAtacado);
            this.gpbNumeroVenda.Controls.Add(this.lblUnidadeMedidaVenda);
            this.gpbNumeroVenda.Controls.Add(this.txtQntVendaAtacado);
            this.gpbNumeroVenda.Controls.Add(this.cmbUMVendaAtacado);
            this.gpbNumeroVenda.Controls.Add(this.lblQuantidadeVendaAtacado);
            this.gpbNumeroVenda.Controls.Add(this.lblNumeroMinimoVenda);
            this.gpbNumeroVenda.Controls.Add(this.cmbUMVendaVarejo);
            this.gpbNumeroVenda.Controls.Add(this.txtValorVendaAtacado);
            this.gpbNumeroVenda.Controls.Add(this.lblNumeroEstoqueMinimo);
            this.gpbNumeroVenda.Controls.Add(this.txtNumeroMinimo);
            this.gpbNumeroVenda.Controls.Add(this.lblValorVendaAtacado);
            this.gpbNumeroVenda.Controls.Add(this.txtEstoqueMinimo);
            this.gpbNumeroVenda.Controls.Add(this.txtValorVendaVarejo);
            this.gpbNumeroVenda.Controls.Add(this.lblValorVendaVarejo);
            this.gpbNumeroVenda.Location = new System.Drawing.Point(15, 181);
            this.gpbNumeroVenda.Margin = new System.Windows.Forms.Padding(4);
            this.gpbNumeroVenda.Name = "gpbNumeroVenda";
            this.gpbNumeroVenda.Padding = new System.Windows.Forms.Padding(4);
            this.gpbNumeroVenda.Size = new System.Drawing.Size(487, 190);
            this.gpbNumeroVenda.TabIndex = 1016;
            this.gpbNumeroVenda.TabStop = false;
            this.gpbNumeroVenda.Text = "Estoque e Venda";
            // 
            // cmbSetorPreparo
            // 
            this.cmbSetorPreparo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbSetorPreparo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetorPreparo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSetorPreparo.FormattingEnabled = true;
            this.cmbSetorPreparo.Location = new System.Drawing.Point(191, 76);
            this.cmbSetorPreparo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSetorPreparo.Name = "cmbSetorPreparo";
            this.cmbSetorPreparo.Size = new System.Drawing.Size(288, 24);
            this.cmbSetorPreparo.TabIndex = 1042;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1042;
            this.label1.Text = "Setor de Preparo";
            // 
            // cmbUMQntAtacado
            // 
            this.cmbUMQntAtacado.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbUMQntAtacado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUMQntAtacado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUMQntAtacado.FormattingEnabled = true;
            this.cmbUMQntAtacado.Location = new System.Drawing.Point(285, 155);
            this.cmbUMQntAtacado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUMQntAtacado.Name = "cmbUMQntAtacado";
            this.cmbUMQntAtacado.Size = new System.Drawing.Size(194, 24);
            this.cmbUMQntAtacado.TabIndex = 1039;
            // 
            // lblUnidadeMedidaVenda
            // 
            this.lblUnidadeMedidaVenda.AutoSize = true;
            this.lblUnidadeMedidaVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadeMedidaVenda.Location = new System.Drawing.Point(306, 30);
            this.lblUnidadeMedidaVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnidadeMedidaVenda.Name = "lblUnidadeMedidaVenda";
            this.lblUnidadeMedidaVenda.Size = new System.Drawing.Size(0, 17);
            this.lblUnidadeMedidaVenda.TabIndex = 1013;
            // 
            // txtQntVendaAtacado
            // 
            this.txtQntVendaAtacado.Location = new System.Drawing.Point(191, 155);
            this.txtQntVendaAtacado.Name = "txtQntVendaAtacado";
            this.txtQntVendaAtacado.Size = new System.Drawing.Size(87, 22);
            this.txtQntVendaAtacado.TabIndex = 1033;
            this.txtQntVendaAtacado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQntVendaAtacado_KeyPress);
            // 
            // cmbUMVendaAtacado
            // 
            this.cmbUMVendaAtacado.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbUMVendaAtacado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUMVendaAtacado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUMVendaAtacado.FormattingEnabled = true;
            this.cmbUMVendaAtacado.Location = new System.Drawing.Point(285, 128);
            this.cmbUMVendaAtacado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUMVendaAtacado.Name = "cmbUMVendaAtacado";
            this.cmbUMVendaAtacado.Size = new System.Drawing.Size(194, 24);
            this.cmbUMVendaAtacado.TabIndex = 1038;
            // 
            // lblQuantidadeVendaAtacado
            // 
            this.lblQuantidadeVendaAtacado.AutoSize = true;
            this.lblQuantidadeVendaAtacado.Location = new System.Drawing.Point(8, 160);
            this.lblQuantidadeVendaAtacado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantidadeVendaAtacado.Name = "lblQuantidadeVendaAtacado";
            this.lblQuantidadeVendaAtacado.Size = new System.Drawing.Size(136, 17);
            this.lblQuantidadeVendaAtacado.TabIndex = 1030;
            this.lblQuantidadeVendaAtacado.Text = "Qnt. Venda Atacado";
            // 
            // cmbUMVendaVarejo
            // 
            this.cmbUMVendaVarejo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbUMVendaVarejo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUMVendaVarejo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUMVendaVarejo.FormattingEnabled = true;
            this.cmbUMVendaVarejo.Location = new System.Drawing.Point(285, 101);
            this.cmbUMVendaVarejo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUMVendaVarejo.Name = "cmbUMVendaVarejo";
            this.cmbUMVendaVarejo.Size = new System.Drawing.Size(194, 24);
            this.cmbUMVendaVarejo.TabIndex = 1037;
            // 
            // txtValorVendaAtacado
            // 
            this.txtValorVendaAtacado.Location = new System.Drawing.Point(191, 130);
            this.txtValorVendaAtacado.Name = "txtValorVendaAtacado";
            this.txtValorVendaAtacado.Size = new System.Drawing.Size(87, 22);
            this.txtValorVendaAtacado.TabIndex = 1032;
            this.txtValorVendaAtacado.Enter += new System.EventHandler(this.txtValorVendaAtacado_Enter);
            // 
            // lblNumeroEstoqueMinimo
            // 
            this.lblNumeroEstoqueMinimo.AutoSize = true;
            this.lblNumeroEstoqueMinimo.Location = new System.Drawing.Point(8, 56);
            this.lblNumeroEstoqueMinimo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroEstoqueMinimo.Name = "lblNumeroEstoqueMinimo";
            this.lblNumeroEstoqueMinimo.Size = new System.Drawing.Size(162, 17);
            this.lblNumeroEstoqueMinimo.TabIndex = 1012;
            this.lblNumeroEstoqueMinimo.Text = "Número Estoque Mínimo";
            // 
            // lblValorVendaAtacado
            // 
            this.lblValorVendaAtacado.AutoSize = true;
            this.lblValorVendaAtacado.Location = new System.Drawing.Point(8, 135);
            this.lblValorVendaAtacado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorVendaAtacado.Name = "lblValorVendaAtacado";
            this.lblValorVendaAtacado.Size = new System.Drawing.Size(142, 17);
            this.lblValorVendaAtacado.TabIndex = 1029;
            this.lblValorVendaAtacado.Text = "Valor Venda Atacado";
            // 
            // txtEstoqueMinimo
            // 
            this.txtEstoqueMinimo.Location = new System.Drawing.Point(191, 51);
            this.txtEstoqueMinimo.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstoqueMinimo.MaxLength = 10;
            this.txtEstoqueMinimo.Name = "txtEstoqueMinimo";
            this.txtEstoqueMinimo.Size = new System.Drawing.Size(107, 22);
            this.txtEstoqueMinimo.TabIndex = 1011;
            this.txtEstoqueMinimo.Enter += new System.EventHandler(this.txtEstoqueMinimo_Enter);
            // 
            // txtValorVendaVarejo
            // 
            this.txtValorVendaVarejo.Location = new System.Drawing.Point(191, 103);
            this.txtValorVendaVarejo.Name = "txtValorVendaVarejo";
            this.txtValorVendaVarejo.Size = new System.Drawing.Size(87, 22);
            this.txtValorVendaVarejo.TabIndex = 1031;
            this.txtValorVendaVarejo.Enter += new System.EventHandler(this.txtValorVendaVarejo_Enter);
            // 
            // lblValorVendaVarejo
            // 
            this.lblValorVendaVarejo.AutoSize = true;
            this.lblValorVendaVarejo.Location = new System.Drawing.Point(8, 108);
            this.lblValorVendaVarejo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorVendaVarejo.Name = "lblValorVendaVarejo";
            this.lblValorVendaVarejo.Size = new System.Drawing.Size(131, 17);
            this.lblValorVendaVarejo.TabIndex = 1028;
            this.lblValorVendaVarejo.Text = "Valor Venda Varejo";
            // 
            // txtIPIPercentual
            // 
            this.txtIPIPercentual.Location = new System.Drawing.Point(258, 25);
            this.txtIPIPercentual.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPIPercentual.MaxLength = 10;
            this.txtIPIPercentual.Name = "txtIPIPercentual";
            this.txtIPIPercentual.Size = new System.Drawing.Size(121, 22);
            this.txtIPIPercentual.TabIndex = 1020;
            this.txtIPIPercentual.Enter += new System.EventHandler(this.txtIPIPercentual_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 1019;
            this.label2.Text = "Percentual de IPI ( % )";
            // 
            // gpbOutrosDados
            // 
            this.gpbOutrosDados.Controls.Add(this.txtPercentualDescontoAtacado);
            this.gpbOutrosDados.Controls.Add(this.lblPercentualDescontoAtacado);
            this.gpbOutrosDados.Controls.Add(this.cmbComissao);
            this.gpbOutrosDados.Controls.Add(this.lblComissao);
            this.gpbOutrosDados.Controls.Add(this.txtOutrasDespesasPercentual);
            this.gpbOutrosDados.Controls.Add(this.lblPercentualOutrasDespesas);
            this.gpbOutrosDados.Controls.Add(this.txtFretePercentual);
            this.gpbOutrosDados.Controls.Add(this.lblFretePercentual);
            this.gpbOutrosDados.Controls.Add(this.txtEmbalagemPercentual);
            this.gpbOutrosDados.Controls.Add(this.lblPercentualEmbalagem);
            this.gpbOutrosDados.Controls.Add(this.txtIPIPercentual);
            this.gpbOutrosDados.Controls.Add(this.label2);
            this.gpbOutrosDados.Location = new System.Drawing.Point(510, 134);
            this.gpbOutrosDados.Margin = new System.Windows.Forms.Padding(4);
            this.gpbOutrosDados.Name = "gpbOutrosDados";
            this.gpbOutrosDados.Padding = new System.Windows.Forms.Padding(4);
            this.gpbOutrosDados.Size = new System.Drawing.Size(512, 237);
            this.gpbOutrosDados.TabIndex = 1021;
            this.gpbOutrosDados.TabStop = false;
            this.gpbOutrosDados.Text = "Outras Informações";
            // 
            // txtPercentualDescontoAtacado
            // 
            this.txtPercentualDescontoAtacado.Location = new System.Drawing.Point(258, 144);
            this.txtPercentualDescontoAtacado.Name = "txtPercentualDescontoAtacado";
            this.txtPercentualDescontoAtacado.Size = new System.Drawing.Size(87, 22);
            this.txtPercentualDescontoAtacado.TabIndex = 1041;
            this.txtPercentualDescontoAtacado.Enter += new System.EventHandler(this.txtPercentualDescontoAtacado_Enter);
            // 
            // lblPercentualDescontoAtacado
            // 
            this.lblPercentualDescontoAtacado.AutoSize = true;
            this.lblPercentualDescontoAtacado.Location = new System.Drawing.Point(16, 149);
            this.lblPercentualDescontoAtacado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualDescontoAtacado.Name = "lblPercentualDescontoAtacado";
            this.lblPercentualDescontoAtacado.Size = new System.Drawing.Size(230, 17);
            this.lblPercentualDescontoAtacado.TabIndex = 1040;
            this.lblPercentualDescontoAtacado.Text = "Percentual Desconto Atacado ( % )";
            // 
            // cmbComissao
            // 
            this.cmbComissao.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbComissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComissao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbComissao.FormattingEnabled = true;
            this.cmbComissao.Location = new System.Drawing.Point(258, 118);
            this.cmbComissao.Margin = new System.Windows.Forms.Padding(4);
            this.cmbComissao.Name = "cmbComissao";
            this.cmbComissao.Size = new System.Drawing.Size(254, 24);
            this.cmbComissao.TabIndex = 1018;
            // 
            // lblComissao
            // 
            this.lblComissao.AutoSize = true;
            this.lblComissao.Location = new System.Drawing.Point(16, 125);
            this.lblComissao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComissao.Name = "lblComissao";
            this.lblComissao.Size = new System.Drawing.Size(69, 17);
            this.lblComissao.TabIndex = 1027;
            this.lblComissao.Text = "Comissão";
            // 
            // txtOutrasDespesasPercentual
            // 
            this.txtOutrasDespesasPercentual.Location = new System.Drawing.Point(258, 94);
            this.txtOutrasDespesasPercentual.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutrasDespesasPercentual.MaxLength = 10;
            this.txtOutrasDespesasPercentual.Name = "txtOutrasDespesasPercentual";
            this.txtOutrasDespesasPercentual.Size = new System.Drawing.Size(121, 22);
            this.txtOutrasDespesasPercentual.TabIndex = 1026;
            this.txtOutrasDespesasPercentual.Enter += new System.EventHandler(this.txtOutrasDespesasPercentual_Enter);
            // 
            // lblPercentualOutrasDespesas
            // 
            this.lblPercentualOutrasDespesas.AutoSize = true;
            this.lblPercentualOutrasDespesas.Location = new System.Drawing.Point(16, 99);
            this.lblPercentualOutrasDespesas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualOutrasDespesas.Name = "lblPercentualOutrasDespesas";
            this.lblPercentualOutrasDespesas.Size = new System.Drawing.Size(244, 17);
            this.lblPercentualOutrasDespesas.TabIndex = 1025;
            this.lblPercentualOutrasDespesas.Text = "Percentual de Outras Despesas ( % )";
            // 
            // txtFretePercentual
            // 
            this.txtFretePercentual.Location = new System.Drawing.Point(258, 71);
            this.txtFretePercentual.Margin = new System.Windows.Forms.Padding(4);
            this.txtFretePercentual.MaxLength = 10;
            this.txtFretePercentual.Name = "txtFretePercentual";
            this.txtFretePercentual.Size = new System.Drawing.Size(121, 22);
            this.txtFretePercentual.TabIndex = 1024;
            this.txtFretePercentual.Enter += new System.EventHandler(this.txtFretePercentual_Enter);
            // 
            // lblFretePercentual
            // 
            this.lblFretePercentual.AutoSize = true;
            this.lblFretePercentual.Location = new System.Drawing.Point(16, 76);
            this.lblFretePercentual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFretePercentual.Name = "lblFretePercentual";
            this.lblFretePercentual.Size = new System.Drawing.Size(167, 17);
            this.lblFretePercentual.TabIndex = 1023;
            this.lblFretePercentual.Text = "Percentual de Frete ( % )";
            // 
            // txtEmbalagemPercentual
            // 
            this.txtEmbalagemPercentual.Location = new System.Drawing.Point(258, 48);
            this.txtEmbalagemPercentual.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmbalagemPercentual.MaxLength = 10;
            this.txtEmbalagemPercentual.Name = "txtEmbalagemPercentual";
            this.txtEmbalagemPercentual.Size = new System.Drawing.Size(121, 22);
            this.txtEmbalagemPercentual.TabIndex = 1022;
            this.txtEmbalagemPercentual.Enter += new System.EventHandler(this.txtEmbalagemPercentual_Enter);
            // 
            // lblPercentualEmbalagem
            // 
            this.lblPercentualEmbalagem.AutoSize = true;
            this.lblPercentualEmbalagem.Location = new System.Drawing.Point(16, 53);
            this.lblPercentualEmbalagem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentualEmbalagem.Name = "lblPercentualEmbalagem";
            this.lblPercentualEmbalagem.Size = new System.Drawing.Size(208, 17);
            this.lblPercentualEmbalagem.TabIndex = 1021;
            this.lblPercentualEmbalagem.Text = "Percentual de Embalagem ( % )";
            // 
            // lblUnidadeMedidaEstoque
            // 
            this.lblUnidadeMedidaEstoque.AutoSize = true;
            this.lblUnidadeMedidaEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidadeMedidaEstoque.Location = new System.Drawing.Point(305, 54);
            this.lblUnidadeMedidaEstoque.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnidadeMedidaEstoque.Name = "lblUnidadeMedidaEstoque";
            this.lblUnidadeMedidaEstoque.Size = new System.Drawing.Size(0, 17);
            this.lblUnidadeMedidaEstoque.TabIndex = 1043;
            // 
            // GuardarProdutoFilial
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1036, 381);
            this.Controls.Add(this.gpbOutrosDados);
            this.Controls.Add(this.gpbNumeroVenda);
            this.Controls.Add(this.txtDescricaoPrateleira);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuardarProdutoFilial";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurações de Produtos";
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtDescricaoPrateleira, 0);
            this.Controls.SetChildIndex(this.gpbNumeroVenda, 0);
            this.Controls.SetChildIndex(this.gpbOutrosDados, 0);
            this.gpbNumeroVenda.ResumeLayout(false);
            this.gpbNumeroVenda.PerformLayout();
            this.gpbOutrosDados.ResumeLayout(false);
            this.gpbOutrosDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricaoPrateleira;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblNumeroMinimoVenda;
        private System.Windows.Forms.TextBox txtNumeroMinimo;
        private System.Windows.Forms.GroupBox gpbNumeroVenda;
        private System.Windows.Forms.Label lblUnidadeMedidaVenda;
        private System.Windows.Forms.Label lblNumeroEstoqueMinimo;
        private System.Windows.Forms.TextBox txtEstoqueMinimo;
        private System.Windows.Forms.TextBox txtIPIPercentual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbOutrosDados;
        private System.Windows.Forms.TextBox txtOutrasDespesasPercentual;
        private System.Windows.Forms.Label lblPercentualOutrasDespesas;
        private System.Windows.Forms.TextBox txtFretePercentual;
        private System.Windows.Forms.Label lblFretePercentual;
        private System.Windows.Forms.TextBox txtEmbalagemPercentual;
        private System.Windows.Forms.Label lblPercentualEmbalagem;
        private System.Windows.Forms.ComboBox cmbComissao;
        private System.Windows.Forms.Label lblComissao;
        private System.Windows.Forms.TextBox txtQntVendaAtacado;
        private System.Windows.Forms.TextBox txtValorVendaAtacado;
        private System.Windows.Forms.TextBox txtValorVendaVarejo;
        private System.Windows.Forms.Label lblQuantidadeVendaAtacado;
        private System.Windows.Forms.Label lblValorVendaAtacado;
        private System.Windows.Forms.Label lblValorVendaVarejo;
        private System.Windows.Forms.ComboBox cmbUMQntAtacado;
        private System.Windows.Forms.ComboBox cmbUMVendaAtacado;
        private System.Windows.Forms.ComboBox cmbUMVendaVarejo;
        private System.Windows.Forms.TextBox txtPercentualDescontoAtacado;
        private System.Windows.Forms.Label lblPercentualDescontoAtacado;
        private System.Windows.Forms.ComboBox cmbSetorPreparo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUnidadeMedidaEstoque;
    }
}