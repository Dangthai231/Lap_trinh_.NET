namespace QuanLyNhanSu.GUI
{
    partial class FormTinhLuong
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
            grpChonThang = new GroupBox();
            lblThang = new Label();
            dtpThang = new DateTimePicker();
            btnTinhLuong = new Button();
            btnChotLuong = new Button();
            lblTrangThai = new Label();
            dgvLuong = new DataGridView();
            colMaNV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colTenPB = new DataGridViewTextBoxColumn();
            colLuongCoBan = new DataGridViewTextBoxColumn();
            colHeSoLuong = new DataGridViewTextBoxColumn();
            colSoNgayCong = new DataGridViewTextBoxColumn();
            colSoGioOT = new DataGridViewTextBoxColumn();
            colThucLinh = new DataGridViewTextBoxColumn();
            lblCongThuc = new Label();
            lblTongLuong = new Label();
            grpChonThang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLuong).BeginInit();
            SuspendLayout();
            //
            // grpChonThang
            //
            grpChonThang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChonThang.Controls.Add(lblThang);
            grpChonThang.Controls.Add(dtpThang);
            grpChonThang.Controls.Add(btnTinhLuong);
            grpChonThang.Controls.Add(btnChotLuong);
            grpChonThang.Controls.Add(lblTrangThai);
            grpChonThang.Location = new Point(12, 10);
            grpChonThang.Name = "grpChonThang";
            grpChonThang.Size = new Size(936, 66);
            grpChonThang.TabIndex = 0;
            grpChonThang.TabStop = false;
            grpChonThang.Text = "Tính lương && chốt lương tháng";
            //
            // lblThang
            //
            lblThang.AutoSize = true;
            lblThang.Location = new Point(16, 30);
            lblThang.Name = "lblThang";
            lblThang.Text = "Tháng / Năm:";
            //
            // dtpThang
            //
            dtpThang.CustomFormat = "MM/yyyy";
            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.Location = new Point(104, 26);
            dtpThang.Name = "dtpThang";
            dtpThang.ShowUpDown = true;
            dtpThang.Size = new Size(100, 23);
            dtpThang.TabIndex = 0;
            //
            // btnTinhLuong
            //
            btnTinhLuong.Location = new Point(216, 23);
            btnTinhLuong.Name = "btnTinhLuong";
            btnTinhLuong.Size = new Size(130, 30);
            btnTinhLuong.TabIndex = 1;
            btnTinhLuong.Text = "Tính lương";
            btnTinhLuong.UseVisualStyleBackColor = true;
            btnTinhLuong.Click += btnTinhLuong_Click;
            //
            // btnChotLuong
            //
            btnChotLuong.BackColor = Color.Firebrick;
            btnChotLuong.FlatStyle = FlatStyle.Flat;
            btnChotLuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChotLuong.ForeColor = Color.White;
            btnChotLuong.Location = new Point(356, 23);
            btnChotLuong.Name = "btnChotLuong";
            btnChotLuong.Size = new Size(150, 30);
            btnChotLuong.TabIndex = 2;
            btnChotLuong.Text = "Chốt lương tháng";
            btnChotLuong.UseVisualStyleBackColor = false;
            btnChotLuong.Click += btnChotLuong_Click;
            //
            // lblTrangThai
            //
            lblTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrangThai.Location = new Point(520, 30);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(404, 20);
            lblTrangThai.Text = "Chọn tháng rồi bấm \"Tính lương\".";
            //
            // dgvLuong
            //
            dgvLuong.AllowUserToAddRows = false;
            dgvLuong.AllowUserToDeleteRows = false;
            dgvLuong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLuong.BackgroundColor = Color.White;
            dgvLuong.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colHoTen, colTenPB, colLuongCoBan, colHeSoLuong, colSoNgayCong, colSoGioOT, colThucLinh });
            dgvLuong.Location = new Point(12, 86);
            dgvLuong.MultiSelect = false;
            dgvLuong.Name = "dgvLuong";
            dgvLuong.ReadOnly = true;
            dgvLuong.RowHeadersVisible = false;
            dgvLuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLuong.Size = new Size(936, 330);
            dgvLuong.TabIndex = 1;
            //
            // colMaNV
            //
            colMaNV.DataPropertyName = "MaNV";
            colMaNV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaNV.FillWeight = 7F;
            colMaNV.HeaderText = "Mã NV";
            colMaNV.Name = "colMaNV";
            colMaNV.ReadOnly = true;
            //
            // colHoTen
            //
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 20F;
            colHoTen.HeaderText = "Họ và tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            //
            // colTenPB
            //
            colTenPB.DataPropertyName = "TenPB";
            colTenPB.FillWeight = 20F;
            colTenPB.HeaderText = "Phòng ban";
            colTenPB.Name = "colTenPB";
            colTenPB.ReadOnly = true;
            //
            // colLuongCoBan
            //
            colLuongCoBan.DataPropertyName = "LuongCoBan";
            colLuongCoBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colLuongCoBan.DefaultCellStyle.Format = "N0";
            colLuongCoBan.FillWeight = 13F;
            colLuongCoBan.HeaderText = "Lương cơ bản";
            colLuongCoBan.Name = "colLuongCoBan";
            colLuongCoBan.ReadOnly = true;
            //
            // colHeSoLuong
            //
            colHeSoLuong.DataPropertyName = "HeSoLuong";
            colHeSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHeSoLuong.DefaultCellStyle.Format = "0.00";
            colHeSoLuong.FillWeight = 7F;
            colHeSoLuong.HeaderText = "Hệ số";
            colHeSoLuong.Name = "colHeSoLuong";
            colHeSoLuong.ReadOnly = true;
            //
            // colSoNgayCong
            //
            colSoNgayCong.DataPropertyName = "SoNgayCong";
            colSoNgayCong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoNgayCong.FillWeight = 8F;
            colSoNgayCong.HeaderText = "Ngày công";
            colSoNgayCong.Name = "colSoNgayCong";
            colSoNgayCong.ReadOnly = true;
            //
            // colSoGioOT
            //
            colSoGioOT.DataPropertyName = "SoGioOT";
            colSoGioOT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoGioOT.FillWeight = 8F;
            colSoGioOT.HeaderText = "Giờ OT";
            colSoGioOT.Name = "colSoGioOT";
            colSoGioOT.ReadOnly = true;
            //
            // colThucLinh
            //
            colThucLinh.DataPropertyName = "ThucLinh";
            colThucLinh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colThucLinh.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colThucLinh.DefaultCellStyle.ForeColor = Color.DarkGreen;
            colThucLinh.DefaultCellStyle.Format = "N0";
            colThucLinh.FillWeight = 14F;
            colThucLinh.HeaderText = "Thực lĩnh";
            colThucLinh.Name = "colThucLinh";
            colThucLinh.ReadOnly = true;
            //
            // lblCongThuc
            //
            lblCongThuc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCongThuc.ForeColor = Color.DimGray;
            lblCongThuc.Location = new Point(12, 428);
            lblCongThuc.Name = "lblCongThuc";
            lblCongThuc.Size = new Size(560, 20);
            lblCongThuc.Text = "Thực lĩnh = (Lương cơ bản × Hệ số / 22) × Số ngày công + Số giờ OT × 50.000";
            //
            // lblTongLuong
            //
            lblTongLuong.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTongLuong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongLuong.ForeColor = Color.Firebrick;
            lblTongLuong.Location = new Point(588, 424);
            lblTongLuong.Name = "lblTongLuong";
            lblTongLuong.Size = new Size(360, 26);
            lblTongLuong.Text = "Tổng quỹ lương: 0 đ";
            lblTongLuong.TextAlign = ContentAlignment.MiddleRight;
            //
            // FormTinhLuong
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 460);
            Controls.Add(grpChonThang);
            Controls.Add(dgvLuong);
            Controls.Add(lblCongThuc);
            Controls.Add(lblTongLuong);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(976, 440);
            Name = "FormTinhLuong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tính lương & Chốt lương (SqlTransaction)";
            Load += FormTinhLuong_Load;
            grpChonThang.ResumeLayout(false);
            grpChonThang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpChonThang;
        private Label lblThang;
        private DateTimePicker dtpThang;
        private Button btnTinhLuong;
        private Button btnChotLuong;
        private Label lblTrangThai;
        private DataGridView dgvLuong;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colTenPB;
        private DataGridViewTextBoxColumn colLuongCoBan;
        private DataGridViewTextBoxColumn colHeSoLuong;
        private DataGridViewTextBoxColumn colSoNgayCong;
        private DataGridViewTextBoxColumn colSoGioOT;
        private DataGridViewTextBoxColumn colThucLinh;
        private Label lblCongThuc;
        private Label lblTongLuong;
    }
}
