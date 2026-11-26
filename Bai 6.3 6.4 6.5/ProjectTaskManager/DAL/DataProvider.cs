using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ProjectTaskManager.DAL
{
    /// <summary>
    /// Lớp hạ tầng truy cập CSDL dùng chung.
    /// Toàn bộ câu lệnh SQL đều sử dụng Parameterized SQL (SqlParameter) để chống SQL Injection.
    /// Hỗ trợ: ExecuteQuery, ExecuteNonQuery, ExecuteScalar, ExecuteReader.
    /// </summary>
    public static class DataProvider
    {
        private const string TEN_CSDL = "ProjectTaskDB";
        private static string chuoiKetNoi;

        public static string TenServer { get; private set; }

        public static string ChuoiKetNoi
        {
            get
            {
                if (chuoiKetNoi == null)
                    chuoiKetNoi = TimChuoiKetNoi();
                return chuoiKetNoi;
            }
        }

        private static string TimChuoiKetNoi()
        {
            List<string> dsThu = new List<string>();

            // 1. Thử chuỗi cấu hình trong App.config
            ConnectionStringSettings cauHinh = ConfigurationManager.ConnectionStrings[TEN_CSDL];
            if (cauHinh != null && !string.IsNullOrWhiteSpace(cauHinh.ConnectionString))
            {
                dsThu.Add(cauHinh.ConnectionString);
            }

            // 2. Thử các server thông dụng trên máy
            string[] servers = new[] { @".\SQLEXPRESS", ".", @"(localdb)\MSSQLLocalDB", "localhost" };
            foreach (string s in servers)
            {
                dsThu.Add($"Data Source={s};Initial Catalog={TEN_CSDL};Integrated Security=True;TrustServerCertificate=True");
            }

            string loiCuoi = "";
            foreach (string connStr in dsThu)
            {
                try
                {
                    SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(connStr)
                    {
                        ConnectTimeout = 4
                    };

                    using (SqlConnection conn = new SqlConnection(b.ConnectionString))
                    {
                        conn.Open();
                        TenServer = b.DataSource;
                        return b.ConnectionString;
                    }
                }
                catch (Exception ex)
                {
                    loiCuoi = ex.Message;
                }
            }

            throw new Exception($"Không thể kết nối đến CSDL '{TEN_CSDL}'.\n\n" +
                                "Vui lòng kiểm tra:\n" +
                                "1. SQL Server đã khởi động.\n" +
                                "2. Đã chạy script Database\\ScriptDB_ProjectTaskDB.sql.\n" +
                                $"Chi tiết lỗi: {loiCuoi}");
        }

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

        /// <summary>
        /// Thực thi truy vấn SELECT trả về DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] thamSo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Thực thi INSERT / UPDATE / DELETE trả về số dòng ảnh hưởng
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Thực thi truy vấn trả về giá trị đơn (dùng cho COUNT, SUM, MAX, ExecuteScalar)
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Thực thi truy vấn dùng SqlDataReader xử lý từng dòng dữ liệu (Streaming reader)
        /// Đáp ứng yêu cầu: 'Dùng SqlDataReader hiển thị các công việc đã quá HanNop mà TrangThai != Done'
        /// </summary>
        public static void ExecuteReader(string sql, Action<SqlDataReader> rowAction, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null && thamSo.Length > 0)
                    cmd.Parameters.AddRange(thamSo);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        rowAction(reader);
                    }
                }
            }
        }
    }
}
