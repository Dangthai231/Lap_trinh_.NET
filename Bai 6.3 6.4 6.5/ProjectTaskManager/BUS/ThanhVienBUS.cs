using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProjectTaskManager.DAL;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.BUS
{
    public class ThanhVienBUS
    {
        private readonly ThanhVienDAL _thanhVienDAL = new ThanhVienDAL();

        public List<ThanhVienDTO> LayDanhSach()
        {
            return _thanhVienDAL.LayTatCa();
        }

        public ThanhVienDTO LayTheoMa(int maThanhVien)
        {
            return _thanhVienDAL.LayTheoMa(maThanhVien);
        }

        public (bool Success, string Message, int Id) Them(ThanhVienDTO tv)
        {
            if (string.IsNullOrWhiteSpace(tv.HoTen))
                return (false, "Họ tên thành viên không được để trống!", 0);

            if (string.IsNullOrWhiteSpace(tv.Email))
                return (false, "Email không được để trống!", 0);

            if (!Regex.IsMatch(tv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "Định dạng email không hợp lệ!", 0);

            if (_thanhVienDAL.KiemTraEmail(tv.Email))
                return (false, "Email này đã tồn tại trong hệ thống!", 0);

            try
            {
                int id = _thanhVienDAL.Them(tv);
                if (id > 0)
                    return (true, "Thêm thành viên thành công!", id);
                return (false, "Không thể thêm thành viên!", 0);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi thêm thành viên: " + ex.Message, 0);
            }
        }

        public (bool Success, string Message) Sua(ThanhVienDTO tv)
        {
            if (tv.MaThanhVien <= 0)
                return (false, "Mã thành viên không hợp lệ!");

            if (string.IsNullOrWhiteSpace(tv.HoTen))
                return (false, "Họ tên thành viên không được để trống!");

            if (string.IsNullOrWhiteSpace(tv.Email))
                return (false, "Email không được để trống!");

            if (!Regex.IsMatch(tv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "Định dạng email không hợp lệ!");

            if (_thanhVienDAL.KiemTraEmail(tv.Email, tv.MaThanhVien))
                return (false, "Email này đã được sử dụng bởi thành viên khác!");

            try
            {
                bool ok = _thanhVienDAL.Sua(tv);
                return ok ? (true, "Cập nhật thành viên thành công!") : (false, "Không tìm thấy thành viên để cập nhật!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi cập nhật thành viên: " + ex.Message);
            }
        }

        public (bool Success, string Message) Xoa(int maThanhVien)
        {
            if (maThanhVien <= 0)
                return (false, "Mã thành viên không hợp lệ!");

            try
            {
                bool ok = _thanhVienDAL.Xoa(maThanhVien);
                return ok ? (true, "Xóa thành viên thành công!") : (false, "Không tìm thấy thành viên để xóa!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xóa thành viên: " + ex.Message);
            }
        }
    }
}
