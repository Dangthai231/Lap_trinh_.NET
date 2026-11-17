namespace QuanLyNhanSu.GUI
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
            mnuNhanSu = new ToolStripMenuItem();
            mnuLuong = new ToolStripMenuItem();
            mnuBaoCao = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            mnuChamCong = new ToolStripMenuItem();
            mnuTinhLuong = new ToolStripMenuItem();
            mnuBaoCaoLuong = new ToolStripMenuItem();
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblSinhVien = new Label();
            pnlSoNV = new Panel();
            lblSoNVTitle = new Label();
            lblSoNV = new Label();
            pnlSoPB = new Panel();
            lblSoPBTitle = new Label();
            lblSoPB = new Label();
            pnlThangChot = new Panel();
            lblThangChotTitle = new Label();
            lblThangChot = new Label();
            pnlQuyLuong = new Panel();
            lblQuyLuongTitle = new Label();
            lblQuyLuong = new Label();
            btnNhanVien = new Button();
            btnChamCong = new Button();
            btnTinhLuong = new Button();
            btnBaoCao = new Button();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuNhanSu, mnuLuong, mnuBaoCao, mnuThoat });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 24);
            menuStrip1.TabIndex = 0;
            //
            // mnuNhanVien
            //
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Text = "Hồ sơ nhân viên";
            mnuNhanVien.Click += btnNhanVien_Click;
            //
            // mnuNhanSu
            //
            mnuNhanSu.DropDownItems.AddRange(new ToolStripItem[] { mnuNhanVien });
            mnuNhanSu.Name = "mnuNhanSu";
            mnuNhanSu.Text = "Nhân sự";
            //
            // mnuChamCong
            //
            mnuChamCong.Name = "mnuChamCong";
            mnuChamCong.Text = "Chấm công tháng";
            mnuChamCong.Click += btnChamCong_Click;
            //
            // mnuTinhLuong
            //
            mnuTinhLuong.Name = "mnuTinhLuong";
            mnuTinhLuong.Text = "Tính && chốt lương";
            mnuTinhLuong.Click += btnTinhLuong_Click;
            //
            // mnuLuong
            //
            mnuLuong.DropDownItems.AddRange(new ToolStripItem[] { mnuChamCong, mnuTinhLuong });
            mnuLuong.Name = "mnuLuong";
            mnuLuong.Text = "Chấm công - Lương";
            //
            // mnuBaoCaoLuong
            //
            mnuBaoCaoLuong.Name = "mnuBaoCaoLuong";
            mnuBaoCaoLuong.Text = "Báo cáo quỹ lương";
            mnuBaoCaoLuong.Click += btnBaoCao_Click;
            //
            // mnuBaoCao
            //
            mnuBaoCao.DropDownItems.AddRange(new ToolStripItem[] { mnuBaoCaoLuong });
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
            lblTieuDe.Text = "QUẢN LÝ NHÂN SỰ && TÍNH LƯƠNG";
            //
            // lblSinhVien
            //
            lblSinhVien.AutoSize = true;
            lblSinhVien.ForeColor = Color.Gainsboro;
            lblSinhVien.Location = new Point(23, 44);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Text = "Sinh viên: Vương Thanh Thúy  |  MSV: 24810310270  |  Lớp: D19CNPM3";
            //
            // pnlSoNV
            //
            pnlSoNV.BackColor = Color.SteelBlue;
            pnlSoNV.Controls.Add(lblSoNVTitle);
            pnlSoNV.Controls.Add(lblSoNV);
            pnlSoNV.Location = new Point(24, 112);
            pnlSoNV.Name = "pnlSoNV";
            pnlSoNV.Size = new Size(204, 86);
            pnlSoNV.TabIndex = 2;
            //
            // lblSoNVTitle
            //
            lblSoNVTitle.AutoSize = true;
            lblSoNVTitle.ForeColor = Color.White;
            lblSoNVTitle.Location = new Point(12, 10);
            lblSoNVTitle.Name = "lblSoNVTitle";
            lblSoNVTitle.Text = "Tổng số nhân viên";
            //
            // lblSoNV
            //
            lblSoNV.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSoNV.ForeColor = Color.White;
            lblSoNV.Location = new Point(10, 36);
            lblSoNV.Name = "lblSoNV";
            lblSoNV.Size = new Size(186, 34);
            lblSoNV.Text = "...";
            //
            // pnlSoPB
            //
            pnlSoPB.BackColor = Color.SeaGreen;
            pnlSoPB.Controls.Add(lblSoPBTitle);
            pnlSoPB.Controls.Add(lblSoPB);
            pnlSoPB.Location = new Point(240, 112);
            pnlSoPB.Name = "pnlSoPB";
            pnlSoPB.Size = new Size(204, 86);
            pnlSoPB.TabIndex = 3;
            //
            // lblSoPBTitle
            //
            lblSoPBTitle.AutoSize = true;
            lblSoPBTitle.ForeColor = Color.White;
            lblSoPBTitle.Location = new Point(12, 10);
            lblSoPBTitle.Name = "lblSoPBTitle";
            lblSoPBTitle.Text = "Số phòng ban";
            //
            // lblSoPB
            //
            lblSoPB.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSoPB.ForeColor = Color.White;
            lblSoPB.Location = new Point(10, 36);
            lblSoPB.Name = "lblSoPB";
            lblSoPB.Size = new Size(186, 34);
            lblSoPB.Text = "...";
            //
            // pnlThangChot
            //
            pnlThangChot.BackColor = Color.DarkOrange;
            pnlThangChot.Controls.Add(lblThangChotTitle);
            pnlThangChot.Controls.Add(lblThangChot);
            pnlThangChot.Location = new Point(456, 112);
            pnlThangChot.Name = "pnlThangChot";
            pnlThangChot.Size = new Size(204, 86);
            pnlThangChot.TabIndex = 4;
            //
            // lblThangChotTitle
            //
            lblThangChotTitle.AutoSize = true;
            lblThangChotTitle.ForeColor = Color.White;
            lblThangChotTitle.Location = new Point(12, 10);
            lblThangChotTitle.Name = "lblThangChotTitle";
            lblThangChotTitle.Text = "Tháng chốt gần nhất";
            //
            // lblThangChot
            //
            lblThangChot.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblThangChot.ForeColor = Color.White;
            lblThangChot.Location = new Point(10, 36);
            lblThangChot.Name = "lblThangChot";
            lblThangChot.Size = new Size(186, 34);
            lblThangChot.Text = "...";
            //
            // pnlQuyLuong
            //
            pnlQuyLuong.BackColor = Color.IndianRed;
            pnlQuyLuong.Controls.Add(lblQuyLuongTitle);
            pnlQuyLuong.Controls.Add(lblQuyLuong);
            pnlQuyLuong.Location = new Point(672, 112);
            pnlQuyLuong.Name = "pnlQuyLuong";
            pnlQuyLuong.Size = new Size(204, 86);
            pnlQuyLuong.TabIndex = 5;
            //
            // lblQuyLuongTitle
            //
            lblQuyLuongTitle.AutoSize = true;
            lblQuyLuongTitle.ForeColor = Color.White;
            lblQuyLuongTitle.Location = new Point(12, 10);
            lblQuyLuongTitle.Name = "lblQuyLuongTitle";
            lblQuyLuongTitle.Text = "Quỹ lương tháng đó";
            //
            // lblQuyLuong
            //
            lblQuyLuong.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblQuyLuong.ForeColor = Color.White;
            lblQuyLuong.Location = new Point(10, 36);
            lblQuyLuong.Name = "lblQuyLuong";
            lblQuyLuong.Size = new Size(186, 34);
            lblQuyLuong.Text = "...";
            //
            // btnNhanVien
            //
            btnNhanVien.BackColor = Color.FromArgb(0, 102, 153);
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(24, 224);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(204, 104);
            btnNhanVien.TabIndex = 10;
            btnNhanVien.Text = "Hồ sơ nhân viên";
            btnNhanVien.UseVisualStyleBackColor = false;
            btnNhanVien.Click += btnNhanVien_Click;
            //
            // btnChamCong
            //
            btnChamCong.BackColor = Color.SeaGreen;
            btnChamCong.FlatStyle = FlatStyle.Flat;
            btnChamCong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnChamCong.ForeColor = Color.White;
            btnChamCong.Location = new Point(240, 224);
            btnChamCong.Name = "btnChamCong";
            btnChamCong.Size = new Size(204, 104);
            btnChamCong.TabIndex = 11;
            btnChamCong.Text = "Chấm công";
            btnChamCong.UseVisualStyleBackColor = false;
            btnChamCong.Click += btnChamCong_Click;
            //
            // btnTinhLuong
            //
            btnTinhLuong.BackColor = Color.Firebrick;
            btnTinhLuong.FlatStyle = FlatStyle.Flat;
            btnTinhLuong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTinhLuong.ForeColor = Color.White;
            btnTinhLuong.Location = new Point(456, 224);
            btnTinhLuong.Name = "btnTinhLuong";
            btnTinhLuong.Size = new Size(204, 104);
            btnTinhLuong.TabIndex = 12;
            btnTinhLuong.Text = "Tính && chốt lương";
            btnTinhLuong.UseVisualStyleBackColor = false;
            btnTinhLuong.Click += btnTinhLuong_Click;
            //
            // btnBaoCao
            //
            btnBaoCao.BackColor = Color.DarkOrange;
            btnBaoCao.FlatStyle = FlatStyle.Flat;
            btnBaoCao.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBaoCao.ForeColor = Color.White;
            btnBaoCao.Location = new Point(672, 224);
            btnBaoCao.Name = "btnBaoCao";
            btnBaoCao.Size = new Size(204, 104);
            btnBaoCao.TabIndex = 13;
            btnBaoCao.Text = "Báo cáo";
            btnBaoCao.UseVisualStyleBackColor = false;
            btnBaoCao.Click += btnBaoCao_Click;
            //
            // lblHuongDan
            //
            lblHuongDan.ForeColor = Color.DimGray;
            lblHuongDan.Location = new Point(24, 344);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(852, 44);
            lblHuongDan.Text = "Quy trình mỗi tháng: 1) Cập nhật hồ sơ nhân viên  ->  2) Chấm công và bấm Lưu  ->  3) Tính lương rồi Chốt lương  ->  4) Xem báo cáo quỹ lương.";
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
            Controls.Add(pnlSoNV);
            Controls.Add(pnlSoPB);
            Controls.Add(pnlThangChot);
            Controls.Add(pnlQuyLuong);
            Controls.Add(btnNhanVien);
            Controls.Add(btnChamCong);
            Controls.Add(btnTinhLuong);
            Controls.Add(btnBaoCao);
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
            Text = "Hệ thống Quản lý Nhân sự & Tính lương";
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
        private ToolStripMenuItem mnuNhanSu;
        private ToolStripMenuItem mnuLuong;
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuChamCong;
        private ToolStripMenuItem mnuTinhLuong;
        private ToolStripMenuItem mnuBaoCaoLuong;
        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblSinhVien;
        private Panel pnlSoNV;
        private Label lblSoNVTitle;
        private Label lblSoNV;
        private Panel pnlSoPB;
        private Label lblSoPBTitle;
        private Label lblSoPB;
        private Panel pnlThangChot;
        private Label lblThangChotTitle;
        private Label lblThangChot;
        private Panel pnlQuyLuong;
        private Label lblQuyLuongTitle;
        private Label lblQuyLuong;
        private Button btnNhanVien;
        private Button btnChamCong;
        private Button btnTinhLuong;
        private Button btnBaoCao;
        private Label lblHuongDan;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblKetNoi;
    }
}
