namespace QuanLyBanHang.DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }

        // Hiển thị trong ComboBox
        public string HienThi
        {
            get { return TenNV + " (" + ChucVu + ")"; }
        }
    }
}
