using Microsoft.Data.SqlClient;

namespace QuanLyBanHang.DAL
{
    using QuanLyBanHang.DTO;

    public class HoaDonDAL
    {
        // THANH TOÁN = 1 SqlTransaction gồm 4 bước. Lỗi ở bất kỳ bước nào -> Rollback toàn bộ.
        // Trả về mã hóa đơn mới; nếu thất bại thì trả về -1 và ghi lý do vào thongBaoLoi.
        public int ThanhToan(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> gioHang, int diemCong, out string thongBaoLoi)
        {
            thongBaoLoi = "";
            using (SqlConnection conn = DataProvider.TaoKetNoi())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Bước 1: Chèn 1 bản ghi vào HoaDon, lấy MaHD vừa tạo
                    SqlCommand cmdHD = new SqlCommand(
                        "INSERT INTO HoaDon (NgayLap, MaNV, MaKH, TongTien) OUTPUT INSERTED.MaHD " +
                        "VALUES (GETDATE(), @MaNV, @MaKH, @TongTien)", conn, trans);
                    cmdHD.Parameters.Add(DataProvider.TS("@MaNV", hoaDon.MaNV));
                    cmdHD.Parameters.Add(DataProvider.TS("@MaKH", hoaDon.MaKH));
                    cmdHD.Parameters.Add(DataProvider.TS("@TongTien", hoaDon.TongTien));
                    int maHD = Convert.ToInt32(cmdHD.ExecuteScalar());

                    foreach (ChiTietHoaDonDTO ct in gioHang)
                    {
                        // Kiểm tra tồn kho (khóa dòng để người khác không bán chen vào)
                        SqlCommand cmdTon = new SqlCommand(
                            "SELECT SoLuongTon FROM SanPham WITH (UPDLOCK, ROWLOCK) WHERE MaSP = @MaSP", conn, trans);
                        cmdTon.Parameters.Add(DataProvider.TS("@MaSP", ct.MaSP));
                        object ketQua = cmdTon.ExecuteScalar();
                        int soLuongTon = ketQua == null ? 0 : Convert.ToInt32(ketQua);

                        if (soLuongTon < ct.SoLuong)
                        {
                            trans.Rollback();   // không đủ hàng -> hủy toàn bộ giao dịch
                            thongBaoLoi = "Sản phẩm \"" + ct.TenSP + "\" chỉ còn " + soLuongTon +
                                          " trong kho, không đủ để bán " + ct.SoLuong + ".\n" +
                                          "Giao dịch đã được hủy (Rollback), dữ liệu không bị thay đổi.";
                            return -1;
                        }

                        // Bước 2: Chèn chi tiết hóa đơn
                        SqlCommand cmdCT = new SqlCommand(
                            "INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)",
                            conn, trans);
                        cmdCT.Parameters.Add(DataProvider.TS("@MaHD", maHD));
                        cmdCT.Parameters.Add(DataProvider.TS("@MaSP", ct.MaSP));
                        cmdCT.Parameters.Add(DataProvider.TS("@SoLuong", ct.SoLuong));
                        cmdCT.Parameters.Add(DataProvider.TS("@DonGia", ct.DonGia));
                        cmdCT.ExecuteNonQuery();

                        // Bước 3: Trừ tồn kho
                        SqlCommand cmdTru = new SqlCommand(
                            "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP", conn, trans);
                        cmdTru.Parameters.Add(DataProvider.TS("@SoLuong", ct.SoLuong));
                        cmdTru.Parameters.Add(DataProvider.TS("@MaSP", ct.MaSP));
                        cmdTru.ExecuteNonQuery();
                    }

                    // Bước 4: Cộng điểm tích lũy (chỉ khi có chọn khách hàng)
                    if (hoaDon.MaKH.HasValue && diemCong > 0)
                    {
                        SqlCommand cmdDiem = new SqlCommand(
                            "UPDATE KhachHang SET DiemTichLuy = DiemTichLuy + @Diem WHERE MaKH = @MaKH", conn, trans);
                        cmdDiem.Parameters.Add(DataProvider.TS("@Diem", diemCong));
                        cmdDiem.Parameters.Add(DataProvider.TS("@MaKH", hoaDon.MaKH.Value));
                        cmdDiem.ExecuteNonQuery();
                    }

                    // Bước 5: Mọi thứ thành công -> Commit
                    trans.Commit();
                    return maHD;
                }
                catch (Exception ex)
                {
                    try { trans.Rollback(); } catch { }
                    thongBaoLoi = "Lỗi khi thanh toán: " + ex.Message + "\nGiao dịch đã được hủy (Rollback).";
                    return -1;
                }
            }
        }
    }
}
