namespace QuanLyNhanSu.GUI
{
    partial class FormBaoCao
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
            btnXem = new Button();
            lblTongQuy = new Label();
            lblSoNV = new Label();
            lblLuongTB = new Label();
            grpPhongBan = new GroupBox();
            lsvPhongBan = new ListView();
            colTenPB = new ColumnHeader();
            colSoNV = new ColumnHeader();
            colTongLuong = new ColumnHeader();
            grpBangLuong = new GroupBox();
            dgvBangLuong = new DataGridView();
            colMaNV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colPhongBan = new DataGridViewTextBoxColumn();
            colNgayCong = new DataGridViewTextBoxColumn();
            colGioOT = new DataGridViewTextBoxColumn();
            colThucLinh = new DataGridViewTextBoxColumn();
            grpChonThang.SuspendLayout();
            grpPhongBan.SuspendLayout();
            grpBangLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBangLuong).BeginInit();
            SuspendLayout();
            //
            // grpChonThang
            //
            grpChonThang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChonThang.Controls.Add(lblThang);
            grpChonThang.Controls.Add(dtpThang);
            grpChonThang.Controls.Add(btnXem);
            grpChonThang.Controls.Add(lblTongQuy);
            grpChonThang.Controls.Add(lblSoNV);
            grpChonThang.Controls.Add(lblLuongTB);
            grpChonThang.Location = new Point(12, 10);
            grpChonThang.Name = "grpChonThang";
            grpChonThang.Size = new Size(956, 96);
            grpChonThang.TabIndex = 0;
            grpChonThang.TabStop = false;
            grpChonThang.Text = "Báo cáo quỹ lương tháng (bảng lương đã chốt)";
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
            // btnXem
            //
            btnXem.Location = new Point(216, 23);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(110, 30);
            btnXem.TabIndex = 1;
            btnXem.Text = "Xem báo cáo";
            btnXem.UseVisualStyleBackColor = true;
            btnXem.Click += btnXem_Click;
            //
            // lblTongQuy
            //
            lblTongQuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongQuy.ForeColor = Color.Firebrick;
            lblTongQuy.Location = new Point(350, 26);
            lblTongQuy.Name = "lblTongQuy";
            lblTongQuy.Size = new Size(590, 24);
            lblTongQuy.Text = "Tổng quỹ lương: 0 đ";
            //
            // lblSoNV
            //
            lblSoNV.Location = new Point(16, 64);
            lblSoNV.Name = "lblSoNV";
            lblSoNV.Size = new Size(320, 20);
            lblSoNV.Text = "Số nhân viên nhận lương: 0";
            //
            // lblLuongTB
            //
            lblLuongTB.Location = new Point(350, 64);
            lblLuongTB.Name = "lblLuongTB";
            lblLuongTB.Size = new Size(590, 20);
            lblLuongTB.Text = "Lương bình quân: 0 đ";
            //
            // grpPhongBan
            //
            grpPhongBan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpPhongBan.Controls.Add(lsvPhongBan);
            grpPhongBan.Location = new Point(12, 116);
            grpPhongBan.Name = "grpPhongBan";
            grpPhongBan.Size = new Size(380, 330);
            grpPhongBan.TabIndex = 1;
            grpPhongBan.TabStop = false;
            grpPhongBan.Text = "Quỹ lương theo phòng ban (SqlDataReader)";
            //
            // lsvPhongBan
            //
            lsvPhongBan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsvPhongBan.Columns.AddRange(new ColumnHeader[] { colTenPB, colSoNV, colTongLuong });
            lsvPhongBan.FullRowSelect = true;
            lsvPhongBan.GridLines = true;
            lsvPhongBan.Location = new Point(10, 24);
            lsvPhongBan.Name = "lsvPhongBan";
            lsvPhongBan.Size = new Size(360, 294);
            lsvPhongBan.TabIndex = 0;
            lsvPhongBan.UseCompatibleStateImageBehavior = false;
            lsvPhongBan.View = View.Details;
            //
            // colTenPB
            //
            colTenPB.Text = "Phòng ban";
            colTenPB.Width = 170;
            //
            // colSoNV
            //
            colSoNV.Text = "Số NV";
            colSoNV.TextAlign = HorizontalAlignment.Center;
            colSoNV.Width = 60;
            //
            // colTongLuong
            //
            colTongLuong.Text = "Tổng lương (đ)";
            colTongLuong.TextAlign = HorizontalAlignment.Right;
            colTongLuong.Width = 120;
            //
            // grpBangLuong
            //
            grpBangLuong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpBangLuong.Controls.Add(dgvBangLuong);
            grpBangLuong.Location = new Point(404, 116);
            grpBangLuong.Name = "grpBangLuong";
            grpBangLuong.Size = new Size(564, 330);
            grpBangLuong.TabIndex = 2;
            grpBangLuong.TabStop = false;
            grpBangLuong.Text = "Bảng lương chi tiết";
            //
            // dgvBangLuong
            //
            dgvBangLuong.AllowUserToAddRows = false;
            dgvBangLuong.AllowUserToDeleteRows = false;
            dgvBangLuong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBangLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangLuong.BackgroundColor = Color.White;
            dgvBangLuong.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colHoTen, colPhongBan, colNgayCong, colGioOT, colThucLinh });
            dgvBangLuong.Location = new Point(10, 24);
            dgvBangLuong.Name = "dgvBangLuong";
            dgvBangLuong.ReadOnly = true;
            dgvBangLuong.RowHeadersVisible = false;
            dgvBangLuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangLuong.Size = new Size(544, 294);
            dgvBangLuong.TabIndex = 0;
            //
            // colMaNV
            //
            colMaNV.DataPropertyName = "MaNV";
            colMaNV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaNV.FillWeight = 9F;
            colMaNV.HeaderText = "Mã NV";
            colMaNV.Name = "colMaNV";
            colMaNV.ReadOnly = true;
            //
            // colHoTen
            //
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 26F;
            colHoTen.HeaderText = "Họ và tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            //
            // colPhongBan
            //
            colPhongBan.DataPropertyName = "TenPB";
            colPhongBan.FillWeight = 24F;
            colPhongBan.HeaderText = "Phòng ban";
            colPhongBan.Name = "colPhongBan";
            colPhongBan.ReadOnly = true;
            //
            // colNgayCong
            //
            colNgayCong.DataPropertyName = "SoNgayCong";
            colNgayCong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNgayCong.FillWeight = 10F;
            colNgayCong.HeaderText = "Công";
            colNgayCong.Name = "colNgayCong";
            colNgayCong.ReadOnly = true;
            //
            // colGioOT
            //
            colGioOT.DataPropertyName = "SoGioOT";
            colGioOT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colGioOT.FillWeight = 9F;
            colGioOT.HeaderText = "OT";
            colGioOT.Name = "colGioOT";
            colGioOT.ReadOnly = true;
            //
            // colThucLinh
            //
            colThucLinh.DataPropertyName = "ThucLinh";
            colThucLinh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colThucLinh.DefaultCellStyle.Format = "N0";
            colThucLinh.FillWeight = 18F;
            colThucLinh.HeaderText = "Thực lĩnh";
            colThucLinh.Name = "colThucLinh";
            colThucLinh.ReadOnly = true;
            //
            // FormBaoCao
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 458);
            Controls.Add(grpChonThang);
            Controls.Add(grpPhongBan);
            Controls.Add(grpBangLuong);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(996, 440);
            Name = "FormBaoCao";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Báo cáo - Thống kê quỹ lương";
            Load += FormBaoCao_Load;
            grpChonThang.ResumeLayout(false);
            grpChonThang.PerformLayout();
            grpPhongBan.ResumeLayout(false);
            grpBangLuong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBangLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpChonThang;
        private Label lblThang;
        private DateTimePicker dtpThang;
        private Button btnXem;
        private Label lblTongQuy;
        private Label lblSoNV;
        private Label lblLuongTB;
        private GroupBox grpPhongBan;
        private ListView lsvPhongBan;
        private ColumnHeader colTenPB;
        private ColumnHeader colSoNV;
        private ColumnHeader colTongLuong;
        private GroupBox grpBangLuong;
        private DataGridView dgvBangLuong;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colPhongBan;
        private DataGridViewTextBoxColumn colNgayCong;
        private DataGridViewTextBoxColumn colGioOT;
        private DataGridViewTextBoxColumn colThucLinh;
    }
}
