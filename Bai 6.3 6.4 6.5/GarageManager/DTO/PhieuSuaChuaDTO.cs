using System;

namespace GarageManager.DTO
{
    public class PhieuSuaChuaDTO
    {
        public int MaPhieu { get; set; }
        public string BienSo { get; set; }
        public string TenKH { get; set; }
        public string DienThoai { get; set; }
        public string HieuXe { get; set; }
        public DateTime NgayNhan { get; set; }
        public string NoiDungSua { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; } // 'Đang sửa', 'Đã hoàn thành', 'Đã thanh toán'
    }
}
