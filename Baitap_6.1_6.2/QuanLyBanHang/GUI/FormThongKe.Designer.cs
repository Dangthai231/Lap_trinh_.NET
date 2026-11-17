namespace QuanLyBanHang.GUI
{
    partial class FormThongKe
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
            grpDoanhThu = new GroupBox();
            lblNgay = new Label();
            dtpNgay = new DateTimePicker();
            lblDoanhThuNgay = new Label();
            lblThang = new Label();
            dtpThang = new DateTimePicker();
            lblDoanhThuThang = new Label();
            btnLamMoi = new Button();
            grpTop5 = new GroupBox();
            lsvTop5 = new ListView();
            colHang = new ColumnHeader();
            colMaSP = new ColumnHeader();
            colTenSP = new ColumnHeader();
            colSoLuong = new ColumnHeader();
            colDoanhThu = new ColumnHeader();
            grpDoanhThu.SuspendLayout();
            grpTop5.SuspendLayout();
            SuspendLayout();
            //
            // grpDoanhThu
            //
            grpDoanhThu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDoanhThu.Controls.Add(lblNgay);
            grpDoanhThu.Controls.Add(dtpNgay);
            grpDoanhThu.Controls.Add(lblDoanhThuNgay);
            grpDoanhThu.Controls.Add(lblThang);
            grpDoanhThu.Controls.Add(dtpThang);
            grpDoanhThu.Controls.Add(lblDoanhThuThang);
            grpDoanhThu.Controls.Add(btnLamMoi);
            grpDoanhThu.Location = new Point(12, 12);
            grpDoanhThu.Name = "grpDoanhThu";
            grpDoanhThu.Size = new Size(776, 112);
            grpDoanhThu.TabIndex = 0;
            grpDoanhThu.TabStop = false;
            grpDoanhThu.Text = "Doanh thu (ExecuteScalar)";
            //
            // lblNgay
            //
            lblNgay.AutoSize = true;
            lblNgay.Location = new Point(16, 34);
            lblNgay.Name = "lblNgay";
            lblNgay.Text = "Ngày:";
            //
            // dtpNgay
            //
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(106, 30);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(120, 23);
            dtpNgay.TabIndex = 0;
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            //
            // lblDoanhThuNgay
            //
            lblDoanhThuNgay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoanhThuNgay.ForeColor = Color.DarkGreen;
            lblDoanhThuNgay.Location = new Point(246, 32);
            lblDoanhThuNgay.Name = "lblDoanhThuNgay";
            lblDoanhThuNgay.Size = new Size(420, 20);
            lblDoanhThuNgay.Text = "Doanh thu ngày: 0 đ";
            //
            // lblThang
            //
            lblThang.AutoSize = true;
            lblThang.Location = new Point(16, 72);
            lblThang.Name = "lblThang";
            lblThang.Text = "Tháng / Năm:";
            //
            // dtpThang
            //
            dtpThang.CustomFormat = "MM/yyyy";
            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.Location = new Point(106, 68);
            dtpThang.Name = "dtpThang";
            dtpThang.ShowUpDown = true;
            dtpThang.Size = new Size(120, 23);
            dtpThang.TabIndex = 1;
            dtpThang.ValueChanged += dtpThang_ValueChanged;
            //
            // lblDoanhThuThang
            //
            lblDoanhThuThang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoanhThuThang.ForeColor = Color.SteelBlue;
            lblDoanhThuThang.Location = new Point(246, 70);
            lblDoanhThuThang.Name = "lblDoanhThuThang";
            lblDoanhThuThang.Size = new Size(420, 20);
            lblDoanhThuThang.Text = "Doanh thu tháng: 0 đ";
            //
            // btnLamMoi
            //
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(664, 30);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(96, 32);
            btnLamMoi.TabIndex = 2;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // grpTop5
            //
            grpTop5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpTop5.Controls.Add(lsvTop5);
            grpTop5.Location = new Point(12, 134);
            grpTop5.Name = "grpTop5";
            grpTop5.Size = new Size(776, 250);
            grpTop5.TabIndex = 1;
            grpTop5.TabStop = false;
            grpTop5.Text = "Top 5 sản phẩm bán chạy nhất (SqlDataReader)";
            //
            // lsvTop5
            //
            lsvTop5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsvTop5.Columns.AddRange(new ColumnHeader[] { colHang, colMaSP, colTenSP, colSoLuong, colDoanhThu });
            lsvTop5.FullRowSelect = true;
            lsvTop5.GridLines = true;
            lsvTop5.Location = new Point(12, 24);
            lsvTop5.Name = "lsvTop5";
            lsvTop5.Size = new Size(752, 214);
            lsvTop5.TabIndex = 0;
            lsvTop5.UseCompatibleStateImageBehavior = false;
            lsvTop5.View = View.Details;
            //
            // colHang
            //
            colHang.Text = "Hạng";
            colHang.TextAlign = HorizontalAlignment.Center;
            colHang.Width = 60;
            //
            // colMaSP
            //
            colMaSP.Text = "Mã SP";
            colMaSP.Width = 130;
            //
            // colTenSP
            //
            colTenSP.Text = "Tên sản phẩm";
            colTenSP.Width = 280;
            //
            // colSoLuong
            //
            colSoLuong.Text = "SL đã bán";
            colSoLuong.TextAlign = HorizontalAlignment.Center;
            colSoLuong.Width = 100;
            //
            // colDoanhThu
            //
            colDoanhThu.Text = "Doanh thu (đ)";
            colDoanhThu.TextAlign = HorizontalAlignment.Right;
            colDoanhThu.Width = 150;
            //
            // FormThongKe
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 396);
            Controls.Add(grpDoanhThu);
            Controls.Add(grpTop5);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(816, 400);
            Name = "FormThongKe";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Báo cáo - Thống kê";
            Load += FormThongKe_Load;
            grpDoanhThu.ResumeLayout(false);
            grpDoanhThu.PerformLayout();
            grpTop5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDoanhThu;
        private Label lblNgay;
        private DateTimePicker dtpNgay;
        private Label lblDoanhThuNgay;
        private Label lblThang;
        private DateTimePicker dtpThang;
        private Label lblDoanhThuThang;
        private Button btnLamMoi;
        private GroupBox grpTop5;
        private ListView lsvTop5;
        private ColumnHeader colHang;
        private ColumnHeader colMaSP;
        private ColumnHeader colTenSP;
        private ColumnHeader colSoLuong;
        private ColumnHeader colDoanhThu;
    }
}
