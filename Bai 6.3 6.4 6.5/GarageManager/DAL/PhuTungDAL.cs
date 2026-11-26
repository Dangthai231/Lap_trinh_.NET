using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using GarageManager.DTO;

namespace GarageManager.DAL
{
    public class PhuTungDAL
    {
        public List<PhuTungDTO> LayTatCa()
        {
            List<PhuTungDTO> list = new List<PhuTungDTO>();
            string sql = "SELECT MaPhuTung, TenPhuTung, DonGia, SoLuongTon FROM PhuTung ORDER BY TenPhuTung ASC";
            DataTable dt = DataProvider.ExecuteQuery(sql);
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new PhuTungDTO
                {
                    MaPhuTung = Convert.ToInt32(r["MaPhuTung"]),
                    TenPhuTung = r["TenPhuTung"].ToString(),
                    DonGia = Convert.ToDecimal(r["DonGia"]),
                    SoLuongTon = Convert.ToInt32(r["SoLuongTon"])
                });
            }
            return list;
        }

        public PhuTungDTO LayTheoMa(int maPhuTung)
        {
            string sql = "SELECT MaPhuTung, TenPhuTung, DonGia, SoLuongTon FROM PhuTung WHERE MaPhuTung = @Ma";
            SqlParameter p = new SqlParameter("@Ma", maPhuTung);
            DataTable dt = DataProvider.ExecuteQuery(sql, p);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new PhuTungDTO
                {
                    MaPhuTung = Convert.ToInt32(r["MaPhuTung"]),
                    TenPhuTung = r["TenPhuTung"].ToString(),
                    DonGia = Convert.ToDecimal(r["DonGia"]),
                    SoLuongTon = Convert.ToInt32(r["SoLuongTon"])
                };
            }
            return null;
        }

        public int Them(PhuTungDTO pt)
        {
            string sql = @"
                INSERT INTO PhuTung (TenPhuTung, DonGia, SoLuongTon)
                VALUES (@TenPhuTung, @DonGia, @SoLuongTon);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@TenPhuTung", pt.TenPhuTung ?? (object)DBNull.Value),
                new SqlParameter("@DonGia", pt.DonGia),
                new SqlParameter("@SoLuongTon", pt.SoLuongTon)
            };

            object res = DataProvider.ExecuteScalar(sql, pars);
            return res != null ? Convert.ToInt32(res) : 0;
        }

        public bool Sua(PhuTungDTO pt)
        {
            string sql = @"
                UPDATE PhuTung
                SET TenPhuTung = @TenPhuTung,
                    DonGia = @DonGia,
                    SoLuongTon = @SoLuongTon
                WHERE MaPhuTung = @Ma";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@Ma", pt.MaPhuTung),
                new SqlParameter("@TenPhuTung", pt.TenPhuTung ?? (object)DBNull.Value),
                new SqlParameter("@DonGia", pt.DonGia),
                new SqlParameter("@SoLuongTon", pt.SoLuongTon)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        /// <summary>
        /// Yêu cầu 1: Cập nhật đơn giá và số lượng tồn kho phụ tùng
        /// </summary>
        public bool CapNhatGiaVaTonKho(int maPhuTung, decimal donGia, int soLuongTon)
        {
            string sql = @"
                UPDATE PhuTung
                SET DonGia = @DonGia,
                    SoLuongTon = @SoLuongTon
                WHERE MaPhuTung = @Ma";

            SqlParameter[] pars = new[]
            {
                new SqlParameter("@Ma", maPhuTung),
                new SqlParameter("@DonGia", donGia),
                new SqlParameter("@SoLuongTon", soLuongTon)
            };

            return DataProvider.ExecuteNonQuery(sql, pars) > 0;
        }

        public bool Xoa(int maPhuTung)
        {
            string sql = "DELETE FROM PhuTung WHERE MaPhuTung = @Ma";
            SqlParameter p = new SqlParameter("@Ma", maPhuTung);
            return DataProvider.ExecuteNonQuery(sql, p) > 0;
        }
    }
}
