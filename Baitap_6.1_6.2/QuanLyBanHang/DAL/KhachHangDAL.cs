using System.Data;

namespace QuanLyBanHang.DAL
{
    using QuanLyBanHang.DTO;

    public class KhachHangDAL
    {
        public List<KhachHangDTO> TimKiem(string tuKhoa)
        {
            string sql = "SELECT MaKH, TenKH, DienThoai, DiemTichLuy FROM KhachHang " +
                         "WHERE TenKH LIKE @TuKhoa OR DienThoai LIKE @TuKhoa ORDER BY TenKH";
            DataTable dt = DataProvider.ExecuteQuery(sql, DataProvider.TS("@TuKhoa", "%" + tuKhoa + "%"));
            List<KhachHangDTO> ds = new List<KhachHangDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new KhachHangDTO
                {
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"].ToString(),
                    DiemTichLuy = Convert.ToInt32(r["DiemTichLuy"])
                });
            }
            return ds;
        }

        public bool Them(KhachHangDTO kh)
        {
            string sql = "INSERT INTO KhachHang (TenKH, DienThoai, DiemTichLuy) VALUES (@TenKH, @DienThoai, 0)";
            return DataProvider.ExecuteNonQuery(sql,
                DataProvider.TS("@TenKH", kh.TenKH), DataProvider.TS("@DienThoai", kh.DienThoai)) > 0;
        }

        public bool Sua(KhachHangDTO kh)
        {
            string sql = "UPDATE KhachHang SET TenKH = @TenKH, DienThoai = @DienThoai WHERE MaKH = @MaKH";
            return DataProvider.ExecuteNonQuery(sql, DataProvider.TS("@MaKH", kh.MaKH),
                DataProvider.TS("@TenKH", kh.TenKH), DataProvider.TS("@DienThoai", kh.DienThoai)) > 0;
        }

        public bool Xoa(int maKH)
        {
            return DataProvider.ExecuteNonQuery("DELETE FROM KhachHang WHERE MaKH = @MaKH",
                DataProvider.TS("@MaKH", maKH)) > 0;
        }
    }
}
