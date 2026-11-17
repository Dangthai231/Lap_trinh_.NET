using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyNhanSu.DAL
{
    // CHẤM CÔNG THEO MÔ HÌNH NGẮT KẾT NỐI (Disconnected Model)
    // SqlDataAdapter nạp dữ liệu vào DataTable -> người dùng sửa trên lưới (không cần kết nối)
    // -> SqlCommandBuilder + adapter.Update() đẩy mọi thay đổi về SQL Server trong 1 lần.
    public class ChamCongDAL
    {
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;

        public DataTable NapBangChamCong(string thangNam)
        {
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand(
                "SELECT MaCong, MaNV, ThangNam, SoNgayCong, SoGioOT, DaChot FROM BangChamCong " +
                "WHERE ThangNam = @ThangNam ORDER BY MaNV", conn);
            cmd.Parameters.Add(DataProvider.TS("@ThangNam", thangNam));

            adapter = new SqlDataAdapter(cmd);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;   // lấy cả khóa chính, cột tự tăng
            builder = new SqlCommandBuilder(adapter);                        // tự sinh INSERT / UPDATE / DELETE
            builder.ConflictOption = ConflictOption.OverwriteChanges;        // cập nhật theo khóa chính MaCong

            DataTable dt = new DataTable("BangChamCong");
            adapter.Fill(dt);                       // Fill tự mở rồi tự đóng kết nối

            // Dòng mới thêm trên lưới dùng mã tạm âm, SQL Server sẽ tự cấp mã thật
            DataColumn colMa = dt.Columns["MaCong"];
            colMa.AutoIncrementSeed = -1;
            colMa.AutoIncrementStep = -1;
            return dt;
        }

        // Đồng bộ toàn bộ thay đổi trong DataTable về SQL Server
        public int LuuBangChamCong(DataTable dt)
        {
            if (adapter == null) throw new InvalidOperationException("Chưa nạp bảng chấm công.");
            return adapter.Update(dt);
        }
    }
}
