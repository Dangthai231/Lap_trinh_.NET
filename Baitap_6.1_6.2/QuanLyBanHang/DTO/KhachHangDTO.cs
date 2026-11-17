namespace QuanLyBanHang.DTO
{
    public class KhachHangDTO
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DienThoai { get; set; }
        public int DiemTichLuy { get; set; }

        // Hiển thị trong ComboBox
        public string HienThi
        {
            get { return MaKH == 0 ? TenKH : TenKH + " - " + DienThoai + " (" + DiemTichLuy + " điểm)"; }
        }
    }
}
