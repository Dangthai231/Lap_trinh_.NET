#nullable enable
namespace BankAtmManagement.Forms;

partial class frmAtmReconciliation
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
        this.pnlTop = new Panel();
        this.lblTitle = new Label();
        this.lblDate = new Label();
        this.dtpReconcileDate = new DateTimePicker();
        this.lblScope = new Label();
        this.cboStationScope = new ComboBox();
        this.btnRunReconciliation = new Button();
        this.btnStopReconciliation = new Button();
        this.pnlProgress = new Panel();
        this.lblStage = new Label();
        this.lblPercent = new Label();
        this.prgLocal = new ProgressBar();
        this.lblStats = new Label();
        this.splitMain = new SplitContainer();
        this.grpDiscrepancies = new GroupBox();
        this.dgvDiscrepancies = new DataGridView();
        this.grpLogs = new GroupBox();
        this.lstLogs = new ListBox();

        this.pnlTop.SuspendLayout();
        this.pnlProgress.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
        this.splitMain.Panel1.SuspendLayout();
        this.splitMain.Panel2.SuspendLayout();
        this.splitMain.SuspendLayout();
        this.grpDiscrepancies.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDiscrepancies)).BeginInit();
        this.grpLogs.SuspendLayout();
        this.SuspendLayout();

        // pnlTop
        this.pnlTop.BackColor = Color.FromArgb(245, 248, 252);
        this.pnlTop.Controls.Add(this.btnStopReconciliation);
        this.pnlTop.Controls.Add(this.btnRunReconciliation);
        this.pnlTop.Controls.Add(this.cboStationScope);
        this.pnlTop.Controls.Add(this.lblScope);
        this.pnlTop.Controls.Add(this.dtpReconcileDate);
        this.pnlTop.Controls.Add(this.lblDate);
        this.pnlTop.Controls.Add(this.lblTitle);
        this.pnlTop.Dock = DockStyle.Top;
        this.pnlTop.Location = new Point(0, 0);
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Size = new Size(1020, 92);
        this.pnlTop.TabIndex = 0;

        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
        this.lblTitle.ForeColor = Color.FromArgb(15, 52, 96);
        this.lblTitle.Location = new Point(14, 10);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new Size(420, 23);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "ĐỐI SOÁT SAO KÊ GIAO DỊCH ATM CUỐI NGÀY (ASYNC)";

        // lblDate
        this.lblDate.AutoSize = true;
        this.lblDate.Font = new Font("Segoe UI", 9.5F);
        this.lblDate.Location = new Point(14, 51);
        this.lblDate.Name = "lblDate";
        this.lblDate.Size = new Size(92, 17);
        this.lblDate.TabIndex = 1;
        this.lblDate.Text = "Ngày đối soát:";

        // dtpReconcileDate
        this.dtpReconcileDate.Font = new Font("Segoe UI", 9.5F);
        this.dtpReconcileDate.Format = DateTimePickerFormat.Short;
        this.dtpReconcileDate.Location = new Point(112, 47);
        this.dtpReconcileDate.Name = "dtpReconcileDate";
        this.dtpReconcileDate.Size = new Size(128, 24);
        this.dtpReconcileDate.TabIndex = 2;

        // lblScope
        this.lblScope.AutoSize = true;
        this.lblScope.Font = new Font("Segoe UI", 9.5F);
        this.lblScope.Location = new Point(256, 51);
        this.lblScope.Name = "lblScope";
        this.lblScope.Size = new Size(68, 17);
        this.lblScope.TabIndex = 3;
        this.lblScope.Text = "Phạm vi:";

        // cboStationScope
        this.cboStationScope.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboStationScope.Font = new Font("Segoe UI", 9.5F);
        this.cboStationScope.FormattingEnabled = true;
        this.cboStationScope.Location = new Point(324, 47);
        this.cboStationScope.Name = "cboStationScope";
        this.cboStationScope.Size = new Size(210, 25);
        this.cboStationScope.TabIndex = 4;

        // btnRunReconciliation
        this.btnRunReconciliation.BackColor = Color.FromArgb(15, 98, 254);
        this.btnRunReconciliation.FlatAppearance.BorderSize = 0;
        this.btnRunReconciliation.FlatStyle = FlatStyle.Flat;
        this.btnRunReconciliation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.btnRunReconciliation.ForeColor = Color.White;
        this.btnRunReconciliation.Location = new Point(558, 42);
        this.btnRunReconciliation.Name = "btnRunReconciliation";
        this.btnRunReconciliation.Size = new Size(215, 34);
        this.btnRunReconciliation.TabIndex = 5;
        this.btnRunReconciliation.Text = "Chạy Đối Soát Tự Động";
        this.btnRunReconciliation.UseVisualStyleBackColor = false;
        this.btnRunReconciliation.Click += this.btnRunReconciliation_Click;

        // btnStopReconciliation
        this.btnStopReconciliation.BackColor = Color.FromArgb(220, 38, 38);
        this.btnStopReconciliation.Enabled = false;
        this.btnStopReconciliation.FlatAppearance.BorderSize = 0;
        this.btnStopReconciliation.FlatStyle = FlatStyle.Flat;
        this.btnStopReconciliation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.btnStopReconciliation.ForeColor = Color.White;
        this.btnStopReconciliation.Location = new Point(783, 42);
        this.btnStopReconciliation.Name = "btnStopReconciliation";
        this.btnStopReconciliation.Size = new Size(160, 34);
        this.btnStopReconciliation.TabIndex = 6;
        this.btnStopReconciliation.Text = "Dừng Đối Soát";
        this.btnStopReconciliation.UseVisualStyleBackColor = false;
        this.btnStopReconciliation.Click += this.btnStopReconciliation_Click;

        // pnlProgress
        this.pnlProgress.BackColor = Color.White;
        this.pnlProgress.BorderStyle = BorderStyle.FixedSingle;
        this.pnlProgress.Controls.Add(this.lblStats);
        this.pnlProgress.Controls.Add(this.prgLocal);
        this.pnlProgress.Controls.Add(this.lblPercent);
        this.pnlProgress.Controls.Add(this.lblStage);
        this.pnlProgress.Dock = DockStyle.Top;
        this.pnlProgress.Location = new Point(0, 92);
        this.pnlProgress.Name = "pnlProgress";
        this.pnlProgress.Padding = new Padding(14, 10, 14, 10);
        this.pnlProgress.Size = new Size(1020, 92);
        this.pnlProgress.TabIndex = 1;

        // lblStage
        this.lblStage.AutoSize = true;
        this.lblStage.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.lblStage.ForeColor = Color.FromArgb(30, 41, 59);
        this.lblStage.Location = new Point(14, 10);
        this.lblStage.Name = "lblStage";
        this.lblStage.Size = new Size(340, 17);
        this.lblStage.TabIndex = 0;
        this.lblStage.Text = "Trạng thái: Sẵn sàng thực hiện đối soát giao dịch cuối ngày.";

        // lblPercent
        this.lblPercent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.lblPercent.AutoSize = false;
        this.lblPercent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.lblPercent.ForeColor = Color.FromArgb(15, 98, 254);
        this.lblPercent.Location = new Point(920, 8);
        this.lblPercent.Name = "lblPercent";
        this.lblPercent.Size = new Size(84, 22);
        this.lblPercent.TabIndex = 1;
        this.lblPercent.Text = "0%";
        this.lblPercent.TextAlign = ContentAlignment.MiddleRight;

        // prgLocal
        this.prgLocal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.prgLocal.Location = new Point(14, 34);
        this.prgLocal.Name = "prgLocal";
        this.prgLocal.Size = new Size(990, 22);
        this.prgLocal.Style = ProgressBarStyle.Continuous;
        this.prgLocal.TabIndex = 2;

        // lblStats
        this.lblStats.AutoSize = true;
        this.lblStats.Font = new Font("Segoe UI", 9F);
        this.lblStats.ForeColor = Color.FromArgb(71, 85, 105);
        this.lblStats.Location = new Point(14, 64);
        this.lblStats.Name = "lblStats";
        this.lblStats.Size = new Size(380, 15);
        this.lblStats.TabIndex = 3;
        this.lblStats.Text = "Đã đối chiếu: 0 / 0 giao dịch | Sai lệch phát hiện: 0 | Thời gian: 0.0s";

        // splitMain
        this.splitMain.Dock = DockStyle.Fill;
        this.splitMain.Location = new Point(0, 184);
        this.splitMain.Name = "splitMain";
        this.splitMain.Orientation = Orientation.Horizontal;
        this.splitMain.Padding = new Padding(10);
        this.splitMain.Panel1.Controls.Add(this.grpDiscrepancies);
        this.splitMain.Panel2.Controls.Add(this.grpLogs);
        this.splitMain.Size = new Size(1020, 446);
        this.splitMain.SplitterDistance = 270;
        this.splitMain.TabIndex = 2;

        // grpDiscrepancies
        this.grpDiscrepancies.Dock = DockStyle.Fill;
        this.grpDiscrepancies.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.grpDiscrepancies.ForeColor = Color.FromArgb(15, 52, 96);
        this.grpDiscrepancies.Location = new Point(0, 0);
        this.grpDiscrepancies.Name = "grpDiscrepancies";
        this.grpDiscrepancies.Padding = new Padding(8);
        this.grpDiscrepancies.Size = new Size(1000, 250);
        this.grpDiscrepancies.TabIndex = 0;
        this.grpDiscrepancies.TabStop = false;
        this.grpDiscrepancies.Text = "Danh sách giao dịch chênh lệch / cần tra soát";

        // dgvDiscrepancies
        this.dgvDiscrepancies.AllowUserToAddRows = false;
        this.dgvDiscrepancies.AllowUserToDeleteRows = false;
        this.dgvDiscrepancies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvDiscrepancies.BackgroundColor = Color.White;
        this.dgvDiscrepancies.BorderStyle = BorderStyle.None;
        this.dgvDiscrepancies.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvDiscrepancies.ColumnHeadersHeight = 34;
        this.dgvDiscrepancies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.dgvDiscrepancies.Dock = DockStyle.Fill;
        this.dgvDiscrepancies.Location = new Point(8, 25);
        this.dgvDiscrepancies.Name = "dgvDiscrepancies";
        this.dgvDiscrepancies.ReadOnly = true;
        this.dgvDiscrepancies.RowHeadersVisible = false;
        this.dgvDiscrepancies.RowTemplate.Height = 28;
        this.dgvDiscrepancies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvDiscrepancies.Size = new Size(984, 217);
        this.dgvDiscrepancies.TabIndex = 0;

        this.grpDiscrepancies.Controls.Add(this.dgvDiscrepancies);

        // grpLogs
        this.grpLogs.Dock = DockStyle.Fill;
        this.grpLogs.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.grpLogs.ForeColor = Color.FromArgb(15, 52, 96);
        this.grpLogs.Location = new Point(0, 0);
        this.grpLogs.Name = "grpLogs";
        this.grpLogs.Padding = new Padding(8);
        this.grpLogs.Size = new Size(1000, 152);
        this.grpLogs.TabIndex = 0;
        this.grpLogs.TabStop = false;
        this.grpLogs.Text = "Nhật ký tiến trình đối soát bất đồng bộ (Log)";

        // lstLogs
        this.lstLogs.BackColor = Color.FromArgb(15, 23, 42);
        this.lstLogs.BorderStyle = BorderStyle.None;
        this.lstLogs.Dock = DockStyle.Fill;
        this.lstLogs.Font = new Font("Consolas", 9.5F);
        this.lstLogs.ForeColor = Color.FromArgb(226, 232, 240);
        this.lstLogs.FormattingEnabled = true;
        this.lstLogs.ItemHeight = 16;
        this.lstLogs.Location = new Point(8, 25);
        this.lstLogs.Name = "lstLogs";
        this.lstLogs.Size = new Size(984, 119);
        this.lstLogs.TabIndex = 0;

        this.grpLogs.Controls.Add(this.lstLogs);

        // frmAtmReconciliation
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(1020, 630);
        this.Controls.Add(this.splitMain);
        this.Controls.Add(this.pnlProgress);
        this.Controls.Add(this.pnlTop);
        this.MinimumSize = new Size(780, 480);
        this.Name = "frmAtmReconciliation";
        this.Text = "Đối soát Sao kê Giao dịch ATM Cuối ngày";
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.pnlProgress.ResumeLayout(false);
        this.pnlProgress.PerformLayout();
        this.splitMain.Panel1.ResumeLayout(false);
        this.splitMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
        this.splitMain.ResumeLayout(false);
        this.grpDiscrepancies.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvDiscrepancies)).EndInit();
        this.grpLogs.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private Panel pnlTop = null!;
    private Label lblTitle = null!;
    private Label lblDate = null!;
    private DateTimePicker dtpReconcileDate = null!;
    private Label lblScope = null!;
    private ComboBox cboStationScope = null!;
    private Button btnRunReconciliation = null!;
    private Button btnStopReconciliation = null!;
    private Panel pnlProgress = null!;
    private Label lblStage = null!;
    private Label lblPercent = null!;
    private ProgressBar prgLocal = null!;
    private Label lblStats = null!;
    private SplitContainer splitMain = null!;
    private GroupBox grpDiscrepancies = null!;
    private DataGridView dgvDiscrepancies = null!;
    private GroupBox grpLogs = null!;
    private ListBox lstLogs = null!;
}
