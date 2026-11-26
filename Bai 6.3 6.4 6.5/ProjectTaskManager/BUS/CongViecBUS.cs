using System;
using System.Collections.Generic;
using ProjectTaskManager.DAL;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.BUS
{
    public class CongViecBUS
    {
        private readonly CongViecDAL _congViecDAL = new CongViecDAL();
        private readonly PhanCongDAL _phanCongDAL = new PhanCongDAL();

        public List<CongViecDTO> LayDanhSach(int? maDuAn = null, string trangThai = null, string timKiem = null)
        {
            return _congViecDAL.LayDanhSach(maDuAn, trangThai, timKiem);
        }

        public CongViecDTO LayTheoMa(int maTask)
        {
            return _congViecDAL.LayTheoMa(maTask);
        }

        public (bool Success, string Message, int Id) Them(CongViecDTO task, List<int> dsMaThanhVien = null)
        {
            if (task.MaDuAn <= 0)
                return (false, "Vui lòng chọn Dự án cho công việc!", 0);

            if (string.IsNullOrWhiteSpace(task.TenTask))
                return (false, "Tên công việc không được để trống!", 0);

            if (string.IsNullOrWhiteSpace(task.TrangThai))
                task.TrangThai = "To Do";

            if (string.IsNullOrWhiteSpace(task.DoUuTien))
                task.DoUuTien = "Trung bình";

            try
            {
                int id = _congViecDAL.Them(task);
                if (id > 0)
                {
                    if (dsMaThanhVien != null && dsMaThanhVien.Count > 0)
                    {
                        _phanCongDAL.CapNhatPhanCongChoTask(id, dsMaThanhVien);
                    }
                    return (true, "Thêm công việc thành công!", id);
                }
                return (false, "Không thể thêm công việc!", 0);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi thêm công việc: " + ex.Message, 0);
            }
        }

        public (bool Success, string Message) Sua(CongViecDTO task, List<int> dsMaThanhVien = null)
        {
            if (task.MaTask <= 0)
                return (false, "Mã công việc không hợp lệ!");

            if (task.MaDuAn <= 0)
                return (false, "Vui lòng chọn Dự án cho công việc!");

            if (string.IsNullOrWhiteSpace(task.TenTask))
                return (false, "Tên công việc không được để trống!");

            try
            {
                bool ok = _congViecDAL.Sua(task);
                if (ok)
                {
                    if (dsMaThanhVien != null)
                    {
                        _phanCongDAL.CapNhatPhanCongChoTask(task.MaTask, dsMaThanhVien);
                    }
                    return (true, "Cập nhật công việc thành công!");
                }
                return (false, "Không tìm thấy công việc để cập nhật!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi cập nhật công việc: " + ex.Message);
            }
        }

        /// <summary>
        /// Yêu cầu 2: Chuyển trạng thái công việc (Ví dụ: Chuyển từ "In Progress" sang "Done")
        /// </summary>
        public (bool Success, string Message) ChuyenTrangThai(int maTask, string trangThaiMoi)
        {
            if (maTask <= 0)
                return (false, "Mã công việc không hợp lệ!");

            if (string.IsNullOrWhiteSpace(trangThaiMoi))
                return (false, "Trạng thái mới không hợp lệ!");

            try
            {
                bool ok = _congViecDAL.CapNhatTrangThai(maTask, trangThaiMoi);
                return ok ? (true, $"Chuyển trạng thái sang '{trangThaiMoi}' thành công!") : (false, "Không thể cập nhật trạng thái!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi chuyển trạng thái: " + ex.Message);
            }
        }

        public (bool Success, string Message) Xoa(int maTask)
        {
            if (maTask <= 0)
                return (false, "Mã công việc không hợp lệ!");

            try
            {
                bool ok = _congViecDAL.Xoa(maTask);
                return ok ? (true, "Xóa công việc thành công!") : (false, "Không tìm thấy công việc để xóa!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xóa công việc: " + ex.Message);
            }
        }

        /// <summary>
        /// Yêu cầu 3: Lấy danh sách công việc trễ hạn (qua SqlDataReader)
        /// </summary>
        public List<CongViecDTO> LayCongViecTreHan(int? maDuAn = null)
        {
            return _congViecDAL.LayCongViecTreHan(maDuAn);
        }
    }
}
