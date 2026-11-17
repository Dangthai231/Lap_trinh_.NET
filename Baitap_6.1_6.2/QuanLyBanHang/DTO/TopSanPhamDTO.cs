namespace QuanLyBanHang.DTO
{
    // Một dòng trong báo cáo Top 5 sản phẩm bán chạy
    public class TopSanPhamDTO
    {
        public int Hang { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
    }
}
