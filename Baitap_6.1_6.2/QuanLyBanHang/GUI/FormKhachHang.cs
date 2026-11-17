using System.Text.RegularExpressions;

namespace QuanLyBanHang.GUI
{
    using QuanLyBanHang.BUS;
    using QuanLyBanHang.DTO;

    public partial class FormKhachHang : Form
    {
        private readonly KhachHangBUS bus = new KhachHangBUS();
        private int maDangChon = 0;      // 0 = chưa chọn khách hàng nào

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            LamMoiONhap();
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            try
            {
                List<KhachHangDTO> ds = bus.TimKiem(txtTimKiem.Text);
                dgvKhachHang.DataSource = ds;
                dgvKhachHang.ClearSelection();
                lblTongSo.Text = "Tổng: " + ds.Count + " khách hàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            KhachHangDTO kh = dgvKhachHang.Rows[e.RowIndex].DataBoundItem as KhachHangDTO;
            if (kh == null) return;

            errorProvider1.Clear();
            maDangChon = kh.MaKH;
            txtMaKH.Text = kh.MaKH.ToString();
            txtTenKH.Text = kh.TenKH;
            txtDienThoai.Text = kh.DienThoai;
            txtDiemTichLuy.Text = kh.DiemTichLuy.ToString();
        }

        private KhachHangDTO DocONhap()
        {
            errorProvider1.Clear();
            List<string> loi = new List<string>();
            string ten = txtTenKH.Text.Trim();
            string sdt = txtDienThoai.Text.Trim();

            if (ten == "") BaoLoi(txtTenKH, "Tên khách hàng không được để trống.", loi);
            if (sdt == "") BaoLoi(txtDienThoai, "Số điện thoại không được để trống.", loi);
            else if (!Regex.IsMatch(sdt, @"^0\d{9}$")) BaoLoi(txtDienThoai, "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng 0.", loi);

            if (loi.Count > 0)
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ:\n\n• " + string.Join("\n• ", loi), "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return new KhachHangDTO { MaKH = maDangChon, TenKH = ten, DienThoai = sdt };
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
                MessageBox.Show("Bạn đang xem 1 khách hàng có sẵn. Bấm \"Làm mới\" trước khi thêm mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            KhachHangDTO kh = DocONhap();
            if (kh == null) return;

            string loi = bus.Them(kh);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã thêm khách hàng " + kh.TenKH + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Hãy chọn 1 khách hàng trong bảng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            KhachHangDTO kh = DocONhap();
            if (kh == null) return;

            string loi = bus.Sua(kh);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã cập nhật khách hàng " + kh.TenKH + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDangChon == 0)
            {
                MessageBox.Show("Hãy chọn 1 khách hàng trong bảng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng " + txtTenKH.Text + "?", "Xác nhận xóa",
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
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDienThoai.Clear();
            txtDiemTichLuy.Clear();
            dgvKhachHang.ClearSelection();
            txtTenKH.Focus();
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
