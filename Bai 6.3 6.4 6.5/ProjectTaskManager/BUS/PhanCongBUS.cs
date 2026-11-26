using System;
using System.Collections.Generic;
using ProjectTaskManager.DAL;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.BUS
{
    public class PhanCongBUS
    {
        private readonly PhanCongDAL _phanCongDAL = new PhanCongDAL();

        public List<PhanCongDTO> LayTheoTask(int maTask)
        {
            return _phanCongDAL.LayTheoTask(maTask);
        }

        public List<int> LayMaThanhVienTheoTask(int maTask)
        {
            return _phanCongDAL.LayDanhSachMaThanhVienTheoTask(maTask);
        }

        /// <summary>
        /// Yêu cầu 1: Giao việc (Phân công) cho một hoặc nhiều thành viên tham gia giải quyết Task
        /// </summary>
        public (bool Success, string Message) PhanCong(int maTask, List<int> dsMaThanhVien)
        {
            if (maTask <= 0)
                return (false, "Mã công việc không hợp lệ!");

            try
            {
                bool ok = _phanCongDAL.CapNhatPhanCongChoTask(maTask, dsMaThanhVien);
                return ok ? (true, "Phân công công việc thành công!") : (false, "Không thể phân công công việc!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi phân công: " + ex.Message);
            }
        }
    }
}
