namespace QuanLyBanHang.GUI
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuBanHang = new ToolStripMenuItem();
            mnuBaoCao = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuSanPham = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            mnuLapHoaDon = new ToolStripMenuItem();
            mnuThongKe = new ToolStripMenuItem();
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblSinhVien = new Label();
            pnlDoanhThu = new Panel();
            lblDoanhThuTitle = new Label();
            lblDoanhThu = new Label();
            pnlHoaDon = new Panel();
            lblHoaDonTitle = new Label();
            lblHoaDon = new Label();
            pnlSanPham = new Panel();
            lblSanPhamTitle = new Label();
            lblSanPham = new Label();
            pnlSapHet = new Panel();
            lblSapHetTitle = new Label();
            lblSapHet = new Label();
            btnBanHang = new Button();
            btnSanPham = new Button();
            btnKhachHang = new Button();
            btnNhanVien = new Button();
            btnThongKe = new Button();
            lblHuongDan = new Label();
            statusStrip1 = new StatusStrip();
            lblKetNoi = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            pnlHeader.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            //
            // menuStrip1
            //
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuDanhMuc, mnuBanHang, mnuBaoCao, mnuThoat });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 24);
            menuStrip1.TabIndex = 0;
            //
            // mnuSanPham
            //
            mnuSanPham.Name = "mnuSanPham";
            mnuSanPham.Text = "Sản phẩm";
            mnuSanPham.Click += btnSanPham_Click;
            //
            // mnuKhachHang
            //
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Text = "Khách hàng";
            mnuKhachHang.Click += btnKhachHang_Click;
            //
            // mnuNhanVien
            //
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Text = "Nhân viên";
            mnuNhanVien.Click += btnNhanVien_Click;
            //
            // mnuDanhMuc
            //
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuSanPham, mnuKhachHang, mnuNhanVien });
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Text = "Danh mục";
            //
            // mnuLapHoaDon
            //
            mnuLapHoaDon.Name = "mnuLapHoaDon";
            mnuLapHoaDon.Text = "Lập hóa đơn";
            mnuLapHoaDon.Click += btnBanHang_Click;
            //
            // mnuBanHang
            //
            mnuBanHang.DropDownItems.AddRange(new ToolStripItem[] { mnuLapHoaDon });
            mnuBanHang.Name = "mnuBanHang";
            mnuBanHang.Text = "Bán hàng";
            //
            // mnuThongKe
            //
            mnuThongKe.Name = "mnuThongKe";
            mnuThongKe.Text = "Thống kê doanh thu";
            mnuThongKe.Click += btnThongKe_Click;
            //
            // mnuBaoCao
            //
            mnuBaoCao.DropDownItems.AddRange(new ToolStripItem[] { mnuThongKe });
            mnuBaoCao.Name = "mnuBaoCao";
            mnuBaoCao.Text = "Báo cáo";
            //
            // mnuThoat
            //
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(0, 102, 153);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblSinhVien);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 24);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 70);
            pnlHeader.TabIndex = 1;
            //
            // lblTieuDe
            //
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(20, 8);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "SIÊU THỊ MINI - QUẢN LÝ BÁN HÀNG";
            //
            // lblSinhVien
            //
            lblSinhVien.AutoSize = true;
            lblSinhVien.ForeColor = Color.Gainsboro;
            lblSinhVien.Location = new Point(23, 44);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Text = "Sinh viên: Vương Thanh Thúy  |  MSV: 24810310270  |  Lớp: D19CNPM3";
            //
            // pnlDoanhThu
            //
            pnlDoanhThu.BackColor = Color.SeaGreen;
            pnlDoanhThu.Controls.Add(lblDoanhThuTitle);
            pnlDoanhThu.Controls.Add(lblDoanhThu);
            pnlDoanhThu.Location = new Point(24, 112);
            pnlDoanhThu.Name = "pnlDoanhThu";
            pnlDoanhThu.Size = new Size(204, 86);
            pnlDoanhThu.TabIndex = 2;
            //
            // lblDoanhThuTitle
            //
            lblDoanhThuTitle.AutoSize = true;
            lblDoanhThuTitle.ForeColor = Color.White;
            lblDoanhThuTitle.Location = new Point(12, 10);
            lblDoanhThuTitle.Name = "lblDoanhThuTitle";
            lblDoanhThuTitle.Text = "Doanh thu hôm nay";
            //
            // lblDoanhThu
            //
            lblDoanhThu.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblDoanhThu.ForeColor = Color.White;
            lblDoanhThu.Location = new Point(10, 36);
            lblDoanhThu.Name = "lblDoanhThu";
            lblDoanhThu.Size = new Size(186, 34);
            lblDoanhThu.Text = "...";
            //
            // pnlHoaDon
            //
            pnlHoaDon.BackColor = Color.SteelBlue;
            pnlHoaDon.Controls.Add(lblHoaDonTitle);
            pnlHoaDon.Controls.Add(lblHoaDon);
            pnlHoaDon.Location = new Point(240, 112);
            pnlHoaDon.Name = "pnlHoaDon";
            pnlHoaDon.Size = new Size(204, 86);
            pnlHoaDon.TabIndex = 3;
            //
            // lblHoaDonTitle
            //
            lblHoaDonTitle.AutoSize = true;
            lblHoaDonTitle.ForeColor = Color.White;
            lblHoaDonTitle.Location = new Point(12, 10);
            lblHoaDonTitle.Name = "lblHoaDonTitle";
            lblHoaDonTitle.Text = "Hóa đơn hôm nay";
            //
            // lblHoaDon
            //
            lblHoaDon.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHoaDon.ForeColor = Color.White;
            lblHoaDon.Location = new Point(10, 36);
            lblHoaDon.Name = "lblHoaDon";
            lblHoaDon.Size = new Size(186, 34);
            lblHoaDon.Text = "...";
            //
            // pnlSanPham
            //
            pnlSanPham.BackColor = Color.DarkOrange;
            pnlSanPham.Controls.Add(lblSanPhamTitle);
            pnlSanPham.Controls.Add(lblSanPham);
            pnlSanPham.Location = new Point(456, 112);
            pnlSanPham.Name = "pnlSanPham";
            pnlSanPham.Size = new Size(204, 86);
            pnlSanPham.TabIndex = 4;
            //
            // lblSanPhamTitle
            //
            lblSanPhamTitle.AutoSize = true;
            lblSanPhamTitle.ForeColor = Color.White;
            lblSanPhamTitle.Location = new Point(12, 10);
            lblSanPhamTitle.Name = "lblSanPhamTitle";
            lblSanPhamTitle.Text = "Số mặt hàng";
            //
            // lblSanPham
            //
            lblSanPham.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSanPham.ForeColor = Color.White;
            lblSanPham.Location = new Point(10, 36);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(186, 34);
            lblSanPham.Text = "...";
            //
            // pnlSapHet
            //
            pnlSapHet.BackColor = Color.IndianRed;
            pnlSapHet.Controls.Add(lblSapHetTitle);
            pnlSapHet.Controls.Add(lblSapHet);
            pnlSapHet.Location = new Point(672, 112);
            pnlSapHet.Name = "pnlSapHet";
            pnlSapHet.Size = new Size(204, 86);
            pnlSapHet.TabIndex = 5;
            //
            // lblSapHetTitle
            //
            lblSapHetTitle.AutoSize = true;
            lblSapHetTitle.ForeColor = Color.White;
            lblSapHetTitle.Location = new Point(12, 10);
            lblSapHetTitle.Name = "lblSapHetTitle";
            lblSapHetTitle.Text = "Sắp hết hàng (< 10)";
            //
            // lblSapHet
            //
            lblSapHet.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSapHet.ForeColor = Color.White;
            lblSapHet.Location = new Point(10, 36);
            lblSapHet.Name = "lblSapHet";
            lblSapHet.Size = new Size(186, 34);
            lblSapHet.Text = "...";
            //
            // btnBanHang
            //
            btnBanHang.BackColor = Color.SeaGreen;
            btnBanHang.FlatStyle = FlatStyle.Flat;
            btnBanHang.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBanHang.ForeColor = Color.White;
            btnBanHang.Location = new Point(24, 224);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(160, 104);
            btnBanHang.TabIndex = 10;
            btnBanHang.Text = "BÁN HÀNG";
            btnBanHang.UseVisualStyleBackColor = false;
            btnBanHang.Click += btnBanHang_Click;
            //
            // btnSanPham
            //
            btnSanPham.BackColor = Color.FromArgb(0, 102, 153);
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSanPham.ForeColor = Color.White;
            btnSanPham.Location = new Point(196, 224);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(160, 104);
            btnSanPham.TabIndex = 11;
            btnSanPham.Text = "Sản phẩm";
            btnSanPham.UseVisualStyleBackColor = false;
            btnSanPham.Click += btnSanPham_Click;
            //
            // btnKhachHang
            //
            btnKhachHang.BackColor = Color.FromArgb(0, 102, 153);
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Location = new Point(368, 224);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(160, 104);
            btnKhachHang.TabIndex = 12;
            btnKhachHang.Text = "Khách hàng";
            btnKhachHang.UseVisualStyleBackColor = false;
            btnKhachHang.Click += btnKhachHang_Click;
            //
            // btnNhanVien
            //
            btnNhanVien.BackColor = Color.FromArgb(0, 102, 153);
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(540, 224);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(160, 104);
            btnNhanVien.TabIndex = 13;
            btnNhanVien.Text = "Nhân viên";
            btnNhanVien.UseVisualStyleBackColor = false;
            btnNhanVien.Click += btnNhanVien_Click;
            //
            // btnThongKe
            //
            btnThongKe.BackColor = Color.DarkOrange;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(712, 224);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(160, 104);
            btnThongKe.TabIndex = 14;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            //
            // lblHuongDan
            //
            lblHuongDan.ForeColor = Color.DimGray;
            lblHuongDan.Location = new Point(24, 344);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(852, 44);
            lblHuongDan.Text = "Chọn chức năng ở các nút phía trên hoặc ở thanh menu. Số liệu trên các ô màu được cập nhật mỗi khi quay lại màn hình này.";
            //
            // statusStrip1
            //
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblKetNoi });
            statusStrip1.Location = new Point(0, 398);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(900, 22);
            statusStrip1.TabIndex = 20;
            //
            // lblKetNoi
            //
            lblKetNoi.Name = "lblKetNoi";
            lblKetNoi.Text = "Đang kết nối CSDL...";
            //
            // FormMain
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 420);
            Controls.Add(pnlDoanhThu);
            Controls.Add(pnlHoaDon);
            Controls.Add(pnlSanPham);
            Controls.Add(pnlSapHet);
            Controls.Add(btnBanHang);
            Controls.Add(btnSanPham);
            Controls.Add(btnKhachHang);
            Controls.Add(btnNhanVien);
            Controls.Add(btnThongKe);
            Controls.Add(lblHuongDan);
            Controls.Add(pnlHeader);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Bán hàng - Siêu thị mini";
            Activated += FormMain_Activated;
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuBanHang;
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuSanPham;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuLapHoaDon;
        private ToolStripMenuItem mnuThongKe;
        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblSinhVien;
        private Panel pnlDoanhThu;
        private Label lblDoanhThuTitle;
        private Label lblDoanhThu;
        private Panel pnlHoaDon;
        private Label lblHoaDonTitle;
        private Label lblHoaDon;
        private Panel pnlSanPham;
        private Label lblSanPhamTitle;
        private Label lblSanPham;
        private Panel pnlSapHet;
        private Label lblSapHetTitle;
        private Label lblSapHet;
        private Button btnBanHang;
        private Button btnSanPham;
        private Button btnKhachHang;
        private Button btnNhanVien;
        private Button btnThongKe;
        private Label lblHuongDan;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblKetNoi;
    }
}
