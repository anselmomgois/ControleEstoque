namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    partial class GuardarPergunta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardarPergunta));
            this.lblPergunta = new System.Windows.Forms.Label();
            this.txtPergunta = new System.Windows.Forms.TextBox();
            this.lblTipoPergunta = new System.Windows.Forms.Label();
            this.ddlTipoPergunta = new System.Windows.Forms.ComboBox();
            this.lblRespostaObrigatoria = new System.Windows.Forms.Label();
            this.chkObrigatorio = new System.Windows.Forms.CheckBox();
            this.lblSomenteNumeros = new System.Windows.Forms.Label();
            this.chkSomenteNumeros = new System.Windows.Forms.CheckBox();
            this.gpbOpcoes = new System.Windows.Forms.GroupBox();
            this.dgvPerguntas = new System.Windows.Forms.DataGridView();
            this.colIdentificadorPerguntaProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPergunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarPergunta = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExcluirPergunta = new System.Windows.Forms.DataGridViewImageColumn();
            this.gpbOpcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPergunta
            // 
            this.lblPergunta.AutoSize = true;
            this.lblPergunta.Location = new System.Drawing.Point(10, 155);
            this.lblPergunta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPergunta.Name = "lblPergunta";
            this.lblPergunta.Size = new System.Drawing.Size(66, 17);
            this.lblPergunta.TabIndex = 2;
            this.lblPergunta.Text = "Pergunta";
            // 
            // txtPergunta
            // 
            this.txtPergunta.Location = new System.Drawing.Point(136, 20);
            this.txtPergunta.Margin = new System.Windows.Forms.Padding(4);
            this.txtPergunta.MaxLength = 4000;
            this.txtPergunta.Multiline = true;
            this.txtPergunta.Name = "txtPergunta";
            this.txtPergunta.Size = new System.Drawing.Size(441, 155);
            this.txtPergunta.TabIndex = 3;
            // 
            // lblTipoPergunta
            // 
            this.lblTipoPergunta.AutoSize = true;
            this.lblTipoPergunta.Location = new System.Drawing.Point(10, 190);
            this.lblTipoPergunta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoPergunta.Name = "lblTipoPergunta";
            this.lblTipoPergunta.Size = new System.Drawing.Size(118, 17);
            this.lblTipoPergunta.TabIndex = 4;
            this.lblTipoPergunta.Text = "Tipo de Pergunta";
            // 
            // ddlTipoPergunta
            // 
            this.ddlTipoPergunta.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ddlTipoPergunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipoPergunta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddlTipoPergunta.FormattingEnabled = true;
            this.ddlTipoPergunta.Location = new System.Drawing.Point(136, 183);
            this.ddlTipoPergunta.Margin = new System.Windows.Forms.Padding(4);
            this.ddlTipoPergunta.Name = "ddlTipoPergunta";
            this.ddlTipoPergunta.Size = new System.Drawing.Size(441, 24);
            this.ddlTipoPergunta.TabIndex = 10;
            this.ddlTipoPergunta.SelectedIndexChanged += new System.EventHandler(this.ddlTipoPergunta_SelectedIndexChanged);
            // 
            // lblRespostaObrigatoria
            // 
            this.lblRespostaObrigatoria.AutoSize = true;
            this.lblRespostaObrigatoria.Location = new System.Drawing.Point(10, 223);
            this.lblRespostaObrigatoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRespostaObrigatoria.Name = "lblRespostaObrigatoria";
            this.lblRespostaObrigatoria.Size = new System.Drawing.Size(143, 17);
            this.lblRespostaObrigatoria.TabIndex = 11;
            this.lblRespostaObrigatoria.Text = "Resposta Obrigatória";
            // 
            // chkObrigatorio
            // 
            this.chkObrigatorio.AutoSize = true;
            this.chkObrigatorio.Location = new System.Drawing.Point(161, 223);
            this.chkObrigatorio.Margin = new System.Windows.Forms.Padding(4);
            this.chkObrigatorio.Name = "chkObrigatorio";
            this.chkObrigatorio.Size = new System.Drawing.Size(18, 17);
            this.chkObrigatorio.TabIndex = 12;
            this.chkObrigatorio.UseVisualStyleBackColor = true;
            // 
            // lblSomenteNumeros
            // 
            this.lblSomenteNumeros.AutoSize = true;
            this.lblSomenteNumeros.Location = new System.Drawing.Point(197, 223);
            this.lblSomenteNumeros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSomenteNumeros.Name = "lblSomenteNumeros";
            this.lblSomenteNumeros.Size = new System.Drawing.Size(232, 17);
            this.lblSomenteNumeros.TabIndex = 13;
            this.lblSomenteNumeros.Text = "Resposta Aceita Somente Números";
            // 
            // chkSomenteNumeros
            // 
            this.chkSomenteNumeros.AutoSize = true;
            this.chkSomenteNumeros.Location = new System.Drawing.Point(437, 223);
            this.chkSomenteNumeros.Margin = new System.Windows.Forms.Padding(4);
            this.chkSomenteNumeros.Name = "chkSomenteNumeros";
            this.chkSomenteNumeros.Size = new System.Drawing.Size(18, 17);
            this.chkSomenteNumeros.TabIndex = 14;
            this.chkSomenteNumeros.UseVisualStyleBackColor = true;
            // 
            // gpbOpcoes
            // 
            this.gpbOpcoes.Controls.Add(this.dgvPerguntas);
            this.gpbOpcoes.Location = new System.Drawing.Point(10, 243);
            this.gpbOpcoes.Margin = new System.Windows.Forms.Padding(4);
            this.gpbOpcoes.Name = "gpbOpcoes";
            this.gpbOpcoes.Padding = new System.Windows.Forms.Padding(4);
            this.gpbOpcoes.Size = new System.Drawing.Size(589, 144);
            this.gpbOpcoes.TabIndex = 15;
            this.gpbOpcoes.TabStop = false;
            this.gpbOpcoes.Text = "Opções";
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
            this.dgvPerguntas.Size = new System.Drawing.Size(581, 121);
            this.dgvPerguntas.TabIndex = 7;
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
            this.colEditarPergunta.FillWeight = 50F;
            this.colEditarPergunta.HeaderText = "Editar";
            this.colEditarPergunta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.edit;
            this.colEditarPergunta.Name = "colEditarPergunta";
            this.colEditarPergunta.ReadOnly = true;
            this.colEditarPergunta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEditarPergunta.Width = 50;
            // 
            // colExcluirPergunta
            // 
            this.colExcluirPergunta.FillWeight = 50F;
            this.colExcluirPergunta.HeaderText = "Excluir";
            this.colExcluirPergunta.Image = global::Informatiz.ControleEstoque.Aplicacao.Properties.Resources.x;
            this.colExcluirPergunta.Name = "colExcluirPergunta";
            this.colExcluirPergunta.ReadOnly = true;
            this.colExcluirPergunta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluirPergunta.Width = 50;
            // 
            // GuardarPergunta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(612, 530);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GuardarPergunta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pergunta";
            this.gpbOpcoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPergunta;
        private System.Windows.Forms.TextBox txtPergunta;
        private System.Windows.Forms.Label lblTipoPergunta;
        private System.Windows.Forms.ComboBox ddlTipoPergunta;
        private System.Windows.Forms.Label lblRespostaObrigatoria;
        private System.Windows.Forms.CheckBox chkObrigatorio;
        private System.Windows.Forms.Label lblSomenteNumeros;
        private System.Windows.Forms.CheckBox chkSomenteNumeros;
        private System.Windows.Forms.GroupBox gpbOpcoes;
        private System.Windows.Forms.DataGridView dgvPerguntas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificadorPerguntaProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPergunta;
        private System.Windows.Forms.DataGridViewImageColumn colEditarPergunta;
        private System.Windows.Forms.DataGridViewImageColumn colExcluirPergunta;
    }
}