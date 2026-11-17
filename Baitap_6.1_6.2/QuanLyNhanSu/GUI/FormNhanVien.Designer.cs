namespace QuanLyNhanSu.GUI
{
    partial class FormNhanVien
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
            components = new System.ComponentModel.Container();
            grpThongTin = new GroupBox();
            lblMaNV = new Label();
            txtMaNV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblCCCD = new Label();
            txtCCCD = new TextBox();
            lblPhongBan = new Label();
            cboPhongBan = new ComboBox();
            lblLuongCoBan = new Label();
            txtLuongCoBan = new TextBox();
            lblHeSoLuong = new Label();
            nudHeSoLuong = new NumericUpDown();
            grpChucNang = new GroupBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnChuyenPhong = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            lblLoc = new Label();
            cboLoc = new ComboBox();
            dgvNhanVien = new DataGridView();
            colMaNV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colNgaySinh = new DataGridViewTextBoxColumn();
            colCCCD = new DataGridViewTextBoxColumn();
            colTenPB = new DataGridViewTextBoxColumn();
            colLuongCoBan = new DataGridViewTextBoxColumn();
            colHeSoLuong = new DataGridViewTextBoxColumn();
            lblTongSo = new Label();
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudHeSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaNV);
            grpThongTin.Controls.Add(txtMaNV);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblNgaySinh);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(lblCCCD);
            grpThongTin.Controls.Add(txtCCCD);
            grpThongTin.Controls.Add(lblPhongBan);
            grpThongTin.Controls.Add(cboPhongBan);
            grpThongTin.Controls.Add(lblLuongCoBan);
            grpThongTin.Controls.Add(txtLuongCoBan);
            grpThongTin.Controls.Add(lblHeSoLuong);
            grpThongTin.Controls.Add(nudHeSoLuong);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(430, 260);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Hồ sơ nhân viên";
            //
            // grpChucNang
            //
            grpChucNang.Controls.Add(btnThem);
            grpChucNang.Controls.Add(btnSua);
            grpChucNang.Controls.Add(btnXoa);
            grpChucNang.Controls.Add(btnLamMoi);
            grpChucNang.Controls.Add(btnChuyenPhong);
            grpChucNang.Controls.Add(lblTimKiem);
            grpChucNang.Controls.Add(txtTimKiem);
            grpChucNang.Controls.Add(btnTimKiem);
            grpChucNang.Controls.Add(lblLoc);
            grpChucNang.Controls.Add(cboLoc);
            grpChucNang.Location = new Point(454, 12);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(430, 260);
            grpChucNang.TabIndex = 1;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "Chức năng";
            //
            // lblMaNV
            //
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(16, 33);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Text = "Mã NV (tự tăng):";
            //
            // txtMaNV
            //
            txtMaNV.Location = new Point(140, 30);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(100, 23);
            txtMaNV.TabIndex = 1;
            txtMaNV.ReadOnly = true;
            txtMaNV.TabStop = false;
            //
            // lblHoTen
            //
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(16, 65);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Text = "Họ và tên:";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(140, 62);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(260, 23);
            txtHoTen.TabIndex = 3;
            //
            // lblNgaySinh
            //
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(16, 97);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Text = "Ngày sinh:";
            //
            // dtpNgaySinh
            //
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(140, 94);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(140, 23);
            dtpNgaySinh.TabIndex = 5;
            //
            // lblCCCD
            //
            lblCCCD.AutoSize = true;
            lblCCCD.Location = new Point(16, 129);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Text = "Số CCCD:";
            //
            // txtCCCD
            //
            txtCCCD.Location = new Point(140, 126);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(160, 23);
            txtCCCD.TabIndex = 7;
            txtCCCD.MaxLength = 12;
            //
            // lblPhongBan
            //
            lblPhongBan.AutoSize = true;
            lblPhongBan.Location = new Point(16, 161);
            lblPhongBan.Name = "lblPhongBan";
            lblPhongBan.Text = "Phòng ban:";
            //
            // cboPhongBan
            //
            cboPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhongBan.Location = new Point(140, 158);
            cboPhongBan.Name = "cboPhongBan";
            cboPhongBan.Size = new Size(240, 23);
            cboPhongBan.TabIndex = 9;
            //
            // lblLuongCoBan
            //
            lblLuongCoBan.AutoSize = true;
            lblLuongCoBan.Location = new Point(16, 193);
            lblLuongCoBan.Name = "lblLuongCoBan";
            lblLuongCoBan.Text = "Lương cơ bản (đ):";
            //
            // txtLuongCoBan
            //
            txtLuongCoBan.Location = new Point(140, 190);
            txtLuongCoBan.Name = "txtLuongCoBan";
            txtLuongCoBan.Size = new Size(160, 23);
            txtLuongCoBan.TabIndex = 11;
            txtLuongCoBan.TextAlign = HorizontalAlignment.Right;
            //
            // lblHeSoLuong
            //
            lblHeSoLuong.AutoSize = true;
            lblHeSoLuong.Location = new Point(16, 225);
            lblHeSoLuong.Name = "lblHeSoLuong";
            lblHeSoLuong.Text = "Hệ số lương:";
            //
            // nudHeSoLuong
            //
            nudHeSoLuong.DecimalPlaces = 2;
            nudHeSoLuong.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudHeSoLuong.Location = new Point(140, 222);
            nudHeSoLuong.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudHeSoLuong.Name = "nudHeSoLuong";
            nudHeSoLuong.Size = new Size(120, 23);
            nudHeSoLuong.TabIndex = 13;
            nudHeSoLuong.TextAlign = HorizontalAlignment.Right;
            //
            // btnThem
            //
            btnThem.Location = new Point(16, 28);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 34);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.Location = new Point(118, 28);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 34);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.ForeColor = Color.Firebrick;
            btnXoa.Location = new Point(220, 28);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 34);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(322, 28);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 34);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // btnChuyenPhong
            //
            btnChuyenPhong.Location = new Point(16, 70);
            btnChuyenPhong.Name = "btnChuyenPhong";
            btnChuyenPhong.Size = new Size(150, 30);
            btnChuyenPhong.TabIndex = 4;
            btnChuyenPhong.Text = "Chuyển phòng ban";
            btnChuyenPhong.UseVisualStyleBackColor = true;
            btnChuyenPhong.Click += btnChuyenPhong_Click;
            //
            // lblTimKiem
            //
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(16, 112);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Text = "Tìm theo tên hoặc số CCCD:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(16, 132);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(300, 23);
            txtTimKiem.TabIndex = 10;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            //
            // btnTimKiem
            //
            btnTimKiem.Location = new Point(324, 131);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(86, 26);
            btnTimKiem.TabIndex = 11;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            //
            // lblLoc
            //
            lblLoc.AutoSize = true;
            lblLoc.Location = new Point(16, 167);
            lblLoc.Name = "lblLoc";
            lblLoc.Text = "Lọc phòng ban:";
            //
            // cboLoc
            //
            cboLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoc.Location = new Point(110, 164);
            cboLoc.Name = "cboLoc";
            cboLoc.Size = new Size(206, 23);
            cboLoc.TabIndex = 12;
            cboLoc.SelectionChangeCommitted += cboLoc_SelectionChangeCommitted;
            //
            // dgvNhanVien
            //
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colHoTen, colNgaySinh, colCCCD, colTenPB, colLuongCoBan, colHeSoLuong });
            dgvNhanVien.Location = new Point(12, 282);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(872, 300);
            dgvNhanVien.TabIndex = 2;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            //
            // colMaNV
            //
            colMaNV.DataPropertyName = "MaNV";
            colMaNV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaNV.FillWeight = 8F;
            colMaNV.HeaderText = "Mã NV";
            colMaNV.Name = "colMaNV";
            colMaNV.ReadOnly = true;
            //
            // colHoTen
            //
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 24F;
            colHoTen.HeaderText = "Họ và tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            //
            // colNgaySinh
            //
            colNgaySinh.DataPropertyName = "NgaySinh";
            colNgaySinh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNgaySinh.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgaySinh.FillWeight = 12F;
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            //
            // colCCCD
            //
            colCCCD.DataPropertyName = "CCCD";
            colCCCD.FillWeight = 15F;
            colCCCD.HeaderText = "Số CCCD";
            colCCCD.Name = "colCCCD";
            colCCCD.ReadOnly = true;
            //
            // colTenPB
            //
            colTenPB.DataPropertyName = "TenPB";
            colTenPB.FillWeight = 22F;
            colTenPB.HeaderText = "Phòng ban";
            colTenPB.Name = "colTenPB";
            colTenPB.ReadOnly = true;
            //
            // colLuongCoBan
            //
            colLuongCoBan.DataPropertyName = "LuongCoBan";
            colLuongCoBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colLuongCoBan.DefaultCellStyle.Format = "N0";
            colLuongCoBan.FillWeight = 14F;
            colLuongCoBan.HeaderText = "Lương cơ bản";
            colLuongCoBan.Name = "colLuongCoBan";
            colLuongCoBan.ReadOnly = true;
            //
            // colHeSoLuong
            //
            colHeSoLuong.DataPropertyName = "HeSoLuong";
            colHeSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHeSoLuong.DefaultCellStyle.Format = "0.00";
            colHeSoLuong.FillWeight = 8F;
            colHeSoLuong.HeaderText = "Hệ số";
            colHeSoLuong.Name = "colHeSoLuong";
            colHeSoLuong.ReadOnly = true;
            //
            // lblTongSo
            //
            lblTongSo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongSo.Location = new Point(12, 590);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Text = "Tổng: 0";
            //
            // errorProvider1
            //
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            //
            // FormNhanVien
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 618);
            Controls.Add(grpThongTin);
            Controls.Add(grpChucNang);
            Controls.Add(dgvNhanVien);
            Controls.Add(lblTongSo);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(912, 657);
            Name = "FormNhanVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Hồ sơ Nhân sự";
            Load += FormNhanVien_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpChucNang.ResumeLayout(false);
            grpChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudHeSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaNV;
        private TextBox txtMaNV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblPhongBan;
        private ComboBox cboPhongBan;
        private Label lblLuongCoBan;
        private TextBox txtLuongCoBan;
        private Label lblHeSoLuong;
        private NumericUpDown nudHeSoLuong;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnChuyenPhong;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label lblLoc;
        private ComboBox cboLoc;
        private DataGridView dgvNhanVien;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colNgaySinh;
        private DataGridViewTextBoxColumn colCCCD;
        private DataGridViewTextBoxColumn colTenPB;
        private DataGridViewTextBoxColumn colLuongCoBan;
        private DataGridViewTextBoxColumn colHeSoLuong;
        private Label lblTongSo;
        private ErrorProvider errorProvider1;
    }
}
