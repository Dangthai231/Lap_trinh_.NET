using System;
using System.Collections.Generic;
using ProjectTaskManager.DAL;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.BUS
{
    public class DuAnBUS
    {
        private readonly DuAnDAL _duAnDAL = new DuAnDAL();

        public List<DuAnDTO> LayDanhSach()
        {
            return _duAnDAL.LayTatCa();
        }

        public DuAnDTO LayTheoMa(int maDuAn)
        {
            return _duAnDAL.LayTheoMa(maDuAn);
        }

        public (bool Success, string Message, int Id) Them(DuAnDTO duAn)
        {
            if (string.IsNullOrWhiteSpace(duAn.TenDuAn))
                return (false, "Tên dự án không được để trống!", 0);

            if (duAn.NgayBatDau.HasValue && duAn.NgayKetThuc.HasValue && duAn.NgayKetThuc.Value < duAn.NgayBatDau.Value)
                return (false, "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!", 0);

            try
            {
                int id = _duAnDAL.Them(duAn);
                if (id > 0)
                    return (true, "Thêm dự án thành công!", id);
                return (false, "Không thể thêm dự án!", 0);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi thêm dự án: " + ex.Message, 0);
            }
        }

        public (bool Success, string Message) Sua(DuAnDTO duAn)
        {
            if (duAn.MaDuAn <= 0)
                return (false, "Mã dự án không hợp lệ!");

            if (string.IsNullOrWhiteSpace(duAn.TenDuAn))
                return (false, "Tên dự án không được để trống!");

            if (duAn.NgayBatDau.HasValue && duAn.NgayKetThuc.HasValue && duAn.NgayKetThuc.Value < duAn.NgayBatDau.Value)
                return (false, "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!");

            try
            {
                bool ok = _duAnDAL.Sua(duAn);
                return ok ? (true, "Cập nhật dự án thành công!") : (false, "Không tìm thấy dự án để cập nhật!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi cập nhật dự án: " + ex.Message);
            }
        }

        public (bool Success, string Message) Xoa(int maDuAn)
        {
            if (maDuAn <= 0)
                return (false, "Mã dự án không hợp lệ!");

            try
            {
                bool ok = _duAnDAL.Xoa(maDuAn);
                return ok ? (true, "Xóa dự án và các công việc liên quan thành công!") : (false, "Không tìm thấy dự án để xóa!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xóa dự án: " + ex.Message);
            }
        }
    }
}
