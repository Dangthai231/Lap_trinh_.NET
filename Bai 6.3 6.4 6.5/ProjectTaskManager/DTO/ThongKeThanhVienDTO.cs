using System;

namespace ProjectTaskManager.DTO
{
    public class ThongKeThanhVienDTO
    {
        public int MaThanhVien { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string ChuyenMon { get; set; }
        public int TongTask { get; set; }
        public int TaskHoanThanh { get; set; }
        public int TaskDangLam { get; set; }
        public int TaskTreHan { get; set; }
        public double TiLeHoanThanh => TongTask > 0 ? Math.Round((double)TaskHoanThanh / TongTask * 100, 1) : 0;
    }
}
