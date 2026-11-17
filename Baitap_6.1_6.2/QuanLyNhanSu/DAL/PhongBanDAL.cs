using System.Data;

namespace QuanLyNhanSu.DAL
{
    using QuanLyNhanSu.DTO;

    public class PhongBanDAL
    {
        public List<PhongBanDTO> LayDanhSach()
        {
            DataTable dt = DataProvider.ExecuteQuery("SELECT MaPB, TenPB, Mota FROM PhongBan ORDER BY MaPB");
            List<PhongBanDTO> ds = new List<PhongBanDTO>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new PhongBanDTO
                {
                    MaPB = Convert.ToInt32(r["MaPB"]),
                    TenPB = r["TenPB"].ToString(),
                    Mota = r["Mota"].ToString()
                });
            }
            return ds;
        }
    }
}
