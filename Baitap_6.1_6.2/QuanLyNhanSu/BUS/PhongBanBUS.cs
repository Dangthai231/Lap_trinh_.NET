namespace QuanLyNhanSu.BUS
{
    using QuanLyNhanSu.DAL;
    using QuanLyNhanSu.DTO;

    public class PhongBanBUS
    {
        private readonly PhongBanDAL dal = new PhongBanDAL();

        public List<PhongBanDTO> LayDanhSach()
        {
            return dal.LayDanhSach();
        }
    }
}
