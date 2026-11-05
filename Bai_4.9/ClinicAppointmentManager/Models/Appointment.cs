namespace ClinicAppointmentManager.Models
{
    public class Appointment
    {
        public string MaLichHen { get; set; } = string.Empty;
        public string HoTenBenhNhan { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public DateTime NgayGioHen { get; set; }
        public string BacSi { get; set; } = string.Empty;
        public string LyDoKham { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "Chờ khám";

        public override string ToString() => $"{MaLichHen} - {HoTenBenhNhan}";
    }
}
