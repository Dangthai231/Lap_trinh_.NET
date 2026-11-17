using Microsoft.Data.SqlClient;

namespace QuanLyBanHang.DAL
{
    using QuanLyBanHang.DTO;

    public class ThongKeDAL
    {
        // ExecuteScalar: tổng doanh thu trong 1 ngày
        public decimal DoanhThuNgay(DateTime ngay)
        {
            object kq = DataProvider.ExecuteScalar(
                "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE CAST(NgayLap AS DATE) = @Ngay",
                DataProvider.TS("@Ngay", ngay.Date));
            return Convert.ToDecimal(kq);
        }

        // ExecuteScalar: tổng doanh thu trong 1 tháng
        public decimal DoanhThuThang(int thang, int nam)
        {
            object kq = DataProvider.ExecuteScalar(
                "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE MONTH(NgayLap) = @Thang AND YEAR(NgayLap) = @Nam",
                DataProvider.TS("@Thang", thang), DataProvider.TS("@Nam", nam));
            return Convert.ToDecimal(kq);
        }

        public int SoHoaDonNgay(DateTime ngay)
        {
            return Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayLap AS DATE) = @Ngay", DataProvider.TS("@Ngay", ngay.Date)));
        }

        public int SoHoaDonThang(int thang, int nam)
        {
            return Convert.ToInt32(DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM HoaDon WHERE MONTH(NgayLap) = @Thang AND YEAR(NgayLap) = @Nam",
                DataProvider.TS("@Thang", thang), DataProvider.TS("@Nam", nam)));
        }

        // SqlDataReader: Top 5 sản phẩm bán chạy nhất (theo tổng số lượng bán)
        public List<TopSanPhamDTO> Top5BanChay()
        {
            List<TopSanPhamDTO> ds = new List<TopSanPhamDTO>();
            string sql = "SELECT TOP 5 sp.MaSP, sp.TenSP, SUM(ct.SoLuong) AS SoLuongBan, SUM(ct.SoLuong * ct.DonGia) AS DoanhThu " +
                         "FROM ChiTietHoaDon ct JOIN SanPham sp ON ct.MaSP = sp.MaSP " +
                         "GROUP BY sp.MaSP, sp.TenSP ORDER BY SoLuongBan DESC, DoanhThu DESC";

            using (SqlConnection conn = DataProvider.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int hang = 1;
                    while (reader.Read())
                    {
                        ds.Add(new TopSanPhamDTO
                        {
                            Hang = hang++,
                            MaSP = reader.GetString(0),
                            TenSP = reader.GetString(1),
                            SoLuongBan = reader.GetInt32(2),
                            DoanhThu = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return ds;
        }
    }
}
