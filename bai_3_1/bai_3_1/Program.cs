using System;

namespace BAI_TAP_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MAY TINH CALCULATOR VOI MODERN SWITCH EXPRESSION\n");

            // 1. Nhập vào số thứ nhất a, phép toán op, số thứ hai b
            Console.Write("Nhap so thu nhat a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap phep toan (+, -, *, /, %): ");
            char op = Console.ReadLine()[0];

            Console.Write("Nhap so thu hai b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            // 2 & 3. Sử dụng switch expression và pattern matching để tính toán & bắt lỗi
            string result = op switch
            {
                '+' => (a + b).ToString("F2"),
                '-' => (a - b).ToString("F2"),
                '*' => (a * b).ToString("F2"),

                // Pattern matching: Kiểm tra điều kiện b == 0 ngay trong nhánh '/' và '%'
                '/' when b == 0 => "Loi: Khong the chia cho 0!",
                '/' => (a / b).ToString("F2"),

                '%' when b == 0 => "Loi: Khong the chia cho 0!",
                '%' => (a % b).ToString("F2"),

                // Nhánh mặc định (tương đương default trong switch thường)
                _ => "Phep toan khong hop le!"
            };

            // In kết quả
            Console.WriteLine($"\nKet qua: {result}");

            Console.ReadKey();
        }
    }
}