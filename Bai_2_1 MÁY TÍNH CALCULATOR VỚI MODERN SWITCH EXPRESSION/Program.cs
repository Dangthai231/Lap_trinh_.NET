using System;
using System.Text;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt có dấu trên Console
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                // Nhập dữ liệu
                Console.Write("Nhập số thứ nhất a: ");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhập số thứ hai b: ");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhập phép toán (+, -, *, /, %): ");
                char op = Console.ReadKey().KeyChar;
                Console.WriteLine();

                // Sử dụng Modern Switch Expression và Pattern Matching (từ C# 8.0)
                string result = op switch
                {
                    '+' => (a + b).ToString("F2"),
                    '-' => (a - b).ToString("F2"),
                    '*' => (a * b).ToString("F2"),
                    // Pattern matching với mệnh đề 'when' để kiểm tra b == 0
                    '/' when b == 0 => throw new DivideByZeroException("Lỗi: Không thể chia cho 0!"),
                    '/' => (a / b).ToString("F2"),
                    '%' when b == 0 => throw new DivideByZeroException("Lỗi: Không thể chia cho 0!"),
                    '%' => (a % b).ToString("F2"),
                    _ => throw new InvalidOperationException("Phép toán không hợp lệ!")
                };

                // In kết quả nếu không có lỗi
                Console.WriteLine($"Kết quả: {result}");
            }
            catch (DivideByZeroException ex)
            {
                // Bắt ngoại lệ chia cho 0
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Lỗi: Định dạng số nhập vào không hợp lệ!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
    }
}