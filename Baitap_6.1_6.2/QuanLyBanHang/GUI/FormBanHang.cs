using System.ComponentModel;
using System.Globalization;

namespace QuanLyBanHang.GUI
{
    using QuanLyBanHang.BUS;
    using QuanLyBanHang.DTO;

    public partial class FormBanHang : Form
    {
        private readonly SanPhamBUS sanPhamBUS = new SanPhamBUS();
        private readonly KhachHangBUS khachHangBUS = new KhachHangBUS();
        private readonly NhanVienBUS nhanVienBUS = new NhanVienBUS();
        private readonly HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        // Giỏ hàng hiển thị trên DataGridView
        private readonly BindingList<ChiTietHoaDonDTO> gioHang = new BindingList<ChiTietHoaDonDTO>();

        // Tồn kho hiện tại của từng sản phẩm (để tô đỏ dòng vượt tồn kho)
        private readonly Dictionary<string, int> tonKho = new Dictionary<string, int>();

        public FormBanHang()
        {
            InitializeComponent();
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            dgvGioHang.AutoGenerateColumns = false;
            colDonGia.DefaultCellStyle.FormatProvider = vi;
            colThanhTien.DefaultCellStyle.FormatProvider = vi;
            bsGioHang.DataSource = gioHang;
            dgvGioHang.DataSource = bsGioHang;
            lblNgayLap.Text = "Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            try
            {
                cboNhanVien.DisplayMember = "HienThi";
                cboNhanVien.ValueMember = "MaNV";
                cboNhanVien.DataSource = nhanVienBUS.TimKiem("");
                cboNhanVien.SelectedIndex = -1;          // người bán tự chọn

                NapKhachHang();
                NapSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatTongTien();
        }

        private void NapKhachHang()
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();
            ds.Add(new KhachHangDTO { MaKH = 0, TenKH = "Khách lẻ" });   // MaKH = 0 nghĩa là khách lẻ
            ds.AddRange(khachHangBUS.TimKiem(""));
            cboKhachHang.DisplayMember = "HienThi";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DataSource = ds;
            cboKhachHang.SelectedIndex = 0;
        }

        private void NapSanPham()
        {
            List<SanPhamDTO> ds = sanPhamBUS.TimKiem("");
            tonKho.Clear();
            foreach (SanPhamDTO sp in ds) tonKho[sp.MaSP] = sp.SoLuongTon;

            cboSanPham.DisplayMember = "HienThi";
            cboSanPham.ValueMember = "MaSP";
            cboSanPham.DataSource = ds;
            cboSanPham.SelectedIndex = -1;
            cboSanPham.Text = "";
        }

        // ===================== CHỌN SẢN PHẨM =====================

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPhamDTO sp = cboSanPham.SelectedItem as SanPhamDTO;
            if (sp == null) return;
            lblThongTinSP.Text = sp.TenSP + "   |   Giá: " + sp.GiaBan.ToString("N0", vi) + " đ   |   Tồn kho: " + sp.SoLuongTon;
        }

        // Quét / gõ mã vạch rồi bấm Enter
        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;

            string ma = txtMaVach.Text.Trim();
            if (ma == "") return;
            try
            {
                SanPhamDTO sp = sanPhamBUS.LayTheoMa(ma);
                if (sp == null)
                {
                    errorProvider1.SetError(txtMaVach, "Không có sản phẩm mã \"" + ma + "\".");
                    MessageBox.Show("Không tìm thấy sản phẩm có mã \"" + ma + "\".", "Không tìm thấy",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                errorProvider1.SetError(txtMaVach, "");
                ThemVaoGio(sp, (int)nudSoLuong.Value);
                txtMaVach.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            SanPhamDTO sp = cboSanPham.SelectedItem as SanPhamDTO;
            if (sp == null)
            {
                errorProvider1.SetError(cboSanPham, "Hãy chọn sản phẩm.");
                MessageBox.Show("Hãy chọn 1 sản phẩm trong danh sách, hoặc gõ mã vạch rồi bấm Enter.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            errorProvider1.SetError(cboSanPham, "");
            ThemVaoGio(sp, (int)nudSoLuong.Value);
        }

        // Sản phẩm đã có trong giỏ thì cộng thêm số lượng
        private void ThemVaoGio(SanPhamDTO sp, int soLuong)
        {
            ChiTietHoaDonDTO dong = gioHang.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (dong == null)
                gioHang.Add(new ChiTietHoaDonDTO { MaSP = sp.MaSP, TenSP = sp.TenSP, SoLuong = soLuong, DonGia = sp.GiaBan });
            else
                dong.SoLuong += soLuong;

            tonKho[sp.MaSP] = sp.SoLuongTon;
            bsGioHang.ResetBindings(false);
            nudSoLuong.Value = 1;
            CapNhatTongTien();
        }

        // Dòng nào mua nhiều hơn tồn kho thì tô đỏ để cảnh báo
        private void dgvGioHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gioHang.Count) return;
            ChiTietHoaDonDTO ct = gioHang[e.RowIndex];
            int ton;
            if (tonKho.TryGetValue(ct.MaSP, out ton) && ct.SoLuong > ton)
                e.CellStyle.ForeColor = Color.Red;
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonDTO ct = bsGioHang.Current as ChiTietHoaDonDTO;
            if (ct == null || dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 dòng trong giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            gioHang.Remove(ct);
            CapNhatTongTien();
        }

        private void btnXoaGio_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0) return;
            if (MessageBox.Show("Xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            gioHang.Clear();
            CapNhatTongTien();
        }

        // ===================== TỔNG TIỀN & ĐIỂM =====================

        private int? MaKhachHangDangChon()
        {
            KhachHangDTO kh = cboKhachHang.SelectedItem as KhachHangDTO;
            if (kh == null || kh.MaKH == 0) return null;
            return kh.MaKH;
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal tong = hoaDonBUS.TinhTongTien(gioHang.ToList());
            lblTongTien.Text = tong.ToString("N0", vi) + " đ";

            if (MaKhachHangDangChon() == null)
                lblDiemCong.Text = "Khách lẻ: không tích điểm.";
            else
                lblDiemCong.Text = "Điểm tích lũy sẽ được cộng: " + hoaDonBUS.TinhDiemTichLuy(tong) + " điểm (100.000 đ = 1 điểm)";
        }

        // ===================== THANH TOÁN (SqlTransaction ở tầng DAL) =====================

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (cboNhanVien.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboNhanVien, "Hãy chọn nhân viên bán hàng.");
                MessageBox.Show("Hãy chọn nhân viên bán hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tong = hoaDonBUS.TinhTongTien(gioHang.ToList());
            if (MessageBox.Show("Thanh toán hóa đơn " + tong.ToString("N0", vi) + " đ cho " + cboKhachHang.Text + "?",
                    "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int maNV = (int)cboNhanVien.SelectedValue;
            int? maKH = MaKhachHangDangChon();
            string loi;
            int maHD = hoaDonBUS.ThanhToan(maNV, maKH, gioHang.ToList(), out loi);

            if (maHD < 0)
            {
                MessageBox.Show(loi, "Thanh toán thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string thongBao = "Thanh toán thành công!\n\nMã hóa đơn: " + maHD +
                              "\nTổng tiền: " + tong.ToString("N0", vi) + " đ";
            if (maKH.HasValue) thongBao += "\nĐiểm cộng cho khách: " + hoaDonBUS.TinhDiemTichLuy(tong);
            MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới cho hóa đơn tiếp theo
            gioHang.Clear();
            try
            {
                NapSanPham();       // tồn kho đã thay đổi
                NapKhachHang();     // điểm tích lũy đã thay đổi
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblThongTinSP.Text = "Gõ mã vạch rồi bấm Enter, hoặc chọn sản phẩm trong danh sách.";
            lblNgayLap.Text = "Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            CapNhatTongTien();
        }
    }
}
