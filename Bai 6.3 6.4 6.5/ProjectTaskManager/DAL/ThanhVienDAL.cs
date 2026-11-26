using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.DAL
{
    public class ThanhVienDAL
    {
        public List<ThanhVienDTO> LayTatCa()
        {
            List<ThanhVienDTO> list = new List<ThanhVienDTO>();
            string sql = "SELECT MaThanhVien, HoTen, Email, ChuyenMon FROM ThanhVien ORDER BY HoTen ASC";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ThanhVienDTO
                {
                    MaThanhVien = Convert.ToInt32(row["MaThanhVien"]),
                    HoTen = row["HoTen"].ToString(),
                    Email = row["Email"].ToString(),
                    ChuyenMon = row["ChuyenMon"]?.ToString()
                });
            }
            return list;
        }

        public ThanhVienDTO LayTheoMa(int maThanhVien)
        {
            string sql = "SELECT MaThanhVien, HoTen, Email, ChuyenMon FROM ThanhVien WHERE MaThanhVien = @Ma";
            SqlParameter p = new SqlParameter("@Ma", maThanhVien);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new ThanhVienDTO
                {
                    MaThanhVien = Convert.ToInt32(row["MaThanhVien"]),
                    HoTen = row["HoTen"].ToString(),
                    Email = row["Email"].ToString(),
                    ChuyenMon = row["ChuyenMon"]?.ToString()
                };
            }
            return null;
        }

        public bool KiemTraEmail(string email, int maThanhVienBoQua = 0)
        {
            string sql = "SELECT COUNT(*) FROM ThanhVien WHERE Email = @Email AND MaThanhVien != @MaBoQua";
            SqlParameter[] pars = new[]
            {
                new SqlParameter("@Email", email ?? ""),
                new SqlParameter("@MaBoQua", maThanhVienBoQua)
            };
            int count = Convert.ToInt32(DataProvider.ExecuteScalar(sql, pars));
            return count > 0;
        }

        public int Them(ThanhVienDTO tv)
        {
            string sql = @"
                INSERT INTO ThanhVien (HoTen, Email, ChuyenMon)
                VALUES (@HoTen, @Email, @ChuyenMon);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@HoTen", tv.HoTen ?? (object)DBNull.Value),
                new SqlParameter("@Email", tv.Email ?? (object)DBNull.Value),
                new SqlParameter("@ChuyenMon", tv.ChuyenMon ?? (object)DBNull.Value)
            };

            object res = DataProvider.ExecuteScalar(sql, pars);
            return res != null ? Convert.ToInt32(res) : 0;
        }

        public bool Sua(ThanhVienDTO tv)
        {
            string sql = @"
                UPDATE ThanhVien
                SET HoTen = @HoTen,
                    Email = @Email,
                    ChuyenMon = @ChuyenMon
                WHERE MaThanhVien = @Ma";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@Ma", tv.MaThanhVien),
                new SqlParameter("@HoTen", tv.HoTen ?? (object)DBNull.Value),
                new SqlParameter("@Email", tv.Email ?? (object)DBNull.Value),
                new SqlParameter("@ChuyenMon", tv.ChuyenMon ?? (object)DBNull.Value)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Xoa(int maThanhVien)
        {
            string sql = "DELETE FROM ThanhVien WHERE MaThanhVien = @Ma";
            SqlParameter p = new SqlParameter("@Ma", maThanhVien);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }
    }
}
