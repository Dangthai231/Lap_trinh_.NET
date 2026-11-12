using System.Globalization;

namespace Bai5_2
{
    // Một dịch vụ: tên + đơn giá
    public class DichVu
    {
        public string LoaiDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal DonGia { get; set; }

        public DichVu(string loai, string ten, decimal donGia)
        {
            LoaiDichVu = loai;
            TenDichVu = ten;
            DonGia = donGia;
        }

        // ListBox hiển thị theo ToString()
        public override string ToString()
        {
            return TenDichVu + "  -  " + DonGia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " đ";
        }
    }
}
