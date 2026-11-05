namespace LabEquipmentCheckout.Models
{
    public class BorrowRecord
    {
        public string MaPhieu { get; set; } = string.Empty;
        public string MaSinhVien { get; set; } = string.Empty;
        public string HoTenSinhVien { get; set; } = string.Empty;
        public string ThietBi { get; set; } = string.Empty;
        public int SoLuong { get; set; } = 1;
        public DateTime NgayMuon { get; set; } = DateTime.Today;
        public DateTime HanTra { get; set; } = DateTime.Today.AddDays(7);
        public DateTime? NgayTraThucTe { get; set; } = null;

        // Tình trạng: "Đang mượn", "Đã trả", "Quá hạn"
        public string TinhTrang
        {
            get
            {
                if (NgayTraThucTe.HasValue) return "Đã trả";
                if (HanTra.Date < DateTime.Today) return "Quá hạn";
                return "Đang mượn";
            }
        }

        public string NgayTraThucTeDisplay =>
            NgayTraThucTe.HasValue ? NgayTraThucTe.Value.ToString("dd/MM/yyyy") : "";
    }
}
