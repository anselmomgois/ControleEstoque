﻿namespace Informatiz.ControleEstoque.Aplicacao.Telas.Venda
{
    partial class InformarMesaAtendenteTouch
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
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.gpbMesa = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chlMesas = new System.Windows.Forms.CheckedListBox();
            this.tlpPrincipal.SuspendLayout();
            this.gpbMesa.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlClientes, 0, 0);
            this.tlpPrincipal.Controls.Add(this.gpbMesa, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tlpPrincipal.Size = new System.Drawing.Size(691, 360);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // pnlClientes
            // 
            this.pnlClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlClientes.Location = new System.Drawing.Point(2, 2);
            this.pnlClientes.Margin = new System.Windows.Forms.Padding(2);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(687, 131);
            this.pnlClientes.TabIndex = 1;
            // 
            // gpbMesa
            // 
            this.gpbMesa.Controls.Add(this.tableLayoutPanel1);
            this.gpbMesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbMesa.Location = new System.Drawing.Point(2, 137);
            this.gpbMesa.Margin = new System.Windows.Forms.Padding(2);
            this.gpbMesa.Name = "gpbMesa";
            this.gpbMesa.Padding = new System.Windows.Forms.Padding(2);
            this.gpbMesa.Size = new System.Drawing.Size(687, 221);
            this.gpbMesa.TabIndex = 2;
            this.gpbMesa.TabStop = false;
            this.gpbMesa.Text = "Mesa";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chlMesas, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(683, 204);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chlMesas
            // 
            this.chlMesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlMesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chlMesas.FormattingEnabled = true;
            this.chlMesas.Location = new System.Drawing.Point(2, 2);
            this.chlMesas.Margin = new System.Windows.Forms.Padding(2);
            this.chlMesas.Name = "chlMesas";
            this.chlMesas.Size = new System.Drawing.Size(679, 200);
            this.chlMesas.TabIndex = 0;
            // 
            // InformarMesaAtendenteTouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 496);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformarMesaAtendenteTouch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atendente / Mesa";
            this.tlpPrincipal.ResumeLayout(false);
            this.gpbMesa.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.GroupBox gpbMesa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.CheckedListBox chlMesas;
    }
}