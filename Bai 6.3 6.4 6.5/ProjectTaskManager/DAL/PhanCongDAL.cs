using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.DAL
{
    public class PhanCongDAL
    {
        public List<PhanCongDTO> LayTheoTask(int maTask)
        {
            List<PhanCongDTO> list = new List<PhanCongDTO>();
            string sql = @"
                SELECT pc.MaTask, pc.MaThanhVien, tv.HoTen, tv.Email, tv.ChuyenMon, pc.NgayGiao
                FROM PhanCong pc
                INNER JOIN ThanhVien tv ON pc.MaThanhVien = tv.MaThanhVien
                WHERE pc.MaTask = @MaTask";

            SqlParameter p = new SqlParameter("@MaTask", maTask);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PhanCongDTO
                {
                    MaTask = Convert.ToInt32(row["MaTask"]),
                    MaThanhVien = Convert.ToInt32(row["MaThanhVien"]),
                    HoTen = row["HoTen"].ToString(),
                    Email = row["Email"].ToString(),
                    ChuyenMon = row["ChuyenMon"]?.ToString(),
                    NgayGiao = Convert.ToDateTime(row["NgayGiao"])
                });
            }
            return list;
        }

        public List<int> LayDanhSachMaThanhVienTheoTask(int maTask)
        {
            List<int> list = new List<int>();
            string sql = "SELECT MaThanhVien FROM PhanCong WHERE MaTask = @MaTask";
            SqlParameter p = new SqlParameter("@MaTask", maTask);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(Convert.ToInt32(row["MaThanhVien"]));
            }
            return list;
        }

        /// <summary>
        /// Giao việc cho một hoặc nhiều thành viên tham gia giải quyết Task.
        /// Sử dụng Transaction để xóa phân công cũ và gán danh sách thành viên mới.
        /// </summary>
        public bool CapNhatPhanCongChoTask(int maTask, List<int> dsMaThanhVien)
        {
            using (SqlConnection conn = DataProvider.TaoKetNoi())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Xóa phân công hiện tại của task
                        string sqlDelete = "DELETE FROM PhanCong WHERE MaTask = @MaTask";
                        using (SqlCommand cmdDel = new SqlCommand(sqlDelete, conn, trans))
                        {
                            cmdDel.Parameters.Add(new SqlParameter("@MaTask", maTask));
                            cmdDel.ExecuteNonQuery();
                        }

                        // 2. Thêm từng thành viên mới
                        if (dsMaThanhVien != null && dsMaThanhVien.Count > 0)
                        {
                            string sqlInsert = "INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao) VALUES (@MaTask, @MaThanhVien, GETDATE())";
                            foreach (int maTV in dsMaThanhVien)
                            {
                                using (SqlCommand cmdIns = new SqlCommand(sqlInsert, conn, trans))
                                {
                                    cmdIns.Parameters.Add(new SqlParameter("@MaTask", maTask));
                                    cmdIns.Parameters.Add(new SqlParameter("@MaThanhVien", maTV));
                                    cmdIns.ExecuteNonQuery();
                                }
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool ThemPhanCong(int maTask, int maThanhVien)
        {
            string sql = @"
                IF NOT EXISTS (SELECT 1 FROM PhanCong WHERE MaTask = @MaTask AND MaThanhVien = @MaTV)
                BEGIN
                    INSERT INTO PhanCong (MaTask, MaThanhVien, NgayGiao)
                    VALUES (@MaTask, @MaTV, GETDATE())
                END";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaTask", maTask),
                new SqlParameter("@MaTV", maThanhVien)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool XoaPhanCong(int maTask, int maThanhVien)
        {
            string sql = "DELETE FROM PhanCong WHERE MaTask = @MaTask AND MaThanhVien = @MaTV";
            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaTask", maTask),
                new SqlParameter("@MaTV", maThanhVien)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }
    }
}
