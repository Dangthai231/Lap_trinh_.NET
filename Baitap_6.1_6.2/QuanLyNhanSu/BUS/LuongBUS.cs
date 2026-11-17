namespace QuanLyNhanSu.BUS
{
    using QuanLyNhanSu.DAL;
    using QuanLyNhanSu.DTO;

    public class LuongBUS
    {
        public const decimal TIEN_MOT_GIO_OT = 50000;
        private readonly LuongDAL dal = new LuongDAL();

        // ThucLinh = (LuongCoBan * HeSoLuong / 22) * SoNgayCong + (SoGioOT * 50.000)
        public static decimal TinhThucLinh(decimal luongCoBan, double heSoLuong, double soNgayCong, double soGioOT)
        {
            decimal luongNgay = luongCoBan * (decimal)heSoLuong / 22m;
            decimal thucLinh = luongNgay * (decimal)soNgayCong + (decimal)soGioOT * TIEN_MOT_GIO_OT;
            return Math.Round(thucLinh, 0);
        }

        // Tính lương (xem trước, chưa ghi vào CSDL)
        public List<BangLuongDTO> TinhLuong(string thangNam)
        {
            List<BangLuongDTO> ds = dal.LayDuLieuTinhLuong(thangNam);
            foreach (BangLuongDTO bl in ds)
                bl.ThucLinh = TinhThucLinh(bl.LuongCoBan, bl.HeSoLuong, bl.SoNgayCong, bl.SoGioOT);
            return ds;
        }

        public bool DaChotLuong(string thangNam)
        {
            return dal.DaChotLuong(thangNam);
        }

        public bool ChotLuong(string thangNam, out string thongBaoLoi)
        {
            List<BangLuongDTO> ds = TinhLuong(thangNam);
            if (ds.Count == 0)
            {
                thongBaoLoi = "Tháng " + thangNam + " chưa có dữ liệu chấm công. Hãy chấm công và bấm \"Lưu chấm công\" trước.";
                return false;
            }
            if (ds.All(x => x.SoNgayCong == 0 && x.SoGioOT == 0))
            {
                thongBaoLoi = "Tất cả nhân viên đều có 0 ngày công trong tháng " + thangNam + ". Hãy kiểm tra lại bảng chấm công.";
                return false;
            }
            return dal.ChotLuong(thangNam, ds, out thongBaoLoi);
        }

        public List<BangLuongDTO> LayBangLuongDaChot(string thangNam) { return dal.LayBangLuongDaChot(thangNam); }
        public decimal TongQuyLuong(string thangNam) { return dal.TongQuyLuong(thangNam); }
        public List<QuyLuongPhongBanDTO> QuyLuongTheoPhongBan(string thangNam) { return dal.QuyLuongTheoPhongBan(thangNam); }
        public string ThangChotGanNhat() { return dal.ThangChotGanNhat(); }
    }
}
