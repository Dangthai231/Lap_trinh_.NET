using System.ComponentModel;
using System.Text;
using LabEquipmentCheckout.Models;

namespace LabEquipmentCheckout
{
    public partial class MainForm : Form
    {
        private BindingList<BorrowRecord> _allRecords = new();
        private BindingList<BorrowRecord> _filtered = new();
        private BindingSource _bindingSource = new();
        private ErrorProvider _errorProvider = new();
        private bool _isEditing = false;
        private string _editingMa = string.Empty;

        private readonly string[] _thietBiList =
        {
            "Máy tính", "Màn hình", "Bàn phím", "Chuột", "Tai nghe",
            "Webcam", "Máy chiếu", "Router WiFi", "Switch mạng",
            "Oscilloscope", "Đồng hồ vạn năng", "Bộ nguồn DC",
            "Arduino Uno", "Raspberry Pi", "Board FPGA"
        };

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
        }

        // ========== Setup ==========
        private void SetupForm()
        {
            cbThietBi.Items.AddRange(_thietBiList);
            cbThietBi.SelectedIndex = 0;

            cbLocTinhTrang.Items.AddRange(new[] { "-- Tất cả --", "Đang mượn", "Đã trả", "Quá hạn" });
            cbLocTinhTrang.SelectedIndex = 0;

            dtpNgayMuon.Value = DateTime.Today;
            dtpHanTra.Value = DateTime.Today.AddDays(7);
            dtpNgayTraThucTe.Value = DateTime.Today;
            dtpNgayTraThucTe.Enabled = false;

            chkDaTra.CheckedChanged += ChkDaTra_CheckedChanged;

            SetupGrid();
            _bindingSource.DataSource = _filtered;
            dgvPhieu.DataSource = _bindingSource;

            GenerateNewMa();
            nudSoLuong.Value = 1;

            txtTimKiem.TextChanged += (s, e) => ApplyFilter();
            cbLocTinhTrang.SelectedIndexChanged += (s, e) => ApplyFilter();
            dgvPhieu.SelectionChanged += DgvPhieu_SelectionChanged!;

            UpdateStatus();
        }

        private void SetupGrid()
        {
            dgvPhieu.AutoGenerateColumns = false;
            dgvPhieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieu.MultiSelect = false;
            dgvPhieu.ReadOnly = true;
            dgvPhieu.AllowUserToAddRows = false;
            dgvPhieu.AllowUserToDeleteRows = false;
            dgvPhieu.RowHeadersVisible = false;
            dgvPhieu.BackgroundColor = SystemColors.Window;
            dgvPhieu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            var cols = new DataGridViewTextBoxColumn[]
            {
                new() { Name = "MaPhieu",          DataPropertyName = "MaPhieu",              HeaderText = "Mã phiếu",     Width = 90  },
                new() { Name = "MaSinhVien",        DataPropertyName = "MaSinhVien",           HeaderText = "Mã SV",        Width = 90  },
                new() { Name = "HoTenSinhVien",     DataPropertyName = "HoTenSinhVien",        HeaderText = "Họ tên SV",    Width = 155 },
                new() { Name = "ThietBi",           DataPropertyName = "ThietBi",              HeaderText = "Thiết bị",     Width = 130 },
                new() { Name = "SoLuong",           DataPropertyName = "SoLuong",              HeaderText = "SL",           Width = 45  },
                new() { Name = "NgayMuon",          DataPropertyName = "NgayMuon",             HeaderText = "Ngày mượn",    Width = 95  },
                new() { Name = "HanTra",            DataPropertyName = "HanTra",               HeaderText = "Hạn trả",      Width = 95  },
                new() { Name = "NgayTraThucTe",     DataPropertyName = "NgayTraThucTeDisplay", HeaderText = "Ngày trả TT",  Width = 95  },
                new() { Name = "TinhTrang",         DataPropertyName = "TinhTrang",            HeaderText = "Tình trạng",   Width = 90  },
            };
            cols[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            cols[6].DefaultCellStyle.Format = "dd/MM/yyyy";

            foreach (var c in cols) { c.ReadOnly = true; dgvPhieu.Columns.Add(c); }
        }

        // ========== Validation ==========
        private bool ValidateInputs()
        {
            _errorProvider.Clear();
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
            { _errorProvider.SetError(txtMaPhieu, "Mã phiếu không được trống."); ok = false; }
            else if (!_isEditing && _allRecords.Any(r => r.MaPhieu == txtMaPhieu.Text.Trim()))
            { _errorProvider.SetError(txtMaPhieu, "Mã phiếu đã tồn tại."); ok = false; }

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            { _errorProvider.SetError(txtMaSV, "Mã sinh viên không được trống."); ok = false; }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            { _errorProvider.SetError(txtHoTen, "Họ tên không được trống."); ok = false; }

            if (string.IsNullOrWhiteSpace(cbThietBi.Text))
            { _errorProvider.SetError(cbThietBi, "Thiết bị không được trống."); ok = false; }

            if ((int)nudSoLuong.Value < 1)
            { _errorProvider.SetError(nudSoLuong, "Số lượng phải lớn hơn 0."); ok = false; }

            if (dtpHanTra.Value.Date < dtpNgayMuon.Value.Date)
            { _errorProvider.SetError(dtpHanTra, "Hạn trả không được trước ngày mượn."); ok = false; }

            if (chkDaTra.Checked && dtpNgayTraThucTe.Value.Date < dtpNgayMuon.Value.Date)
            { _errorProvider.SetError(dtpNgayTraThucTe, "Ngày trả thực tế không được trước ngày mượn."); ok = false; }

            return ok;
        }

        // ========== CRUD ==========
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var r = BuildRecordFromForm();
            _allRecords.Add(r);
            ApplyFilter();
            ClearForm();
            UpdateStatus();
            MessageBox.Show("Thêm phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (!_isEditing) { MessageBox.Show("Chọn một phiếu trong danh sách để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidateInputs()) return;

            var rec = _allRecords.FirstOrDefault(r => r.MaPhieu == _editingMa);
            if (rec == null) return;

            FillRecordFromForm(rec);
            ApplyFilter();
            ClearForm();
            UpdateStatus();
            MessageBox.Show("Cập nhật phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) { MessageBox.Show("Chọn một phiếu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var ma = dgvPhieu.SelectedRows[0].Cells["MaPhieu"].Value?.ToString();
            var sv = dgvPhieu.SelectedRows[0].Cells["HoTenSinhVien"].Value?.ToString();

            if (MessageBox.Show($"Xóa phiếu mượn của '{sv}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var rec = _allRecords.FirstOrDefault(r => r.MaPhieu == ma);
            if (rec != null) { _allRecords.Remove(rec); ApplyFilter(); ClearForm(); UpdateStatus(); }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        // ========== Selection ==========
        private void DgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) return;
            var ma = dgvPhieu.SelectedRows[0].Cells["MaPhieu"].Value?.ToString();
            var rec = _allRecords.FirstOrDefault(r => r.MaPhieu == ma);
            if (rec == null) return;

            _isEditing = true;
            _editingMa = rec.MaPhieu;

            txtMaPhieu.Text = rec.MaPhieu;
            txtMaPhieu.ReadOnly = true;
            txtMaSV.Text = rec.MaSinhVien;
            txtHoTen.Text = rec.HoTenSinhVien;
            cbThietBi.Text = rec.ThietBi;
            nudSoLuong.Value = rec.SoLuong;
            dtpNgayMuon.Value = rec.NgayMuon;
            dtpHanTra.Value = rec.HanTra;

            chkDaTra.Checked = rec.NgayTraThucTe.HasValue;
            if (rec.NgayTraThucTe.HasValue) dtpNgayTraThucTe.Value = rec.NgayTraThucTe.Value;

            _errorProvider.Clear();
        }

        // ========== Checkbox đã trả ==========
        private void ChkDaTra_CheckedChanged(object? sender, EventArgs e)
        {
            dtpNgayTraThucTe.Enabled = chkDaTra.Checked;
            if (chkDaTra.Checked) dtpNgayTraThucTe.Value = DateTime.Today;
        }

        // ========== Filter ==========
        private void ApplyFilter()
        {
            var kw = txtTimKiem.Text.Trim().ToLower();
            var loc = cbLocTinhTrang.SelectedIndex == 0 ? null : cbLocTinhTrang.SelectedItem?.ToString();

            var q = _allRecords.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(kw))
                q = q.Where(r => r.MaSinhVien.ToLower().Contains(kw) || r.ThietBi.ToLower().Contains(kw) || r.HoTenSinhVien.ToLower().Contains(kw));
            if (loc != null)
                q = q.Where(r => r.TinhTrang == loc);

            _filtered.Clear();
            foreach (var r in q) _filtered.Add(r);
            _bindingSource.ResetBindings(false);
            UpdateStatus();
        }

        // ========== Xuất CSV ==========
        private void MenuXuatCSV_Click(object sender, EventArgs e)
        {
            if (_filtered.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            using var dlg = new SaveFileDialog { Filter = "CSV|*.csv", FileName = $"PhieuMuon_{DateTime.Now:yyyyMMdd_HHmm}.csv" };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            var sb = new StringBuilder();
            sb.AppendLine("Mã phiếu,Mã SV,Họ tên SV,Thiết bị,Số lượng,Ngày mượn,Hạn trả,Ngày trả TT,Tình trạng");
            foreach (var r in _filtered)
                sb.AppendLine($"{r.MaPhieu},{r.MaSinhVien},{r.HoTenSinhVien},{r.ThietBi},{r.SoLuong},{r.NgayMuon:dd/MM/yyyy},{r.HanTra:dd/MM/yyyy},{r.NgayTraThucTeDisplay},{r.TinhTrang}");

            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show($"Xuất {_filtered.Count} phiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        // ========== Helpers ==========
        private BorrowRecord BuildRecordFromForm()
        {
            var r = new BorrowRecord();
            FillRecordFromForm(r);
            r.MaPhieu = txtMaPhieu.Text.Trim();
            return r;
        }

        private void FillRecordFromForm(BorrowRecord r)
        {
            r.MaSinhVien = txtMaSV.Text.Trim();
            r.HoTenSinhVien = txtHoTen.Text.Trim();
            r.ThietBi = cbThietBi.Text.Trim();
            r.SoLuong = (int)nudSoLuong.Value;
            r.NgayMuon = dtpNgayMuon.Value.Date;
            r.HanTra = dtpHanTra.Value.Date;
            r.NgayTraThucTe = chkDaTra.Checked ? dtpNgayTraThucTe.Value.Date : null;
        }

        private void ClearForm()
        {
            _isEditing = false;
            _editingMa = string.Empty;
            _errorProvider.Clear();
            txtMaPhieu.ReadOnly = false;
            GenerateNewMa();
            txtMaSV.Clear();
            txtHoTen.Clear();
            cbThietBi.SelectedIndex = 0;
            nudSoLuong.Value = 1;
            dtpNgayMuon.Value = DateTime.Today;
            dtpHanTra.Value = DateTime.Today.AddDays(7);
            chkDaTra.Checked = false;
            dtpNgayTraThucTe.Value = DateTime.Today;
            dtpNgayTraThucTe.Enabled = false;
            dgvPhieu.ClearSelection();
        }

        private void GenerateNewMa()
        {
            txtMaPhieu.Text = $"PM{_allRecords.Count + 1:D4}";
        }

        private void UpdateStatus()
        {
            int quaHan = _filtered.Count(r => r.TinhTrang == "Quá hạn");
            lblStatus.Text = $"Tổng phiếu hiển thị: {_filtered.Count} / {_allRecords.Count}   |   Quá hạn: {quaHan}";
        }
    }
}
