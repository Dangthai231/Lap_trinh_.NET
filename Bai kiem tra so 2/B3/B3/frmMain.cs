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

        // Logic điều hướng MDI chung
        private void OpenChildForm(Type formType)
        {
            // Kiểm tra xem form đã được mở chưa
            Form? child = this.MdiChildren.FirstOrDefault(f => f.GetType() == formType);

            if (child != null)
            {
                // Nếu đã mở, mang lên trước
                child.Activate();
            }
            else
            {
                // Nếu chưa mở, tạo mới
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
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
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
                    // Giả lập lấy dữ liệu tỷ giá hoặc đơn hàng mới mỗi 2 giây
                    await Task.Delay(2000);

                    string statusText = $"Đang đồng bộ... Lần thứ {count} (Thread ID: {Environment.CurrentManagedThreadId})";

                    // Cập nhật UI an toàn
                    UpdateStatusSafe(statusText);
                }
            });
        }

        private void UpdateStatusSafe(string text)
        {
            // Kiểm tra InvokeRequired
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new Action(() => UpdateStatusSafe(text)));
            }
            else
            {
                lblStatus.Text = text;
            }
        }

        // Cung cấp ProgressBar cho các form con sử dụng
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
            }
        }
    }
}
