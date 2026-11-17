using System.Text.RegularExpressions;

namespace QuanLyBanHang.GUI
{
    using QuanLyBanHang.BUS;
    using QuanLyBanHang.DTO;

    public partial class FormNhanVien : Form
    {
        private readonly NhanVienBUS bus = new NhanVienBUS();
        private int maDangChon = 0;      // 0 = chưa chọn nhân viên nào

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.AutoGenerateColumns = false;
            LamMoiONhap();
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            try
            {
                List<NhanVienDTO> ds = bus.TimKiem(txtTimKiem.Text);
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

            errorProvider1.Clear();
            maDangChon = nv.MaNV;
            txtMaNV.Text = nv.MaNV.ToString();
            txtTenNV.Text = nv.TenNV;
            txtSoDienThoai.Text = nv.SoDienThoai;
            cboChucVu.SelectedItem = nv.ChucVu;
        }

        private NhanVienDTO DocONhap()
        {
            errorProvider1.Clear();
            List<string> loi = new List<string>();
            string ten = txtTenNV.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();

            if (ten == "") BaoLoi(txtTenNV, "Tên nhân viên không được để trống.", loi);
            if (sdt == "") BaoLoi(txtSoDienThoai, "Số điện thoại không được để trống.", loi);
            else if (!Regex.IsMatch(sdt, @"^0\d{9}$")) BaoLoi(txtSoDienThoai, "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng 0.", loi);

            if (cboChucVu.SelectedIndex < 0) BaoLoi(cboChucVu, "Vui lòng chọn chức vụ.", loi);

            if (loi.Count > 0)
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ:\n\n• " + string.Join("\n• ", loi), "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return new NhanVienDTO { MaNV = maDangChon, TenNV = ten, SoDienThoai = sdt, ChucVu = cboChucVu.Text };
        }

        private void BaoLoi(Control c, string thongBao, List<string> loi)
        {
            errorProvider1.SetError(c, thongBao);
            loi.Add(thongBao);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (maDangChon != 0)
            {
                MessageBox.Show("Bạn đang xem 1 nhân viên có sẵn. Bấm \"Làm mới\" trước khi thêm mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NhanVienDTO nv = DocONhap();
            if (nv == null) return;

            string loi = bus.Them(nv);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã thêm nhân viên " + nv.TenNV + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Hãy chọn 1 nhân viên trong bảng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NhanVienDTO nv = DocONhap();
            if (nv == null) return;

            string loi = bus.Sua(nv);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã cập nhật nhân viên " + nv.TenNV + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Hãy chọn 1 nhân viên trong bảng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + txtTenNV.Text + "?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            string loi = bus.Xoa(maDangChon);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LamMoiONhap();
            TaiDanhSach();
        }

        private void LamMoiONhap()
        {
            errorProvider1.Clear();
            maDangChon = 0;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSoDienThoai.Clear();
            cboChucVu.SelectedIndex = -1;
            dgvNhanVien.ClearSelection();
            txtTenNV.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; TaiDanhSach(); }
        }
    }
}
