using System.Globalization;

namespace QuanLyNhanSu.GUI
{
    using QuanLyNhanSu.BUS;
    using QuanLyNhanSu.DTO;

    public partial class FormBaoCao : Form
    {
        private readonly LuongBUS bus = new LuongBUS();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            dgvBangLuong.AutoGenerateColumns = false;
            colThucLinh.DefaultCellStyle.FormatProvider = vi;

            // Mở sẵn tháng gần nhất đã chốt lương (nếu có)
            try
            {
                string thang = bus.ThangChotGanNhat();
                DateTime d;
                if (thang != "" && DateTime.TryParseExact("01/" + thang, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                    dtpThang.Value = d;
                else
                    dtpThang.Value = DateTime.Today;
                XemBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try { XemBaoCao(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void XemBaoCao()
        {
            string thangNam = ChamCongBUS.ThangNam(dtpThang.Value);

            // ExecuteScalar: tổng quỹ lương
            decimal tong = bus.TongQuyLuong(thangNam);
            List<BangLuongDTO> bangLuong = bus.LayBangLuongDaChot(thangNam);
            dgvBangLuong.DataSource = bangLuong;

            lblTongQuy.Text = "Tổng quỹ lương tháng " + thangNam + ": " + tong.ToString("N0", vi) + " đ";
            lblSoNV.Text = "Số nhân viên nhận lương: " + bangLuong.Count;
            lblLuongTB.Text = "Lương bình quân: " +
                              (bangLuong.Count == 0 ? 0 : tong / bangLuong.Count).ToString("N0", vi) + " đ";
            if (bangLuong.Count == 0)
                lblSoNV.Text += "   (tháng này chưa chốt lương)";

            // SqlDataReader: quỹ lương theo phòng ban
            lsvPhongBan.Items.Clear();
            foreach (QuyLuongPhongBanDTO pb in bus.QuyLuongTheoPhongBan(thangNam))
            {
                ListViewItem item = new ListViewItem(pb.TenPB);
                item.SubItems.Add(pb.SoNhanVien.ToString());
                item.SubItems.Add(pb.TongLuong.ToString("N0", vi));
                lsvPhongBan.Items.Add(item);
            }
        }
    }
}
