using System.ComponentModel;
using System.Text;
using RepairServiceTracker.Models;

namespace RepairServiceTracker
{
    public partial class MainForm : Form
    {
        private BindingList<RepairOrder> _all = new();
        private BindingList<RepairOrder> _filtered = new();
        private BindingSource _bs = new();
        private ErrorProvider _ep = new();
        private bool _isEditing;
        private string _editingMa = string.Empty;

        private readonly string[] _loaiThietBi = { "Điện thoại", "Laptop", "Máy tính bàn", "Máy tính bảng", "Máy in", "Tivi", "Tủ lạnh", "Máy giặt", "Điều hòa", "Khác" };
        private readonly string[] _trangThaiList = { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" };

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            cbLoaiThietBi.Items.AddRange(_loaiThietBi);
            cbLoaiThietBi.SelectedIndex = 0;
            cbTrangThai.Items.AddRange(_trangThaiList);
            cbTrangThai.SelectedIndex = 0;
            cbLocTrangThai.Items.Add("-- Tất cả --");
            cbLocTrangThai.Items.AddRange(_trangThaiList);
            cbLocTrangThai.SelectedIndex = 0;

            dtpNgayTiepNhan.Value = DateTime.Today;
            dtpNgayTiepNhan.Format = DateTimePickerFormat.Custom;
            dtpNgayTiepNhan.CustomFormat = "dd/MM/yyyy";

            picThietBi.SizeMode = PictureBoxSizeMode.Zoom;
            picThietBi.BorderStyle = BorderStyle.FixedSingle;
            picThietBi.BackColor = Color.FromArgb(240, 240, 240);

            SetupGrid();
            _bs.DataSource = _filtered;
            dgvDon.DataSource = _bs;

            GenerateNewMa();

            txtTimKiem.TextChanged += (s, e) => ApplyFilter();
            cbLocTrangThai.SelectedIndexChanged += (s, e) => ApplyFilter();
            dgvDon.SelectionChanged += DgvDon_SelectionChanged!;

            UpdateStatus();
        }

        private void SetupGrid()
        {
            dgvDon.AutoGenerateColumns = false;
            dgvDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDon.MultiSelect = false;
            dgvDon.ReadOnly = true;
            dgvDon.AllowUserToAddRows = false;
            dgvDon.AllowUserToDeleteRows = false;
            dgvDon.RowHeadersVisible = false;
            dgvDon.BackgroundColor = SystemColors.Window;
            dgvDon.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            var cols = new DataGridViewTextBoxColumn[]
            {
                new() { Name="MaDon",         DataPropertyName="MaDon",          HeaderText="Mã đơn",       Width=90  },
                new() { Name="TenKhachHang",  DataPropertyName="TenKhachHang",   HeaderText="Khách hàng",   Width=140 },
                new() { Name="SoDienThoai",   DataPropertyName="SoDienThoai",    HeaderText="Số ĐT",        Width=110 },
                new() { Name="LoaiThietBi",   DataPropertyName="LoaiThietBi",    HeaderText="Loại TB",      Width=110 },
                new() { Name="MoTaLoi",       DataPropertyName="MoTaLoi",        HeaderText="Mô tả lỗi",   Width=150 },
                new() { Name="NgayTiepNhan",  DataPropertyName="NgayTiepNhan",   HeaderText="Ngày tiếp nhận", Width=115 },
                new() { Name="ChiPhiDuKien",  DataPropertyName="ChiPhiDisplay",  HeaderText="Chi phí DK",   Width=100 },
                new() { Name="TrangThai",     DataPropertyName="TrangThai",      HeaderText="Trạng thái",   Width=110 },
            };
            cols[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            cols[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (var c in cols) { c.ReadOnly = true; dgvDon.Columns.Add(c); }
        }

        // ========== Validation ==========
        private bool ValidateInputs()
        {
            _ep.Clear();
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtMaDon.Text))
            { _ep.SetError(txtMaDon, "Mã đơn không được trống."); ok = false; }
            else if (!_isEditing && _all.Any(r => r.MaDon == txtMaDon.Text.Trim()))
            { _ep.SetError(txtMaDon, "Mã đơn đã tồn tại."); ok = false; }

            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            { _ep.SetError(txtTenKH, "Tên khách hàng không được trống."); ok = false; }

            if (string.IsNullOrWhiteSpace(txtSoDT.Text))
            { _ep.SetError(txtSoDT, "Số điện thoại không được trống."); ok = false; }

            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            { _ep.SetError(txtMoTa, "Mô tả lỗi bắt buộc nhập."); ok = false; }

            if (!decimal.TryParse(txtChiPhi.Text.Replace(",", "").Replace(".", ""), out decimal cp) || cp < 0)
            { _ep.SetError(txtChiPhi, "Chi phí phải là số không âm."); ok = false; }

            return ok;
        }

        // ========== CRUD ==========
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            _all.Add(BuildFromForm());
            ApplyFilter();
            ClearForm();
            UpdateStatus();
            MessageBox.Show("Thêm đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (!_isEditing) { MessageBox.Show("Chọn một đơn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidateInputs()) return;
            var r = _all.First(x => x.MaDon == _editingMa);
            FillFromForm(r);
            ApplyFilter();
            ClearForm();
            UpdateStatus();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDon.SelectedRows.Count == 0) { MessageBox.Show("Chọn một đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            var ma = dgvDon.SelectedRows[0].Cells["MaDon"].Value?.ToString();
            var ten = dgvDon.SelectedRows[0].Cells["TenKhachHang"].Value?.ToString();
            if (MessageBox.Show($"Xóa đơn sửa chữa của '{ten}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var r = _all.FirstOrDefault(x => x.MaDon == ma);
            if (r != null) { _all.Remove(r); ApplyFilter(); ClearForm(); UpdateStatus(); }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        // ========== Chọn ảnh ==========
        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Chọn ảnh thiết bị",
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp",
                Multiselect = false
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            picThietBi.ImageLocation = dlg.FileName;
            picThietBi.Tag = dlg.FileName;
        }

        // ========== Selection ==========
        private void DgvDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDon.SelectedRows.Count == 0) return;
            var ma = dgvDon.SelectedRows[0].Cells["MaDon"].Value?.ToString();
            var r = _all.FirstOrDefault(x => x.MaDon == ma);
            if (r == null) return;

            _isEditing = true;
            _editingMa = r.MaDon;
            txtMaDon.Text = r.MaDon;
            txtMaDon.ReadOnly = true;
            txtTenKH.Text = r.TenKhachHang;
            txtSoDT.Text = r.SoDienThoai;
            cbLoaiThietBi.Text = r.LoaiThietBi;
            txtMoTa.Text = r.MoTaLoi;
            dtpNgayTiepNhan.Value = r.NgayTiepNhan;
            txtChiPhi.Text = r.ChiPhiDuKien.ToString("N0");
            cbTrangThai.Text = r.TrangThai;

            if (!string.IsNullOrEmpty(r.AnhThietBiPath) && File.Exists(r.AnhThietBiPath))
            {
                picThietBi.ImageLocation = r.AnhThietBiPath;
                picThietBi.Tag = r.AnhThietBiPath;
            }
            else
            {
                picThietBi.Image = null;
                picThietBi.Tag = null;
            }
            _ep.Clear();
        }

        // ========== Filter ==========
        private void ApplyFilter()
        {
            var kw = txtTimKiem.Text.Trim().ToLower();
            var loc = cbLocTrangThai.SelectedIndex == 0 ? null : cbLocTrangThai.SelectedItem?.ToString();
            var q = _all.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(kw))
                q = q.Where(r => r.MaDon.ToLower().Contains(kw) || r.TenKhachHang.ToLower().Contains(kw) || r.SoDienThoai.Contains(kw));
            if (loc != null)
                q = q.Where(r => r.TrangThai == loc);
            _filtered.Clear();
            foreach (var r in q) _filtered.Add(r);
            _bs.ResetBindings(false);
            UpdateStatus();
        }

        // ========== Xuất CSV ==========
        private void MenuXuatCSV_Click(object sender, EventArgs e)
        {
            if (_filtered.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            using var dlg = new SaveFileDialog { Filter = "CSV|*.csv", FileName = $"DonSuaChua_{DateTime.Now:yyyyMMdd_HHmm}.csv" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            var sb = new StringBuilder();
            sb.AppendLine("Mã đơn,Khách hàng,Số ĐT,Loại TB,Mô tả lỗi,Ngày tiếp nhận,Chi phí DK,Trạng thái");
            foreach (var r in _filtered)
                sb.AppendLine($"{r.MaDon},{r.TenKhachHang},{r.SoDienThoai},{r.LoaiThietBi},{r.MoTaLoi},{r.NgayTiepNhan:dd/MM/yyyy},{r.ChiPhiDuKien:N0},{r.TrangThai}");
            File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show($"Xuất {_filtered.Count} đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        // ========== Helpers ==========
        private RepairOrder BuildFromForm()
        {
            var r = new RepairOrder { MaDon = txtMaDon.Text.Trim() };
            FillFromForm(r);
            return r;
        }

        private void FillFromForm(RepairOrder r)
        {
            r.TenKhachHang = txtTenKH.Text.Trim();
            r.SoDienThoai = txtSoDT.Text.Trim();
            r.LoaiThietBi = cbLoaiThietBi.Text.Trim();
            r.MoTaLoi = txtMoTa.Text.Trim();
            r.NgayTiepNhan = dtpNgayTiepNhan.Value.Date;
            decimal.TryParse(txtChiPhi.Text.Replace(",", "").Replace(".", ""), out decimal cp);
            r.ChiPhiDuKien = cp;
            r.TrangThai = cbTrangThai.Text;
            r.AnhThietBiPath = picThietBi.Tag?.ToString();
        }

        private void ClearForm()
        {
            _isEditing = false;
            _editingMa = string.Empty;
            _ep.Clear();
            txtMaDon.ReadOnly = false;
            GenerateNewMa();
            txtTenKH.Clear();
            txtSoDT.Clear();
            cbLoaiThietBi.SelectedIndex = 0;
            txtMoTa.Clear();
            dtpNgayTiepNhan.Value = DateTime.Today;
            txtChiPhi.Text = "0";
            cbTrangThai.SelectedIndex = 0;
            picThietBi.Image = null;
            picThietBi.Tag = null;
            dgvDon.ClearSelection();
        }

        private void GenerateNewMa() => txtMaDon.Text = $"SC{_all.Count + 1:D4}";

        private void UpdateStatus()
        {
            var chuaHoanTat = _filtered.Where(r => r.TrangThai != "Hoàn tất" && r.TrangThai != "Đã hủy");
            decimal tongChi = chuaHoanTat.Sum(r => r.ChiPhiDuKien);
            lblStatus.Text = $"Hiển thị: {_filtered.Count} / {_all.Count} đơn   |   Tổng chi phí DK (chưa hoàn tất): {tongChi:N0} ₫";
        }
    }
}
