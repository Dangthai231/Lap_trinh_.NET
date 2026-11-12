namespace Bai5_4
{
    // Một nhân viên thuộc một nhóm
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string MaNhom { get; set; }      // nhóm mà nhân viên thuộc về
        public string TenNhom { get; set; }

        public NhanVien(string maNV, string hoTen, string chucVu, DateTime ngayVaoLam, string maNhom, string tenNhom)
        {
            MaNV = maNV;
            HoTen = hoTen;
            ChucVu = chucVu;
            NgayVaoLam = ngayVaoLam;
            MaNhom = maNhom;
            TenNhom = tenNhom;
        }
    }
}
