using System.Globalization;

namespace Bai5_2
{
    public partial class Form1 : Form
    {
        private readonly CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");

        // Bảng giá dịch vụ của phòng khám, chia theo loại
        private readonly List<DichVu> bangGia = new List<DichVu>
        {
            new DichVu("Khám bệnh", "Khám nội tổng quát", 150000),
            new DichVu("Khám bệnh", "Khám nhi", 120000),
            new DichVu("Khám bệnh", "Khám tai mũi họng", 130000),
            new DichVu("Khám bệnh", "Khám răng hàm mặt", 100000),
            new DichVu("Khám bệnh", "Khám da liễu", 140000),

            new DichVu("Xét nghiệm", "Công thức máu", 90000),
            new DichVu("Xét nghiệm", "Đường huyết", 40000),
            new DichVu("Xét nghiệm", "Mỡ máu", 120000),
            new DichVu("Xét nghiệm", "Chức năng gan", 150000),
            new DichVu("Xét nghiệm", "Tổng phân tích nước tiểu", 60000),

            new DichVu("Chụp X-Quang", "X-Quang ngực thẳng", 120000),
            new DichVu("Chụp X-Quang", "X-Quang cột sống", 180000),
            new DichVu("Chụp X-Quang", "X-Quang khớp gối", 150000),
            new DichVu("Chụp X-Quang", "X-Quang răng toàn cảnh", 200000),

            new DichVu("Vắc-xin", "Vắc-xin cúm", 350000),
            new DichVu("Vắc-xin", "Vắc-xin viêm gan B", 220000),
            new DichVu("Vắc-xin", "Vắc-xin uốn ván", 120000),
            new DichVu("Vắc-xin", "Vắc-xin dại", 300000),
            new DichVu("Vắc-xin", "Vắc-xin HPV", 1790000)
        };

        // Mã giảm giá -> % chiết khấu
        private readonly Dictionary<string, int> maGiamGia = new Dictionary<string, int>
        {
            { "SV10", 10 },
            { "GIAM15", 15 },
            { "VIP20", 20 }
        };

        public Form1()
        {
            InitializeComponent();
        }

        // ===================== 1. ĐỔI LOẠI DỊCH VỤ =====================
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            NapDichVuHienCo();
        }

        // Nạp các dịch vụ thuộc loại đang chọn (bỏ qua những dịch vụ đã chọn rồi)
        private void NapDichVuHienCo()
        {
            lstAvailableServices.Items.Clear();
            if (cboCategory.SelectedIndex < 0) return;

            string loai = cboCategory.Text;
            foreach (DichVu dv in bangGia)
            {
                if (dv.LoaiDichVu == loai && !lstSelectedServices.Items.Contains(dv))
                    lstAvailableServices.Items.Add(dv);
            }
        }

        // ===================== 2. CHUYỂN DỊCH VỤ QUA LẠI =====================
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ChonDichVu();
        }

        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            ChonDichVu();
        }

        private void ChonDichVu()
        {
            DichVu dv = lstAvailableServices.SelectedItem as DichVu;
            if (dv == null)
            {
                MessageBox.Show("Hãy chọn 1 dịch vụ ở danh sách bên trái.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lstAvailableServices.Items.Remove(dv);
            lstSelectedServices.Items.Add(dv);
            TinhTien();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            BoChonDichVu();
        }

        private void lstSelectedServices_DoubleClick(object sender, EventArgs e)
        {
            BoChonDichVu();
        }

        private void BoChonDichVu()
        {
            DichVu dv = lstSelectedServices.SelectedItem as DichVu;
            if (dv == null)
            {
                MessageBox.Show("Hãy chọn 1 dịch vụ ở danh sách bên phải để bỏ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lstSelectedServices.Items.Remove(dv);
            NapDichVuHienCo();       // trả dịch vụ về danh sách bên trái (nếu đúng loại đang xem)
            TinhTien();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.Items.Count == 0) return;

            lstSelectedServices.Items.Clear();
            NapDichVuHienCo();
            TinhTien();
        }

        // ===================== 3. TÍNH TIỀN =====================
        private void nudChietKhau_ValueChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            string ma = txtMaGiamGia.Text.Trim().ToUpper();
            if (ma == "")
            {
                MessageBox.Show("Vui lòng nhập mã giảm giá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int phanTram;
            if (!maGiamGia.TryGetValue(ma, out phanTram))
            {
                MessageBox.Show("Mã giảm giá \"" + ma + "\" không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nudChietKhau.Value = phanTram;   // tự gọi TinhTien() qua ValueChanged
            MessageBox.Show("Áp dụng mã " + ma + ": giảm " + phanTram + "%.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TinhTien()
        {
            decimal tong = 0;
            foreach (DichVu dv in lstSelectedServices.Items)
                tong += dv.DonGia;

            decimal tienGiam = tong * nudChietKhau.Value / 100;
            decimal thanhTien = tong - tienGiam;

            lblTongTienValue.Text = tong.ToString("N0", vi) + " đ";
            lblTienGiamValue.Text = tienGiam.ToString("N0", vi) + " đ";
            lblThanhTienValue.Text = thanhTien.ToString("N0", vi) + " đ";
            grpSelected.Text = "Dịch vụ đã chọn (" + lstSelectedServices.Items.Count + ")";
        }
    }
}
