using System;

namespace ProjectTaskManager.DTO
{
    public class DuAnDTO
    {
        public int MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; } // 'Đang chạy', 'Hoàn thành', 'Tạm dừng'

        // Thuộc tính mở rộng để hiển thị tiến độ
        public int TongTask { get; set; }
        public int TaskHoanThanh { get; set; }
        public double TiLeHoanThanh => TongTask > 0 ? Math.Round((double)TaskHoanThanh / TongTask * 100, 1) : 0;

        public override string ToString()
        {
            return TenDuAn;
        }
    }
}
