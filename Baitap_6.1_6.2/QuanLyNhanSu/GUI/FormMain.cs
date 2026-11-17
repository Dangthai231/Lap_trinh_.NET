using System.Globalization;

namespace QuanLyNhanSu.GUI
{
    using QuanLyNhanSu.BUS;
    using QuanLyNhanSu.DAL;

    public partial class FormMain : Form
    {
        private readonly NhanVienBUS nhanVienBUS = new NhanVienBUS();
        private readonly PhongBanBUS phongBanBUS = new PhongBanBUS();
        private readonly LuongBUS luongBUS = new LuongBUS();
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
                lblKetNoi.Text = "Đã kết nối CSDL HRMDB trên server: " + DataProvider.TenServer;
            }
            catch (Exception ex)
            {
                lblKetNoi.Text = "Chưa kết nối được CSDL";
                MessageBox.Show(ex.Message, "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CapNhatSoLieu();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            CapNhatSoLieu();
        }

        private void CapNhatSoLieu()
        {
            if (!daKetNoi) return;
            try
            {
                lblSoNV.Text = nhanVienBUS.DemNhanVien().ToString();
                lblSoPB.Text = phongBanBUS.LayDanhSach().Count.ToString();
                string thang = luongBUS.ThangChotGanNhat();
                lblThangChot.Text = thang == "" ? "Chưa có" : thang;
                lblQuyLuong.Text = thang == "" ? "0 đ" : luongBUS.TongQuyLuong(thang).ToString("N0", vi) + " đ";
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

        private void btnNhanVien_Click(object sender, EventArgs e) { MoForm(new FormNhanVien()); }
        private void btnChamCong_Click(object sender, EventArgs e) { MoForm(new FormChamCong()); }
        private void btnTinhLuong_Click(object sender, EventArgs e) { MoForm(new FormTinhLuong()); }
        private void btnBaoCao_Click(object sender, EventArgs e) { MoForm(new FormBaoCao()); }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
