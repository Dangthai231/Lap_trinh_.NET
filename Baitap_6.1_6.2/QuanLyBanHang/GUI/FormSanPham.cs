using System.Globalization;

namespace QuanLyBanHang.GUI
{
    using QuanLyBanHang.BUS;
    using QuanLyBanHang.DTO;

    public partial class FormSanPham : Form
    {
        private readonly SanPhamBUS bus = new SanPhamBUS();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.AutoGenerateColumns = false;
            colGiaBan.DefaultCellStyle.FormatProvider = vi;
            LamMoiONhap();
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            try
            {
                List<SanPhamDTO> ds = bus.TimKiem(txtTimKiem.Text);
                dgvSanPham.DataSource = ds;
                dgvSanPham.ClearSelection();
                lblTongSo.Text = "Tổng: " + ds.Count + " sản phẩm";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            SanPhamDTO sp = dgvSanPham.Rows[e.RowIndex].DataBoundItem as SanPhamDTO;
            if (sp == null) return;

            errorProvider1.Clear();
            txtMaSP.Text = sp.MaSP;
            txtMaSP.ReadOnly = true;              // không sửa khóa chính
            txtTenSP.Text = sp.TenSP;
            txtGiaBan.Text = sp.GiaBan.ToString("N0", vi);
            nudSoLuongTon.Value = Math.Min(sp.SoLuongTon, nudSoLuongTon.Maximum);
        }

        // Kiểm tra dữ liệu nhập, trả về null nếu sai
        private SanPhamDTO DocONhap()
        {
            errorProvider1.Clear();
            List<string> loi = new List<string>();
            decimal gia = 0;

            if (txtMaSP.Text.Trim() == "") BaoLoi(txtMaSP, "Mã sản phẩm không được để trống.", loi);
            if (txtTenSP.Text.Trim() == "") BaoLoi(txtTenSP, "Tên sản phẩm không được để trống.", loi);

            string sGia = txtGiaBan.Text.Trim().Replace(".", "").Replace(",", "").Replace(" ", "");
            if (sGia == "") BaoLoi(txtGiaBan, "Giá bán không được để trống.", loi);
            else if (!decimal.TryParse(sGia, NumberStyles.Number, CultureInfo.InvariantCulture, out gia))
                BaoLoi(txtGiaBan, "Giá bán phải là số.", loi);
            else if (gia <= 0) BaoLoi(txtGiaBan, "Giá bán phải lớn hơn 0.", loi);

            if (loi.Count > 0)
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ:\n\n• " + string.Join("\n• ", loi), "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return new SanPhamDTO
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                GiaBan = gia,
                SoLuongTon = (int)nudSoLuongTon.Value
            };
        }

        private void BaoLoi(Control c, string thongBao, List<string> loi)
        {
            errorProvider1.SetError(c, thongBao);
            loi.Add(thongBao);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP.ReadOnly)
            {
                MessageBox.Show("Bạn đang xem 1 sản phẩm có sẵn. Bấm \"Làm mới\" trước khi thêm sản phẩm mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SanPhamDTO sp = DocONhap();
            if (sp == null) return;

            string loi = bus.Them(sp);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã thêm sản phẩm " + sp.TenSP + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!txtMaSP.ReadOnly)
            {
                MessageBox.Show("Hãy chọn 1 sản phẩm trong bảng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SanPhamDTO sp = DocONhap();
            if (sp == null) return;

            string loi = bus.Sua(sp);
            if (loi != "") { MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đã cập nhật sản phẩm " + sp.MaSP + ".", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiONhap();
            TaiDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!txtMaSP.ReadOnly)
            {
                MessageBox.Show("Hãy chọn 1 sản phẩm trong bảng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + txtMaSP.Text + " - " + txtTenSP.Text + "?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            string loi = bus.Xoa(txtMaSP.Text.Trim());
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
            txtMaSP.ReadOnly = false;
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            nudSoLuongTon.Value = 0;
            dgvSanPham.ClearSelection();
            txtMaSP.Focus();
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
