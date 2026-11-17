namespace QuanLyBanHang.BUS
{
    using QuanLyBanHang.DAL;
    using QuanLyBanHang.DTO;

    public class SanPhamBUS
    {
        private readonly SanPhamDAL dal = new SanPhamDAL();

        public List<SanPhamDTO> TimKiem(string tuKhoa)
        {
            return dal.TimKiem((tuKhoa ?? "").Trim());
        }

        public SanPhamDTO LayTheoMa(string maSP)
        {
            return dal.LayTheoMa((maSP ?? "").Trim());
        }

        public int DemSapHetHang()
        {
            return dal.DemSapHetHang(10);
        }

        // Trả về "" nếu thành công, ngược lại là câu báo lỗi
        public string Them(SanPhamDTO sp)
        {
            if (dal.LayTheoMa(sp.MaSP) != null) return "Mã sản phẩm \"" + sp.MaSP + "\" đã tồn tại.";
            try { return dal.Them(sp) ? "" : "Không thêm được sản phẩm."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "sản phẩm"); }
        }

        public string Sua(SanPhamDTO sp)
        {
            try { return dal.Sua(sp) ? "" : "Không tìm thấy sản phẩm để sửa."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "sản phẩm"); }
        }

        public string Xoa(string maSP)
        {
            try { return dal.Xoa(maSP) ? "" : "Không tìm thấy sản phẩm để xóa."; }
            catch (Exception ex) { return LoiCSDL.DichLoi(ex, "sản phẩm"); }
        }
    }
}
