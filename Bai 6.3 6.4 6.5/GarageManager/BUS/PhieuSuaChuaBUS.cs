using System;
using System.Collections.Generic;
using GarageManager.DAL;
using GarageManager.DTO;

namespace GarageManager.BUS
{
    public class PhieuSuaChuaBUS
    {
        private readonly PhieuSuaChuaDAL _dal = new PhieuSuaChuaDAL();

        public List<PhieuSuaChuaDTO> LayDanhSach(string trangThai = null, string timKiem = null)
        {
            return _dal.LayDanhSach(trangThai, timKiem);
        }

        public PhieuSuaChuaDTO LayTheoMa(int maPhieu)
        {
            return _dal.LayTheoMa(maPhieu);
        }

        public List<ChiTietSuaChuaDTO> LayChiTietTheoPhieu(int maPhieu)
        {
            return _dal.LayChiTietTheoPhieu(maPhieu);
        }

        /// <summary>
        /// Yêu cầu 2: Lập phiếu sửa chữa & Thay thế phụ tùng bảo đảm tính nhất quán qua SqlTransaction
        /// </summary>
        public (bool Success, string Message, int Id) LapPhieuSuaChua(PhieuSuaChuaDTO phieu, List<ChiTietSuaChuaDTO> chiTietList)
        {
            if (string.IsNullOrWhiteSpace(phieu.BienSo))
                return (false, "Vui lòng chọn Biển số xe tiếp nhận!", 0);

            if (chiTietList == null || chiTietList.Count == 0)
                return (false, "Phiếu sửa chữa phải có ít nhất 1 phụ tùng / dịch vụ thay thế!", 0);

            // Tính tổng tiền = Tổng (Số lượng x Đơn giá) + Tổng tiền công
            decimal tong = 0;
            foreach (var ct in chiTietList)
            {
                if (ct.SoLuong <= 0)
                    return (false, $"Số lượng phụ tùng '{ct.TenPhuTung}' phải lớn hơn 0!", 0);

                tong += (ct.SoLuong * ct.DonGia) + ct.TienCong;
            }
            phieu.TongTien = tong;

            try
            {
                // Thực thi Transaction tại DAL
                int idMoi = _dal.LapPhieuSuaChuaTransaction(phieu, chiTietList);
                return (true, $"Lập phiếu sửa chữa #{idMoi} thành công! Đã trừ kho và lưu giao dịch nhất quán bằng SqlTransaction.", idMoi);
            }
            catch (Exception ex)
            {
                return (false, "Giao dịch thất bại (đã Rollback): " + ex.Message, 0);
            }
        }

        /// <summary>
        /// Yêu cầu 3: Thanh toán phiếu sửa chữa -> Chuyển trạng thái sang "Đã thanh toán"
        /// </summary>
        public (bool Success, string Message) ThanhToan(int maPhieu)
        {
            if (maPhieu <= 0)
                return (false, "Mã phiếu không hợp lệ!");

            try
            {
                bool ok = _dal.ChuyenTrangThaiThanhToan(maPhieu);
                return ok ? (true, $"Đã thanh toán thành công phiếu sửa chữa #{maPhieu}!") : (false, "Không tìm thấy phiếu để thanh toán!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi thanh toán: " + ex.Message);
            }
        }

        public (bool Success, string Message) ChuyenTrangThai(int maPhieu, string trangThai)
        {
            try
            {
                bool ok = _dal.CapNhatTrangThai(maPhieu, trangThai);
                return ok ? (true, $"Đã chuyển trạng thái phiếu #{maPhieu} sang '{trangThai}'!") : (false, "Không thể chuyển trạng thái!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        public (bool Success, string Message) Xoa(int maPhieu)
        {
            try
            {
                bool ok = _dal.Xoa(maPhieu);
                return ok ? (true, "Xóa phiếu sửa chữa thành công!") : (false, "Không thể xóa phiếu!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        public (int TongPhieu, int DangSua, int DaHoanThanh, int DaThanhToan, decimal TongDoanhThu) ThongKeTongQuan()
        {
            return _dal.ThongKeTongQuan();
        }
    }
}
