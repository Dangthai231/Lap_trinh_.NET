namespace bai4
{
    partial class Form1
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
            this.flpSoDo = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbKhungGio = new System.Windows.Forms.ComboBox();
            this.lblSoViTri = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuyChon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flpSoDo
            // 
            this.flpSoDo.Location = new System.Drawing.Point(112, 72);
            this.flpSoDo.Name = "flpSoDo";
            this.flpSoDo.Size = new System.Drawing.Size(565, 368);
            this.flpSoDo.TabIndex = 0;
            // 
            // cmbKhungGio
            // 
            this.cmbKhungGio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhungGio.FormattingEnabled = true;
            this.cmbKhungGio.Items.AddRange(new object[] {
            "Sáng,",
            "Tối"});
            this.cmbKhungGio.Location = new System.Drawing.Point(684, 72);
            this.cmbKhungGio.Name = "cmbKhungGio";
            this.cmbKhungGio.Size = new System.Drawing.Size(260, 24);
            this.cmbKhungGio.TabIndex = 1;
            this.cmbKhungGio.SelectedIndexChanged += new System.EventHandler(this.cmbKhungGio_SelectedIndexChanged);
            // 
            // lblSoViTri
            // 
            this.lblSoViTri.AutoSize = true;
            this.lblSoViTri.Location = new System.Drawing.Point(683, 111);
            this.lblSoViTri.Name = "lblSoViTri";
            this.lblSoViTri.Size = new System.Drawing.Size(129, 16);
            this.lblSoViTri.TabIndex = 5;
            this.lblSoViTri.Text = "Số vị trí đang chọn: 0";
            this.lblSoViTri.Click += new System.EventHandler(this.lblSoViTri_Click);
            // 
            // lblTamTinh
            // 
            this.lblTamTinh.AutoSize = true;
            this.lblTamTinh.Location = new System.Drawing.Point(818, 111);
            this.lblTamTinh.Name = "lblTamTinh";
            this.lblTamTinh.Size = new System.Drawing.Size(126, 16);
            this.lblTamTinh.TabIndex = 6;
            this.lblTamTinh.Text = "Tạm tính tiền: 0 VNĐ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(686, 143);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(108, 23);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "Xác nhận đặt";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click_1);
            // 
            // btnHuyChon
            // 
            this.btnHuyChon.Location = new System.Drawing.Point(816, 143);
            this.btnHuyChon.Name = "btnHuyChon";
            this.btnHuyChon.Size = new System.Drawing.Size(128, 23);
            this.btnHuyChon.TabIndex = 8;
            this.btnHuyChon.Text = "Hủy chọn tất cả";
            this.btnHuyChon.UseVisualStyleBackColor = true;
            this.btnHuyChon.Click += new System.EventHandler(this.btnHuyChon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 478);
            this.Controls.Add(this.btnHuyChon);
            this.Controls.Add(this.lblSoViTri);
            this.Controls.Add(this.cmbKhungGio);
            this.Controls.Add(this.lblTamTinh);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.flpSoDo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSoDo;
        private System.Windows.Forms.ComboBox cmbKhungGio;
        private System.Windows.Forms.Label lblSoViTri;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuyChon;
    }
}

