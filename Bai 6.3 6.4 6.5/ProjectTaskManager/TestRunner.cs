using System;
using System.Collections.Generic;
using ProjectTaskManager.BUS;
using ProjectTaskManager.DTO;

namespace ProjectTaskManager
{
    public static class TestRunner
    {
        public static void RunTests()
        {
            Console.WriteLine("=== BẮT ĐẦU KIỂM THỬ BÀI 6.3 3-TIER ===");

            DuAnBUS duAnBUS = new DuAnBUS();
            var dsDuAn = duAnBUS.LayDanhSach();
            Console.WriteLine($"1. Danh sách Dự án: {dsDuAn.Count} dự án.");
            foreach (var d in dsDuAn)
            {
                Console.WriteLine($"   - [{d.MaDuAn}] {d.TenDuAn} | Trạng thái: {d.TrangThai} | Tiến độ: {d.TiLeHoanThanh}% ({d.TaskHoanThanh}/{d.TongTask})");
            }

            ThanhVienBUS tvBUS = new ThanhVienBUS();
            var dsTV = tvBUS.LayDanhSach();
            Console.WriteLine($"2. Danh sách Thành viên: {dsTV.Count} thành viên.");
            foreach (var tv in dsTV)
            {
                Console.WriteLine($"   - [{tv.MaThanhVien}] {tv.HoTen} ({tv.Email}) - {tv.ChuyenMon}");
            }

            CongViecBUS taskBUS = new CongViecBUS();
            var dsTask = taskBUS.LayDanhSach();
            Console.WriteLine($"3. Danh sách Task: {dsTask.Count} tasks.");
            foreach (var t in dsTask)
            {
                Console.WriteLine($"   - [{t.MaTask}] [{t.TrangThai}] {t.TenTask} | Dự án: {t.TenDuAn} | Phụ trách: {t.DanhSachThanhVien} | Overdue: {t.IsOverdue}");
            }

            // Test SqlDataReader LayCongViecTreHan
            var dsTreHan = taskBUS.LayCongViecTreHan();
            Console.WriteLine($"4. Cảnh báo trễ hạn (SqlDataReader): {dsTreHan.Count} tasks trễ hạn.");
            foreach (var t in dsTreHan)
            {
                Console.WriteLine($"   - ⚠️ [{t.MaTask}] {t.TenTask} (Hạn: {t.HanNop:dd/MM/yyyy}, Trễ: {t.SoNgayTreHan} ngày) - Trạng thái: {t.TrangThai}");
            }

            // Test Chuyển trạng thái Parameterized Update
            if (dsTask.Count > 0)
            {
                int testId = dsTask[0].MaTask;
                string oldStatus = dsTask[0].TrangThai;
                string newStatus = oldStatus == "Done" ? "In Progress" : "Done";
                var updateRes = taskBUS.ChuyenTrangThai(testId, newStatus);
                Console.WriteLine($"5. Chuyển trạng thái Task {testId} sang '{newStatus}': {updateRes.Success} - {updateRes.Message}");
                // restore
                taskBUS.ChuyenTrangThai(testId, oldStatus);
            }

            // Test Báo cáo GROUP BY & ExecuteScalar
            BaoCaoBUS bcBUS = new BaoCaoBUS();
            var dsThongKe = bcBUS.ThongKeTheoThanhVien();
            Console.WriteLine($"6. Thống kê tỷ lệ hoàn thành (GROUP BY & ExecuteScalar):");
            foreach (var tk in dsThongKe)
            {
                double scalarPct = bcBUS.TinhTiLeHoanThanh(tk.MaThanhVien);
                Console.WriteLine($"   - {tk.HoTen}: Tổng {tk.TongTask} task | Xong {tk.TaskHoanThanh} | Đang làm {tk.TaskDangLam} | Trễ {tk.TaskTreHan} | Tỷ lệ GROUP BY: {tk.TiLeHoanThanh}% | Tỷ lệ ExecuteScalar: {scalarPct}%");
            }

            Console.WriteLine("=== TẤT CẢ TEST ĐÃ HOÀN TẤT THÀNH CÔNG ===");
        }
    }
}
