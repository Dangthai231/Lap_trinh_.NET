namespace QuanLyNhanSu.DTO
{
    // Tổng quỹ lương theo phòng ban (dùng cho báo cáo)
    public class QuyLuongPhongBanDTO
    {
        public string TenPB { get; set; }
        public int SoNhanVien { get; set; }
        public decimal TongLuong { get; set; }
    }
}
