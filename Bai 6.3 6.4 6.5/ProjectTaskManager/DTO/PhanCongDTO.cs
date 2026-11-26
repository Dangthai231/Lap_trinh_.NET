using System;

namespace ProjectTaskManager.DTO
{
    public class PhanCongDTO
    {
        public int MaTask { get; set; }
        public int MaThanhVien { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string ChuyenMon { get; set; }
        public DateTime NgayGiao { get; set; }
    }
}
