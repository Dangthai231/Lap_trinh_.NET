using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    using QuanLyNhanSu.DTO;

    public class NhanVienDAL
    {
        // Tìm theo tên hoặc CCCD (LIKE + %), lọc theo phòng ban (maPB = 0: tất cả). Dùng parameterized query.
        public List<NhanVienDTO> TimKiem(string tuKhoa, int maPB)
        {
            string sql = "SELECT nv.MaNV, nv.HoTen, nv.NgaySinh, nv.CCCD, nv.MaPB, pb.TenPB, nv.LuongCoBan, nv.HeSoLuong " +
                         "FROM NhanVien nv LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB " +
                         "WHERE (nv.HoTen LIKE @TuKhoa OR nv.CCCD LIKE @TuKhoa) AND (@MaPB = 0 OR nv.MaPB = @MaPB) " +
                         "ORDER BY nv.MaNV";
            DataTable dt = DataProvider.ExecuteQuery(sql,
                DataProvider.TS("@TuKhoa", "%" + tuKhoa + "%"), DataProvider.TS("@MaPB", maPB));

            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new NhanVienDTO
                {
                    MaNV = Convert.ToInt32(r["MaNV"]),
                    HoTen = r["HoTen"].ToString(),
                    NgaySinh = r["NgaySinh"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["NgaySinh"]),
                    CCCD = r["CCCD"].ToString(),
                    MaPB = r["MaPB"] == DBNull.Value ? 0 : Convert.ToInt32(r["MaPB"]),
                    TenPB = r["TenPB"].ToString(),
                    LuongCoBan = Convert.ToDecimal(r["LuongCoBan"]),
                    HeSoLuong = Convert.ToDouble(r["HeSoLuong"])
                });
            }
            return ds;
        }

        public int DemNhanVien()
        {
            return Convert.ToInt32(DataProvider.ExecuteScalar("SELECT COUNT(*) FROM NhanVien"));
        }

        public bool Them(NhanVienDTO nv)
        {
            string sql = "INSERT INTO NhanVien (HoTen, NgaySinh, CCCD, MaPB, LuongCoBan, HeSoLuong) " +
                         "VALUES (@HoTen, @NgaySinh, @CCCD, @MaPB, @LuongCoBan, @HeSoLuong)";
            return DataProvider.ExecuteNonQuery(sql, ThamSo(nv)) > 0;
        }

        public bool Sua(NhanVienDTO nv)
        {
            string sql = "UPDATE NhanVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, CCCD = @CCCD, MaPB = @MaPB, " +
                         "LuongCoBan = @LuongCoBan, HeSoLuong = @HeSoLuong WHERE MaNV = @MaNV";
            return DataProvider.ExecuteNonQuery(sql, ThamSo(nv)) > 0;
        }

        // Chuyển phòng ban: chỉ đổi MaPB
        public bool ChuyenPhongBan(int maNV, int maPBMoi)
        {
            return DataProvider.ExecuteNonQuery("UPDATE NhanVien SET MaPB = @MaPB WHERE MaNV = @MaNV",
                DataProvider.TS("@MaPB", maPBMoi), DataProvider.TS("@MaNV", maNV)) > 0;
        }

        public bool Xoa(int maNV)
        {
            return DataProvider.ExecuteNonQuery("DELETE FROM NhanVien WHERE MaNV = @MaNV", DataProvider.TS("@MaNV", maNV)) > 0;
        }

        private static SqlParameter[] ThamSo(NhanVienDTO nv)
        {
            return new[]
            {
                DataProvider.TS("@MaNV", nv.MaNV),
                DataProvider.TS("@HoTen", nv.HoTen),
                DataProvider.TS("@NgaySinh", nv.NgaySinh),
                DataProvider.TS("@CCCD", nv.CCCD),
                DataProvider.TS("@MaPB", nv.MaPB),
                DataProvider.TS("@LuongCoBan", nv.LuongCoBan),
                DataProvider.TS("@HeSoLuong", nv.HeSoLuong)
            };
        }
    }
}
