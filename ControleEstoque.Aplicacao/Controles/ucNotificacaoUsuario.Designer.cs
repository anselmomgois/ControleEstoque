namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    partial class ucNotificacaoUsuario
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblCelular = new System.Windows.Forms.Label();
            this.btnAcessar = new System.Windows.Forms.Button();
            this.lblDescricaoMostrar = new System.Windows.Forms.Label();
            this.lblClienteMostrar = new System.Windows.Forms.Label();
            this.lblFixoMostrar = new System.Windows.Forms.Label();
            this.lblCelularMostrar = new System.Windows.Forms.Label();
            this.imgcor = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgcor)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.imgcor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAcessar, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 143);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblCelularMostrar, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblFixoMostrar, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblClienteMostrar, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDescricaoMostrar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDescricao, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCliente, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTelefone, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCelular, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(232, 83);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.Black;
            this.lblDescricao.Location = new System.Drawing.Point(3, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(84, 20);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(3, 20);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(84, 20);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblTelefone
            // 
            this.lblTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefone.ForeColor = System.Drawing.Color.Black;
            this.lblTelefone.Location = new System.Drawing.Point(3, 40);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(84, 20);
            this.lblTelefone.TabIndex = 2;
            this.lblTelefone.Text = "Fixo:";
            // 
            // lblCelular
            // 
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelular.ForeColor = System.Drawing.Color.Black;
            this.lblCelular.Location = new System.Drawing.Point(3, 60);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(84, 20);
            this.lblCelular.TabIndex = 3;
            this.lblCelular.Text = "Celular:";
            // 
            // btnAcessar
            // 
            this.btnAcessar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAcessar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcessar.ForeColor = System.Drawing.Color.Black;
            this.btnAcessar.Location = new System.Drawing.Point(4, 115);
            this.btnAcessar.Name = "btnAcessar";
            this.btnAcessar.Size = new System.Drawing.Size(232, 24);
            this.btnAcessar.TabIndex = 2;
            this.btnAcessar.Text = "Visualizar";
            this.btnAcessar.UseVisualStyleBackColor = true;
            this.btnAcessar.Click += new System.EventHandler(this.btnAcessar_Click);
            // 
            // lblDescricaoMostrar
            // 
            this.lblDescricaoMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescricaoMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoMostrar.ForeColor = System.Drawing.Color.Black;
            this.lblDescricaoMostrar.Location = new System.Drawing.Point(93, 0);
            this.lblDescricaoMostrar.Name = "lblDescricaoMostrar";
            this.lblDescricaoMostrar.Size = new System.Drawing.Size(136, 20);
            this.lblDescricaoMostrar.TabIndex = 4;
            this.lblDescricaoMostrar.Text = "Descrição:";
            // 
            // lblClienteMostrar
            // 
            this.lblClienteMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClienteMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteMostrar.ForeColor = System.Drawing.Color.Black;
            this.lblClienteMostrar.Location = new System.Drawing.Point(93, 20);
            this.lblClienteMostrar.Name = "lblClienteMostrar";
            this.lblClienteMostrar.Size = new System.Drawing.Size(136, 20);
            this.lblClienteMostrar.TabIndex = 5;
            this.lblClienteMostrar.Text = "Descrição:";
            // 
            // lblFixoMostrar
            // 
            this.lblFixoMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFixoMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixoMostrar.ForeColor = System.Drawing.Color.Black;
            this.lblFixoMostrar.Location = new System.Drawing.Point(93, 40);
            this.lblFixoMostrar.Name = "lblFixoMostrar";
            this.lblFixoMostrar.Size = new System.Drawing.Size(136, 20);
            this.lblFixoMostrar.TabIndex = 6;
            this.lblFixoMostrar.Text = "Descrição:";
            // 
            // lblCelularMostrar
            // 
            this.lblCelularMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCelularMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelularMostrar.ForeColor = System.Drawing.Color.Black;
            this.lblCelularMostrar.Location = new System.Drawing.Point(93, 60);
            this.lblCelularMostrar.Name = "lblCelularMostrar";
            this.lblCelularMostrar.Size = new System.Drawing.Size(136, 23);
            this.lblCelularMostrar.TabIndex = 7;
            this.lblCelularMostrar.Text = "Descrição:";
            // 
            // imgcor
            // 
            this.imgcor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgcor.Location = new System.Drawing.Point(4, 4);
            this.imgcor.Name = "imgcor";
            this.imgcor.Size = new System.Drawing.Size(232, 14);
            this.imgcor.TabIndex = 0;
            this.imgcor.TabStop = false;
            // 
            // ucNotificacaoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(208, 143);
            this.Name = "ucNotificacaoUsuario";
            this.Size = new System.Drawing.Size(240, 143);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgcor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgcor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Button btnAcessar;
        private System.Windows.Forms.Label lblCelularMostrar;
        private System.Windows.Forms.Label lblFixoMostrar;
        private System.Windows.Forms.Label lblClienteMostrar;
        private System.Windows.Forms.Label lblDescricaoMostrar;
    }
}
