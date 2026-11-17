using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyBanHang.DAL
{
    // Lớp dùng chung để kết nối và thực thi câu lệnh SQL.
    // Mọi câu lệnh đều truyền giá trị qua SqlParameter -> chống SQL Injection.
    public static class DataProvider
    {
        private const string TEN_CSDL = "SalesDB";
        private static string chuoiKetNoi;

        // Tên server đang kết nối (hiện ở thanh trạng thái)
        public static string TenServer { get; private set; }

        public static string ChuoiKetNoi
        {
            get
            {
                if (chuoiKetNoi == null) chuoiKetNoi = TimChuoiKetNoi();
                return chuoiKetNoi;
            }
        }

        // Thử chuỗi kết nối trong App.config trước, nếu không được thì tự thử các tên server phổ biến
        private static string TimChuoiKetNoi()
        {
            List<string> dsThu = new List<string>();
            ConnectionStringSettings cauHinh = ConfigurationManager.ConnectionStrings[TEN_CSDL];
            if (cauHinh != null && !string.IsNullOrWhiteSpace(cauHinh.ConnectionString))
                dsThu.Add(cauHinh.ConnectionString);

            foreach (string server in new[] { @".\SQLEXPRESS", ".", @"(localdb)\MSSQLLocalDB", "localhost" })
            {
                dsThu.Add("Data Source=" + server + ";Initial Catalog=" + TEN_CSDL +
                          ";Integrated Security=True;TrustServerCertificate=True");
            }

            string loiCuoi = "";
            foreach (string chuoi in dsThu)
            {
                SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(chuoi);
                b.ConnectTimeout = 4;
                try
                {
                    using (SqlConnection conn = new SqlConnection(b.ConnectionString))
                    {
                        conn.Open();
                        TenServer = b.DataSource;
                        return chuoi;
                    }
                }
                catch (Exception ex)
                {
                    loiCuoi = ex.Message;
                }
            }

            throw new Exception("Không kết nối được tới CSDL " + TEN_CSDL + ".\n\n" +
                                "Hãy kiểm tra:\n" +
                                "1. SQL Server đã được bật.\n" +
                                "2. Đã chạy file Database\\ScriptDB.sql để tạo CSDL.\n" +
                                "3. Nếu tên server khác, sửa chuỗi kết nối trong file App.config.\n\n" +
                                "Chi tiết lỗi: " + loiCuoi);
        }

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

        // SELECT -> DataTable
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] thamSo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null) cmd.Parameters.AddRange(thamSo);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // INSERT / UPDATE / DELETE -> số dòng bị ảnh hưởng
        public static int ExecuteNonQuery(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null) cmd.Parameters.AddRange(thamSo);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Lấy 1 giá trị duy nhất (COUNT, SUM...)
        public static object ExecuteScalar(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (thamSo != null) cmd.Parameters.AddRange(thamSo);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // Tạo tham số, đổi null thành DBNull
        public static SqlParameter TS(string ten, object giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }
    }
}
