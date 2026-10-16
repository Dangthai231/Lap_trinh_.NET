using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Scenario C: Khởi chạy tác vụ nền giả lập đồng bộ dữ liệu
            StartBackgroundSync();
        }

        // Scenario A: Logic điều hướng MDI (Kiểm tra trùng lặp)
        private void OpenChildForm(Type formType)
        {
            // Kiểm tra xem Form con đã mở hay chưa
            Form? child = this.MdiChildren.FirstOrDefault(f => f.GetType() == formType);

            if (child != null)
            {
                // Nếu đã mở thì mang lên trước
                child.Activate();
                child.WindowState = FormWindowState.Normal;
            }
            else
            {
                // Nếu chưa mở thì tạo mới instance
                Form? newForm = Activator.CreateInstance(formType) as Form;
                if (newForm != null)
                {
                    newForm.MdiParent = this;
                    newForm.Show();
                }
            }
        }

        private void mnuQuanLySanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(frmProductCatalog));
        }

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(frmAsyncReport));
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            MessageBox.Show("Đã đăng xuất hệ thống.", "Thông báo");
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        // Scenario C: Cập nhật UI an toàn từ Background Thread
        private void StartBackgroundSync()
        {
            Task.Run(async () =>
            {
                int count = 0;
                while (true)
                {
                    count++;
                    // Giả lập quét số lượng đơn hàng mới mỗi 2 giây
                    await Task.Delay(2000);

                    string status = $"[Sync] Đồng bộ dữ liệu lần {count} - OK (Thread ID: {Environment.CurrentManagedThreadId})";
                    
                    // Áp dụng quy tắc Thread Safety: Safe Cross-Thread
                    UpdateStatusSafe(status);
                }
            });
        }

        private void UpdateStatusSafe(string text)
        {
            // Kiểm tra InvokeRequired để chuyển ngữ cảnh xử lý về UI Thread
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new Action(() => UpdateStatusSafe(text)));
            }
            else
            {
                lblStatus.Text = text;
            }
        }

        // Phương thức dùng chung cho các form con cập nhật tiến trình
        public void UpdateProgress(int value, bool visible)
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new Action(() => UpdateProgress(value, visible)));
            }
            else
            {
                prgTask.Visible = visible;
                prgTask.Value = value;
                if (!visible) lblStatus.Text = "Ready";
            }
        }
    }
}
