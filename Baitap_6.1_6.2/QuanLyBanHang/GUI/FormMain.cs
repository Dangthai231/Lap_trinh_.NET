using System.Globalization;

namespace QuanLyBanHang.GUI
{
    using QuanLyBanHang.BUS;
    using QuanLyBanHang.DAL;

    public partial class FormMain : Form
    {
        private readonly ThongKeBUS thongKeBUS = new ThongKeBUS();
        private readonly SanPhamBUS sanPhamBUS = new SanPhamBUS();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");
        private bool daKetNoi = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                string chuoi = DataProvider.ChuoiKetNoi;     // thử kết nối ngay khi mở
                daKetNoi = true;
                lblKetNoi.Text = "Đã kết nối CSDL SalesDB trên server: " + DataProvider.TenServer;
            }
            catch (Exception ex)
            {
                lblKetNoi.Text = "Chưa kết nối được CSDL";
                MessageBox.Show(ex.Message, "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatSoLieu();
        }

        // Mỗi lần quay lại màn hình chính thì cập nhật số liệu
        private void FormMain_Activated(object sender, EventArgs e)
        {
            CapNhatSoLieu();
        }

        private void CapNhatSoLieu()
        {
            if (!daKetNoi) return;
            try
            {
                lblDoanhThu.Text = thongKeBUS.DoanhThuNgay(DateTime.Today).ToString("N0", vi) + " đ";
                lblHoaDon.Text = thongKeBUS.SoHoaDonNgay(DateTime.Today).ToString();
                lblSanPham.Text = sanPhamBUS.TimKiem("").Count.ToString();
                lblSapHet.Text = sanPhamBUS.DemSapHetHang().ToString();
            }
            catch (Exception ex)
            {
                lblKetNoi.Text = "Lỗi đọc dữ liệu: " + ex.Message;
            }
        }

        private void MoForm(Form f)
        {
            if (!daKetNoi)
            {
                MessageBox.Show("Chưa kết nối được CSDL. Hãy chạy file Database\\ScriptDB.sql rồi mở lại chương trình.",
                    "Chưa có CSDL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (f)
            {
                f.ShowDialog(this);
            }
        }

        private void btnBanHang_Click(object sender, EventArgs e) { MoForm(new FormBanHang()); }
        private void btnSanPham_Click(object sender, EventArgs e) { MoForm(new FormSanPham()); }
        private void btnKhachHang_Click(object sender, EventArgs e) { MoForm(new FormKhachHang()); }
        private void btnNhanVien_Click(object sender, EventArgs e) { MoForm(new FormNhanVien()); }
        private void btnThongKe_Click(object sender, EventArgs e) { MoForm(new FormThongKe()); }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
