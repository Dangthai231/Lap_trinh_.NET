namespace B3
{
    partial class frmAsyncReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Location = new System.Drawing.Point(12, 12);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(200, 40);
            this.btnLoadReport.TabIndex = 0;
            this.btnLoadReport.Text = "Tải Báo Cáo Doanh Thu";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 58);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(776, 380);
            this.dgvReport.TabIndex = 1;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.DimGray;
            this.lblNote.Location = new System.Drawing.Point(218, 25);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(350, 15);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "(Trong khi tải, bạn vẫn có thể di chuyển form hoặc mở form khác)";
            // 
            // frmAsyncReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnLoadReport);
            this.Name = "frmAsyncReport";
            this.Text = "Báo cáo Thống kê & Đồng bộ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblNote;
    }
}
