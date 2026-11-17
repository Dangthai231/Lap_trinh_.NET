namespace QuanLyBanHang.BUS
{
    using QuanLyBanHang.DAL;
    using QuanLyBanHang.DTO;

    public class KhachHangBUS
    {
        private readonly KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHangDTO> TimKiem(string tuKhoa)
        {
            return dal.TimKiem((tuKhoa ?? "").Trim());
        }

        public string Them(KhachHangDTO kh)
        {
            try { return dal.Them(kh) ? "" : "Không thêm được khách hàng."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "khách hàng"); }
        }

        public string Sua(KhachHangDTO kh)
        {
            try { return dal.Sua(kh) ? "" : "Không tìm thấy khách hàng để sửa."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "khách hàng"); }
        }

        public string Xoa(int maKH)
        {
            try { return dal.Xoa(maKH) ? "" : "Không tìm thấy khách hàng để xóa."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "khách hàng"); }
        }
    }
}
