using System.Data;

namespace QuanLyBanHang.DAL
{
    using QuanLyBanHang.DTO;

    public class NhanVienDAL
    {
        public List<NhanVienDTO> TimKiem(string tuKhoa)
        {
            string sql = "SELECT MaNV, TenNV, SoDienThoai, ChucVu FROM NhanVien " +
                         "WHERE TenNV LIKE @TuKhoa OR SoDienThoai LIKE @TuKhoa ORDER BY MaNV";
            DataTable dt = DataProvider.ExecuteQuery(sql, DataProvider.TS("@TuKhoa", "%" + tuKhoa + "%"));
            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new NhanVienDTO
                {
                    MaNV = Convert.ToInt32(r["MaNV"]),
                    TenNV = r["TenNV"].ToString(),
                    SoDienThoai = r["SoDienThoai"].ToString(),
                    ChucVu = r["ChucVu"].ToString()
                });
            }
            return ds;
        }

        public bool Them(NhanVienDTO nv)
        {
            string sql = "INSERT INTO NhanVien (TenNV, SoDienThoai, ChucVu) VALUES (@TenNV, @SoDienThoai, @ChucVu)";
            return DataProvider.ExecuteNonQuery(sql, DataProvider.TS("@TenNV", nv.TenNV),
                DataProvider.TS("@SoDienThoai", nv.SoDienThoai), DataProvider.TS("@ChucVu", nv.ChucVu)) > 0;
        }

        public bool Sua(NhanVienDTO nv)
        {
            string sql = "UPDATE NhanVien SET TenNV = @TenNV, SoDienThoai = @SoDienThoai, ChucVu = @ChucVu WHERE MaNV = @MaNV";
            return DataProvider.ExecuteNonQuery(sql, DataProvider.TS("@MaNV", nv.MaNV), DataProvider.TS("@TenNV", nv.TenNV),
                DataProvider.TS("@SoDienThoai", nv.SoDienThoai), DataProvider.TS("@ChucVu", nv.ChucVu)) > 0;
        }

        public bool Xoa(int maNV)
        {
            return DataProvider.ExecuteNonQuery("DELETE FROM NhanVien WHERE MaNV = @MaNV",
                DataProvider.TS("@MaNV", maNV)) > 0;
        }
    }
}
