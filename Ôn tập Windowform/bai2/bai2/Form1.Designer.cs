namespace bai2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNguoiYeuCau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayGhiNhan = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radThap = new System.Windows.Forms.RadioButton();
            this.radTrungBinh = new System.Windows.Forms.RadioButton();
            this.radKhanCap = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLoaiSuCo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDienThoai = new System.Windows.Forms.CheckBox();
            this.chkMayIn = new System.Windows.Forms.CheckBox();
            this.chkLaptop = new System.Windows.Forms.CheckBox();
            this.chkMayTinhBan = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picAnhLoi = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTaiAnh = new System.Windows.Forms.Button();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(151, 13);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(100, 22);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Người yêu cầu";
            // 
            // txtNguoiYeuCau
            // 
            this.txtNguoiYeuCau.Location = new System.Drawing.Point(151, 45);
            this.txtNguoiYeuCau.Name = "txtNguoiYeuCau";
            this.txtNguoiYeuCau.Size = new System.Drawing.Size(100, 22);
            this.txtNguoiYeuCau.TabIndex = 3;
            this.txtNguoiYeuCau.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày ghi nhận";
            // 
            // dtpNgayGhiNhan
            // 
            this.dtpNgayGhiNhan.Location = new System.Drawing.Point(151, 75);
            this.dtpNgayGhiNhan.Name = "dtpNgayGhiNhan";
            this.dtpNgayGhiNhan.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayGhiNhan.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radThap);
            this.groupBox1.Controls.Add(this.radTrungBinh);
            this.groupBox1.Controls.Add(this.radKhanCap);
            this.groupBox1.Location = new System.Drawing.Point(50, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 116);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mức độ ưu tiên";
            // 
            // radThap
            // 
            this.radThap.AutoSize = true;
            this.radThap.Location = new System.Drawing.Point(6, 21);
            this.radThap.Name = "radThap";
            this.radThap.Size = new System.Drawing.Size(60, 20);
            this.radThap.TabIndex = 7;
            this.radThap.TabStop = true;
            this.radThap.Text = "Thấp";
            this.radThap.UseVisualStyleBackColor = true;
            // 
            // radTrungBinh
            // 
            this.radTrungBinh.AutoSize = true;
            this.radTrungBinh.Location = new System.Drawing.Point(6, 47);
            this.radTrungBinh.Name = "radTrungBinh";
            this.radTrungBinh.Size = new System.Drawing.Size(91, 20);
            this.radTrungBinh.TabIndex = 8;
            this.radTrungBinh.TabStop = true;
            this.radTrungBinh.Text = "Trung bình";
            this.radTrungBinh.UseVisualStyleBackColor = true;
            // 
            // radKhanCap
            // 
            this.radKhanCap.AutoSize = true;
            this.radKhanCap.Location = new System.Drawing.Point(6, 73);
            this.radKhanCap.Name = "radKhanCap";
            this.radKhanCap.Size = new System.Drawing.Size(84, 20);
            this.radKhanCap.TabIndex = 9;
            this.radKhanCap.TabStop = true;
            this.radKhanCap.Text = "Khẩn cấp";
            this.radKhanCap.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Loại sự cố";
            // 
            // cmbLoaiSuCo
            // 
            this.cmbLoaiSuCo.FormattingEnabled = true;
            this.cmbLoaiSuCo.Items.AddRange(new object[] {
            "Phần cứng, ",
            "Phần mềm, ",
            "Mạng, Tài khoản"});
            this.cmbLoaiSuCo.Location = new System.Drawing.Point(537, 21);
            this.cmbLoaiSuCo.Name = "cmbLoaiSuCo";
            this.cmbLoaiSuCo.Size = new System.Drawing.Size(121, 24);
            this.cmbLoaiSuCo.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDienThoai);
            this.groupBox2.Controls.Add(this.chkMayIn);
            this.groupBox2.Controls.Add(this.chkLaptop);
            this.groupBox2.Controls.Add(this.chkMayTinhBan);
            this.groupBox2.Location = new System.Drawing.Point(537, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 153);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thiết bị ảnh hưởng";
            // 
            // chkDienThoai
            // 
            this.chkDienThoai.AutoSize = true;
            this.chkDienThoai.Location = new System.Drawing.Point(6, 102);
            this.chkDienThoai.Name = "chkDienThoai";
            this.chkDienThoai.Size = new System.Drawing.Size(88, 20);
            this.chkDienThoai.TabIndex = 3;
            this.chkDienThoai.Text = "Điện thoại";
            this.chkDienThoai.UseVisualStyleBackColor = true;
            // 
            // chkMayIn
            // 
            this.chkMayIn.AutoSize = true;
            this.chkMayIn.Location = new System.Drawing.Point(7, 76);
            this.chkMayIn.Name = "chkMayIn";
            this.chkMayIn.Size = new System.Drawing.Size(68, 20);
            this.chkMayIn.TabIndex = 2;
            this.chkMayIn.Text = "Máy in";
            this.chkMayIn.UseVisualStyleBackColor = true;
            // 
            // chkLaptop
            // 
            this.chkLaptop.AutoSize = true;
            this.chkLaptop.Location = new System.Drawing.Point(7, 49);
            this.chkLaptop.Name = "chkLaptop";
            this.chkLaptop.Size = new System.Drawing.Size(71, 20);
            this.chkLaptop.TabIndex = 1;
            this.chkLaptop.Text = "Laptop";
            this.chkLaptop.UseVisualStyleBackColor = true;
            // 
            // chkMayTinhBan
            // 
            this.chkMayTinhBan.AutoSize = true;
            this.chkMayTinhBan.Location = new System.Drawing.Point(7, 22);
            this.chkMayTinhBan.Name = "chkMayTinhBan";
            this.chkMayTinhBan.Size = new System.Drawing.Size(104, 20);
            this.chkMayTinhBan.TabIndex = 0;
            this.chkMayTinhBan.Text = "Máy tính bàn";
            this.chkMayTinhBan.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(410, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Thiết bị ảnh hưởng";
            // 
            // picAnhLoi
            // 
            this.picAnhLoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnhLoi.Location = new System.Drawing.Point(537, 252);
            this.picAnhLoi.Name = "picAnhLoi";
            this.picAnhLoi.Size = new System.Drawing.Size(100, 50);
            this.picAnhLoi.TabIndex = 14;
            this.picAnhLoi.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ảnh chụp lỗi";
            // 
            // btnTaiAnh
            // 
            this.btnTaiAnh.Location = new System.Drawing.Point(527, 329);
            this.btnTaiAnh.Name = "btnTaiAnh";
            this.btnTaiAnh.Size = new System.Drawing.Size(121, 23);
            this.btnTaiAnh.TabIndex = 17;
            this.btnTaiAnh.Text = "Tải ảnh lỗi";
            this.btnTaiAnh.UseVisualStyleBackColor = true;
            this.btnTaiAnh.Click += new System.EventHandler(this.btnTaiAnh_Click);
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.Location = new System.Drawing.Point(50, 376);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(97, 23);
            this.btnGuiYeuCau.TabIndex = 18;
            this.btnGuiYeuCau.Text = "Gửi yêu cầu";
            this.btnGuiYeuCau.UseVisualStyleBackColor = true;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(153, 376);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(75, 23);
            this.btnNhapLai.TabIndex = 19;
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            this.btnNhapLai.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNhapLai);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.btnTaiAnh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picAnhLoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbLoaiSuCo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpNgayGhiNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNguoiYeuCau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaPhieu);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNguoiYeuCau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayGhiNhan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radThap;
        private System.Windows.Forms.RadioButton radTrungBinh;
        private System.Windows.Forms.RadioButton radKhanCap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLoaiSuCo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDienThoai;
        private System.Windows.Forms.CheckBox chkMayIn;
        private System.Windows.Forms.CheckBox chkLaptop;
        private System.Windows.Forms.CheckBox chkMayTinhBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picAnhLoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTaiAnh;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.Button btnNhapLai;
    }
}

