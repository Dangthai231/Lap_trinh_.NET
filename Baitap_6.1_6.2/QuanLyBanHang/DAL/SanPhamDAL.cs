using System.Data;

namespace QuanLyBanHang.DAL
{
    using QuanLyBanHang.DTO;

    public class SanPhamDAL
    {
        // Tìm theo tên hoặc mã vạch, dùng ký tự đại diện % qua SqlParameter
        public List<SanPhamDTO> TimKiem(string tuKhoa)
        {
            string sql = "SELECT MaSP, TenSP, GiaBan, SoLuongTon FROM SanPham " +
                         "WHERE TenSP LIKE @TuKhoa OR MaSP LIKE @TuKhoa ORDER BY TenSP";
            DataTable dt = DataProvider.ExecuteQuery(sql, DataProvider.TS("@TuKhoa", "%" + tuKhoa + "%"));
            return ChuyenDoi(dt);
        }

        public SanPhamDTO LayTheoMa(string maSP)
        {
            string sql = "SELECT MaSP, TenSP, GiaBan, SoLuongTon FROM SanPham WHERE MaSP = @MaSP";
            List<SanPhamDTO> ds = ChuyenDoi(DataProvider.ExecuteQuery(sql, DataProvider.TS("@MaSP", maSP)));
            return ds.Count > 0 ? ds[0] : null;
        }

        public bool Them(SanPhamDTO sp)
        {
            string sql = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon) VALUES (@MaSP, @TenSP, @GiaBan, @SoLuongTon)";
            return DataProvider.ExecuteNonQuery(sql,
                DataProvider.TS("@MaSP", sp.MaSP), DataProvider.TS("@TenSP", sp.TenSP),
                DataProvider.TS("@GiaBan", sp.GiaBan), DataProvider.TS("@SoLuongTon", sp.SoLuongTon)) > 0;
        }

        public bool Sua(SanPhamDTO sp)
        {
            string sql = "UPDATE SanPham SET TenSP = @TenSP, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon WHERE MaSP = @MaSP";
            return DataProvider.ExecuteNonQuery(sql,
                DataProvider.TS("@MaSP", sp.MaSP), DataProvider.TS("@TenSP", sp.TenSP),
                DataProvider.TS("@GiaBan", sp.GiaBan), DataProvider.TS("@SoLuongTon", sp.SoLuongTon)) > 0;
        }

        public bool Xoa(string maSP)
        {
            return DataProvider.ExecuteNonQuery("DELETE FROM SanPham WHERE MaSP = @MaSP",
                DataProvider.TS("@MaSP", maSP)) > 0;
        }

        public int DemSapHetHang(int nguong)
        {
            return Convert.ToInt32(DataProvider.ExecuteScalar("SELECT COUNT(*) FROM SanPham WHERE SoLuongTon < @Nguong",
                DataProvider.TS("@Nguong", nguong)));
        }

        private static List<SanPhamDTO> ChuyenDoi(DataTable dt)
        {
            List<SanPhamDTO> ds = new List<SanPhamDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new SanPhamDTO
                {
                    MaSP = r["MaSP"].ToString(),
                    TenSP = r["TenSP"].ToString(),
                    GiaBan = Convert.ToDecimal(r["GiaBan"]),
                    SoLuongTon = Convert.ToInt32(r["SoLuongTon"])
                });
            }
            return ds;
        }
    }
}
