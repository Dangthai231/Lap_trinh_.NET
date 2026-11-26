#nullable enable
namespace BankAtmManagement.Forms;

partial class frmBankAtmMain
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.menuStrip = new MenuStrip();
        this.mnuSystem = new ToolStripMenuItem();
        this.mnuLogout = new ToolStripMenuItem();
        this.mnuLockScreen = new ToolStripMenuItem();
        this.mnuSystemSeparator = new ToolStripSeparator();
        this.mnuExit = new ToolStripMenuItem();
        this.mnuAtmManagement = new ToolStripMenuItem();
        this.mnuAtmStations = new ToolStripMenuItem();
        this.mnuAtmReconciliation = new ToolStripMenuItem();
        this.mnuWindow = new ToolStripMenuItem();
        this.mnuCascade = new ToolStripMenuItem();
        this.mnuTileHorizontal = new ToolStripMenuItem();
        this.mnuTileVertical = new ToolStripMenuItem();
        this.mnuWindowSeparator = new ToolStripSeparator();
        this.mnuCloseAll = new ToolStripMenuItem();
        this.statusStrip = new StatusStrip();
        this.lblTeller = new ToolStripStatusLabel();
        this.lblCoreStatus = new ToolStripStatusLabel();
        this.lblProgressText = new ToolStripStatusLabel();
        this.prgReconciliation = new ToolStripProgressBar();
        this.menuStrip.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        // menuStrip
        this.menuStrip.BackColor = Color.FromArgb(245, 247, 251);
        this.menuStrip.Font = new Font("Segoe UI", 9.5F);
        this.menuStrip.Items.AddRange(new ToolStripItem[]
        {
            this.mnuSystem,
            this.mnuAtmManagement,
            this.mnuWindow
        });
        this.menuStrip.Location = new Point(0, 0);
        this.menuStrip.MdiWindowListItem = this.mnuWindow;
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Padding = new Padding(8, 3, 0, 3);
        this.menuStrip.Size = new Size(1240, 28);
        this.menuStrip.TabIndex = 0;
        this.menuStrip.Text = "Menu chính";

        // mnuSystem
        this.mnuSystem.DropDownItems.AddRange(new ToolStripItem[]
        {
            this.mnuLogout,
            this.mnuLockScreen,
            this.mnuSystemSeparator,
            this.mnuExit
        });
        this.mnuSystem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.mnuSystem.Name = "mnuSystem";
        this.mnuSystem.Size = new Size(85, 22);
        this.mnuSystem.Text = "Hệ thống";

        // mnuLogout
        this.mnuLogout.Font = new Font("Segoe UI", 9.5F);
        this.mnuLogout.Name = "mnuLogout";
        this.mnuLogout.Size = new Size(180, 24);
        this.mnuLogout.Text = "Đăng xuất";
        this.mnuLogout.Click += this.mnuLogout_Click;

        // mnuLockScreen
        this.mnuLockScreen.Font = new Font("Segoe UI", 9.5F);
        this.mnuLockScreen.Name = "mnuLockScreen";
        this.mnuLockScreen.ShortcutKeys = Keys.Control | Keys.L;
        this.mnuLockScreen.Size = new Size(180, 24);
        this.mnuLockScreen.Text = "Khóa màn hình";
        this.mnuLockScreen.Click += this.mnuLockScreen_Click;

        // mnuSystemSeparator
        this.mnuSystemSeparator.Name = "mnuSystemSeparator";
        this.mnuSystemSeparator.Size = new Size(177, 6);

        // mnuExit
        this.mnuExit.Font = new Font("Segoe UI", 9.5F);
        this.mnuExit.Name = "mnuExit";
        this.mnuExit.ShortcutKeys = Keys.Alt | Keys.F4;
        this.mnuExit.Size = new Size(180, 24);
        this.mnuExit.Text = "Thoát";
        this.mnuExit.Click += this.mnuExit_Click;

        // mnuAtmManagement
        this.mnuAtmManagement.DropDownItems.AddRange(new ToolStripItem[]
        {
            this.mnuAtmStations,
            this.mnuAtmReconciliation
        });
        this.mnuAtmManagement.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.mnuAtmManagement.Name = "mnuAtmManagement";
        this.mnuAtmManagement.Size = new Size(110, 22);
        this.mnuAtmManagement.Text = "Quản lý ATM";

        // mnuAtmStations
        this.mnuAtmStations.Font = new Font("Segoe UI", 9.5F);
        this.mnuAtmStations.Name = "mnuAtmStations";
        this.mnuAtmStations.ShortcutKeys = Keys.F2;
        this.mnuAtmStations.Size = new Size(275, 24);
        this.mnuAtmStations.Text = "Danh sách Trạm ATM && Tồn quỹ";
        this.mnuAtmStations.Click += this.mnuAtmStations_Click;

        // mnuAtmReconciliation
        this.mnuAtmReconciliation.Font = new Font("Segoe UI", 9.5F);
        this.mnuAtmReconciliation.Name = "mnuAtmReconciliation";
        this.mnuAtmReconciliation.ShortcutKeys = Keys.F3;
        this.mnuAtmReconciliation.Size = new Size(275, 24);
        this.mnuAtmReconciliation.Text = "Đối soát Giao dịch Cuối ngày";
        this.mnuAtmReconciliation.Click += this.mnuAtmReconciliation_Click;

        // mnuWindow
        this.mnuWindow.DropDownItems.AddRange(new ToolStripItem[]
        {
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.mnuWindowSeparator,
            this.mnuCloseAll
        });
        this.mnuWindow.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.mnuWindow.Name = "mnuWindow";
        this.mnuWindow.Size = new Size(72, 22);
        this.mnuWindow.Text = "Cửa sổ";

        // mnuCascade
        this.mnuCascade.Font = new Font("Segoe UI", 9.5F);
        this.mnuCascade.Name = "mnuCascade";
        this.mnuCascade.Size = new Size(235, 24);
        this.mnuCascade.Text = "Xếp tầng (Cascade)";
        this.mnuCascade.Click += this.mnuCascade_Click;

        // mnuTileHorizontal
        this.mnuTileHorizontal.Font = new Font("Segoe UI", 9.5F);
        this.mnuTileHorizontal.Name = "mnuTileHorizontal";
        this.mnuTileHorizontal.Size = new Size(235, 24);
        this.mnuTileHorizontal.Text = "Xếp ngang (Tile Horizontal)";
        this.mnuTileHorizontal.Click += this.mnuTileHorizontal_Click;

        // mnuTileVertical
        this.mnuTileVertical.Font = new Font("Segoe UI", 9.5F);
        this.mnuTileVertical.Name = "mnuTileVertical";
        this.mnuTileVertical.Size = new Size(235, 24);
        this.mnuTileVertical.Text = "Xếp dọc (Tile Vertical)";
        this.mnuTileVertical.Click += this.mnuTileVertical_Click;

        // mnuWindowSeparator
        this.mnuWindowSeparator.Name = "mnuWindowSeparator";
        this.mnuWindowSeparator.Size = new Size(232, 6);

        // mnuCloseAll
        this.mnuCloseAll.Font = new Font("Segoe UI", 9.5F);
        this.mnuCloseAll.Name = "mnuCloseAll";
        this.mnuCloseAll.Size = new Size(235, 24);
        this.mnuCloseAll.Text = "Đóng tất cả";
        this.mnuCloseAll.Click += this.mnuCloseAll_Click;

        // statusStrip
        this.statusStrip.BackColor = Color.FromArgb(240, 244, 249);
        this.statusStrip.Font = new Font("Segoe UI", 9F);
        this.statusStrip.Items.AddRange(new ToolStripItem[]
        {
            this.lblTeller,
            this.lblCoreStatus,
            this.lblProgressText,
            this.prgReconciliation
        });
        this.statusStrip.Location = new Point(0, 734);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Padding = new Padding(8, 2, 14, 2);
        this.statusStrip.Size = new Size(1240, 28);
        this.statusStrip.TabIndex = 1;
        this.statusStrip.Text = "Trạng thái hệ thống";

        // lblTeller
        this.lblTeller.BorderSides = ToolStripStatusLabelBorderSides.Right;
        this.lblTeller.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblTeller.ForeColor = Color.FromArgb(20, 48, 88);
        this.lblTeller.Name = "lblTeller";
        this.lblTeller.Padding = new Padding(4, 0, 12, 0);
        this.lblTeller.Size = new Size(280, 23);
        this.lblTeller.Text = "Giao dịch viên trực: Trần Hoàng Nam (GDV-001)";

        // lblCoreStatus
        this.lblCoreStatus.BorderSides = ToolStripStatusLabelBorderSides.Right;
        this.lblCoreStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblCoreStatus.ForeColor = Color.FromArgb(16, 124, 65);
        this.lblCoreStatus.Name = "lblCoreStatus";
        this.lblCoreStatus.Padding = new Padding(8, 0, 12, 0);
        this.lblCoreStatus.Size = new Size(235, 23);
        this.lblCoreStatus.Text = "● Core Banking: Đã kết nối (Online)";

        // lblProgressText
        this.lblProgressText.Name = "lblProgressText";
        this.lblProgressText.Padding = new Padding(8, 0, 8, 0);
        this.lblProgressText.Size = new Size(498, 23);
        this.lblProgressText.Spring = true;
        this.lblProgressText.Text = "Tiến độ đối soát: Sẵn sàng";
        this.lblProgressText.TextAlign = ContentAlignment.MiddleRight;

        // prgReconciliation
        this.prgReconciliation.Maximum = 100;
        this.prgReconciliation.Minimum = 0;
        this.prgReconciliation.Name = "prgReconciliation";
        this.prgReconciliation.Size = new Size(200, 20);
        this.prgReconciliation.Style = ProgressBarStyle.Continuous;
        this.prgReconciliation.Value = 0;

        // frmBankAtmMain
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1240, 762);
        this.Controls.Add(this.statusStrip);
        this.Controls.Add(this.menuStrip);
        this.IsMdiContainer = true;
        this.MainMenuStrip = this.menuStrip;
        this.MinimumSize = new Size(960, 620);
        this.Name = "frmBankAtmMain";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Hệ thống Điều hành Mạng lưới Cây ATM Ngân hàng (MDI)";
        this.WindowState = FormWindowState.Maximized;
        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private MenuStrip menuStrip = null!;
    private ToolStripMenuItem mnuSystem = null!;
    private ToolStripMenuItem mnuLogout = null!;
    private ToolStripMenuItem mnuLockScreen = null!;
    private ToolStripSeparator mnuSystemSeparator = null!;
    private ToolStripMenuItem mnuExit = null!;
    private ToolStripMenuItem mnuAtmManagement = null!;
    private ToolStripMenuItem mnuAtmStations = null!;
    private ToolStripMenuItem mnuAtmReconciliation = null!;
    private ToolStripMenuItem mnuWindow = null!;
    private ToolStripMenuItem mnuCascade = null!;
    private ToolStripMenuItem mnuTileHorizontal = null!;
    private ToolStripMenuItem mnuTileVertical = null!;
    private ToolStripSeparator mnuWindowSeparator = null!;
    private ToolStripMenuItem mnuCloseAll = null!;
    private StatusStrip statusStrip = null!;
    private ToolStripStatusLabel lblTeller = null!;
    private ToolStripStatusLabel lblCoreStatus = null!;
    private ToolStripStatusLabel lblProgressText = null!;
    private ToolStripProgressBar prgReconciliation = null!;
}
