using System;

namespace ProjectTaskManager.DTO
{
    public class CongViecDTO
    {
        public int MaTask { get; set; }
        public int MaDuAn { get; set; }
        public string TenDuAn { get; set; }
        public string TenTask { get; set; }
        public string MoTa { get; set; }
        public DateTime? HanNop { get; set; }
        public string DoUuTien { get; set; } // 'Cao', 'Trung bình', 'Thấp'
        public string TrangThai { get; set; } // 'To Do', 'In Progress', 'Review', 'Done'

        // Danh sách thành viên phụ trách (ghép chuỗi)
        public string DanhSachThanhVien { get; set; } = "";

        // Kiểm tra quá hạn
        public bool IsOverdue => HanNop.HasValue && HanNop.Value.Date < DateTime.Today && TrangThai != "Done";

        // Số ngày trễ hạn
        public int SoNgayTreHan
        {
            get
            {
                if (IsOverdue && HanNop.HasValue)
                {
                    return (DateTime.Today - HanNop.Value.Date).Days;
                }
                return 0;
            }
        }
    }
}
