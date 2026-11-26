using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ProjectTaskManager.BUS;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.GUI
{
    public class FormThanhVien : Form
    {
        private readonly ThanhVienBUS _thanhVienBUS = new ThanhVienBUS();
        private readonly int _maThanhVien;

        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtChuyenMon;
        private Button btnLuu;
        private Button btnHuy;

        public FormThanhVien(int maThanhVien = 0)
        {
            _maThanhVien = maThanhVien;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = _maThanhVien > 0 ? "Chỉnh sửa thành viên" : "Thêm mới thành viên";
            this.Size = new Size(460, 310);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            this.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = _maThanhVien > 0 ? "CHỈNH SỬA THÀNH VIÊN" : "THÊM MỚI THÀNH VIÊN",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(25, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            int y = 65;
            int lblX = 25;
            int inputX = 140;
            int inputW = 270;
            int rowSpacing = 42;

            // Họ tên
            Label lblHoTen = new Label { Text = "Họ và tên (*):", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtHoTen = new TextBox { Location = new Point(inputX, y), Width = inputW };
            this.Controls.Add(lblHoTen);
            this.Controls.Add(txtHoTen);

            // Email
            y += rowSpacing;
            Label lblEmail = new Label { Text = "Email (*):", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtEmail = new TextBox { Location = new Point(inputX, y), Width = inputW };
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);

            // Chuyên môn
            y += rowSpacing;
            Label lblChuyenMon = new Label { Text = "Chuyên môn:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtChuyenMon = new TextBox { Location = new Point(inputX, y), Width = inputW };
            this.Controls.Add(lblChuyenMon);
            this.Controls.Add(txtChuyenMon);

            // Buttons
            y += 55;
            btnLuu = new Button
            {
                Text = "💾 Lưu",
                Location = new Point(inputX + 40, y),
                Size = new Size(100, 36),
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
                Location = new Point(inputX + 150, y),
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
            if (_maThanhVien > 0)
            {
                ThanhVienDTO tv = _thanhVienBUS.LayTheoMa(_maThanhVien);
                if (tv != null)
                {
                    txtHoTen.Text = tv.HoTen;
                    txtEmail.Text = tv.Email;
                    txtChuyenMon.Text = tv.ChuyenMon;
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Định dạng email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            ThanhVienDTO tv = new ThanhVienDTO
            {
                MaThanhVien = _maThanhVien,
                HoTen = txtHoTen.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ChuyenMon = txtChuyenMon.Text.Trim()
            };

            if (_maThanhVien == 0)
            {
                var res = _thanhVienBUS.Them(tv);
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
                var res = _thanhVienBUS.Sua(tv);
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
