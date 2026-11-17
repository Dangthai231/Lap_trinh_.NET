using System.Globalization;

namespace QuanLyBanHang.GUI
{
    using QuanLyBanHang.BUS;
    using QuanLyBanHang.DTO;

    public partial class FormThongKe : Form
    {
        private readonly ThongKeBUS bus = new ThongKeBUS();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");
        private bool daTai = false;   // tránh truy vấn 2 lần lúc mở form

        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            dtpNgay.Value = DateTime.Today;
            dtpThang.Value = DateTime.Today;
            TaiTatCa();
            daTai = true;
        }

        private void TaiTatCa()
        {
            try
            {
                TaiDoanhThuNgay();
                TaiDoanhThuThang();
                TaiTop5();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDoanhThuNgay()
        {
            DateTime ngay = dtpNgay.Value.Date;
            decimal tien = bus.DoanhThuNgay(ngay);
            int soHD = bus.SoHoaDonNgay(ngay);
            lblDoanhThuNgay.Text = "Doanh thu ngày " + ngay.ToString("dd/MM/yyyy") + ": " +
                                   tien.ToString("N0", vi) + " đ  (" + soHD + " hóa đơn)";
        }

        private void TaiDoanhThuThang()
        {
            int thang = dtpThang.Value.Month, nam = dtpThang.Value.Year;
            decimal tien = bus.DoanhThuThang(thang, nam);
            int soHD = bus.SoHoaDonThang(thang, nam);
            lblDoanhThuThang.Text = "Doanh thu tháng " + thang.ToString("00") + "/" + nam + ": " +
                                    tien.ToString("N0", vi) + " đ  (" + soHD + " hóa đơn)";
        }

        private void TaiTop5()
        {
            lsvTop5.Items.Clear();
            foreach (TopSanPhamDTO sp in bus.Top5BanChay())
            {
                ListViewItem item = new ListViewItem(sp.Hang.ToString());
                item.SubItems.Add(sp.MaSP);
                item.SubItems.Add(sp.TenSP);
                item.SubItems.Add(sp.SoLuongBan.ToString());
                item.SubItems.Add(sp.DoanhThu.ToString("N0", vi));
                if (sp.Hang == 1) item.Font = new Font(lsvTop5.Font, FontStyle.Bold);
                lsvTop5.Items.Add(item);
            }
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            if (!daTai) return;
            try { TaiDoanhThuNgay(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dtpThang_ValueChanged(object sender, EventArgs e)
        {
            if (!daTai) return;
            try { TaiDoanhThuThang(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiTatCa();
        }
    }
}
