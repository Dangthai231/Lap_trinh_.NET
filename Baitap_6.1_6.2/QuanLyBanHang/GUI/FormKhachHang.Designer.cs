namespace QuanLyBanHang.GUI
{
    partial class FormKhachHang
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
            lblMaKH = new Label();
            txtMaKH = new TextBox();
            lblTenKH = new Label();
            txtTenKH = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblDiemTichLuy = new Label();
            txtDiemTichLuy = new TextBox();
            grpChucNang = new GroupBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvKhachHang = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colDienThoai = new DataGridViewTextBoxColumn();
            colDiemTichLuy = new DataGridViewTextBoxColumn();
            lblTongSo = new Label();
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaKH);
            grpThongTin.Controls.Add(txtMaKH);
            grpThongTin.Controls.Add(lblTenKH);
            grpThongTin.Controls.Add(txtTenKH);
            grpThongTin.Controls.Add(lblDienThoai);
            grpThongTin.Controls.Add(txtDienThoai);
            grpThongTin.Controls.Add(lblDiemTichLuy);
            grpThongTin.Controls.Add(txtDiemTichLuy);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(430, 200);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khách hàng";
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
            // lblMaKH
            //
            lblMaKH.AutoSize = true;
            lblMaKH.Location = new Point(16, 33);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Text = "Mã KH (tự tăng):";
            //
            // txtMaKH
            //
            txtMaKH.Location = new Point(140, 30);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(100, 23);
            txtMaKH.TabIndex = 1;
            txtMaKH.ReadOnly = true;
            txtMaKH.TabStop = false;
            //
            // lblTenKH
            //
            lblTenKH.AutoSize = true;
            lblTenKH.Location = new Point(16, 65);
            lblTenKH.Name = "lblTenKH";
            lblTenKH.Text = "Tên khách hàng:";
            //
            // txtTenKH
            //
            txtTenKH.Location = new Point(140, 62);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(260, 23);
            txtTenKH.TabIndex = 3;
            //
            // lblDienThoai
            //
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(16, 97);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Text = "Điện thoại:";
            //
            // txtDienThoai
            //
            txtDienThoai.Location = new Point(140, 94);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(160, 23);
            txtDienThoai.TabIndex = 5;
            txtDienThoai.MaxLength = 15;
            //
            // lblDiemTichLuy
            //
            lblDiemTichLuy.AutoSize = true;
            lblDiemTichLuy.Location = new Point(16, 129);
            lblDiemTichLuy.Name = "lblDiemTichLuy";
            lblDiemTichLuy.Text = "Điểm tích lũy:";
            //
            // txtDiemTichLuy
            //
            txtDiemTichLuy.Location = new Point(140, 126);
            txtDiemTichLuy.Name = "txtDiemTichLuy";
            txtDiemTichLuy.Size = new Size(100, 23);
            txtDiemTichLuy.TabIndex = 7;
            txtDiemTichLuy.ReadOnly = true;
            txtDiemTichLuy.TabStop = false;
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
            // dgvKhachHang
            //
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colTenKH, colDienThoai, colDiemTichLuy });
            dgvKhachHang.Location = new Point(12, 222);
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(872, 300);
            dgvKhachHang.TabIndex = 2;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            //
            // colMaKH
            //
            colMaKH.DataPropertyName = "MaKH";
            colMaKH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaKH.FillWeight = 10F;
            colMaKH.HeaderText = "Mã KH";
            colMaKH.Name = "colMaKH";
            colMaKH.ReadOnly = true;
            //
            // colTenKH
            //
            colTenKH.DataPropertyName = "TenKH";
            colTenKH.FillWeight = 40F;
            colTenKH.HeaderText = "Tên khách hàng";
            colTenKH.Name = "colTenKH";
            colTenKH.ReadOnly = true;
            //
            // colDienThoai
            //
            colDienThoai.DataPropertyName = "DienThoai";
            colDienThoai.FillWeight = 20F;
            colDienThoai.HeaderText = "Điện thoại";
            colDienThoai.Name = "colDienThoai";
            colDienThoai.ReadOnly = true;
            //
            // colDiemTichLuy
            //
            colDiemTichLuy.DataPropertyName = "DiemTichLuy";
            colDiemTichLuy.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colDiemTichLuy.FillWeight = 15F;
            colDiemTichLuy.HeaderText = "Điểm tích lũy";
            colDiemTichLuy.Name = "colDiemTichLuy";
            colDiemTichLuy.ReadOnly = true;
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
            // FormKhachHang
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 558);
            Controls.Add(grpThongTin);
            Controls.Add(grpChucNang);
            Controls.Add(dgvKhachHang);
            Controls.Add(lblTongSo);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(912, 597);
            Name = "FormKhachHang";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Khách hàng";
            Load += FormKhachHang_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpChucNang.ResumeLayout(false);
            grpChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaKH;
        private TextBox txtMaKH;
        private Label lblTenKH;
        private TextBox txtTenKH;
        private Label lblDienThoai;
        private TextBox txtDienThoai;
        private Label lblDiemTichLuy;
        private TextBox txtDiemTichLuy;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvKhachHang;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn colDienThoai;
        private DataGridViewTextBoxColumn colDiemTichLuy;
        private Label lblTongSo;
        private ErrorProvider errorProvider1;
    }
}
