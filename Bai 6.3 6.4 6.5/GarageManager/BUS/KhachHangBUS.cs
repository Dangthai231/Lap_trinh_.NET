using System;
using System.Collections.Generic;
using GarageManager.DAL;
using GarageManager.DTO;

namespace GarageManager.BUS
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAL _dal = new KhachHangDAL();

        public List<KhachHangDTO> LayDanhSach()
        {
            return _dal.LayTatCa();
        }

        public KhachHangDTO LayTheoMa(int maKH)
        {
            return _dal.LayTheoMa(maKH);
        }

        public KhachHangDTO LayTheoDienThoai(string sdt)
        {
            return _dal.LayTheoDienThoai(sdt);
        }

        public (bool Success, string Message, int Id) Them(KhachHangDTO kh)
        {
            if (string.IsNullOrWhiteSpace(kh.TenKH))
                return (false, "Tên khách hàng không được để trống!", 0);

            if (!string.IsNullOrWhiteSpace(kh.DienThoai))
            {
                var existing = _dal.LayTheoDienThoai(kh.DienThoai.Trim());
                if (existing != null)
                    return (false, "Số điện thoại này đã tồn tại trong hệ thống!", 0);
            }

            try
            {
                int id = _dal.Them(kh);
                return id > 0 ? (true, "Thêm khách hàng thành công!", id) : (false, "Không thể thêm khách hàng!", 0);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi thêm khách hàng: " + ex.Message, 0);
            }
        }

        public (bool Success, string Message) Sua(KhachHangDTO kh)
        {
            if (kh.MaKH <= 0)
                return (false, "Mã khách hàng không hợp lệ!");

            if (string.IsNullOrWhiteSpace(kh.TenKH))
                return (false, "Tên khách hàng không được để trống!");

            try
            {
                bool ok = _dal.Sua(kh);
                return ok ? (true, "Cập nhật thông tin khách hàng thành công!") : (false, "Không tìm thấy khách hàng để sửa!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi cập nhật khách hàng: " + ex.Message);
            }
        }

        public (bool Success, string Message) Xoa(int maKH)
        {
            try
            {
                bool ok = _dal.Xoa(maKH);
                return ok ? (true, "Xóa khách hàng thành công!") : (false, "Không thể xóa khách hàng!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi xóa khách hàng: " + ex.Message);
            }
        }
    }
}
