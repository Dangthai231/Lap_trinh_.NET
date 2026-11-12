namespace Bai5_3
{
    partial class Form1
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
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            lblSoLuong = new Label();
            nudSoLuong = new NumericUpDown();
            lblDanhMuc = new Label();
            cboDanhMuc = new ComboBox();
            grpChucNang = new GroupBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvProducts = new DataGridView();
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            lblTongSo = new Label();
            bsProducts = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            grpChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(lblDonGia);
            grpThongTin.Controls.Add(txtDonGia);
            grpThongTin.Controls.Add(lblSoLuong);
            grpThongTin.Controls.Add(nudSoLuong);
            grpThongTin.Controls.Add(lblDanhMuc);
            grpThongTin.Controls.Add(cboDanhMuc);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(470, 190);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sản phẩm";
            //
            // lblMaSP
            //
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(16, 31);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Text = "Mã SP:";
            //
            // txtMaSP
            //
            txtMaSP.Location = new Point(110, 28);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(150, 23);
            txtMaSP.TabIndex = 0;
            //
            // lblTenSP
            //
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(16, 62);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Text = "Tên SP:";
            //
            // txtTenSP
            //
            txtTenSP.Location = new Point(110, 59);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(320, 23);
            txtTenSP.TabIndex = 1;
            //
            // lblDonGia
            //
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(16, 93);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Text = "Đơn giá (đ):";
            //
            // txtDonGia
            //
            txtDonGia.Location = new Point(110, 90);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(150, 23);
            txtDonGia.TabIndex = 2;
            txtDonGia.TextAlign = HorizontalAlignment.Right;
            //
            // lblSoLuong
            //
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(16, 124);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Text = "Số lượng:";
            //
            // nudSoLuong
            //
            nudSoLuong.Location = new Point(110, 121);
            nudSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(100, 23);
            nudSoLuong.TabIndex = 3;
            nudSoLuong.TextAlign = HorizontalAlignment.Right;
            //
            // lblDanhMuc
            //
            lblDanhMuc.AutoSize = true;
            lblDanhMuc.Location = new Point(16, 155);
            lblDanhMuc.Name = "lblDanhMuc";
            lblDanhMuc.Text = "Danh mục:";
            //
            // cboDanhMuc
            //
            cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhMuc.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện", "Thiết bị mạng", "Khác" });
            cboDanhMuc.Location = new Point(110, 152);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(200, 23);
            cboDanhMuc.TabIndex = 4;
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
            grpChucNang.Location = new Point(494, 12);
            grpChucNang.Name = "grpChucNang";
            grpChucNang.Size = new Size(376, 190);
            grpChucNang.TabIndex = 1;
            grpChucNang.TabStop = false;
            grpChucNang.Text = "Chức năng";
            //
            // btnThem
            //
            btnThem.Location = new Point(16, 28);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 34);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.Location = new Point(104, 28);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 34);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.ForeColor = Color.Firebrick;
            btnXoa.Location = new Point(192, 28);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 34);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(280, 28);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(80, 34);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // lblTimKiem
            //
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(16, 86);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Text = "Tìm theo tên sản phẩm:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(16, 108);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(256, 23);
            txtTimKiem.TabIndex = 4;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            //
            // btnTimKiem
            //
            btnTimKiem.Location = new Point(280, 106);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(80, 27);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            //
            // dgvProducts
            //
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colUnitPrice, colQuantity, colCategory });
            dgvProducts.Location = new Point(12, 214);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(858, 270);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellClick += dgvProducts_CellClick;
            //
            // colProductId
            //
            colProductId.DataPropertyName = "ProductId";
            colProductId.FillWeight = 12F;
            colProductId.HeaderText = "Mã SP";
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            //
            // colProductName
            //
            colProductName.DataPropertyName = "ProductName";
            colProductName.FillWeight = 38F;
            colProductName.HeaderText = "Tên sản phẩm";
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            //
            // colUnitPrice
            //
            colUnitPrice.DataPropertyName = "UnitPrice";
            colUnitPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colUnitPrice.DefaultCellStyle.Format = "N0";
            colUnitPrice.FillWeight = 17F;
            colUnitPrice.HeaderText = "Đơn giá";
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            //
            // colQuantity
            //
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colQuantity.FillWeight = 11F;
            colQuantity.HeaderText = "Số lượng";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            //
            // colCategory
            //
            colCategory.DataPropertyName = "Category";
            colCategory.FillWeight = 18F;
            colCategory.HeaderText = "Danh mục";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            //
            // lblTongSo
            //
            lblTongSo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongSo.Location = new Point(12, 492);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Text = "Đang hiển thị: 0 / 0 sản phẩm";
            //
            // errorProvider1
            //
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 518);
            Controls.Add(grpThongTin);
            Controls.Add(grpChucNang);
            Controls.Add(dgvProducts);
            Controls.Add(lblTongSo);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 5.3 - Quản lý danh sách sản phẩm";
            Load += Form1_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            grpChucNang.ResumeLayout(false);
            grpChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsProducts).EndInit();
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
        private Label lblDonGia;
        private TextBox txtDonGia;
        private Label lblSoLuong;
        private NumericUpDown nudSoLuong;
        private Label lblDanhMuc;
        private ComboBox cboDanhMuc;
        private GroupBox grpChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvProducts;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colCategory;
        private Label lblTongSo;
        private BindingSource bsProducts;
        private ErrorProvider errorProvider1;
    }
}
