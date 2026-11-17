namespace QuanLyBanHang.BUS
{
    using QuanLyBanHang.DAL;
    using QuanLyBanHang.DTO;

    public class ThongKeBUS
    {
        private readonly ThongKeDAL dal = new ThongKeDAL();

        public decimal DoanhThuNgay(DateTime ngay) { return dal.DoanhThuNgay(ngay); }
        public decimal DoanhThuThang(int thang, int nam) { return dal.DoanhThuThang(thang, nam); }
        public int SoHoaDonNgay(DateTime ngay) { return dal.SoHoaDonNgay(ngay); }
        public int SoHoaDonThang(int thang, int nam) { return dal.SoHoaDonThang(thang, nam); }
        public List<TopSanPhamDTO> Top5BanChay() { return dal.Top5BanChay(); }
    }
}
