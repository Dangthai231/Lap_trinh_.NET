using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GarageManager.DAL
{
    public static class DataProvider
    {
        private const string TEN_CSDL = "GarageDB";
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

            ConnectionStringSettings cauHinh = ConfigurationManager.ConnectionStrings[TEN_CSDL];
            if (cauHinh != null && !string.IsNullOrWhiteSpace(cauHinh.ConnectionString))
            {
                dsThu.Add(cauHinh.ConnectionString);
            }

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

            throw new Exception($"Không thể kết nối đến CSDL '{TEN_CSDL}'.\nChi tiết lỗi: {loiCuoi}");
        }

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

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
    }
}
