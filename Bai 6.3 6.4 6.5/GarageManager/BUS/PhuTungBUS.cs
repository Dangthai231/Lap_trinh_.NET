using System;
using System.Collections.Generic;
using GarageManager.DAL;
using GarageManager.DTO;

namespace GarageManager.BUS
{
    public class PhuTungBUS
    {
        private readonly PhuTungDAL _dal = new PhuTungDAL();

        public List<PhuTungDTO> LayDanhSach()
        {
            return _dal.LayTatCa();
        }

        public PhuTungDTO LayTheoMa(int maPT)
        {
            return _dal.LayTheoMa(maPT);
        }

        public (bool Success, string Message, int Id) Them(PhuTungDTO pt)
        {
            if (string.IsNullOrWhiteSpace(pt.TenPhuTung))
                return (false, "Tên phụ tùng không được để trống!", 0);

            if (pt.DonGia < 0)
                return (false, "Đơn giá không được âm!", 0);

            if (pt.SoLuongTon < 0)
                return (false, "Số lượng tồn kho không được âm!", 0);

            try
            {
                int id = _dal.Them(pt);
                return id > 0 ? (true, "Thêm phụ tùng thành công!", id) : (false, "Không thể thêm phụ tùng!", 0);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi thêm phụ tùng: " + ex.Message, 0);
            }
        }

        public (bool Success, string Message) Sua(PhuTungDTO pt)
        {
            if (pt.MaPhuTung <= 0)
                return (false, "Mã phụ tùng không hợp lệ!");

            if (string.IsNullOrWhiteSpace(pt.TenPhuTung))
                return (false, "Tên phụ tùng không được để trống!");

            if (pt.DonGia < 0)
                return (false, "Đơn giá không được âm!");

            if (pt.SoLuongTon < 0)
                return (false, "Số lượng tồn kho không được âm!");

            try
            {
                bool ok = _dal.Sua(pt);
                return ok ? (true, "Cập nhật phụ tùng thành công!") : (false, "Không thể cập nhật phụ tùng!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi cập nhật phụ tùng: " + ex.Message);
            }
        }

        public (bool Success, string Message) CapNhatGiaVaTonKho(int maPT, decimal donGia, int soLuongTon)
        {
            if (donGia < 0 || soLuongTon < 0)
                return (false, "Đơn giá hoặc số lượng tồn kho không hợp lệ!");

            try
            {
                bool ok = _dal.CapNhatGiaVaTonKho(maPT, donGia, soLuongTon);
                return ok ? (true, "Cập nhật đơn giá & kho thành công!") : (false, "Không tìm thấy phụ tùng!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi cập nhật: " + ex.Message);
            }
        }

        public (bool Success, string Message) Xoa(int maPT)
        {
            try
            {
                bool ok = _dal.Xoa(maPT);
                return ok ? (true, "Xóa phụ tùng thành công!") : (false, "Không thể xóa phụ tùng (có thể đang có trong phiếu sửa chữa)!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi xóa phụ tùng: " + ex.Message);
            }
        }
    }
}
