using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using GarageManager.DTO;

namespace GarageManager.DAL
{
    public class KhachHangDAL
    {
        public List<KhachHangDTO> LayTatCa()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string sql = "SELECT MaKH, TenKH, DienThoai, DiaChi FROM KhachHang ORDER BY TenKH ASC";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new KhachHangDTO
                {
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"]?.ToString(),
                    DiaChi = r["DiaChi"]?.ToString()
                });
            }
            return list;
        }

        public KhachHangDTO LayTheoMa(int maKH)
        {
            string sql = "SELECT MaKH, TenKH, DienThoai, DiaChi FROM KhachHang WHERE MaKH = @MaKH";
            SqlParameter p = new SqlParameter("@MaKH", maKH);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new KhachHangDTO
                {
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"]?.ToString(),
                    DiaChi = r["DiaChi"]?.ToString()
                };
            }
            return null;
        }

        public KhachHangDTO LayTheoDienThoai(string sdt)
        {
            string sql = "SELECT MaKH, TenKH, DienThoai, DiaChi FROM KhachHang WHERE DienThoai = @DienThoai";
            SqlParameter p = new SqlParameter("@DienThoai", sdt ?? "");
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new KhachHangDTO
                {
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"]?.ToString(),
                    DiaChi = r["DiaChi"]?.ToString()
                };
            }
            return null;
        }

        public int Them(KhachHangDTO kh)
        {
            string sql = @"
                INSERT INTO KhachHang (TenKH, DienThoai, DiaChi)
                VALUES (@TenKH, @DienThoai, @DiaChi);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@TenKH", kh.TenKH ?? (object)DBNull.Value),
                new SqlParameter("@DienThoai", kh.DienThoai ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", kh.DiaChi ?? (object)DBNull.Value)
            };

            object res = DataProvider.ExecuteScalar(sql, pars);
            return res != null ? Convert.ToInt32(res) : 0;
        }

        public bool Sua(KhachHangDTO kh)
        {
            string sql = @"
                UPDATE KhachHang
                SET TenKH = @TenKH,
                    DienThoai = @DienThoai,
                    DiaChi = @DiaChi
                WHERE MaKH = @MaKH";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.TenKH ?? (object)DBNull.Value),
                new SqlParameter("@DienThoai", kh.DienThoai ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", kh.DiaChi ?? (object)DBNull.Value)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Xoa(int maKH)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            SqlParameter p = new SqlParameter("@MaKH", maKH);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }
    }
}
