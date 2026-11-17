namespace QuanLyBanHang.GUI
{
    partial class FormBanHang
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
            grpHoaDon = new GroupBox();
            lblNhanVien = new Label();
            cboNhanVien = new ComboBox();
            lblKhachHang = new Label();
            cboKhachHang = new ComboBox();
            lblNgayLap = new Label();
            grpChonSP = new GroupBox();
            lblMaVach = new Label();
            txtMaVach = new TextBox();
            lblSanPham = new Label();
            cboSanPham = new ComboBox();
            lblSoLuong = new Label();
            nudSoLuong = new NumericUpDown();
            btnThemVaoGio = new Button();
            lblThongTinSP = new Label();
            dgvGioHang = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            btnXoaDong = new Button();
            btnXoaGio = new Button();
            lblDiemCong = new Label();
            lblTongTienCaption = new Label();
            lblTongTien = new Label();
            btnThanhToan = new Button();
            bsGioHang = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            grpHoaDon.SuspendLayout();
            grpChonSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsGioHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // grpHoaDon
            //
            grpHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpHoaDon.Controls.Add(lblNhanVien);
            grpHoaDon.Controls.Add(cboNhanVien);
            grpHoaDon.Controls.Add(lblKhachHang);
            grpHoaDon.Controls.Add(cboKhachHang);
            grpHoaDon.Controls.Add(lblNgayLap);
            grpHoaDon.Location = new Point(12, 10);
            grpHoaDon.Name = "grpHoaDon";
            grpHoaDon.Size = new Size(976, 64);
            grpHoaDon.TabIndex = 0;
            grpHoaDon.TabStop = false;
            grpHoaDon.Text = "Thông tin hóa đơn";
            //
            // lblNhanVien
            //
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(14, 28);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Text = "Nhân viên bán:";
            //
            // cboNhanVien
            //
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(110, 24);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(230, 23);
            cboNhanVien.TabIndex = 0;
            //
            // lblKhachHang
            //
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(372, 28);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Text = "Khách hàng:";
            //
            // cboKhachHang
            //
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.Location = new Point(452, 24);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(320, 23);
            cboKhachHang.TabIndex = 1;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
            //
            // lblNgayLap
            //
            lblNgayLap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNgayLap.ForeColor = Color.DimGray;
            lblNgayLap.Location = new Point(790, 28);
            lblNgayLap.Name = "lblNgayLap";
            lblNgayLap.Size = new Size(176, 18);
            lblNgayLap.Text = "Ngày lập:";
            lblNgayLap.TextAlign = ContentAlignment.MiddleRight;
            //
            // grpChonSP
            //
            grpChonSP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChonSP.Controls.Add(lblMaVach);
            grpChonSP.Controls.Add(txtMaVach);
            grpChonSP.Controls.Add(lblSanPham);
            grpChonSP.Controls.Add(cboSanPham);
            grpChonSP.Controls.Add(lblSoLuong);
            grpChonSP.Controls.Add(nudSoLuong);
            grpChonSP.Controls.Add(btnThemVaoGio);
            grpChonSP.Controls.Add(lblThongTinSP);
            grpChonSP.Location = new Point(12, 82);
            grpChonSP.Name = "grpChonSP";
            grpChonSP.Size = new Size(976, 92);
            grpChonSP.TabIndex = 1;
            grpChonSP.TabStop = false;
            grpChonSP.Text = "Chọn sản phẩm";
            //
            // lblMaVach
            //
            lblMaVach.AutoSize = true;
            lblMaVach.Location = new Point(14, 28);
            lblMaVach.Name = "lblMaVach";
            lblMaVach.Text = "Quét / nhập mã:";
            //
            // txtMaVach
            //
            txtMaVach.Location = new Point(110, 24);
            txtMaVach.Name = "txtMaVach";
            txtMaVach.Size = new Size(180, 23);
            txtMaVach.TabIndex = 0;
            txtMaVach.KeyDown += txtMaVach_KeyDown;
            //
            // lblSanPham
            //
            lblSanPham.AutoSize = true;
            lblSanPham.Location = new Point(304, 28);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Text = "hoặc chọn:";
            //
            // cboSanPham
            //
            cboSanPham.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSanPham.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboSanPham.Location = new Point(374, 24);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(340, 23);
            cboSanPham.TabIndex = 1;
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            //
            // lblSoLuong
            //
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(726, 28);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Text = "SL:";
            //
            // nudSoLuong
            //
            nudSoLuong.Location = new Point(752, 24);
            nudSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(70, 23);
            nudSoLuong.TabIndex = 2;
            nudSoLuong.TextAlign = HorizontalAlignment.Right;
            nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnThemVaoGio
            //
            btnThemVaoGio.Location = new Point(834, 21);
            btnThemVaoGio.Name = "btnThemVaoGio";
            btnThemVaoGio.Size = new Size(128, 29);
            btnThemVaoGio.TabIndex = 3;
            btnThemVaoGio.Text = "Thêm vào giỏ";
            btnThemVaoGio.UseVisualStyleBackColor = true;
            btnThemVaoGio.Click += btnThemVaoGio_Click;
            //
            // lblThongTinSP
            //
            lblThongTinSP.ForeColor = Color.SteelBlue;
            lblThongTinSP.Location = new Point(110, 58);
            lblThongTinSP.Name = "lblThongTinSP";
            lblThongTinSP.Size = new Size(700, 20);
            lblThongTinSP.Text = "Gõ mã vạch rồi bấm Enter, hoặc chọn sản phẩm trong danh sách.";
            //
            // dgvGioHang
            //
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.AllowUserToDeleteRows = false;
            dgvGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.BackgroundColor = Color.White;
            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colSoLuong, colDonGia, colThanhTien });
            dgvGioHang.Location = new Point(12, 184);
            dgvGioHang.MultiSelect = false;
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.ReadOnly = true;
            dgvGioHang.RowHeadersVisible = false;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.Size = new Size(976, 290);
            dgvGioHang.TabIndex = 2;
            dgvGioHang.CellFormatting += dgvGioHang_CellFormatting;
            //
            // colMaSP
            //
            colMaSP.DataPropertyName = "MaSP";
            colMaSP.FillWeight = 18F;
            colMaSP.HeaderText = "Mã SP";
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
            // colSoLuong
            //
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoLuong.FillWeight = 10F;
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            //
            // colDonGia
            //
            colDonGia.DataPropertyName = "DonGia";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDonGia.DefaultCellStyle.Format = "N0";
            colDonGia.FillWeight = 15F;
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            //
            // colThanhTien
            //
            colThanhTien.DataPropertyName = "ThanhTien";
            colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colThanhTien.DefaultCellStyle.Format = "N0";
            colThanhTien.FillWeight = 17F;
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.Name = "colThanhTien";
            colThanhTien.ReadOnly = true;
            //
            // btnXoaDong
            //
            btnXoaDong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXoaDong.Location = new Point(12, 486);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(130, 32);
            btnXoaDong.TabIndex = 3;
            btnXoaDong.Text = "Bỏ dòng đã chọn";
            btnXoaDong.UseVisualStyleBackColor = true;
            btnXoaDong.Click += btnXoaDong_Click;
            //
            // btnXoaGio
            //
            btnXoaGio.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXoaGio.ForeColor = Color.Firebrick;
            btnXoaGio.Location = new Point(150, 486);
            btnXoaGio.Name = "btnXoaGio";
            btnXoaGio.Size = new Size(110, 32);
            btnXoaGio.TabIndex = 4;
            btnXoaGio.Text = "Xóa giỏ hàng";
            btnXoaGio.UseVisualStyleBackColor = true;
            btnXoaGio.Click += btnXoaGio_Click;
            //
            // lblDiemCong
            //
            lblDiemCong.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDiemCong.ForeColor = Color.DarkGreen;
            lblDiemCong.Location = new Point(12, 530);
            lblDiemCong.Name = "lblDiemCong";
            lblDiemCong.Size = new Size(480, 20);
            lblDiemCong.Text = "Khách lẻ: không tích điểm.";
            //
            // lblTongTienCaption
            //
            lblTongTienCaption.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongTienCaption.AutoSize = true;
            lblTongTienCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongTienCaption.Location = new Point(560, 492);
            lblTongTienCaption.Name = "lblTongTienCaption";
            lblTongTienCaption.Text = "TỔNG TIỀN:";
            //
            // lblTongTien
            //
            lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongTien.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Firebrick;
            lblTongTien.Location = new Point(670, 484);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(318, 36);
            lblTongTien.Text = "0 đ";
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            //
            // btnThanhToan
            //
            btnThanhToan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThanhToan.BackColor = Color.SeaGreen;
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(818, 526);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(170, 44);
            btnThanhToan.TabIndex = 5;
            btnThanhToan.Text = "THANH TOÁN";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            //
            // errorProvider1
            //
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            //
            // FormBanHang
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 582);
            Controls.Add(grpHoaDon);
            Controls.Add(grpChonSP);
            Controls.Add(dgvGioHang);
            Controls.Add(btnXoaDong);
            Controls.Add(btnXoaGio);
            Controls.Add(lblDiemCong);
            Controls.Add(lblTongTienCaption);
            Controls.Add(lblTongTien);
            Controls.Add(btnThanhToan);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1016, 560);
            Name = "FormBanHang";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bán hàng - Lập hóa đơn";
            Load += FormBanHang_Load;
            grpHoaDon.ResumeLayout(false);
            grpHoaDon.PerformLayout();
            grpChonSP.ResumeLayout(false);
            grpChonSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsGioHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpHoaDon;
        private Label lblNhanVien;
        private ComboBox cboNhanVien;
        private Label lblKhachHang;
        private ComboBox cboKhachHang;
        private Label lblNgayLap;
        private GroupBox grpChonSP;
        private Label lblMaVach;
        private TextBox txtMaVach;
        private Label lblSanPham;
        private ComboBox cboSanPham;
        private Label lblSoLuong;
        private NumericUpDown nudSoLuong;
        private Button btnThemVaoGio;
        private Label lblThongTinSP;
        private DataGridView dgvGioHang;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private Button btnXoaDong;
        private Button btnXoaGio;
        private Label lblDiemCong;
        private Label lblTongTienCaption;
        private Label lblTongTien;
        private Button btnThanhToan;
        private BindingSource bsGioHang;
        private ErrorProvider errorProvider1;
    }
}
