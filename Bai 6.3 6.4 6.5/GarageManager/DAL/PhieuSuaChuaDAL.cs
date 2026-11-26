using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using GarageManager.DTO;

namespace GarageManager.DAL
{
    public class PhieuSuaChuaDAL
    {
        public List<PhieuSuaChuaDTO> LayDanhSach(string trangThai = null, string timKiem = null)
        {
            List<PhieuSuaChuaDTO> list = new List<PhieuSuaChuaDTO>();
            List<SqlParameter> pars = new List<SqlParameter>();

            string sql = @"
                SELECT p.MaPhieu, p.BienSo, x.HieuXe, kh.TenKH, kh.DienThoai,
                       p.NgayNhan, p.NoiDungSua, p.TongTien, p.TrangThai
                FROM PhieuSuaChua p
                INNER JOIN Xe x ON p.BienSo = x.BienSo
                INNER JOIN KhachHang kh ON x.MaKH = kh.MaKH
                WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(trangThai) && trangThai != "Tất cả")
            {
                sql += " AND p.TrangThai = @TrangThai";
                pars.Add(new SqlParameter("@TrangThai", trangThai));
            }

            if (!string.IsNullOrWhiteSpace(timKiem))
            {
                sql += " AND (p.BienSo LIKE @TimKiem OR kh.TenKH LIKE @TimKiem OR kh.DienThoai LIKE @TimKiem)";
                pars.Add(new SqlParameter("@TimKiem", $"%{timKiem}%"));
            }

            sql += " ORDER BY p.MaPhieu DESC";

            DataTable dt = DataProvider.ExecuteQuery(sql, pars.ToArray());
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new PhieuSuaChuaDTO
                {
                    MaPhieu = Convert.ToInt32(r["MaPhieu"]),
                    BienSo = r["BienSo"].ToString(),
                    HieuXe = r["HieuXe"]?.ToString(),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"]?.ToString(),
                    NgayNhan = Convert.ToDateTime(r["NgayNhan"]),
                    NoiDungSua = r["NoiDungSua"]?.ToString(),
                    TongTien = Convert.ToDecimal(r["TongTien"]),
                    TrangThai = r["TrangThai"].ToString()
                });
            }

            return list;
        }

        public PhieuSuaChuaDTO LayTheoMa(int maPhieu)
        {
            string sql = @"
                SELECT p.MaPhieu, p.BienSo, x.HieuXe, kh.TenKH, kh.DienThoai,
                       p.NgayNhan, p.NoiDungSua, p.TongTien, p.TrangThai
                FROM PhieuSuaChua p
                INNER JOIN Xe x ON p.BienSo = x.BienSo
                INNER JOIN KhachHang kh ON x.MaKH = kh.MaKH
                WHERE p.MaPhieu = @MaPhieu";

            SqlParameter p = new SqlParameter("@MaPhieu", maPhieu);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new PhieuSuaChuaDTO
                {
                    MaPhieu = Convert.ToInt32(r["MaPhieu"]),
                    BienSo = r["BienSo"].ToString(),
                    HieuXe = r["HieuXe"]?.ToString(),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"]?.ToString(),
                    NgayNhan = Convert.ToDateTime(r["NgayNhan"]),
                    NoiDungSua = r["NoiDungSua"]?.ToString(),
                    TongTien = Convert.ToDecimal(r["TongTien"]),
                    TrangThai = r["TrangThai"].ToString()
                };
            }
            return null;
        }

        public List<ChiTietSuaChuaDTO> LayChiTietTheoPhieu(int maPhieu)
        {
            List<ChiTietSuaChuaDTO> list = new List<ChiTietSuaChuaDTO>();
            string sql = @"
                SELECT ct.MaPhieu, ct.MaPhuTung, pt.TenPhuTung, pt.DonGia, ct.SoLuong, ct.TienCong
                FROM ChiTietSuaChua ct
                INNER JOIN PhuTung pt ON ct.MaPhuTung = pt.MaPhuTung
                WHERE ct.MaPhieu = @MaPhieu";

            SqlParameter p = new SqlParameter("@MaPhieu", maPhieu);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChiTietSuaChuaDTO
                {
                    MaPhieu = Convert.ToInt32(r["MaPhieu"]),
                    MaPhuTung = Convert.ToInt32(r["MaPhuTung"]),
                    TenPhuTung = r["TenPhuTung"].ToString(),
                    DonGia = Convert.ToDecimal(r["DonGia"]),
                    SoLuong = Convert.ToInt32(r["SoLuong"]),
                    TienCong = Convert.ToDecimal(r["TienCong"])
                });
            }
            return list;
        }

        /// <summary>
        /// Yêu cầu 2: Lập phiếu sửa chữa & Thay thế phụ tùng bằng SqlTransaction:
        /// 1. Tạo bản ghi PhieuSuaChua.
        /// 2. Tạo các bản ghi ChiTietSuaChua.
        /// 3. Trừ số lượng phụ tùng tương ứng trong bảng PhuTung (SoLuongTon -= SoLuong).
        /// 4. Nếu phụ tùng không đủ số lượng trong kho -> trans.Rollback() và xuất thông báo.
        /// </summary>
        public int LapPhieuSuaChuaTransaction(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> chiTietList)
        {
            using (SqlConnection conn = DataProvider.TaoKetNoi())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra tồn kho trước cho tất cả phụ tùng trong phiếu
                        foreach (var ct in chiTietList)
                        {
                            string sqlCheck = "SELECT TenPhuTung, SoLuongTon FROM PhuTung WHERE MaPhuTung = @MaPhuTung";
                            using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, trans))
                            {
                                cmdCheck.Parameters.Add(new SqlParameter("@MaPhuTung", ct.MaPhuTung));
                                using (SqlDataReader reader = cmdCheck.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string tenPT = reader["TenPhuTung"].ToString();
                                        int tonKho = Convert.ToInt32(reader["SoLuongTon"]);
                                        if (tonKho < ct.SoLuong)
                                        {
                                            reader.Close();
                                            // 4. Nếu phụ tùng không đủ số lượng -> trans.Rollback() và ném ngoại lệ
                                            trans.Rollback();
                                            throw new InvalidOperationException($"Phụ tùng '{tenPT}' không đủ số lượng trong kho! (Yêu cầu: {ct.SoLuong}, Tồn kho: {tonKho})");
                                        }
                                    }
                                    else
                                    {
                                        reader.Close();
                                        trans.Rollback();
                                        throw new InvalidOperationException($"Không tìm thấy phụ tùng có mã {ct.MaPhuTung}!");
                                    }
                                }
                            }
                        }

                        // 2. Tạo bản ghi PhieuSuaChua
                        string sqlPhieu = @"
                            INSERT INTO PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TongTien, TrangThai)
                            VALUES (@BienSo, @NgayNhan, @NoiDungSua, @TongTien, @TrangThai);
                            SELECT SCOPE_IDENTITY();";

                        int maPhieuMoi = 0;
                        using (SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, trans))
                        {
                            cmdPhieu.Parameters.Add(new SqlParameter("@BienSo", phieu.BienSo.Trim().ToUpper()));
                            cmdPhieu.Parameters.Add(new SqlParameter("@NgayNhan", phieu.NgayNhan));
                            cmdPhieu.Parameters.Add(new SqlParameter("@NoiDungSua", phieu.NoiDungSua ?? (object)DBNull.Value));
                            cmdPhieu.Parameters.Add(new SqlParameter("@TongTien", phieu.TongTien));
                            cmdPhieu.Parameters.Add(new SqlParameter("@TrangThai", phieu.TrangThai ?? "Đang sửa"));

                            object res = cmdPhieu.ExecuteScalar();
                            maPhieuMoi = Convert.ToInt32(res);
                        }

                        // 3. Tạo các bản ghi ChiTietSuaChua và trừ tồn kho phụ tùng
                        string sqlCT = @"
                            INSERT INTO ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong)
                            VALUES (@MaPhieu, @MaPhuTung, @SoLuong, @TienCong)";

                        string sqlTruKho = @"
                            UPDATE PhuTung
                            SET SoLuongTon = SoLuongTon - @SoLuong
                            WHERE MaPhuTung = @MaPhuTung";

                        foreach (var ct in chiTietList)
                        {
                            using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans))
                            {
                                cmdCT.Parameters.Add(new SqlParameter("@MaPhieu", maPhieuMoi));
                                cmdCT.Parameters.Add(new SqlParameter("@MaPhuTung", ct.MaPhuTung));
                                cmdCT.Parameters.Add(new SqlParameter("@SoLuong", ct.SoLuong));
                                cmdCT.Parameters.Add(new SqlParameter("@TienCong", ct.TienCong));
                                cmdCT.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdTru = new SqlCommand(sqlTruKho, conn, trans))
                            {
                                cmdTru.Parameters.Add(new SqlParameter("@MaPhuTung", ct.MaPhuTung));
                                cmdTru.Parameters.Add(new SqlParameter("@SoLuong", ct.SoLuong));
                                cmdTru.ExecuteNonQuery();
                            }
                        }

                        // Hoàn tất Transaction
                        trans.Commit();
                        return maPhieuMoi;
                    }
                    catch
                    {
                        // Rollback nếu chưa rollback
                        try { trans.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Yêu cầu 3: Thanh toán phiếu sửa chữa -> Chuyển trạng thái sang "Đã thanh toán"
        /// </summary>
        public bool ChuyenTrangThaiThanhToan(int maPhieu)
        {
            string sql = @"
                UPDATE PhieuSuaChua
                SET TrangThai = N'Đã thanh toán'
                WHERE MaPhieu = @MaPhieu";

            SqlParameter p = new SqlParameter("@MaPhieu", maPhieu);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }

        public bool CapNhatTrangThai(int maPhieu, string trangThai)
        {
            string sql = @"
                UPDATE PhieuSuaChua
                SET TrangThai = @TrangThai
                WHERE MaPhieu = @MaPhieu";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@TrangThai", trangThai)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Xoa(int maPhieu)
        {
            string sql = "DELETE FROM PhieuSuaChua WHERE MaPhieu = @MaPhieu";
            SqlParameter p = new SqlParameter("@MaPhieu", maPhieu);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }

        public (int TongPhieu, int DangSua, int DaHoanThanh, int DaThanhToan, decimal TongDoanhThu) ThongKeTongQuan()
        {
            string sql = @"
                SELECT 
                    COUNT(*) AS TongPhieu,
                    SUM(CASE WHEN TrangThai = N'Đang sửa' THEN 1 ELSE 0 END) AS DangSua,
                    SUM(CASE WHEN TrangThai = N'Đã hoàn thành' THEN 1 ELSE 0 END) AS DaHoanThanh,
                    SUM(CASE WHEN TrangThai = N'Đã thanh toán' THEN 1 ELSE 0 END) AS DaThanhToan,
                    SUM(CASE WHEN TrangThai = N'Đã thanh toán' THEN TongTien ELSE 0 END) AS TongDoanhThu
                FROM PhieuSuaChua";

            DataTable dt = DataProvider.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return (
                    r["TongPhieu"] == DBNull.Value ? 0 : Convert.ToInt32(r["TongPhieu"]),
                    r["DangSua"] == DBNull.Value ? 0 : Convert.ToInt32(r["DangSua"]),
                    r["DaHoanThanh"] == DBNull.Value ? 0 : Convert.ToInt32(r["DaHoanThanh"]),
                    r["DaThanhToan"] == DBNull.Value ? 0 : Convert.ToInt32(r["DaThanhToan"]),
                    r["TongDoanhThu"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TongDoanhThu"])
                );
            }

            return (0, 0, 0, 0, 0);
        }
    }
}
