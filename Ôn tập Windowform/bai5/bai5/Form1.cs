using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Khởi tạo khi form load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Chọn mặc định loại vận chuyển đầu tiên
            if (cboLoaiVanChuyen.Items.Count > 0)
                cboLoaiVanChuyen.SelectedIndex = 0;

            // Cấu hình DataGridView cho phép xóa dòng và chọn cả dòng
            dgvHangHoa.AllowUserToDeleteRows = true;
            dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHangHoa.MultiSelect = false;

            // Đặt ValueType cho các cột số để DataGridView lưu giá trị số thô (double)
            // thay vì chuỗi, tránh lỗi parse khi đổi culture (dấu . hay , phân cách nghìn)
            ColSoLuong.ValueType = typeof(double);
            ColTrongLuong.ValueType = typeof(double);
            ColDonGia.ValueType = typeof(double);
            ColThanhTien.ValueType = typeof(double);

            // Định dạng hiển thị cho cột đơn giá và thành tiền (vd: 1.000.000)
            ColDonGia.DefaultCellStyle.Format = "N0";
            ColThanhTien.DefaultCellStyle.Format = "N0";

            // Xử lý lỗi chuyển đổi dữ liệu để không hiện hộp thoại mặc định xấu
            dgvHangHoa.DataError += dgvHangHoa_DataError;

            // Tính toán ban đầu
            CapNhatTongKet();
        }

        // Bắt lỗi khi DataGridView không chuyển đổi được giá trị nhập vào
        private void dgvHangHoa_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            DataGridViewCell cell = dgvHangHoa.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.ErrorText = "Dữ liệu không hợp lệ!";
        }

        // 1. Hiển thị thời gian hệ thống trên StatusStrip (dùng Timer)
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // Xử lý click vào label3 (nhãn gợi ý phím tắt) - hiện không làm gì cả
        private void label3_Click(object sender, EventArgs e)
        {
        }

        // 2. Xử lý Validation với ErrorProvider (Số lượng, Trọng lượng <= 0)
        private void dgvHangHoa_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Bỏ qua nếu đang ở dòng mới chưa nhập gì
            if (dgvHangHoa.Rows[e.RowIndex].IsNewRow) return;

            string columnName = dgvHangHoa.Columns[e.ColumnIndex].Name;
            string value = e.FormattedValue == null ? string.Empty : e.FormattedValue.ToString();
            DataGridViewCell cell = dgvHangHoa.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (columnName == "ColSoLuong" || columnName == "ColTrongLuong")
            {
                // Nếu ô trống, không báo lỗi (cho phép bỏ trống để nhập sau)
                if (string.IsNullOrWhiteSpace(value))
                {
                    cell.ErrorText = string.Empty;
                    return;
                }

                // Kiểm tra giá trị có phải số không và phải lớn hơn 0
                if (!double.TryParse(value, out double val))
                {
                    e.Cancel = true; // Ngăn không cho rời khỏi ô
                    cell.ErrorText = "Vui lòng nhập số!";
                    errorProvider1.SetError(dgvHangHoa, "Vui lòng nhập số hợp lệ!");
                }
                else if (val <= 0)
                {
                    e.Cancel = true;
                    cell.ErrorText = "Giá trị phải lớn hơn 0!";
                    errorProvider1.SetError(dgvHangHoa, "Vui lòng nhập số lớn hơn 0!");
                }
                else
                {
                    // Hợp lệ -> xóa lỗi
                    cell.ErrorText = string.Empty;
                    errorProvider1.Clear();
                }
            }
            else
            {
                // Khi rời khỏi cột Số lượng/Trọng lượng, xóa cảnh báo trên lưới
                errorProvider1.Clear();
            }
        }

        // 3. Tự động tính Thành tiền và cập nhật StatusStrip khi thay đổi giá trị cell
        private void dgvHangHoa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvHangHoa.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];

                // Tính Thành tiền = Số lượng * Đơn giá
                double soLuong = 0, donGia = 0;
                if (row.Cells["ColSoLuong"].Value != null)
                    double.TryParse(row.Cells["ColSoLuong"].Value.ToString(), out soLuong);
                if (row.Cells["ColDonGia"].Value != null)
                    double.TryParse(row.Cells["ColDonGia"].Value.ToString(), out donGia);

                // Lưu giá trị số thô (ValueType = double), DataGridView tự định dạng hiển thị "N0"
                row.Cells["ColThanhTien"].Value = soLuong * donGia;

                // Cập nhật lại tổng kết dưới StatusStrip
                CapNhatTongKet();
            }
        }

        // Xử lý sau khi người dùng xóa dòng -> tính lại tổng
        private void dgvHangHoa_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CapNhatTongKet();
        }

        // Hàm phụ cập nhật tổng trên StatusStrip
        private void CapNhatTongKet()
        {
            double tongSoLuong = 0, tongTrongLuong = 0, tongTien = 0;

            foreach (DataGridViewRow row in dgvHangHoa.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Các cột đã đặt ValueType = typeof(double) nên Value là số (hoặc null)
                    tongSoLuong += LayGiaSo(row.Cells["ColSoLuong"].Value);
                    tongTrongLuong += LayGiaSo(row.Cells["ColTrongLuong"].Value);
                    tongTien += LayGiaSo(row.Cells["ColThanhTien"].Value);
                }
            }

            lblTongSoLuong.Text = $"Tổng số lượng: {tongSoLuong}";
            lblTongTrongLuong.Text = $"Tổng trọng lượng: {tongTrongLuong} kg";
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
        }

        // Hàm phụ chuyển giá trị ô sang double an toàn (tránh ném FormatException)
        private static double LayGiaSo(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (value is double d) return d;
            if (double.TryParse(value.ToString(), out double result)) return result;
            return 0;
        }

        // 4. Hỗ trợ phím tắt điều khiển bằng ProcessCmdKey (chạy sớm nhất,
        //    trước cả DataGridView nên không bị nuốt phím F2/Delete)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Nhấn F2 để thêm nhanh dòng mới
            if (keyData == Keys.F2)
            {
                // Nếu đang sửa ô thì commit giá trị hiện tại trước
                if (dgvHangHoa.IsCurrentCellInEditMode)
                    dgvHangHoa.EndEdit();

                dgvHangHoa.Focus();

                // Thêm dòng mới và chuyển con trỏ vào ô "Tên hàng" để nhập
                int newRowIndex = dgvHangHoa.Rows.Add();
                dgvHangHoa.CurrentCell = dgvHangHoa.Rows[newRowIndex].Cells["ColTenHang"];
                dgvHangHoa.BeginEdit(true);
                return true; // báo đã xử lý, không cho control khác can thiệp
            }

            // Nhấn Delete để xóa dòng đang chọn
            if (keyData == Keys.Delete)
            {
                // Không xử lý nếu đang sửa ô (để cho phép xóa ký tự trong ô)
                if (dgvHangHoa.IsCurrentCellInEditMode)
                    return base.ProcessCmdKey(ref msg, keyData);

                // Ưu tiên xóa các dòng được chọn
                if (dgvHangHoa.SelectedRows.Count > 0)
                {
                    var rowsToDelete = dgvHangHoa.SelectedRows
                        .Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow)
                        .ToList();

                    foreach (DataGridViewRow row in rowsToDelete)
                        dgvHangHoa.Rows.Remove(row);

                    CapNhatTongKet();
                    return true;
                }
                // Nếu không có dòng được chọn, xóa dòng hiện tại
                if (dgvHangHoa.CurrentRow != null && !dgvHangHoa.CurrentRow.IsNewRow)
                {
                    dgvHangHoa.Rows.Remove(dgvHangHoa.CurrentRow);
                    CapNhatTongKet();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Sự kiện KeyDown giữ lại cho tương lai (hiện tại phím tắt qua ProcessCmdKey)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
