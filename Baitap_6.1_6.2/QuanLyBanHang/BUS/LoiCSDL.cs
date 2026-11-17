using Microsoft.Data.SqlClient;

namespace QuanLyBanHang.BUS
{
    // Đổi lỗi SQL Server thành câu thông báo dễ hiểu
    public static class LoiCSDL
    {
        public static string DichLoi(Exception ex, string doiTuong)
        {
            SqlException sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                switch (sqlEx.Number)
                {
                    case 2627:
                    case 2601: return "Dữ liệu bị trùng (mã hoặc số điện thoại đã tồn tại).";
                    case 547:
                        if (sqlEx.Message.Contains("DELETE"))
                            return "Không thể xóa " + doiTuong + " này vì đã có hóa đơn liên quan.";
                        return "Dữ liệu vi phạm ràng buộc của CSDL (giá trị không hợp lệ).";
                }
            }
            return "Lỗi CSDL: " + ex.Message;
        }
    }
}
