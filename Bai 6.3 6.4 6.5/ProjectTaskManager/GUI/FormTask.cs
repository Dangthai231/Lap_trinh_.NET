using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjectTaskManager.BUS;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.GUI
{
    public class FormTask : Form
    {
        private readonly CongViecBUS _congViecBUS = new CongViecBUS();
        private readonly DuAnBUS _duAnBUS = new DuAnBUS();
        private readonly ThanhVienBUS _thanhVienBUS = new ThanhVienBUS();
        private readonly PhanCongBUS _phanCongBUS = new PhanCongBUS();

        private readonly int _maTask;
        private readonly int _maDuAnMacDinh;

        private ComboBox cboDuAn;
        private TextBox txtTenTask;
        private TextBox txtMoTa;
        private DateTimePicker dtpHanNop;
        private ComboBox cboDoUuTien;
        private ComboBox cboTrangThai;
        private CheckedListBox clbThanhVien;
        private Button btnLuu;
        private Button btnHuy;

        public FormTask(int maTask = 0, int maDuAnMacDinh = 0, string trangThaiMacDinh = "To Do")
        {
            _maTask = maTask;
            _maDuAnMacDinh = maDuAnMacDinh;

            InitializeComponent();
            LoadData(trangThaiMacDinh);
        }

        private void InitializeComponent()
        {
            this.Text = _maTask > 0 ? "Chỉnh sửa công việc (Task)" : "Thêm mới công việc (Task)";
            this.Size = new Size(540, 620);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            this.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = _maTask > 0 ? "CHỈNH SỬA CÔNG VIỆC" : "TẠO MỚI CÔNG VIỆC",
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(25, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            int y = 65;
            int lblX = 25;
            int inputX = 140;
            int inputW = 345;
            int rowSpacing = 42;

            // Dự án
            Label lblDuAn = new Label { Text = "Dự án (*):", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboDuAn = new ComboBox { Location = new Point(inputX, y), Width = inputW, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(lblDuAn);
            this.Controls.Add(cboDuAn);

            // Tên Task
            y += rowSpacing;
            Label lblTenTask = new Label { Text = "Tên Task (*):", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtTenTask = new TextBox { Location = new Point(inputX, y), Width = inputW };
            this.Controls.Add(lblTenTask);
            this.Controls.Add(txtTenTask);

            // Hạn nộp
            y += rowSpacing;
            Label lblHanNop = new Label { Text = "Hạn nộp:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            dtpHanNop = new DateTimePicker { Location = new Point(inputX, y), Width = inputW, Format = DateTimePickerFormat.Short };
            this.Controls.Add(lblHanNop);
            this.Controls.Add(dtpHanNop);

            // Độ ưu tiên
            y += rowSpacing;
            Label lblDoUuTien = new Label { Text = "Độ ưu tiên:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboDoUuTien = new ComboBox { Location = new Point(inputX, y), Width = inputW, DropDownStyle = ComboBoxStyle.DropDownList };
            cboDoUuTien.Items.AddRange(new object[] { "Cao", "Trung bình", "Thấp" });
            cboDoUuTien.SelectedIndex = 1;
            this.Controls.Add(lblDoUuTien);
            this.Controls.Add(cboDoUuTien);

            // Trạng thái
            y += rowSpacing;
            Label lblTrangThai = new Label { Text = "Trạng thái:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cboTrangThai = new ComboBox { Location = new Point(inputX, y), Width = inputW, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTrangThai.Items.AddRange(new object[] { "To Do", "In Progress", "Review", "Done" });
            cboTrangThai.SelectedIndex = 0;
            this.Controls.Add(lblTrangThai);
            this.Controls.Add(cboTrangThai);

            // Mô tả
            y += rowSpacing;
            Label lblMoTa = new Label { Text = "Mô tả chi tiết:", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtMoTa = new TextBox { Location = new Point(inputX, y), Width = inputW, Height = 65, Multiline = true, ScrollBars = ScrollBars.Vertical };
            this.Controls.Add(lblMoTa);
            this.Controls.Add(txtMoTa);

            // Phân công thành viên
            y += 75;
            Label lblPhanCong = new Label { Text = "Phân công (*):", Location = new Point(lblX, y + 4), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            clbThanhVien = new CheckedListBox { Location = new Point(inputX, y), Width = inputW, Height = 100, CheckOnClick = true };
            this.Controls.Add(lblPhanCong);
            this.Controls.Add(clbThanhVien);

            // Buttons
            y += 115;
            btnLuu = new Button
            {
                Text = "💾 Lưu công việc",
                Location = new Point(inputX + 95, y),
                Size = new Size(130, 36),
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
                Location = new Point(inputX + 235, y),
                Size = new Size(110, 36),
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

        private void LoadData(string trangThaiMacDinh)
        {
            // Load danh sách dự án
            List<DuAnDTO> dsDuAn = _duAnBUS.LayDanhSach();
            cboDuAn.DataSource = dsDuAn;
            cboDuAn.DisplayMember = "TenDuAn";
            cboDuAn.ValueMember = "MaDuAn";

            if (_maDuAnMacDinh > 0)
                cboDuAn.SelectedValue = _maDuAnMacDinh;

            // Load danh sách thành viên vào CheckedListBox
            List<ThanhVienDTO> dsThanhVien = _thanhVienBUS.LayDanhSach();
            clbThanhVien.DataSource = dsThanhVien;
            clbThanhVien.DisplayMember = "HoTen";
            clbThanhVien.ValueMember = "MaThanhVien";

            if (!string.IsNullOrEmpty(trangThaiMacDinh))
                cboTrangThai.SelectedItem = trangThaiMacDinh;

            // Nếu sửa, load thông tin cũ
            if (_maTask > 0)
            {
                CongViecDTO task = _congViecBUS.LayTheoMa(_maTask);
                if (task != null)
                {
                    cboDuAn.SelectedValue = task.MaDuAn;
                    txtTenTask.Text = task.TenTask;
                    txtMoTa.Text = task.MoTa;
                    if (task.HanNop.HasValue)
                        dtpHanNop.Value = task.HanNop.Value;
                    if (!string.IsNullOrEmpty(task.DoUuTien))
                        cboDoUuTien.SelectedItem = task.DoUuTien;
                    if (!string.IsNullOrEmpty(task.TrangThai))
                        cboTrangThai.SelectedItem = task.TrangThai;

                    // Tick các thành viên đã được phân công
                    List<int> dsMaTV = _phanCongBUS.LayMaThanhVienTheoTask(_maTask);
                    for (int i = 0; i < clbThanhVien.Items.Count; i++)
                    {
                        if (clbThanhVien.Items[i] is ThanhVienDTO tv && dsMaTV.Contains(tv.MaThanhVien))
                        {
                            clbThanhVien.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (cboDuAn.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Dự án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenTask.Text))
            {
                MessageBox.Show("Tên công việc không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTask.Focus();
                return;
            }

            // Lấy danh sách thành viên được chọn
            List<int> dsMaTV = new List<int>();
            foreach (var item in clbThanhVien.CheckedItems)
            {
                if (item is ThanhVienDTO tv)
                {
                    dsMaTV.Add(tv.MaThanhVien);
                }
            }

            CongViecDTO task = new CongViecDTO
            {
                MaTask = _maTask,
                MaDuAn = (int)cboDuAn.SelectedValue,
                TenTask = txtTenTask.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                HanNop = dtpHanNop.Value,
                DoUuTien = cboDoUuTien.SelectedItem?.ToString() ?? "Trung bình",
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "To Do"
            };

            if (_maTask == 0)
            {
                var res = _congViecBUS.Them(task, dsMaTV);
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
                var res = _congViecBUS.Sua(task, dsMaTV);
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
