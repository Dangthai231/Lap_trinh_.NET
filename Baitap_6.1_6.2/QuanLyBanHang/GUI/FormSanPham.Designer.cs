namespace QuanLyBanHang.GUI
{
    partial class FormSanPham
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
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblGiaBan = new Label();
            txtGiaBan = new TextBox();
            lblSoLuongTon = new Label();
            nudSoLuongTon = new NumericUpDown();
            grpChucNang = new GroupBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvSanPham = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colSoLuongTon = new DataGridViewTextBoxColumn();
            lblTongSo = new Label();
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(lblGiaBan);
            grpThongTin.Controls.Add(txtGiaBan);
            grpThongTin.Controls.Add(lblSoLuongTon);
            grpThongTin.Controls.Add(nudSoLuongTon);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(430, 200);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sản phẩm";
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
            // lblMaSP
            //
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(16, 33);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Text = "Mã SP / Mã vạch:";
            //
            // txtMaSP
            //
            txtMaSP.Location = new Point(140, 30);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(200, 23);
            txtMaSP.TabIndex = 1;
            txtMaSP.MaxLength = 20;
            //
            // lblTenSP
            //
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(16, 65);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Text = "Tên sản phẩm:";
            //
            // txtTenSP
            //
            txtTenSP.Location = new Point(140, 62);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(260, 23);
            txtTenSP.TabIndex = 3;
            //
            // lblGiaBan
            //
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new Point(16, 97);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Text = "Giá bán (đ):";
            //
            // txtGiaBan
            //
            txtGiaBan.Location = new Point(140, 94);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(160, 23);
            txtGiaBan.TabIndex = 5;
            txtGiaBan.TextAlign = HorizontalAlignment.Right;
            //
            // lblSoLuongTon
            //
            lblSoLuongTon.AutoSize = true;
            lblSoLuongTon.Location = new Point(16, 129);
            lblSoLuongTon.Name = "lblSoLuongTon";
            lblSoLuongTon.Text = "Số lượng tồn:";
            //
            // nudSoLuongTon
            //
            nudSoLuongTon.DecimalPlaces = 0;
            nudSoLuongTon.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuongTon.Location = new Point(140, 126);
            nudSoLuongTon.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new Size(120, 23);
            nudSoLuongTon.TabIndex = 7;
            nudSoLuongTon.TextAlign = HorizontalAlignment.Right;
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
            lblTimKiem.Text = "Tìm theo tên hoặc mã vạch:";
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
            // dgvSanPham
            //
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colGiaBan, colSoLuongTon });
            dgvSanPham.Location = new Point(12, 222);
            dgvSanPham.MultiSelect = false;
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(872, 300);
            dgvSanPham.TabIndex = 2;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            //
            // colMaSP
            //
            colMaSP.DataPropertyName = "MaSP";
            colMaSP.FillWeight = 20F;
            colMaSP.HeaderText = "Mã SP / Mã vạch";
            colMaSP.Name = "colMaSP";
            colMaSP.ReadOnly = true;
            //
            // colTenSP
            //
            colTenSP.DataPropertyName = "TenSP";
            colTenSP.FillWeight = 40F;
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.Name = "colTenSP";
            colTenSP.ReadOnly = true;
            //
            // colGiaBan
            //
            colGiaBan.DataPropertyName = "GiaBan";
            colGiaBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGiaBan.DefaultCellStyle.Format = "N0";
            colGiaBan.FillWeight = 20F;
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.Name = "colGiaBan";
            colGiaBan.ReadOnly = true;
            //
            // colSoLuongTon
            //
            colSoLuongTon.DataPropertyName = "SoLuongTon";
            colSoLuongTon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoLuongTon.FillWeight = 14F;
            colSoLuongTon.HeaderText = "Tồn kho";
            colSoLuongTon.Name = "colSoLuongTon";
            colSoLuongTon.ReadOnly = true;
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
            // FormSanPham
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 558);
            Controls.Add(grpThongTin);
            Controls.Add(grpChucNang);
            Controls.Add(dgvSanPham);
            Controls.Add(lblTongSo);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(912, 597);
            Name = "FormSanPham";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Sản phẩm";
            Load += FormSanPham_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpChucNang.ResumeLayout(false);
            grpChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaSP;
        private TextBox txtMaSP;
        private Label lblTenSP;
        private TextBox txtTenSP;
        private Label lblGiaBan;
        private TextBox txtGiaBan;
        private Label lblSoLuongTon;
        private NumericUpDown nudSoLuongTon;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvSanPham;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colSoLuongTon;
        private Label lblTongSo;
        private ErrorProvider errorProvider1;
    }
}
