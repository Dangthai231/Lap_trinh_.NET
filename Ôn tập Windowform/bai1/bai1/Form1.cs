using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
          
        }

       
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
           
        }
        // Sự kiện cho nút "Tính tiền"
        private void btnTinhTien_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu: không được để trống và phải là số
            if (!double.TryParse(txtDonGia.Text, out double donGia) ||
                !int.TryParse(txtSoLuong.Text, out int soLuong) ||
                !double.TryParse(txtGiamGia.Text, out double giamGia))
            {
                // Hiển thị cảnh báo nếu nhập chữ hoặc để trống
                MessageBox.Show("Vui lòng nhập số hợp lệ vào tất cả các ô! Không được để trống hoặc nhập chữ.",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tự động tính toán theo công thức yêu cầu
            double tongTien = (donGia * soLuong) * ((100 - giamGia) / 100);

            // Hiển thị kết quả ra Label, định dạng N2 để có dấu phẩy phân cách hàng nghìn
            lblTongTien.Text = "Tổng tiền thanh toán: " + tongTien.ToString("N2") + " VNĐ";
        }
        // Sự kiện cho nút "Làm mới"
        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            // Xóa dữ liệu các ô nhập liệu
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();

            // Đặt lại kết quả
            lblTongTien.Text = "Tổng tiền thanh toán: 0 VNĐ";

            // Đưa con trỏ chuột về ô Đơn giá
            txtDonGia.Focus();
        }
    }
}
