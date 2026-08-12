using System;
namespace NetInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font chữ UTF-8 để hiển thị tiếng Việt trên Console không bị lỗi font
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== THÔNG TIN MÔI TRƯỜNG THỰC THI ===");
            Console.WriteLine("--------------------------------------\n");

            // 1. Phiên bản CLR/.NET Core đang chạy (Environment.Version)
            Console.WriteLine($"1. Phiên bản CLR/.NET đang chạy: {Environment.Version}");

            // 2. Tên máy tính và tên người dùng đăng nhập hệ thống
            Console.WriteLine($"2. Tên máy tính: {Environment.MachineName}");
            Console.WriteLine($"   Tên người dùng hiện tại: {Environment.UserName}");

            // 3. Hệ điều hành và kiến trúc CPU (64-bit / 32-bit)
            // Lấy thông tin 64-bit hay 32-bit
            string osArch = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
            Console.WriteLine($"3. Hệ điều hành: {Environment.OSVersion.VersionString}");
            Console.WriteLine($"   Kiến trúc: {osArch}");

            // 4. Dung lượng bộ nhớ RAM đang được Garbage Collector (GC) quản lý
            // Trả về số byte hiện tại đang được cấp phát. Tham số 'false' nghĩa là không ép buộc GC phải thu gom rác ngay lập tức trước khi đo.
            long memoryInBytes = GC.GetTotalMemory(false);

            // Chuyển đổi sang Megabyte (MB) để dễ đọc hơn
            double memoryInMB = memoryInBytes / (1024.0 * 1024.0);

            Console.WriteLine($"4. Bộ nhớ RAM do GC quản lý: {memoryInBytes:N0} bytes (Khoảng {memoryInMB:F2} MB)");

            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}