namespace QuanLyBanHang.BUS
{
    using QuanLyBanHang.DAL;
    using QuanLyBanHang.DTO;

    public class HoaDonBUS
    {
        private readonly HoaDonDAL dal = new HoaDonDAL();

        public decimal TinhTongTien(List<ChiTietHoaDonDTO> gioHang)
        {
            return gioHang.Sum(x => x.ThanhTien);
        }

        // Quy tắc: cứ 100.000 đ được 1 điểm (làm tròn xuống)
        public int TinhDiemTichLuy(decimal tongTien)
        {
            return (int)Math.Floor(tongTien / 100000m);
        }

        // Trả về mã hóa đơn (> 0) nếu thành công, -1 nếu thất bại (lý do trong thongBaoLoi)
        public int ThanhToan(int maNV, int? maKH, List<ChiTietHoaDonDTO> gioHang, out string thongBaoLoi)
        {
            if (gioHang == null || gioHang.Count == 0)
            {
                thongBaoLoi = "Giỏ hàng đang trống.";
                return -1;
            }

            decimal tong = TinhTongTien(gioHang);
            HoaDonDTO hd = new HoaDonDTO { MaNV = maNV, MaKH = maKH, TongTien = tong, NgayLap = DateTime.Now };
            int diem = maKH.HasValue ? TinhDiemTichLuy(tong) : 0;
            return dal.ThanhToan(hd, gioHang, diem, out thongBaoLoi);
        }
    }
}
