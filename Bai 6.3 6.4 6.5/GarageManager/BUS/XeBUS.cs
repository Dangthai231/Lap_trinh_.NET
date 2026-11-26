using System;
using System.Collections.Generic;
using GarageManager.DAL;
using GarageManager.DTO;

namespace GarageManager.BUS
{
    public class XeBUS
    {
        private readonly XeDAL _dal = new XeDAL();

        public List<XeDTO> LayDanhSach()
        {
            return _dal.LayTatCa();
        }

        public XeDTO TraCuuBienSo(string bienSo)
        {
            if (string.IsNullOrWhiteSpace(bienSo))
                return null;
            return _dal.TraCuuBienSo(bienSo.Trim());
        }

        public (bool Success, string Message) Them(XeDTO xe)
        {
            if (string.IsNullOrWhiteSpace(xe.BienSo))
                return (false, "Biển số xe không được để trống!");

            if (xe.MaKH <= 0)
                return (false, "Vui lòng chọn hoặc nhập thông tin Chủ xe!");

            var existing = _dal.TraCuuBienSo(xe.BienSo.Trim());
            if (existing != null)
                return (false, $"Biển số xe '{xe.BienSo}' đã có trong hệ thống!");

            try
            {
                bool ok = _dal.Them(xe);
                return ok ? (true, "Thêm xe thành công!") : (false, "Không thể thêm xe!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi thêm xe: " + ex.Message);
            }
        }

        public (bool Success, string Message) Sua(XeDTO xe)
        {
            if (string.IsNullOrWhiteSpace(xe.BienSo))
                return (false, "Biển số xe không được để trống!");

            if (xe.MaKH <= 0)
                return (false, "Vui lòng chọn Chủ xe!");

            try
            {
                bool ok = _dal.Sua(xe);
                return ok ? (true, "Cập nhật thông tin xe thành công!") : (false, "Không thể cập nhật xe!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi cập nhật xe: " + ex.Message);
            }
        }

        public (bool Success, string Message) Xoa(string bienSo)
        {
            try
            {
                bool ok = _dal.Xoa(bienSo);
                return ok ? (true, "Xóa thông tin xe thành công!") : (false, "Không thể xóa xe!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi xóa xe: " + ex.Message);
            }
        }
    }
}
