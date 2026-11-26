using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjectTaskManager.BUS;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.GUI
{
    public class FormMain : Form
    {
        private readonly DuAnBUS _duAnBUS = new DuAnBUS();
        private readonly CongViecBUS _congViecBUS = new CongViecBUS();
        private readonly ThanhVienBUS _thanhVienBUS = new ThanhVienBUS();
        private readonly BaoCaoBUS _baoCaoBUS = new BaoCaoBUS();

        // Controls chính
        private Label lblKpiTong;
        private Label lblKpiToDo;
        private Label lblKpiInProg;
        private Label lblKpiReview;
        private Label lblKpiDone;
        private Label lblKpiTreHan;

        private ComboBox cboLocDuAn;
        private ComboBox cboLocTrangThai;
        private TextBox txtTimKiem;

        private TabControl tabControlMain;

        // Tab Kanban
        private FlowLayoutPanel pnlColToDo;
        private FlowLayoutPanel pnlColInProg;
        private FlowLayoutPanel pnlColReview;
        private FlowLayoutPanel pnlColDone;
        private Label lblCountToDo;
        private Label lblCountInProg;
        private Label lblCountReview;
        private Label lblCountDone;

        // Tab List View
        private DataGridView dgvTasks;

        // Tab Dự án
        private DataGridView dgvDuAn;

        // Tab Thành viên
        private DataGridView dgvThanhVien;

        // Tab Cảnh báo & Báo cáo
        private DataGridView dgvTreHan;
        private DataGridView dgvThongKeThanhVien;
        private Label lblBaoCaoTongQuan;

        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Hệ thống Quản lý Công việc & Tiến độ Dự án (Project & Task Management) - Bài 6.3";
            this.Size = new Size(1300, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            this.BackColor = Color.FromArgb(248, 250, 252);

            // ================= 1. HEADER =================
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 75,
                BackColor = Color.FromArgb(30, 41, 59),
                Padding = new Padding(20, 10, 20, 10)
            };

            Label lblAppTitle = new Label
            {
                Text = "⚡ HỆ THỐNG QUẢN LÝ CÔNG VIỆC & TIẾN ĐỘ DỰ ÁN",
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 12),
                AutoSize = true
            };
            Label lblStudentInfo = new Label
            {
                Text = "Sinh viên thực hiện: Đặng Hồng Thái | MSV: 24810310241 | Lớp: D19CNPM3 | CSDL: SQL Server (ProjectTaskDB)",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(22, 43),
                AutoSize = true
            };

            Label lblDbStatus = new Label
            {
                Text = "● CSDL: ProjectTaskDB (Connected)",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 197, 94),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(1020, 25),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblStudentInfo);
            pnlHeader.Controls.Add(lblDbStatus);
            this.Controls.Add(pnlHeader);

            // ================= 2. KPI CARDS =================
            Panel pnlKpi = new Panel
            {
                Dock = DockStyle.Top,
                Height = 85,
                BackColor = Color.FromArgb(241, 245, 249),
                Padding = new Padding(15, 10, 15, 10)
            };

            int cardW = 190;
            int cardH = 65;
            int startX = 15;
            int gap = 15;

            var cardTong = CreateKpiCard("TỔNG SỐ TASK", out lblKpiTong, Color.FromArgb(59, 130, 246), new Point(startX, 10), new Size(cardW, cardH));
            var cardToDo = CreateKpiCard("TO DO (CHƯA LÀM)", out lblKpiToDo, Color.FromArgb(100, 116, 139), new Point(startX + (cardW + gap), 10), new Size(cardW, cardH));
            var cardInProg = CreateKpiCard("IN PROGRESS (ĐANG LÀM)", out lblKpiInProg, Color.FromArgb(245, 158, 11), new Point(startX + (cardW + gap) * 2, 10), new Size(cardW + 15, cardH));
            var cardReview = CreateKpiCard("REVIEW (CHỜ DUYỆT)", out lblKpiReview, Color.FromArgb(139, 92, 246), new Point(startX + (cardW + gap) * 3 + 15, 10), new Size(cardW, cardH));
            var cardDone = CreateKpiCard("DONE (HOÀN THÀNH)", out lblKpiDone, Color.FromArgb(16, 185, 129), new Point(startX + (cardW + gap) * 4 + 15, 10), new Size(cardW, cardH));
            var cardTreHan = CreateKpiCard("⚠️ QUÁ HẠN (OVERDUE)", out lblKpiTreHan, Color.FromArgb(239, 68, 68), new Point(startX + (cardW + gap) * 5 + 15, 10), new Size(cardW + 15, cardH));

            pnlKpi.Controls.Add(cardTong);
            pnlKpi.Controls.Add(cardToDo);
            pnlKpi.Controls.Add(cardInProg);
            pnlKpi.Controls.Add(cardReview);
            pnlKpi.Controls.Add(cardDone);
            pnlKpi.Controls.Add(cardTreHan);
            this.Controls.Add(pnlKpi);

            // ================= 3. TOOLBAR LỌC & THAO TÁC =================
            Panel pnlFilter = new Panel
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            Label lblDuAn = new Label { Text = "Dự án:", Location = new Point(15, 16), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboLocDuAn = new ComboBox { Location = new Point(65, 12), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLocDuAn.SelectedIndexChanged += (s, e) => LoadAllData();

            Label lblTrangThai = new Label { Text = "Trạng thái:", Location = new Point(340, 16), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboLocTrangThai = new ComboBox { Location = new Point(415, 12), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "To Do", "In Progress", "Review", "Done" });
            cboLocTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndexChanged += (s, e) => LoadAllData();

            Label lblSearch = new Label { Text = "Tìm kiếm:", Location = new Point(570, 16), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTimKiem = new TextBox { Location = new Point(635, 12), Width = 180, PlaceholderText = "Nhập tên task..." };
            txtTimKiem.TextChanged += (s, e) => LoadAllData();

            Button btnThemTask = new Button
            {
                Text = "➕ Thêm Task mới",
                Location = new Point(830, 10),
                Size = new Size(140, 34),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThemTask.FlatAppearance.BorderSize = 0;
            btnThemTask.Click += BtnThemTask_Click;

            Button btnThemDuAn = new Button
            {
                Text = "📁 Thêm Dự án",
                Location = new Point(980, 10),
                Size = new Size(130, 34),
                BackColor = Color.FromArgb(79, 70, 229),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThemDuAn.FlatAppearance.BorderSize = 0;
            btnThemDuAn.Click += BtnThemDuAn_Click;

            Button btnLamMoi = new Button
            {
                Text = "🔄 Làm mới",
                Location = new Point(1120, 10),
                Size = new Size(110, 34),
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) =>
            {
                LoadDanhSachDuAnCombo();
                LoadAllData();
            };

            pnlFilter.Controls.Add(lblDuAn);
            pnlFilter.Controls.Add(cboLocDuAn);
            pnlFilter.Controls.Add(lblTrangThai);
            pnlFilter.Controls.Add(cboLocTrangThai);
            pnlFilter.Controls.Add(lblSearch);
            pnlFilter.Controls.Add(txtTimKiem);
            pnlFilter.Controls.Add(btnThemTask);
            pnlFilter.Controls.Add(btnThemDuAn);
            pnlFilter.Controls.Add(btnLamMoi);
            this.Controls.Add(pnlFilter);

            // ================= 4. TAB CONTROL =================
            tabControlMain = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Padding = new Point(15, 8)
            };
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;

            // Tab 1: Kanban Board
            TabPage tabKanban = new TabPage { Text = "📌 Bảng Kanban (Kanban Board)", BackColor = Color.FromArgb(241, 245, 249) };
            InitKanbanTab(tabKanban);
            tabControlMain.TabPages.Add(tabKanban);

            // Tab 2: Danh sách Task (List View)
            TabPage tabList = new TabPage { Text = "📋 Danh sách Task (List View)", BackColor = Color.White };
            InitListTab(tabList);
            tabControlMain.TabPages.Add(tabList);

            // Tab 3: Quản lý Dự án
            TabPage tabDuAn = new TabPage { Text = "📁 Quản lý Dự án", BackColor = Color.White };
            InitDuAnTab(tabDuAn);
            tabControlMain.TabPages.Add(tabDuAn);

            // Tab 4: Quản lý Thành viên
            TabPage tabThanhVien = new TabPage { Text = "👥 Thành viên nhóm", BackColor = Color.White };
            InitThanhVienTab(tabThanhVien);
            tabControlMain.TabPages.Add(tabThanhVien);

            // Tab 5: Cảnh báo trễ hạn & Báo cáo
            TabPage tabBaoCao = new TabPage { Text = "⚠️ Cảnh báo Trễ hạn & Báo cáo", BackColor = Color.FromArgb(248, 250, 252) };
            InitBaoCaoTab(tabBaoCao);
            tabControlMain.TabPages.Add(tabBaoCao);

            this.Controls.Add(tabControlMain);
            tabControlMain.BringToFront();
        }

        private Panel CreateKpiCard(string title, out Label lblValue, Color accentColor, Point loc, Size sz)
        {
            Panel card = new Panel
            {
                Location = loc,
                Size = sz,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            Panel bar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 5,
                BackColor = accentColor
            };
            card.Controls.Add(bar);

            Label lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(12, 8),
                AutoSize = true
            };
            lblValue = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(10, 26),
                AutoSize = true
            };

            card.Controls.Add(lblT);
            card.Controls.Add(lblValue);
            return card;
        }

        // ================= TAB 1: KANBAN BOARD =================
        private void InitKanbanTab(TabPage tab)
        {
            TableLayoutPanel tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                Padding = new Padding(10)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));

            // Cột 1: To Do
            var colToDo = CreateKanbanColumn("📝 TO DO", Color.FromArgb(100, 116, 139), out pnlColToDo, out lblCountToDo, "To Do");
            // Cột 2: In Progress
            var colInProg = CreateKanbanColumn("⚙️ IN PROGRESS", Color.FromArgb(245, 158, 11), out pnlColInProg, out lblCountInProg, "In Progress");
            // Cột 3: Review
            var colReview = CreateKanbanColumn("🔍 REVIEW", Color.FromArgb(139, 92, 246), out pnlColReview, out lblCountReview, "Review");
            // Cột 4: Done
            var colDone = CreateKanbanColumn("✅ DONE", Color.FromArgb(16, 185, 129), out pnlColDone, out lblCountDone, "Done");

            tlp.Controls.Add(colToDo, 0, 0);
            tlp.Controls.Add(colInProg, 1, 0);
            tlp.Controls.Add(colReview, 2, 0);
            tlp.Controls.Add(colDone, 3, 0);

            tab.Controls.Add(tlp);
        }

        private Panel CreateKanbanColumn(string headerText, Color headerColor, out FlowLayoutPanel flowPnl, out Label countLbl, string colStatus)
        {
            Panel colPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(241, 245, 249),
                Margin = new Padding(5)
            };

            Panel headerPnl = new Panel
            {
                Dock = DockStyle.Top,
                Height = 42,
                BackColor = Color.White,
                Padding = new Padding(10, 5, 10, 5)
            };

            Panel accent = new Panel
            {
                Dock = DockStyle.Top,
                Height = 3,
                BackColor = headerColor
            };
            headerPnl.Controls.Add(accent);

            Label title = new Label
            {
                Text = headerText,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = headerColor,
                Location = new Point(10, 10),
                AutoSize = true
            };

            countLbl = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = headerColor,
                Location = new Point(180, 10),
                Size = new Size(26, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnQuickAdd = new Button
            {
                Text = "➕",
                Size = new Size(26, 22),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(colPanel.Width - 40, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = headerColor,
                Cursor = Cursors.Hand
            };
            btnQuickAdd.FlatAppearance.BorderSize = 0;
            btnQuickAdd.Click += (s, e) =>
            {
                int maDuAn = LayMaDuAnDangChon();
                FormTask frm = new FormTask(0, maDuAn, colStatus);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllData();
                }
            };

            headerPnl.Controls.Add(title);
            headerPnl.Controls.Add(countLbl);
            headerPnl.Controls.Add(btnQuickAdd);

            flowPnl = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(5)
            };

            colPanel.Controls.Add(flowPnl);
            colPanel.Controls.Add(headerPnl);
            return colPanel;
        }

        // ================= TAB 2: LIST VIEW =================
        private void InitListTab(TabPage tab)
        {
            Panel pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(15, 8, 15, 8)
            };

            Button btnSua = new Button
            {
                Text = "✏️ Sửa Task",
                Location = new Point(15, 8),
                Size = new Size(110, 32),
                BackColor = Color.FromArgb(241, 245, 249),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnSua.Click += BtnSuaTask_Click;

            Button btnXoa = new Button
            {
                Text = "🗑 Xóa Task",
                Location = new Point(135, 8),
                Size = new Size(110, 32),
                BackColor = Color.FromArgb(254, 242, 242),
                ForeColor = Color.FromArgb(220, 38, 38),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnXoa.Click += BtnXoaTask_Click;

            Button btnChuyenInProg = new Button
            {
                Text = "▶ Chuyển sang In Progress",
                Location = new Point(255, 8),
                Size = new Size(185, 32),
                BackColor = Color.FromArgb(254, 243, 199),
                ForeColor = Color.FromArgb(180, 83, 9),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnChuyenInProg.Click += (s, e) => ChuyenTrangThaiDangChon("In Progress");

            Button btnChuyenDone = new Button
            {
                Text = "✔ Đánh dấu Hoàn thành (Done)",
                Location = new Point(450, 8),
                Size = new Size(215, 32),
                BackColor = Color.FromArgb(220, 252, 231),
                ForeColor = Color.FromArgb(22, 101, 52),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnChuyenDone.Click += (s, e) => ChuyenTrangThaiDangChon("Done");

            pnlTop.Controls.Add(btnSua);
            pnlTop.Controls.Add(btnXoa);
            pnlTop.Controls.Add(btnChuyenInProg);
            pnlTop.Controls.Add(btnChuyenDone);

            dgvTasks = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                RowTemplate = { Height = 36 },
                Font = new Font("Segoe UI", 9f)
            };
            dgvTasks.EnableHeadersVisualStyles = false;
            dgvTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvTasks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvTasks.ColumnHeadersHeight = 38;
            dgvTasks.CellFormatting += DgvTasks_CellFormatting;
            dgvTasks.DoubleClick += (s, e) => BtnSuaTask_Click(s, e);

            tab.Controls.Add(dgvTasks);
            tab.Controls.Add(pnlTop);
        }

        // ================= TAB 3: DỰ ÁN =================
        private void InitDuAnTab(TabPage tab)
        {
            Panel pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(15, 8, 15, 8)
            };

            Button btnThem = new Button
            {
                Text = "➕ Thêm Dự án",
                Location = new Point(15, 8),
                Size = new Size(130, 32),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Click += BtnThemDuAn_Click;

            Button btnSua = new Button
            {
                Text = "✏️ Sửa Dự án",
                Location = new Point(155, 8),
                Size = new Size(120, 32),
                BackColor = Color.FromArgb(241, 245, 249),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnSua.Click += BtnSuaDuAn_Click;

            Button btnXoa = new Button
            {
                Text = "🗑 Xóa Dự án",
                Location = new Point(285, 8),
                Size = new Size(120, 32),
                BackColor = Color.FromArgb(254, 242, 242),
                ForeColor = Color.FromArgb(220, 38, 38),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnXoa.Click += BtnXoaDuAn_Click;

            pnlTop.Controls.Add(btnThem);
            pnlTop.Controls.Add(btnSua);
            pnlTop.Controls.Add(btnXoa);

            dgvDuAn = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                RowTemplate = { Height = 36 },
                Font = new Font("Segoe UI", 9f)
            };
            dgvDuAn.EnableHeadersVisualStyles = false;
            dgvDuAn.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvDuAn.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvDuAn.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvDuAn.ColumnHeadersHeight = 38;
            dgvDuAn.DoubleClick += (s, e) => BtnSuaDuAn_Click(s, e);

            tab.Controls.Add(dgvDuAn);
            tab.Controls.Add(pnlTop);
        }

        // ================= TAB 4: THÀNH VIÊN =================
        private void InitThanhVienTab(TabPage tab)
        {
            Panel pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(15, 8, 15, 8)
            };

            Button btnThem = new Button
            {
                Text = "➕ Thêm Thành viên",
                Location = new Point(15, 8),
                Size = new Size(150, 32),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Click += BtnThemThanhVien_Click;

            Button btnSua = new Button
            {
                Text = "✏️ Sửa Thành viên",
                Location = new Point(175, 8),
                Size = new Size(140, 32),
                BackColor = Color.FromArgb(241, 245, 249),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnSua.Click += BtnSuaThanhVien_Click;

            Button btnXoa = new Button
            {
                Text = "🗑 Xóa Thành viên",
                Location = new Point(325, 8),
                Size = new Size(140, 32),
                BackColor = Color.FromArgb(254, 242, 242),
                ForeColor = Color.FromArgb(220, 38, 38),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnXoa.Click += BtnXoaThanhVien_Click;

            pnlTop.Controls.Add(btnThem);
            pnlTop.Controls.Add(btnSua);
            pnlTop.Controls.Add(btnXoa);

            dgvThanhVien = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                RowTemplate = { Height = 36 },
                Font = new Font("Segoe UI", 9f)
            };
            dgvThanhVien.EnableHeadersVisualStyles = false;
            dgvThanhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvThanhVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvThanhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvThanhVien.ColumnHeadersHeight = 38;
            dgvThanhVien.DoubleClick += (s, e) => BtnSuaThanhVien_Click(s, e);

            tab.Controls.Add(dgvThanhVien);
            tab.Controls.Add(pnlTop);
        }

        // ================= TAB 5: BÁO CÁO & CẢNH BÁO =================
        private void InitBaoCaoTab(TabPage tab)
        {
            SplitContainer split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 300,
                SplitterWidth = 8,
                BackColor = Color.FromArgb(226, 232, 240)
            };

            // Phần trên: Cảnh báo trễ hạn (Overdue) dùng SqlDataReader
            Panel pnlTop = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(15) };
            Label lblHeaderTreHan = new Label
            {
                Text = "🚨 1. CẢNH BÁO CÔNG VIỆC QUÁ HẠN (OVERDUE TASKS)",
                Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 38, 38),
                Dock = DockStyle.Top,
                Height = 30
            };
            Label lblSubTreHan = new Label
            {
                Text = "Truy vấn dữ liệu trực tiếp bằng SqlDataReader qua DataProvider.ExecuteReader() theo đúng yêu cầu Bài 6.3 (TrangThai != 'Done' VÀ HanNop < Ngày hiện tại):",
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Dock = DockStyle.Top,
                Height = 22
            };

            dgvTreHan = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                RowTemplate = { Height = 34 },
                Font = new Font("Segoe UI", 9f)
            };
            dgvTreHan.EnableHeadersVisualStyles = false;
            dgvTreHan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
            dgvTreHan.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(153, 27, 27);
            dgvTreHan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvTreHan.ColumnHeadersHeight = 36;
            dgvTreHan.CellFormatting += DgvTreHan_CellFormatting;

            pnlTop.Controls.Add(dgvTreHan);
            pnlTop.Controls.Add(lblSubTreHan);
            pnlTop.Controls.Add(lblHeaderTreHan);

            // Phần dưới: Thống kê tỷ lệ % theo từng thành viên (GROUP BY & ExecuteScalar)
            Panel pnlBottom = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(15) };
            Label lblHeaderThongKe = new Label
            {
                Text = "📊 2. THỐNG KÊ TỶ LỆ % HOÀN THÀNH CÔNG VIỆC CỦA TỪNG THÀNH VIÊN",
                Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Dock = DockStyle.Top,
                Height = 30
            };
            lblBaoCaoTongQuan = new Label
            {
                Text = "Dữ liệu được thống kê bằng câu lệnh GROUP BY kết hợp hàm ExecuteScalar theo đúng yêu cầu đề bài:",
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Dock = DockStyle.Top,
                Height = 25
            };

            dgvThongKeThanhVien = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                RowTemplate = { Height = 34 },
                Font = new Font("Segoe UI", 9f)
            };
            dgvThongKeThanhVien.EnableHeadersVisualStyles = false;
            dgvThongKeThanhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvThongKeThanhVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvThongKeThanhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvThongKeThanhVien.ColumnHeadersHeight = 36;
            dgvThongKeThanhVien.CellFormatting += DgvThongKeThanhVien_CellFormatting;

            pnlBottom.Controls.Add(dgvThongKeThanhVien);
            pnlBottom.Controls.Add(lblBaoCaoTongQuan);
            pnlBottom.Controls.Add(lblHeaderThongKe);

            split.Panel1.Controls.Add(pnlTop);
            split.Panel2.Controls.Add(pnlBottom);
            tab.Controls.Add(split);
        }

        // ================= LOAD DATA & HANDLERS =================
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachDuAnCombo();
                LoadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu:\n" + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachDuAnCombo()
        {
            List<DuAnDTO> list = _duAnBUS.LayDanhSach();
            List<DuAnDTO> comboItems = new List<DuAnDTO>
            {
                new DuAnDTO { MaDuAn = 0, TenDuAn = "-- Tất cả dự án --" }
            };
            comboItems.AddRange(list);

            cboLocDuAn.DataSource = comboItems;
            cboLocDuAn.DisplayMember = "TenDuAn";
            cboLocDuAn.ValueMember = "MaDuAn";
            cboLocDuAn.SelectedIndex = 0;
        }

        private int LayMaDuAnDangChon()
        {
            if (cboLocDuAn.SelectedValue is int ma)
                return ma;
            return 0;
        }

        private void LoadAllData()
        {
            int maDuAn = LayMaDuAnDangChon();
            int? filterDuAn = maDuAn > 0 ? maDuAn : (int?)null;
            string trangThai = cboLocTrangThai.SelectedItem?.ToString();
            string timKiem = txtTimKiem.Text.Trim();

            // 1. Cập nhật KPI
            var kpi = _baoCaoBUS.ThongKeTongQuan(filterDuAn);
            lblKpiTong.Text = kpi.Tong.ToString();
            lblKpiToDo.Text = kpi.ToDo.ToString();
            lblKpiInProg.Text = kpi.InProgress.ToString();
            lblKpiReview.Text = kpi.Review.ToString();
            lblKpiDone.Text = kpi.Done.ToString();
            lblKpiTreHan.Text = kpi.TreHan.ToString();

            // 2. Load Kanban
            LoadKanbanBoard(filterDuAn, timKiem);

            // 3. Load List View
            List<CongViecDTO> dsTask = _congViecBUS.LayDanhSach(filterDuAn, trangThai, timKiem);
            dgvTasks.DataSource = dsTask;
            DinhDangCotTask(dgvTasks);

            // 4. Load Dự án
            List<DuAnDTO> dsDuAn = _duAnBUS.LayDanhSach();
            dgvDuAn.DataSource = dsDuAn;
            DinhDangCotDuAn(dgvDuAn);

            // 5. Load Thành viên
            List<ThanhVienDTO> dsTV = _thanhVienBUS.LayDanhSach();
            dgvThanhVien.DataSource = dsTV;
            DinhDangCotThanhVien(dgvThanhVien);

            // 6. Load Cảnh báo trễ hạn (SqlDataReader) & Báo cáo
            List<CongViecDTO> dsTreHan = _congViecBUS.LayCongViecTreHan(filterDuAn);
            dgvTreHan.DataSource = dsTreHan;
            DinhDangCotTreHan(dgvTreHan);

            List<ThongKeThanhVienDTO> dsThongKe = _baoCaoBUS.ThongKeTheoThanhVien(filterDuAn);
            dgvThongKeThanhVien.DataSource = dsThongKe;
            DinhDangCotThongKe(dgvThongKeThanhVien);
        }

        private void LoadKanbanBoard(int? filterDuAn, string timKiem)
        {
            pnlColToDo.SuspendLayout();
            pnlColInProg.SuspendLayout();
            pnlColReview.SuspendLayout();
            pnlColDone.SuspendLayout();

            pnlColToDo.Controls.Clear();
            pnlColInProg.Controls.Clear();
            pnlColReview.Controls.Clear();
            pnlColDone.Controls.Clear();

            List<CongViecDTO> allTasks = _congViecBUS.LayDanhSach(filterDuAn, null, timKiem);

            int countToDo = 0;
            int countInProg = 0;
            int countReview = 0;
            int countDone = 0;

            foreach (var task in allTasks)
            {
                Panel card = CreateTaskCard(task);
                switch (task.TrangThai)
                {
                    case "To Do":
                        pnlColToDo.Controls.Add(card);
                        countToDo++;
                        break;
                    case "In Progress":
                        pnlColInProg.Controls.Add(card);
                        countInProg++;
                        break;
                    case "Review":
                        pnlColReview.Controls.Add(card);
                        countReview++;
                        break;
                    case "Done":
                        pnlColDone.Controls.Add(card);
                        countDone++;
                        break;
                }
            }

            lblCountToDo.Text = countToDo.ToString();
            lblCountInProg.Text = countInProg.ToString();
            lblCountReview.Text = countReview.ToString();
            lblCountDone.Text = countDone.ToString();

            pnlColToDo.ResumeLayout();
            pnlColInProg.ResumeLayout();
            pnlColReview.ResumeLayout();
            pnlColDone.ResumeLayout();
        }

        private Panel CreateTaskCard(CongViecDTO task)
        {
            Panel card = new Panel
            {
                Width = 270,
                Height = 160,
                BackColor = Color.White,
                Margin = new Padding(3, 4, 3, 8),
                Padding = new Padding(10)
            };

            // Viền đỏ nếu quá hạn
            if (task.IsOverdue)
            {
                card.Paint += (s, e) =>
                {
                    using (Pen p = new Pen(Color.FromArgb(239, 68, 68), 2))
                    {
                        e.Graphics.DrawRectangle(p, 0, 0, card.Width - 1, card.Height - 1);
                    }
                };
            }

            // Tag Dự án + Độ ưu tiên
            Label lblProjectTag = new Label
            {
                Text = task.TenDuAn,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                BackColor = Color.FromArgb(241, 245, 249),
                Location = new Point(8, 8),
                AutoSize = true,
                Padding = new Padding(3, 1, 3, 1)
            };

            Color priorityColor = task.DoUuTien == "Cao" ? Color.FromArgb(239, 68, 68) :
                                  task.DoUuTien == "Trung bình" ? Color.FromArgb(245, 158, 11) : Color.FromArgb(16, 185, 129);
            Label lblPriority = new Label
            {
                Text = task.DoUuTien,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = priorityColor,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(card.Width - 65, 8),
                Size = new Size(55, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Tên Task
            Label lblTaskTitle = new Label
            {
                Text = task.TenTask,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(8, 30),
                Size = new Size(250, 36),
                AutoEllipsis = true
            };

            // Hạn nộp & Cảnh báo quá hạn
            string hanNopStr = task.HanNop.HasValue ? task.HanNop.Value.ToString("dd/MM/yyyy") : "Không có";
            Label lblDueDate = new Label
            {
                Text = task.IsOverdue ? $"⚠️ Quá hạn {task.SoNgayTreHan} ngày ({hanNopStr})" : $"📅 Hạn: {hanNopStr}",
                Font = new Font("Segoe UI", 8f, task.IsOverdue ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = task.IsOverdue ? Color.FromArgb(220, 38, 38) : Color.FromArgb(100, 116, 139),
                Location = new Point(8, 70),
                AutoSize = true
            };

            // Người phụ trách
            Label lblAssignee = new Label
            {
                Text = "👤 " + (string.IsNullOrWhiteSpace(task.DanhSachThanhVien) ? "Chưa giao" : task.DanhSachThanhVien),
                Font = new Font("Segoe UI", 8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(8, 92),
                Size = new Size(250, 20),
                AutoEllipsis = true
            };

            // Nút điều hướng trạng thái
            Panel pnlActions = new Panel
            {
                Location = new Point(5, 120),
                Size = new Size(260, 32),
                BackColor = Color.FromArgb(248, 250, 252)
            };

            // Nút Lùi trạng thái
            string prevStatus = LayTrangThaiLui(task.TrangThai);
            if (!string.IsNullOrEmpty(prevStatus))
            {
                Button btnPrev = new Button
                {
                    Text = "◀ " + prevStatus,
                    Size = new Size(80, 26),
                    Location = new Point(5, 3),
                    Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnPrev.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                btnPrev.Click += (s, e) => ChuyenTrangThaiTask(task.MaTask, prevStatus);
                pnlActions.Controls.Add(btnPrev);
            }

            // Nút Tiến trạng thái
            string nextStatus = LayTrangThaiTien(task.TrangThai);
            if (!string.IsNullOrEmpty(nextStatus))
            {
                Button btnNext = new Button
                {
                    Text = nextStatus + " ▶",
                    Size = new Size(80, 26),
                    Location = new Point(90, 3),
                    Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                    BackColor = Color.FromArgb(37, 99, 235),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnNext.FlatAppearance.BorderSize = 0;
                btnNext.Click += (s, e) => ChuyenTrangThaiTask(task.MaTask, nextStatus);
                pnlActions.Controls.Add(btnNext);
            }

            // Nút Sửa
            Button btnEdit = new Button
            {
                Text = "✏",
                Size = new Size(30, 26),
                Location = new Point(185, 3),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnEdit.Click += (s, e) =>
            {
                FormTask frm = new FormTask(task.MaTask);
                if (frm.ShowDialog() == DialogResult.OK) LoadAllData();
            };
            pnlActions.Controls.Add(btnEdit);

            // Nút Xóa
            Button btnDel = new Button
            {
                Text = "🗑",
                Size = new Size(30, 26),
                Location = new Point(220, 3),
                BackColor = Color.FromArgb(254, 242, 242),
                ForeColor = Color.FromArgb(220, 38, 38),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnDel.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnDel.Click += (s, e) =>
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa task '{task.TenTask}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var res = _congViecBUS.Xoa(task.MaTask);
                    if (res.Success) LoadAllData();
                    else MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            pnlActions.Controls.Add(btnDel);

            card.Controls.Add(lblProjectTag);
            card.Controls.Add(lblPriority);
            card.Controls.Add(lblTaskTitle);
            card.Controls.Add(lblDueDate);
            card.Controls.Add(lblAssignee);
            card.Controls.Add(pnlActions);

            return card;
        }

        private string LayTrangThaiLui(string current)
        {
            switch (current)
            {
                case "In Progress": return "To Do";
                case "Review": return "In Progress";
                case "Done": return "Review";
                default: return null;
            }
        }

        private string LayTrangThaiTien(string current)
        {
            switch (current)
            {
                case "To Do": return "In Progress";
                case "In Progress": return "Review";
                case "Review": return "Done";
                default: return null;
            }
        }

        private void ChuyenTrangThaiTask(int maTask, string trangThaiMoi)
        {
            var res = _congViecBUS.ChuyenTrangThai(maTask, trangThaiMoi);
            if (res.Success)
            {
                LoadAllData();
            }
            else
            {
                MessageBox.Show(res.Message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChuyenTrangThaiDangChon(string trangThaiMoi)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 công việc từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTask = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["MaTask"].Value);
            ChuyenTrangThaiTask(maTask, trangThaiMoi);
        }

        // ================= CRUD ACTIONS =================
        private void BtnThemTask_Click(object sender, EventArgs e)
        {
            int maDuAn = LayMaDuAnDangChon();
            FormTask frm = new FormTask(0, maDuAn);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAllData();
            }
        }

        private void BtnSuaTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công việc cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTask = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["MaTask"].Value);
            FormTask frm = new FormTask(maTask);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAllData();
            }
        }

        private void BtnXoaTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn công việc cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTask = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["MaTask"].Value);
            string tenTask = dgvTasks.SelectedRows[0].Cells["TenTask"].Value?.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa công việc: '{tenTask}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var res = _congViecBUS.Xoa(maTask);
                if (res.Success)
                {
                    MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
                else
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnThemDuAn_Click(object sender, EventArgs e)
        {
            FormDuAn frm = new FormDuAn(0);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachDuAnCombo();
                LoadAllData();
            }
        }

        private void BtnSuaDuAn_Click(object sender, EventArgs e)
        {
            if (dgvDuAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dự án cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDuAn = Convert.ToInt32(dgvDuAn.SelectedRows[0].Cells["MaDuAn"].Value);
            FormDuAn frm = new FormDuAn(maDuAn);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachDuAnCombo();
                LoadAllData();
            }
        }

        private void BtnXoaDuAn_Click(object sender, EventArgs e)
        {
            if (dgvDuAn.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dự án cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDuAn = Convert.ToInt32(dgvDuAn.SelectedRows[0].Cells["MaDuAn"].Value);
            string tenDuAn = dgvDuAn.SelectedRows[0].Cells["TenDuAn"].Value?.ToString();

            if (MessageBox.Show($"Xóa dự án '{tenDuAn}' sẽ đồng thời xóa TẤT CẢ công việc thuộc dự án này.\nBạn có chắc chắn?", "Xác nhận xóa dự án", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var res = _duAnBUS.Xoa(maDuAn);
                if (res.Success)
                {
                    MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDuAnCombo();
                    LoadAllData();
                }
                else
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnThemThanhVien_Click(object sender, EventArgs e)
        {
            FormThanhVien frm = new FormThanhVien(0);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAllData();
            }
        }

        private void BtnSuaThanhVien_Click(object sender, EventArgs e)
        {
            if (dgvThanhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTV = Convert.ToInt32(dgvThanhVien.SelectedRows[0].Cells["MaThanhVien"].Value);
            FormThanhVien frm = new FormThanhVien(maTV);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAllData();
            }
        }

        private void BtnXoaThanhVien_Click(object sender, EventArgs e)
        {
            if (dgvThanhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTV = Convert.ToInt32(dgvThanhVien.SelectedRows[0].Cells["MaThanhVien"].Value);
            string hoTen = dgvThanhVien.SelectedRows[0].Cells["HoTen"].Value?.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa thành viên '{hoTen}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var res = _thanhVienBUS.Xoa(maTV);
                if (res.Success)
                {
                    MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
                else
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllData();
        }

        // ================= ĐỊNH DẠNG DATA GRID VIEW =================
        private void DinhDangCotTask(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            dgv.Columns["MaTask"].HeaderText = "Mã";
            dgv.Columns["MaTask"].FillWeight = 40;

            dgv.Columns["TenTask"].HeaderText = "Tên công việc";
            dgv.Columns["TenTask"].FillWeight = 160;

            dgv.Columns["TenDuAn"].HeaderText = "Dự án";
            dgv.Columns["TenDuAn"].FillWeight = 120;

            dgv.Columns["DoUuTien"].HeaderText = "Độ ưu tiên";
            dgv.Columns["DoUuTien"].FillWeight = 70;

            dgv.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgv.Columns["TrangThai"].FillWeight = 80;

            dgv.Columns["HanNop"].HeaderText = "Hạn nộp";
            dgv.Columns["HanNop"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns["HanNop"].FillWeight = 80;

            dgv.Columns["DanhSachThanhVien"].HeaderText = "Thành viên phụ trách";
            dgv.Columns["DanhSachThanhVien"].FillWeight = 140;

            if (dgv.Columns.Contains("MaDuAn")) dgv.Columns["MaDuAn"].Visible = false;
            if (dgv.Columns.Contains("MoTa")) dgv.Columns["MoTa"].Visible = false;
            if (dgv.Columns.Contains("IsOverdue")) dgv.Columns["IsOverdue"].Visible = false;
            if (dgv.Columns.Contains("SoNgayTreHan")) dgv.Columns["SoNgayTreHan"].Visible = false;
        }

        private void DgvTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTasks.Rows.Count) return;
            var task = dgvTasks.Rows[e.RowIndex].DataBoundItem as CongViecDTO;
            if (task == null) return;

            if (task.IsOverdue)
            {
                dgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                dgvTasks.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            }
            else if (task.TrangThai == "Done")
            {
                dgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                dgvTasks.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(21, 128, 61);
            }
        }

        private void DinhDangCotDuAn(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;
            dgv.Columns["MaDuAn"].HeaderText = "Mã";
            dgv.Columns["MaDuAn"].FillWeight = 40;
            dgv.Columns["TenDuAn"].HeaderText = "Tên Dự Án";
            dgv.Columns["TenDuAn"].FillWeight = 180;
            dgv.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            dgv.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns["NgayBatDau"].FillWeight = 80;
            dgv.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            dgv.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns["NgayKetThuc"].FillWeight = 80;
            dgv.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgv.Columns["TrangThai"].FillWeight = 80;
            dgv.Columns["TongTask"].HeaderText = "Tổng Task";
            dgv.Columns["TongTask"].FillWeight = 65;
            dgv.Columns["TaskHoanThanh"].HeaderText = "Đã xong";
            dgv.Columns["TaskHoanThanh"].FillWeight = 65;
            dgv.Columns["TiLeHoanThanh"].HeaderText = "Tiến độ (%)";
            dgv.Columns["TiLeHoanThanh"].DefaultCellStyle.Format = "0.0'%'";
            dgv.Columns["TiLeHoanThanh"].FillWeight = 80;
        }

        private void DinhDangCotThanhVien(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;
            dgv.Columns["MaThanhVien"].HeaderText = "Mã";
            dgv.Columns["MaThanhVien"].FillWeight = 40;
            dgv.Columns["HoTen"].HeaderText = "Họ và tên";
            dgv.Columns["HoTen"].FillWeight = 150;
            dgv.Columns["Email"].HeaderText = "Email";
            dgv.Columns["Email"].FillWeight = 140;
            dgv.Columns["ChuyenMon"].HeaderText = "Chuyên môn / Vị trí";
            dgv.Columns["ChuyenMon"].FillWeight = 150;
        }

        private void DinhDangCotTreHan(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;
            dgv.Columns["MaTask"].HeaderText = "Mã";
            dgv.Columns["MaTask"].FillWeight = 40;
            dgv.Columns["TenTask"].HeaderText = "Công việc quá hạn";
            dgv.Columns["TenTask"].FillWeight = 160;
            dgv.Columns["TenDuAn"].HeaderText = "Dự án";
            dgv.Columns["TenDuAn"].FillWeight = 120;
            dgv.Columns["HanNop"].HeaderText = "Hạn chót";
            dgv.Columns["HanNop"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns["HanNop"].FillWeight = 80;
            dgv.Columns["SoNgayTreHan"].HeaderText = "Số ngày quá hạn";
            dgv.Columns["SoNgayTreHan"].FillWeight = 90;
            dgv.Columns["TrangThai"].HeaderText = "Trạng thái hiện tại";
            dgv.Columns["TrangThai"].FillWeight = 90;
            dgv.Columns["DanhSachThanhVien"].HeaderText = "Người phụ trách";
            dgv.Columns["DanhSachThanhVien"].FillWeight = 140;

            if (dgv.Columns.Contains("MaDuAn")) dgv.Columns["MaDuAn"].Visible = false;
            if (dgv.Columns.Contains("MoTa")) dgv.Columns["MoTa"].Visible = false;
            if (dgv.Columns.Contains("DoUuTien")) dgv.Columns["DoUuTien"].Visible = false;
            if (dgv.Columns.Contains("IsOverdue")) dgv.Columns["IsOverdue"].Visible = false;
        }

        private void DgvTreHan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvTreHan.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                dgvTreHan.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                if (dgvTreHan.Columns[e.ColumnIndex].Name == "SoNgayTreHan" && e.Value != null)
                {
                    e.Value = "⚠️ Trễ " + e.Value + " ngày";
                    e.FormattingApplied = true;
                }
            }
        }

        private void DinhDangCotThongKe(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;
            dgv.Columns["MaThanhVien"].HeaderText = "Mã";
            dgv.Columns["MaThanhVien"].FillWeight = 40;
            dgv.Columns["HoTen"].HeaderText = "Họ và tên thành viên";
            dgv.Columns["HoTen"].FillWeight = 150;
            dgv.Columns["Email"].HeaderText = "Email";
            dgv.Columns["Email"].FillWeight = 120;
            dgv.Columns["ChuyenMon"].HeaderText = "Chuyên môn";
            dgv.Columns["ChuyenMon"].FillWeight = 130;
            dgv.Columns["TongTask"].HeaderText = "Tổng Task giao";
            dgv.Columns["TongTask"].FillWeight = 80;
            dgv.Columns["TaskHoanThanh"].HeaderText = "Đã xong (Done)";
            dgv.Columns["TaskHoanThanh"].FillWeight = 85;
            dgv.Columns["TaskDangLam"].HeaderText = "Đang thực hiện";
            dgv.Columns["TaskDangLam"].FillWeight = 85;
            dgv.Columns["TaskTreHan"].HeaderText = "Bị trễ hạn";
            dgv.Columns["TaskTreHan"].FillWeight = 75;
            dgv.Columns["TiLeHoanThanh"].HeaderText = "Tỷ lệ hoàn thành (%)";
            dgv.Columns["TiLeHoanThanh"].DefaultCellStyle.Format = "0.0'%'";
            dgv.Columns["TiLeHoanThanh"].FillWeight = 110;
        }

        private void DgvThongKeThanhVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvThongKeThanhVien.Rows.Count) return;
            if (dgvThongKeThanhVien.Columns[e.ColumnIndex].Name == "TaskTreHan" && Convert.ToInt32(e.Value) > 0)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
            else if (dgvThongKeThanhVien.Columns[e.ColumnIndex].Name == "TiLeHoanThanh")
            {
                double val = Convert.ToDouble(e.Value);
                if (val >= 100)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                else if (val >= 50)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }
        }
    }
}
