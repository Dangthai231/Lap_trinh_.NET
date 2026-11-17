namespace QuanLyNhanSu.GUI
{
    partial class FormChamCong
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
            btnNap = new Button();
            lblTrangThai = new Label();
            dgvChamCong = new DataGridView();
            colMaNV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colTenPB = new DataGridViewTextBoxColumn();
            colSoNgayCong = new DataGridViewTextBoxColumn();
            colSoGioOT = new DataGridViewTextBoxColumn();
            lblHuongDan = new Label();
            btnLuu = new Button();
            grpChonThang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();
            //
            // grpChonThang
            //
            grpChonThang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChonThang.Controls.Add(lblThang);
            grpChonThang.Controls.Add(dtpThang);
            grpChonThang.Controls.Add(btnNap);
            grpChonThang.Controls.Add(lblTrangThai);
            grpChonThang.Location = new Point(12, 10);
            grpChonThang.Name = "grpChonThang";
            grpChonThang.Size = new Size(796, 66);
            grpChonThang.TabIndex = 0;
            grpChonThang.TabStop = false;
            grpChonThang.Text = "Chọn tháng chấm công";
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
            // btnNap
            //
            btnNap.Location = new Point(216, 23);
            btnNap.Name = "btnNap";
            btnNap.Size = new Size(170, 30);
            btnNap.TabIndex = 1;
            btnNap.Text = "Nạp bảng chấm công";
            btnNap.UseVisualStyleBackColor = true;
            btnNap.Click += btnNap_Click;
            //
            // lblTrangThai
            //
            lblTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrangThai.Location = new Point(400, 30);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(384, 20);
            lblTrangThai.Text = "Chọn tháng rồi bấm \"Nạp bảng chấm công\".";
            //
            // dgvChamCong
            //
            dgvChamCong.AllowUserToAddRows = false;
            dgvChamCong.AllowUserToDeleteRows = false;
            dgvChamCong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChamCong.BackgroundColor = Color.White;
            dgvChamCong.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colHoTen, colTenPB, colSoNgayCong, colSoGioOT });
            dgvChamCong.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvChamCong.Location = new Point(12, 86);
            dgvChamCong.MultiSelect = false;
            dgvChamCong.Name = "dgvChamCong";
            dgvChamCong.RowHeadersVisible = false;
            dgvChamCong.Size = new Size(796, 340);
            dgvChamCong.TabIndex = 1;
            dgvChamCong.CellValidating += dgvChamCong_CellValidating;
            dgvChamCong.CellEndEdit += dgvChamCong_CellEndEdit;
            dgvChamCong.CellParsing += dgvChamCong_CellParsing;
            dgvChamCong.DataError += dgvChamCong_DataError;
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
            // colHoTen
            //
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 30F;
            colHoTen.HeaderText = "Họ và tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            //
            // colTenPB
            //
            colTenPB.DataPropertyName = "TenPB";
            colTenPB.FillWeight = 28F;
            colTenPB.HeaderText = "Phòng ban";
            colTenPB.Name = "colTenPB";
            colTenPB.ReadOnly = true;
            //
            // colSoNgayCong
            //
            colSoNgayCong.DataPropertyName = "SoNgayCong";
            colSoNgayCong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoNgayCong.DefaultCellStyle.BackColor = Color.LightYellow;
            colSoNgayCong.FillWeight = 16F;
            colSoNgayCong.HeaderText = "Số ngày công";
            colSoNgayCong.Name = "colSoNgayCong";
            //
            // colSoGioOT
            //
            colSoGioOT.DataPropertyName = "SoGioOT";
            colSoGioOT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoGioOT.DefaultCellStyle.BackColor = Color.LightYellow;
            colSoGioOT.FillWeight = 16F;
            colSoGioOT.HeaderText = "Số giờ OT";
            colSoGioOT.Name = "colSoGioOT";
            //
            // lblHuongDan
            //
            lblHuongDan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblHuongDan.ForeColor = Color.DimGray;
            lblHuongDan.Location = new Point(12, 438);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(590, 40);
            lblHuongDan.Text = "Gõ trực tiếp số ngày công (0 - 31) và số giờ làm thêm vào 2 cột màu vàng, sau đó bấm \"Lưu chấm công\" để lưu tất cả về SQL Server trong 1 lần.";
            //
            // btnLuu
            //
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuu.BackColor = Color.SeaGreen;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(628, 436);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(180, 42);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Lưu chấm công";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            //
            // FormChamCong
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 490);
            Controls.Add(grpChonThang);
            Controls.Add(dgvChamCong);
            Controls.Add(lblHuongDan);
            Controls.Add(btnLuu);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(836, 460);
            Name = "FormChamCong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chấm công tháng (Disconnected Model)";
            FormClosing += FormChamCong_FormClosing;
            Load += FormChamCong_Load;
            grpChonThang.ResumeLayout(false);
            grpChonThang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpChonThang;
        private Label lblThang;
        private DateTimePicker dtpThang;
        private Button btnNap;
        private Label lblTrangThai;
        private DataGridView dgvChamCong;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colTenPB;
        private DataGridViewTextBoxColumn colSoNgayCong;
        private DataGridViewTextBoxColumn colSoGioOT;
        private Label lblHuongDan;
        private Button btnLuu;
    }
}
