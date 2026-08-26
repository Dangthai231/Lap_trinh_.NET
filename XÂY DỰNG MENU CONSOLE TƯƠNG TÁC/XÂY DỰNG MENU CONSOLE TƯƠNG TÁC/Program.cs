using System;

namespace XAY_DUNG_MENU_CONSOLE_TUONG_TAC
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("============= MENU =============");
                Console.WriteLine("1. Chay Bai tap 1 (Calculator)");
                Console.WriteLine("2. Chay Bai tap 2 (Phuong trinh bac 2)");
                Console.WriteLine("3. Chay Bai tap 3 (So nguyen to & Fibonacci)");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("================================");
                Console.Write("Nhap lua chon cua ban (0-3): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n[Dang thuc thi] Bai tap 1 (Calculator)...");
                            RunCalculator();
                            break;
                        case 2:
                            Console.WriteLine("\n[Dang thuc thi] Bai tap 2 (Phuong trinh bac 2)...");
                            RunQuadraticEquation();
                            break;
                        case 3:
                            Console.WriteLine("\n[Dang thuc thi] Bai tap 3 (So nguyen to & Fibonacci)...");
                            RunPrimeAndFibonacci();
                            break;
                        case 0:
                            Console.WriteLine("\nChuong trinh dang thoat. Tam biet!");
                            break;
                        default:
                            Console.WriteLine("\nLua chon khong hop le. Vui long nhap so tu 0 den 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nLoi: Vui long nhap mot so nguyen hop le.");
                    choice = -1;
                }

                if (choice != 0)
                {
                    Console.WriteLine("\nNhan phim bat ky de quay lai Menu...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }

        // ================= HAM XU LY BAI 1 =================
        static void RunCalculator()
        {
            try
            {
                Console.Write("Nhap so thu nhat: ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap phep toan (+, -, *, /): ");
                char op = Console.ReadLine()[0];
                Console.Write("Nhap so thu hai: ");
                double b = Convert.ToDouble(Console.ReadLine());

                switch (op)
                {
                    case '+': Console.WriteLine($"Ket qua: {a} + {b} = {a + b}"); break;
                    case '-': Console.WriteLine($"Ket qua: {a} - {b} = {a - b}"); break;
                    case '*': Console.WriteLine($"Ket qua: {a} * {b} = {a * b}"); break;
                    case '/':
                        if (b != 0) Console.WriteLine($"Ket qua: {a} / {b} = {a / b}");
                        else Console.WriteLine("Loi: Khong the chia cho 0!");
                        break;
                    default: Console.WriteLine("Phep toan khong hop le."); break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Du lieu nhap vao khong hop le!");
            }
        }

        // ================= HAM XU LY BAI 2 =================
        static void RunQuadraticEquation()
        {
            try
            {
                Console.WriteLine("Giai phuong trinh ax^2 + bx + c = 0");
                Console.Write("Nhap he so a: ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap he so b: ");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap he so c: ");
                double c = Convert.ToDouble(Console.ReadLine());

                if (a == 0)
                {
                    if (b == 0)
                    {
                        if (c == 0) Console.WriteLine("Phuong trinh co vo so nghiem.");
                        else Console.WriteLine("Phuong trinh vo nghiem.");
                    }
                    else
                    {
                        Console.WriteLine($"Phuong trinh co 1 nghiem: x = {-c / b}");
                    }
                }
                else
                {
                    double delta = b * b - 4 * a * c;
                    if (delta < 0)
                    {
                        Console.WriteLine("Phuong trinh vo nghiem.");
                    }
                    else if (delta == 0)
                    {
                        Console.WriteLine($"Phuong trinh co nghiem kep x1 = x2 = {-b / (2 * a)}");
                    }
                    else
                    {
                        double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                        Console.WriteLine($"Phuong trinh co 2 nghiem phan biet:\nx1 = {x1}\nx2 = {x2}");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Du lieu nhap vao khong hop le!");
            }
        }

        // ================= HAM XU LY BAI 3 =================
        static void RunPrimeAndFibonacci()
        {
            try
            {
                Console.Write("Nhap mot so nguyen duong n: ");
                int n = Convert.ToInt32(Console.ReadLine());

                if (n < 0)
                {
                    Console.WriteLine("Vui long nhap so nguyen duong.");
                    return;
                }

                // Kiem tra So nguyen to
                bool isPrime = n > 1;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{n} {(isPrime ? "LA" : "KHONG PHAI")} so nguyen to.");

                // In day Fibonacci
                Console.Write($"Day Fibonacci toi {n} phan tu: ");
                long f0 = 0, f1 = 1;
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{f0} ");
                    long fn = f0 + f1;
                    f0 = f1;
                    f1 = fn;
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Du lieu nhap vao khong hop le!");
            }
        }
    }
}