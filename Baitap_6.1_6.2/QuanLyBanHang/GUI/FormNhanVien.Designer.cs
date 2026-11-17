namespace QuanLyBanHang.GUI
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
            lblTenNV = new Label();
            txtTenNV = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblChucVu = new Label();
            cboChucVu = new ComboBox();
            grpChucNang = new GroupBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvNhanVien = new DataGridView();
            colMaNV = new DataGridViewTextBoxColumn();
            colTenNV = new DataGridViewTextBoxColumn();
            colSoDienThoai = new DataGridViewTextBoxColumn();
            colChucVu = new DataGridViewTextBoxColumn();
            lblTongSo = new Label();
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaNV);
            grpThongTin.Controls.Add(txtMaNV);
            grpThongTin.Controls.Add(lblTenNV);
            grpThongTin.Controls.Add(txtTenNV);
            grpThongTin.Controls.Add(lblSoDienThoai);
            grpThongTin.Controls.Add(txtSoDienThoai);
            grpThongTin.Controls.Add(lblChucVu);
            grpThongTin.Controls.Add(cboChucVu);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(430, 200);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin nhân viên";
            //
            // grpChucNang
            //
            grpChucNang.Controls.Add(btnThem);
            grpChucNang.Controls.Add(btnSua);
            grpChucNang.Controls.Add(btnXoa);
            grpChucNang.Controls.Add(btnLamMoi);
            grpChucNang.Controls.Add(lblTimKiem);
            grpChucNang.Controls.Add(txtTimKiem);
            grpChucNang.Controls.Add(btnTimKiem);
            grpChucNang.Location = new Point(454, 12);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(430, 200);
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
            // lblTenNV
            //
            lblTenNV.AutoSize = true;
            lblTenNV.Location = new Point(16, 65);
            lblTenNV.Name = "lblTenNV";
            lblTenNV.Text = "Tên nhân viên:";
            //
            // txtTenNV
            //
            txtTenNV.Location = new Point(140, 62);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(260, 23);
            txtTenNV.TabIndex = 3;
            //
            // lblSoDienThoai
            //
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(16, 97);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Text = "Số điện thoại:";
            //
            // txtSoDienThoai
            //
            txtSoDienThoai.Location = new Point(140, 94);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(160, 23);
            txtSoDienThoai.TabIndex = 5;
            txtSoDienThoai.MaxLength = 15;
            //
            // lblChucVu
            //
            lblChucVu.AutoSize = true;
            lblChucVu.Location = new Point(16, 129);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Text = "Chức vụ:";
            //
            // cboChucVu
            //
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Items.AddRange(new object[] { "Thu ngân", "Quản lý", "Thủ kho", "Bảo vệ" });
            cboChucVu.Location = new Point(140, 126);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(160, 23);
            cboChucVu.TabIndex = 7;
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
            // lblTimKiem
            //
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(16, 76);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Text = "Tìm theo tên hoặc số điện thoại:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(16, 96);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(300, 23);
            txtTimKiem.TabIndex = 10;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            //
            // btnTimKiem
            //
            btnTimKiem.Location = new Point(324, 95);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(86, 26);
            btnTimKiem.TabIndex = 11;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            //
            // dgvNhanVien
            //
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colTenNV, colSoDienThoai, colChucVu });
            dgvNhanVien.Location = new Point(12, 222);
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
            colMaNV.FillWeight = 10F;
            colMaNV.HeaderText = "Mã NV";
            colMaNV.Name = "colMaNV";
            colMaNV.ReadOnly = true;
            //
            // colTenNV
            //
            colTenNV.DataPropertyName = "TenNV";
            colTenNV.FillWeight = 40F;
            colTenNV.HeaderText = "Tên nhân viên";
            colTenNV.Name = "colTenNV";
            colTenNV.ReadOnly = true;
            //
            // colSoDienThoai
            //
            colSoDienThoai.DataPropertyName = "SoDienThoai";
            colSoDienThoai.FillWeight = 20F;
            colSoDienThoai.HeaderText = "Số điện thoại";
            colSoDienThoai.Name = "colSoDienThoai";
            colSoDienThoai.ReadOnly = true;
            //
            // colChucVu
            //
            colChucVu.DataPropertyName = "ChucVu";
            colChucVu.FillWeight = 20F;
            colChucVu.HeaderText = "Chức vụ";
            colChucVu.Name = "colChucVu";
            colChucVu.ReadOnly = true;
            //
            // lblTongSo
            //
            lblTongSo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongSo.Location = new Point(12, 530);
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
            ClientSize = new Size(896, 558);
            Controls.Add(grpThongTin);
            Controls.Add(grpChucNang);
            Controls.Add(dgvNhanVien);
            Controls.Add(lblTongSo);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(912, 597);
            Name = "FormNhanVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Nhân viên";
            Load += FormNhanVien_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpChucNang.ResumeLayout(false);
            grpChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaNV;
        private TextBox txtMaNV;
        private Label lblTenNV;
        private TextBox txtTenNV;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblChucVu;
        private ComboBox cboChucVu;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvNhanVien;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colTenNV;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colChucVu;
        private Label lblTongSo;
        private ErrorProvider errorProvider1;
    }
}
