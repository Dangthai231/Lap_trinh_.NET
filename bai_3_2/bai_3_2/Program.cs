using System;

namespace BAI_TAP_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Giai va bien luan phuong trinh bac 2 (ax^2 + bx + c = 0)");

            // 1. Nhap 3 he so a, b, c (double)
            Console.Write("Nhap he so a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap he so b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap he so c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            // 2. Xu ly truong hop a = 0 (Phuong trinh tro thanh bac nhat bx + c = 0)
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        Console.WriteLine("Phuong trinh co vo so nghiem.");
                    }
                    else
                    {
                        Console.WriteLine("Vo nghiem.");
                    }
                }
                else
                {
                    double x = -c / b;
                    Console.WriteLine($"Phuong trinh tro thanh bac 1. Nghiem x={x:F2}");
                }
            }
            // 3. Khi a != 0, tinh Delta = b^2 - 4ac: tim nghiem
            else
            {
                double delta = b * b - 4 * a * c;

                if (delta < 0)
                {
                    Console.WriteLine("Vo nghiem.");
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine($"Nghiem kep x={x:F2}");
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    // Hien thi 2 chu so thap phan de khop voi TestCases
                    Console.WriteLine($"x1={x1:F2},x2={x2:F2}");
                }
            }

            Console.ReadKey();
        }
    }
}