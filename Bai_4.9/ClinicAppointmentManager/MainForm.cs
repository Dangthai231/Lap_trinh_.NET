using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using ClinicAppointmentManager.Models;

namespace ClinicAppointmentManager
{
    public partial class MainForm : Form
    {
        private BindingList<Appointment> _allAppointments = new();
        private BindingList<Appointment> _filteredAppointments = new();
        private BindingSource _bindingSource = new();
        private ErrorProvider _errorProvider = new();
        private bool _isEditing = false;
        private string _editingMa = string.Empty;

        // ---- Danh sách bác sĩ mẫu ----
        private readonly string[] _bacSiList = { "BS. Nguyễn Văn An", "BS. Trần Thị Bình", "BS. Lê Văn Cường", "BS. Phạm Thị Dung", "BS. Hoàng Văn Em" };
        private readonly string[] _trangThaiList = { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" };

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // ComboBox bác sĩ
            cbBacSi.Items.AddRange(_bacSiList);
            cbBacSi.SelectedIndex = 0;

            // ComboBox trạng thái
            cbTrangThai.Items.AddRange(_trangThaiList);
            cbTrangThai.SelectedIndex = 0;

            // ComboBox lọc trạng thái
            cbLocTrangThai.Items.Add("-- Tất cả --");
            cbLocTrangThai.Items.AddRange(_trangThaiList);
            cbLocTrangThai.SelectedIndex = 0;

            // DateTimePicker
            dtpNgayGio.Format = DateTimePickerFormat.Custom;
            dtpNgayGio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayGio.Value = DateTime.Now.AddHours(1);
            dtpNgayGio.ShowUpDown = false;

            // DateTimePicker lọc
            dtpLocNgay.Format = DateTimePickerFormat.Custom;
            dtpLocNgay.CustomFormat = "dd/MM/yyyy";
            dtpLocNgay.Value = DateTime.Today;
            dtpLocNgay.ShowCheckBox = true;
            dtpLocNgay.Checked = false;

            // DataGridView
            SetupDataGridView();

            // Binding
            _bindingSource.DataSource = _filteredAppointments;
            dgvLichHen.DataSource = _bindingSource;

            // Tạo mã tự động
            GenerateNewMa();

            // Event
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            cbLocTrangThai.SelectedIndexChanged += ApplyFilter;
            dtpLocNgay.ValueChanged += ApplyFilter;
            dgvLichHen.SelectionChanged += DgvLichHen_SelectionChanged!;

            UpdateStatus();
        }

        private void SetupDataGridView()
        {
            dgvLichHen.AutoGenerateColumns = false;
            dgvLichHen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichHen.MultiSelect = false;
            dgvLichHen.ReadOnly = true;
            dgvLichHen.AllowUserToAddRows = false;
            dgvLichHen.AllowUserToDeleteRows = false;
            dgvLichHen.RowHeadersVisible = false;
            dgvLichHen.BackgroundColor = SystemColors.Window;
            dgvLichHen.BorderStyle = BorderStyle.Fixed3D;
            dgvLichHen.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            var cols = new[]
            {
                new DataGridViewTextBoxColumn { Name = "MaLichHen",     DataPropertyName = "MaLichHen",     HeaderText = "Mã lịch hẹn",       Width = 110 },
                new DataGridViewTextBoxColumn { Name = "HoTenBenhNhan", DataPropertyName = "HoTenBenhNhan", HeaderText = "Họ tên bệnh nhân",   Width = 170 },
                new DataGridViewTextBoxColumn { Name = "SoDienThoai",   DataPropertyName = "SoDienThoai",   HeaderText = "Số điện thoại",      Width = 120 },
                new DataGridViewTextBoxColumn { Name = "NgayGioHen",    DataPropertyName = "NgayGioHen",    HeaderText = "Ngày giờ hẹn",       Width = 130 },
                new DataGridViewTextBoxColumn { Name = "BacSi",         DataPropertyName = "BacSi",         HeaderText = "Bác sĩ",             Width = 160 },
                new DataGridViewTextBoxColumn { Name = "LyDoKham",      DataPropertyName = "LyDoKham",      HeaderText = "Lý do khám",         Width = 160 },
                new DataGridViewTextBoxColumn { Name = "TrangThai",     DataPropertyName = "TrangThai",     HeaderText = "Trạng thái",         Width = 100 },
            };

            // Format ngày giờ
            ((DataGridViewTextBoxColumn)cols[3]).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            foreach (var col in cols)
            {
                col.ReadOnly = true;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
                dgvLichHen.Columns.Add(col);
            }
        }

        // ========== Validation ==========
        private bool ValidateInputs()
        {
            bool valid = true;
            _errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtMaLichHen.Text))
            {
                _errorProvider.SetError(txtMaLichHen, "Mã lịch hẹn không được để trống.");
                valid = false;
            }
            else
            {
                // Kiểm tra trùng mã (khi thêm mới)
                if (!_isEditing && _allAppointments.Any(a => a.MaLichHen == txtMaLichHen.Text.Trim()))
                {
                    _errorProvider.SetError(txtMaLichHen, "Mã lịch hẹn đã tồn tại.");
                    valid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                _errorProvider.SetError(txtHoTen, "Họ tên không được để trống.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDT.Text))
            {
                _errorProvider.SetError(txtSoDT, "Số điện thoại không được để trống.");
                valid = false;
            }
            else if (!Regex.IsMatch(txtSoDT.Text.Trim(), @"^(0[3|5|7|8|9])[0-9]{8}$"))
            {
                _errorProvider.SetError(txtSoDT, "Số điện thoại không hợp lệ (10 số, đầu 03/05/07/08/09).");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                _errorProvider.SetError(txtLyDo, "Lý do khám không được để trống.");
                valid = false;
            }

            if (dtpNgayGio.Value <= DateTime.Now)
            {
                _errorProvider.SetError(dtpNgayGio, "Ngày hẹn không được nằm trong quá khứ.");
                valid = false;
            }

            return valid;
        }

        // ========== CRUD ==========
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var apt = new Appointment
            {
                MaLichHen = txtMaLichHen.Text.Trim(),
                HoTenBenhNhan = txtHoTen.Text.Trim(),
                SoDienThoai = txtSoDT.Text.Trim(),
                NgayGioHen = dtpNgayGio.Value,
                BacSi = cbBacSi.SelectedItem?.ToString() ?? "",
                LyDoKham = txtLyDo.Text.Trim(),
                TrangThai = cbTrangThai.SelectedItem?.ToString() ?? "Chờ khám"
            };

            _allAppointments.Add(apt);
            ApplyFilter(null, EventArgs.Empty);
            ClearForm();
            UpdateStatus();
            MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (!_isEditing)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn trong danh sách để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            var apt = _allAppointments.FirstOrDefault(a => a.MaLichHen == _editingMa);
            if (apt == null) return;

            apt.HoTenBenhNhan = txtHoTen.Text.Trim();
            apt.SoDienThoai = txtSoDT.Text.Trim();
            apt.NgayGioHen = dtpNgayGio.Value;
            apt.BacSi = cbBacSi.SelectedItem?.ToString() ?? "";
            apt.LyDoKham = txtLyDo.Text.Trim();
            apt.TrangThai = cbTrangThai.SelectedItem?.ToString() ?? "Chờ khám";

            ApplyFilter(null, EventArgs.Empty);
            ClearForm();
            UpdateStatus();
            MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichHen.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ma = dgvLichHen.SelectedRows[0].Cells["MaLichHen"].Value?.ToString();
            var hoTen = dgvLichHen.SelectedRows[0].Cells["HoTenBenhNhan"].Value?.ToString();

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa lịch hẹn của bệnh nhân '{hoTen}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var apt = _allAppointments.FirstOrDefault(a => a.MaLichHen == ma);
            if (apt != null)
            {
                _allAppointments.Remove(apt);
                ApplyFilter(null, EventArgs.Empty);
                ClearForm();
                UpdateStatus();
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ========== Selection ==========
        private void DgvLichHen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLichHen.SelectedRows.Count == 0) return;

            var ma = dgvLichHen.SelectedRows[0].Cells["MaLichHen"].Value?.ToString();
            var apt = _allAppointments.FirstOrDefault(a => a.MaLichHen == ma);
            if (apt == null) return;

            _isEditing = true;
            _editingMa = apt.MaLichHen;

            txtMaLichHen.Text = apt.MaLichHen;
            txtMaLichHen.ReadOnly = true;
            txtHoTen.Text = apt.HoTenBenhNhan;
            txtSoDT.Text = apt.SoDienThoai;
            dtpNgayGio.Value = apt.NgayGioHen;
            cbBacSi.SelectedItem = apt.BacSi;
            txtLyDo.Text = apt.LyDoKham;
            cbTrangThai.SelectedItem = apt.TrangThai;

            _errorProvider.Clear();
        }

        // ========== Search & Filter ==========
        private void TxtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            ApplyFilter(sender, e ?? EventArgs.Empty);
        }

        private void ApplyFilter(object? sender, EventArgs e)
        {
            var keyword = txtTimKiem.Text.Trim().ToLower();
            var trangThai = cbLocTrangThai.SelectedIndex == 0 ? null : cbLocTrangThai.SelectedItem?.ToString();
            var locNgay = dtpLocNgay.Checked ? dtpLocNgay.Value.Date : (DateTime?)null;

            var filtered = _allAppointments.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(keyword))
                filtered = filtered.Where(a =>
                    a.HoTenBenhNhan.ToLower().Contains(keyword) ||
                    a.SoDienThoai.Contains(keyword));

            if (trangThai != null)
                filtered = filtered.Where(a => a.TrangThai == trangThai);

            if (locNgay.HasValue)
                filtered = filtered.Where(a => a.NgayGioHen.Date == locNgay.Value);

            _filteredAppointments.Clear();
            foreach (var a in filtered)
                _filteredAppointments.Add(a);

            _bindingSource.ResetBindings(false);
            UpdateStatus();
        }

        // ========== Helpers ==========
        private void ClearForm()
        {
            _isEditing = false;
            _editingMa = string.Empty;
            _errorProvider.Clear();
            txtMaLichHen.ReadOnly = false;
            GenerateNewMa();
            txtHoTen.Clear();
            txtSoDT.Clear();
            dtpNgayGio.Value = DateTime.Now.AddHours(1);
            cbBacSi.SelectedIndex = 0;
            txtLyDo.Clear();
            cbTrangThai.SelectedIndex = 0;
            dgvLichHen.ClearSelection();
        }

        private void GenerateNewMa()
        {
            int next = _allAppointments.Count + 1;
            txtMaLichHen.Text = $"LH{next:D4}";
        }

        private void UpdateStatus()
        {
            lblStatus.Text = $"Hiển thị: {_filteredAppointments.Count} / {_allAppointments.Count} lịch hẹn";
        }

        // ========== Menu: Xuất CSV ==========
        private void MenuXuatCSV_Click(object sender, EventArgs e)
        {
            if (_filteredAppointments.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"LichHen_{DateTime.Now:yyyyMMdd_HHmm}.csv",
                Title = "Lưu danh sách lịch hẹn"
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            var sb = new StringBuilder();
            sb.AppendLine("Mã lịch hẹn,Họ tên bệnh nhân,Số điện thoại,Ngày giờ hẹn,Bác sĩ,Lý do khám,Trạng thái");

            foreach (var a in _filteredAppointments)
                sb.AppendLine($"{a.MaLichHen},{a.HoTenBenhNhan},{a.SoDienThoai},{a.NgayGioHen:dd/MM/yyyy HH:mm},{a.BacSi},{a.LyDoKham},{a.TrangThai}");

            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show($"Xuất thành công {_filteredAppointments.Count} lịch hẹn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
