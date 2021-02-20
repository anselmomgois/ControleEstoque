namespace Informatiz.ControleEstoque.Server.Telas
{
    partial class LogExecucao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpbLog = new System.Windows.Forms.GroupBox();
            this.dgvCores = new System.Windows.Forms.DataGridView();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbLog
            // 
            this.gpbLog.Controls.Add(this.dgvCores);
            this.gpbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbLog.Location = new System.Drawing.Point(0, 0);
            this.gpbLog.Name = "gpbLog";
            this.gpbLog.Size = new System.Drawing.Size(1081, 394);
            this.gpbLog.TabIndex = 0;
            this.gpbLog.TabStop = false;
            this.gpbLog.Text = "Log Execuções";
            // 
            // dgvCores
            // 
            this.dgvCores.AllowUserToAddRows = false;
            this.dgvCores.AllowUserToDeleteRows = false;
            this.dgvCores.AllowUserToOrderColumns = true;
            this.dgvCores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colData,
            this.colLog});
            this.dgvCores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCores.Location = new System.Drawing.Point(3, 18);
            this.dgvCores.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCores.Name = "dgvCores";
            this.dgvCores.ReadOnly = true;
            this.dgvCores.Size = new System.Drawing.Size(1075, 373);
            this.dgvCores.TabIndex = 7;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colData.FillWeight = 150F;
            this.colData.HeaderText = " Data e Hora";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 150;
            // 
            // colLog
            // 
            this.colLog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colLog.DefaultCellStyle = dataGridViewCellStyle1;
            this.colLog.FillWeight = 150F;
            this.colLog.HeaderText = "Log";
            this.colLog.Name = "colLog";
            this.colLog.ReadOnly = true;
            this.colLog.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LogExecucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 530);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LogExecucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LogExecucao";
            this.gpbLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbLog;
        private System.Windows.Forms.DataGridView dgvCores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLog;
    }
}