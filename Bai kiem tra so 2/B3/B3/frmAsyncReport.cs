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
    public partial class frmAsyncReport : Form
    {
        public frmAsyncReport()
        {
            InitializeComponent();
        }

        private async void btnLoadReport_Click(object sender, EventArgs e)
        {
            // Vô hiệu hóa nút để tránh click nhiều lần
            btnLoadReport.Enabled = false;
            dgvReport.DataSource = null;
            
            // Lấy tham chiếu đến Form Cha MDI
            frmMain? mainForm = this.MdiParent as frmMain;
            
            // Bật ProgressBar trên StatusStrip của Form Cha
            mainForm?.UpdateProgress(0, true);

            try
            {
                // Scenario B: Tải dữ liệu bất đồng bộ (async / await)
                // Giả lập tác vụ lấy dữ liệu cấu hình lớn hoặc truy xuất CSDL tốn 3.6 giây
                DataTable reportData = await Task.Run(async () =>
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Kỳ báo cáo", typeof(string));
                    dt.Columns.Add("Doanh số", typeof(string));
                    dt.Columns.Add("Trạng thái", typeof(string));

                    // Chia nhỏ công việc thành 12 bước (mỗi bước ~300ms) để cập nhật tiến độ
                    for (int i = 1; i <= 12; i++)
                    {
                        // Tác vụ tính toán nặng hoặc chờ I/O
                        await Task.Delay(300); 

                        // Tính toán % tiến độ
                        int progress = (int)((i / 12.0) * 100);
                        
                        // Cập nhật UI an toàn từ Background Thread qua phương thức Invoke của Form Cha
                        mainForm?.UpdateProgress(progress, true);

                        // Thêm dòng dữ liệu giả lập
                        dt.Rows.Add($"Tháng {i}/2026", (i * 12500000).ToString("N0") + " VND", "Hoàn tất");
                    }

                    return dt;
                });

                // Cập nhật kết quả lên DataGridView (Tự động quay về UI Thread sau await)
                dgvReport.DataSource = reportData;
                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
                MessageBox.Show("Báo cáo đã được tải thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra trong quá trình tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục trạng thái nút và ẩn ProgressBar
                btnLoadReport.Enabled = true;
                mainForm?.UpdateProgress(100, false);
            }
        }
    }
}
