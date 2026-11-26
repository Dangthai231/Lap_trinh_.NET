using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.DAL
{
    public class DuAnDAL
    {
        public List<DuAnDTO> LayTatCa()
        {
            List<DuAnDTO> list = new List<DuAnDTO>();
            string sql = @"
                SELECT d.MaDuAn, d.TenDuAn, d.NgayBatDau, d.NgayKetThuc, d.TrangThai,
                       COUNT(c.MaTask) AS TongTask,
                       SUM(CASE WHEN c.TrangThai = N'Done' THEN 1 ELSE 0 END) AS TaskHoanThanh
                FROM DuAn d
                LEFT JOIN CongViec c ON d.MaDuAn = c.MaDuAn
                GROUP BY d.MaDuAn, d.TenDuAn, d.NgayBatDau, d.NgayKetThuc, d.TrangThai
                ORDER BY d.MaDuAn DESC";

            DataTable dt = DataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DuAnDTO
                {
                    MaDuAn = Convert.ToInt32(row["MaDuAn"]),
                    TenDuAn = row["TenDuAn"].ToString(),
                    NgayBatDau = row["NgayBatDau"] == DBNull.Value ? null : Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = row["NgayKetThuc"] == DBNull.Value ? null : Convert.ToDateTime(row["NgayKetThuc"]),
                    TrangThai = row["TrangThai"]?.ToString(),
                    TongTask = Convert.ToInt32(row["TongTask"]),
                    TaskHoanThanh = row["TaskHoanThanh"] == DBNull.Value ? 0 : Convert.ToInt32(row["TaskHoanThanh"])
                });
            }
            return list;
        }

        public DuAnDTO LayTheoMa(int maDuAn)
        {
            string sql = "SELECT MaDuAn, TenDuAn, NgayBatDau, NgayKetThuc, TrangThai FROM DuAn WHERE MaDuAn = @MaDuAn";
            SqlParameter p = new SqlParameter("@MaDuAn", maDuAn);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DuAnDTO
                {
                    MaDuAn = Convert.ToInt32(row["MaDuAn"]),
                    TenDuAn = row["TenDuAn"].ToString(),
                    NgayBatDau = row["NgayBatDau"] == DBNull.Value ? null : Convert.ToDateTime(row["NgayBatDau"]),
                    NgayKetThuc = row["NgayKetThuc"] == DBNull.Value ? null : Convert.ToDateTime(row["NgayKetThuc"]),
                    TrangThai = row["TrangThai"]?.ToString()
                };
            }
            return null;
        }

        public int Them(DuAnDTO duAn)
        {
            string sql = @"
                INSERT INTO DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai)
                VALUES (@TenDuAn, @NgayBatDau, @NgayKetThuc, @TrangThai);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@TenDuAn", duAn.TenDuAn ?? (object)DBNull.Value),
                new SqlParameter("@NgayBatDau", duAn.NgayBatDau.HasValue ? (object)duAn.NgayBatDau.Value : DBNull.Value),
                new SqlParameter("@NgayKetThuc", duAn.NgayKetThuc.HasValue ? (object)duAn.NgayKetThuc.Value : DBNull.Value),
                new SqlParameter("@TrangThai", duAn.TrangThai ?? (object)DBNull.Value)
            };

            object result = DataProvider.ExecuteScalar(sql, pars);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool Sua(DuAnDTO duAn)
        {
            string sql = @"
                UPDATE DuAn
                SET TenDuAn = @TenDuAn,
                    NgayBatDau = @NgayBatDau,
                    NgayKetThuc = @NgayKetThuc,
                    TrangThai = @TrangThai
                WHERE MaDuAn = @MaDuAn";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaDuAn", duAn.MaDuAn),
                new SqlParameter("@TenDuAn", duAn.TenDuAn ?? (object)DBNull.Value),
                new SqlParameter("@NgayBatDau", duAn.NgayBatDau.HasValue ? (object)duAn.NgayBatDau.Value : DBNull.Value),
                new SqlParameter("@NgayKetThuc", duAn.NgayKetThuc.HasValue ? (object)duAn.NgayKetThuc.Value : DBNull.Value),
                new SqlParameter("@TrangThai", duAn.TrangThai ?? (object)DBNull.Value)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Xoa(int maDuAn)
        {
            string sql = "DELETE FROM DuAn WHERE MaDuAn = @MaDuAn";
            SqlParameter p = new SqlParameter("@MaDuAn", maDuAn);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }
    }
}
