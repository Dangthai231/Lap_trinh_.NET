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
            btnLoadReport.Enabled = false;
            dgvReport.DataSource = null;
            
            // Lấy tham chiếu đến Form Cha để cập nhật ProgressBar
            frmMain? mainForm = this.MdiParent as frmMain;
            mainForm?.UpdateProgress(0, true);

            try
            {
                // Scenario B: Giả lập tác vụ nặng (tải dữ liệu) tốn 3-5 giây
                // Sử dụng Task.Run để đẩy tác vụ xuống Thread phụ
                DataTable result = await Task.Run(async () =>
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Tháng", typeof(string));
                    dt.Columns.Add("Doanh thu", typeof(decimal));
                    dt.Columns.Add("Số đơn hàng", typeof(int));

                    // Giả lập tính toán hoặc truy xuất CSDL nặng theo từng bước
                    for (int i = 1; i <= 12; i++)
                    {
                        // Mỗi bước tốn khoảng 300ms
                        await Task.Delay(300); 

                        // Cập nhật ProgressBar trên Form Cha (cần Invoke an toàn)
                        int progress = (int)((i / 12.0) * 100);
                        mainForm?.UpdateProgress(progress, true);

                        // Thêm dữ liệu giả lập
                        dt.Rows.Add($"Tháng {i}", i * 15000000, i * 100);
                    }

                    return dt;
                });

                // Cập nhật kết quả lên UI (sau khi await xong, context quay về UI Thread)
                dgvReport.DataSource = result;
                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}");
            }
            finally
            {
                btnLoadReport.Enabled = true;
                mainForm?.UpdateProgress(100, false);
            }
        }
    }
}
