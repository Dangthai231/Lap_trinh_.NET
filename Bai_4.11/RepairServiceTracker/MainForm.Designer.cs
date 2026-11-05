namespace RepairServiceTracker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuFile, menuXuatCSV, menuThoat;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        private TextBox txtMaDon, txtTenKH, txtSoDT, txtMoTa, txtChiPhi, txtTimKiem;
        private ComboBox cbLoaiThietBi, cbTrangThai, cbLocTrangThai;
        private DateTimePicker dtpNgayTiepNhan;
        private PictureBox picThietBi;
        private Button btnThem, btnCapNhat, btnXoa, btnLamMoi, btnChonAnh;
        private DataGridView dgvDon;
        private GroupBox grpDon, grpDanhSach;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ---- Menu ----
            menuStrip = new MenuStrip();
            menuFile = new ToolStripMenuItem("&File");
            menuXuatCSV = new ToolStripMenuItem("Xuất danh sách ra CSV");
            menuThoat = new ToolStripMenuItem("Thoát");
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuXuatCSV, new ToolStripSeparator(), menuThoat });
            menuStrip.Items.Add(menuFile);
            menuXuatCSV.Click += MenuXuatCSV_Click;
            menuThoat.Click += MenuThoat_Click;

            // ---- Status ----
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel("Hiển thị: 0 đơn") { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
            statusStrip.Items.Add(lblStatus);

            // ---- Input controls ----
            txtMaDon       = new TextBox { Dock = DockStyle.Fill };
            txtTenKH       = new TextBox { Dock = DockStyle.Fill };
            txtSoDT        = new TextBox { Dock = DockStyle.Fill };
            cbLoaiThietBi  = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            txtMoTa        = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 55, ScrollBars = ScrollBars.Vertical };
            dtpNgayTiepNhan = new DateTimePicker { Dock = DockStyle.Fill };
            txtChiPhi      = new TextBox { Dock = DockStyle.Fill, Text = "0" };
            cbTrangThai    = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            // ---- PictureBox ----
            picThietBi = new PictureBox { Dock = DockStyle.Fill, Height = 140 };

            // ---- Buttons ----
            btnThem    = MakeBtn("➕ Thêm",     Color.FromArgb(0, 120, 215));
            btnCapNhat = MakeBtn("✏️ Cập nhật", Color.FromArgb(16, 124, 16));
            btnXoa     = MakeBtn("🗑️ Xóa",      Color.FromArgb(196, 43, 28));
            btnLamMoi  = MakeBtn("🔄 Làm mới",  Color.FromArgb(100, 100, 100));
            btnChonAnh = MakeBtn("🖼️ Chọn ảnh", Color.FromArgb(80, 80, 160));
            btnThem.Click    += BtnThem_Click;
            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa.Click     += BtnXoa_Click;
            btnLamMoi.Click  += BtnLamMoi_Click;
            btnChonAnh.Click += BtnChonAnh_Click;

            // ---- TableLayoutPanel input ----
            var tlp = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(6) };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // rows: 9 fixed + 1 pic + 1 buttons
            int[] rowHeights = { 32, 32, 32, 32, 65, 32, 32, 32, 32, 145, 38 };
            foreach (var h in rowHeights) tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, h));
            tlp.RowCount = rowHeights.Length;

            void AddRow(int row, string lbl, Control ctrl, bool span = false)
            {
                var l = new Label { Text = lbl, AutoSize = true, Anchor = AnchorStyles.Right, Padding = new Padding(0, 6, 4, 0) };
                if (span) { tlp.Controls.Add(ctrl, 0, row); tlp.SetColumnSpan(ctrl, 2); }
                else { tlp.Controls.Add(l, 0, row); tlp.Controls.Add(ctrl, 1, row); }
            }

            AddRow(0, "Mã đơn (*)",        txtMaDon);
            AddRow(1, "Tên khách hàng (*)", txtTenKH);
            AddRow(2, "Số điện thoại (*)",  txtSoDT);
            AddRow(3, "Loại thiết bị",      cbLoaiThietBi);
            AddRow(4, "Mô tả lỗi (*)",      txtMoTa);
            AddRow(5, "Ngày tiếp nhận",     dtpNgayTiepNhan);
            AddRow(6, "Chi phí dự kiến",    txtChiPhi);
            AddRow(7, "Trạng thái",         cbTrangThai);

            // Row 8: nút chọn ảnh + label
            var lblAnh = new Label { Text = "Ảnh thiết bị", AutoSize = true, Anchor = AnchorStyles.Right, Padding = new Padding(0, 6, 4, 0) };
            tlp.Controls.Add(lblAnh, 0, 8);
            tlp.Controls.Add(btnChonAnh, 1, 8);

            // Row 9: PictureBox spans both cols
            tlp.Controls.Add(picThietBi, 0, 9);
            tlp.SetColumnSpan(picThietBi, 2);

            // Row 10: buttons
            var pnlBtn = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 1 };
            for (int i = 0; i < 4; i++) pnlBtn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            pnlBtn.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            pnlBtn.Controls.Add(btnThem,    0, 0);
            pnlBtn.Controls.Add(btnCapNhat, 1, 0);
            pnlBtn.Controls.Add(btnXoa,     2, 0);
            pnlBtn.Controls.Add(btnLamMoi,  3, 0);
            tlp.Controls.Add(pnlBtn, 0, 10);
            tlp.SetColumnSpan(pnlBtn, 2);

            grpDon = new GroupBox { Text = "Thông tin đơn sửa chữa", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), Padding = new Padding(4) };
            grpDon.Controls.Add(tlp);

            // ---- Filter + Grid ----
            txtTimKiem     = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "Mã đơn, tên KH, số ĐT..." };
            cbLocTrangThai = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            var tlpFilter = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 1, Padding = new Padding(4, 2, 4, 2) };
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tlpFilter.Controls.Add(new Label { Text = "🔍 Tìm kiếm:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
            tlpFilter.Controls.Add(txtTimKiem,     1, 0);
            tlpFilter.Controls.Add(new Label { Text = "Trạng thái:", AutoSize = true, Anchor = AnchorStyles.Left }, 2, 0);
            tlpFilter.Controls.Add(cbLocTrangThai, 3, 0);

            var grpFilter = new GroupBox { Text = "Tìm kiếm & Lọc", Dock = DockStyle.Fill, Height = 58, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) };
            grpFilter.Controls.Add(tlpFilter);

            dgvDon = new DataGridView
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9f),
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                EnableHeadersVisualStyles = false,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(200, 200, 200),
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    SelectionBackColor = Color.FromArgb(180, 210, 240),
                    SelectionForeColor = Color.Black,
                    Padding = new Padding(2)
                }
            };

            var pnlRight = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, Padding = new Padding(4) };
            pnlRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            pnlRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            pnlRight.Controls.Add(grpFilter, 0, 0);
            pnlRight.Controls.Add(dgvDon,    0, 1);

            grpDanhSach = new GroupBox { Text = "Danh sách đơn sửa chữa", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), Padding = new Padding(4) };
            grpDanhSach.Controls.Add(pnlRight);

            // ---- Main layout: TableLayoutPanel 2 cột (thay SplitContainer để tránh lỗi SplitterDistance) ----
            var tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(4)
            };
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 420));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tlpMain.Controls.Add(grpDon,       0, 0);
            tlpMain.Controls.Add(grpDanhSach,  1, 0);

            // ---- ErrorProvider ----
            _ep = new ErrorProvider(components) { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

            // ---- Form ----
            SuspendLayout();
            Text = "Repair Service Tracker – Quản lý đơn sửa chữa";
            Size = new Size(1200, 680);
            MinimumSize = new Size(900, 540);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9f);
            MainMenuStrip = menuStrip;
            Controls.Add(tlpMain);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            ResumeLayout(false);
            PerformLayout();
        }

        private static Button MakeBtn(string text, Color back)
        {
            var b = new Button { Text = text, Dock = DockStyle.Fill, BackColor = back, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 33 };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
    }
}
