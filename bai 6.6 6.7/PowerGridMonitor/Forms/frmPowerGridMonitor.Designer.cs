#nullable enable
namespace PowerGridMonitor.Forms;

partial class frmPowerGridMonitor
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
        this.pnlHeader = new Panel();
        this.lblHeaderTitle = new Label();
        this.lblHeaderSubtitle = new Label();
        this.pnlControls = new Panel();
        this.lblSubstation = new Label();
        this.cboSubstation = new ComboBox();
        this.btnStartScada = new Button();
        this.btnDisconnect = new Button();
        this.pnlDashboard = new Panel();
        this.pnlVoltageCard = new Panel();
        this.lblVoltageTitle = new Label();
        this.lblVoltage = new Label();
        this.lblVoltageNote = new Label();
        this.pnlLoadCard = new Panel();
        this.lblLoadTitle = new Label();
        this.lblLoadPercent = new Label();
        this.lblLoadAlert = new Label();
        this.prgLoadBar = new ProgressBar();
        this.grpLogs = new GroupBox();
        this.dgvGridLogs = new DataGridView();
        this.statusStrip = new StatusStrip();
        this.lblScadaState = new ToolStripStatusLabel();
        this.lblLastPacketTime = new ToolStripStatusLabel();
        this.lblTotalCycles = new ToolStripStatusLabel();

        this.pnlHeader.SuspendLayout();
        this.pnlControls.SuspendLayout();
        this.pnlDashboard.SuspendLayout();
        this.pnlVoltageCard.SuspendLayout();
        this.pnlLoadCard.SuspendLayout();
        this.grpLogs.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).BeginInit();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        // pnlHeader
        this.pnlHeader.BackColor = Color.FromArgb(15, 42, 74);
        this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
        this.pnlHeader.Controls.Add(this.lblHeaderTitle);
        this.pnlHeader.Dock = DockStyle.Top;
        this.pnlHeader.Location = new Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Size = new Size(1000, 68);
        this.pnlHeader.TabIndex = 0;

        // lblHeaderTitle
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = Color.White;
        this.lblHeaderTitle.Location = new Point(18, 10);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new Size(560, 25);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "TRUNG TÂM ĐIỀU ĐỘ && GIÁM SÁT LƯỚI ĐIỆN THỜI GIAN THỰC";

        // lblHeaderSubtitle
        this.lblHeaderSubtitle.AutoSize = true;
        this.lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
        this.lblHeaderSubtitle.ForeColor = Color.FromArgb(186, 210, 240);
        this.lblHeaderSubtitle.Location = new Point(20, 39);
        this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        this.lblHeaderSubtitle.Size = new Size(390, 15);
        this.lblHeaderSubtitle.TabIndex = 1;
        this.lblHeaderSubtitle.Text = "Hệ thống SCADA thu thập thông số trạm biến áp (Cross-Thread Safety)";

        // pnlControls
        this.pnlControls.BackColor = Color.FromArgb(245, 248, 252);
        this.pnlControls.Controls.Add(this.btnDisconnect);
        this.pnlControls.Controls.Add(this.btnStartScada);
        this.pnlControls.Controls.Add(this.cboSubstation);
        this.pnlControls.Controls.Add(this.lblSubstation);
        this.pnlControls.Dock = DockStyle.Top;
        this.pnlControls.Location = new Point(0, 68);
        this.pnlControls.Name = "pnlControls";
        this.pnlControls.Size = new Size(1000, 62);
        this.pnlControls.TabIndex = 1;

        // lblSubstation
        this.lblSubstation.AutoSize = true;
        this.lblSubstation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.lblSubstation.ForeColor = Color.FromArgb(30, 41, 59);
        this.lblSubstation.Location = new Point(18, 21);
        this.lblSubstation.Name = "lblSubstation";
        this.lblSubstation.Size = new Size(115, 17);
        this.lblSubstation.TabIndex = 0;
        this.lblSubstation.Text = "Chọn Trạm biến áp:";

        // cboSubstation
        this.cboSubstation.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboSubstation.Font = new Font("Segoe UI", 10F);
        this.cboSubstation.FormattingEnabled = true;
        this.cboSubstation.Location = new Point(145, 17);
        this.cboSubstation.Name = "cboSubstation";
        this.cboSubstation.Size = new Size(290, 25);
        this.cboSubstation.TabIndex = 1;
        this.cboSubstation.SelectedIndexChanged += this.cboSubstation_SelectedIndexChanged;

        // btnStartScada
        this.btnStartScada.BackColor = Color.FromArgb(16, 124, 65);
        this.btnStartScada.FlatAppearance.BorderSize = 0;
        this.btnStartScada.FlatStyle = FlatStyle.Flat;
        this.btnStartScada.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.btnStartScada.ForeColor = Color.White;
        this.btnStartScada.Location = new Point(455, 13);
        this.btnStartScada.Name = "btnStartScada";
        this.btnStartScada.Size = new Size(220, 35);
        this.btnStartScada.TabIndex = 2;
        this.btnStartScada.Text = "Bắt đầu Giám sát SCADA";
        this.btnStartScada.UseVisualStyleBackColor = false;
        this.btnStartScada.Click += this.btnStartScada_Click;

        // btnDisconnect
        this.btnDisconnect.BackColor = Color.FromArgb(220, 38, 38);
        this.btnDisconnect.Enabled = false;
        this.btnDisconnect.FlatAppearance.BorderSize = 0;
        this.btnDisconnect.FlatStyle = FlatStyle.Flat;
        this.btnDisconnect.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.btnDisconnect.ForeColor = Color.White;
        this.btnDisconnect.Location = new Point(687, 13);
        this.btnDisconnect.Name = "btnDisconnect";
        this.btnDisconnect.Size = new Size(155, 35);
        this.btnDisconnect.TabIndex = 3;
        this.btnDisconnect.Text = "Ngắt Kết nối";
        this.btnDisconnect.UseVisualStyleBackColor = false;
        this.btnDisconnect.Click += this.btnDisconnect_Click;

        // pnlDashboard
        this.pnlDashboard.BackColor = Color.FromArgb(236, 241, 248);
        this.pnlDashboard.Controls.Add(this.pnlLoadCard);
        this.pnlDashboard.Controls.Add(this.pnlVoltageCard);
        this.pnlDashboard.Dock = DockStyle.Top;
        this.pnlDashboard.Location = new Point(0, 130);
        this.pnlDashboard.Name = "pnlDashboard";
        this.pnlDashboard.Padding = new Padding(16, 12, 16, 12);
        this.pnlDashboard.Size = new Size(1000, 160);
        this.pnlDashboard.TabIndex = 2;

        // pnlVoltageCard
        this.pnlVoltageCard.BackColor = Color.White;
        this.pnlVoltageCard.BorderStyle = BorderStyle.FixedSingle;
        this.pnlVoltageCard.Controls.Add(this.lblVoltageNote);
        this.pnlVoltageCard.Controls.Add(this.lblVoltage);
        this.pnlVoltageCard.Controls.Add(this.lblVoltageTitle);
        this.pnlVoltageCard.Location = new Point(16, 12);
        this.pnlVoltageCard.Name = "pnlVoltageCard";
        this.pnlVoltageCard.Size = new Size(465, 134);
        this.pnlVoltageCard.TabIndex = 0;

        // lblVoltageTitle
        this.lblVoltageTitle.AutoSize = true;
        this.lblVoltageTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.lblVoltageTitle.ForeColor = Color.FromArgb(71, 85, 105);
        this.lblVoltageTitle.Location = new Point(16, 12);
        this.lblVoltageTitle.Name = "lblVoltageTitle";
        this.lblVoltageTitle.Size = new Size(170, 17);
        this.lblVoltageTitle.TabIndex = 0;
        this.lblVoltageTitle.Text = "ĐIỆN ÁP HIỆN TẠI (kV)";

        // lblVoltage
        this.lblVoltage.AutoSize = false;
        this.lblVoltage.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        this.lblVoltage.ForeColor = Color.FromArgb(15, 98, 254);
        this.lblVoltage.Location = new Point(16, 36);
        this.lblVoltage.Name = "lblVoltage";
        this.lblVoltage.Size = new Size(430, 56);
        this.lblVoltage.TabIndex = 1;
        this.lblVoltage.Text = "--- kV";
        this.lblVoltage.TextAlign = ContentAlignment.MiddleLeft;

        // lblVoltageNote
        this.lblVoltageNote.AutoSize = true;
        this.lblVoltageNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        this.lblVoltageNote.ForeColor = Color.DimGray;
        this.lblVoltageNote.Location = new Point(16, 102);
        this.lblVoltageNote.Name = "lblVoltageNote";
        this.lblVoltageNote.Size = new Size(255, 15);
        this.lblVoltageNote.TabIndex = 2;
        this.lblVoltageNote.Text = "Dải điện áp thu thập SCADA: 108 kV - 115 kV";

        // pnlLoadCard
        this.pnlLoadCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.pnlLoadCard.BackColor = Color.White;
        this.pnlLoadCard.BorderStyle = BorderStyle.FixedSingle;
        this.pnlLoadCard.Controls.Add(this.prgLoadBar);
        this.pnlLoadCard.Controls.Add(this.lblLoadAlert);
        this.pnlLoadCard.Controls.Add(this.lblLoadPercent);
        this.pnlLoadCard.Controls.Add(this.lblLoadTitle);
        this.pnlLoadCard.Location = new Point(496, 12);
        this.pnlLoadCard.Name = "pnlLoadCard";
        this.pnlLoadCard.Size = new Size(488, 134);
        this.pnlLoadCard.TabIndex = 1;

        // lblLoadTitle
        this.lblLoadTitle.AutoSize = true;
        this.lblLoadTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.lblLoadTitle.ForeColor = Color.FromArgb(71, 85, 105);
        this.lblLoadTitle.Location = new Point(16, 12);
        this.lblLoadTitle.Name = "lblLoadTitle";
        this.lblLoadTitle.Size = new Size(155, 17);
        this.lblLoadTitle.TabIndex = 0;
        this.lblLoadTitle.Text = "MỨC MANG TẢI (%)";

        // lblLoadPercent
        this.lblLoadPercent.AutoSize = false;
        this.lblLoadPercent.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        this.lblLoadPercent.ForeColor = Color.FromArgb(16, 124, 65);
        this.lblLoadPercent.Location = new Point(16, 34);
        this.lblLoadPercent.Name = "lblLoadPercent";
        this.lblLoadPercent.Size = new Size(160, 56);
        this.lblLoadPercent.TabIndex = 1;
        this.lblLoadPercent.Text = "-- %";
        this.lblLoadPercent.TextAlign = ContentAlignment.MiddleLeft;

        // lblLoadAlert
        this.lblLoadAlert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.lblLoadAlert.AutoSize = false;
        this.lblLoadAlert.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.lblLoadAlert.ForeColor = Color.FromArgb(71, 85, 105);
        this.lblLoadAlert.Location = new Point(182, 46);
        this.lblLoadAlert.Name = "lblLoadAlert";
        this.lblLoadAlert.Size = new Size(290, 36);
        this.lblLoadAlert.TabIndex = 2;
        this.lblLoadAlert.Text = "Chờ kết nối tín hiệu SCADA...";
        this.lblLoadAlert.TextAlign = ContentAlignment.MiddleLeft;

        // prgLoadBar
        this.prgLoadBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.prgLoadBar.Location = new Point(16, 98);
        this.prgLoadBar.Maximum = 100;
        this.prgLoadBar.Minimum = 0;
        this.prgLoadBar.Name = "prgLoadBar";
        this.prgLoadBar.Size = new Size(454, 18);
        this.prgLoadBar.Style = ProgressBarStyle.Continuous;
        this.prgLoadBar.TabIndex = 3;

        // grpLogs
        this.grpLogs.Dock = DockStyle.Fill;
        this.grpLogs.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.grpLogs.ForeColor = Color.FromArgb(15, 42, 74);
        this.grpLogs.Location = new Point(0, 290);
        this.grpLogs.Name = "grpLogs";
        this.grpLogs.Padding = new Padding(14, 8, 14, 10);
        this.grpLogs.Size = new Size(1000, 332);
        this.grpLogs.TabIndex = 3;
        this.grpLogs.TabStop = false;
        this.grpLogs.Text = "Nhật ký sự cố Quá tải (> 85%) - Tự động ghi nhận qua Thread-Safe Invoke";

        // dgvGridLogs
        this.dgvGridLogs.AllowUserToAddRows = false;
        this.dgvGridLogs.AllowUserToDeleteRows = false;
        this.dgvGridLogs.BackgroundColor = Color.White;
        this.dgvGridLogs.BorderStyle = BorderStyle.FixedSingle;
        this.dgvGridLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvGridLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.dgvGridLogs.Dock = DockStyle.Fill;
        this.dgvGridLogs.Location = new Point(14, 25);
        this.dgvGridLogs.Name = "dgvGridLogs";
        this.dgvGridLogs.ReadOnly = true;
        this.dgvGridLogs.RowHeadersVisible = false;
        this.dgvGridLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvGridLogs.Size = new Size(972, 297);
        this.dgvGridLogs.TabIndex = 0;

        this.grpLogs.Controls.Add(this.dgvGridLogs);

        // statusStrip
        this.statusStrip.BackColor = Color.FromArgb(240, 244, 249);
        this.statusStrip.Font = new Font("Segoe UI", 9F);
        this.statusStrip.Items.AddRange(new ToolStripItem[]
        {
            this.lblScadaState,
            this.lblLastPacketTime,
            this.lblTotalCycles
        });
        this.statusStrip.Location = new Point(0, 622);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Padding = new Padding(10, 2, 14, 2);
        this.statusStrip.Size = new Size(1000, 28);
        this.statusStrip.TabIndex = 4;
        this.statusStrip.Text = "Thanh trạng thái SCADA";

        // lblScadaState
        this.lblScadaState.BorderSides = ToolStripStatusLabelBorderSides.Right;
        this.lblScadaState.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblScadaState.ForeColor = Color.DimGray;
        this.lblScadaState.Name = "lblScadaState";
        this.lblScadaState.Padding = new Padding(4, 0, 14, 0);
        this.lblScadaState.Size = new Size(260, 23);
        this.lblScadaState.Text = "● SCADA: Chưa kết nối";

        // lblLastPacketTime
        this.lblLastPacketTime.BorderSides = ToolStripStatusLabelBorderSides.Right;
        this.lblLastPacketTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblLastPacketTime.ForeColor = Color.FromArgb(15, 52, 96);
        this.lblLastPacketTime.Name = "lblLastPacketTime";
        this.lblLastPacketTime.Padding = new Padding(10, 0, 14, 0);
        this.lblLastPacketTime.Size = new Size(250, 23);
        this.lblLastPacketTime.Text = "Thời gian nhận gói tin cuối: --:--:--";

        // lblTotalCycles
        this.lblTotalCycles.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblTotalCycles.ForeColor = Color.FromArgb(15, 52, 96);
        this.lblTotalCycles.Name = "lblTotalCycles";
        this.lblTotalCycles.Padding = new Padding(10, 0, 4, 0);
        this.lblTotalCycles.Size = new Size(466, 23);
        this.lblTotalCycles.Spring = true;
        this.lblTotalCycles.Text = "Tổng số chu kỳ đã quét: 0";
        this.lblTotalCycles.TextAlign = ContentAlignment.MiddleRight;

        // frmPowerGridMonitor
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(1000, 650);
        this.Controls.Add(this.grpLogs);
        this.Controls.Add(this.pnlDashboard);
        this.Controls.Add(this.pnlControls);
        this.Controls.Add(this.pnlHeader);
        this.Controls.Add(this.statusStrip);
        this.MinimumSize = new Size(840, 540);
        this.Name = "frmPowerGridMonitor";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Trung tâm Điều độ & Giám sát Lưới điện Thời gian thực (SCADA)";
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlControls.ResumeLayout(false);
        this.pnlControls.PerformLayout();
        this.pnlDashboard.ResumeLayout(false);
        this.pnlVoltageCard.ResumeLayout(false);
        this.pnlVoltageCard.PerformLayout();
        this.pnlLoadCard.ResumeLayout(false);
        this.pnlLoadCard.PerformLayout();
        this.grpLogs.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).EndInit();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Panel pnlHeader = null!;
    private Label lblHeaderTitle = null!;
    private Label lblHeaderSubtitle = null!;
    private Panel pnlControls = null!;
    private Label lblSubstation = null!;
    private ComboBox cboSubstation = null!;
    private Button btnStartScada = null!;
    private Button btnDisconnect = null!;
    private Panel pnlDashboard = null!;
    private Panel pnlVoltageCard = null!;
    private Label lblVoltageTitle = null!;
    private Label lblVoltage = null!;
    private Label lblVoltageNote = null!;
    private Panel pnlLoadCard = null!;
    private Label lblLoadTitle = null!;
    private Label lblLoadPercent = null!;
    private Label lblLoadAlert = null!;
    private ProgressBar prgLoadBar = null!;
    private GroupBox grpLogs = null!;
    private DataGridView dgvGridLogs = null!;
    private StatusStrip statusStrip = null!;
    private ToolStripStatusLabel lblScadaState = null!;
    private ToolStripStatusLabel lblLastPacketTime = null!;
    private ToolStripStatusLabel lblTotalCycles = null!;
}
