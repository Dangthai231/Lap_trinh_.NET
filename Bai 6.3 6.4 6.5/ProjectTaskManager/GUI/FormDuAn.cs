using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectTaskManager.BUS;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.GUI
{
    public class FormDuAn : Form
    {
        private readonly DuAnBUS _duAnBUS = new DuAnBUS();
        private readonly int _maDuAn;

        private TextBox txtTenDuAn;
        private DateTimePicker dtpNgayBatDau;
        private DateTimePicker dtpNgayKetThuc;
        private ComboBox cboTrangThai;
        private Button btnLuu;
        private Button btnHuy;

        public FormDuAn(int maDuAn = 0)
        {
            _maDuAn = maDuAn;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = _maDuAn > 0 ? "Chỉnh sửa dự án" : "Thêm mới dự án";
            this.Size = new Size(480, 360);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            this.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = _maDuAn > 0 ? "CHỈNH SỬA THÔNG TIN DỰ ÁN" : "TẠO MỚI DỰ ÁN",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(25, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            int y = 65;
            int lblX = 25;
            int inputX = 140;
            int inputW = 290;
            int rowSpacing = 42;

            // Tên dự án
            Label lblTen = new Label { Text = "Tên dự án (*):", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTenDuAn = new TextBox { Location = new Point(inputX, y), Width = inputW };
            this.Controls.Add(lblTen);
            this.Controls.Add(txtTenDuAn);

            // Ngày bắt đầu
            y += rowSpacing;
            Label lblBD = new Label { Text = "Ngày bắt đầu:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            dtpNgayBatDau = new DateTimePicker { Location = new Point(inputX, y), Width = inputW, Format = DateTimePickerFormat.Short };
            this.Controls.Add(lblBD);
            this.Controls.Add(dtpNgayBatDau);

            // Ngày kết thúc
            y += rowSpacing;
            Label lblKT = new Label { Text = "Ngày kết thúc:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            dtpNgayKetThuc = new DateTimePicker { Location = new Point(inputX, y), Width = inputW, Format = DateTimePickerFormat.Short };
            dtpNgayKetThuc.Value = DateTime.Today.AddMonths(1);
            this.Controls.Add(lblKT);
            this.Controls.Add(dtpNgayKetThuc);

            // Trạng thái
            y += rowSpacing;
            Label lblTrangThai = new Label { Text = "Trạng thái:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTrangThai = new ComboBox { Location = new Point(inputX, y), Width = inputW, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTrangThai.Items.AddRange(new object[] { "Đang chạy", "Hoàn thành", "Tạm dừng" });
            cboTrangThai.SelectedIndex = 0;
            this.Controls.Add(lblTrangThai);
            this.Controls.Add(cboTrangThai);

            // Buttons
            y += 60;
            btnLuu = new Button
            {
                Text = "💾 Lưu dự án",
                Location = new Point(inputX + 40, y),
                Size = new Size(120, 36),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.Click += BtnLuu_Click;

            btnHuy = new Button
            {
                Text = "Hủy bỏ",
                Location = new Point(inputX + 170, y),
                Size = new Size(100, 36),
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Color.FromArgb(51, 65, 85),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Click += (s, e) => this.Close();

            this.Controls.Add(btnLuu);
            this.Controls.Add(btnHuy);
        }

        private void LoadData()
        {
            if (_maDuAn > 0)
            {
                DuAnDTO duAn = _duAnBUS.LayTheoMa(_maDuAn);
                if (duAn != null)
                {
                    txtTenDuAn.Text = duAn.TenDuAn;
                    if (duAn.NgayBatDau.HasValue)
                        dtpNgayBatDau.Value = duAn.NgayBatDau.Value;
                    if (duAn.NgayKetThuc.HasValue)
                        dtpNgayKetThuc.Value = duAn.NgayKetThuc.Value;
                    if (!string.IsNullOrEmpty(duAn.TrangThai))
                        cboTrangThai.SelectedItem = duAn.TrangThai;
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDuAn.Text))
            {
                MessageBox.Show("Tên dự án không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDuAn.Focus();
                return;
            }

            if (dtpNgayKetThuc.Value < dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DuAnDTO duAn = new DuAnDTO
            {
                MaDuAn = _maDuAn,
                TenDuAn = txtTenDuAn.Text.Trim(),
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Value,
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang chạy"
            };

            if (_maDuAn == 0)
            {
                var res = _duAnBUS.Them(duAn);
                if (res.Success)
                {
                    MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var res = _duAnBUS.Sua(duAn);
                if (res.Success)
                {
                    MessageBox.Show(res.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
