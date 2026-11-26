using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.DAL
{
    public class BaoCaoDAL
    {
        /// <summary>
        /// Yêu cầu 3: Thống kê tỷ lệ % hoàn thành công việc của từng thành viên trong dự án
        /// bằng câu lệnh GROUP BY kết hợp tính toán số task hoàn thành / tổng task.
        /// </summary>
        public List<ThongKeThanhVienDTO> ThongKeTheoThanhVien(int? maDuAn = null)
        {
            List<ThongKeThanhVienDTO> list = new List<ThongKeThanhVienDTO>();
            List<SqlParameter> pars = new List<SqlParameter>();

            string sql = @"
                SELECT tv.MaThanhVien, tv.HoTen, tv.Email, tv.ChuyenMon,
                       COUNT(c.MaTask) AS TongTask,
                       SUM(CASE WHEN c.TrangThai = N'Done' THEN 1 ELSE 0 END) AS TaskHoanThanh,
                       SUM(CASE WHEN c.TrangThai IN (N'To Do', N'In Progress', N'Review') THEN 1 ELSE 0 END) AS TaskDangLam,
                       SUM(CASE WHEN c.HanNop IS NOT NULL AND c.HanNop < GETDATE() AND c.TrangThai <> N'Done' THEN 1 ELSE 0 END) AS TaskTreHan
                FROM ThanhVien tv
                INNER JOIN PhanCong pc ON tv.MaThanhVien = pc.MaThanhVien
                INNER JOIN CongViec c ON pc.MaTask = c.MaTask
                WHERE 1 = 1";

            if (maDuAn.HasValue && maDuAn.Value > 0)
            {
                sql += " AND c.MaDuAn = @MaDuAn";
                pars.Add(new SqlParameter("@MaDuAn", maDuAn.Value));
            }

            sql += @"
                GROUP BY tv.MaThanhVien, tv.HoTen, tv.Email, tv.ChuyenMon
                ORDER BY TaskHoanThanh DESC, TongTask DESC";

            DataTable dt = DataProvider.ExecuteQuery(sql, pars.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ThongKeThanhVienDTO
                {
                    MaThanhVien = Convert.ToInt32(row["MaThanhVien"]),
                    HoTen = row["HoTen"].ToString(),
                    Email = row["Email"].ToString(),
                    ChuyenMon = row["ChuyenMon"]?.ToString(),
                    TongTask = Convert.ToInt32(row["TongTask"]),
                    TaskHoanThanh = Convert.ToInt32(row["TaskHoanThanh"]),
                    TaskDangLam = Convert.ToInt32(row["TaskDangLam"]),
                    TaskTreHan = Convert.ToInt32(row["TaskTreHan"])
                });
            }

            return list;
        }

        /// <summary>
        /// Yêu cầu 3: Tính tỷ lệ % hoàn thành công việc của 1 thành viên trong dự án bằng ExecuteScalar
        /// </summary>
        public double TinhTiLeHoanThanhThanhVien(int maThanhVien, int? maDuAn = null)
        {
            List<SqlParameter> pars = new List<SqlParameter>
            {
                new SqlParameter("@MaTV", maThanhVien)
            };

            string sql = @"
                SELECT CAST(SUM(CASE WHEN c.TrangThai = N'Done' THEN 1 ELSE 0 END) * 100.0 / NULLIF(COUNT(c.MaTask), 0) AS FLOAT)
                FROM PhanCong pc
                INNER JOIN CongViec c ON pc.MaTask = c.MaTask
                WHERE pc.MaThanhVien = @MaTV";

            if (maDuAn.HasValue && maDuAn.Value > 0)
            {
                sql += " AND c.MaDuAn = @MaDuAn";
                pars.Add(new SqlParameter("@MaDuAn", maDuAn.Value));
            }

            // SỬ DỤNG ExecuteScalar đúng yêu cầu đề bài
            object res = DataProvider.ExecuteScalar(sql, pars.ToArray());
            if (res != null && res != DBNull.Value)
            {
                return Math.Round(Convert.ToDouble(res), 1);
            }
            return 0;
        }

        /// <summary>
        /// Thống kê tổng số lượng các task theo trạng thái phục vụ hiển thị Dashboard
        /// </summary>
        public (int Tong, int ToDo, int InProgress, int Review, int Done, int TreHan) ThongKeTongQuan(int? maDuAn = null)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            string sql = @"
                SELECT 
                    COUNT(*) AS Tong,
                    SUM(CASE WHEN TrangThai = N'To Do' THEN 1 ELSE 0 END) AS ToDo,
                    SUM(CASE WHEN TrangThai = N'In Progress' THEN 1 ELSE 0 END) AS InProgress,
                    SUM(CASE WHEN TrangThai = N'Review' THEN 1 ELSE 0 END) AS Review,
                    SUM(CASE WHEN TrangThai = N'Done' THEN 1 ELSE 0 END) AS Done,
                    SUM(CASE WHEN HanNop IS NOT NULL AND HanNop < GETDATE() AND TrangThai <> N'Done' THEN 1 ELSE 0 END) AS TreHan
                FROM CongViec
                WHERE 1 = 1";

            if (maDuAn.HasValue && maDuAn.Value > 0)
            {
                sql += " AND MaDuAn = @MaDuAn";
                pars.Add(new SqlParameter("@MaDuAn", maDuAn.Value));
            }

            DataTable dt = DataProvider.ExecuteQuery(sql, pars.ToArray());
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                int tong = r["Tong"] == DBNull.Value ? 0 : Convert.ToInt32(r["Tong"]);
                int todo = r["ToDo"] == DBNull.Value ? 0 : Convert.ToInt32(r["ToDo"]);
                int inprog = r["InProgress"] == DBNull.Value ? 0 : Convert.ToInt32(r["InProgress"]);
                int review = r["Review"] == DBNull.Value ? 0 : Convert.ToInt32(r["Review"]);
                int done = r["Done"] == DBNull.Value ? 0 : Convert.ToInt32(r["Done"]);
                int treHan = r["TreHan"] == DBNull.Value ? 0 : Convert.ToInt32(r["TreHan"]);
                return (tong, todo, inprog, review, done, treHan);
            }

            return (0, 0, 0, 0, 0, 0);
        }
    }
}
