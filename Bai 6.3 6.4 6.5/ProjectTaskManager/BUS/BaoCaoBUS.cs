using System.Collections.Generic;
using ProjectTaskManager.DAL;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager.BUS
{
    public class BaoCaoBUS
    {
        private readonly BaoCaoDAL _baoCaoDAL = new BaoCaoDAL();

        /// <summary>
        /// Yêu cầu 3: Thống kê tỷ lệ % hoàn thành công việc của từng thành viên
        /// </summary>
        public List<ThongKeThanhVienDTO> ThongKeTheoThanhVien(int? maDuAn = null)
        {
            return _baoCaoDAL.ThongKeTheoThanhVien(maDuAn);
        }

        /// <summary>
        /// Yêu cầu 3: Tính % bằng ExecuteScalar
        /// </summary>
        public double TinhTiLeHoanThanh(int maThanhVien, int? maDuAn = null)
        {
            return _baoCaoDAL.TinhTiLeHoanThanhThanhVien(maThanhVien, maDuAn);
        }

        public (int Tong, int ToDo, int InProgress, int Review, int Done, int TreHan) ThongKeTongQuan(int? maDuAn = null)
        {
            return _baoCaoDAL.ThongKeTongQuan(maDuAn);
        }
    }
}
