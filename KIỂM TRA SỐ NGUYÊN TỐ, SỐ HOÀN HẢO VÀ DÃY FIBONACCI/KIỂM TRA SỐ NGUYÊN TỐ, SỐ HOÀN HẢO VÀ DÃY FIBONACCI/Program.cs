using System;

namespace BAI_TAP_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            // 1. Nhập vào số nguyên dương N
            Console.Write("Nhap vao so nguyen duong N: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Vui long nhap so nguyen duong! Nhap lai N: ");
            }

            // Hiển thị kết quả kiểm tra Số hoàn hảo
            if (IsPerfectNumber(n))
            {
                Console.Write($"{n} la So hoan hao! ");
            }
            else
            {
                Console.Write($"{n} KHONG la So hoan hao! ");
            }

            // Hiển thị kết quả kiểm tra Số nguyên tố
            if (IsPrime(n))
            {
                Console.WriteLine($"{n} la So nguyen to.");
            }
            else
            {
                Console.WriteLine($"{n} KHONG la So nguyen to.");
            }

            // 4. In ra N số đầu tiên của dãy Fibonacci
            Console.Write($"Day Fibonacci {n} so: ");
            PrintFibonacci(n);

            Console.ReadKey();
        }

        // 2. Viết hàm kiểm tra Số nguyên tố
        static bool IsPrime(int n)
        {
            if (n < 2) return false;

            // Sử dụng vòng lặp for để kiểm tra ước
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // 3. Viết hàm kiểm tra Số hoàn hảo
        static bool IsPerfectNumber(int n)
        {
            if (n < 2) return false;

            int sum = 0;
            // Số hoàn hảo bằng tổng các ước thực sự của nó
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }

            return sum == n;
        }

        // Hàm hỗ trợ in dãy Fibonacci
        static void PrintFibonacci(int n)
        {
            long f0 = 0, f1 = 1;

            for (int i = 0; i < n; i++)
            {
                // Xử lý dấu phẩy để in chuẩn như Testcase (0, 1, 1, 2, 3, 5)
                if (i == n - 1)
                {
                    Console.Write($"{f0}");
                }
                else
                {
                    Console.Write($"{f0}, ");
                }

                long fn = f0 + f1;
                f0 = f1;
                f1 = fn;
            }
            Console.WriteLine();
        }
    }
}