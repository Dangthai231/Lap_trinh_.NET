using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai4
{
    public partial class Form1 : Form
    {
        // Biến lưu trữ giá tiền theo khung giờ
        private int giaTien = 100000; // Mặc định là Sáng
        private int soViTriDangChon = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbKhungGio.SelectedIndex = 0; // Chọn mặc định "Sáng"

            // Dùng vòng lặp for để tạo 20 Button[cite: 8]
            for (int i = 1; i <= 20; i++)
            {
                Button btn = new Button();
                btn.Text = "Bàn " + i;
                btn.Width = 60;
                btn.Height = 50;
                btn.BackColor = Color.White; // Màu trắng (Trống)[cite: 8]
                btn.Cursor = Cursors.Hand;

                // Gán chung 1 hàm xử lý sự kiện Click cho toàn bộ 20 nút[cite: 8]
                btn.Click += new EventHandler(lblSoViTri_Click);

                // Thêm nút vào FlowLayoutPanel[cite: 8]
                flpSoDo.Controls.Add(btn);
            }
        }
        private void lblSoViTri_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Nếu nút màu Đỏ (Đã khóa), không cho phép thao tác[cite: 8]
            if (btn.BackColor == Color.Red)
            {
                MessageBox.Show("Vị trí này đã có người đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đổi trạng thái từ Trắng (Trống) sang Xanh lá (Đang chọn) và ngược lại[cite: 8]
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.LightGreen; // Đang chọn[cite: 8]
                soViTriDangChon++;
            }
            else if (btn.BackColor == Color.LightGreen)
            {
                btn.BackColor = Color.White; // Bỏ chọn[cite: 8]
                soViTriDangChon--;
            }

            // Cập nhật số lượng và tạm tính tiền realtime[cite: 8]
            CapNhatThongKe();
        }

        private void cmbKhungGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhungGio.SelectedItem.ToString() == "Sáng")
                giaTien = 100000;
            else if (cmbKhungGio.SelectedItem.ToString() == "Tối")
                giaTien = 150000;

            // Tính lại tiền ngay khi đổi khung giờ[cite: 8]
            CapNhatThongKe();
        }

        // Hàm phụ cập nhật Label[cite: 8]
        private void CapNhatThongKe()
        {
            lblSoViTri.Text = $"Số vị trí đang chọn: {soViTriDangChon}";
            int tongTien = soViTriDangChon * giaTien;
            lblTamTinh.Text = $"Tạm tính tiền: {tongTien:N0} VNĐ";
        }

        // 4. Xử lý nút Xác nhận đặt[cite: 8]
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (soViTriDangChon == 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Xác nhận đặt {soViTriDangChon} bàn với tổng tiền là {soViTriDangChon * giaTien:N0} VNĐ?",
                                                   "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Chuyển tất cả các nút Xanh lá thành Đỏ (Đã khóa)[cite: 8]
                foreach (Control ctrl in flpSoDo.Controls)
                {
                    if (ctrl is Button && ctrl.BackColor == Color.LightGreen)
                    {
                        ctrl.BackColor = Color.Red;
                    }
                }

                // Reset bộ đếm
                soViTriDangChon = 0;
                CapNhatThongKe();
                MessageBox.Show("Đặt bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyChon_Click(object sender, EventArgs e)
        {
            if (soViTriDangChon > 0)
            {
                // Đổi toàn bộ các nút đang chọn (Xanh lá) về trống (Trắng)[cite: 8]
                foreach (Control ctrl in flpSoDo.Controls)
                {
                    if (ctrl is Button && ctrl.BackColor == Color.LightGreen)
                    {
                        ctrl.BackColor = Color.White;
                    }
                }

                // Reset bộ đếm
                soViTriDangChon = 0;
                CapNhatThongKe();
            }
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            if (soViTriDangChon == 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Xác nhận đặt {soViTriDangChon} bàn với tổng tiền là {soViTriDangChon * giaTien:N0} VNĐ?",
                                                   "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Chuyển tất cả các nút Xanh lá thành Đỏ (Đã khóa)[cite: 8]
                foreach (Control ctrl in flpSoDo.Controls)
                {
                    if (ctrl is Button && ctrl.BackColor == Color.LightGreen)
                    {
                        ctrl.BackColor = Color.Red;
                    }
                }

                // Reset bộ đếm
                soViTriDangChon = 0;
                CapNhatThongKe();
                MessageBox.Show("Đặt bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
