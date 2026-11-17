using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    using QuanLyNhanSu.DTO;

    public class LuongDAL
    {
        // Lấy dữ liệu chấm công + lương cơ bản của tháng để tính lương
        public List<BangLuongDTO> LayDuLieuTinhLuong(string thangNam)
        {
            string sql = "SELECT nv.MaNV, nv.HoTen, pb.TenPB, nv.LuongCoBan, nv.HeSoLuong, cc.SoNgayCong, cc.SoGioOT " +
                         "FROM BangChamCong cc JOIN NhanVien nv ON cc.MaNV = nv.MaNV " +
                         "LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB " +
                         "WHERE cc.ThangNam = @ThangNam ORDER BY nv.MaNV";
            DataTable dt = DataProvider.ExecuteQuery(sql, DataProvider.TS("@ThangNam", thangNam));
            List<BangLuongDTO> ds = new List<BangLuongDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new BangLuongDTO
                {
                    MaNV = Convert.ToInt32(r["MaNV"]),
                    HoTen = r["HoTen"].ToString(),
                    TenPB = r["TenPB"].ToString(),
                    ThangNam = thangNam,
                    LuongCoBan = Convert.ToDecimal(r["LuongCoBan"]),
                    HeSoLuong = Convert.ToDouble(r["HeSoLuong"]),
                    SoNgayCong = Convert.ToDouble(r["SoNgayCong"]),
                    SoGioOT = Convert.ToDouble(r["SoGioOT"])
                });
            }
            return ds;
        }

        public bool DaChotLuong(string thangNam)
        {
            object kq = DataProvider.ExecuteScalar(
                "SELECT COUNT(*) FROM BangChamCong WHERE ThangNam = @ThangNam AND DaChot = 1",
                DataProvider.TS("@ThangNam", thangNam));
            return Convert.ToInt32(kq) > 0;
        }

        // CHỐT LƯƠNG = 1 SqlTransaction: ghi bảng lương cho toàn bộ nhân viên + khóa chấm công tháng đó.
        public bool ChotLuong(string thangNam, List<BangLuongDTO> bangLuong, out string thongBaoLoi)
        {
            thongBaoLoi = "";
            using (SqlConnection conn = DataProvider.TaoKetNoi())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Kiểm tra lại trong giao dịch: tháng đã chốt thì không cho chốt lần nữa
                    SqlCommand cmdKT = new SqlCommand(
                        "SELECT COUNT(*) FROM BangChamCong WITH (UPDLOCK) WHERE ThangNam = @ThangNam AND DaChot = 1", conn, trans);
                    cmdKT.Parameters.Add(DataProvider.TS("@ThangNam", thangNam));
                    if (Convert.ToInt32(cmdKT.ExecuteScalar()) > 0)
                    {
                        trans.Rollback();
                        thongBaoLoi = "Tháng " + thangNam + " đã được chốt lương trước đó.\n" +
                                      "Giao dịch đã được hủy (Rollback), dữ liệu không bị thay đổi.";
                        return false;
                    }

                    // Bước 1: Ghi bảng lương cho từng nhân viên
                    foreach (BangLuongDTO bl in bangLuong)
                    {
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO BangLuong (MaNV, ThangNam, ThucLinh) VALUES (@MaNV, @ThangNam, @ThucLinh)", conn, trans);
                        cmd.Parameters.Add(DataProvider.TS("@MaNV", bl.MaNV));
                        cmd.Parameters.Add(DataProvider.TS("@ThangNam", thangNam));
                        cmd.Parameters.Add(DataProvider.TS("@ThucLinh", bl.ThucLinh));
                        cmd.ExecuteNonQuery();
                    }

                    // Bước 2: Khóa dữ liệu chấm công của tháng
                    SqlCommand cmdKhoa = new SqlCommand(
                        "UPDATE BangChamCong SET DaChot = 1 WHERE ThangNam = @ThangNam", conn, trans);
                    cmdKhoa.Parameters.Add(DataProvider.TS("@ThangNam", thangNam));
                    cmdKhoa.ExecuteNonQuery();

                    // Bước 3: Thành công -> Commit
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    thongBaoLoi = "Lỗi khi chốt lương: " + ex.Message + "\nGiao dịch đã được hủy (Rollback).";
                    return false;
                }
            }
        }

        // ---------- BÁO CÁO ----------

        // Bảng lương đã chốt của 1 tháng
        public List<BangLuongDTO> LayBangLuongDaChot(string thangNam)
        {
            string sql = "SELECT bl.MaNV, nv.HoTen, pb.TenPB, nv.LuongCoBan, nv.HeSoLuong, " +
                         "ISNULL(cc.SoNgayCong, 0) AS SoNgayCong, ISNULL(cc.SoGioOT, 0) AS SoGioOT, bl.ThucLinh " +
                         "FROM BangLuong bl JOIN NhanVien nv ON bl.MaNV = nv.MaNV " +
                         "LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB " +
                         "LEFT JOIN BangChamCong cc ON cc.MaNV = bl.MaNV AND cc.ThangNam = bl.ThangNam " +
                         "WHERE bl.ThangNam = @ThangNam ORDER BY bl.MaNV";
            DataTable dt = DataProvider.ExecuteQuery(sql, DataProvider.TS("@ThangNam", thangNam));
            List<BangLuongDTO> ds = new List<BangLuongDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new BangLuongDTO
                {
                    MaNV = Convert.ToInt32(r["MaNV"]),
                    HoTen = r["HoTen"].ToString(),
                    TenPB = r["TenPB"].ToString(),
                    ThangNam = thangNam,
                    LuongCoBan = Convert.ToDecimal(r["LuongCoBan"]),
                    HeSoLuong = Convert.ToDouble(r["HeSoLuong"]),
                    SoNgayCong = Convert.ToDouble(r["SoNgayCong"]),
                    SoGioOT = Convert.ToDouble(r["SoGioOT"]),
                    ThucLinh = Convert.ToDecimal(r["ThucLinh"])
                });
            }
            return ds;
        }

        // ExecuteScalar: tổng quỹ lương của tháng
        public decimal TongQuyLuong(string thangNam)
        {
            return Convert.ToDecimal(DataProvider.ExecuteScalar(
                "SELECT ISNULL(SUM(ThucLinh), 0) FROM BangLuong WHERE ThangNam = @ThangNam",
                DataProvider.TS("@ThangNam", thangNam)));
        }

        // SqlDataReader: quỹ lương theo từng phòng ban
        public List<QuyLuongPhongBanDTO> QuyLuongTheoPhongBan(string thangNam)
        {
            List<QuyLuongPhongBanDTO> ds = new List<QuyLuongPhongBanDTO>();
            string sql = "SELECT ISNULL(pb.TenPB, N'(Chưa có phòng)') AS TenPB, COUNT(*) AS SoNV, SUM(bl.ThucLinh) AS TongLuong " +
                         "FROM BangLuong bl JOIN NhanVien nv ON bl.MaNV = nv.MaNV " +
                         "LEFT JOIN PhongBan pb ON nv.MaPB = pb.MaPB " +
                         "WHERE bl.ThangNam = @ThangNam GROUP BY pb.TenPB ORDER BY TongLuong DESC";
            using (SqlConnection conn = DataProvider.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(DataProvider.TS("@ThangNam", thangNam));
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ds.Add(new QuyLuongPhongBanDTO
                        {
                            TenPB = reader.GetString(0),
                            SoNhanVien = reader.GetInt32(1),
                            TongLuong = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return ds;
        }

        // Tháng gần nhất đã chốt lương (dùng cho màn hình chính)
        public string ThangChotGanNhat()
        {
            object kq = DataProvider.ExecuteScalar(
                "SELECT TOP 1 ThangNam FROM BangLuong " +
                "ORDER BY RIGHT(ThangNam, 4) DESC, LEFT(ThangNam, 2) DESC");
            return kq == null || kq == DBNull.Value ? "" : kq.ToString();
        }
    }
}
