using System.Globalization;
using System.Text.RegularExpressions;

namespace QuanLyNhanSu.GUI
{
    using QuanLyNhanSu.BUS;
    using QuanLyNhanSu.DTO;

    public partial class FormNhanVien : Form
    {
        private readonly NhanVienBUS bus = new NhanVienBUS();
        private readonly PhongBanBUS phongBanBUS = new PhongBanBUS();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        private NhanVienDTO nvDangChon = null;     // null = chưa chọn nhân viên nào

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.AutoGenerateColumns = false;
            colLuongCoBan.DefaultCellStyle.FormatProvider = vi;
            dtpNgaySinh.MaxDate = DateTime.Today;
            nudHeSoLuong.Minimum = 0;

            try
            {
                List<PhongBanDTO> dsPB = phongBanBUS.LayDanhSach();

                cboPhongBan.DisplayMember = "TenPB";
                cboPhongBan.ValueMember = "MaPB";
                cboPhongBan.DataSource = new List<PhongBanDTO>(dsPB);

                List<PhongBanDTO> dsLoc = new List<PhongBanDTO>();
                dsLoc.Add(new PhongBanDTO { MaPB = 0, TenPB = "Tất cả phòng ban" });
                dsLoc.AddRange(dsPB);
                cboLoc.DisplayMember = "TenPB";
                cboLoc.ValueMember = "MaPB";
                cboLoc.DataSource = dsLoc;
                cboLoc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamMoiONhap();
            TaiDanhSach();
        }

        private int MaPBDangLoc()
        {
            return cboLoc.SelectedValue is int ? (int)cboLoc.SelectedValue : 0;
        }

        private void TaiDanhSach()
        {
            try
            {
                List<NhanVienDTO> ds = bus.TimKiem(txtTimKiem.Text, MaPBDangLoc());
                dgvNhanVien.DataSource = ds;
                dgvNhanVien.ClearSelection();
                lblTongSo.Text = "Tổng: " + ds.Count + " nhân viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            NhanVienDTO nv = dgvNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVienDTO;
            if (nv == null) return;

            nvDangChon = nv;
            errorProvider1.Clear();
            txtMaNV.Text = nv.MaNV.ToString();
            txtHoTen.Text = nv.HoTen;
            dtpNgaySinh.Value = nv.NgaySinh ?? new DateTime(2000, 1, 1);
            txtCCCD.Text = nv.CCCD;
            cboPhongBan.SelectedValue = nv.MaPB;
            txtLuongCoBan.Text = nv.LuongCoBan.ToString("N0", vi);
            nudHeSoLuong.Value = (decimal)Math.Min(Math.Max(nv.HeSoLuong, 0), 10);
        }

        // ===================== KIỂM TRA DỮ LIỆU =====================
        private NhanVienDTO DocONhap()
        {
            errorProvider1.Clear();
            List<string> loi = new List<string>();
            decimal luong = 0;

            if (txtHoTen.Text.Trim() == "") BaoLoi(txtHoTen, "Họ tên không được để trống.", loi);

            int tuoi = DateTime.Today.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            if (tuoi < 18) BaoLoi(dtpNgaySinh, "Nhân viên phải đủ 18 tuổi.", loi);

            string cccd = txtCCCD.Text.Trim();
            if (cccd == "") BaoLoi(txtCCCD, "Số CCCD không được để trống.", loi);
            else if (!Regex.IsMatch(cccd, @"^\d{12}$")) BaoLoi(txtCCCD, "Số CCCD phải gồm đúng 12 chữ số.", loi);

            if (cboPhongBan.SelectedIndex < 0) BaoLoi(cboPhongBan, "Vui lòng chọn phòng ban.", loi);

            string sLuong = txtLuongCoBan.Text.Trim().Replace(".", "").Replace(",", "").Replace(" ", "");
            if (sLuong == "") BaoLoi(txtLuongCoBan, "Lương cơ bản không được để trống.", loi);
            else if (!decimal.TryParse(sLuong, NumberStyles.Number, CultureInfo.InvariantCulture, out luong))
                BaoLoi(txtLuongCoBan, "Lương cơ bản phải là số.", loi);
            else if (luong <= 0) BaoLoi(txtLuongCoBan, "Lương cơ bản phải lớn hơn 0.", loi);

            if (nudHeSoLuong.Value <= 0) BaoLoi(nudHeSoLuong, "Hệ số lương phải lớn hơn 0.", loi);

            if (loi.Count > 0)
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ:\n\n• " + string.Join("\n• ", loi), "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return new NhanVienDTO
            {
                MaNV = nvDangChon == null ? 0 : nvDangChon.MaNV,
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                CCCD = cccd,
                MaPB = (int)cboPhongBan.SelectedValue,
                LuongCoBan = luong,
                HeSoLuong = (double)nudHeSoLuong.Value
            };
        }

        private void BaoLoi(Control c, string thongBao, List<string> loi)
        {
            errorProvider1.SetError(c, thongBao);
            loi.Add(thongBao);
        }

        // ===================== THÊM / SỬA / XÓA =====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (nvDangChon != null)
            {
                MessageBox.Show("Bạn đang xem 1 nhân viên có sẵn. Bấm \"Làm mới\" trước khi thêm mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NhanVienDTO nv = DocONhap();
            if (nv == null) return;

            string loi = bus.Them(nv);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã thêm nhân viên " + nv.HoTen + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (nvDangChon == null)
            {
                MessageBox.Show("Hãy chọn 1 nhân viên trong bảng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NhanVienDTO nv = DocONhap();
            if (nv == null) return;

            string loi = bus.Sua(nv);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã cập nhật nhân viên " + nv.HoTen + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nvDangChon == null)
            {
                MessageBox.Show("Hãy chọn 1 nhân viên trong bảng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + nvDangChon.HoTen + "?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            string loi = bus.Xoa(nvDangChon.MaNV);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            LamMoiONhap();
            TaiDanhSach();
        }

        // Chuyển phòng ban: chọn nhân viên, chọn phòng mới ở ô "Phòng ban" rồi bấm nút
        private void btnChuyenPhong_Click(object sender, EventArgs e)
        {
            if (nvDangChon == null)
            {
                MessageBox.Show("Hãy chọn 1 nhân viên trong bảng, sau đó chọn phòng ban mới ở ô \"Phòng ban\".",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PhongBanDTO pbMoi = cboPhongBan.SelectedItem as PhongBanDTO;
            if (pbMoi == null || pbMoi.MaPB == nvDangChon.MaPB)
            {
                errorProvider1.SetError(cboPhongBan, "Hãy chọn phòng ban mới khác phòng hiện tại.");
                MessageBox.Show("Hãy chọn phòng ban mới (khác \"" + nvDangChon.TenPB + "\") ở ô \"Phòng ban\".",
                    "Chưa chọn phòng mới", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Chuyển " + nvDangChon.HoTen + " từ \"" + nvDangChon.TenPB + "\" sang \"" + pbMoi.TenPB + "\"?",
                    "Xác nhận chuyển phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string loi = bus.ChuyenPhongBan(nvDangChon.MaNV, pbMoi.MaPB);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã chuyển " + nvDangChon.HoTen + " sang " + pbMoi.TenPB + ".", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLoc.SelectedIndex = 0;
            LamMoiONhap();
            TaiDanhSach();
        }

        private void LamMoiONhap()
        {
            nvDangChon = null;
            errorProvider1.Clear();
            txtMaNV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            txtCCCD.Clear();
            cboPhongBan.SelectedIndex = -1;
            txtLuongCoBan.Clear();
            nudHeSoLuong.Value = 1;
            dgvNhanVien.ClearSelection();
            txtHoTen.Focus();
        }

        // ===================== TÌM KIẾM =====================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; TaiDanhSach(); }
        }

        private void cboLoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TaiDanhSach();
        }
    }
}
