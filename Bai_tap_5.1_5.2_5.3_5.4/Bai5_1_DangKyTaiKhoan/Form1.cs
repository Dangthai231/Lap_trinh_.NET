namespace Bai5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.MaxDate = DateTime.Today;   // không chọn được ngày sinh ở tương lai
            LamMoi();
        }

        // ===================== ĐĂNG KÝ =====================
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            epCheck.Clear();
            List<string> loi = new List<string>();

            // 1. Tên đăng nhập và Mật khẩu không được để trống
            if (txtTenDangNhap.Text.Trim() == "")
                BaoLoi(txtTenDangNhap, "Tên đăng nhập không được để trống.", loi);

            if (txtMatKhau.Text == "")
                BaoLoi(txtMatKhau, "Mật khẩu không được để trống.", loi);

            // 2. Mật khẩu nhập lại phải khớp
            if (txtXacNhanMatKhau.Text != txtMatKhau.Text)
                BaoLoi(txtXacNhanMatKhau, "Mật khẩu nhập lại không khớp.", loi);

            // 3. Tuổi phải >= 18
            int tuoi = TinhTuoi(dtpNgaySinh.Value.Date);
            if (tuoi < 18)
                BaoLoi(dtpNgaySinh, "Bạn phải đủ 18 tuổi (hiện tại: " + tuoi + " tuổi).", loi);

            // Giới tính
            if (!rdoNam.Checked && !rdoNu.Checked)
                BaoLoi(pnlGioiTinh, "Vui lòng chọn giới tính.", loi);

            // 4. Phải đồng ý điều khoản
            if (!chkDieuKhoan.Checked)
                BaoLoi(chkDieuKhoan, "Bạn phải đồng ý với Điều khoản dịch vụ.", loi);

            if (loi.Count > 0)
            {
                MessageBox.Show("Thông tin chưa hợp lệ:\n\n• " + string.Join("\n• ", loi), "Lỗi đăng ký",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Đăng ký tài khoản thành công!\n\n" +
                "Tên đăng nhập: " + txtTenDangNhap.Text.Trim() + "\n" +
                "Ngày sinh: " + dtpNgaySinh.Value.ToString("dd/MM/yyyy") + " (" + tuoi + " tuổi)\n" +
                "Giới tính: " + (rdoNam.Checked ? "Nam" : "Nữ"),
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BaoLoi(Control c, string thongBao, List<string> loi)
        {
            epCheck.SetError(c, thongBao);
            loi.Add(thongBao);
        }

        // Tính tuổi tròn: chưa tới sinh nhật năm nay thì trừ 1
        private static int TinhTuoi(DateTime ngaySinh)
        {
            DateTime homNay = DateTime.Today;
            int tuoi = homNay.Year - ngaySinh.Year;
            if (ngaySinh > homNay.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }

        // Người dùng sửa ô nào thì xóa dấu lỗi ở ô đó
        private void O_Changed(object sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c == null) return;
            if (c == rdoNam || c == rdoNu) c = pnlGioiTinh;
            epCheck.SetError(c, "");
            if (c == txtMatKhau) epCheck.SetError(txtXacNhanMatKhau, "");
        }

        // ===================== LÀM MỚI =====================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtXacNhanMatKhau.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            chkDieuKhoan.Checked = false;
            epCheck.Clear();
            txtTenDangNhap.Focus();
        }
    }
}
