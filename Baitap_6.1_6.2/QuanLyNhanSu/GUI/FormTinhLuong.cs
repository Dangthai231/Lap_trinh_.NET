using System.Globalization;

namespace QuanLyNhanSu.GUI
{
    using QuanLyNhanSu.BUS;
    using QuanLyNhanSu.DTO;

    public partial class FormTinhLuong : Form
    {
        private readonly LuongBUS bus = new LuongBUS();
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        public FormTinhLuong()
        {
            InitializeComponent();
        }

        private void FormTinhLuong_Load(object sender, EventArgs e)
        {
            dgvLuong.AutoGenerateColumns = false;
            colLuongCoBan.DefaultCellStyle.FormatProvider = vi;
            colThucLinh.DefaultCellStyle.FormatProvider = vi;
            dtpThang.Value = DateTime.Today;
        }

        private string ThangDangChon()
        {
            return ChamCongBUS.ThangNam(dtpThang.Value);
        }

        // Tính lương theo công thức (chưa ghi vào CSDL)
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            HienBangLuong(ThangDangChon());
        }

        private void HienBangLuong(string thangNam)
        {
            try
            {
                List<BangLuongDTO> ds = bus.TinhLuong(thangNam);
                dgvLuong.DataSource = ds;
                lblTongLuong.Text = "Tổng quỹ lương: " + ds.Sum(x => x.ThucLinh).ToString("N0", vi) + " đ";

                if (ds.Count == 0)
                {
                    lblTrangThai.ForeColor = Color.DarkOrange;
                    lblTrangThai.Text = "Tháng " + thangNam + " chưa có dữ liệu chấm công.";
                }
                else if (bus.DaChotLuong(thangNam))
                {
                    lblTrangThai.ForeColor = Color.Firebrick;
                    lblTrangThai.Text = "Tháng " + thangNam + " ĐÃ CHỐT LƯƠNG.";
                }
                else
                {
                    lblTrangThai.ForeColor = Color.SeaGreen;
                    lblTrangThai.Text = "Tháng " + thangNam + ": " + ds.Count + " nhân viên - chưa chốt lương.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chốt lương: ghi BangLuong cho toàn bộ nhân viên + khóa chấm công, trong 1 SqlTransaction
        private void btnChotLuong_Click(object sender, EventArgs e)
        {
            string thangNam = ThangDangChon();
            if (MessageBox.Show("Chốt lương tháng " + thangNam + "?\n\nSau khi chốt, bảng chấm công của tháng này sẽ bị khóa, không sửa được nữa.",
                    "Xác nhận chốt lương", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                string loi;
                if (bus.ChotLuong(thangNam, out loi))
                {
                    MessageBox.Show("Đã chốt lương tháng " + thangNam + " thành công.\nDữ liệu chấm công tháng này đã được khóa.",
                        "Chốt lương thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(loi, "Chốt lương thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HienBangLuong(thangNam);
        }
    }
}
