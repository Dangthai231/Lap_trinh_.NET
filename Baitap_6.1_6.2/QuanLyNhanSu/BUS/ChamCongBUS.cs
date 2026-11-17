using System.Data;

namespace QuanLyNhanSu.BUS
{
    using QuanLyNhanSu.DAL;
    using QuanLyNhanSu.DTO;

    public class ChamCongBUS
    {
        private readonly ChamCongDAL dal = new ChamCongDAL();
        private readonly NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public static string ThangNam(DateTime d)
        {
            return d.ToString("MM'/'yyyy", System.Globalization.CultureInfo.InvariantCulture);     // ví dụ "11/2026"
        }

        // Nạp bảng chấm công của tháng. Nhân viên nào chưa có dòng chấm công thì thêm dòng mới (SoNgayCong = 0)
        // vào DataTable; các dòng mới này sẽ được INSERT khi bấm "Lưu chấm công".
        public DataTable NapBangChamCong(string thangNam, out bool daChot)
        {
            DataTable dt = dal.NapBangChamCong(thangNam);
            daChot = dt.AsEnumerable().Any(r => Convert.ToBoolean(r["DaChot"]));

            // Thêm cột hiển thị (không có trong bảng BangChamCong nên không ảnh hưởng adapter.Update)
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("TenPB", typeof(string));

            List<NhanVienDTO> dsNV = nhanVienDAL.TimKiem("", 0);
            foreach (NhanVienDTO nv in dsNV)
            {
                DataRow dong = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["MaNV"]) == nv.MaNV);
                if (dong == null)
                {
                    if (daChot) continue;               // tháng đã chốt thì không thêm nữa
                    dong = dt.NewRow();
                    dong["MaNV"] = nv.MaNV;
                    dong["ThangNam"] = thangNam;
                    dong["SoNgayCong"] = 0.0;
                    dong["SoGioOT"] = 0.0;
                    dong["DaChot"] = false;
                    dt.Rows.Add(dong);
                }
                dong["HoTen"] = nv.HoTen;
                dong["TenPB"] = nv.TenPB;
            }

            // Cột hiển thị không phải là thay đổi cần lưu
            foreach (DataRow r in dt.Rows)
                if (r.RowState == DataRowState.Modified) r.AcceptChanges();
            return dt;
        }

        // Kiểm tra dữ liệu trên lưới, trả về "" nếu hợp lệ
        public string KiemTra(DataTable dt)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                double ngay = Convert.ToDouble(r["SoNgayCong"]);
                double ot = Convert.ToDouble(r["SoGioOT"]);
                if (ngay < 0 || ngay > 31) return "Nhân viên " + r["HoTen"] + ": số ngày công phải từ 0 đến 31.";
                if (ot < 0) return "Nhân viên " + r["HoTen"] + ": số giờ OT không được âm.";
            }
            return "";
        }

        public int Luu(DataTable dt)
        {
            return dal.LuuBangChamCong(dt);
        }
    }
}
