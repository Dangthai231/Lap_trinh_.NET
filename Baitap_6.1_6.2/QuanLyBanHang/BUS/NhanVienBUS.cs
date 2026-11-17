namespace QuanLyBanHang.BUS
{
    using QuanLyBanHang.DAL;
    using QuanLyBanHang.DTO;

    public class NhanVienBUS
    {
        private readonly NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVienDTO> TimKiem(string tuKhoa)
        {
            return dal.TimKiem((tuKhoa ?? "").Trim());
        }

        public string Them(NhanVienDTO nv)
        {
            try { return dal.Them(nv) ? "" : "Không thêm được nhân viên."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "nhân viên"); }
        }

        public string Sua(NhanVienDTO nv)
        {
            try { return dal.Sua(nv) ? "" : "Không tìm thấy nhân viên để sửa."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "nhân viên"); }
        }

        public string Xoa(int maNV)
        {
            try { return dal.Xoa(maNV) ? "" : "Không tìm thấy nhân viên để xóa."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "nhân viên"); }
        }
    }
}
