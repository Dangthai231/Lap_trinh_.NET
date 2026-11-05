namespace RepairServiceTracker.Models
{
    public class RepairOrder
    {
        public string MaDon { get; set; } = string.Empty;
        public string TenKhachHang { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string LoaiThietBi { get; set; } = string.Empty;
        public string MoTaLoi { get; set; } = string.Empty;
        public DateTime NgayTiepNhan { get; set; } = DateTime.Today;
        public decimal ChiPhiDuKien { get; set; } = 0;
        public string TrangThai { get; set; } = "Mới tiếp nhận";
        public string? AnhThietBiPath { get; set; } = null;

        public string ChiPhiDisplay => ChiPhiDuKien.ToString("N0");
    }
}
