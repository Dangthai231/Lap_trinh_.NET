namespace LabEquipmentCheckout
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // ---- Menu & Status ----
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuFile, menuXuatCSV, menuThoat;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        // ---- Input fields ----
        private TextBox txtMaPhieu, txtMaSV, txtHoTen;
        private ComboBox cbThietBi;
        private NumericUpDown nudSoLuong;
        private DateTimePicker dtpNgayMuon, dtpHanTra, dtpNgayTraThucTe;
        private CheckBox chkDaTra;
        private Button btnThem, btnCapNhat, btnXoa, btnLamMoi;

        // ---- Filter ----
        private TextBox txtTimKiem;
        private ComboBox cbLocTinhTrang;

        // ---- Grid ----
        private DataGridView dgvPhieu;

        // ---- Containers ----
        private GroupBox grpPhieu, grpDanhSach;
        private TableLayoutPanel tlpInput, tlpFilter;


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
            menuXuatCSV = new ToolStripMenuItem("Xuất phiếu đang lọc ra CSV");
            menuThoat = new ToolStripMenuItem("Thoát");
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuXuatCSV, new ToolStripSeparator(), menuThoat });
            menuStrip.Items.Add(menuFile);
            menuXuatCSV.Click += MenuXuatCSV_Click;
            menuThoat.Click += MenuThoat_Click;

            // ---- Status ----
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel("Tổng phiếu: 0") { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
            statusStrip.Items.Add(lblStatus);

            // ---- Input controls ----
            txtMaPhieu = new TextBox { Dock = DockStyle.Fill };
            txtMaSV    = new TextBox { Dock = DockStyle.Fill };
            txtHoTen   = new TextBox { Dock = DockStyle.Fill };
            cbThietBi  = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            nudSoLuong = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 1, Maximum = 999, Value = 1 };
            dtpNgayMuon      = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            dtpHanTra        = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            dtpNgayTraThucTe = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            chkDaTra         = new CheckBox { Text = "Đã trả – ngày trả thực tế:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };

            // ---- Buttons ----
            btnThem    = MakeButton("➕ Thêm",     Color.FromArgb(0, 120, 215));
            btnCapNhat = MakeButton("✏️ Cập nhật", Color.FromArgb(16, 124, 16));
            btnXoa     = MakeButton("🗑️ Xóa",      Color.FromArgb(196, 43, 28));
            btnLamMoi  = MakeButton("🔄 Làm mới",  Color.FromArgb(100, 100, 100));
            btnThem.Click    += BtnThem_Click;
            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa.Click     += BtnXoa_Click;
            btnLamMoi.Click  += BtnLamMoi_Click;

            // ---- TableLayoutPanel input (10 rows) ----
            tlpInput = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 11, Padding = new Padding(6) };
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < 10; i++) tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            void AddRow(int row, string lbl, Control ctrl)
            {
                var l = new Label { Text = lbl, AutoSize = true, Anchor = AnchorStyles.Right, Padding = new Padding(0, 6, 4, 0) };
                tlpInput.Controls.Add(l, 0, row);
                tlpInput.Controls.Add(ctrl, 1, row);
            }
            AddRow(0, "Mã phiếu (*)",      txtMaPhieu);
            AddRow(1, "Mã sinh viên (*)",   txtMaSV);
            AddRow(2, "Họ tên SV (*)",      txtHoTen);
            AddRow(3, "Thiết bị (*)",       cbThietBi);
            AddRow(4, "Số lượng (*)",       nudSoLuong);
            AddRow(5, "Ngày mượn",          dtpNgayMuon);
            AddRow(6, "Hạn trả",            dtpHanTra);
            // Row 7: checkbox spans both cols
            tlpInput.Controls.Add(chkDaTra, 0, 7);
            tlpInput.SetColumnSpan(chkDaTra, 2);
            // Row 8: ngày trả thực tế (label empty, picker)
            var lblEmpty = new Label { Text = "", Dock = DockStyle.Fill };
            tlpInput.Controls.Add(lblEmpty, 0, 8);
            tlpInput.Controls.Add(dtpNgayTraThucTe, 1, 8);

            // Row 9: buttons
            var pnlBtn = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 1 };
            for (int i = 0; i < 4; i++) pnlBtn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            pnlBtn.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            pnlBtn.Controls.Add(btnThem,    0, 0);
            pnlBtn.Controls.Add(btnCapNhat, 1, 0);
            pnlBtn.Controls.Add(btnXoa,     2, 0);
            pnlBtn.Controls.Add(btnLamMoi,  3, 0);
            tlpInput.Controls.Add(pnlBtn, 0, 9);
            tlpInput.SetColumnSpan(pnlBtn, 2);

            grpPhieu = new GroupBox { Text = "Thông tin phiếu mượn", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), Padding = new Padding(4) };
            grpPhieu.Controls.Add(tlpInput);

            // ---- Filter panel ----
            txtTimKiem = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "Mã SV, tên SV hoặc tên thiết bị..." };
            cbLocTinhTrang = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            tlpFilter = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 1, Padding = new Padding(4, 2, 4, 2) };
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tlpFilter.Controls.Add(new Label { Text = "🔍 Tìm kiếm:", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
            tlpFilter.Controls.Add(txtTimKiem, 1, 0);
            tlpFilter.Controls.Add(new Label { Text = "Lọc:", AutoSize = true, Anchor = AnchorStyles.Left }, 2, 0);
            tlpFilter.Controls.Add(cbLocTinhTrang, 3, 0);

            var grpFilter = new GroupBox { Text = "Tìm kiếm & Lọc", Dock = DockStyle.Fill, Height = 58, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) };
            grpFilter.Controls.Add(tlpFilter);

            // ---- DataGridView ----
            dgvPhieu = new DataGridView
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9f),
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 120, 215),
                    ForeColor = Color.White,
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

            // Right panel: filter + grid
            var pnlRight = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, Padding = new Padding(4) };
            pnlRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            pnlRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            pnlRight.Controls.Add(grpFilter, 0, 0);
            pnlRight.Controls.Add(dgvPhieu,  0, 1);

            grpDanhSach = new GroupBox { Text = "Danh sách phiếu mượn", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), Padding = new Padding(4) };
            grpDanhSach.Controls.Add(pnlRight);

            // ---- Main layout: TableLayoutPanel 2 cột (thay SplitContainer) ----
            var tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(4)
            };
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tlpMain.Controls.Add(grpPhieu,     0, 0);
            tlpMain.Controls.Add(grpDanhSach,  1, 0);

            // ---- ErrorProvider ----
            _errorProvider = new ErrorProvider(components) { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

            // ---- Form ----
            SuspendLayout();
            Text = "Lab Equipment Checkout – Quản lý mượn trả thiết bị";
            Size = new Size(1150, 660);
            MinimumSize = new Size(900, 520);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9f);
            MainMenuStrip = menuStrip;
            Controls.Add(tlpMain);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            ResumeLayout(false);
            PerformLayout();
        }

        private static Button MakeButton(string text, Color back)
        {
            var b = new Button { Text = text, Dock = DockStyle.Fill, BackColor = back, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 35 };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
    }
}
