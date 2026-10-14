using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            // Mở OpenFileDialog để chọn ảnh[cite: 5]
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh lỗi";
            ofd.Filter = "Image Files|*.jpg;*.png"; // Lọc tệp .jpg, .png[cite: 5]

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh lên PictureBox và chỉnh SizeMode[cite: 5]
                picAnhLoi.Image = Image.FromFile(ofd.FileName);
                picAnhLoi.SizeMode = PictureBoxSizeMode.StretchImage; // Kéo giãn ảnh vừa khung[cite: 5]
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtNguoiYeuCau.Clear();
            dtpNgayGhiNhan.Value = DateTime.Now;
            
            // Xóa chọn RadioButton
            radThap.Checked = false;
            radTrungBinh.Checked = false;
            radKhanCap.Checked = false;

            // Xóa chọn ComboBox
            cmbLoaiSuCo.SelectedIndex = -1;

            // Xóa chọn CheckBox
            chkMayTinhBan.Checked = false;
            chkLaptop.Checked = false;
            chkMayIn.Checked = false;
            chkDienThoai.Checked = false;

            // Xóa ảnh
            picAnhLoi.Image = null;
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            // Gom thông tin cơ bản
            string maPhieu = txtMaPhieu.Text;
            string nguoiYeuCau = txtNguoiYeuCau.Text;
            string ngayGhiNhan = dtpNgayGhiNhan.Value.ToString("dd/MM/yyyy");

            // Lấy Mức độ ưu tiên
            string mucDo = "Chưa chọn";
            if (radThap.Checked) mucDo = "Thấp";
            else if (radTrungBinh.Checked) mucDo = "Trung bình";
            else if (radKhanCap.Checked) mucDo = "Khẩn cấp";

            // Lấy Loại sự cố
            string loaiSuCo = cmbLoaiSuCo.SelectedItem != null ? cmbLoaiSuCo.SelectedItem.ToString() : "Chưa chọn";

            // Lấy Thiết bị ảnh hưởng (Có thể chọn nhiều CheckBox)
            string thietBi = "";
            if (chkMayTinhBan.Checked) thietBi += "- Máy tính bàn\n";
            if (chkLaptop.Checked) thietBi += "- Laptop\n";
            if (chkMayIn.Checked) thietBi += "- Máy in\n";
            if (chkDienThoai.Checked) thietBi += "- Điện thoại\n";
            if (thietBi == "") thietBi = "Không có\n";

            // Tạo chuỗi tóm tắt để hiển thị[cite: 5]
            string tomTat = $"--- THÔNG TIN PHIẾU HỖ TRỢ ---\n" +
                            $"Mã phiếu: {maPhieu}\n" +
                            $"Người yêu cầu: {nguoiYeuCau}\n" +
                            $"Ngày ghi nhận: {ngayGhiNhan}\n" +
                            $"Mức độ ưu tiên: {mucDo}\n" +
                            $"Loại sự cố: {loaiSuCo}\n" +
                            $"Thiết bị ảnh hưởng:\n{thietBi}";

            // Hiển thị bảng tóm tắt qua MessageBox[cite: 5]
            MessageBox.Show(tomTat, "Xác nhận gửi yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
