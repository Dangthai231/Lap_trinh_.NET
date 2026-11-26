using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.DAL
{
    public class CongViecDAL
    {
        /// <summary>
        /// Lọc danh sách Task theo từng Dự án, Trạng thái và từ khóa tìm kiếm.
        /// Đồng thời lấy danh sách thành viên phân công (nối chuỗi).
        /// </summary>
        public List<CongViecDTO> LayDanhSach(int? maDuAn = null, string trangThai = null, string timKiem = null)
        {
            List<CongViecDTO> list = new List<CongViecDTO>();
            List<SqlParameter> pars = new List<SqlParameter>();

            string sql = @"
                SELECT c.MaTask, c.MaDuAn, d.TenDuAn, c.TenTask, c.MoTa, c.HanNop, c.DoUuTien, c.TrangThai,
                       STRING_AGG(tv.HoTen, N', ') AS DanhSachThanhVien
                FROM CongViec c
                INNER JOIN DuAn d ON c.MaDuAn = d.MaDuAn
                LEFT JOIN PhanCong pc ON c.MaTask = pc.MaTask
                LEFT JOIN ThanhVien tv ON pc.MaThanhVien = tv.MaThanhVien
                WHERE 1 = 1";

            if (maDuAn.HasValue && maDuAn.Value > 0)
            {
                sql += " AND c.MaDuAn = @MaDuAn";
                pars.Add(new SqlParameter("@MaDuAn", maDuAn.Value));
            }

            if (!string.IsNullOrWhiteSpace(trangThai) && trangThai != "Tất cả")
            {
                sql += " AND c.TrangThai = @TrangThai";
                pars.Add(new SqlParameter("@TrangThai", trangThai));
            }

            if (!string.IsNullOrWhiteSpace(timKiem))
            {
                sql += " AND (c.TenTask LIKE @TimKiem OR c.MoTa LIKE @TimKiem)";
                pars.Add(new SqlParameter("@TimKiem", $"%{timKiem}%"));
            }

            sql += @"
                GROUP BY c.MaTask, c.MaDuAn, d.TenDuAn, c.TenTask, c.MoTa, c.HanNop, c.DoUuTien, c.TrangThai
                ORDER BY c.MaTask DESC";

            DataTable dt = DataProvider.ExecuteQuery(sql, pars.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CongViecDTO
                {
                    MaTask = Convert.ToInt32(row["MaTask"]),
                    MaDuAn = Convert.ToInt32(row["MaDuAn"]),
                    TenDuAn = row["TenDuAn"].ToString(),
                    TenTask = row["TenTask"].ToString(),
                    MoTa = row["MoTa"]?.ToString(),
                    HanNop = row["HanNop"] == DBNull.Value ? null : Convert.ToDateTime(row["HanNop"]),
                    DoUuTien = row["DoUuTien"]?.ToString(),
                    TrangThai = row["TrangThai"].ToString(),
                    DanhSachThanhVien = row["DanhSachThanhVien"] == DBNull.Value ? "Chưa phân công" : row["DanhSachThanhVien"].ToString()
                });
            }

            return list;
        }

        public CongViecDTO LayTheoMa(int maTask)
        {
            string sql = @"
                SELECT c.MaTask, c.MaDuAn, d.TenDuAn, c.TenTask, c.MoTa, c.HanNop, c.DoUuTien, c.TrangThai,
                       STRING_AGG(tv.HoTen, N', ') AS DanhSachThanhVien
                FROM CongViec c
                INNER JOIN DuAn d ON c.MaDuAn = d.MaDuAn
                LEFT JOIN PhanCong pc ON c.MaTask = pc.MaTask
                LEFT JOIN ThanhVien tv ON pc.MaThanhVien = tv.MaThanhVien
                WHERE c.MaTask = @MaTask
                GROUP BY c.MaTask, c.MaDuAn, d.TenDuAn, c.TenTask, c.MoTa, c.HanNop, c.DoUuTien, c.TrangThai";

            SqlParameter p = new SqlParameter("@MaTask", maTask);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new CongViecDTO
                {
                    MaTask = Convert.ToInt32(row["MaTask"]),
                    MaDuAn = Convert.ToInt32(row["MaDuAn"]),
                    TenDuAn = row["TenDuAn"].ToString(),
                    TenTask = row["TenTask"].ToString(),
                    MoTa = row["MoTa"]?.ToString(),
                    HanNop = row["HanNop"] == DBNull.Value ? null : Convert.ToDateTime(row["HanNop"]),
                    DoUuTien = row["DoUuTien"]?.ToString(),
                    TrangThai = row["TrangThai"].ToString(),
                    DanhSachThanhVien = row["DanhSachThanhVien"] == DBNull.Value ? "Chưa phân công" : row["DanhSachThanhVien"].ToString()
                };
            }
            return null;
        }

        public int Them(CongViecDTO task)
        {
            string sql = @"
                INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai)
                VALUES (@MaDuAn, @TenTask, @MoTa, @HanNop, @DoUuTien, @TrangThai);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaDuAn", task.MaDuAn),
                new SqlParameter("@TenTask", task.TenTask ?? (object)DBNull.Value),
                new SqlParameter("@MoTa", task.MoTa ?? (object)DBNull.Value),
                new SqlParameter("@HanNop", task.HanNop.HasValue ? (object)task.HanNop.Value : DBNull.Value),
                new SqlParameter("@DoUuTien", task.DoUuTien ?? (object)DBNull.Value),
                new SqlParameter("@TrangThai", string.IsNullOrWhiteSpace(task.TrangThai) ? "To Do" : task.TrangThai)
            };

            object res = DataProvider.ExecuteScalar(sql, pars);
            return res != null ? Convert.ToInt32(res) : 0;
        }

        public bool Sua(CongViecDTO task)
        {
            string sql = @"
                UPDATE CongViec
                SET MaDuAn = @MaDuAn,
                    TenTask = @TenTask,
                    MoTa = @MoTa,
                    HanNop = @HanNop,
                    DoUuTien = @DoUuTien,
                    TrangThai = @TrangThai
                WHERE MaTask = @MaTask";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaTask", task.MaTask),
                new SqlParameter("@MaDuAn", task.MaDuAn),
                new SqlParameter("@TenTask", task.TenTask ?? (object)DBNull.Value),
                new SqlParameter("@MoTa", task.MoTa ?? (object)DBNull.Value),
                new SqlParameter("@HanNop", task.HanNop.HasValue ? (object)task.HanNop.Value : DBNull.Value),
                new SqlParameter("@DoUuTien", task.DoUuTien ?? (object)DBNull.Value),
                new SqlParameter("@TrangThai", task.TrangThai ?? (object)DBNull.Value)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        /// <summary>
        /// Yêu cầu 2: Chuyển trạng thái công việc (Ví dụ: Chuyển từ "In Progress" sang "Done")
        /// -> Cập nhật cơ sở dữ liệu qua lệnh Parameterized SQL Update.
        /// </summary>
        public bool CapNhatTrangThai(int maTask, string trangThaiMoi)
        {
            string sql = @"
                UPDATE CongViec
                SET TrangThai = @TrangThai
                WHERE MaTask = @MaTask";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@MaTask", maTask),
                new SqlParameter("@TrangThai", trangThaiMoi)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Xoa(int maTask)
        {
            string sql = "DELETE FROM CongViec WHERE MaTask = @MaTask";
            SqlParameter p = new SqlParameter("@MaTask", maTask);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }

        /// <summary>
        /// Yêu cầu 3: Dùng SqlDataReader hiển thị các công việc đã quá HanNop mà TrangThai != 'Done'.
        /// Phương thức này sử dụng đúng SqlDataReader qua DataProvider.ExecuteReader để đọc stream dữ liệu.
        /// </summary>
        public List<CongViecDTO> LayCongViecTreHan(int? maDuAn = null)
        {
            List<CongViecDTO> list = new List<CongViecDTO>();
            List<SqlParameter> pars = new List<SqlParameter>();

            string sql = @"
                SELECT c.MaTask, c.MaDuAn, d.TenDuAn, c.TenTask, c.MoTa, c.HanNop, c.DoUuTien, c.TrangThai,
                       STRING_AGG(tv.HoTen, N', ') AS DanhSachThanhVien
                FROM CongViec c
                INNER JOIN DuAn d ON c.MaDuAn = d.MaDuAn
                LEFT JOIN PhanCong pc ON c.MaTask = pc.MaTask
                LEFT JOIN ThanhVien tv ON pc.MaThanhVien = tv.MaThanhVien
                WHERE c.HanNop IS NOT NULL 
                  AND c.HanNop < GETDATE() 
                  AND c.TrangThai <> N'Done'";

            if (maDuAn.HasValue && maDuAn.Value > 0)
            {
                sql += " AND c.MaDuAn = @MaDuAn";
                pars.Add(new SqlParameter("@MaDuAn", maDuAn.Value));
            }

            sql += @"
                GROUP BY c.MaTask, c.MaDuAn, d.TenDuAn, c.TenTask, c.MoTa, c.HanNop, c.DoUuTien, c.TrangThai
                ORDER BY c.HanNop ASC";

            // SỬ DỤNG SqlDataReader theo đúng yêu cầu đề bài
            DataProvider.ExecuteReader(sql, reader =>
            {
                CongViecDTO task = new CongViecDTO
                {
                    MaTask = reader.GetInt32(reader.GetOrdinal("MaTask")),
                    MaDuAn = reader.GetInt32(reader.GetOrdinal("MaDuAn")),
                    TenDuAn = reader.GetString(reader.GetOrdinal("TenDuAn")),
                    TenTask = reader.GetString(reader.GetOrdinal("TenTask")),
                    MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? "" : reader.GetString(reader.GetOrdinal("MoTa")),
                    HanNop = reader.IsDBNull(reader.GetOrdinal("HanNop")) ? null : reader.GetDateTime(reader.GetOrdinal("HanNop")),
                    DoUuTien = reader.IsDBNull(reader.GetOrdinal("DoUuTien")) ? "" : reader.GetString(reader.GetOrdinal("DoUuTien")),
                    TrangThai = reader.GetString(reader.GetOrdinal("TrangThai")),
                    DanhSachThanhVien = reader.IsDBNull(reader.GetOrdinal("DanhSachThanhVien")) ? "Chưa phân công" : reader.GetString(reader.GetOrdinal("DanhSachThanhVien"))
                };
                list.Add(task);
            }, pars.ToArray());

            return list;
        }
    }
}
