using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu cơ bản
            if (string.IsNullOrWhiteSpace(txtMaVT.Text) || string.IsNullOrWhiteSpace(txtTenVT.Text))
            {
                MessageBox.Show("Vui lòng nhập ít nhất Mã và Tên vật tư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yêu cầu: Không cho phép thêm nếu Mã VT đã tồn tại trong ListView[cite: 7]
            foreach (ListViewItem item in lsvDanhSach.Items)
            {
                if (item.Text == txtMaVT.Text) // item.Text chính là giá trị của cột đầu tiên (Mã VT)
                {
                    MessageBox.Show("Mã vật tư này đã tồn tại trong danh sách!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Tạo một dòng mới (ListViewItem)
            ListViewItem newItem = new ListViewItem(txtMaVT.Text); // Cột 1: Mã VT
            newItem.SubItems.Add(txtTenVT.Text);                   // Cột 2: Tên VT
            newItem.SubItems.Add(cmbDonViTinh.Text);               // Cột 3: Đơn vị tính
            newItem.SubItems.Add(txtDonGia.Text);                  // Cột 4: Đơn giá

            // Đưa dòng mới vào ListView
            lsvDanhSach.Items.Add(newItem);

            // Dọn dẹp form sau khi thêm
            ClearForm();
        }
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvDanhSach.SelectedItems[0];

                txtMaVT.Text = selectedItem.SubItems[0].Text;
                txtTenVT.Text = selectedItem.SubItems[1].Text;
                cmbDonViTinh.Text = selectedItem.SubItems[2].Text;
                txtDonGia.Text = selectedItem.SubItems[3].Text;

                // Mẹo: Nên khóa TextBox Mã VT lại khi đang chọn sửa để tránh đổi Mã làm hỏng logic
                txtMaVT.Enabled = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count > 0)
            {
                // Cập nhật lại các cột của dòng đang được chọn (bỏ qua cột 0 là Mã VT)
                ListViewItem selectedItem = lsvDanhSach.SelectedItems[0];
                selectedItem.SubItems[1].Text = txtTenVT.Text;
                selectedItem.SubItems[2].Text = cmbDonViTinh.Text;
                selectedItem.SubItems[3].Text = txtDonGia.Text;

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách để cập nhật!");
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count > 0)
            {
                // Yêu cầu: Hiển thị MessageBox xác nhận dạng (Yes/No) trước khi xóa[cite: 7]
                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng đang chọn?",
                                                       "Xác nhận xóa",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    lsvDanhSach.Items.Remove(lsvDanhSach.SelectedItems[0]);
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            }
        }

        private void btnXoaToanBo_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa TOÀN BỘ danh sách không?",
                                                   "Xóa tất cả",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                lsvDanhSach.Items.Clear();
                ClearForm();
            }
        }

        // Hàm phụ dùng chung để làm sạch các ô nhập liệu
        private void ClearForm()
        {
            txtMaVT.Clear();
            txtTenVT.Clear();
            txtDonGia.Clear();
            cmbDonViTinh.SelectedIndex = -1;

            txtMaVT.Enabled = true; // Mở khóa lại ô Mã VT nếu trước đó đã bị khóa
            txtMaVT.Focus();
        }
    }
    }
