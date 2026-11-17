using System.Data;
using System.Globalization;

namespace QuanLyNhanSu.GUI
{
    using QuanLyNhanSu.BUS;

    public partial class FormChamCong : Form
    {
        private readonly ChamCongBUS bus = new ChamCongBUS();
        private DataTable dtChamCong;         // dữ liệu ngắt kết nối đang sửa trên lưới
        private string thangDangXem = "";
        private bool daChot = false;

        public FormChamCong()
        {
            InitializeComponent();
        }

        private void FormChamCong_Load(object sender, EventArgs e)
        {
            dgvChamCong.AutoGenerateColumns = false;
            dtpThang.Value = DateTime.Today;
            btnLuu.Enabled = false;
        }

        private bool CoThayDoiChuaLuu()
        {
            if (dtChamCong == null || daChot) return false;
            dgvChamCong.EndEdit();
            return dtChamCong.GetChanges() != null;
        }

        // ===================== NẠP BẢNG CHẤM CÔNG =====================
        private void btnNap_Click(object sender, EventArgs e)
        {
            if (CoThayDoiChuaLuu() &&
                MessageBox.Show("Bảng chấm công tháng " + thangDangXem + " có thay đổi chưa lưu. Bỏ qua các thay đổi đó?",
                    "Chưa lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            string thangNam = ChamCongBUS.ThangNam(dtpThang.Value);
            try
            {
                dtChamCong = bus.NapBangChamCong(thangNam, out daChot);
                thangDangXem = thangNam;
                dgvChamCong.DataSource = dtChamCong;

                dgvChamCong.ReadOnly = daChot;
                btnLuu.Enabled = !daChot;
                CapNhatTrangThai();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTrangThai()
        {
            if (dtChamCong == null) return;
            if (daChot)
            {
                lblTrangThai.ForeColor = Color.Firebrick;
                lblTrangThai.Text = "Tháng " + thangDangXem + " ĐÃ CHỐT LƯƠNG - chỉ xem, không sửa được.";
                return;
            }
            DataTable thayDoi = dtChamCong.GetChanges();
            int soChuaLuu = thayDoi == null ? 0 : thayDoi.Rows.Count;
            lblTrangThai.ForeColor = soChuaLuu > 0 ? Color.DarkOrange : Color.SeaGreen;
            lblTrangThai.Text = "Tháng " + thangDangXem + ": " + dtChamCong.Rows.Count + " nhân viên" +
                                (soChuaLuu > 0 ? "  |  " + soChuaLuu + " dòng chưa lưu" : "  |  đã lưu hết");
        }

        // ===================== NHẬP TRÊN LƯỚI =====================

        // Cho phép gõ cả 21.5 lẫn 21,5
        private void dgvChamCong_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.Value == null) return;
            double so;
            string s = e.Value.ToString().Trim().Replace(',', '.');
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out so))
            {
                e.Value = so;
                e.ParsingApplied = true;
            }
        }

        private void dgvChamCong_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string ten = dgvChamCong.Columns[e.ColumnIndex].Name;
            if (ten != "colSoNgayCong" && ten != "colSoGioOT") return;
            if (dgvChamCong.ReadOnly) return;

            double so;
            string s = (e.FormattedValue ?? "").ToString().Trim().Replace(',', '.');
            string loi = "";
            if (!double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out so))
                loi = "Phải nhập số.";
            else if (ten == "colSoNgayCong" && (so < 0 || so > 31))
                loi = "Số ngày công phải từ 0 đến 31.";
            else if (ten == "colSoGioOT" && so < 0)
                loi = "Số giờ OT không được âm.";

            DataGridViewCell o = dgvChamCong[e.ColumnIndex, e.RowIndex];
            if (loi != "")
            {
                // Không cho rời ô sai: hiện dấu lỗi đỏ trong ô + dòng báo lỗi phía trên
                o.ErrorText = loi;
                e.Cancel = true;
                lblTrangThai.ForeColor = Color.Red;
                lblTrangThai.Text = "LỖI: " + loi + " (Nhấn Esc để hủy giá trị vừa gõ)";
            }
            else o.ErrorText = "";
        }

        private void dgvChamCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvChamCong[e.ColumnIndex, e.RowIndex].ErrorText = "";
            CapNhatTrangThai();
        }

        private void dgvChamCong_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        // ===================== LƯU (adapter.Update) =====================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtChamCong == null) return;
            if (!dgvChamCong.EndEdit()) return;

            string loi = bus.KiemTra(dtChamCong);
            if (loi != "")
            {
                MessageBox.Show(loi, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtChamCong.GetChanges() == null)
            {
                MessageBox.Show("Không có thay đổi nào cần lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int soDong = bus.Luu(dtChamCong);      // SqlCommandBuilder + adapter.Update() trong 1 thao tác
                MessageBox.Show("Đã lưu chấm công tháng " + thangDangXem + " (" + soDong + " dòng được cập nhật).",
                    "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nạp lại để lấy mã chấm công thật do SQL Server cấp cho các dòng mới
                dtChamCong = bus.NapBangChamCong(thangDangXem, out daChot);
                dgvChamCong.DataSource = dtChamCong;
                CapNhatTrangThai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormChamCong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CoThayDoiChuaLuu() &&
                MessageBox.Show("Có thay đổi chưa lưu. Vẫn đóng cửa sổ?", "Chưa lưu",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
