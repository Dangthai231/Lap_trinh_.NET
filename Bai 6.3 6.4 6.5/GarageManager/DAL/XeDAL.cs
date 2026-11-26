using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using GarageManager.DTO;

namespace GarageManager.DAL
{
    public class XeDAL
    {
        public List<XeDTO> LayTatCa()
        {
            List<XeDTO> list = new List<XeDTO>();
            string sql = @"
                SELECT x.BienSo, x.MaKH, kh.TenKH, kh.DienThoai, x.HieuXe, x.NamSanXuat
                FROM Xe x
                INNER JOIN KhachHang kh ON x.MaKH = kh.MaKH
                ORDER BY x.BienSo ASC";

            DataTable dt = DataProvider.ExecuteQuery(sql);
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new XeDTO
                {
                    BienSo = r["BienSo"].ToString(),
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"]?.ToString(),
                    HieuXe = r["HieuXe"]?.ToString(),
                    NamSanXuat = r["NamSanXuat"] == DBNull.Value ? null : Convert.ToInt32(r["NamSanXuat"])
                });
            }
            return list;
        }

        /// <summary>
        /// Yêu cầu 1: Tra cứu biển số xe bằng SqlParameter.
        /// </summary>
        public XeDTO TraCuuBienSo(string bienSo)
        {
            string sql = @"
                SELECT x.BienSo, x.MaKH, kh.TenKH, kh.DienThoai, x.HieuXe, x.NamSanXuat
                FROM Xe x
                INNER JOIN KhachHang kh ON x.MaKH = kh.MaKH
                WHERE UPPER(REPLACE(x.BienSo, ' ', '')) = UPPER(REPLACE(@BienSo, ' ', ''))";

            // Sử dụng SqlParameter theo đúng yêu cầu đề bài
            SqlParameter p = new SqlParameter("@BienSo", bienSo?.Trim() ?? "");
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new XeDTO
                {
                    BienSo = r["BienSo"].ToString(),
                    MaKH = Convert.ToInt32(r["MaKH"]),
                    TenKH = r["TenKH"].ToString(),
                    DienThoai = r["DienThoai"]?.ToString(),
                    HieuXe = r["HieuXe"]?.ToString(),
                    NamSanXuat = r["NamSanXuat"] == DBNull.Value ? null : Convert.ToInt32(r["NamSanXuat"])
                };
            }
            return null;
        }

        public bool Them(XeDTO xe)
        {
            string sql = @"
                INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat)
                VALUES (@BienSo, @MaKH, @HieuXe, @NamSanXuat)";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@BienSo", xe.BienSo.Trim().ToUpper()),
                new SqlParameter("@MaKH", xe.MaKH),
                new SqlParameter("@HieuXe", xe.HieuXe ?? (object)DBNull.Value),
                new SqlParameter("@NamSanXuat", xe.NamSanXuat.HasValue ? (object)xe.NamSanXuat.Value : DBNull.Value)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Sua(XeDTO xe)
        {
            string sql = @"
                UPDATE Xe
                SET MaKH = @MaKH,
                    HieuXe = @HieuXe,
                    NamSanXuat = @NamSanXuat
                WHERE BienSo = @BienSo";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@BienSo", xe.BienSo.Trim().ToUpper()),
                new SqlParameter("@MaKH", xe.MaKH),
                new SqlParameter("@HieuXe", xe.HieuXe ?? (object)DBNull.Value),
                new SqlParameter("@NamSanXuat", xe.NamSanXuat.HasValue ? (object)xe.NamSanXuat.Value : DBNull.Value)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Xoa(string bienSo)
        {
            string sql = "DELETE FROM Xe WHERE BienSo = @BienSo";
            SqlParameter p = new SqlParameter("@BienSo", bienSo);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }
    }
}
