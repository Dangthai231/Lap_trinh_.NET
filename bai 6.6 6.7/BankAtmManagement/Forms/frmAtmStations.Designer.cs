#nullable enable
namespace BankAtmManagement.Forms;

partial class frmAtmStations
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
        this.lblHeaderTitle = new Label();
        this.lblSearch = new Label();
        this.txtSearch = new TextBox();
        this.lblStatusFilter = new Label();
        this.cboStatusFilter = new ComboBox();
        this.lblSummary = new Label();
        this.pnlRight = new Panel();
        this.grpEditor = new GroupBox();
        this.lblStationCode = new Label();
        this.txtStationCode = new TextBox();
        this.lblAddress = new Label();
        this.txtLocationAddress = new TextBox();
        this.lblCashBalance = new Label();
        this.numCashBalance = new NumericUpDown();
        this.lblStatus = new Label();
        this.cboStatus = new ComboBox();
        this.lblPhotoSection = new Label();
        this.picStationPhoto = new PictureBox();
        this.lblPhotoPath = new Label();
        this.btnBrowsePhoto = new Button();
        this.btnClearPhoto = new Button();
        this.btnAdd = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnReset = new Button();
        this.dgvStations = new DataGridView();
        this.openFileDialog = new OpenFileDialog();

        this.pnlTop.SuspendLayout();
        this.pnlRight.SuspendLayout();
        this.grpEditor.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numCashBalance)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picStationPhoto)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
        this.SuspendLayout();

        // pnlTop
        this.pnlTop.BackColor = Color.FromArgb(245, 248, 252);
        this.pnlTop.Controls.Add(this.lblSummary);
        this.pnlTop.Controls.Add(this.cboStatusFilter);
        this.pnlTop.Controls.Add(this.lblStatusFilter);
        this.pnlTop.Controls.Add(this.txtSearch);
        this.pnlTop.Controls.Add(this.lblSearch);
        this.pnlTop.Controls.Add(this.lblHeaderTitle);
        this.pnlTop.Dock = DockStyle.Top;
        this.pnlTop.Location = new Point(0, 0);
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Padding = new Padding(12, 8, 12, 8);
        this.pnlTop.Size = new Size(1060, 84);
        this.pnlTop.TabIndex = 0;

        // lblHeaderTitle
        this.lblHeaderTitle.AutoSize = true;
        this.lblHeaderTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
        this.lblHeaderTitle.ForeColor = Color.FromArgb(15, 52, 96);
        this.lblHeaderTitle.Location = new Point(14, 10);
        this.lblHeaderTitle.Name = "lblHeaderTitle";
        this.lblHeaderTitle.Size = new Size(340, 23);
        this.lblHeaderTitle.TabIndex = 0;
        this.lblHeaderTitle.Text = "DANH SÁCH TRẠM ATM && QUẢN LÝ TỒN QUỸ";

        // lblSummary
        this.lblSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.lblSummary.AutoSize = false;
        this.lblSummary.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.lblSummary.ForeColor = Color.FromArgb(16, 110, 60);
        this.lblSummary.Location = new Point(490, 12);
        this.lblSummary.Name = "lblSummary";
        this.lblSummary.Size = new Size(554, 22);
        this.lblSummary.TabIndex = 1;
        this.lblSummary.Text = "Tổng số trạm: 0 | Tổng tồn quỹ: 0 VNĐ";
        this.lblSummary.TextAlign = ContentAlignment.MiddleRight;

        // lblSearch
        this.lblSearch.AutoSize = true;
        this.lblSearch.Font = new Font("Segoe UI", 9.5F);
        this.lblSearch.Location = new Point(14, 48);
        this.lblSearch.Name = "lblSearch";
        this.lblSearch.Size = new Size(65, 17);
        this.lblSearch.TabIndex = 2;
        this.lblSearch.Text = "Tìm kiếm:";

        // txtSearch
        this.txtSearch.Font = new Font("Segoe UI", 9.5F);
        this.txtSearch.Location = new Point(85, 45);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.PlaceholderText = "Nhập mã trạm hoặc địa chỉ đặt máy...";
        this.txtSearch.Size = new Size(280, 24);
        this.txtSearch.TabIndex = 3;
        this.txtSearch.TextChanged += this.FilterChanged;

        // lblStatusFilter
        this.lblStatusFilter.AutoSize = true;
        this.lblStatusFilter.Font = new Font("Segoe UI", 9.5F);
        this.lblStatusFilter.Location = new Point(385, 48);
        this.lblStatusFilter.Name = "lblStatusFilter";
        this.lblStatusFilter.Size = new Size(72, 17);
        this.lblStatusFilter.TabIndex = 4;
        this.lblStatusFilter.Text = "Trạng thái:";

        // cboStatusFilter
        this.cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboStatusFilter.Font = new Font("Segoe UI", 9.5F);
        this.cboStatusFilter.FormattingEnabled = true;
        this.cboStatusFilter.Location = new Point(462, 44);
        this.cboStatusFilter.Name = "cboStatusFilter";
        this.cboStatusFilter.Size = new Size(180, 25);
        this.cboStatusFilter.TabIndex = 5;
        this.cboStatusFilter.SelectedIndexChanged += this.FilterChanged;

        // pnlRight
        this.pnlRight.BackColor = Color.FromArgb(248, 250, 253);
        this.pnlRight.Controls.Add(this.grpEditor);
        this.pnlRight.Dock = DockStyle.Right;
        this.pnlRight.Location = new Point(660, 84);
        this.pnlRight.Name = "pnlRight";
        this.pnlRight.Padding = new Padding(10);
        this.pnlRight.Size = new Size(400, 566);
        this.pnlRight.TabIndex = 1;

        // grpEditor
        this.grpEditor.Dock = DockStyle.Fill;
        this.grpEditor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        this.grpEditor.ForeColor = Color.FromArgb(15, 52, 96);
        this.grpEditor.Location = new Point(10, 10);
        this.grpEditor.Name = "grpEditor";
        this.grpEditor.Padding = new Padding(12);
        this.grpEditor.Size = new Size(380, 546);
        this.grpEditor.TabIndex = 0;
        this.grpEditor.TabStop = false;
        this.grpEditor.Text = "Thông tin chi tiết Trạm ATM";

        // lblStationCode
        this.lblStationCode.AutoSize = true;
        this.lblStationCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblStationCode.ForeColor = Color.FromArgb(40, 48, 60);
        this.lblStationCode.Location = new Point(14, 28);
        this.lblStationCode.Name = "lblStationCode";
        this.lblStationCode.Size = new Size(65, 15);
        this.lblStationCode.TabIndex = 0;
        this.lblStationCode.Text = "Mã trạm:";

        // txtStationCode
        this.txtStationCode.CharacterCasing = CharacterCasing.Upper;
        this.txtStationCode.Font = new Font("Segoe UI", 9.5F);
        this.txtStationCode.Location = new Point(14, 48);
        this.txtStationCode.Name = "txtStationCode";
        this.txtStationCode.PlaceholderText = "VD: ATM-HN-005";
        this.txtStationCode.Size = new Size(350, 24);
        this.txtStationCode.TabIndex = 1;

        // lblAddress
        this.lblAddress.AutoSize = true;
        this.lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblAddress.ForeColor = Color.FromArgb(40, 48, 60);
        this.lblAddress.Location = new Point(14, 80);
        this.lblAddress.Name = "lblAddress";
        this.lblAddress.Size = new Size(108, 15);
        this.lblAddress.TabIndex = 2;
        this.lblAddress.Text = "Địa chỉ đặt máy:";

        // txtLocationAddress
        this.txtLocationAddress.Font = new Font("Segoe UI", 9.5F);
        this.txtLocationAddress.Location = new Point(14, 100);
        this.txtLocationAddress.Multiline = true;
        this.txtLocationAddress.Name = "txtLocationAddress";
        this.txtLocationAddress.Size = new Size(350, 44);
        this.txtLocationAddress.TabIndex = 3;

        // lblCashBalance
        this.lblCashBalance.AutoSize = true;
        this.lblCashBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblCashBalance.ForeColor = Color.FromArgb(40, 48, 60);
        this.lblCashBalance.Location = new Point(14, 152);
        this.lblCashBalance.Name = "lblCashBalance";
        this.lblCashBalance.Size = new Size(185, 15);
        this.lblCashBalance.TabIndex = 4;
        this.lblCashBalance.Text = "Số tiền tồn quỹ hiện tại (VNĐ):";

        // numCashBalance
        this.numCashBalance.Font = new Font("Segoe UI", 9.5F);
        this.numCashBalance.Increment = 5000000m;
        this.numCashBalance.Location = new Point(14, 172);
        this.numCashBalance.Maximum = 100000000000m;
        this.numCashBalance.Minimum = 0m;
        this.numCashBalance.Name = "numCashBalance";
        this.numCashBalance.Size = new Size(185, 24);
        this.numCashBalance.TabIndex = 5;
        this.numCashBalance.ThousandsSeparator = true;

        // lblStatus
        this.lblStatus.AutoSize = true;
        this.lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblStatus.ForeColor = Color.FromArgb(40, 48, 60);
        this.lblStatus.Location = new Point(210, 152);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new Size(125, 15);
        this.lblStatus.TabIndex = 6;
        this.lblStatus.Text = "Trạng thái hoạt động:";

        // cboStatus
        this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboStatus.Font = new Font("Segoe UI", 9.5F);
        this.cboStatus.FormattingEnabled = true;
        this.cboStatus.Location = new Point(210, 172);
        this.cboStatus.Name = "cboStatus";
        this.cboStatus.Size = new Size(154, 25);
        this.cboStatus.TabIndex = 7;

        // lblPhotoSection
        this.lblPhotoSection.AutoSize = true;
        this.lblPhotoSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblPhotoSection.ForeColor = Color.FromArgb(40, 48, 60);
        this.lblPhotoSection.Location = new Point(14, 206);
        this.lblPhotoSection.Name = "lblPhotoSection";
        this.lblPhotoSection.Size = new Size(158, 15);
        this.lblPhotoSection.TabIndex = 8;
        this.lblPhotoSection.Text = "Ảnh chụp hiện trường trạm:";

        // picStationPhoto
        this.picStationPhoto.BackColor = Color.FromArgb(236, 240, 246);
        this.picStationPhoto.BorderStyle = BorderStyle.FixedSingle;
        this.picStationPhoto.Location = new Point(14, 226);
        this.picStationPhoto.Name = "picStationPhoto";
        this.picStationPhoto.Size = new Size(350, 168);
        this.picStationPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        this.picStationPhoto.TabIndex = 9;
        this.picStationPhoto.TabStop = false;

        // lblPhotoPath
        this.lblPhotoPath.AutoEllipsis = true;
        this.lblPhotoPath.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        this.lblPhotoPath.ForeColor = Color.DimGray;
        this.lblPhotoPath.Location = new Point(14, 398);
        this.lblPhotoPath.Name = "lblPhotoPath";
        this.lblPhotoPath.Size = new Size(350, 18);
        this.lblPhotoPath.TabIndex = 10;
        this.lblPhotoPath.Text = "Chưa đính kèm ảnh hiện trường.";

        // btnBrowsePhoto
        this.btnBrowsePhoto.BackColor = Color.FromArgb(28, 100, 242);
        this.btnBrowsePhoto.FlatAppearance.BorderSize = 0;
        this.btnBrowsePhoto.FlatStyle = FlatStyle.Flat;
        this.btnBrowsePhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnBrowsePhoto.ForeColor = Color.White;
        this.btnBrowsePhoto.Location = new Point(14, 422);
        this.btnBrowsePhoto.Name = "btnBrowsePhoto";
        this.btnBrowsePhoto.Size = new Size(220, 32);
        this.btnBrowsePhoto.TabIndex = 11;
        this.btnBrowsePhoto.Text = "Đính kèm ảnh hiện trường...";
        this.btnBrowsePhoto.UseVisualStyleBackColor = false;
        this.btnBrowsePhoto.Click += this.btnBrowsePhoto_Click;

        // btnClearPhoto
        this.btnClearPhoto.BackColor = Color.FromArgb(228, 232, 238);
        this.btnClearPhoto.FlatAppearance.BorderSize = 0;
        this.btnClearPhoto.FlatStyle = FlatStyle.Flat;
        this.btnClearPhoto.Font = new Font("Segoe UI", 9F);
        this.btnClearPhoto.ForeColor = Color.FromArgb(40, 48, 60);
        this.btnClearPhoto.Location = new Point(242, 422);
        this.btnClearPhoto.Name = "btnClearPhoto";
        this.btnClearPhoto.Size = new Size(122, 32);
        this.btnClearPhoto.TabIndex = 12;
        this.btnClearPhoto.Text = "Gỡ ảnh";
        this.btnClearPhoto.UseVisualStyleBackColor = false;
        this.btnClearPhoto.Click += this.btnClearPhoto_Click;

        // btnAdd
        this.btnAdd.BackColor = Color.FromArgb(16, 124, 65);
        this.btnAdd.FlatAppearance.BorderSize = 0;
        this.btnAdd.FlatStyle = FlatStyle.Flat;
        this.btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnAdd.ForeColor = Color.White;
        this.btnAdd.Location = new Point(14, 468);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new Size(170, 34);
        this.btnAdd.TabIndex = 13;
        this.btnAdd.Text = "Thêm trạm mới";
        this.btnAdd.UseVisualStyleBackColor = false;
        this.btnAdd.Click += this.btnAdd_Click;

        // btnUpdate
        this.btnUpdate.BackColor = Color.FromArgb(245, 158, 11);
        this.btnUpdate.FlatAppearance.BorderSize = 0;
        this.btnUpdate.FlatStyle = FlatStyle.Flat;
        this.btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnUpdate.ForeColor = Color.White;
        this.btnUpdate.Location = new Point(194, 468);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new Size(170, 34);
        this.btnUpdate.TabIndex = 14;
        this.btnUpdate.Text = "Cập nhật trạm";
        this.btnUpdate.UseVisualStyleBackColor = false;
        this.btnUpdate.Click += this.btnUpdate_Click;

        // btnDelete
        this.btnDelete.BackColor = Color.FromArgb(220, 38, 38);
        this.btnDelete.FlatAppearance.BorderSize = 0;
        this.btnDelete.FlatStyle = FlatStyle.Flat;
        this.btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnDelete.ForeColor = Color.White;
        this.btnDelete.Location = new Point(14, 508);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new Size(170, 32);
        this.btnDelete.TabIndex = 15;
        this.btnDelete.Text = "Xóa trạm";
        this.btnDelete.UseVisualStyleBackColor = false;
        this.btnDelete.Click += this.btnDelete_Click;

        // btnReset
        this.btnReset.BackColor = Color.FromArgb(100, 116, 139);
        this.btnReset.FlatAppearance.BorderSize = 0;
        this.btnReset.FlatStyle = FlatStyle.Flat;
        this.btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnReset.ForeColor = Color.White;
        this.btnReset.Location = new Point(194, 508);
        this.btnReset.Name = "btnReset";
        this.btnReset.Size = new Size(170, 32);
        this.btnReset.TabIndex = 16;
        this.btnReset.Text = "Làm mới form";
        this.btnReset.UseVisualStyleBackColor = false;
        this.btnReset.Click += this.btnReset_Click;

        this.grpEditor.Controls.Add(this.btnReset);
        this.grpEditor.Controls.Add(this.btnDelete);
        this.grpEditor.Controls.Add(this.btnUpdate);
        this.grpEditor.Controls.Add(this.btnAdd);
        this.grpEditor.Controls.Add(this.btnClearPhoto);
        this.grpEditor.Controls.Add(this.btnBrowsePhoto);
        this.grpEditor.Controls.Add(this.lblPhotoPath);
        this.grpEditor.Controls.Add(this.picStationPhoto);
        this.grpEditor.Controls.Add(this.lblPhotoSection);
        this.grpEditor.Controls.Add(this.cboStatus);
        this.grpEditor.Controls.Add(this.lblStatus);
        this.grpEditor.Controls.Add(this.numCashBalance);
        this.grpEditor.Controls.Add(this.lblCashBalance);
        this.grpEditor.Controls.Add(this.txtLocationAddress);
        this.grpEditor.Controls.Add(this.lblAddress);
        this.grpEditor.Controls.Add(this.txtStationCode);
        this.grpEditor.Controls.Add(this.lblStationCode);

        // dgvStations
        this.dgvStations.AllowUserToAddRows = false;
        this.dgvStations.AllowUserToDeleteRows = false;
        this.dgvStations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStations.BackgroundColor = Color.White;
        this.dgvStations.BorderStyle = BorderStyle.None;
        this.dgvStations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        this.dgvStations.ColumnHeadersHeight = 36;
        this.dgvStations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.dgvStations.Dock = DockStyle.Fill;
        this.dgvStations.Location = new Point(0, 84);
        this.dgvStations.MultiSelect = false;
        this.dgvStations.Name = "dgvStations";
        this.dgvStations.ReadOnly = true;
        this.dgvStations.RowHeadersVisible = false;
        this.dgvStations.RowTemplate.Height = 30;
        this.dgvStations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvStations.Size = new Size(660, 566);
        this.dgvStations.TabIndex = 2;
        this.dgvStations.SelectionChanged += this.dgvStations_SelectionChanged;
        this.dgvStations.CellFormatting += this.dgvStations_CellFormatting;

        // openFileDialog
        this.openFileDialog.Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.webp|Tất cả tệp (*.*)|*.*";
        this.openFileDialog.Title = "Chọn ảnh chụp hiện trường trạm ATM";

        // frmAtmStations
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(1060, 650);
        this.Controls.Add(this.dgvStations);
        this.Controls.Add(this.pnlRight);
        this.Controls.Add(this.pnlTop);
        this.MinimumSize = new Size(820, 520);
        this.Name = "frmAtmStations";
        this.Text = "Quản lý Danh sách Trạm ATM & Tồn quỹ";
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.pnlRight.ResumeLayout(false);
        this.grpEditor.ResumeLayout(false);
        this.grpEditor.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numCashBalance)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picStationPhoto)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
        this.ResumeLayout(false);
    }

    private Panel pnlTop = null!;
    private Label lblHeaderTitle = null!;
    private Label lblSearch = null!;
    private TextBox txtSearch = null!;
    private Label lblStatusFilter = null!;
    private ComboBox cboStatusFilter = null!;
    private Label lblSummary = null!;
    private Panel pnlRight = null!;
    private GroupBox grpEditor = null!;
    private Label lblStationCode = null!;
    private TextBox txtStationCode = null!;
    private Label lblAddress = null!;
    private TextBox txtLocationAddress = null!;
    private Label lblCashBalance = null!;
    private NumericUpDown numCashBalance = null!;
    private Label lblStatus = null!;
    private ComboBox cboStatus = null!;
    private Label lblPhotoSection = null!;
    private PictureBox picStationPhoto = null!;
    private Label lblPhotoPath = null!;
    private Button btnBrowsePhoto = null!;
    private Button btnClearPhoto = null!;
    private Button btnAdd = null!;
    private Button btnUpdate = null!;
    private Button btnDelete = null!;
    private Button btnReset = null!;
    private DataGridView dgvStations = null!;
    private OpenFileDialog openFileDialog = null!;
}
