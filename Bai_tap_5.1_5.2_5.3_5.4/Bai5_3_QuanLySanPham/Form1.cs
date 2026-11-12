using System.Globalization;
using System.Text.RegularExpressions;

namespace Bai5_3
{
    public partial class Form1 : Form
    {
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        // Danh sách gốc chứa TẤT CẢ sản phẩm (dữ liệu trong bộ nhớ)
        private readonly List<Product> dsSanPham = new List<Product>();

        // Danh sách đang hiển thị trên DataGridView (toàn bộ hoặc kết quả tìm kiếm)
        private readonly List<Product> dsHienThi = new List<Product>();

        // Sản phẩm đang được chọn trên bảng (null = chưa chọn)
        private Product spDangChon = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvProducts.AutoGenerateColumns = false;
            colUnitPrice.DefaultCellStyle.FormatProvider = vi;   // 1.500.000
            bsProducts.DataSource = dsHienThi;                   // List<Product> -> BindingSource
            dgvProducts.DataSource = bsProducts;                 // BindingSource -> DataGridView
            LamMoiONhap();
            HienThi();
        }

        // Làm mới DataGridView theo từ khóa tìm kiếm hiện tại
        private void HienThi()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            dgvProducts.CurrentCell = null;
            dsHienThi.Clear();
            foreach (Product sp in dsSanPham)
            {
                if (tuKhoa == "" || sp.ProductName.ToLower().Contains(tuKhoa))
                    dsHienThi.Add(sp);
            }
            bsProducts.ResetBindings(false);
            dgvProducts.ClearSelection();

            lblTongSo.Text = "Đang hiển thị: " + dsHienThi.Count + " / " + dsSanPham.Count + " sản phẩm";
        }

        // ===================== CLICK DÒNG -> ĐẨY LÊN Ô NHẬP =====================
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Product sp = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (sp == null) return;

            spDangChon = sp;
            errorProvider1.Clear();
            txtMaSP.Text = sp.ProductId;
            txtTenSP.Text = sp.ProductName;
            txtDonGia.Text = sp.UnitPrice.ToString("N0", vi);
            nudSoLuong.Value = sp.Quantity;
            cboDanhMuc.SelectedItem = sp.Category;
        }

        // ===================== KIỂM TRA & ĐỌC Ô NHẬP =====================
        private Product DocONhap(Product dangSua)
        {
            errorProvider1.Clear();
            List<string> loi = new List<string>();

            string ma = txtMaSP.Text.Trim();
            string ten = txtTenSP.Text.Trim();
            decimal gia = 0;

            if (ma == "")
                BaoLoi(txtMaSP, "Mã SP không được để trống.", loi);
            else if (dsSanPham.Any(x => x != dangSua && string.Equals(x.ProductId, ma, StringComparison.OrdinalIgnoreCase)))
                BaoLoi(txtMaSP, "Mã SP \"" + ma + "\" đã tồn tại.", loi);

            if (ten == "")
                BaoLoi(txtTenSP, "Tên SP không được để trống.", loi);

            string sGia = txtDonGia.Text.Trim().Replace(" ", "").Replace("đ", "");
            if (sGia == "")
                BaoLoi(txtDonGia, "Đơn giá không được để trống.", loi);
            else if (!DocSo(sGia, out gia))
                BaoLoi(txtDonGia, "Đơn giá phải là số.", loi);
            else if (gia <= 0)
                BaoLoi(txtDonGia, "Đơn giá phải lớn hơn 0.", loi);

            if (cboDanhMuc.SelectedIndex < 0)
                BaoLoi(cboDanhMuc, "Vui lòng chọn danh mục.", loi);

            if (loi.Count > 0)
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ:\n\n• " + string.Join("\n• ", loi), "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Product
            {
                ProductId = ma,
                ProductName = ten,
                UnitPrice = gia,
                Quantity = (int)nudSoLuong.Value,
                Category = cboDanhMuc.Text
            };
        }

        private void BaoLoi(Control c, string thongBao, List<string> loi)
        {
            errorProvider1.SetError(c, thongBao);
            loi.Add(thongBao);
        }

        // Chấp nhận 1500000 hoặc 1.500.000 hoặc 1,500,000
        private static bool DocSo(string s, out decimal ketQua)
        {
            ketQua = 0;
            if (Regex.IsMatch(s, @"^\d{1,3}([.,]\d{3})+$")) s = s.Replace(".", "").Replace(",", "");
            return decimal.TryParse(s.Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out ketQua);
        }

        // ===================== THÊM =====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            Product moi = DocONhap(null);
            if (moi == null) return;

            dsSanPham.Add(moi);
            HienThi();
            LamMoiONhap();
            MessageBox.Show("Đã thêm sản phẩm " + moi.ProductId + " - " + moi.ProductName + ".", "Thêm thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===================== SỬA =====================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (spDangChon == null)
            {
                MessageBox.Show("Hãy click chọn 1 sản phẩm trong bảng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Product moi = DocONhap(spDangChon);
            if (moi == null) return;

            spDangChon.ProductId = moi.ProductId;
            spDangChon.ProductName = moi.ProductName;
            spDangChon.UnitPrice = moi.UnitPrice;
            spDangChon.Quantity = moi.Quantity;
            spDangChon.Category = moi.Category;

            string ma = spDangChon.ProductId;
            HienThi();
            LamMoiONhap();
            MessageBox.Show("Đã cập nhật sản phẩm " + ma + ".", "Sửa thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===================== XÓA =====================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (spDangChon == null)
            {
                MessageBox.Show("Hãy click chọn 1 sản phẩm trong bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + spDangChon.ProductId + " - " + spDangChon.ProductName + "?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            dsSanPham.Remove(spDangChon);
            HienThi();
            LamMoiONhap();
        }

        // ===================== TÌM KIẾM =====================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThi();
            if (txtTimKiem.Text.Trim() != "" && dsHienThi.Count == 0)
                MessageBox.Show("Không tìm thấy sản phẩm nào có tên chứa \"" + txtTimKiem.Text.Trim() + "\".", "Tìm kiếm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiem_Click(sender, e);
            }
        }

        // ===================== LÀM MỚI =====================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            HienThi();
            LamMoiONhap();
        }

        private void LamMoiONhap()
        {
            spDangChon = null;
            errorProvider1.Clear();
            dgvProducts.ClearSelection();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            nudSoLuong.Value = 0;
            cboDanhMuc.SelectedIndex = -1;
            txtMaSP.Focus();
        }
    }
}
