namespace ClinicAppointmentManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuFile, menuXuatCSV, menuThoat;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        private TableLayoutPanel tlpMain;
        private GroupBox grpNhapLieu;
        private GroupBox grpDanhSach;
        private GroupBox grpTimKiem;

        // Input controls
        private Label lblMa, lblHoTen, lblSoDT, lblNgayGio, lblBacSi, lblLyDo, lblTrangThai;
        private TextBox txtMaLichHen, txtHoTen, txtSoDT, txtLyDo;
        private DateTimePicker dtpNgayGio;
        private ComboBox cbBacSi, cbTrangThai;
        private Button btnThem, btnCapNhat, btnXoa, btnLamMoi;
        private TableLayoutPanel tlpInput;

        // Search & Filter
        private Label lblTimKiem, lblLocNgay, lblLocTrangThai;
        private TextBox txtTimKiem;
        private DateTimePicker dtpLocNgay;
        private ComboBox cbLocTrangThai;
        private TableLayoutPanel tlpFilter;

        // Grid
        private DataGridView dgvLichHen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ---- MenuStrip ----
            menuStrip = new MenuStrip();
            menuFile = new ToolStripMenuItem("&File");
            menuXuatCSV = new ToolStripMenuItem("Xuất danh sách ra CSV");
            menuThoat = new ToolStripMenuItem("Thoát");
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuXuatCSV, new ToolStripSeparator(), menuThoat });
            menuStrip.Items.Add(menuFile);
            menuXuatCSV.Click += MenuXuatCSV_Click;
            menuThoat.Click += MenuThoat_Click;

            // ---- StatusStrip ----
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel("Hiển thị: 0 / 0 lịch hẹn");
            lblStatus.Spring = true;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            statusStrip.Items.Add(lblStatus);

            // ---- Labels & Inputs ----
            lblMa        = new Label { Text = "Mã lịch hẹn (*)", AutoSize = true, Anchor = AnchorStyles.Right };
            lblHoTen     = new Label { Text = "Họ tên bệnh nhân (*)", AutoSize = true, Anchor = AnchorStyles.Right };
            lblSoDT      = new Label { Text = "Số điện thoại (*)", AutoSize = true, Anchor = AnchorStyles.Right };
            lblNgayGio   = new Label { Text = "Ngày giờ hẹn (*)", AutoSize = true, Anchor = AnchorStyles.Right };
            lblBacSi     = new Label { Text = "Bác sĩ", AutoSize = true, Anchor = AnchorStyles.Right };
            lblLyDo      = new Label { Text = "Lý do khám (*)", AutoSize = true, Anchor = AnchorStyles.Right };
            lblTrangThai = new Label { Text = "Trạng thái", AutoSize = true, Anchor = AnchorStyles.Right };

            txtMaLichHen = new TextBox { Dock = DockStyle.Fill };
            txtHoTen     = new TextBox { Dock = DockStyle.Fill };
            txtSoDT      = new TextBox { Dock = DockStyle.Fill };
            dtpNgayGio   = new DateTimePicker { Dock = DockStyle.Fill };
            cbBacSi      = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            txtLyDo      = new TextBox { Dock = DockStyle.Fill };
            cbTrangThai  = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            // ---- Buttons ----
            btnThem     = new Button { Text = "➕ Thêm",     Dock = DockStyle.Fill, BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 35 };
            btnCapNhat  = new Button { Text = "✏️ Cập nhật", Dock = DockStyle.Fill, BackColor = Color.FromArgb(16, 124, 16), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 35 };
            btnXoa      = new Button { Text = "🗑️ Xóa",      Dock = DockStyle.Fill, BackColor = Color.FromArgb(196, 43, 28), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 35 };
            btnLamMoi   = new Button { Text = "🔄 Làm mới",  Dock = DockStyle.Fill, BackColor = Color.FromArgb(100, 100, 100), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 35 };
            btnThem.FlatAppearance.BorderSize = 0;
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnThem.Click    += BtnThem_Click;
            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa.Click     += BtnXoa_Click;
            btnLamMoi.Click  += BtnLamMoi_Click;

            // ---- TableLayoutPanel input (7 rows label+control + 1 row buttons) ----
            tlpInput = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 9,
                Padding = new Padding(6)
            };
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < 8; i++)
                tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // buttons

            tlpInput.Controls.Add(lblMa,        0, 0); tlpInput.Controls.Add(txtMaLichHen, 1, 0);
            tlpInput.Controls.Add(lblHoTen,     0, 1); tlpInput.Controls.Add(txtHoTen,     1, 1);
            tlpInput.Controls.Add(lblSoDT,      0, 2); tlpInput.Controls.Add(txtSoDT,      1, 2);
            tlpInput.Controls.Add(lblNgayGio,   0, 3); tlpInput.Controls.Add(dtpNgayGio,   1, 3);
            tlpInput.Controls.Add(lblBacSi,     0, 4); tlpInput.Controls.Add(cbBacSi,      1, 4);
            tlpInput.Controls.Add(lblLyDo,      0, 5); tlpInput.Controls.Add(txtLyDo,      1, 5);
            tlpInput.Controls.Add(lblTrangThai, 0, 6); tlpInput.Controls.Add(cbTrangThai,  1, 6);

            // Button row - a sub-panel
            var pnlButtons = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                ColumnStyles = { new ColumnStyle(SizeType.Percent, 25), new ColumnStyle(SizeType.Percent, 25), new ColumnStyle(SizeType.Percent, 25), new ColumnStyle(SizeType.Percent, 25) }
            };
            pnlButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            pnlButtons.Controls.Add(btnThem,    0, 0);
            pnlButtons.Controls.Add(btnCapNhat, 1, 0);
            pnlButtons.Controls.Add(btnXoa,     2, 0);
            pnlButtons.Controls.Add(btnLamMoi,  3, 0);

            tlpInput.Controls.Add(pnlButtons, 0, 7);
            tlpInput.SetColumnSpan(pnlButtons, 2);

            // ---- GroupBox nhập liệu ----
            grpNhapLieu = new GroupBox
            {
                Text = "Thông tin lịch hẹn",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(4)
            };
            grpNhapLieu.Controls.Add(tlpInput);

            // ---- Filter controls ----
            lblTimKiem     = new Label { Text = "🔍 Tìm kiếm:", AutoSize = true, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            lblLocNgay     = new Label { Text = "Lọc ngày:", AutoSize = true, Anchor = AnchorStyles.Left | AnchorStyles.Right };
            lblLocTrangThai = new Label { Text = "Trạng thái:", AutoSize = true, Anchor = AnchorStyles.Left | AnchorStyles.Right };

            txtTimKiem  = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "Nhập tên hoặc số điện thoại..." };
            dtpLocNgay  = new DateTimePicker { Dock = DockStyle.Fill };
            cbLocTrangThai = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            tlpFilter = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 6,
                RowCount = 1,
                Padding = new Padding(4, 2, 4, 2)
            };
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            tlpFilter.Controls.Add(lblTimKiem,      0, 0);
            tlpFilter.Controls.Add(txtTimKiem,      1, 0);
            tlpFilter.Controls.Add(lblLocNgay,      2, 0);
            tlpFilter.Controls.Add(dtpLocNgay,      3, 0);
            tlpFilter.Controls.Add(lblLocTrangThai, 4, 0);
            tlpFilter.Controls.Add(cbLocTrangThai,  5, 0);

            grpTimKiem = new GroupBox
            {
                Text = "Tìm kiếm & Lọc",
                Dock = DockStyle.Fill,
                Height = 60,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(2)
            };
            grpTimKiem.Controls.Add(tlpFilter);

            // ---- DataGridView ----
            dgvLichHen = new DataGridView
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
                GridColor = Color.FromArgb(200, 200, 200),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    SelectionBackColor = Color.FromArgb(180, 210, 240),
                    SelectionForeColor = Color.Black,
                    Padding = new Padding(2)
                }
            };

            // ---- GroupBox danh sách ----
            var pnlListInner = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                Padding = new Padding(4)
            };
            pnlListInner.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            pnlListInner.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            pnlListInner.Controls.Add(grpTimKiem, 0, 0);
            pnlListInner.Controls.Add(dgvLichHen, 0, 1);

            grpDanhSach = new GroupBox
            {
                Text = "Danh sách lịch hẹn",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(4)
            };
            grpDanhSach.Controls.Add(pnlListInner);

            // ---- Main TableLayoutPanel: Left=input, Right=list ----
            tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(6)
            };
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tlpMain.Controls.Add(grpNhapLieu,  0, 0);
            tlpMain.Controls.Add(grpDanhSach,  1, 0);

            // ---- ErrorProvider ----
            _errorProvider = new ErrorProvider(components)
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            // ---- Form ----
            SuspendLayout();
            Text = "Clinic Appointment Manager – Quản lý lịch hẹn phòng khám";
            Size = new Size(1100, 640);
            MinimumSize = new Size(900, 520);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9f);
            Icon = SystemIcons.Application;
            MainMenuStrip = menuStrip;

            Controls.Add(tlpMain);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
